// Ensure jQuery and Mixitup are loaded correctly


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    

    <script src="https://cdn.jsdelivr.net/npm/@fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.js"></script>


    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.css" />
$(document).ready(function () {
    // 1. Select the portfolio container
    var containerEl = document.querySelector(".portfolio-item");

    // 2. Initialize Mixitup with all configurations in one place
    var mixer = mixitup(containerEl, {
        animation: {
            effects: "fade translateZ(-100px)",      // Fade with 3D transform
            effectsIn: "fade translateY(-100%)",     // Fade in with Y translation
            easing: "cubic-bezier(0.645, 0.045, 0.355, 1)"  // Custom easing function
        },
        behavior: {
            liveSort: true    // Enable live sorting
        },
        load: {
            sort: 'edited:desc'   // Sort items based on 'data-edited' attribute, descending
        }
    });

    // 3. Initialize Fancybox with the required options
    $("[data-fancybox]").fancybox({
        loop: true,   // Loop through gallery images
        hash: true,   // Enable URL hash
        transitionEffect: "slide",   // Slide transition between images
        clickContent: function (current, event) {
            // Customize click behavior: Next image on click
            return current.type === "image" ? "next" : false;
        }
    });

    // 4. Example: Update and sort items dynamically
    var target = containerEl.children[3]; // Select the 4th item (index 3)

    // Get the 'data-edited' attribute value
    console.log(target.getAttribute('data-edited')); // Should log '2015-04-24' or similar

    // Update the 'data-edited' attribute of the target item
    target.setAttribute('data-edited', '2023-08-10'); // Change edited date

    // Re-sort items after updating the attribute
    mixer.sort('edited:desc').then(function (state) {
        // Check if the target item moved to the top of the sorted list
        console.log(state.targets[0] === target); // Should log true if sorted correctly
    });
});
