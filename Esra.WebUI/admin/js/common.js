$(document).ready(function () {
    var menu = $('.hamburgerNav');
    menu.on('click', function () {
        if (menu.hasClass('is-active'))
            $('.nav > li').slideDown();
        if (!menu.hasClass('is-active'))
            $('.nav > li:not(:last-child)').slideUp();
    })
    var subMenu = $('.nav > li:not(:last-child)');
    subMenu.on('click', function () {
        var This = $(this).find('ul');
        if ($(window).width() < 845)
            $('.nav > li').find('ul').not(This).slideUp();


        if ($(window).width() < 845) {
            if (This.css('display') == ('block'))
                This.slideUp(function () {
                    This.css('display', 'none');

                });
            if (This.css('display') == ('none'))
                This.slideDown(function () {
                    This.css('display', 'block');
                });
        }
    });
    $(window).resize(function () {

        if ($(window).width() < 845) {
            $('.nav > li:not(:last-child)').find('ul > li > a').css('display', '');

        } else {
            $('.nav > li').css('display', '');
            $('.hamburgerNav').removeClass('is-active');
            $('.nav > li').find('ul').css('display', '');


        }
        if ($(window).width() < 640) {

        } else {
            $('.SubSearch').css('display', '');
            $('.hamburgerSearch').removeClass('is-active');

        }

        var isAndroidSelect = $('#cpBodyMiddle_ddlGamePlatform option#8').hasClass('js-active');
        var close = "75";
        var open = "175";
        if ($(window).width() > 1020) {
            close = "175px", open = "310px";
        }
        if ($(window).width() > 845 && $(window).width() <= 1020) {
            close = "110px", open = "230px";
        }
        if ($(window).width() > 660 && $(window).width() <= 845) {
            close = "75px", open = "175px";

        }
        if ($(window).width() <= 643) {
            close = "82%", open = "82%";

        }
        if (isAndroidSelect)
            open = close;
        $('#cpBodyMiddle_txtSearchGameName').animate({
            width: open
        }, 1);
    });
    var subSearch = $('.hamburgerSearch');
    subSearch.on('click', function () {
        if ($(window).width() < 845) {
            $('.SubSearch').slideToggle();
        }
    });
    $('.c_select').find('option:first-child').on('click', function () {
        var This = $(this).parent();
        This.find('.js-open-drop').slideToggle(100);
    });
    $('.js-open-drop').on('mouseleave', function () {
        $('.js-open-drop').slideUp(100);

    });
    $('.js-open-drop option').on('click', function () {
        var isAndroidSelect = $('#cpBodyMiddle_ddlGamePlatform option#8').hasClass('js-active');
        //console.log("isAndroidSelect: " + isAndroidSelect);
        if ($(this).parent().attr('id').indexOf('ddlGamePlatform') > -1) {
            if (!isAndroidSelect || $(this).attr('id') === '8') {
                if (!isAndroidSelect && $(this).attr('id') === '8')
                    $(this).parent().find('option').removeClass('js-active');
                $(this).toggleClass("js-active");
            }
        } else {
            $(this).toggleClass("js-active");
        }
        if ($(this).attr('id') === '8' && $(this).parent().hasClass('js-intro')) {
            showAndroidButton($(this));
        }
        if ($(this).parent().find('option').hasClass('js-active'))
            $(this).parent().parent().css('background-color', '#1fb25a');
        else
            $(this).parent().parent().css('background-color', '#464646');


    });
    $('#cpBodyMiddle_btnSearch').on('click', function () {
        var hfSearchGenres = "", hfSearchAges = "", hfSearchPlatform = "";
        $('#cpBodyMiddle_ddlGenres').find('.js-active').each(function () { hfSearchGenres += ($(this).attr('id') + ',') });
        $('#cpBodyMiddle_ddlAges').find('.js-active').each(function () { hfSearchAges += ($(this).attr('id') + ',') });
        $('#cpBodyMiddle_ddlGamePlatform').find('.js-active').each(function () { hfSearchPlatform += ($(this).attr('id') + ',') });
        $('#cpBodyBottom_hfSearchGenres').val(hfSearchGenres);
        $('#cpBodyBottom_hfSearchAges').val(hfSearchAges);
        $('#cpBodyBottom_hfSearchPlatform').val(hfSearchPlatform);
    });
    $('.js-select-age').on('click', function () {
        var thiss = $(this);
        var age = $(this).attr('data-age');
        var color = '';
        if (age === '18') color = '#ed1b2c';
        if (age === '15') color = '#f58220';
        if (age === '12') color = '#faa61a';
        if (age === '7') color = '#1fb25a';
        if (age === '3') color = '#57bc72';
        $('.height3').animate({
            backgroundColor: color
        }, 150);
        $('.js-ages-active').fadeOut(50, function () {
            $('[data-agee="' + age + '"]').fadeIn(250, function () {
                $(this).removeClass('js-ages').addClass('js-ages-active');
            });
            $(this).removeClass('js-ages-active').addClass('js-ages');
        });
        $('.js-DivAge-open').fadeOut(200, function () {
            $('[data-age-content="' + age + '"]').fadeIn(function () {
                $(this).removeClass('js-DivAge-close').addClass('js-DivAge-open');
            });
            $(this).removeClass('js-DivAge-open').addClass('js-DivAge-close');


        });
        thiss.parent().parent().find('i').remove();
        thiss.append('<i style="color:' + color + ';" class="fa fa-chevron-down fa-2x" aria-hidden="true"></i>').hide().fadeIn();

    });
    $('.js-delPic').on('click', function () {
        if (!$(this).hasClass('img-removed')) {
            $(this).html("undo");
            $(this).parent().parent().fadeTo(500, 0.5);
            $(this).addClass('img-removed');
            $('#txtPicName').val($('#txtPicName').val().replace($(this).next().html(), ""));
        } else {
            $(this).html("remove");
            $(this).parent().parent().fadeTo(500, 1);
            $(this).removeClass('img-removed');
            $('#txtPicName').val($('#txtPicName').val() + $(this).next().html() + ',');
        }
    });
    $('.js-IsCover').on('click', function () {
        if (!$(this).hasClass('isCover')) {
            $('.js-IsCover:nth(0)').parent().parent().parent().find('.isCover').removeClass('isCover').css('background-color', 'rgba(0, 0, 0, 0.7)');
            $(this).html("cover");
            $(this).addClass('isCover');
            $(this).css('background-color', 'green');
        } else {
            $(this).html("cover");
            $(this).removeClass('isCover');
            $(this).css('background-color', 'rgba(0, 0, 0, 0.7)');
        }
    });

    $('.gameLargLogoHolder img').on('mouseover', function () {
        $('.gameLargLogoHolder img').css('z-index', '0');
        $('.gameLargLogoHolder img').css('transform', 'none');

        $(this).css('z-index', '999');
    });
});

