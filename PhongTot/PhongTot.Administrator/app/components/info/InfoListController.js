/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('InfoListController', InfoListController);
    InfoListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function InfoListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.Info = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.filter = {
            Keywords: "",
            StartDate: "",
            EndDate: "",
            Status: true
        }
        $scope.Search = Search;
        function Search() {
            getAllInfo();
        }
        $scope.getAllInfo = getAllInfo;
        function getAllInfo(page) {
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
            apiService.get('api/info/getallpaging', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.Info = result.data.Items;
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
        getAllInfo();
    }
})(angular.module('myApp'));
