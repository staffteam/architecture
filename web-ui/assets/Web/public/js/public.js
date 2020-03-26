var form = layui.form,
    layer = layui.layer,
    layedit = layui.layedit,
    laydate = layui.laydate,
    table = layui.table;

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
})

function getCode(){
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
}

var loginO, forgetPwO, editPassO;

function onLogin(obj) {
    layer.close(forgetPwO);
    layer.close(editPassO);
    var _val = $(obj).parent().find('input').val();
    loginO = layer.open({
        title: false,
        btn: false,
        type:1,
        area: ['450px', '535px'],
        content: $('#loginTemplate').html(),
        success: function (obj, index) {
            obj.find('input[name="phoneoremail"]').val(_val);
            form.render();
            verify.init();
            
            setTimeout(function(){
                form.on('submit(login)', function (data) {
                    if (verify.find('login')) {
                        layer.alert(JSON.stringify(data.field), {
                            title: '最终的提交信息'
                        });
                        return false;
                    }
                });
            },300)
        }
    })
}

function forgetPw() {
    layer.close(loginO);
    layer.close(editPassO);
    forgetPwO = layer.open({
        title: false,
        btn: false,
        type:1,
        area: ['450px', '535px'],
        content: $('#editPassTemplate').html(),
        success: function (obj, index) {
            form.render();
            verify.init();
            getCode();
            setTimeout(function(){
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
            },300)
        }
    })
}

