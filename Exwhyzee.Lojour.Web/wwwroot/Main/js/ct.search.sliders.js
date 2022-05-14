function numberWithCommas(x) {
    if (x !== null) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
}

jQuery(function($) {
	
	var $currency = "<?php ct_currency(); ?>";
	var $sqftsm = "<?php ct_sqftsqm(); ?>";
	var $acres = "<?php ct_acres(); ?>";

    //Price From / To
    $( "#slider-range" ).slider({
        range: true,
        min: 100000,
        step: 10000,
        max: 5000000,
        values: [ 100000, 5000000 ],
        slide: function( event, ui ) {
            $( "#slider-range #min" ).html(numberWithCommas(ui.values[ 0 ]) );
            $( "#slider-range #max" ).html(numberWithCommas(ui.values[ 1 ]) );
            $( "#price-from-to-slider .min-range" ).html( $currency + numberWithCommas($( "#slider-range" ).slider( "values", 0 )) );
            $( "#price-from-to-slider .max-range" ).html( $currency + numberWithCommas($( "#slider-range" ).slider( "values", 1 )) );
            $( "#ct_price_from" ).val(ui.values[ 0 ]);
            $( "#ct_price_to" ).val(ui.values[ 1 ]);
        }
    });
  
    //slider range data tooltip set
    var $handler = $("#slider-range .ui-slider-handle");

    $( "#price-from-to-slider .min-range" ).prepend( $currency );
    $( "#price-from-to-slider .max-range" ).prepend( $currency );
  
    $handler.eq(0).append("<b class='amount'>" +$currency+ "<span id='min'>"+numberWithCommas($( "#slider-range" ).slider( "values", 0 )) +"</span></b>");
    $handler.eq(1).append("<b class='amount'>" +$currency+ "<span id='max'>"+numberWithCommas($( "#slider-range" ).slider( "values", 1 )) +"</span></b>");

    //slider range pointer mousedown event
    $handler.on("mousedown",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeIn(300);
    });

    //slider range pointer mouseup event
    $handler.on("mouseup",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeOut(300);
    });

    //Size From / To
    $( "#slider-range-two" ).slider({
        range: true,
        min: 100,
        step: 100,
        max: 10000,
        values: [ 100, 10000 ],
        slide: function( event, ui ) {
            $( "#slider-range-two #min" ).html(numberWithCommas(ui.values[ 0 ]) );
            $( "#slider-range-two #max" ).html(numberWithCommas(ui.values[ 1 ]) );
            $( "#size-from-to-slider .min-range" ).html( numberWithCommas($( "#slider-range-two" ).slider( "values", 0 )) + $sqftsm);
            $( "#size-from-to-slider .max-range" ).html( numberWithCommas($( "#slider-range-two" ).slider( "values", 1 )) + $sqftsm);
            $( "#ct_sqft_from" ).val(ui.values[ 0 ]);
            $( "#ct_sqft_to" ).val(ui.values[ 1 ]);
        }
    });
  
    //slider range data tooltip set
    var $handlertwo = $("#slider-range-two .ui-slider-handle");

    $( "#size-from-to-slider .min-range" ).append( $sqftsm );
    $( "#size-from-to-slider .max-range" ).append( $sqftsm );
  
    $handlertwo.eq(0).append("<b class='amount'><span id='min'>"+numberWithCommas($( "#slider-range-two" ).slider( "values", 0 )) +"</span>" +$sqftsm+ "</b>");
    $handlertwo.eq(1).append("<b class='amount'><span id='max'>"+numberWithCommas($( "#slider-range-two" ).slider( "values", 1 )) +"</span>" +$sqftsm+ "</b>");

    //slider range pointer mousedown event
    $handlertwo.on("mousedown",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeIn(300);
    });

    //slider range pointer mouseup event
    $handlertwo.on("mouseup",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeOut(300);
    });

    //Lotsize From / To
    $( "#slider-range-three" ).slider({
        range: true,
        min: 0,
        step: 1,
        max: 100,
        values: [ 0, 100 ],
        slide: function( event, ui ) {
            $( "#slider-range-three #min" ).html(numberWithCommas(ui.values[ 0 ]) );
            $( "#slider-range-three #max" ).html(numberWithCommas(ui.values[ 1 ]) );
            $( "#lotsize-from-to-slider .min-range" ).html( numberWithCommas($( "#slider-range-three" ).slider( "values", 0 )) + " " +$acres);
            $( "#lotsize-from-to-slider .max-range" ).html( numberWithCommas($( "#slider-range-three" ).slider( "values", 1 )) + " " +$acres);
            $( "#ct_lotsize_from" ).val(ui.values[ 0 ]);
            $( "#ct_lotsize_to" ).val(ui.values[ 1 ]);
        }
    });
  
    //slider range data tooltip set
    var $handlerthree = $("#slider-range-three .ui-slider-handle");

    $( "#lotsize-from-to-slider .min-range" ).append( " " + $acres );
    $( "#lotsize-from-to-slider .max-range" ).append( " " + $acres );

    $( "#lotsize-from-to-slider .min-range" ).replaceWith( "<span class='min-range'>" + numberWithCommas($( "#slider-range-three" ).slider( "values", 0 )) + " " + $acres + "</span>" );
  
    $handlerthree.eq(0).append("<b class='amount'><span id='min'>"+numberWithCommas($( "#slider-range-three" ).slider( "values", 0 )) +"</span> " +$acres+ "</b>");
    $handlerthree.eq(1).append("<b class='amount'><span id='max'>"+numberWithCommas($( "#slider-range-three" ).slider( "values", 1 )) +"</span> " +$acres+ "</b>");

    //slider range pointer mousedown event
    $handlerthree.on("mousedown",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeIn(300);
    });

    //slider range pointer mouseup event
    $handlerthree.on("mouseup",function(e){
        e.preventDefault();
        $(this).children(".amount").fadeOut(300);
    });

});