/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />


(function (app) {

    app.controller('ProductEditController', ProductEditController)
    ProductEditController.$inject = ['$scope', 'apiService', 'notificationService','$stateParams','$state', 'commonService']
    function ProductEditController($scope, apiService, notificationService, $stateParams, $state, commonService) {
        $scope.product = [];

        // update san pham
        $scope.frmProductEdit = frmProductEdit;

        function frmProductEdit() {
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cap nhat.');
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Cap nhat không thành công.');
                });

        }
        // lay san pham theo ID


        function LoadproductCategoryDetail() {

            apiService.get('api/product/GetbyId/' + $stateParams.id, null, function (result) {

                $scope.product = result.data;

            }, function (error) {

                notificationService.displayError(error.data);

            });
        }

        ///seoalias

        $scope.GetseoAlias = GetseoAlias;
        function GetseoAlias() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        //Load Danh muc
        function LoadParent() {

            apiService.get('api/product1/getallParents', null, function (result) {
                $scope.parentCategories = result.data;

            }, function () {
                console.log('Cannot Pr');

            })
        }
        LoadParent();
        // Finder
        $scope.ChooseI = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });

            }
            finder.popup();
        }

        LoadproductCategoryDetail();


    }

})(angular.module('product'));