function register() {
    layer.close(loginO);
    layer.close(forgetPwO);
    editPassO = layer.open({
        title: false,
        btn: false,
        type:1,
        area: ['450px', '545px'],
        zIndex: layer.zIndex,
        content: $('#registerTemplate').html(),
        success: function (obj, index) {
            form.render();
            verify.init();
            getCode();
            setTimeout(function () {
                $('#agreement').click(function () {
                    layer.open({
                        title: "《用户协议》",
                        area: ['800px', '600px'],
                        type:1,
                        zIndex: layer.zIndex, //重点1
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
                        type:1,
                        title: "《隐私政策》",
                        area: ['800px', '600px'],
                        content: $('#policyContent').html(),
                        zIndex: layer.zIndex,
                    })
                    event.stopPropagation(); //  阻止事件冒泡
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
            }, 300)
        }
    })
}
$(function () {
    var element = layui.element;
})

function $msg(o) {
    if (o.icon == 0) {
        layer.msg('<i class="layui-icon layui-icon-tips" ></i>' + o.content, {
            time: o.time || 2000,
            skin: 'layer-ext-tips'
        });
    } else if (o.icon == 1) {
        layer.msg('<i class="layui-icon layui-icon-ok-circle" ></i>' + o.content, {
            time: o.time || 2000,
            skin: 'layer-ext-success'
        });
    } else if (o.icon == 2) {
        layer.msg('<i class="layui-icon layui-icon-tips" ></i>' + o.content, {
            time: o.time || 2000,
            skin: 'layer-ext-error'
        });
    }
}
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
    return (false);
}

// 表单验证
$(function () {
    verify.init();
});
var isPhone = /^1[3456789]\d{9}$/;
var isEmail = /^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;

var verify = {
    $fn: [],
    init: function () {
        var the = this;
        $('[verify]').each(function (_key) {
            the.$fn.push({});
            var _verify = $(this)[0].getAttribute('verify');
            var _tips = $(this)[0].getAttribute('tips');
            $(this)[0].setAttribute("data-index", _key);
            _tips = _tips == "" ? "该字段" : _tips;
            if (_verify != "") {
                var _list = _verify.split('&&');
                _list.forEach(function (value, index) {
                    if (value.indexOf('||') == -1) {
                        switch (value) {
                            case 'required':
                                the.$fn[_key].required = function (value) {
                                    if (value == "") {
                                        $msg({
                                            content: '请输入' + _tips,
                                            icon: 2
                                        });
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'email':
                                the.$fn[_key].email = function (value) {
                                    if (value != '' && !isEmail.test(value)) {
                                        $msg({
                                            content: _tips + '格式错误',
                                            icon: 2
                                        });
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'phone':
                                the.$fn[_key].phone = function (value) {
                                    if (value != '' && !isPhone.test(value)) {
                                        $msg({
                                            content: _tips + '格式错误',
                                            icon: 2
                                        });
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                        }
                    } else {
                        the.$fn[_key].orList = value.split('||');
                        the.$fn[_key].or = function (value) {
                            var _is_ = false;
                            this.orList.forEach(function (time, key) {
                                switch (time) {
                                    case 'email':
                                        if (value != '' && isEmail.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'phone':
                                        if (value != '' && isPhone.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                }
                            });
                            if (!_is_) {
                                $msg({
                                    content: _tips + '格式错误',
                                    icon: 2
                                });
                            }
                            return _is_;
                        };
                    }
                });
            }
        });
    },
    find: function (obj) {
        var the = this;
        var _if = true;
        $('#' + obj + ' [verify]').each(function (_key) {
            if (_if) {
                var _is_ = true;
                var _this = this;
                var _index = +$(this)[0].getAttribute('data-index');
                $.each(the.$fn[_index], function (name) {
                    if (_is_ && name != "orList" && !the.$fn[_index][name]($(_this).val())) {
                        _is_ = false;
                    }
                });
                if (!_is_) {
                    $(this).addClass('layui-form-danger').focus();
                    _if = false;
                } else {
                    $(this).removeClass('layui-form-danger');
                }
            }
        })
        return _if;
    },
    upgradesInit: function () {
        var the = this;
        $('[verifys]').each(function (_key) {
            the.$fn.push({});
            var _this = this;
            var _verify = $(this)[0].getAttribute('verifys');
            var _tips = $(this)[0].getAttribute('tips');
            $(this)[0].setAttribute("data-index", _key);
            _tips = _tips == "" ? "该字段" : _tips;
            if (_verify != "" && !$(this).hasClass('not-verifys')) {
                $(this).addClass('not-verifys');
                var _list = _verify.split('&&');
                _list.forEach(function (value, index) {
                    if (value.indexOf('||') == -1) {
                        switch (value) {
                            case 'required':
                                the.$fn[_key].required = function (value, $this) {
                                    if (value == "") {
                                        the.tips($this, ($($this).hasClass('upcode') ? '请上传' : $($this).hasClass('selects') ? '请选择' : '请输入') + _tips);
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'email':
                                the.$fn[_key].email = function (value, $this) {
                                    if (value != '' && !isEmail.test(value)) {
                                        the.tips($this, _tips + '格式错误');
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'phone':
                                the.$fn[_key].phone = function (value, $this) {
                                    if (value != '' && !isPhone.test(value)) {
                                        the.tips($this, _tips + '格式错误');
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                        }
                    } else {
                        the.$fn[_key].orList = value.split('||');
                        the.$fn[_key].or = function (value, $this) {
                            var _is_ = false;
                            this.orList.forEach(function (time, key) {
                                switch (time) {
                                    case 'email':
                                        if (value != '' && isEmail.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'phone':
                                        if (value != '' && isPhone.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                }
                            });
                            if (!_is_) {
                                the.tips($this, _tips + '格式错误');
                            }
                            return _is_;
                        };
                    }
                });
                $(_this).blur(function () {
                    var _verify = $(this)[0].getAttribute('verifys');
                    if (_verify != '') {
                        var _is_ = true;
                        var _this = this;
                        var _index = +$(this)[0].getAttribute('data-index');
                        $.each(the.$fn[_index], function (name) {
                            if (_is_ && name != "orList" && !the.$fn[_index][name]($(_this).val(), _this)) {
                                _is_ = false;
                            }
                        });
                        if (!_is_) {
                            $(this).addClass('layui-form-danger');
                        } else {
                            $(this).removeClass('layui-form-danger');
                            $(this).parent().find('.verify-tips').remove();
                        }
                    } else {
                        $(this).removeClass('layui-form-danger');
                        $(this).parent().find('.verify-tips').remove();
                    }
                })
            }else{
                $(_this).blur();
            }
        });
    },
    finds: function (obj) {
        var the = this;
        var _if = true;
        $('#' + obj + ' [verifys]').each(function (_key) {
            if (_if) {
                var _is_ = true;
                var _this = this;
                var _index = +$(this)[0].getAttribute('data-index');
                $.each(the.$fn[_index], function (name) {
                    if (_is_ && name != "orList" && !the.$fn[_index][name]($(_this).val(), _this)) {
                        _is_ = false;
                    }
                });
                if (!_is_) {
                    $(this).addClass('layui-form-danger').focus();
                    _if = false;
                } else {
                    $(this).removeClass('layui-form-danger');
                    $(this).parent().find('.verify-tips').remove();
                }
            }
        })
        return _if;
    },
    tips: function (o, v) {
        $(o).parent().find('.verify-tips').length == 0 ? $(o).after("<p class='verify-tips' >" + v + "</p>") : $(o).parent().find('.verify-tips').html(v);
    }
}

// 上传文件
var upWin = {
    layero: {},
    progresss: {},
    i: 0,
    layerObj: {},
    init: function (success) {
        let _this = this;
        _this.layerObj = layer.open({
            offset: 'rb',
            type: 1,
            area: ['400px', '200px'],
            shade: false,
            title: false, //不显示标题
            closeBtn: false,
            content: ' <div class="win-progress">' +
                '<div class="title">正在上传</div>' +
                '<div class="list">' +
                '</div>' +
                '</div>',
            success: function (layero, index) {
                _this.layero = layero;
                success ? success(layero, index) : null;
            }
        });
    },
    start: function (name) {
        let _this = this;
        _this.i++;
        $(_this.layero).find('.list').append(
            '<div class="list-progress"><div class="label">' + name +
            '</div><div class="layui-progress layui-progress-big" lay-filter="winprogress' +
            _this.i + '" lay-showPercent="true">' +
            '<div class="layui-progress-bar" lay-percent="0%"></div>' +
            '</div></div>');
        _this.progresss[name] = {name:'winprogress' + _this.i,index:_this.i};
        element.init();
    },
    percent: function (name, progress) {
        let _this = this;
        setTimeout(function () {
            element.progress(_this.progresss[name].name, progress + '%');
            setTimeout(function () {
                if (progress == 100 && _this.progresss[name].index==_this.i) {
                    layer.close(_this.layerObj);
                }
            }, 300)
        }, 300)
    }
}