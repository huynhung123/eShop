/// <reference path="../assets/admin/libs/angular.js/angular.js" />
(function () {
    angular.module('tedushop', ['tedushop.productcategory',
        'Tedushop.common']).config(config);

    config.$inject  = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('Home', {
            url: "/admin",
            templateUrl: "/App/Components/Home/HomeView.html",
            controller: "HomeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }

})();