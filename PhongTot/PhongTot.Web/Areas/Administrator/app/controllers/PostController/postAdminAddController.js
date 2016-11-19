(function (app) {
    app.controller('postAdminAddController', postAdminAddController);

    postAdminAddController.$inject = ['apiService', '$scope', 'notificationService'];

    function postAdminAddController(apiService, $scope, notificationService) {
        $scope.postCategories = [];
        $scope.post = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.AddPost = AddPost;

        function AddPost() {
            apiService.post('api/post/create', $scope.post,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được thêm mới.');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');

                });
        }
        function loadPostCategory() {
            apiService.get('api/postcategory/getall', null, function (result) {
                $scope.postCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadPostCategory();
    }


})(angular.module('myAppAdmin'));