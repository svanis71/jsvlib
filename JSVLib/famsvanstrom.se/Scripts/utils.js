String.prototype.padLeft = function (c, n) {
    var s = this;
    var len = s.length;
    var zeros = "";
    for (var i = 0; i < (n - len) ; i++)
        zeros += c;
    return zeros + s;
};

String.prototype.reverse = function () {
    var rs = "";
    for (var i = this.length - 1; i >= 0; i--) {
        rs += this[i];
    }
    return rs;
};

String.prototype.contains = function (c) {
    var found = false;
    var middle = this.length / 2;
    var end = this.length - 1;
    for (var i = 0; i < middle && !found; i++) {
        found = this.charAt(i) == c || this.charAt(end - i) == c;
    }
    return found;
};

Number.prototype.isPrime = function () {
    /*
    def isPrime(n)
        return false if n < 2
        2.upto(Math.sqrt(n)) { |i| return false if n % i == 0 }
        return true
    end
    */
    if (this < 2)
        return false;
    for (var i = 2; i <= Math.sqrt(this) ; i++) {
        if (this % i == 0) return false;
    }
    return true;

}