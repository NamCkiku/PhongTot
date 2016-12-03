/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('categoryInfoListController', categoryInfoListController);
    categoryInfoListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function categoryInfoListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.categoryInfo = [];
        $scope.filter = {
            Keywords: "",
            StartDate: "",
            EndDate: "",
            Status: true
        }
        $scope.Search = Search;
        function Search() {
            getAllCategoryInfo();
        }
        function getAllCategoryInfo(page) {
            var myBlockUI = blockUI.instances.get('myBlockUI');
            myBlockUI.start();
            page = page || 0;
            var config = {
                params: {
                    Keywords: $scope.filter.Keywords,
                    StartDate: $scope.filter.StartDate,
                    EndDate: $scope.filter.EndDate,
                    Status: $scope.filter.Status,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('api/categoryinfo/getallpaging', config, function (result) {
                if (result.data == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.categoryInfo = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $timeout(function (result) {
                    // Stop the block after some async operation.
                    myBlockUI.stop();
                }, 100);
            }, function () {
                console.log('Load product failed.');
            });
        }
        getAllCategoryInfo();
    }
})(angular.module('myApp'));
