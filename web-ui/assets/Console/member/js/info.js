$(function () {
    if ($('#provinces').length > 0) {
        Provinces({
            elem: "provinces",
            label: "所在地区",
            required: true,
            call: function () {
                verify.upgradesInit();
            }
        });
    }
    if ($('#tops').length > 0) {
        var upload = layui.upload;
        //普通图片上传
        var uploadInst = upload.render({
            elem: '#tops',
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

    }

    form.render();

    $('#getCode').click(function () {
        $('#bankCard input[name="phone"]').blur();
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
    verify.upgradesInit();
});
//提交基本资料
function submitInfo() {
    $('#memberR input').blur();
    if ($('#memberR .verify-tips').length == 0) {
        location.href = '/Member/Info'
    }
}

//银行卡绑定
function submitBankCard() {
    $('#bankCard input').blur();
    if ($('#bankCard .verify-tips').length == 0) {
        location.href = '/Member/Info'
    }
}
//验证身份 --密码
function submitPassNext() {
    $('#editPass input').blur();
    if ($('#editPass .verify-tips').length == 0) {
        $('#editPass').hide();
        $('.identity-step li').eq(1).addClass('on');
        $('.tips').hide();
        $('#editPass2').show();
    }
}
//确认密码 --密码
function submitPassNext2(){
    $('#editPass2 input').blur();
    if ($('#editPass2 .verify-tips').length == 0) {
        $('#editPass2').hide();
        $('.identity-step li').eq(2).addClass('on');
        $('.edit-success,.tips-bottom').show();
    }
}