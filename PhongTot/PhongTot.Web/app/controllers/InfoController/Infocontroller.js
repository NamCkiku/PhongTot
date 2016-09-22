/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('infoController', infoController);
    infoController.$inject = ['apiService', '$scope', 'notificationService'];
    function infoController(apiService, $scope, notificationService) {
        $scope.Info = [];
        //$scope.info = {
        //    CreatedDate: new Date(),
        //    Status: true,
        //}
        function createInfo() {
            apiService.post('http://localhost:33029/api/info/add', $scope.info, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
            }, function (error) {
                //notificationService.displayError('Thêm mới không thành công.');
            });
        }


        function getAllInfo() {
            apiService.get('http://localhost:33029/api/info/getall', null, function (result) {
                $scope.courses = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        getAllInfo();
    }
})(angular.module('myApp'));
