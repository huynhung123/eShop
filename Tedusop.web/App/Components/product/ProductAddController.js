/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />


(function (app) {

    app.controller('ProductAddController', ProductAddController)

    ProductAddController.$inject = ['$scope'];

    function ProductAddController($scope) {







        /// Chon anh Ckfinder
        var product = {
            Image: null
        }

        $scope.product = product;

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