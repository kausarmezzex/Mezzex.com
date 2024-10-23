(function($) {
  "use strict";
    $(window).scroll(function () {
        var window_top = $(window).scrollTop() + 1;

        // Check if the scroll is greater than 50px
        if (window_top > 50) {
            console.log('Adding class');  // Log this to check
            $('.main_menu').addClass('menu_fixed animated fadeInDown'); // Add class to the main menu
            $('.main_menu .main-menu-item ul li .nav-link').addClass('text-black'); // Add text-black class to the specific nav-link
        } else {
            console.log('Removing class');  // Log this to check
            $('.main_menu').removeClass('menu_fixed animated fadeInDown'); // Remove class from the main menu
            $('.main_menu .main-menu-item ul li .nav-link').removeClass('text-black'); // Remove text-black class from the specific nav-link
        }
    });


  $(".popup-youtube, .popup-vimeo").magnificPopup({
    // disableOn: 700,
    type: "iframe",
    mainClass: "mfp-fade",
    removalDelay: 160,
    preloader: false,
    fixedContentPos: false
  });

  $(document).ready(function() {
    $("select").niceSelect();
  });



var client_logo = $(".client_logo_slider");
    if (client_logo.length) {
      client_logo.owlCarousel({
        items: 6,
        loop: true,
        dots: true,
        autoplay: true,
        margin: 40,
        autoplayHoverPause: true,
        autoplayTimeout: 2000,
        nav: true,
        responsive: {
        0: {
          items: 3,
          margin: 15
        },
        600: {
          items: 3,
          margin: 15
        },
        991: {
          items: 5,
          margin: 15
        },
        1200: {
          items: 6,
          margin: 15
        }
      }
      });
    }

 /* var client_logo = $(".client_logo_slider");
  if (client_logo.length) {
    client_logo.owlCarousel({
      items: 6,
      loop: true,
	  dots: true,
        autoplay: true,
        margin: 40,
        autoplayHoverPause: true,
        autoplayTimeout: 5000,
        nav: true,
      responsive: {
        0: {
          items: 3,
          margin: 15
        },
        600: {
          items: 3,
          margin: 15
        },
        991: {
          items: 5,
          margin: 15
        },
        1200: {
          items: 6,
          margin: 15
        }
      }
    });
  } */
  
   var review = $(".review_part_text");
    if (review.length) {
      review.owlCarousel({
        items: 2,
        loop: true,
        dots: true,
        autoplay: true,
        margin: 40,
        autoplayHoverPause: true,
        autoplayTimeout: 4000,
        nav: false,
        responsive: {
          0: {
            items: 1
          },
          480: {
            items: 1
          },
          768: {
            items: 2
          }
        }
      });
    }

  $(window).on("load", function() {
    if (document.getElementById("portfolio")) {
      var $workGrid = $(".portfolio-grid").isotope({
        itemSelector: ".all"
      });
    }

    $(".portfolio-filter ul li").on("click", function() {
      $(".portfolio-filter ul li").removeClass("active");
      $(this).addClass("active");

      var data = $(this).attr("data-filter");
      $workGrid.isotope({
        filter: data
      });
    });

   

    $(".popup-youtube, .popup-vimeo").magnificPopup({
      // disableOn: 700,
      type: "iframe",
      mainClass: "mfp-fade",
      removalDelay: 160,
      preloader: false,
      fixedContentPos: false
    });
  });

})(jQuery);
