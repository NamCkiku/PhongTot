(function (app) {
    app.controller('postDetailController', postDetailController);

    postDetailController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window', '$timeout'];

    function postDetailController(apiService, $scope, notificationService, commonService, $window, $timeout) {
        $scope.Post = [];
        $scope.postReated = [];
        $scope.postDetail = [];

        function getID() {
            var path = $window.location.href;
            var result = String(path).split("/");
            if (result != null && result.length > 0) {
                var id = result[result.length - 1];
                return id;
            }
        }
        function getPostDetail() {
            var id = getID();
            apiService.get('api/post/getbyid/' + id, null, function (result) {
                $scope.postDetail = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }

        function getReatedPost() {
            var config = {
                params: {
                    id : getID()
                }
            }
            apiService.get('api/post/reatedpost', config, function (result) {
                $scope.postReated = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        


        function getAllPost() {
            apiService.get('api/post/getall', null, function (result) {
                $scope.Post = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }
        getAllPost();
        getPostDetail();
        getReatedPost();
    }

})(angular.module('myApp'));