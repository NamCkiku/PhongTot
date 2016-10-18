(function (app) {
    app.controller('InfoCategoryController', InfoCategoryController);

    InfoCategoryController.$inject = ['apiService', '$scope', 'notificationService', '$window'];

    function InfoCategoryController(apiService, $scope, notificationService, $window) {
        $scope.infos = [];
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;


        function getID() {
            var path = $window.location.href;
            var result = String(path).split("/");
            if (result != null && result.length > 0) {
                var id = result[result.length - 1];
                return id;
            }
        }
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            GetInfoByCategory();
        }
        $scope.GetInfoByCategory = GetInfoByCategory;
        function GetInfoByCategory(page) {
            page = page || 0;
            var config = {
                params: {
                    id: getID(),
                    page: page,
                    sort: $scope.sortKey,
                    pageSize: 10
                }
            }
            $scope.infos = null;
            apiService.get('http://localhost:33029/api/info/getinfobycategory' , config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.infos = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                console.log($scope.infos);
                console.log($scope.page);
                console.log($scope.pagesCount);
                console.log($scope.totalCount);
            }, function () {
                notificationService.displayError('Load product failed.');
            });
        }
        GetInfoByCategory();
    }

})(angular.module('myApp'));