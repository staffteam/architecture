var file_name = "",fileJson={};
$(function () {
    verify.upgradesInit();
    var upload = layui.upload;
    //普通图片上传
    //普通图片上传
    var uploadInst = upload.render({
        elem: '#upWord',
        url: 'http://localhost:8083/api/image',
        multiple: true,
        done: function (res, index, upload) {
            upWin.percent(index, 100);
            $('.file-list').prepend('<p id="img1"><img src="' + fileJson[index] + '"><span onclick="delImg(this)">删除</span></p>');
        },
        before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {
                fileJson[index] = result;
                if (upWin.layerObj) {
                    upWin.start(file.name,index);
                    
                } else {
                    upWin.init(function () {
                        upWin.start(file.name,index);
                    });
                }

            });
        },
        allDone: function (obj) { //当文件全部被提交后，才触发
            //如果上传失败
            $('input[name="license"]').val(obj.successfu);
            return $msg({
                content: '共上传' + obj.total + '个文件，成功' + obj.successful + '个，失败' + obj.aborted,
                icon: 1
            });
        },
        error: function () {
            $msg({
                content: '上传失败',
                icon: 0
            });
        }
    });
    form.on('submit(identityApply)', function (data) {
        if (verify.finds('identityApply')) {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            });
            return false;
        }
    });
})

function delImg(obj) {
    $(obj).parent().remove();
}

$('#getCode').click(function () {
    $('#identityApply input[name="phone"]').blur();
    if ($('.item-phone .verify-tips').length == 0) {
        $(this).html('60s后重新获取');
        var _this = this;
        var _i = 60;
        var _set = setInterval(function () {
            if (_i == 1) {
                clearInterval(_set);
                $(_this).html('重新获取验证码');
            } else {
                _i--;
                $(_this).html(_i + 's后重新获取');
            }
        }, 1000)

    }
})