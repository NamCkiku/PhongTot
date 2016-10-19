/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('infoController', infoController);
    infoController.$inject = ['apiService', '$scope', 'commonService', 'notificationService', 'fileUploadService', '$timeout', '$window'];
    function infoController(apiService, $scope, commonService, notificationService, fileUploadService, $timeout, $window) {
        $scope.Info = [];
        $scope.categoryinfo = [];
        $scope.province = [];
        $scope.district = [];
        $scope.ward = [];
        $scope.category = "";

        $scope.Convenient = [
            'Chỗ để xe',
            'Sân phơi',
            'Thang máy',
            'Internet',
            'Điều hòa',
            'Bình nóng lạnh',
            'Máy giặt',
            'Truyền hình cáp',
            'Tivi'
        ];



        $scope.infoAdd = {
            CreateDate: new Date(),
            Status: false,
            OtherInfo: {
                Convenient:[]
            },
            Image: "adadsadasd",

        };

        $scope.getFiles = function () {
            console.log($scope.dzMethods.getAllFiles());
            alert('Check console log.');
        };
        Dropzone.autoDiscover = false;
        //Set options for dropzone
        //Visit http://www.dropzonejs.com/#configuration-options for more options
        $scope.dzOptions = {
            url: 'http://localhost:33029/api/info/images/uploadFile',
            paramName: 'photo',
            maxFilesize: 2, // MB
            maxFiles: 8,
            addRemoveLinks: true,
            dictDefaultMessage: 'Nhấn vào đây để thêm hoặc thả các bức ảnh',
            dictRemoveFile: 'Xóa Ảnh',
            dictResponseError: 'Không thể tải ảnh này',
            init: function () {
                this.on("maxfilesexceeded", function (file) {
                    this.removeFile(file);
                    notificationService.displayError('Giới hạn số lượng hình ảnh là 8!');
                });
            },
            acceptedFiles: 'image/jpeg, images/jpg, image/png',
            addRemoveLinks: true,
            //autoProcessQueue: false,
        };
        //Handle events for dropzone
        //Visit http://www.dropzonejs.com/#events for more events
        $scope.dzCallbacks = {
            'addedfile': function (file) {
                $scope.infoAdd.MoreImages = [];

            },
            'thumbnail': function (file, dataUrl) {
                $scope.infoAdd.MoreImages.push(file.name);
                console.log($scope.infoAdd.MoreImages);
            },
            'success': function (file, xhr) {
                console.log(file, xhr);
            },
        };
        //Apply methods for dropzone
        //Visit http://www.dropzonejs.com/#dropzone-methods for more methods

        $scope.dzMethods = {
        };

        var morImage = $scope.newFile;


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


        var infoImage = null;
        $scope.prepareFiles = prepareFiles;
        function prepareFiles($files) {
            infoImage = $files;
        }

        $scope.createInfo = createInfo;
        function createInfo() {
            $scope.infoAdd.OtherInfo.Convenient = JSON.stringify($scope.infoAdd.OtherInfo.Convenient)
            $scope.infoAdd.MoreImages = JSON.stringify($scope.infoAdd.MoreImages)
            console.log($scope.infoAdd)
            debugger;
            apiService.post('http://localhost:33029/api/info/add', $scope.infoAdd, function (result) {
                $scope.infoAdd = result.data;
                if (infoImage) {
                    fileUploadService.uploadImage(infoImage, $scope.infoAdd.ID);
                }
                //$scope.dzMethods.processQueue();
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                $window.location.href = '/Home/Index/';
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
