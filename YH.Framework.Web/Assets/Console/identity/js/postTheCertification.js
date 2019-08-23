$(function () {
    var upload = layui.upload;
    
    //普通图片上传
    upcertify({
        elem:'#identityImg',
        percent:'identityImgProgress',
        codeElem:'identityImgCode',
    });
    upcertify({
        elem:'#certify',
        percent:'certifyProgress',
        codeElem:'certifyCode',
    });
    form.on('submit(identityApply)', function (data) {
        if (verify.finds('identityApply')) {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            });
            return false;
        }
    });
    
    Provinces({
        elem: "provinces",
        label: "现居住地址",
        required:true,
        call: function () {
            verify.upgradesInit();
        }
    });
})

//资历证书图片上传
function upcertify(init) {
    return layui.upload.render({
        elem: init.elem,
        url: 'http://127.0.0.1:8083/api/image',
        before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {
                $(init.elem).find('p.img').show().find('img').attr('src',result);
            });
        },
        progress: function(e , percent) {
            $(init.elem).find('.layui-progress').show();
            element.progress(init.percent, percent+'%')
        },
        done: function (res) {
            //如果上传失败
            $(init.elem).find('.layui-progress').hide();
            if (res.code > 0) {
                return $msg({
                    content: '上传失败',
                    icon: 0
                });
            }
            $('input[name="'+init.codeElem+'"]').val(res.data);
            //上传成功
            $(init.elem).find('p.done').show();
            setTimeout(function(){
                $(init.elem).find('p.done').hide();
            },500)
        },
        error: function (err) {
            $msg({
                content: '上传失败',
                icon: 0
            });
        }
    });
}