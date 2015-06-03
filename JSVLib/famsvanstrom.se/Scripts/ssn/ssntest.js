/// <reference path="../angular.js" />
var ssnGen = {};

ssnGen.getModulo10 = function (ssnToTest) {
    var ssn = ssnToTest.replace(/-/, "");
    if (ssn.match(/\d{4}(1[0-2]|0[0-9])([0-2][0-9]|3[0-1])\d{3,4}/) == null)
        return -99;

    var multiplier = 2;
    var checkSum = 0;

    ssn = ssn.toString().substr(2, 9);
    for (var i = 0; i < 9; i++) {
        var tmp = parseInt(ssn.charAt(i)) * multiplier;
        if (tmp > 9)
            tmp -= 9;
        checkSum += tmp;
        multiplier = 3 - multiplier;
    }
    return 10 - (checkSum % 10);
};

var ssnApp = angular.module('ssnChecksumApp', []);
ssnApp.controller('PnrController', function ($scope) {
    $scope.pnr = "";
    $scope.pnrClass = "";
    $scope.checksum = "?";
    $scope.$watch('pnr', function (o, n) {
        var ssn = $scope.pnr;
        if (ssn.length < 11) {
            $scope.pnrClass = "";
            $scope.checksum = "?";
            return;
        }
        $scope.checksum = ssnGen.getModulo10(ssn);
        if (ssn.length == 12 && $scope.checksum == ssn.substr(11, 1)) {
            $scope.pnrClass = "green";
        } else if (ssn.length == 12) {
            $scope.pnrClass = "red";
        }

    });
});