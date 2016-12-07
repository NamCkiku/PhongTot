(function (app) {
    app.controller('systemParameterEditController', systemParameterEditController);
    systemParameterEditController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function systemParameterEditController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.SaveData = SaveData;
        function SaveData() {
            $scope.arrSyspara = [];
            $scope.arrSyspara.push({ Field: $("#chkshowsearch").attr("name"), Value: $("#chkshowsearch").attr('checked') });
            $scope.arrSyspara = JSON.stringify($scope.arrSyspara);
            apiService.put('api/syspara/update', $scope.arrSyspara,
                function (result) {
                    notificationService.displaySuccess('Chúc mừng bạn đã cập nhập thành công');
                    $state.go('setting');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
    }
})(angular.module('myApp'));