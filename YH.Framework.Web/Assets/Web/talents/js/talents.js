$(function () {
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