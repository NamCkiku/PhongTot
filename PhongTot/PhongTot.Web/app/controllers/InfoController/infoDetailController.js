(function (app) {
    app.controller('infoDetailController', infoDetailController);

    infoDetailController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window'];

    function infoDetailController(apiService, $scope, notificationService, commonService, $window) {

        $scope.moreImages = [];


        function getID() {
            var path = $window.location.href;
            var result = String(path).split("/");
            if (result != null && result.length > 0) {
                var id = result[result.length - 1];
                return id;
            }
        }


        function GetInfoDetail() {
            var id = getID();
            apiService.get('http://localhost:33029/api/info/getbyid/' + id, null, function (result) {
                $scope.infoDetail = result.data;
                $scope.moreImages = JSON.parse($scope.infoDetail.MoreImages);
                $scope.Convenient = JSON.parse($scope.infoDetail.OtherInfo.Convenient);
                console.log($scope.infoDetail);
                console.log($scope.moreImages);
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        GetInfoDetail();
    }

})(angular.module('myApp'));