document.addEventListener("DOMContentLoaded", function (event) {
    var expanders = document.querySelectorAll(".expander");
    for (var i = 0; i < expanders.length; i++) {
        expanders[i].addEventListener("click", function (e) {
            var nextElem = this.nextElementSibling;
            for (; nextElem != null && !nextElem.classList.contains("collapsable") ; nextElem = this.nextElementSibling);
            if (nextElem != null && nextElem.classList.contains("collapsable")) {
                if (nextElem.classList.contains("hidden")) {
                    nextElem.classList.remove("hidden");
                } else {
                    nextElem.classList.add("hidden");
                }
            }
        });
    }
});