(function (app) {
    'use strict';

    app.controller('membershipProfileAddController', membershipProfileAddController);

    membershipProfileAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'blockUI'];

    function membershipProfileAddController($scope, apiService, notificationService, $state, $stateParams, blockUI) {
        $scope.account = {
            EmailConfirmed: true,
            CreatedDate: new Date(),
            Groups: []
        }
        $scope.addAccount = addAccount;

        function addAccount() {
            apiService.post('/api/applicationUser/add', $scope.account, addSuccessed, addFailed);
        }
        function addSuccessed() {
            notificationService.displaySuccess($scope.account.Name + ' đã được thêm mới.');
            $state.go('membership');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function loadGroups() {
            apiService.get('/api/applicationGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                });

        }

        loadGroups();
    }
})(angular.module('myApp'));