/// <reference path="../../../assets/admin/libs/angular.js/angular.js" />



(function (app) {

    app.controller('ProductListController', ProductListController)

    ProductListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter']
    function ProductListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.product = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getProduct = getProduct;
        $scope.keyWord = '';

        // tim kiem san pham

        $scope.SeachPC = SeachPC;
        function SeachPC() {

            getProduct();
        }


        //lay danh sach san pham
        function getProduct(page) {

            page = page || 0;

            var config = {

                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize: 4

                }

            }
            //end
            apiService.get('api/product/getall', config, function (result) {
                if (result.data.TotalCuont === 0) {
                    return notificationService.displayWarning('Không tìm thấy sản phẩm nào');
                }
                $scope.product = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pageCount = result.data.TotalPage;
                $scope.TotalCuont = result.data.TotalCuont;
            }, function (error) {
                console.log('khong co san pham nao')
            })

        }
        /// xoa 1 san pham

        $scope.deldeteproduct = deldeteproduct;

        function deldeteproduct(id) {
            $ngBootbox.confirm('Ban co chan chan muon xoa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product/delete', config, function () {

                    notificationService.displaySuccess('Xoa thanh cong');
                    SeachPC();
                }, function () {

                    notificationService.displayError('Xoa khong thanh cong');
                })

            })
        }


        /// xoa nhieu san pham

        //1. lang nghe thay doi cua Product
        $scope.$watch('product', function (n, o) {
            var ckecked = $filter("filter")(n, { ckecked: true });
            if (ckecked.length) {
                $scope.selected = ckecked;
                $('#btndelete').removeAttr('disabled');
            }
            else {

                $('#btndelete').attr('disabled');
            }

        }, true)
        /// chon  tat ca

        $scope.selectAll = selectAll;
        $scope.check = false;

        function selectAll() {

            if ($scope.check == false) {

                angular.forEach($scope.product, function (item) {
                    item.ckecked = true;
                })
                $scope.check = true;
            }
            else {

                angular.forEach($scope.product, function (item) {

                    item.ckecked = false;

                })
                $scope.check = false;
            }

        }


        $scope.deleteMuti = deleteMuti;
        function deleteMuti() {

            var lisId = [];
            $.each($scope.selected, function (product, item) {
                lisId.push(item.Id);

            })

            var config = {
                params: {

                    chekProduct: JSON.stringify(lisId)

                }
               
            }

            apiService.del('api/product/deleteMulti', config, function (result) {

                notificationService.displaySuccess('xoa thanh cong')
                SeachPC()
            }, function () {

                notificationService.displayError('xoa khong thanh cong')

            })
        }



        ///end
        //sap xep gia tri table
        $scope.sortColum = 'Id';
        $scope.reverse = false;
        $scope.sortData = function (column) {

            if ($scope.sortColum == column)
                $scope.reverse = !$scope.reverse;
            else
                $scope.reverse = false;

            $scope.sortColum = column;

        }
        $scope.getProduct();
    }

})(angular.module('product'));