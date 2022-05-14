window.paypalCheckoutReady = function () {
    function objectifyForm(formArray) {
        var returnArray = {};
        for (var i = 0; i < formArray.length; i++) {
            returnArray[formArray[i]['name']] = formArray[i]['value'];
        }
        return returnArray;
    }

    function renderButton(container, createPaymentUrl, payPalData, payPalEnv) {
        paypal.Button.render({
            env: payPalEnv,

            style: {
                size: 'small',
                color: 'blue',
                shape: 'rect',
                label: 'checkout'
            },

            payment: function (resolve, reject) {
                var $form = $('input[name="itemnumber"][value="'+payPalData.itemnumber+'"]').parent();
                var newPrice = $form.find('input[name="itemprice"]').val();
                payPalData.itemprice = newPrice;
                
                paypal.request.post(createPaymentUrl, payPalData)
                    .then(function (data) {
                        resolve(data.token);
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            },

            onAuthorize: function (data, actions) {
                return actions.redirect();
            },

            onCancel: function (data, actions) {
                return actions.redirect();
            }

        }, container);
    }

    function createButtonFromForm(form) {
        $form = $(form);
        var createPaymentUrl = $form.attr('action');
        var formData = objectifyForm(jQuery(form).serializeArray());
        var container = $form.find('.my-listing-paypal-button')[0];
        var payPalEnv = $form.data('paypal-env');

        renderButton(container, createPaymentUrl, formData, payPalEnv);
    }

    $ = jQuery;
    $('.my-listing-paypal-button').text('');
    $('.paypal-button-form').each(function () {
        createButtonFromForm(this);
    });
};