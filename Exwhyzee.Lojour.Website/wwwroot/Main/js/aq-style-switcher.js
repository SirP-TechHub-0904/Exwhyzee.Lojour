/** 
 * Aqua Style Switcher
 *
 *
 * Author: Syamil MJ
 * Author URI: http://aquagraphite.com
 */

jQuery(document).ready(function($) {

	// setup the initial display on page load
	var menu_state = $.cookie('style_selector');

	if( typeof menu_state !== "undefined" && menu_state == "visible" ) {
		$('#style_selector_container').show();
		$('#style_selector .open').hide();
		$('#style_selector .close').show();
	} else {
		$('#style_selector_container').hide();
		$('#style_selector .open').show();
		$('#style_selector .close').hide();
		$.cookie('style_selector', 'hidden');
	}

	$('#style_selector .close').click(function(e) {
		e.preventDefault();
		
		$('#style_selector_container').hide();
		
		$(this).hide();
		$('#style_selector .open').show();
		$.cookie('style_selector', 'hidden');
		console.log( $.cookie('style_selector') );
	});

	$('#style_selector .open').click(function(e) {
		e.preventDefault();
		
		$('#style_selector_container').show();
		
		$(this).hide();
		$('#style_selector .close').show();
		$.cookie('style_selector', 'visible');
		console.log( $.cookie('style_selector') );
	});

});