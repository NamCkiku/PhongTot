/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('InfoEditController', InfoEditController);
    InfoEditController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI', '$state', '$stateParams'];
    function InfoEditController(apiService, $scope, notificationService, $timeout, $window, blockUI, $state, $stateParams) {
        $scope.moreImages = [];
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
        GetInfoDetail();
    }
})(angular.module('myApp'));
