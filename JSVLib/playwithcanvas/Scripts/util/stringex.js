String.prototype.rotate = function () {
    var s1 = this.charAt(0);
    var s2 = this.substring(1);
    return s2 + s1;
};