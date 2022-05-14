(function($){

// Contact submit  ----------------------------------------

	$("#submit_btn").click(function(){		
		var user_name=$('input[name=name]').val();
		var user_email=$('input[name=email]').val();
		var user_message=$('textarea[name=message]').val();
		var proceed=true;
			if(user_name==""){
				$('input[name=name]').css('border','2px solid #F54A4B');
				proceed=false
			}
			if(user_email==""){
				$('input[name=email]').css('border','2px solid #F54A4B');
				proceed=false
			}
			if(user_message==""){
				$('textarea[name=message]').css('border','2px solid #F54A4B');
				proceed=false
			}
			if(proceed){
				post_data={'userName':user_name,'userEmail':user_email,'userMessage':user_message};
				$.post('php/contact_me.php',
				post_data,
				function(data){
					$("#result").hide().html('<div class="success">'+data+'</div>').fadeIn(700);
					$('#contact_form input').val('');
					$('#contact_form textarea').val('')}).fail(
					function(err){
						$("#result").hide().html('<div class="error">'+err.statusText+'</div>').fadeIn(1500)
				});
			}
	});
	
	$("#contact_form input, #contact_form textarea").keyup(function(){		
			$("#contact_form input, #contact_form textarea").css('border','2px solid #fff');
			$("#result").fadeOut(700)			
	});

    $(document).ready(function(){
        // OwlCarousel  ----------------------------------------

        $("#services-carusel").owlCarousel({
            navigation:true,
            slideSpeed : 500,
            pagination : false,
            items : 3,
            itemsDesktop : false,
            itemsDesktopSmall : [1200,2],
            itemsTablet: [979,2],
            itemsMobile : [740,1]
        });


        $('#testimonials-slider').owlCarousel({
            navigation : true,
            pagination:true,
            slideSpeed : 300,
            paginationSpeed : 400,
            singleItem:true,
            transitionStyle : "goDown",
            autoHeight : true
        });

        $(".single-slider").owlCarousel({
            navigation : false,
            pagination:true,
            slideSpeed : 300,
            paginationSpeed : 400,
            singleItem:true,
            transitionStyle : "backSlide",
            autoHeight : true
        });

        $(".single-media").owlCarousel({
            navigation : false,
            slideSpeed : 500,
            pagination : true,
            singleItem:true,
            autoplay:true,
            autoHeight : true
        });
    })

// google map styles and functions  --------

   function initialize() {
       var styles = [
        {
            featureType: 'water',
            elementType: 'all',
            stylers: [
                { hue: '#cdcdcd' },
                { saturation: -100 },
                { lightness: 18 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'landscape',
            elementType: 'all',
            stylers: [
                { hue: '#e8e8e8' },
                { saturation: -100 },
                { lightness: 18 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'road',
            elementType: 'all',
            stylers: [
                { hue: '#fdfdfd' },
                { saturation: -100 },
                { lightness: -1 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'road.local',
            elementType: 'all',
            stylers: [
                { hue: '#fdfdfd' },
                { saturation: -100 },
                { lightness: -1 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'poi.park',
            elementType: 'all',
            stylers: [
                { hue: '#c0c0c0' },
                { saturation: -100 },
                { lightness: -3 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'poi',
            elementType: 'all',
            stylers: [
                { hue: '#c0c0c0' },
                { saturation: -100 },
                { lightness: -3 },
                { visibility: 'on' }
            ]
        },{
            featureType: 'transit',
            elementType: 'all',
            stylers: [
                { hue: '#ffffff' },
                { saturation: -100 },
                { lightness: -9 },
                { visibility: 'on' }
            ]
        }

          ];


        if($(".awe-map").length){
            if(document.getElementById("map_canvas")!=null){
                var options = $(".awe-map").attr("data-options"), map_latitude='40.761467',map_longitude='-73.956379',map_marker='';
                if(options)
                {
                    options = JSON.parse(options);
                    map_latitude = options.latitude;
                    map_longitude = options.longitude;
                    map_marker = options.marker;

                }

                var Chulan = new google.maps.LatLng(map_latitude,map_longitude);
                var mapOptions = {
                    zoom:17,
                    zoomControl: true,
                    scaleControl: false,
                    scrollwheel: false,
                    disableDefaultUI:true,
                    center: Chulan,
                    mapTypeControlOptions: {
                        mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'bestfromgoogle']
                    }
                };
                map = new google.maps.Map(document.getElementById("map_canvas"),
                    mapOptions);
                var styledMapOptions = {
                    name: "Chulan"
                }
                var jayzMapType = new google.maps.StyledMapType(
                    styles, styledMapOptions);
                map.mapTypes.set('bestfromgoogle', jayzMapType);
                map.setMapTypeId('bestfromgoogle');
                var companyImage = new google.maps.MarkerImage(map_marker,
                    new google.maps.Size(64,64),
                    new google.maps.Point(0,0),
                    new google.maps.Point(64,64)
                );

                // your marker coordinates   --------

                var companyPos = new google.maps.LatLng(map_latitude,map_longitude);
                var companyMarker = new google.maps.Marker({
                    position: companyPos,
                    map: map,
                    icon: companyImage,
                    zIndex: 3
                });
            }
        }

    }
    initialize();
})(jQuery);
//  definition of mobile browser------------------

	var isMobile = { 
       Android: function() {
            return navigator.userAgent.match(/Android/i);
        },
        BlackBerry: function() {
            return navigator.userAgent.match(/BlackBerry/i);
        },
        iOS: function() {
            return navigator.userAgent.match(/iPhone|iPad|iPod/i);
        },
        Opera: function() {
            return navigator.userAgent.match(/Opera Mini/i);
        },
        Windows: function() {
            return navigator.userAgent.match(/IEMobile/i);
        },
        any: function() {
            return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
        }
		
    };
	
// if not mobile ------------------  
(function($){
	trueMobile = isMobile.any();
	
	if (trueMobile == null){
        if($('.js-parallax').length>0){
            $('.js-parallax').css('background-attachment', "fixed").parallax("70%", 0.3);
        };
  //       if($('.parallax-facts').length){
  //           $('.parallax-facts').parallax("70%", 0.3);    
  //       }
		// if($('.parallax-testimonials').length > 0){
  //           $('.parallax-testimonials').parallax("70%", 0.3);    
  //       }
		$('.box').hover(function(){
			$(this).find('div.folio-overlay').stop(true,true).animate({opacity:'0.9',left:'10px' , top:'10px'},{queue:true,duration:500,easing:"swing"});
			$(this).find('div.folio-button').addClass('scale-big');	
				},function(){
			$(this).find('div.folio-overlay').stop(true,true).animate({opacity:'0',left:'0' , top:'0'},{queue:true,duration:500,easing:"easeInOutBack"});
			$(this).find('div.folio-button').removeClass('scale-big');
		});	

		$('.start-holder').hover(function(){
			$('.start-decor').addClass('start-rotade');	
				},function(){
			$('.start-decor').removeClass('start-rotade');	
		});	
	}
    $('.open-popup-gallery').on("click",function() {
        var items = [];
        $(this).find("div.input-gallery img").each(function(){
            items.push( {
                src: $(this).attr("src")
            } );
        });
        $.magnificPopup.open({
            items:items,
            type: 'image',
            gallery: {
                enabled: true
            }
        });
        return false;
    });
})(jQuery);