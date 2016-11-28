(function (app) {
    app.controller('categoryInfoAddController', categoryInfoAddController);

    categoryInfoAddController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state'];

    function categoryInfoAddController(apiService, $scope, notificationService, commonService, $state) {
        $scope.categoryInfo = {
            Status: true
        }
        $scope.lisInfoCategories = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.categoryInfo.Alias = commonService.getSeoTitle($scope.categoryInfo.Name);
        }

        $scope.AddCategoryInfo = AddCategoryInfo;

        function AddCategoryInfo() {
            apiService.post('api/categoryinfo/add', $scope.categoryInfo,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được thêm mới.');
                    $state.go('categoryInfo');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');

                });
        }


        function loadInfoCategory() {
            apiService.get('api/categoryinfo/getall', null, function (result) {
                $scope.lisInfoCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadInfoCategory();
    }


})(angular.module('myApp'));