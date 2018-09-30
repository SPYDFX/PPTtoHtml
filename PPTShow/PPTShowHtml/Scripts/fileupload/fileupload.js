$(function () {
    $('#fileUpload').on('change', function (obj) {
        var files = obj.target.files || obj.dataTransfer.files;//js获取所有文件  
        if (imgFilter(files) == false) {
            return ;
        }

        //判断上传的图片跟页面上的图片，如果已经上传了，不需要重新上传  
        var imgList = $("img[data-flag='new']");//获取所有的img  
        $.each(files, function (i, item) {
            var objUrl = getObjectURL(item);
            var a = true;
            if (imgList.length > 0) {
                $.each(imgList, function (j, val) {
                    var fileName = $(val).data("img").name;
                    var fileSize = $(val).data("img").size;
                    if (fileName == item.name && fileSize == item.size) {
                        a = false;
                    }
                });
            }
            if (a) {
                var html = '';                            // 缩略
                html += '<div class="atlas-content">';
                html += '<i class="js-del-img fm-icon ion-close-circled"></i>';
                html += '<div class="img-container" data-name="' + files[i].name + '">';
                html += "<img data-flag='new' src='" + objUrl + "' data-file='" + item + "' data-img='"+files[i]+"'>";
                html += '</div>';
                html += '</div>';
                $('.atlas-container').append(html);                     // 将缩略图片写入   
                //var img = $(".atlas-container>div>div").last().children("file");//获取新生成的img标签  
                //img.data("file", item);
            } 
        })
    });

    $("#btnUploadImg").click(function () {
        var imgList = $("img[data-flag='new']");
        if (imgList != null && imgList.length > 0) {
            UploadFile(imgList);
        }
    });
});
var imgFilter = function (files) {
    var a = true;
    //for (var i = 0, file; file = files[i]; i++) {
    //    if (file.type.indexOf("image") == 0) {
    //        if (file.size >= 512000) {
    //            alert('您这张"' + file.name + '"图片大小过大，应小于500k，请重新上传');
    //            a = false;
    //        }
    //    } else {
    //        alert('文件"' + file.name + '"不是图片。请重新上传');
    //        a = false;
    //    }
    //}
    return a;
};
var getObjectURL = function (file) {
    var url = null;
    if (window.createObjectURL != undefined) { // basic  
        url = window.createObjectURL(file);
    } else if (window.URL != undefined) { // mozilla(firefox)  
        url = window.URL.createObjectURL(file);
    } else if (window.webkitURL != undefined) { // webkit or chrome  
        url = window.webkitURL.createObjectURL(file);
    }
    return url;
};
var UploadFile = function (imgList) {
   // var formdata = null;
    
    //$.each(imgList, function (j, value) {//添加图片  
    //    //formdata.append("file", $(value).data("file"));
    //    formdata = new FormData($(value).data("file"))
    //});
    var formdata = new FormData($("#postForm")[0]);
    //formdata.append("Files",$("#postForm")[0]);  //$('#fileUpload')[0].files[0]
   // var formdata = new FormData($('#fileUpload')[0].files[0]);
    $.ajax({
        url: "/Home/UploadFile",
        type: "POST",
        cache: false,
        data: formdata,
        async: false,
        processData: false, // 关键点
        contentType: false, // 关键点
        success: function (result) {
            if (result.success) {
                //AddHouse(imgList);//图片上传成功后在提交数据
                //alert("操作成功" + result.data);
                //window.location.href = "/RentMG/HouseList";

                window.location.href = result.data;
            }
            else {
                alert(result.msg);
            }
            //var file = $("#fileUpload")
            //file.after(file.clone().val(""));
            //file.remove();
        }
    });
};
function btnPost() {
    // var formData = new FormData($("#postForm")[0]);
    //var formData = new FormData($('#file')[0].files[0]);
   
    $.ajax({
        url: "/Home/UploadFile",
        data: formData,
        type: "POST",
        async: false,
        contentType: false,
        processData: false,
        success: function (msg) {
        },
        error: function (e) {
        }
    });
}