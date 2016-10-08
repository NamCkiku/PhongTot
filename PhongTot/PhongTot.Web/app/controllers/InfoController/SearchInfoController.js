(function (app) {
    app.controller('SearchInfoController', SearchInfoController);

    SearchInfoController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window'];

    function SearchInfoController(apiService, $scope, notificationService, commonService, $window) {

        $scope.slider = {
            minValue: 0,
            maxValue: 50,
            options: {
                floor: 0,
                ceil: 50,
                step: 0.5,
                precision: 1,
                hideLimitLabels: true,
                hidePointerLabels: true,
            }
        };


        $scope.keyword = [
            $scope.slider.minValue,
            $scope.slider.maxValue

        ];
        $scope.keywords = [];
        search();
        function search(keywords) {
            var config = {
                params: {
                    keywords: "Hà Nội,Ở ghép,Mê Linh",
                }
            }
            apiService.get('http://localhost:33029/api/info/search', config, function (result) {
                $scope.Info = result.data;
                console.log($scope.Info);
            }, function () {
                notificationService.displayError('Lỗi');
            });
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

        getAllProvinceInfo();
        getAllCategoryInfo();
    }

})(angular.module('myApp'));