(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService'];

    function ProductCategoryListController($scope, apiService) {

        $scope.productcategories = [];
        $scope.page = 0;
        $scope.pageCount = 0;

        $scope.getProductcategories = getProductcategories;

        function getProductcategories(page) {

            page = page || 0;
            var config = {
                params: {

                    page: page,
                    pageSize: 4

                }


            }

            apiService.get('/api/product1/getall', config, function (result) {

                $scope.productcategories = result.data.Items;
                $scope.page = result.data.page;
                $scope.pageCount = result.data.TotalPage;
                $scope.TotalCuont = result.data.TotalCuont;



            }, function () {
                console.log('load');

            });


        }

        $scope.getProductcategories();
    }


})(angular.module('tedushop.productcategory'));