/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />

(function () {
    angular.module('product', ['Tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('product', {
                url: "/product",
                parent: 'base',
                templateUrl: "/App/Components/product/ProductListView.html",
                controller: "ProductListController"
            })
            .state('productadd', {
                url: '/productadd',
                parent: 'base',
                templateUrl: "/App/Components/product/ProductAddView.html",
                controller: "ProductAddController"
            }).state('productEdit', {
                url: '/productEdit/:id',
                parent: 'base',
                templateUrl: "/App/Components/product/ProductEditView.html",
                controller: "ProductEditController"
            });

    }


})();