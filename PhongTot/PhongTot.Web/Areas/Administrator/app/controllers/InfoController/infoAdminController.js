/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('infoAdminController', infoAdminController);
    infoAdminController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window'];
    function infoAdminController(apiService, $scope, notificationService, $timeout, $window) {
        $scope.Info = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        function search() {
            getAllInfo();
        }
        $scope.getAllInfo = getAllInfo;
        function getAllInfo(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
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
            }, function () {
                console.log('Load product failed.');
            });
        }
        getAllInfo();
    }
})(angular.module('myAppAdmin'));
