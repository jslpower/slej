var InitialPageInputTagValue = function() {
    this.Search = function(search) {
        if (search == undefined) {
            if ($('.searchbox').parents('form').length > 0) {
                search = $('.searchbox').parents('form').serialize();
            }
            else {
                search = $('form').serialize();
            }
        }
        else {
            if (search.nodeType === 1) {
                search = $(search).serialize();
            }
            else if (typeof search !== 'string') {
                search = $.param(search);
            }
        }
        if (search.replace(/\s/, '') !== '') {
            location.href = location.href.split('?')[0] + '?' + search;
        }
        else {
            location.replace(location.href);
        }
    };
    this.Init = function() {
        $(window).load(function() {
            setTimeout(function() {
                $('div[class*=search]').find('input[type!=submit][type!=button],select').filter('[name!=""]').val(function() {
                    var ms = location.href.match(this.name + '=([^&]+)&?');
                    return ms ? decodeURI(ms[1]) : (this.value || '');
                });
            }, 0);
        });
    };
};