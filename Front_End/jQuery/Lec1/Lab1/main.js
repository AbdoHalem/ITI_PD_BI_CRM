$(document).ready(function() {
    // Hide all sections initially when the page loads
    $('.section').hide();

    //? --- 1. Navigation Logic ---

    $('#btn-about').click(function() {
        // Hide all sections, then show only About
        $('.section').hide();
        $('#about-sec').show();
    });

    $('#btn-gallery').click(function() {
        $('.section').hide();
        $('#gallery-sec').show();
    });

    $('#btn-services').click(function() {
        // Hide other main contents
        $('#about-sec, #gallery-sec, #complain-sec').hide();
        // Toggle the dropdown menu visibility with a sliding motion
        $('#services-menu').slideToggle('fast');
    });

    $('#btn-complain').click(function() {
        $('.section').hide();
        $('#complain-sec').show();
        // Ensure form is visible and result is hidden if returning to this tab
        $('#form-view').show();
        $('#result-view').hide();
    });


    //? --- 2. Gallery Slider Logic ---
    
    // Array holding the image file names
    var images = ['snow1.jpg', 'snow2.jpg', 'snow3.jpg'];
    var currentIndex = 0;

    $('#next-btn').click(function() {
        currentIndex++;
        // Reset to first image if we reach the end
        if (currentIndex >= images.length) {
            currentIndex = 0;
        }
        // Change the src attribute of the image tag
        $('#slider-img').attr('src', images[currentIndex]);
    });

    $('#prev-btn').click(function() {
        currentIndex--;
        // Go to the last image if we go below 0
        if (currentIndex < 0) {
            currentIndex = images.length - 1;
        }
        $('#slider-img').attr('src', images[currentIndex]);
    });


    //? --- 3. Complain Form Logic ---

    $('#send-btn').click(function() {
        // Retrieve values from the input fields
        var userName = $('#input-name').val();
        var userEmail = $('#input-email').val();
        var userPhone = $('#input-phone').val();
        var userComplain = $('#input-complain').val();

        // Inject the retrieved values into the result span tags
        $('#res-name').text(userName);
        $('#res-email').text(userEmail);
        $('#res-phone').text(userPhone);
        $('#res-complain').text(userComplain);

        // Hide the input form and show the result view
        $('#form-view').hide();
        $('#result-view').show();
    });

    $('#back-btn').click(function() {
        // Hide the result view and bring back the form
        // Note: The inputs will still contain the old data because we didn't clear them
        $('#result-view').hide();
        $('#form-view').show();
    });
});