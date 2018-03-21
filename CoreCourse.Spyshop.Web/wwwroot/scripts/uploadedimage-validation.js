$(function () {
    jQuery.validator.unobtrusive.adapters.add(
        'uploadedimage',
        ['extensions', 'extensionsmessage', 'maxlength', 'maxlengthmessage'],
        function (options) {
            var params = {
                extensions: options.params.extensions.split(','),
                maxlength: parseInt(options.params.maxlength),
                extensionsmessage: options.params.extensionsmessage,
                maxlengthmessage: options.params.maxlengthmessage,
            };
            options.rules['uploadedImageAllowedFiles'] = params;
            options.rules['uploadedImageMaxFileSize'] = params;
            options.messages['uploadedImageAllowedFiles'] = params.extensionsmessage;
            options.messages['uploadedImageMaxFileSize'] = params.maxlengthmessage;
        });

    jQuery.validator.addMethod('uploadedImageAllowedFiles',
        function (value, element, options) {
            if (element.files.length === 0) return true;
            var extension = getFileExtension(element.files[0].name);
            var validExtension = $.inArray(extension, options.extensions) !== -1;
            return validExtension;
        });

    jQuery.validator.addMethod('uploadedImageMaxFileSize',
        function (value, element, options) {
            if (element.files.length === 0) return true;
            var filesize = element.files[0].size;
            return filesize <= options.maxlength * 1024;
        });

    function getFileExtension(fileName) {
        var extension = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName) : undefined;
        if (extension !== undefined) {
            return (extension[0] + '').toLowerCase();
        }
        return extension.toLowerCase();
    };

    $.validator.unobtrusive.parse("form");
}(jQuery));
