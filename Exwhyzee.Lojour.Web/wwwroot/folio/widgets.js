(function($)
{
    
    jQuery(document).ready(function()
    {
        if ( $("#wo-googlemap").length > 0 )
        {
            /* --------------------------------------------------------------------------- */
            /*  1.Google Maps
            /* --------------------------------------------------------------------------- */

            var $latlng             = new  google.maps.LatLng(-25.363882,131.044922),
                $myOptions          = {
                    zoom            : 16,
                    center          : $latlng,
                    // panControl      : false,
                    // zoomControl     : true,
                    // scaleControl    : false,
                    // mapTypeControl  : false,
                    // mapTypeId       : google.maps.MapTypeId.ROADMAP
                },

                // $tabContact         = ('tab-contact');

            // $content.bind('easytabs:after', function(evt,tab,panel) {
                // if ( tab.hasClass($tabContact) ) {
            $map = new google.maps.Map(document.getElementById("wo-googlemap"), $myOptions);
            new google.maps.Marker({
                position: $latlng,
                map: $map, 
                title: "Hello World!"
            });
        }

        /*-------------------------------------------------*/
        /* 2.Skill Widget 
        /*------------------------------------------------*/
        if ($(".skillbar").length>0)
        {
            $('.skillbar').each(function()
            {
                $(this).find('.skillbar-bar').animate(
                {
                    width:$(this).attr('data-percent')
                },6000);
            });
        }  


        /*-------------------------------------------------*/
        /* 3.Tbas
        /*------------------------------------------------*/
        if ( $(".tabs-in-sidebar").length>0 )
        {
            $(".tabs-in-sidebar").tabs();
        }

         /*-------------------------------------------------*/
        /* 4. Subcribe 
        /*------------------------------------------------*/
        var _button = $(".submit-subcribe"), $email, _checkMail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/igm;
        $(document).on("click", ".submit-subcribe", function(event)
        {
            event.preventDefault();
            $email = $(".email-subcribe").val();
        
            if (  $email == '' || !_checkMail.test($email) )  
            {
                alert("Please enter a valid email address");
            }else{
                $.ajax(
                {
                    type: "POST",
                    url: WO_ADMIN_AJAX.url,
                    data: {"action": "parse_mailchimp",  email: $email},
                    success: function(res)
                    {
                        var _parseJSON = $.parseJSON(res);

                        if ( _parseJSON.error )
                        {
                            alert(_parseJSON.mes);
                        }else{
                            alert("Thank You! an email has been send to your email address, please check your email.");
                        }
                    }
                })
            }
        })

    })

    

})(jQuery)