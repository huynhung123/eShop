(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function ProductCategoryListController($scope, apiService, notificationService, $ngBootbox) {

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

        //Xoa 1 san pham

        $scope.deldeteproduct = deldeteproduct;

        function deldeteproduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product1/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    SeachPC();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
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