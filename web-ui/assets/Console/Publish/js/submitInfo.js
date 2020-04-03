$(function(){
    createCode(4);
    Provinces({
        elem: "provinces",
        label: "现居住地址",
        required: true,
        call: function () {
            verify.upgradesInit();
        }
    });
})
$('#getCode').click(function () {
    $('#identityApply input[name="phone"]').blur();
    if ($('.item-phone .verify-tips').length == 0) {
        $(this).html('60s后重新获取');
        var _this = this;
        var _i = 60;
        var _set = setInterval(function () {
            if (_i == 1) {
                clearInterval(_set);
                $(_this).html('重新获取验证码');
            } else {
                _i--;
                $(_this).html(_i + 's后重新获取');
            }
        }, 1000)

    }
})
//提交方法
function submitInfo(){
    $('#identityApply input').blur();
    if($('#identityApply .verify-tips').length==0){
        location.href = location.protocol + '//' + location.host + '/PublishProject/SubmitInfoUp'
    }
}

//生成验证码的方法
function createCode(length) {
    var code = "";
    var codeLength = parseInt(length); //验证码的长度
    var checkCode = document.getElementById("checkCode");
    ////所有候选组成验证码的字符，当然也可以用中文的
    var codeChars = new Array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
    'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'); 
    //循环组成验证码的字符串
    for (var i = 0; i < codeLength; i++)
    {
        //获取随机验证码下标
        var charNum = Math.floor(Math.random() * 62);
        //组合成指定字符验证码
        code += codeChars[charNum];
    }
    if (checkCode)
    {
        //为验证码区域添加样式名
        checkCode.className = "code";
        //将生成验证码赋值到显示区
        checkCode.innerHTML = code;
    }
}

//检查验证码是否正确
function validateCode(obj)
{
    //获取显示区生成的验证码
    var checkCode = document.getElementById("checkCode").innerHTML;
    //获取输入的验证码
    var inputCode = document.getElementById("inputCode").value;
    console.log(checkCode);
    console.log(inputCode);
    if (inputCode.length <= 0)
    {
        if($(obj).parent().find('.verify-tips').length>0){
            $(obj).parent().find('.verify-tips').html('请输入请输入验证码').show();
        }else{
            $(obj).parent().append('<p class="verify-tips">请输入请输入验证码</p>');
        }
    }
    else if (inputCode.toUpperCase() != checkCode.toUpperCase())
    {
        if($(obj).parent().find('.verify-tips').length>0){
            $(obj).parent().find('.verify-tips').html('验证码输入有误').show();
        }else{
            $(obj).parent().append('<p class="verify-tips">验证码输入有误</p>');
        }
        createCode(4);
    }
    else
    {
        $(obj).parent().find('.verify-tips').remove();
    }       
}    