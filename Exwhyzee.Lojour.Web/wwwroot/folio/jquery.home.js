(function($){
    function initChulan() {
        function number(num, content, target, duration) {
            if (duration) {
                var count    = 0;
                var speed    = parseInt(duration / num);
                var interval = setInterval(function(){
                    if(count - 1 < num) {
                        target.html(count);
                    }
                    else {
                        target.html(content);
                        clearInterval(interval);
                    }
                    count++;
                }, speed);
            }
            else {
                target.html(content);
            }
        }
    	function stats(duration) {
            $('.stats .num').each(function() {
                var container = $(this);
                var num = container.attr('data-num');
                var content  = container.attr('data-content');
                number(num, content, container, duration);
            });
        }
        
        $("a.scroll-link").bind('click', function(event) {
            event.preventDefault();
            var href = $(this).attr('href');
            if(href.indexOf("/#")!=-1){
                href = href.split("/#");
                if(href[1]!='' && href[1]!=undefined) href = "#"+href[1];
            }else href = $(this).attr('href');
            $.scrollTo(
                href,950,{easing:'swing',offset: 0,'axis':'y'} );
            setTimeout( function(){
            },900);
        });
        
//        $(document.body).on('appear', '#about div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#about div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });
    	
//    	if($('.animaper').length)
//        {
//            $('.animaper').appear();
//        }

//        $(document.body).on('appear', '#about div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#about div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });
//        $(document.body).on('appear', '#resume div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#resume div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });
//        $(document.body).on('appear', '#work div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#work div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });
//        $(document.body).on('appear', '#services div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#services div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });
//        $(document.body).on('appear', '#contacts div.anim', function() {
            $(this).each(function(){
                setTimeout (function (){
                    $('#contacts div.anim').animate({opacity:'1', top:'0'},{queue:true,duration:1200});
                }, 600 );
            });
//        });

        var $i = 1;
//        $(document.body).on('appear', '.stats', function(e) {
            if ($i === 1) { stats(2600); }
            $i++;
            $('.num').removeClass('scale-small');
//        });
//        $(document.body).on('appear', '#facts ul li', function(e) {

            $('#facts ul li').removeClass('scale-small');
//        });
        $(".show-skills").on("click",function(e){
            e.preventDefault();
            if($('.piechart-holder').length >0 ){
                $(this).find('i').toggleClass('but-rotade');
                $('.piechart-holder').slideToggle(500);
                setTimeout (function (){
                    $('.chart').easyPieChart({
                        barColor: chulancolor,
                        easing: 'easeOutBounce',
                        onStep: function(from, to, percent) {
                            $(this.el).find('.percent').text(Math.round(percent));
                        }
                    });

                }, 500 );
                var text = $('.show-skills').find('span').text();
                $('.show-skills').find('span').text(
                    text == "show skills" ? "hide skills" : "show skills");
            }
        });

// MagnificPopup  ----------------------------------------
        if($('.popup-with-move-anim').length)
        {
            $('.popup-with-move-anim').magnificPopup({
                type: 'ajax',
                alignTop: true,
                overflowY: 'scroll' ,
                fixedContentPos: false,
                fixedBgPos: true,
                closeBtnInside: false,
                midClick: true,
                removalDelay: 600,
                mainClass: 'my-mfp-slide-bottom',
                callbacks: {
                    elementParse: function(item) {
                        item.src = item.el.attr('data-url');
                    },
                    ajaxContentAdded: function() {
                        $("#project-slider").owlCarousel({
                            navigation : true,
                            pagination:true,
                            slideSpeed : 300,
                            paginationSpeed : 400,
                            singleItem:true,
                            transitionStyle : "backSlide",
                            autoHeight : true
                        });
                        $('.white-popup-block h2').textillate({in:{effect:'flipInX',delayScale: 3.5}});

                    }
                }
            });
        }
        $('.popup-youtube, .popup-vimeo').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            removalDelay: 600,
            mainClass: 'my-mfp-slide-bottom'
        });

        $('.popup-gallery').magnificPopup({
            type: 'image',
            tLoading: 'Loading image #%curr%...',
            removalDelay: 600,
            mainClass: 'my-mfp-slide-bottom',
            gallery: {
                enabled: true,
                navigateByImgClick: true,
                preload: [0,1] // Will preload 0 - before current, and 1 after the current image
            },
            image: {
                tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
            }
        });

        $('.image-popup').magnificPopup({
            type: 'image',
            closeOnContentClick: true,
            removalDelay: 600,
            mainClass: 'my-mfp-slide-bottom',
            image: {
                verticalFit: true
            }
        });


// Navigation + custoum  scripts----------------------------------------

        $('#options li').click(function(){
            $('#options li').removeClass('actcat');
            $(this).addClass('actcat');
        });

        $('#nav').onePageNav({
            currentClass: 'current',
            changeHash: false,
            scrollSpeed: 750,
            scrollOffset: 30,
            scrollThreshold: 0.5,
            filter: '',
            easing: 'swing'
        });

        var ww = $(window).width();

        if( ww < 959){

            $('.link-holder').onePageNav({
                currentClass: 'cur',
                changeHash: false,
                scrollSpeed: 750,
                scrollOffset: 30,
                scrollThreshold: 0.5,
                filter: '',
                easing: 'swing'
            });
            $('.link-holder a').click(function(){
                setTimeout (function (){
                    $('.link-holder').slideUp(500);
                }, 600 );
            });
        }

// Mixitup  ----------------------------------------

        $('#folio_container').mixitup({
            targetSelector: '.box',
            effects: ['fade','rotateX'],
            easing: 'snap',
            transitionSpeed:700,
            layoutMode: 'grid',
            targetDisplayGrid: 'inline-block',
            targetDisplayList: 'block'
        });

    }
    $(document).ready(function(){
    	initChulan();
    });
})(jQuery)