﻿/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('categoryInfoListController', categoryInfoListController);
    categoryInfoListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function categoryInfoListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.categoryInfo = [];
        $scope.filter = {
            Keywords: "",
            StartDate: "",
            EndDate: "",
            Status: true
        }
        $scope.Search = Search;
        function Search() {
            $('#gridInfoCategory').data('kendoGrid').dataSource.read();
        }
        function getAllCategoryInfo() {
            $scope.mainGridOptions = {
                toolbar: ["excel"],
                excel: {
                    //fileName: "Kendo UI Grid Export.xlsx",
                    //proxyURL: "//demos.telerik.com/kendo-ui/service/export",
                    filterable: true
                },
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: function (options) {
                            var config = {
                                params: {
                                    Keywords: $scope.filter.Keywords,
                                    StartDate: $scope.filter.StartDate,
                                    EndDate: $scope.filter.EndDate,
                                    Status: $scope.filter.Status,
                                    page: options.data.page - 1,
                                    pageSize: options.data.pageSize
                                }
                            }
                            apiService.get('api/categoryinfo/getallpaging', config, function (result) {
                                options.success(result.data);
                                $scope.totalCount = result.data.TotalCount;
                            }, function () {
                                options.error(result.data);
                            });
                        }
                    },
                    pageSize: 10,
                    schema: {
                        data: "Items",
                        total: "TotalCount"
                    },

                    serverPaging: true
                }),
                sortable: true,
                pageable: true,
                columns: [{
                    field: "ID",
                    title: "Mã",
                    width: "100px",
                }, {
                    field: "Name",
                    title: "Tiêu đề"
                }, {
                    field: "CreatedDate",
                    title: "Ngày tạo",
                    width: "150px",
                    template: "#=CreatedDate == null ? '' : kendo.toString(kendo.parseDate(CreatedDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #"
                }, {
                    field: "Status",
                    title: "Trạng thái",
                    width: "150px",
                    template: "#= Status == true ? '<span class=\"label label-info\">Kích hoạt' : '<span class=\"label label-info\">Khóa' #"
                },{
                    width: "100px",
                    title: "Chức năng",
                    template: "<span><button type=\"button\" ui-sref=\"categoryInfoEdit({id:#= ID #})\" class=\"btn btn-info btn-sm\"'><i class=\"fa fa-pencil\"></i></button></span>&nbsp;<span><button type=\"button\" ui-sref=\"categoryInfoEdit({id:#= ID #})\" class=\"btn btn-danger btn-sm\"><i class=\"fa fa-trash\"></i></button></span>"
                }]
            };
        }
        getAllCategoryInfo();
    }
})(angular.module('myApp'));
