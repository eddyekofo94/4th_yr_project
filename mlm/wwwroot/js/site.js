// Write your JavaScript code.
(function ($) {
    "use strict"; // Start of use strict

    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: (target.offset().top - 54)
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $('.js-scroll-trigger').click(function () {
        $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
        target: '#mainNav',
        offset: 54
    });

// Chat Signalr
    let transport = signalR.TransportType.WebSockets;
    let connection = new signalR.HubConnection(`http://${document.location.host}/chat`, {transport: transport});

    $(document).ready(function () {
//        TODO: Query all the table and every user's messages

//        $.ajax({
//            url: "http://localhost:5000/api/chat/get",
//            method: 'GET',
//            dataType: 'JSON',
//            success: addPostsList
//        });

        $("#messageIn").focus(); //    focuses on the text form

 

        function addPost(post) {
//            console.log('New post from server: ', post);
            $("#messages")
                .append('<li>' +
                    post.author +
                    ': ' +
                    post.content +
                    " Translated: " +
                    post.contentTranslated +
                    '</li>');
        }

        connection.on('Send',
            (message) => {
                $.each(message,
                    function (index) {
                        var post = message[index];
                        console.log(post);
                    });
                addPost(message); // Adds each message
                newMessage()
            });
    });


    connection.start().catch(err => {
        console.log('connection error');
    });

//    Messages
    $(".messages").animate({scrollTop: $(document).height()}, "fast");

    $("#profile-img").click(function () {
        $("#status-options").toggleClass("active");
    });

    $(".expand-button").click(function () {
        $("#profile").toggleClass("expanded");
        $("#contacts").toggleClass("expanded");
    });

    $("#status-options ul li").click(function () {
        $("#profile-img").removeClass();
        $("#status-online").removeClass("active");
        $("#status-away").removeClass("active");
        $("#status-busy").removeClass("active");
        $("#status-offline").removeClass("active");
        $(this).addClass("active");

        if ($("#status-online").hasClass("active")) {
            $("#profile-img").addClass("online");
        } else if ($("#status-away").hasClass("active")) {
            $("#profile-img").addClass("away");
        } else if ($("#status-busy").hasClass("active")) {
            $("#profile-img").addClass("busy");
        } else if ($("#status-offline").hasClass("active")) {
            $("#profile-img").addClass("offline");
        } else {
            $("#profile-img").removeClass();
        }

        $("#status-options").removeClass("active");
    });

    function newMessage() {
        let message = $("#messageIn").val();
        console.log(message);
        if ($.trim(message) == '') {
            return false;
        }
        $('<li class="sent"><img src="http://emilcarlsson.se/assets/mikeross.png" alt="" /><p>' + message + '</p></li>').appendTo($('.messages ul'));
        $('.message-input input').val(null);
        $('.contact.active .preview').html('<span>You: </span>' + message);
        $(".messages").animate({scrollTop: $(document).height()}, "fast");
    };

    $('.submit').click(function () {
        newMessage();
    });
    $(".message-input").submit(function () {
        var msg = $('#messageIn').val();
        console.log(msg);
        $.post("http://localhost:5000/api/chat/send/" + msg,
            function (data) {
                console.log(data);
            });

        $(".message-input").trigger("reset"); // ressets the form

    });
    $(window).on('keydown', function (e) {
        let message = $("#messageIn").val();
        // console.log(message);
        if (e.which == 13) {
            $.post("http://localhost:5000/api/chat/send/" + message,
                function (data) {
                    console.log(data);
                });
            newMessage();
            return false;
        }
    });

})(jQuery); // End of use strict
