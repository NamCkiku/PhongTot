(function (app) {
    app.controller('SearchInfoController', SearchInfoController);

    SearchInfoController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window', '$location'];

    function SearchInfoController(apiService, $scope, notificationService, commonService, $window, $location) {
        $scope.Info = [];
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
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
        var QueryString = function () {
            // This function is anonymous, is executed immediately and 
            // the return value is assigned to QueryString!
            var query_string = {};
            var query = window.location.search.substring(1);
            var vars = query.split("&");
            for (var i = 0; i < vars.length; i++) {
                var pair = vars[i].split("=");
                // If first entry with this name
                if (typeof query_string[pair[0]] === "undefined") {
                    query_string[pair[0]] = decodeURIComponent(pair[1]);
                    // If second entry with this name
                } else if (typeof query_string[pair[0]] === "string") {
                    var arr = [query_string[pair[0]], decodeURIComponent(pair[1])];
                    query_string[pair[0]] = arr;
                    // If third or later entry with this name
                } else {
                    query_string[pair[0]].push(decodeURIComponent(pair[1]));
                }
            }
            return query_string;
        }();
        $scope.keywords = [];
        function search(keywords) {
            var params = {
                CategoryID: $scope.keywords.CategoryID,
                PriceFrom: $scope.slider.minValue,
                PriceTo: $scope.slider.maxValue,
                Wardid: $scope.keywords.Wardid,
                Districtid: $scope.keywords.Districtid,
                Provinceid: $scope.keywords.Provinceid
            };
            var queryString = [];
            for (var key in params) {
                if (params[key] !== undefined) {
                    queryString.push(key + '=' + params[key]);
                }
            }
            $window.location.href = '/Info/Search?' + queryString.join('&');

        }
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            ResultSearch();
        }
        $scope.ResultSearch = ResultSearch;
        function ResultSearch(page) {
            page = page || 0;
            var config = {
                params: {
                    CategoryID: QueryString.CategoryID,
                    PriceFrom: QueryString.PriceFrom * 1000000,
                    PriceTo: QueryString.PriceTo * 1000000,
                    Wardid: QueryString.Wardid,
                    Districtid: QueryString.Districtid,
                    Provinceid: QueryString.Provinceid,
                    page: page,
                    pageSize: 10,
                    sort: $scope.sortKey
                }
            }
            apiService.get('http://localhost:33029/api/info/search', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.Info = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        function getAllCategoryInfo() {
            apiService.get('http://localhost:33029/api/categoryinfo/getall', null, function (result) {
                $scope.categoryinfo = result.data;
            }, function () {
                notificationService.displayError('Load product failed.');
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
        ResultSearch();
        $scope.search = search;
    }

})(angular.module('myApp'));