$(function () {
    jQuery.validator.unobtrusive.adapters.add(
        'mustbetrue',
        [],
        function (options) {
            options.rules['required'] = true;
            if (options.messages)
                options.messages['required'] = options.message;
        });

}(jQuery));