$(document).ready(function () {
    var offset = 20;
    var duration = 300;
    $(window).scroll(function () {
        if ($(this).scrollTop() > offset) {
            $('.back-to-top').fadeIn(duration);
        } else {
            $('.back-to-top').fadeOut(duration);
        }
    });
    $('.back-to-top').click(function (event) {
        event.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    });
    $('.js-loadCart').click(function (event) {
        var offset = 79;
        if ($(window).width() <= 845) {
            offset = 165;
        }
        if ($(this).hasClass('cart1')) offset = $('div.cart1').position().top - offset;
        if ($(this).hasClass('cart2')) offset = $('div.cart2').position().top - offset;
        if ($(this).hasClass('cart3')) offset = $('div.cart3').position().top - offset;
        if ($(this).hasClass('cart4')) offset = $('div.cart4').position().top - offset;
        if ($(this).hasClass('cart5')) offset = $('div.cart5').position().top - offset;
        if ($(this).hasClass('cart6')) offset = $('div.cart6').position().top - offset;
        event.preventDefault();
        $('html, body').animate({ scrollTop: offset }, duration);
        return false;
    });
});

function showAndroidButton(tag) {
    var close = "75";
    var open = "175";
    if ($(window).width() > 1020) {
        close = "175px", open = "310px";
    }
    if ($(window).width() > 845 && $(window).width() <= 1020) {
        close = "110px", open = "230px";
    }
    if ($(window).width() > 660 && $(window).width() <= 845) {
        close = "75px", open = "175px";
    }
    if ($(tag).hasClass('js-active')) {
        $('#cpBodyMiddle_txtSearchGameName').animate({
            width: close
        }, 500, function () {
            $('.js-ddlGameCategory').fadeIn();
        });
    } else {
        $('.js-ddlGameCategory').fadeOut(function () {
            $('#cpBodyMiddle_txtSearchGameName').animate({
                width: open
            }, 500);
        });
    }
}

function makeid(size) {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < size; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return text;
}

function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}