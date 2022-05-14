/**
 * Advanced Search
 *
 * @package WP Pro Real Estate 7
 * @subpackage JavaScript
 */

jQuery( document ).ready(function($) {

	if($('#advanced_search').length){
		$('#advanced_search #ct_country').on('change', function(){
			
			$('#ct_state').removeClass("disabled");
			$('#ct_state').prop('disabled', false).niceSelect('update');

			$('#state_code .nice-select .current').html(searchLabel.all_states);
			$('#city_code .nice-select .current').html(searchLabel.all_cities);
			$('#zip_code .nice-select .current').html(searchLabel.all_zip_post);
			var data = new Object();
			data.action = 'country_ajax';
			data.country = $(this).val();
			var element=$(this);
			$.ajax({
				type:"post",
				url:ajax_link,
				dataType: 'json',
				data:data,
				beforeSend: function() { showProgress(element); },
				error: function(e) { alert( "error" ); hideProgress(); },
				success: function(ret, textStatus, XMLHttpRequest) {
					if(ret.success == true)
					{
					
						$('#state_code ul.list').empty();
						$('#state_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_states + '</li>');
						

						$.each(ret.state, function (index, value) {

						let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();
						
						$('#state_code ul.list').append(li);
						});

						$('#city_code ul.list').empty();
						$('#city_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_cities + '</li>');
						$.each(ret.city, function (index, value) {
						let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();						
						$('#city_code ul.list').append(li);
						});

						$('#zip_code ul.list').empty();
						$('#zip_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_zip_post + '</li>');
						$.each(ret.zipcode, function (index, value) {
						let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();						
						$('#zip_code ul.list').append(li);
						});

						removeOtherValuesSelect('state','');
						removeOtherValuesSelect('city','');
						removeOtherValuesSelect('zipcode','');
						if(ret.state!='') addOtherValues('state',ret.state);
						if(ret.city!='') addOtherValues('city',ret.city);
						if(ret.zipcode!='') addOtherValues('zipcode',ret.zipcode);
						setSelectValue('city','0');
						setSelectValue('state','0');
						setSelectValue('zipcode','0');
					}
					hideProgress();
				}
			});
		});
					/*------------------State data----------------*/
					
						var state_data ;
						var state_option ;						
						$( document ).ready(function() {

						$("#state_code ul.list").addClass("databackup");
						state_data =  $('#state_code .databackup').html();
						$('.my_old_state').text(state_data);
						$("#state_code ul.list").removeClass("databackup");
						
						
						$("#ct_state").addClass("databackup");
						state_option =  $('#ct_state.databackup').html();
						$('.state_option').html(state_option);
						$("#ct_state").removeClass("databackup");
						});
					/*------------------End---------------------*/		
					/*------------------City data----------------*/
						var city_data ;	
						$( document ).ready(function() {
						//alert('test');
						$("#city_code ul.list").addClass("databackup");
						city_data =  $('#city_code .databackup').html();
						$('.my_old_city').text(city_data);
						
						});
					/*------------------End---------------------*/			
		$('#advanced_search #ct_state').on('change', function(){
			
			$('#ct_city').removeClass("disabled");
			$('#ct_city').prop('disabled', false).niceSelect('update');
	

			$('#city_code .nice-select .current').html(searchLabel.all_cities);
			$('#zip_code .nice-select .current').html(searchLabel.all_zip_post);
			var data = new Object();

			$("#city_code ul.list").removeClass("databackup");
			data.action = 'state_ajax';
			data.country = $('#advanced_search #ct_country').val();
			data.state = $(this).val();
			data.firstsearch = firstSearch('state');
			var element=$(this);
			$.ajax({
				type:"post",
				url:ajax_link,
				dataType: 'json',
				data:data,
				beforeSend: function() { showProgress(element); },
				error: function(e) { alert( "error" ); hideProgress(); },
				success: function(ret, textStatus, XMLHttpRequest) {
					if(ret.success == true)
					{
						
						if(data.firstsearch==true){
							setSelectValue('',first_el(ret.country));
							//removeOtherValuesSelect('state',data.state);
							removeOtherValuesSelect('city','');
							removeOtherValuesSelect('zipcode','');
							if(ret.city!='') addOtherValues('city',ret.city);
							if(ret.zipcode!='') addOtherValues('zipcode',ret.zipcode);
							setSelectValue('city',first_el(ret.city));
							setSelectValue('zipcode',first_el(ret.zipcode));

						}
						else{
							console.log(ret.city);
							removeOtherValues('city');
							removeOtherValues('zipcode');
							if(ret.city!='') addOtherValues('city',ret.city);
							if(ret.zipcode!='') addOtherValues('zipcode',ret.zipcode);
				
						}
				/*--------------- Custom Code Start ----------------*/
								
						$('#city_code ul.list').empty();
						$('#city_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_cities + '</li>');
						$.each(ret.city, function (index, value) {
						let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();
						$('#city_code ul.list').append(li);
						});

						$('#zip_code ul.list').empty();
						$('#zip_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_zip_post + '</li>');
						$.each(ret.zipcode, function (index, value) {
						let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();
						$('#zip_code ul.list').append(li);
						});
						
				/*------------- Custom Code End -----------------*/	
					}
					hideProgress();
				}
			});
		});
				/*------------------Zip data----------------*/
					var zip_data ;	
							$( document ).ready(function() {
					   //alert('test');
					   $("#zip_code ul.list").addClass("databackup");
							 zip_data =  $('#zip_code .databackup').html();
							$('.my_old_data').text(zip_data);
							
							console.log(zip_data);
					});
				/*------------------End---------------------*/	
			
		
		$('#advanced_search #ct_city').on('change', function(){
			
	
			$('#ct_zipcode').removeClass("disabled");
			$('#ct_zipcode').prop('disabled', false).niceSelect('update');
			$('#ct_zip_code').removeClass("disabled");
			$('#ct_zip_code').prop('disabled', false).niceSelect('update');
	

			$('#zip_code .nice-select .current').html(searchLabel.all_zip_post);
			var data = new Object();
			$("#zip_code ul.list").removeClass("databackup");
			data.action = 'city_ajax';
			data.country = $('#advanced_search #ct_country').val();
			data.state = $('#advanced_search #ct_state').val();
			data.city = $(this).val();
			data.firstsearch = firstSearch('city');
			var element=$(this);
			
			$.ajax({
				type:"post",
				url:ajax_link,
				dataType: 'json',
				data:data,
				beforeSend: function() { showProgress(element); },
				error: function(e) { alert( "error" ); hideProgress(); },
				success: function(ret, textStatus, XMLHttpRequest) {
			
			        if(ret.success == true)
					{
							removeOtherValues('zipcode');
							if(ret.zipcode!='') addOtherValues('zipcode',ret.zipcode);	
	               /*--------------- Custom Code Start ----------------*/							
							//console.log(ret.zipcode);
							$('#zip_code ul.list').empty();
							$('#zip_code ul.list').append('<li data-value="0" class="option selected">' + searchLabel.all_zip_post + '</li>');
							$.each(ret.zipcode, function (index, value) {
							let li=$('<ul class="list"><li data-value="'+index+'" class="option" >'+value+'</li></ul>').html();
							$('#zip_code ul.list').append(li);
							});
							 
					/*------------- Custom Code End -----------------*/					
						
					}
					hideProgress();
			    }
			});
		});
		
		$('#advanced_search #ct_zipcode').on('change', function(){
			var search_f=firstSearch('zipcode');
			if(search_f==true){
				var data = new Object();
				data.action = 'zipcode_ajax';
				data.zipcode = $(this).val();
				data.firstsearch = search_f;
				var element=$(this);
				$.ajax({
					type:"post",
					url:ajax_link,
					dataType: 'json',
					data:data,
					beforeSend: function() { showProgress(element); },
					error: function(e) { alert( "error" ); hideProgress(); },
					success: function(ret, textStatus, XMLHttpRequest) {
				        if(ret.success == true)
						{
							setSelectValue('',first_el(ret.country));
							removeOtherValuesSelect('state','');
							removeOtherValuesSelect('city','');
							removeOtherValuesSelect('zipcode',data.zipcode);
							if(ret.state!='') addOtherValues('state',ret.state);
							if(ret.city!='') addOtherValues('city',ret.city);
							setSelectValue('state',first_el(ret.state));
							setSelectValue('city',first_el(ret.city));
						}
						hideProgress();
				    }
				});
			}
		});
	}
});

function first_el(obj) { for (var a in obj) return a; }
function removeOtherValues(select_id){
	$=jQuery;
	$('#ct_'+select_id).find('option').each(function(){
		if($(this).attr('value')!=0) $(this).remove();
	});
	$('#ct_'+select_id).val(0);
	$('#ct_'+select_id).next().find('.customSelectInner').html( $('#ct_'+select_id+' option').first().html() );
}
function removeAllValues(except){
	//if(except!="country") removeOtherValues('country');
	if(except!="state") removeOtherValues('state');
	//if(except!="city") removeOtherValues('city');
	//if(except!="zipcode") removeOtherValues('zipcode');
}
function removeOtherValuesSelect(element,value){
	$('#ct_'+element).find('option').each(function(){
		if(value!=""){ if($(this).attr('value')!=value && $(this).attr('value')!='0') $(this).remove(); }
		else{ if($(this).attr('value')!='0') $(this).remove(); }
	});
}
function addOtherValues(select_id,values){
	$=jQuery;
	for (var key in values) {
		$('#ct_'+select_id).append($('<option>', {
		    value: key,
		    text: values[key]
		}));
	}
}
function showProgress(element){
	$=jQuery;
	var position = $(element).position();
	$('.makeloading').css('left', (position.left+$(element).outerWidth(true)-50)+'px').css('top', (position.top+4)+'px').addClass('loadme muted');
}
function hideProgress(){ $=jQuery; $('.makeloading').removeClass('loadme'); }
function firstSearch(except){
	$=jQuery;
	var return_val=true;
	if(except!="country"){ if($("#ct_country").val()!="0"){ return_val=false;}}
	if(except!="state"){ if($("#ct_state").val()!="0"){ return_val=false;}}
	if(except!="city"){ if($("#ct_city").val()!="0"){ return_val=false;}}
	if(except!="zipcode"){ if($("#ct_zipcode").val()!="0"){ return_val=false;}}
	return return_val;
}
function setSelectValue(element,value){
	if(element=="") element='country';
	$("#ct_"+element).val(value);
	var html_text=$('#ct_'+element+' option:selected').text();
	$('#ct_'+element).next().find('.customSelectInner').html(html_text);
}