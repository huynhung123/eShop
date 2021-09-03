(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService','notificationService'];

    function ProductCategoryListController($scope, apiService, notificationService) {

        $scope.productcategories = [];
        $scope.page = 0; /// phan trang
        $scope.pageCount = 0; //// phan trang
        $scope.keyword = ''; /// tim kiem san pham theo key wword
        $scope.getProductcategories = getProductcategories;

        //tim kiem san pham bang keywỏd
        $scope.SeachPC = SeachPC;
        function SeachPC() {

            getProductcategories();
        }

        /// ket thúc tim kiem

        function getProductcategories(page) {
            ///Phan trang, tim kiem
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5

                }


            }
            ////
            apiService.get('/api/product1/getall', config, function (result) {
                /// phan trang
                if (result.data.TotalCuont == 0) {

                    return notificationService.displayWarning('Không tìm thấy sản phẩm nào');
                }
                $scope.productcategories = result.data.Items;
                $scope.page = result.data.page;
                $scope.pageCount = result.data.TotalPage;
                $scope.TotalCuont = result.data.TotalCuont;

                ///

            }, function () {
                console.log('load');

            });


        }

        $scope.getProductcategories();
    }


})(angular.module('tedushop.productcategory'));