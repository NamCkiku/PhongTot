﻿/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('postListController', postListController);
    postListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function postListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.post = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.filter = {
            Keywords: "",
            StartDate: "",
            EndDate: "",
            Status: true
        }
        $scope.Search = Search;
        function Search() {
            $('#gridPost').data('kendoGrid').dataSource.read();
        }
        function getAllInfo(page) {
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
                                    page: options.data.skip,
                                    pageSize: options.data.take
                                }
                            }
                            apiService.get('api/post/getallpaging', config, function (result) {
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
                        total: "TotalPages"
                    },

                    serverPaging: true
                }),
                sortable: true,
                pageable: true,
                columns: [{
                    field: "Image",
                    title: "Ảnh",
                    width: "100px",
                    template: "<img width=\"40\" height=\"40\" src=\"http://localhost:33029/Content/images/#:data.Image#\" />"
                }, {
                    field: "Name",
                    title: "Tiêu đề"
                }, {
                    field: "CreateDate",
                    title: "Ngày tạo",
                    width: "150px",
                    template: "#=CreateDate == null ? '' : kendo.toString(kendo.parseDate(CreateDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #"
                }, {
                    field: "Status",
                    title: "Trạng thái",
                    width: "150px",
                    template: "#= Status == true ? '<span class=\"label label-info\">Kích hoạt' : '<span class=\"label label-info\">Khóa' #"
                }, {
                    field: "HotFlag",
                    title: "Tin Nổi Bật",
                    width: "150px",
                    template: "#= HotFlag == true ? '<span class=\"label label-info\">Kích hoạt' : '<span class=\"label label-info\">Khóa' #"
                }, {
                    field: "ViewCount",
                    title: "Lượt xem",
                    width: "150px",
                }, {
                    width: "100px",
                    title: "Chức năng",
                    template: "<span><button type=\"button\" ui-sref=\"eidtpost({id:#= ID #})\" class=\"btn btn-info btn-sm\"'><i class=\"fa fa-pencil\"></i></button></span>&nbsp;<span><button type=\"button\" ui-sref=\"categoryInfoEdit({id:#= ID #})\" class=\"btn btn-danger btn-sm\"><i class=\"fa fa-trash\"></i></button></span>"
                }]
            };
        }
        getAllInfo();
    }
})(angular.module('myApp'));
