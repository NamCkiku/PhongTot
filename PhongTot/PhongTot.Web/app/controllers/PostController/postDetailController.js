(function (app) {
    app.controller('postDetailController', postDetailController);

    postDetailController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$window', '$timeout'];

    function postDetailController(apiService, $scope, notificationService, commonService, $window, $timeout) {


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
            var id = getID();
            apiService.get('api/post/reatedpost/', id, function (result) {
                $scope.postReated = result.data;
            }, function () {
                notificationService.displayError('Lỗi');
            });
        }

        getPostDetail();
        getReatedPost();
    }

})(angular.module('myApp'));