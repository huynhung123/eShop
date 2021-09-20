/// <reference path="../assets/admin/libs/angular.js/angular.js" />
(function () {
    angular.module('tedushop',
        ['tedushop.productcategory',
            'product',
            'Tedushop.common']).config(config);

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

})();