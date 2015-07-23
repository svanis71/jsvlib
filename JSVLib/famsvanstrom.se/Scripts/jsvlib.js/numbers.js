
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