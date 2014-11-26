var MenuType = function () {
    return {
        DropDown: 0,
        Tab: 1
    };
}();

(function ($) {
    $.fn.jsvMenu = function (settings) {
        var defaultSettings = {
            items: [{ label: "Start", link: "#", subitems: null }],
            type: MenuType.DropDown,
            dropOnHover: true
        };
        var menu = defaultSettings.items;
        var type = defaultSettings.type;
        var dropOnHover = defaultSettings.dropOnHover;
        
        if (settings.type) {
            type = settings.type;
        }
        console.log("type = " + type);
        if (settings.items) {
            menu = settings.items;
        }
        if (settings.dropOnHover) {
            dropOnHover = settings.dropOnHover;
        }
        
        console.log(settings.items);
        console.log(menu);
        var curl = window.location.pathname;
        var idx = 1;
        return this.each(function () {
            var me = $(this);
            console.log(me);
            var dropdownPh = $('<section class="jsv-dropdown-ph"></section>');
            var topDd = $('<dd class="jsv-menu"></dd>');
            $.each(menu, function () {
                var dl = $('<dl class="jsv-topmenuitem"></dl>');
                var label = $('<section class="jsv-topmenulabel"></section>');
                var dropdown = $('<section class="jsv-dropdown"></section>');
                var dropdownDd = $('<dd class="jsv-dropdown-items"></dd>');
                console.log("Skapar menu item för " + this.label);
                console.log(this);
                dl.attr("data-index", idx);
                var link = $('<a class="jsv-menu-link"></a>');
                link.text(this.label);
                link.attr("href", this.link);
                link.appendTo(label);
                //if (this.link == curl) {
                // Sub items are floating i.e dropdown must clearfix
                dropdown.addClass("clearfix");
                dropdownDd.addClass("clearfix")
                if (this.current == true) {
                    dl.addClass("current");
                    dropdown.addClass("current");
                }
                
                if (this.subitems != undefined && this.subitems != null) {
                    console.log("Finns " + this.subitems.length +  " sub items!")
                    $.each(this.subitems, function () {
                        console.log("Sub item with label: " + this.label)
                        var itm = $('<dl class="jsv-dropdown-item"></dl>');
                        var slink = $('<a class="jsv-menu-link"></a>');
                        slink.text(this.label);
                        slink.attr("href", this.link);
                        slink.appendTo(itm);
                        console.log(itm);
                        itm.appendTo(dropdownDd);
                        console.log("dropdownDd ------>");
                        console.log(dropdownDd);
                    });
                    dropdownDd.appendTo(dropdown);
                }
                label.appendTo(dl);
                dropdown.attr("data-index", idx.toString());
                if (type == MenuType.Tab) {
                    dropdown.appendTo(dropdownPh);
                } else {
                    dropdown.appendTo(dl);
                }
                
                console.log("mouseevents data-index:" + idx);
                console.log($(".jsv-topmenuitem[data-index='" + idx + "']"));
                //dl.on("mouseover", function () {
                //    var myIdx = $(this).data("index");
                //    $(".jsv-dropdown[data-index='" + myIdx + "']").show();
                //})
                //.on("mouseleave", function () {
                //    var myIdx = $(this).data("index");
                //    if ((!$(this).hasClass("current") && type == MenuType.Tab) || type == MenuType.DropDown) {
                //        $(".jsv-dropdown[data-index='" + myIdx + "']").hide();
                //    }
                //});
                dl.appendTo(topDd);
               idx++;
            });
            topDd.appendTo(me);
            dropdownPh.appendTo(me);

        });
    };
})(jQuery);
