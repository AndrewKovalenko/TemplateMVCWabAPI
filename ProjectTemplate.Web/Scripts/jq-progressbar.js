(function ($) {

    var htmlTemplate = '<div class="jq-progressbar"><img alt="progress"/></div>';

    $.progressBar = function (method, imagePath) {
        if (!imagePath) {
            imagePath = "/Content/images/common/ajax-loader.gif";
        }
        if (methods[method]) {
            return methods[method](imagePath);
        } else if (typeof method === 'object' || !method) {
            return methods.init.call(this, imagePath);
        } else {
            $.error('There is no method with name' + method + ' in jQuery.popUp');
            return undefined;
        }
    };

    var methods = {
        init: function (imagePath) {
            var progressBarElement = $("body div.jq-progressbar");
            if (progressBarElement.length == 0) {
                $("body").append(htmlTemplate);
                progressBarElement = $("body div.jq-progressbar");
            }
            var imageTag = progressBarElement.find("img");
            imageTag.attr("src", imagePath);
            progressBarElement.show();
        },

        show: function (imagePath) {
            if (imagePath)
                this.init.call(this, imagePath);
            $("body div.jq-progressbar").show();
        },

        hide: function () {
            var progresBarTag = $("body div.jq-progressbar");
            if (progresBarTag) {
                progresBarTag.hide();
            }
        }
    };
}
)(jQuery)


