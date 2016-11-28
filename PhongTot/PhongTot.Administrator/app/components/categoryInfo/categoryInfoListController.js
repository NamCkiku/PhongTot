/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('categoryInfoListController', categoryInfoListController);
    categoryInfoListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function categoryInfoListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.categoryInfo = [];
        function getAllCategoryInfo() {
            var myBlockUI = blockUI.instances.get('myBlockUI');
            myBlockUI.start();
            apiService.get('api/categoryinfo/getall', null, function (result) {
                if (result.data == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.categoryInfo = result.data;
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
