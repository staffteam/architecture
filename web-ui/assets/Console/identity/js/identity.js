$(function () {
    verify.upgradesInit();
    var upload = layui.upload;
    //普通图片上传
    var uploadInst = upload.render({
        elem: '#test1',
        url: '/upload/',
        before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {
                $('#demo1').attr('src', result); //图片链接（base64）
            });
        },
        done: function (res) {
            //如果上传失败
            if (res.code > 0) {
                return $msg({
                    content: '上传失败',
                    icon: 0
                });
            }
            //上传成功
        },
        error: function () {
            //演示失败状态，并实现重传
            var demoText = $('#demoText');
            demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-xs demo-reload">重试</a>');
            demoText.find('.demo-reload').on('click', function () {
                uploadInst.upload();
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