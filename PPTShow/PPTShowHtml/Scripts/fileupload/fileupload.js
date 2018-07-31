$(function () {
    $('#fileUpload').on('change', function (obj) {
        var files = obj.target.files || obj.dataTransfer.files;//js获取所有文件  
        if (imgFilter(files) == false) {
            return flase;
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
                html += '<img src=' + objUrl + ' alt="图册" data-flag="new"  data-img=' + item + '/>';
                html += '</div>';
                html += '</div>';
                $('.atlas-container').append(html);                     // 将缩略图片写入
            } 
        })
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