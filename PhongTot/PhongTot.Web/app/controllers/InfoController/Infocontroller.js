/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('infoController', infoController);
    infoController.$inject = ['apiService', '$scope', 'commonService', 'notificationService'];
    function infoController(apiService, $scope, commonService, notificationService) {
        $scope.Info = [];
        $scope.categoryinfo = [];
        $scope.province = [];
        $scope.district = [];
        $scope.ward = [];
        $scope.category = "";
        $scope.infoAdd = {
            CreateDate: new Date(),
            Status: false,
            OtherInfo:{}

        }
        $scope.option = {

        }
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.infoAdd.Alias = commonService.getSeoTitle($scope.infoAdd.Name);
        }

        function getAllCategoryInfo() {
            apiService.get('http://localhost:33029/api/categoryinfo/getall', null, function (result) {
                $scope.categoryinfo = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }

        function getAllProvinceInfo() {
            apiService.get('http://localhost:33029/api/province/getall', null, function (result) {
                $scope.province = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }

        $scope.getAlDistrictByProvince = getAlDistrictByProvince;
        function getAlDistrictByProvince(id) {

            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('http://localhost:33029/api/district/getallbyprovince/' + config.params.id, null, function (result) {
                $scope.district = result.data;
            }, function () {
                console.log(config);
                notificationService.displayError('Lỗi');
            });
        }

        $scope.getAlWardByDistrict = getAlWardByDistrict;
        function getAlWardByDistrict(id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('http://localhost:33029/api/ward/getallbydistrict/' + config.params.id, null, function (result) {
                $scope.ward = result.data;
            }, function () {
                console.log(config);
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
        $scope.createInfo = createInfo;
        function createInfo() {
            console.log($scope.infoAdd)
            debugger;
            apiService.post('http://localhost:33029/api/info/add', $scope.infoAdd, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công.');
            });
        }




        $scope.tinymceOptions = {
            height: 200,
            // menubar: false,
            plugins: [
              'advlist autolink lists link image charmap print preview anchor',
              'searchreplace visualblocks code fullscreen',
              'insertdatetime media table contextmenu paste code'
            ],
            toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            inline: false,
            skin: 'lightgray',
            theme: 'modern',
            menubar: false,
        };
        getAllInfo();
        getAllProvinceInfo();
        getAllCategoryInfo();

    }
})(angular.module('myApp'));
