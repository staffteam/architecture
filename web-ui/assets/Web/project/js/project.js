$(function () {
    $('.sx-list .list p span').click(function () {
        $(this).parent().find('span').removeClass('on');
        $(this).addClass('on');
    })
    $('.sx-tab span').click(function () {
        $(this).addClass('on').siblings().removeClass('on');
    })
    layui.laypage.render({
        elem: 'pages',
        count: 50 //数据总数
    });
})

function sc(obj) {
    if ($(obj).hasClass('on')) {
        $(obj).removeClass('on');
    } else {
        $(obj).addClass('on');
    }
}