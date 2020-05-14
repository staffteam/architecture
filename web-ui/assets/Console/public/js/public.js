var form = layui.form,
    layer = layui.layer,
    layedit = layui.layedit,
    laydate = layui.laydate,
    table = layui.table;

function $msg(o) {
    if (o.icon == 0) {
        layer.msg('<i class="layui-icon layui-icon-tips" ></i>' + o.content, {
            time: o.time || 2000,
            tipsMore: true,
            skin: 'layer-ext-tips'
        });
    } else if (o.icon == 1) {
        layer.msg('<i class="layui-icon layui-icon-ok-circle" ></i>' + o.content, {
            time: o.time || 2000,
            tipsMore: true,
            skin: 'layer-ext-success'
        });
    } else if (o.icon == 2) {
        layer.msg('<i class="layui-icon layui-icon-tips" ></i>' + o.content, {
            time: o.time || 2000,
            tipsMore: true,
            skin: 'layer-ext-error'
        });
    }
}

function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == variable) {
            return pair[1];
        }
    }
    return (false);
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
var isBank = /([\d]{4})([\d]{4})([\d]{4})([\d]{4})([\d]{0,})?/;
var isId = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
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
                                        if (_tips.indexOf('请再次') >= 0) {
                                            $msg({
                                                content: _tips,
                                                icon: 2
                                            });
                                        } else {
                                            $msg({
                                                content: '请输入' + _tips,
                                                icon: 2
                                            });
                                        }
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
                            case 'id':
                                the.$fn[_key].id = function (value) {
                                    if (value != '' && !isId.test(value)) {
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
                            case 'password':
                                the.$fn[_key].id = function (value) {
                                    if (value.length < 6 || value.length > 12) {
                                        $msg({
                                            content: _tips + '长度需大于6并小于12个字符',
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
                            case 'bank':
                                the.$fn[_key].bank = function (value) {
                                    if (value != '' && !isBank.test(value)) {
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
                                    case 'id':
                                        if (value != '' && isId.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'password':
                                        if (value.length >= 6 && value.length <= 12) {
                                            _is_ = true;
                                            return false;
                                        }
                                        break;
                                    case 'phone':
                                        if (value != '' && isPhone.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'bank':
                                        if (value != '' && isBank.test(value)) {
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
                the.$fn[_key] = {};
                _list.forEach(function (value, index) {
                    if (value.indexOf('||') == -1) {
                        switch (value) {
                            case 'required':
                                the.$fn[_key].required = function (value, $this) {
                                    if (value == "") {
                                        if (_tips.indexOf('请再次') >= 0) {
                                            the.tips($this, _tips);
                                        } else {
                                            the.tips($this, ($($this).hasClass('upcode') ? '请上传' : $($this).hasClass('selects') ? '请选择' : '请输入') + _tips);
                                        }

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

                            case 'id':
                                the.$fn[_key].id = function (value, $this) {
                                    if (value != '' && !isId.test(value)) {
                                        the.tips($this, _tips + '格式错误');
                                        return false;
                                    } else {
                                        return true;
                                    }
                                };
                                break;
                            case 'password':
                                the.$fn[_key].id = function (value, $this) {
                                    if (value.length < 6 || value.length > 12) {
                                        the.tips($this, _tips + '长度需大于6并小于12个字符');
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
                            case 'bank':
                                the.$fn[_key].bank = function (value, $this) {
                                    if (value != '' && !isBank.test(value)) {
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
                                    case 'id':
                                        if (value != '' && isId.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'password':
                                        if (value.length >= 6 && value.length <= 12) {
                                            _is_ = true;
                                            return false;
                                        }
                                        break;
                                    case 'phone':
                                        if (value != '' && isPhone.test(value)) {
                                            _is_ = true;
                                        }
                                        break;
                                    case 'bank':
                                        if (value != '' && isBank.test(value)) {
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
            } else {
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
};


// 上传文件
var upWin = {
    layero: {},
    progresss: {},
    i: 0,
    layerObj: 0,
    init: function (success) {
        var _this = this;
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
    start: function (name, index) {
        var _this = this;
        _this.i++;
        $(_this.layero).find('.list').append(
            '<div class="list-progress"><div class="label">' + name +
            '</div><div class="layui-progress layui-progress-big" lay-filter="winprogress' +
            _this.i + '" lay-showPercent="true">' +
            '<div class="layui-progress-bar" lay-percent="0%"></div>' +
            '</div></div>');
        _this.progresss[index || name] = {
            name: 'winprogress' + _this.i,
            index: _this.i
        };
        element.init();
    },
    percent: function (name, progress) {
        var _this = this;
        setTimeout(function () {
            element.progress(_this.progresss[name].name, progress + '%');
            setTimeout(function () {
                if (progress == 100 && _this.progresss[name].index == _this.i) {
                    layer.close(_this.layerObj);
                    _this.layerObj = 0;
                }
            }, 300)
        }, 300)
    },
    close: function () {
        var _this = this;
        layer.close(_this.layerObj);
    }
};


//判断浏览器版本
function IEVersion() {
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串  
    var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1; //判断是否IE<11浏览器  
    var isEdge = userAgent.indexOf("Edge") > -1 && !isIE; //判断是否IE的Edge浏览器  
    var isIE11 = userAgent.indexOf('Trident') > -1 && userAgent.indexOf("rv:11.0") > -1;
    if (isIE) {
        var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        var fIEVersion = parseFloat(RegExp["$1"]);
        if (fIEVersion == 7) {
            return 7;
        } else if (fIEVersion == 8) {
            return 8;
        } else if (fIEVersion == 9) {
            return 9;
        } else if (fIEVersion == 10) {
            return 10;
        } else {
            return 6; //IE版本<=7
        }
    } else if (isEdge) {
        return 'edge'; //edge
    } else if (isIE11) {
        return 11; //IE11  
    } else {
        return -1; //不是ie浏览器
    }
}

$(function () {
    var bb = IEVersion();
    if (bb <= 9 && bb != -1) {
        $('#iegruntbox').show();
    }
})

function inputList(input, list) {
    var mailBox = [
        "@qq.com",
        "@sina.com",
        "@163.com",
        "@126.com",
        "@yahoo.com.cn",
        "@gmail.com",
        "@sohu.com"
    ];
    input.bind('input propertychange', function () {
        var key = input.val();
        if (key.indexOf("@") != -1) {
            key = key.slice(0, key.indexOf("@"));
        }
        var mailBoxLen = mailBox.length;
        var html = "";
        for (var i = 0; i < mailBoxLen; i++) {
            html += '<option value="' + key + mailBox[i] + '"></option>';
        }
        list.html(html);
    });
}