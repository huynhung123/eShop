/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />
(function () {
    angular.module('tedushop.productcategory', ['Tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('productcategory', {
                url: "/productcategory",
                templateUrl: "/App/Components/ProductCategory/ProductCategoryListView.html",
                controller: "ProductCategoryListController"
            })
            .state('productcategoryadd', {
                url: "/productcategoryadd",
                templateUrl: "/App/Components/ProductCategory/ProductCategoryAddView.html",
                controller: "ProductCategoryAddController"
            })
            .state('productcategoryedit', {
                url: "/productcategoryedit/:id",
                templateUrl: "/App/Components/ProductCategory/productCategoryEditView.html",
                controller: "productCategoryEditController"
            });

    }

})();