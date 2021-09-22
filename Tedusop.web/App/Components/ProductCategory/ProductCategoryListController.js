(function (app) {

    app.controller('ProductCategoryListController', ProductCategoryListController)
    ProductCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function ProductCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {

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
                    pageSize: 6

                }


            }
            ////
            apiService.get('/api/product1/getall', config, function (result) {
                /// phan trang
                if (result.data.TotalCuont == 0) {

                    return notificationService.displayWarning('Không tìm thấy sản phẩm nào');
                }
                $scope.productcategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pageCount = result.data.TotalPage;
                $scope.TotalCuont = result.data.TotalCuont;

          
                ///

            }, function () {
                console.log('load');

            });


        }

        ///Xoa nhieu danh muc san pham
        // checkALL Checkbox

        $scope.deleteMuti = deleteMuti;
        function deleteMuti() {
            var lisID = [];
            $.each($scope.selected, function (product, item) {

                lisID.push(item.ID);
            });
            var config = {
                params: {

                    checkProduct: JSON.stringify(lisID)
                }

            }
            apiService.del('api/product1/deletemulti', config, function (result) {
                notificationService.displaySuccess('xoa thanh cong');
                SeachPC()
            }, function (error) {

                notificationService.displayError('xoa khong thanh cong');

            });
        }



        $scope.$watch('productcategories', function (n, o) {

            var ckecked = $filter("filter")(n, { ckecked: true });
            if (ckecked.length) {
                $scope.selected = ckecked;
                $('#btndelete').removeAttr('disabled');
            }
            else {

                $('#btndelete').attr('disabled');
            }

        }, true);

        $scope.selectAll = selectAll;
        $scope.a = false;
        function selectAll() {

            if ($scope.a == false) {
                angular.forEach($scope.productcategories, function (item) {

                    item.ckecked = true;
                })

                $scope.a = true;
            }
            else {
                angular.forEach($scope.productcategories, function (item) {

                    item.ckecked = false;
                });

                $scope.a = false;
            }
        }

     



       
        //sap xep gia tri table
        $scope.sortColum = 'ID';
        $scope.reverse = false;
        $scope.sortData = function (column) {

            if ($scope.sortColum == column)
                $scope.reverse = !$scope.reverse;
            else
                $scope.reverse = false;

            $scope.sortColum = column;

        }
        $scope.getProductcategories();
    }


})(angular.module('tedushop.productcategory'));