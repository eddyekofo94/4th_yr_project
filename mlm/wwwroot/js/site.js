// Write your JavaScript code.
(function ($) {
    "use strict"; // Start of use strict
    
    // For the side-nav
    $('[data-toggle=offcanvas]').click(function () {
        $('.sidebar').toggleClass('active');
    });


})(jQuery); // End of use strict
