﻿// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreSpa.Server.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCoreSpa.Server.Services;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Localization;
using AspNetCoreSpa.Server.ViewModels;
using System.Globalization;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetCoreSpa.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly IHostingEnvironment _env;
        private readonly IMemoryCache _cache;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment env,
            IStringLocalizer<HomeController> stringLocalizer,
            IMemoryCache memoryCache
            )
        {
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _env = env;
            _cache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            if (ConfirmEmailRequest())
            {
                await ConfirmEmail();
            }

            var content = GetContentByCulture();

            ViewBag.content = content;

            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect("~/");
        }

        private bool ConfirmEmailRequest()
        {
            return Request.Query.ContainsKey("emailConfirmCode") && Request.Query.ContainsKey("userId");
        }

        private async Task ConfirmEmail()
        {
            var userId = Request.Query["userId"].ToString();
            var code = Request.Query["emailConfirmCode"].ToString();
            code = code.Replace(" ", "+");

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !user.EmailConfirmed)
            {
                var valid = await _userManager.ConfirmEmailAsync(user, code);
                if (valid.Succeeded)
                {
                    ViewBag.emailConfirmed = true;
                }
            }
        }

        private string GetContentByCulture()
        {
            var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = requestCulture.RequestCulture.Culture;

            var CACHE_KEY = $"Content-{culture.Name}";


            string cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CACHE_KEY, out cacheEntry))
            {
                // Key not in cache, so get & set data.
                var culturalContent = _stringLocalizer.WithCulture(culture)
                                        .GetAllStrings()
                                        .Select(c => new ContentVm
                                        {
                                            Key = c.Name,
                                            Value = c.Value
                                        })
                                        .ToDictionary(x => x.Key, x => x.Value);
                cacheEntry = Helpers.JsonSerialize(culturalContent);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                // Save data in cache.
                _cache.Set(CACHE_KEY, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }

    }
}
