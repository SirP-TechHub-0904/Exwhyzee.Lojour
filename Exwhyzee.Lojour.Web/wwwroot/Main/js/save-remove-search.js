jQuery(document).ready(function ($) {
    "use strict";
	var userID = UserInfo.userID;
	var ajaxurl = UserInfo.ajaxurl;
	var process_loader_spinner = UserInfo.process_loader_spinner;
	var confirm_message = UserInfo.confirm;
	
		/*--------------------------------------------------------------------------
         *  Save esetting on Saved Alerts
         * -------------------------------------------------------------------------*/
		 $('.esetting').each(function (i){ 
			var $this = $(this);
			 $this.change(function (e) {
				e.preventDefault();
				var id = $(this).data('propid');
				var esetting = $(this).val();
				if( parseInt( userID, 10 ) === 0 ) {
					$('#overlay').addClass('open');
				} else {
					$.ajax({ 
						url:ajaxurl,
						data: { 
							'action': 'ct_email_cron_onoff',
							'esetting': esetting,
							'id': id,
							'author_id': userID,
						},
						method: 'POST',
						dataType: 'JSON',
						beforeSend: function () {
							$this.next('span.customSelect').css('border','1px solid greenyellow');
							
						},
						success: function (response) {
							if (response.success) {
								console.log(response);
							}
						},
						error: function (xhr, status, error) {
							var err = eval("(" + xhr.responseText + ")");
							console.log(err.Message);
						},
						complete: function () {
							$this.next('span.customSelect').css('border','1px solid #d5d9dd');
							$this.addClass('set');
						}
					});
				}
			 
			 });
		 });
		/*--------------------------------------------------------------------------
         *  Save Search on Searched Listings
         * -------------------------------------------------------------------------*/
        $("#searched-save-search").click(function(e) {
            e.preventDefault();
            var $this = $(this);
            var $form = $('.form-searched-save-search');
			var serialized = $form.serialize();

            if( parseInt( userID, 10 ) === 0 ) {
                $('#overlay').addClass('open');
            } else {
                $.ajax({
                    url: ajaxurl,
                    data: serialized,
                    method: 'POST',
                    dataType: 'JSON',

                    beforeSend: function () {
                        $this.children('i').remove();
                        $this.prepend('<i class="fa-left ' + process_loader_spinner + '"></i>');
                    },
                    success: function (response) {
                        if (response.success) {
                            $('#searched-save-search').addClass('saved');
							$('#searched-save-search').html('Search Saved');
                        }
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                    },
                    complete: function () {
                        $this.children('i').removeClass(process_loader_spinner);
                    }
                });
           }

        });
		/*--------------------------------------------------------------------------
         *  Save Alert Creation Search - Email Alerts
         * -------------------------------------------------------------------------*/
        $("#ct-alert-creation").click(function(e) {
            e.preventDefault();
            var $this = $(this);
            var $form = $('.ctea-alert-creation-form');
			var serialized = $form.serialize();

            if( parseInt( userID, 10 ) === 0 ) {
                $('#overlay').addClass('open');
            } else {
                $.ajax({
                    url: ajaxurl,
                    data: serialized,
                    method: 'POST',
                    dataType: 'JSON',

                    beforeSend: function () {
                        $this.children('i').remove();
                        $this.prepend('<i class="fa-left ' + process_loader_spinner + '"></i>');
                    },
                    success: function (response) {
                        if (response.success) {
                            $('#ct-alert-creation').addClass('saved');
							//console.log(response);
							location.reload();
                        }
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                    },
                    complete: function () {
                        $this.children('i').removeClass(process_loader_spinner);
                    }
                });
           }

        });
        /*--------------------------------------------------------------------------
        * Delete Search
        * --------------------------------------------------------------------------*/
        $('.remove-search').click(function(e) {
            e.preventDefault();
            var $this = $(this);
            var prop_id = $this.data('propertyid');
            var removeBlock = $this.closest('.saved-search-block');

            if (confirm(confirm_message)) {
                $.ajax({
                    url: ajaxurl,
                    dataType: 'JSON',
                    method: 'POST',
                    data: {
                        'action': 'ct_delete_search',
                        'property_id': prop_id
                    },
                    beforeSend: function () {
                        $this.children('i').remove();
                        $this.prepend('<i class="' + process_loader_spinner + '"></i>');
                    },
                    success: function (res) {
                        if (res.success) {
                            removeBlock.remove();
                        }
                    },
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        console.log(err.Message);
                    }
                });
            }
        });
}); // end document ready