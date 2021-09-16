/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />


(function (app) {

    app.controller('ProductListController', ProductListController)

    ProductListController.$inject = ['$scope', 'apiService', 'notificationService']
    function ProductListController($scope, apiService, notificationService) {
        $scope.product = [];
        $scope.page = 0;
        $scope.pageSize = 0;
        $scope.getProduct = getProduct;

        //lay danh sach san pham
        function getProduct(page) {

            page = page || 0;

            var config = {

                params: {

                    page: page,
                    pageSize: 2

                }

            }

            apiService.get('api/product/getall', config, function (result) {
                $scope.product = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pageCount = result.data.TotalPage;
                $scope.TotalCuont = result.data.TotalCuont;
            }, function (error) {
                console.log('khong co san pham nao')
            })

        }


        $scope.getProduct();
    }

})(angular.module('product'));