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




        ///seoalias

        $scope.GetseoAlias = GetseoAlias;
        function GetseoAlias() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        /// Laay danh sach parenId
        function LoadParent() {

            apiService.get('api/product/getallparenID', null, function (result) {
                $scope.parentCategories = result.data;

            }, function () {
                console.log('Cannot Pr');

            })
        }
        LoadParent();

        ////
        $scope.ChooseI = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });

            }
            finder.popup();
        }

    }

})(angular.module('product'));