(function (app) {
    app.controller('postEditController', postEditController);

    postEditController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state', '$stateParams'];

    function postEditController(apiService, $scope, notificationService, commonService, $state, $stateParams) {
        $scope.postCategories = [];
        $scope.post = {
            Status: true,
            HotFlag:false,
            CreateDate: new Date()
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }
        function LoadPostDetail() {
            apiService.get('api/post/getbyid/' + $stateParams.id, null, function (result) {
                $scope.post = result.data;
                console.log($scope.post);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        $scope.EditPost = EditPost;
        function EditPost() {
            apiService.put('api/post/update', $scope.post,
                function (result) {
                    notificationService.displaySuccess("Cập Nhập Thành Công");
                    $state.go('post');
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
        LoadPostDetail();
        loadPostCategory();
    }


})(angular.module('myApp'));