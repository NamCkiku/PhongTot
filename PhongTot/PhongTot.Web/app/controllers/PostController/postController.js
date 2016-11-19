/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('postController', postController);
    postController.$inject = ['apiService', '$scope', 'commonService', 'notificationService'];
    function postController(apiService, $scope, commonService, notificationService) {
        $scope.Post = [];


        function getAllPost() {
            apiService.get('api/post/getall', null, function (result) {
                $scope.Post = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        getAllPost();
    }
})(angular.module('myApp'));
