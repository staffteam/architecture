Auth.init({
    login_url: '#login',
    forgot_url: '#forgot'
});
$(function () {
    var form = layui.form;
    form.render();
    $('#agreement').click(function () {
        layer.open({
            title: "《用户协议》",
            area: ['800px', '600px'],
            content: $('#agreementContent').html(),
        })
        event.stopPropagation(); //  阻止事件冒泡
    });
    $('.lowin-register').on('click', '.layui-form-checkbox[lay-skin=primary]', function () {
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
})

function getCode(obj) {
    var formObj = $(obj).closest('.lowin-box-inner');
    var phone = formObj.find('input[name="phone"]');
    if (phone != '' && (isPhone.test(phone.val()) || isEmail.test(phone.val()))) {
        if (!$(obj).hasClass('on')) {
            $(obj).addClass('on');
            $(obj).html('60s后重新获取');
            var the = obj;
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
    } else if (phone == '') {
        phone.next().html('请输入手机号或邮箱');
    } else if (!isPhone.test(phone.val()) && !isEmail.test(phone.val())) {
        phone.next().html('请输入有效的手机号或邮箱');
    }
};

function goLogin() {
    $('.lowin-box').removeClass('lowin-flip');
    $('.lowin-box').not('.lowin-login').addClass('lowin-flip');
    $('.lowin').addClass('on');
    $('.lowin-login input[name="phone"]').val($('input[name="phoneEndEmail"]').val());
}

function goRegister() {
    $('.lowin-box').removeClass('lowin-flip');
    $('.lowin-box').not('.lowin-register').addClass('lowin-flip');
    $('.lowin').addClass('on');
    $('.lowin-register input[name="phone"]').val($('input[name="phoneEndEmail"]').val());
}

function phoneBlur(name) {
    var formObj = $('.lowin-' + name);
    var phone = formObj.find('input[name="phone"]');
    if (phone.val() == '') {
        phone.next().html('请输入手机号或邮箱');
    } else if (!isPhone.test(phone.val()) && !isEmail.test(phone.val())) {
        phone.next().html('请输入有效的手机号或邮箱');
    } else {
        phone.next().html('');
    }
}

function phoneCode(name) {
    var formObj = $('.lowin-' + name);
    var code = formObj.find('input[name="code"]');
    if (code.val() == '') {
        code.next().html('请输入验证码');
    } else {
        code.next().html('');
    }
}

function key1Blur(name) {
    var formObj = $('.lowin-' + name);
    var key1 = formObj.find('input[name="key1"]');
    if (key1.val() == '') {
        key1.next().html('请输入密码');
    } else {
        key1.next().html('');
    }
}

function key2Blur(name) {
    var formObj = $('.lowin-' + name);
    var key1 = formObj.find('input[name="key1"]');
    var key2 = formObj.find('input[name="key2"]');
    if (key1.val() != key2.val()) {
        key1.next().html('')
        key2.next().html('两次密码不一致')
    } else {
        key2.next().html('');
    }
}

function login(name) {
    var formObj = $('.lowin-' + name);
    var phone = formObj.find('input[name="phone"]');
    var key1 = formObj.find('input[name="key1"]');
    if (phone.val() == '') {
        phone.next().html('请输入手机号或邮箱');
    } else if (!isPhone.test(phone.val()) && !isEmail.test(phone.val())) {
        phone.next().html('请输入有效的手机号或邮箱');
    } else if (key1.val() == '') {
        phone.next().html('');
        key1.next().html('请输入密码')
    } else {
        alert('ok');
    }
}

function register(name) {
    var formObj = $('.lowin-' + name);
    var phone = formObj.find('input[name="phone"]');
    var key1 = formObj.find('input[name="key1"]');
    var key2 = formObj.find('input[name="key2"]');
    if (phone.val() == '') {
        phone.next().html('请输入手机号或邮箱');
    } else if (!isPhone.test(phone.val()) && !isEmail.test(phone.val())) {
        phone.next().html('请输入有效的手机号或邮箱');
    } else if (key1.val() == '') {
        phone.next().html('');
        key1.next().html('请输入密码')
    } else if (key1.val() != key2.val()) {
        key1.next().html('')
        key2.next().html('两次密码不一致')
    } else {
        key2.next().html('');
        alert('ok');
    }
}

function forget(name) {
    var formObj = $('.lowin-' + name);
    var phone = formObj.find('input[name="phone"]');
    var code = formObj.find('input[name="code"]');
    var key1 = formObj.find('input[name="key1"]');
    var key2 = formObj.find('input[name="key2"]');
    if (phone.val() == '') {
        phone.next().html('请输入手机号或邮箱');
    } else if (!isPhone.test(phone.val()) && !isEmail.test(phone.val())) {
        phone.next().html('请输入有效的手机号或邮箱');
    } else if (code.val() == '') {
        phone.next().html('');
        code.next().html('请输入验证码')
    } else if (key1.val() == '') {
        code.next().html('');
        key1.next().html('请输入新密码')
    } else if (key1.val() != key2.val()) {
        key1.next().html('')
        key2.next().html('两次密码不一致')
    } else {
        key2.next().html('');
        alert('ok');
    }
}

function closeLogin() {
    $('.lowin').removeClass('on');
}