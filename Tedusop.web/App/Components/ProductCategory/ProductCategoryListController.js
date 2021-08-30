(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService'];

    function ProductCategoryListController($scope, apiService) {

        $scope.productcategories = [];

        $scope.getProductcategories = getProductcategories;

        function getProductcategories() {

            apiService.get('/api/product1/getall', null, function (result) {

                $scope.productcategories = result.data;


            }, function () {
                console.log('load');

            });


        }

        $scope.getProductcategories();
    }

    
})(angular.module('tedushop.productcategory'));