﻿(function (app) {
    app.controller('postAddController', postAddController);

    postAddController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state'];

    function postAddController(apiService, $scope, notificationService, commonService, $state) {
        $scope.postCategories = [];
        $scope.post = {
            Status: true,
            HotFlag: false,
            CreateDate:new Date()
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }

        $scope.AddPost = AddPost;
        function AddPost() {
            apiService.post('api/post/add', $scope.post,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được thêm mới.');
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

        loadPostCategory();
    }


})(angular.module('myApp'));