/**
 * CT Custom Select
 *
 * @package WP Pro Real Estate 7
 * @subpackage JavaScript
 */

jQuery.noConflict();

(function($) {
	$(document).ready(function(){

		/*-----------------------------------------------------------------------------------*/
		/* Add Custom Select */
		/*-----------------------------------------------------------------------------------*/
		
		jQuery('select').niceSelect();
		jQuery('select').niceSelect('update');
		
	});
	
})(jQuery);