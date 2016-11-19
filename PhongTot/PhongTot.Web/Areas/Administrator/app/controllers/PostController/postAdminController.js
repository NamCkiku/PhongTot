/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('postAdminController', postAdminController);
    postAdminController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window'];
    function postAdminController(apiService, $scope, notificationService, $timeout, $window) {
        $scope.Post = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        function search() {
            getAllPost();
        }
        $scope.getAllPost = getAllPost;
        function getAllPost(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('api/post/getallpaging', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.Post = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }
        getAllPost();
    }
})(angular.module('myAppAdmin'));
