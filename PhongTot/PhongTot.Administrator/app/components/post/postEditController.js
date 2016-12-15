(function (app) {
    app.controller('postEditController', postEditController);

    postEditController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state', '$stateParams'];

    function postEditController(apiService, $scope, notificationService, commonService, $state, $stateParams) {
        $scope.postCategories = [];
        $scope.post = {
            Status: true,
            HotFlag: false,
            CreateDate: new Date()
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        var __appBasePath = 'http://localhost:31223/';
        $scope.editorOptions = {
            tools: [
                    "bold",
                    "italic",
                    "underline",
                    "strikethrough",
                    "justifyLeft",
                    "justifyCenter",
                    "justifyRight",
                    "justifyFull",
                    "insertUnorderedList",
                    "insertOrderedList",
                    "indent",
                    "outdent",
                    "createLink",
                    "unlink",
                    "insertImage",
                    "insertFile",
                    "subscript",
                    "superscript",
                    "createTable",
                    "addRowAbove",
                    "addRowBelow",
                    "addColumnLeft",
                    "addColumnRight",
                    "deleteRow",
                    "deleteColumn",
                    "viewHtml",
                    "formatting",
                    "cleanFormatting",
                    "fontName",
                    "fontSize",
                    "foreColor",
                    "backColor",
                    "print"
            ],

            imageBrowser: {
                messages: {
                    dropFilesHere: "Drop files here"
                },

                transport: {
                    read: __appBasePath + "ImageBrowser/Read",
                    destroy: {
                        url: __appBasePath + "ImageBrowser/Destroy",
                        type: "POST"
                    },
                    create: {
                        url: __appBasePath + "ImageBrowser/Create",
                        type: "POST"
                    },
                    thumbnailUrl: __appBasePath + "ImageBrowser/Thumbnail",
                    uploadUrl: __appBasePath + "ImageBrowser/Upload",
                    imageUrl: __appBasePath + "Content/UserFiles/Images/{0}"
                }
            }
        };
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }
        function LoadPostDetail() {
            apiService.get('api/post/getbyid/' + $stateParams.id, null, function (result) {
                $scope.post = result.data;
                console.log($scope.post);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function decodeHtml(text) {
            var txt = document.createElement("textarea");
            txt.innerHTML = text;
            return txt.value;
        }
        $scope.EditPost = EditPost;
        function EditPost() {
            $scope.post.Content = decodeHtml($scope.post.Content);
            apiService.put('api/post/update', $scope.post,
                function (result) {
                    notificationService.displaySuccess("Cập Nhập Thành Công");
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
        LoadPostDetail();
        loadPostCategory();
    }


})(angular.module('myApp'));