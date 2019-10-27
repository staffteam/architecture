var loginO,forgetPwO;
function onLogin(obj){
    var _val =  $(obj).parent().find('input').val();
    loginO=layui.layer.open({
        title:false,
        btn:false,
        area:['450px','535px'],
        content:$('#loginTemplate').html(),
        success:function(obj,index){
            obj.find('input[name="account"]').val(_val);
            var form = layui.form;
            form.render();
        }
    })
}
function forgetPw(){
    layui.layer.close(loginO);
}
$(function(){
    var element = layui.element;
})

