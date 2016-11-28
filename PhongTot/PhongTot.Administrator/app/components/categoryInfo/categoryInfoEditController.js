(function (app) {
    app.controller('categoryInfoEditController', categoryInfoEditController);

    categoryInfoEditController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state', '$stateParams'];

    function categoryInfoEditController(apiService, $scope, notificationService, commonService, $state, $stateParams) {
        $scope.categoryInfo = {
        }
        $scope.lisInfoCategories = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.categoryInfo.Alias = commonService.getSeoTitle($scope.categoryInfo.Name);
        }

        function LoadCategoryInfotDetail() {
            apiService.get('api/categoryinfo/getbyid/' + $stateParams.id, null, function (result) {
                console.log(result.data);
                $scope.categoryInfo = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        $scope.UpdateCategoryInfo = UpdateCategoryInfo;
        function UpdateCategoryInfo() {
            apiService.put('api/categoryinfo/update', $scope.categoryInfo,
                function (result) {
                    notificationService.displaySuccess('Chúc mừng bạn đã cập nhập thành công');
                    $state.go('categoryInfo');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
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
        LoadCategoryInfotDetail();
    }


})(angular.module('myApp'));