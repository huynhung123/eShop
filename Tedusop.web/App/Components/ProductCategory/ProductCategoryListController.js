(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService'];

    function ProductCategoryListController($scope, apiService) {

        $scope.productcategories = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';
        $scope.getProductcategories = getProductcategories;

        //tim kiem san pham bang keywỏd
        $scope.SeachPC = SeachPC;
        function SeachPC() {

            getProductcategories();
        }
        /// ket thúc tim kiem

        function getProductcategories(page) {
            ///Phan trang
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2

                }


            }
            ////
            apiService.get('/api/product1/getall', config, function (result) {
                /// phan trang
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