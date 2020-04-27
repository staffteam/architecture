form.on('submit(login)', function (data) {
    if (verify.find('login')) {
        layer.alert(JSON.stringify(data.field), {
            title: '最终的提交信息'
        });
        return false;
    }
});
form.on('submit(register)', function (data) {
    if (!$('#registerBtn').hasClass('off') && verify.find('register')) {
        if ($('#register input[name="verifycode"]').val() != '123456') {
            $msg({
                content: '验证码错误',
                icon: 2
            });
        } else if ($('#register input[name="second"]').val() != $('#register input[name="password"]').val()) {
            $msg({
                content: '两次密码不一致',
                icon: 2
            });
        } else {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            });
        }
        return false;
    }
});
form.on('submit(find)', function (data) {
    if (verify.find('find')) {
        if ($('#find input[name="verifycode"]').val() != '123456') {
            $msg({
                content: '验证码错误',
                icon: 2
            });
        } else if ($('#find input[name="second"]').val() != $('#find input[name="password"]').val()) {
            $msg({
                content: '两次密码不一致',
                icon: 2
            });
        } else {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            });
        }
        return false;
    }
});
if (location.hash == '#login') {
    $('#register').hide();
    $('#login').show();
} else if (location.hash == '#register') {
    $('#register').show();
    $('#login').hide();
} else {
    $('#register').hide();
    $('#login').show();
}

$(function () {
    $('.goRegister').click(function () {
        $('#register').show();
        $('#login').hide();
        $('#find').hide();
    });
    $('.goLogin').click(function () {
        $('#register').hide();
        $('#login').show();
        $('#find').hide();
    });
    $('.retrieve').click(function () {
        $('#find').show();
        $('#register').hide();
        $('#login').hide();
    });
    $('#agreement').click(function () {
        layer.open({
            title: "《用户协议》",
            area: ['800px', '600px'],
            content: $('#agreementContent').html(),
        })
        event.stopPropagation(); //  阻止事件冒泡
    });
    $('#register').on('click', '.layui-form-checkbox[lay-skin=primary]', function () {
        $('#agreement').html('《用户协议》');
        $('#policy').html('《隐私政策》');
        if ($('input[name="consent"]').is(':checked')) {
            $('#registerBtn').removeClass('off');
        } else {
            $('#registerBtn').addClass('off');
        }
    })
    $('#policy').click(function () {
        layer.open({
            title: "《隐私政策》",
            area: ['800px', '600px'],
            content: $('#policyContent').html(),
        })
        event.stopPropagation(); //  阻止事件冒泡
    });


    // 验证码
    $('input[name="verifycode"]').on('input', function () {
        var _val = $(this).val();
        if (_val.length > 6) {
            _val = _val.substring(0, _val.length - 1);
        }
        if (!/^([0-9])*$/.test($(this).val())) {
            _val = $(this).val().replace(/[a-zA-z]/g, '');
            $(this).val(_val);
        } else {
            $(this).val(_val);
        }
    });

    $('.get-code').click(function () {
        var _val = $(this).closest('.fill-out').find('input[name="phoneoremail"]').val();
        if (_val != '' && isPhone.test(_val)) {
            if (!$(this).hasClass('on')) {
                $(this).addClass('on');
                $(this).html('60s后重新获取');
                var the = this;
                var i = 60;
                var _time = setInterval(function () {
                    i--;
                    if (i == 0) {
                        $(the).html('重新获取验证码');
                        $(the).removeClass('on');
                        clearInterval(_time);
                    } else {
                        $(the).html(i + 's后重新获取');
                    }
                }, 1000)
            }
        } else if (_val == '') {
            $msg({
                content: '请输入手机或邮箱',
                icon: 2
            });
        } else if (isPhone.test(_val)) {
            $msg({
                content: '请输入有效的手机或邮箱',
                icon: 2
            });
        }
    });
    var form = layui.form;
    form.render();
})