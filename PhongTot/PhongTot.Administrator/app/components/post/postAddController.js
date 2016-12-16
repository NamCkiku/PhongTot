(function (app) {
    app.controller('postAddController', postAddController);

    postAddController.$inject = ['apiService', '$scope', 'notificationService', 'commonService', '$state', 'fileUploadService'];

    function postAddController(apiService, $scope, notificationService, commonService, $state, fileUploadService) {
        $scope.postCategories = [];
        $scope.post = {
            Status: true,
            HotFlag: false,
            CreateDate: new Date(),
            Image: "adadsadasd",
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
        var infoImage = null;
        $scope.prepareFiles = prepareFiles;
        function prepareFiles($files) {
            infoImage = $files;
        }
        function decodeHtml(text) {
            var txt = document.createElement("textarea");
            txt.innerHTML = text;
            return txt.value;
        }
        $scope.AddPost = AddPost;
        function AddPost() {
            apiService.ValidatorForm("#frmAddPost");
            var frmAddPost = angular.element(document.querySelector('#frmAddPost'));
            var formValidation = frmAddPost.data('formValidation').validate();
            if (formValidation.isValid()) {
                $scope.post.Content = decodeHtml($scope.post.Content);
                apiService.post('api/post/add', $scope.post,
                    function (result) {
                        $scope.post = result.data;
                        if (infoImage) {
                            fileUploadService.uploadImage(infoImage, $scope.post.ID);
                        }
                        notificationService.displaySuccess(result.data.Name + 'đã được thêm mới.');
                        $state.go('post');
                    }, function (error) {
                        notificationService.displayError('Thêm mới không thành công.');

                    });
            }
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