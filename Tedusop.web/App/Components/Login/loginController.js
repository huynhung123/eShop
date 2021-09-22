/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />

(function (app) {

    app.controller('loginController', loginController)
    loginController.$inject = ['$scope', 'loginService', '$injector', 'notificationService']
    function loginController($scope, loginService, $injector, notificationService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.loginSubmit = function () {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.error != undefined) {
                    notificationService.displayError("Đăng nhập không đúng.");
                }
                else {
                    var stateService = $injector.get('$state');
                    stateService.go('home');
                }
            });
        }
        
    }
})(angular.module('tedushop'));