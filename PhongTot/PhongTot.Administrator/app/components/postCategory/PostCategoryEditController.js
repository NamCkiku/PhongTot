(function (app) {
    app.controller('postCategoryEditController', postCategoryEditController);

    postCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state', '$stateParams'];

    function postCategoryEditController(apiService, $scope, notificationService, commonService, $state, $stateParams) {
        $scope.postcategory = {
            Status: true,
            CreatedDate: new Date()
        }
        $scope.lispostCategories = [];
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.postcategory.Alias = commonService.getSeoTitle($scope.postcategory.Name);
        }

        $scope.UpdatePostCategory = UpdatePostCategory;
        function UpdatePostCategory() {
            apiService.put('api/postcategory/update', $scope.postcategory,
                function (result) {
                    notificationService.displaySuccess("Cập Nhập không thành công.");
                    $state.go('postcategory');
                }, function (error) {
                    notificationService.displayError('Cập Nhập không thành công.');

                });
        }
        function LoadPostCategoryDetail() {
            apiService.get('api/postcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.postcategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function loadPostCategory() {
            apiService.get('api/postcategory/getall', null, function (result) {
                $scope.lispostCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        LoadPostCategoryDetail();
        loadPostCategory();
    }


})(angular.module('myApp'));