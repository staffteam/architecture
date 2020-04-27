function qqCode() {
    layui.layer.open({
        title: 'qq沟通群二维码',
        content: '<img style="width:200px; margin:0 auto; display:block;" src="/Assets/Web/public/images/wechart.png" />'
    })
}

function weCode() {
    layui.layer.open({
        title: '微信沟通群二维码',
        content: '<img style="width:200px; margin:0 auto; display:block;" src="/Assets/Web/public/images/wechart.png" />'
    })
}
var qqe = ['微笑', '撇嘴', '色', '发呆', '得意', '哭', '害羞', '闭嘴', '睡', '尴尬', '怒', '调皮', '呲牙', '惊讶', '难过', '酷', '冷汗', '吐', '偷笑', '可爱', '白眼', '饿', '困', '惊恐', '汗', '憨笑', '大兵', '奋斗', '疑问', '嘘...', '晕', '抓狂', '衰', '骷髅', '敲打', '再见', '抠鼻', '鼓掌', '糗大了', '坏笑', '左哼哼', '右哼哼', '哈欠', '鄙视', '委屈', '快哭了', '阴险', '亲亲', '吓', '可怜', '菜刀', '西瓜', '啤酒', '篮球', '乒乓球', '咖啡', '饭', '猪', '玫瑰', '凋谢', '爱心', '心碎', '蛋糕', '闪电', '炸弹', '刀', '足球', '瓢虫', '便便', '月亮', '太阳', '礼物', '拥抱', '强', '弱', '握手', '抱拳', '勾引', '拳头', '差劲', '爱你', '不', '好'];

$(function () {
    $('.link-up-main .list .item .c .title i').hover(function () {
        $(this).append('<div class="del" onclick="del(this)" ><i class="iconfont" >&#xe601;</i> 删除</div>')
    }, function () {
        $(this).find('.del').remove();
    });
    var upload = layui.upload;
    //附件上传
    var uploadInst = upload.render({
        elem: '#linkUpFile',
        url: '/upload/',
        before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {

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
            $msg({
                content: '上传失败',
                icon: 0
            });
        }
    });

    //表情初始化
    qqe.forEach(function (value) {
        $('#qqe').append('<img title="[' + value + ']" src="/assets/Console/public/images/qqe/' + value + '.gif" />');
    })
    //表情点击事件
    $('#qqe img').click(function () {
        insertAtCaret($('#importsUp')[0], $(this).attr('title'));
        $('#qqe').hide();
    })
    //表情展开
    $('#face').hover(function () {
        $('#qqe').show()
    }, function () {
        $('#qqe').hide();
    })
    //项目成员树结构展开收缩
    $('.project-member ul li div.title').click(function(){
        if($(this).hasClass('on')){
            $(this).removeClass('on');
            $(this).parent().find('.list').hide();
        }else{
            $(this).addClass('on');
            $(this).parent().find('.list').show();
        }
    })
    //右侧项目组切换
    $('#pNav li').click(function(){
        $(this).addClass('on').siblings().removeClass('on');
    })
    //切换消息与文件
    $('.link-up-title ul li').click(function(){
        $(this).addClass('on').siblings().removeClass('on');
        $('div.link-up-content').hide();
        $('div.link-up-content').eq($(this).index('.link-up-title ul li')).show();
    })
})
//项目组数弹窗关闭
function projectMemberClose(){
    $('#projectMember').hide();
}
//项目组数弹窗开启
function projectMemberShow(){
    $('#projectMember').show();
}
//发送
function importsUp() {
    var val = $('#importsUp').val().replace(/\[/g, "<em>").replace(/\]/g, "</em>");
    $('body').append('<div stlyle="display:none;" id="importsUpVal" >' + val + '</div>');
    $('#importsUpVal em').each(function () {
        var _this = $(this),
            is = false;
        qqe.forEach(function (value) {
            if (_this.html() == value) {
                is = true;
            }
        })
        if (is) {
            _this.before("<img src='/Assets/Console/public/images/qqe/" + _this.html() + ".gif' />");
            _this.remove();
        } else {
            _this.before("[" + _this.html() + "]");
            _this.remove();
        }
    })
    var _html = $('#importsUpVal').html().replace(/<em>/g, "[").replace(/<\/em>/g, "]");
    $('.link-up-main .list').append('<div class="item">' +
        '<p><img src="/Assets/Web/public/images/top.png" /></p>' +
        '<div class="c">' +
        '<div class="title">' +
        '<span>admin</span>' +
        '<em>05:14</em>' +
        '<i class="iconfont">&#xe604;</i>' +
        '</div>' +
        '<div class="con">' +
        _html +
        '</div>' +
        '</div>' +
        '</div>');
    $('#importsUpVal').remove();
    $('.link-up-main .list .item .c .title i').hover(function () {
        $(this).append('<div class="del" onclick="del(this)" ><i class="iconfont" >&#xe601;</i> 删除</div>')
    }, function () {
        $(this).find('.del').remove();
    });
    $('#importsUp').val('');
}
//删除消息
function del(obj) {
    $(obj).closest('.item').remove();
}

function insertAtCaret(areaElement, textFeildValue) {
    var textObj = areaElement;

    // 兼容不支持 selectionStart 浏览器
    if (document.all && textObj.createTextRange && textObj.caretPos) {
        var caretPos = textObj.caretPos;
        caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == '' ?
            textFeildValue + '' : textFeildValue;
    } else if (textObj.setSelectionRange) {
        var rangeStart = textObj.selectionStart;
        var rangeEnd = textObj.selectionEnd;
        var tempStr1 = textObj.value.substring(0, rangeStart);
        var tempStr2 = textObj.value.substring(rangeEnd);
        textObj.value = tempStr1 + textFeildValue + tempStr2;
        textObj.focus();
        var len = textFeildValue.length;
        textObj.setSelectionRange(rangeStart + len, rangeStart + len); // 移动光标到添加内容之后
    } else {
        textObj.value += textFeildValue;
    }
    return true;
}
