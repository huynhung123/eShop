
(function (app) {

    app.controller('ProductCategoryAddController', ProductCategoryAddController)

    ProductCategoryAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state'];

    function ProductCategoryAddController($scope, apiService, notificationService, $state) {

        $scope.ProducCategory = {

            CreatedDate: new Date(),
            Status: true,
         
        }

        /// Add product





        $scope.frmProductcategoryAdd = frmProductcategoryAdd;

        function frmProductcategoryAdd() {
            apiService.post('api/product1/Created', $scope.ProducCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('productcategory');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        /// Load Option
        function LoadParent() {
            apiService.get('api/product1/getallParents', null, function (result) {

                $scope.parentCategories = result.data;
            }, function () {

                console.log('Cannot Pr');
            });

        }

        LoadParent();

    }

})(angular.module('tedushop.productcategory'));