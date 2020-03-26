//项目负责人绑定
function fzrClick(obj) {
    if ($('input[name="fzrId"]').val() == '') {
        $msg({
            content: '请输入人员ID',
            icon: 0
        });
        return false;
    }
    if (!$(obj).hasClass('success')) {
        $(obj).html('绑定中').addClass('on');
        $('input[name="fzrId"]').attr('disabled', true);
        $(obj).closest('.layui-inline').find('.recruit-me').addClass('off');
        setTimeout(function () {
            $(obj).html('绑定成功').addClass('success').removeClass('on');
            $('#fzrList').show();
        }, 1000);
    }
}
//项目负责人绑定本人
function fzrMeClick(obj) {
    var _btn = $(obj).closest('.layui-inline').find('.recruit-btn');
    if (!$(obj).hasClass('off')) {
        $('input[name="fzrId"]').val('123123').attr('disabled', true);
        $(_btn).html('绑定成功').addClass('success');
        $(obj).addClass('off');
        $('#fzrList').show();
    }
}

//项目负责人解除绑定
function fzrRelieve(obj) {
    var _btn = $(obj).closest('.layui-form-item').find('.recruit-btn');
    var _me = $(obj).closest('.layui-form-item').find('.recruit-me');
    $('input[name="fzrId"]').val('').prop('disabled', false);
    $(_btn).html('立即绑定').removeClass('success');
    $(_me).removeClass('off');
    $('#fzrList').hide();
}

//审核人绑定
function shrClick(obj) {
    if ($('input[name="shrId"]').val() == '') {
        $msg({
            content: '请输入人员ID',
            icon: 0
        });
        return false;
    }
    if (!$(obj).hasClass('success')) {
        $(obj).html('绑定中').addClass('on');
        $('input[name="shrId"]').attr('disabled', true);
        $(obj).closest('.layui-inline').find('.recruit-me').addClass('off');
        setTimeout(function () {
            $(obj).html('绑定成功').addClass('success').removeClass('on');
            $('#shrList').show();
        }, 1000);
    }
}
//审核人绑定本人
function shrMeClick(obj) {
    var _btn = $(obj).closest('.layui-inline').find('.recruit-btn');
    if (!$(obj).hasClass('off')) {
        $('input[name="shrId"]').val('123123').attr('disabled', true);
        $(_btn).html('绑定成功').addClass('success');
        $(obj).addClass('off');
        $('#shrList').show();
    }
}

//审核人解除绑定
function shrRelieve(obj) {
    var _btn = $(obj).closest('.layui-form-item').find('.recruit-btn');
    var _me = $(obj).closest('.layui-form-item').find('.recruit-me');
    $('input[name="shrId"]').val('').prop('disabled', false);
    $(_btn).html('立即绑定').removeClass('success');
    $(_me).removeClass('off');
    $('#shrList').hide();
}



//发布招募
function zmClick(obj) {
    var _is = $('#fzrList').css('display') != 'none' && $('#shrList').css('display') != 'none';
    if (_is) {
        if (!$(obj).hasClass('success')) {
            $(obj).html('绑定中').addClass('on');
            setTimeout(function () {
                $(obj).html('招募成功').addClass('success').removeClass('on');
                $('#zmList').show();
                $('.zm-next').show();
            }, 1000);
        }
    } else {
        $msg({
            content: '请先绑定项目负责人及审核人',
            icon: 0
        });
    }
}
//发布招募解除绑定
function zmRelieve(obj) {
    var _btn = $(obj).closest('.layui-form-item').find('.recruit-btn');
    $(_btn).html('发布招募').removeClass('success');
    $('#zmList').hide();
    $('.zm-next').hide();
}

//招募后点击下一步
function recruitNext(obj) {
    $('.recruit-step-two').show();
    $('.recruit-step-one').hide();
}


//第四方主体确认
function recruitTwoAffirm(obj) {
    if (!$(obj).hasClass('btn-affirm')) {
        $(obj).closest('li').find('p').html('<i class="iconfont">&#xe60a;</i><span>项目细节已确定</span>');
        $(obj).html('已确认').addClass('btn-affirm');
        $(obj).closest('li').addClass('on');
    }
}

//确认通过，点击下一步
function recruitTwoNext(){
    if($('.recreit-two-list ul li').length == $('.recreit-two-list ul li.on').length){
        location.href="/PublishProject/ReleaseSuccess"
    }else{
        $msg({
            content: '待确认项目细节确认才可发布项目',
            icon: 0
        });
    }
}