/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('InfoEditController', InfoEditController);
    InfoEditController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI', '$state', '$stateParams','$modal'];
    function InfoEditController(apiService, $scope, notificationService, $timeout, $window, blockUI, $state, $stateParams, $modal) {
        $scope.moreImages = [];
        $scope.infoDetail = {};
        function InitCarousel() {
            $timeout(function () {
                var sync1 = $("#sync1");
                sync1.owlCarousel({
                    singleItem: true,
                    slideSpeed: 1000,
                    navigation: false,
                    pagination: true,
                    responsiveRefreshRate: 200,
                    autoPlay: 10000,
                });
            });
        }
        function GetInfoDetail() {
            apiService.get('api/info/getbyid/' + $stateParams.id, null, function (result) {
                $scope.infoDetail = result.data;
                $scope.moreImages = JSON.parse($scope.infoDetail.MoreImages);
                $scope.Convenient = JSON.parse($scope.infoDetail.OtherInfo.Convenient);
                InitCarousel();
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        $scope.Status = false;
        $scope.ChangeStatus = ChangeStatus;
        function ChangeStatus() {
            apiService.get('api/info/changestatus/' + $stateParams.id, null, function (result) {
                $scope.infoDetail.Status = result.data;
                notificationService.displaySuccess('Chúc mừng bạn đã duyệt thành công');
                $state.go('infos');
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        GetInfoDetail();


        $scope.openDeleteInfo = openDeleteInfo;
        function openDeleteInfo(size, id) {
            $scope.modalInstance = $modal.open({
                animation: true,
                templateUrl: 'InfoModal.html',
                backdrop: 'static',
                windowClass: 'center-modal',
                scope: $scope,
                size: size
            });
            $scope.ok = function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/info/delete', config, function () {
                    $scope.modalInstance.dismiss('cancel');
                    notificationService.displaySuccess('Xóa thành công');
                    $state.go('infos');
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            };
            $scope.close = function () {
                $scope.modalInstance.dismiss('cancel');
            };
            $scope.modalInstance.rendered.then(function (response) {
            })
            $scope.modalInstance.result.then(function (response) {

            }, function () {
            });
        }
    }
})(angular.module('myApp'));
