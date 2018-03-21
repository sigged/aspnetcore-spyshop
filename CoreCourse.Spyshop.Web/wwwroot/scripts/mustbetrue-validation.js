$(function () {
    jQuery.validator.unobtrusive.adapters.add(
        'mustbetrue',
        [],
        function (options) {
            options.rules['mustbetruecheck'] = {};
            options.messages['mustbetruecheck'] = options.message;
        });

    jQuery.validator.addMethod('mustbetruecheck',
        function (value, element, options) {
            return value === "true";
        });
    
    $.validator.unobtrusive.parse("form");
}(jQuery));
