/// <reference path="E:\_Study\_SourceCode\_SourseGithub\PhongTot\PhongTot\PhongTot.Web\bower_components/angular/angular.js" />
(function (app) {
    app.controller('InfoListController', InfoListController);
    InfoListController.$inject = ['apiService', '$scope', 'notificationService', '$timeout', '$window', 'blockUI'];
    function InfoListController(apiService, $scope, notificationService, $timeout, $window, blockUI) {
        $scope.Info = [];
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
            $('#gridInfo').data('kendoGrid').dataSource.read();
        }
        $scope.getAllInfo = getAllInfo;
        function getAllInfo() {
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
                                    page: options.data.page-1,
                                    pageSize: options.data.pageSize
                                }
                            }
                            apiService.get('api/info/getallpaging', config, function (result) {
                                options.success(result.data);
                                $scope.totalCount = result.data.TotalCount;
                            }, function () {
                                options.error(result.data);
                            });
                        }
                    },
                    pageSize:10,
                    schema: {
                        data: "Items",
                        total: "TotalCount"
                    },

                    serverPaging: true
                }),
                sortable: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
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
                    width: "100px",
                    title: "Chức năng",
                    template: "<button class=\"btn btn-sm btn-info\" ui-sref=\"infoedit({id:#= ID #})\"><i class=\"fa fa-eye\"></i></button>"
                }]
            };
        }
        getAllInfo();
    }
})(angular.module('myApp'));
