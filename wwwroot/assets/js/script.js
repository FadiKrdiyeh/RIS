$(document).ready(function () {
    var w = window.innerWidth;

    if (w > 767) {
        $('#menu-jk').scrollToFixed();
    } else {
        // $('#menu-jk').scrollToFixed();
    }



});


$(document).ready(function() {

    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:0,
        nav:true,
        autoplay: true,
        dots: true,
        autoplayTimeout: 5000,
        navText:['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });

    $(".moved-label").on("focus", function () {
        $(this).siblings("label").css({
            "top": "-30px",
            "font-size": "16px",
            "color": "#111"
        });
        //let checkIfNull = $(this).val();
        //console.log(checkIfNull);
        //console.log("Arrived");
    });
    $(".moved-label").on("blur", function () {
        let checkIfNull = $(this).val();
        if (checkIfNull == "") {
            $(this).siblings("label").css({
                "top": "5px",
                "font-size": "20px",
                "color": "#555"
            });
        }
        //console.log(checkIfNull);
        //console.log("Arrived");
    });
    // console.log("test");
    $('#Input_UserName').focus();
    $('#account').on('submit', function (e) {
        let username = $("#Input_UserName").val();
        let password = $("#Input_Password").val();
        if (username != "" && password != "") {
            // e.preventDefault();
            let but = $(this).find('[type="submit"]').toggleClass('sending').blur();
            setTimeout(function () {
                but.removeClass('sending').blur();
            }, 4500);
        } else {
            e.preventDefault();
            let but = $(this).find('[type="submit"]').toggleClass('sending').blur();

            setTimeout(function () {
                but.removeClass('sending').blur();
            }, 1500);
        }

    })
});

// Toggle Info Button In Create Patient Page
$(document).ready(function () {
    // $("#firstname").focus();

    // $('#infoToShow').toggle();
    $('#otherInfo').click(function () {
        $(this).find('i').toggleClass('fa-angle-double-down');
        $(this).find('i').toggleClass('fa-angle-double-up');
        $('#infoToShow').slideToggle(2000);
    });
});

// Change Select Style
$('select').not('.original').each(function () {
    var $this = $(this), numberOfOptions = $(this).children('option').length;

    $this.addClass('select-hidden');
    $this.wrap('<div class="select"></div>');
    $this.after('<div class="select-styled form-control"></div>');

    var $styledSelect = $this.next('div.select-styled');
    $styledSelect.text($this.children('option').eq(0).text());

    var $list = $('<ul />', {
        'class': 'select-options'
    }).insertAfter($styledSelect);

    for (var i = 0; i < numberOfOptions; i++) {
        $('<li />', {
            text: $this.children('option').eq(i).text(),
            rel: $this.children('option').eq(i).val()
        }).appendTo($list);
        //if ($this.children('option').eq(i).is(':selected')){
        //  $('li[rel="' + $this.children('option').eq(i).val() + '"]').addClass('is-selected')
        //}
    }

    var $listItems = $list.children('li');

    $styledSelect.click(function (e) {
        e.stopPropagation();
        $('div.select-styled.active').not(this).each(function () {
            $(this).removeClass('active').next('ul.select-options').slideUp();
        });
        $(this).toggleClass('active').next('ul.select-options').slideToggle();
    });

    $listItems.click(function (e) {
        e.stopPropagation();
        $styledSelect.text($(this).text()).removeClass('active');
        $this.val($(this).attr('rel'));
        $this.find('option').removeAttr('selected');
        $this.find('option[value="' + $(this).attr('rel') + '"]').attr('selected', 'selected');
        $list.hide();
        //console.log($this.val());
    });

    $(document).click(function () {
        $styledSelect.removeClass('active');
        $list.hide();
    });

});