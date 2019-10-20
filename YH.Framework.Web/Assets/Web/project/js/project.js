$(function(){
    $('.sx-list .list p span').click(function(){
        $(this).parent().find('span').removeClass('on');
        $(this).addClass('on');
    })
    $('.sx-tab span').click(function(){
        $(this).addClass('on').siblings().removeClass('on');
    })
})

function sc(obj){
    if($(obj).hasClass('on')){
        $(obj).removeClass('on');
    }else{
        $(obj).addClass('on');
    }
}