$(function () {
    var state = getQueryVariable('state');
    if (state == 1) {
        //审核成功
        $('#auditTitle').html('审核成功');
        $('#auditSuccess').show();
        $('.audit-success').show();
    } else if (state == 0) {
        //正在审核中

    } else if(state == 2){
        //审核未通过
        $('#auditTitle').html('审核结果');
        $('#auditError').show();
        $('.audit-error').show();
        $('.identity-step').addClass('error');
    }
})