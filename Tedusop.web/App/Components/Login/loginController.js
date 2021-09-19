/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />

(function (app) {

    app.controller('loginController', loginController)
    loginController.$inject=['$scope', '$state']
    function loginController($scope, $state) {
        $scope.logonSubmit = function () {
            $state.go('Home')
        }
        
    }
})(angular.module('tedushop'));