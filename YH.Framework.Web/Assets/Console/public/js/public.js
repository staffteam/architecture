var form = layui.form,
    layer = layui.layer,
    layedit = layui.layedit,
    laydate = layui.laydate,
    table = layui.table;

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

$(window).load(function () {
    // $("#content").mCustomScrollbar({
    //     scrollInertia:150,
    //     axis: "yx"
    // });
});

$(function () {
    var _list = null;
    var _layer = null;
    $('.layadmin-flexible').click(function () {
        if ($('.main').hasClass('side-shrink')) {
            $(this).find('.layui-icon-spread-left').addClass('layui-icon-shrink-right').removeClass('layui-icon-spread-left');
            $('.main').removeClass('side-shrink');
            $('.layui-nav-item.cache').addClass('layui-nav-itemed').removeClass('cache');
            $('.layui-side-scroll .layui-nav-item').removeClass('hovers')
        } else {
            $(this).find('.layui-icon-shrink-right').addClass('layui-icon-spread-left').removeClass('layui-icon-shrink-right');
            $('.main').addClass('side-shrink');
            $('.layui-nav-item.layui-nav-itemed').addClass('cache').removeClass('layui-nav-itemed');
            $('.layui-side-scroll .layui-nav-item').addClass('hovers');
        }
    });
    $('.layui-side-scroll .layui-nav-item a').hover(function () {
        if ($(this).parent().hasClass('hovers')) {
            _layer = layer.tips($(this)[0].getAttribute('lay-tips'), this);
        }
    }, function () {
        if ($(this).parent().hasClass('hovers')) {
            layui.layer.close(_layer);
        }
    })
    $('.layui-side-scroll .layui-nav-item a').on('click', function () {
        if ($('.main').hasClass('side-shrink')) {
            $('.layadmin-flexible').click();
            layui.layer.close(_layer);
        }
    })
});


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
            if (_verify != "") {
                var _list = _verify.split('&&');
                _list.forEach(function (value, index) {
                    if (value.indexOf('||') == -1) {
                        switch (value) {
                            case 'required':
                                the.$fn[_key].required = function (value,$this) {
                                    if (value == "") {
                                        the.tips($this, ($($this).hasClass('upcode')?'请上传':$($this).hasClass('selects')?'请选择':'请输入') + _tips);
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'email':
                                the.$fn[_key].email = function (value,$this) {
                                    if (value != '' && !isEmail.test(value)) {
                                        the.tips($this, _tips + '格式错误');
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'phone':
                                the.$fn[_key].phone = function (value,$this) {
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
                        the.$fn[_key].or = function (value,$this) {
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
                    var _is_ = true;
                    var _this = this;
                    var _index = +$(this)[0].getAttribute('data-index');
                    $.each(the.$fn[_index], function (name) {
                        if (_is_ && name != "orList" && !the.$fn[_index][name]($(_this).val(),_this)) {
                            _is_ = false;
                        }
                    });
                    if (!_is_) {
                        $(this).addClass('layui-form-danger');
                    } else {
                        $(this).removeClass('layui-form-danger');
                        $(this).parent().find('.verify-tips').remove();
                    }
                })
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
                    if (_is_ && name != "orList" && !the.$fn[_index][name]($(_this).val(),_this)) {
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
        $(o).parent().find('.verify-tips').length==0?$(o).after("<p class='verify-tips' >" + v + "</p>"):$(o).parent().find('.verify-tips').html(v);
    }
}