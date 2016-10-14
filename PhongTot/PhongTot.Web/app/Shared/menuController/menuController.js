/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('menuController', menuController);
    menuController.$inject = ['apiService', '$scope', 'commonService', 'notificationService'];
    function menuController(apiService, $scope, commonService, notificationService, fileUploadService, $timeout) {
        $scope.categoryinfo = [];
        $scope.category = "";
      
        function getAllCategoryInfo() {
            apiService.get('http://localhost:33029/api/categoryinfo/getall', null, function (result) {
                $scope.categoryinfo = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        getAllCategoryInfo();
    }
})(angular.module('myApp'));
