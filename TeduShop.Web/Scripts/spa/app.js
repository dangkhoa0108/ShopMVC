///// <reference path="../plugins/angular/angular.js" />
////Khởi tạo 1 module gồm 2 tham số: (tên tham số, danh sách dependency)
//var myApp = angular.module('myModule', []);
////Register
//myApp.controller('myController', myController);
//myController.$inject = ['$scope'];
////Khai báo
//function myController($scope) {
//    $scope.message = "This is my message from Controller";
//}


var myApp = angular.module('myModule', []);
myApp.controller('schoolController', schoolController);
myApp.service('ValidatorService', ValidatorService);
myApp.directive('teduShopDirective', teduShopDirective);
schoolController.$inject = ['$scope', 'ValidatorService'];
function schoolController($scope, ValidatorService) {
    $scope.checkNumber= function() {
        $scope.message = ValidatorService.checkNumber( $scope.number);
    }
    $scope.number = 1;
}

function ValidatorService() {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 === 0) {
            return 'This is Event';
        } else {
            return 'No...';
        }
    }
}

function teduShopDirective() {
    return {
        template: '<h1>First Directive</h1>'
    }
}