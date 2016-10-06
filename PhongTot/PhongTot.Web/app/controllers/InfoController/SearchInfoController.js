(function (app) {
    app.controller('SearchInfoController', SearchInfoController);

    SearchInfoController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window'];

    function SearchInfoController(apiService, $scope, notificationService, commonService, $window) {

        function search(keyword) {
            var config = {
                params: {
                    keyword: "Thái Nguyên",
                }
            }
            apiService.get('http://localhost:33029/api/info/search', config, function (result) {
                $scope.Info = result.data;
                console.log($scope.Info);
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
    }

})(angular.module('myApp'));