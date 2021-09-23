/// <reference path="../assets/admin/libs/angular.js/angular.js" />
(function () {
    angular.module('tedushop',
        ['tedushop.productcategory',
            'product',
            'Tedushop.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/App/shraed/View/baseView.html',
                abstract: true
            }).state('Login', {
                url: "/login",
                templateUrl: "/App/Components/Login/loginView.html",
                controller: "loginController"
            })
            .state('Home', {
                parent: 'base',
                url: "/admin",
                templateUrl: "/App/Components/Home/HomeView.html",
                controller: "HomeController"
            })
        $urlRouterProvider.otherwise('/admin');

    }

    function configAuthentication($httpProvider) {
            $httpProvider.interceptors.push(function ($q, $location) {
                return {
                    request: function (config) {

                        return config;
                    },
                    requestError: function (rejection) {

                        return $q.reject(rejection);
                    },
                    response: function (response) {
                        if (response.status == "401") {
                            $location.path('/login');
                        }
                        //the same response/modified/or a new one need to be returned.
                        return response;
                    },
                    responseError: function (rejection) {

                        if (rejection.status == "401") {
                            $location.path('/login');
                        }
                        return $q.reject(rejection);
                    }
                };
            });
    }

})();