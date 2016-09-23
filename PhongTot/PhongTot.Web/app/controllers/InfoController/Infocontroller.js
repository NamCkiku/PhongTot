/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('infoController', infoController);
    infoController.$inject = ['apiService', '$scope', 'commonService', 'notificationService'];
    function infoController(apiService, $scope, commonService, notificationService) {
        $scope.Info = [];
        $scope.categoryinfo = [];
        $scope.infoAdd = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.infoAdd.Alias = commonService.getSeoTitle($scope.infoAdd.Name);
        }
        function createInfo() {
            apiService.post('http://localhost:33029/api/info/add', $scope.infoAdd, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công.');
            });
        }
        function getAllCategoryInfo() {
            apiService.get('http://localhost:33029/api/categoryinfo/getall', null, function (result) {
                $scope.categoryinfo = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }

        function getAllInfo() {
            apiService.get('http://localhost:33029/api/info/getall', null, function (result) {
                $scope.Info = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        getAllInfo();
        getAllCategoryInfo();
    }
})(angular.module('myApp'));
