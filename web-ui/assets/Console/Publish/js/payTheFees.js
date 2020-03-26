$(function(){
    form.render();
    $('.pay-list p').click(function () {
        $(this).parent().find('.layui-unselect').click();
    })
})

function pay(id){
    $('.pay-step-one').hide();
    $('.pay-step-two').show();
}
function backOne(){
    $('.pay-step-one').show();
    $('.pay-step-two').hide();
}
function backTwo(){
    $('.pay-step-three').hide();
    $('.pay-step-two').show();
}

function payTwo(){
    $('.pay-step-three').show();
    $('.pay-step-two').hide();
}

function payThree(){
    $('.pay-step-four').show();
    $('.pay-step-three').hide();
}
function backThree(){
    $('.pay-step-four').hide();
    $('.pay-step-three').show();
}
function payAgreement(id){
    layui.layer.open({
        title:'协议',
        content:'这是协议',
        btn:['确定'],
        area:['400px','400px']
    })
}