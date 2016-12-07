(function (app) {
    'use strict';

    app.controller('membershipProfileViewController', membershipProfileViewController);

    membershipProfileViewController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams', 'blockUI'];

    function membershipProfileViewController($scope, apiService, notificationService, $location, $stateParams, blockUI) {
        $scope.account = {}
        function loadDetail() {
            var myBlockUI = blockUI.instances.get('myBlockUI');
            myBlockUI.start();
            apiService.get('/api/applicationUser/detail/' + $stateParams.id, null,
            function (result) {
                $scope.account = result.data.Result;
                console.log($scope.account)
                $timeout(function (result) {
                    // Stop the block after some async operation.
                    myBlockUI.stop();
                }, 100);
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }
        loadDetail();
    }
})(angular.module('myApp'));