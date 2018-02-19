using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mlm.Models;
using mlm.Models.ChatModel.mlm;

namespace mlm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MessageModel> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
//            builder.Entity<Friend>()
//                .HasOne(a => a.RequestedBy)
//                .WithMany(b => b.SentFriendRequests)
//                .HasForeignKey(c => c.RequestedById);
//
//            builder.Entity<Friend>()
//                .HasOne(a => a.RequestedTo)
//                .WithMany(b => b.ReceievedFriendRequests)
//                .HasForeignKey(c => c.RequestedToId);
        }
    }
}