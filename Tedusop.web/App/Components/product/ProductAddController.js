/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />


(function (app) {

    app.controller('ProductAddController', ProductAddController)

    ProductAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function ProductAddController($scope, apiService, notificationService, $state, commonService) {

        /// Chon anh Ckfinder
        $scope.product = {

            CreatedDate: new Date(),
            Status: true,
            HomeFlang: true,
            HotFlang: true

        }

        /// add san pham
        $scope.frmProductAdd = frmProductAdd;

        function frmProductAdd() {
            $scope.product.MoreImages = JSON.stringify($scope.MoreImages)
            apiService.post('api/product/Created', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('product');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        ///seoalias

        $scope.GetseoAlias = GetseoAlias;
        function GetseoAlias() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        /// Laay danh sach parenId
        function LoadParent() {

            apiService.get('api/product1/getallParents', null, function (result) {
                $scope.parentCategories = result.data;

            }, function () {
                console.log('Cannot Pr');

            })
        }
        LoadParent();

        //// chọn ảnh
        $scope.ChooseI = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });

            }
            finder.popup();
        }
        ///chon nhieu anh
        $scope.MoreImages = [];
        $scope.ChooseMoreImg = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.MoreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
    }

})(angular.module('product'));