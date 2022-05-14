/**
 * Created by duongle on 5/27/14.
 */
(function($){
    function initChulan() {

// functions ------------------
        "use strict";

// counter ------------------
        // JpreLoader ------------------
        $('#main').jpreLoader({
            loaderVPos: '50%',
            autoClose: true
        }, 
        function() {
            $('#main').animate({"opacity":'1'},{queue:false,duration:700,easing:"easeInOutQuad"});
            if($('h1.animtext').length > 0)
                $('h1.animtext').textillate({ in: { effect: 'flipInX',delayScale: 2.5  } });
            if($('.fade').length > 0){
                setTimeout( function(){
                    $('.fade').animate({"opacity":'1'},{queue:false,duration:1200,easing:"easeInOutQuad"});
                },100);
            }

        });
        if($('h1.animtext').length > 0){
            $('h1.animtext').fitText(1.8,{minFontSize:'20px',maxFontSize:'72px'});
        }
        $('.nav-button').on('click',function(){
            $('.link-holder').slideToggle(500);
        });
        // if(is_homepage=='true' || is_homepage==true){
        //     $("a.nav-top,a.to-top").bind('click', function(event) {
        //         event.preventDefault();
        //         var href = $(this).attr('href');
        //         if(href.indexOf("/#")!=-1){
        //             href = href.split("/#");
        //             if(href[1]!='' && href[1]!=undefined) href = "#"+href[1];
        //         }else href = $(this).attr('href');
        //         $.scrollTo(
        //             href,550,{easing:'swing',offset: 0,'axis':'y'} );
        //         setTimeout( function(){
        //         },500);
        //     });
        // }
        $("a.scroll-link-blog").bind('click', function(event) {
            event.preventDefault();
            var href = $(this).attr('href');
            if(href.indexOf("/#")!=-1){
                href = href.split("/#");
                if(href[1]!='' && href[1]!=undefined) href = "#"+href[1];
            }else href = $(this).attr('href');
            $.scrollTo(
                href,550,{easing:'swing',offset: 0,'axis':'y'} );
            setTimeout( function(){
            },500);
        });

    };

    $(document).ready(function(){
        initChulan();
        var scroll = new SmoothScroll('a[href*="#"]');
    });
})(jQuery);