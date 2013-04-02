(function ($) {
    $.fn.serializeObject = function () {
        if (!this.length) { return false; }

        var $el = this,
      data = {},
      lookup = data; //current reference of data

        $el.find(':input[type!="radio"], input:checked').each(function () {
            // data[a][b] becomes [ data, a, b ]
            var named = this.name.replace(/\[([^\]]+)?\]/g, ',$1').split(','),
            cap = named.length - 1,
            i = 0;

            // Ensure that only elements with valid `name` properties will be serialized
            if (named[0]) {
                for (; i < cap; i++) {
                    // move down the tree - create objects or array if necessary
                    lookup = lookup[named[i]] = lookup[named[i]] ||
                  (named[i + 1] == "" ? [] : {});
                }

                // at the end, psuh or assign the value

                if (!$(this).is('[type="checkbox"]')) {
                    if (lookup[named[cap]] == undefined) {

                        if (lookup.length != undefined) {
                            lookup.push($(this).val());
                        } else {
                            lookup[named[cap]] = $(this).val();
                        }
                    }
                } else {
                    if (lookup.length != undefined) {
                        lookup.push($(this).is(':checked'));
                    } else {
                        lookup[named[cap]] = $(this).is(':checked');
                    }
                }


                // assign the reference back to root
                lookup = data;

            }
        });

        return data;
    };

    function fixIePost(url, data, callback, completeCallback, type) {
        if (jQuery.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }

        return jQuery.ajax({
            cache: false,
            type: 'POST',
            url: url,
            data: data,
            success: callback,
            dataType: type,
            complete: completeCallback
        });
    }

    function fixIeGet(url, data, callback, completeCallback, type) {
        if (jQuery.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }

        return jQuery.ajax({
            cache: false,
            type: 'GET',
            url: url,
            data: data,
            success: callback,
            dataType: type,
            complete: completeCallback
        });
    };

    jQuery.post = fixIePost;
    jQuery.get = fixIeGet;
})(jQuery);