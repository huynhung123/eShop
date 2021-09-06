(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams','commonService'];
    function productCategoryEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {

        $scope.ProducCategory = {

            CreatedDate: new Date(),
            Status: true

        }

        /// lay du lieu ra theo ID

        function LoadproductCategoryDetail() {

            apiService.get('api/product1/getbyid/' + $stateParams.id, null, function (result) {

                $scope.ProducCategory = result.data;

            }, function (error) {

                notificationService.displayError(error.data);

            });
        }



        /// load Option
        function LoadParent() {
            apiService.get('api/product1/getallParents', null, function (result) {

                $scope.parentCategories = result.data;
            }, function () {

                console.log('Cannot Pr');
            });

        }

        //cap nhat du lieu

        $scope.frmProductcategoryEdit = frmProductcategoryEdit;

        function frmProductcategoryEdit() {
            apiService.put('api/product1/update', $scope.ProducCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('productcategory');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        // Seo Alias

        $scope.GetseoAlias = GetseoAlias;
        function GetseoAlias() {

            $scope.ProducCategory.Alias = commonService.getSeoTitle($scope.ProducCategory.Name);

        }

        LoadParent();
        LoadproductCategoryDetail();
    }
})(angular.module('tedushop.productcategory'));