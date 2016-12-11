(function (app) {
    app.controller('postCategoryAddController', postCategoryAddController);

    postCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state'];

    function postCategoryAddController(apiService, $scope, notificationService, commonService, $state) {
        $scope.postcategory = {
            Status: true,
            CreatedDate:new Date()
        }
        $scope.lispostCategories = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.postcategory.Alias = commonService.getSeoTitle($scope.postcategory.Name);
        }

        $scope.AddPostCategory = AddPostCategory;

        function AddPostCategory() {
            apiService.post('api/postcategory/add', $scope.postcategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được thêm mới.');
                    $state.go('postcategory');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');

                });
        }


        function loadPostCategory() {
            apiService.get('api/postcategory/getall', null, function (result) {
                $scope.lispostCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadPostCategory();
    }


})(angular.module('myApp'));