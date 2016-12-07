(function (app) {
    app.controller('systemParameterListController', systemParameterListController);
    systemParameterListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function systemParameterListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.syspara = [];
        function getAllSystemParameter() {
            var myBlockUI = blockUI.instances.get('myBlockUI');
            myBlockUI.start();
            apiService.get('api/syspara/getall', null, function (result) {
                $scope.syspara = result.data;
                console.log($scope.syspara)
                $timeout(function (result) {
                    // Stop the block after some async operation.
                    myBlockUI.stop();
                }, 100);
            }, function () {
                notificationService.displayError('Lỗi.');
            });
        }
        getAllSystemParameter();
    }
})(angular.module('myApp'));