$(function () {
    //普通图片上传
    upcertify({
        elem: '#identityImg',
        percent: 'identityImgProgress',
        codeElem: 'identityImgCode',
    });
    upcertify({
        elem: '#certify',
        percent: 'certifyProgress',
        codeElem: 'certifyCode',
    });
    form.on('submit(identityApply)', function (data) {
        if (verify.finds('identityApply')) {
            layer.alert(JSON.stringify(data.field), {
                title: '最终的提交信息'
            });
            return false;
        }
    });
    form.on("radio(status)", function (data) {
        var status = data.value
        if (status == 1) {
            $('.work-form').find('input').each(function () {
                this.setAttribute("verifys", '');
            })
        } else {
            $('.work-form').find('input').each(function () {
                this.setAttribute("verifys", 'required');
            })
        }
        verify.upgradesInit();
    });
    Provinces({
        elem: "provinces",
        label: "现居住地址",
        required: true,
        call: function () {
            verify.upgradesInit();
        }
    });
    var _i = 0;
    $('#addCertify').click(function () {
        _i++;
        var html = '<div class="layui-form-item">' +
            ' <div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">证书名称</label>' +
            '<div class="layui-input-inline">' +
            '<input type="text" name="phone" tips="证书名称" placeholder="证书名称" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style = "vertical-align: top;" > ' +
            '<div class="layui-form-item" > ' +
            '<label class="layui-form-label" > 证书照片</label > ' +
            '<div class="layui-input-inline" style = "width: auto;" > ' +
            '<div class="updata" id = "certify' + _i + '" > ' +
            '<i class="layui-icon layui-icon-add-1" ></i > ' +
            '<span > 点击上传</span > ' +
            '<p class="img" > <img src="" /></p > ' +
            '<p class="done" > <i class="layui-icon layui-icon-ok-circle"></i><span>上传成功</span></p > ' +
            '<div class="layui-progress" ay - showpercent="true" lay-filter="certifyProgress' + _i + '" > ' +
            '<div class="layui-progress-bar" lay - percent="0%" ></div > ' +
            '</div> ' +
            '</div> ' +
            '<input type="hidden" name="certifyCode' + _i + '" value="111" class="upcode" tips="身份证件照">' +
            '</div>' +
            '</div> ' +
            '</div> ' +
            '<div class="layui-inline">' +
            '<span class="delCertify" ><i class="layui-icon layui-icon-close"></i>删除</span>' +
            '</div>' +
            '</div> ';
        $(this).closest('.layui-form-item').after(html);
        upcertify({
            elem: '#certify' + _i,
            percent: 'certifyProgress' + _i,
            codeElem: 'certifyCode' + _i,
        });
    });
    $('#addEducation').click(function () {
        _i++;
        var html = '<div class="layui-form-item">' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">开始时间</label>' +
            '<div class="layui-input-inline" style="width:10vw;">' +
            '<input type="text" name="phone" required  tips="开始时间"' +
            'placeholder="开始时间" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">结束时间</label>' +
            '<div class="layui-input-inline" style="width:10vw;">' +
            '<input type="text" name="phone" required  tips="结束时间"' +
            'placeholder="结束时间" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">学校名称</label>' +
            '<div class="layui-input-inline" style="width:12vw;">' +
            '<input type="text" name="phone" required  tips="学校名称"' +
            'placeholder="学校名称" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">专业名称</label>' +
            '<div class="layui-input-inline" style="width:12vw;">' +
            '<input type="text" name="phone" required  tips="专业名称"' +
            'placeholder="专业名称" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline">' +
            '<span class="delCertify" ><i class="layui-icon layui-icon-close"></i>删除</span>' +
            '</div>' +
            '</div> ';
        $(this).closest('.layui-form-item').after(html);
    });
    $('#addWork').click(function () {
        _i++;
        var html = '<div class="layui-form-item work-form">' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">开始时间</label>' +
            '<div class="layui-input-inline" style="width:10vw;">' +
            '<input type="text" name="starttime" required  tips="开始时间" placeholder="开始时间" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">结束时间</label>' +
            '<div class="layui-input-inline" style="width:10vw;">' +
            '<input type="text" name="endtime" required  tips="结束时间" placeholder="结束时间" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">公司名称</label>' +
            '<div class="layui-input-inline" style="width:12vw;">' +
            '<input type="text" name="zsmc" required  tips="公司名称" placeholder="公司名称" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline" style="vertical-align: top;">' +
            '<label class="layui-form-label">岗位名称</label>' +
            '<div class="layui-input-inline" style="width:12vw;">' +
            '<input type="text" name="gwmc" required  tips="岗位名称" placeholder="岗位名称" autocomplete="off" class="layui-input">' +
            '</div>' +
            '</div> ' +
            '<div class="layui-inline">' +
            '<span class="delCertify" ><i class="layui-icon layui-icon-close"></i>删除</span>' +
            '</div>' +
            '</div>';
        $(this).closest('.layui-form-item').after(html);
    })

    $('body').on('click', '.delCertify', function () {
        $(this).closest('.layui-form-item').remove();
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
                $(init.elem).find('p.img').show().find('img').attr('src', result);
            });
        },
        progress: function (e, percent) {
            $(init.elem).find('.layui-progress').show();
            element.progress(init.percent, percent + '%')
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
            $('input[name="' + init.codeElem + '"]').val(res.data);
            //上传成功
            $(init.elem).find('p.done').show().find('span').html('上传成功');
            $(init.elem).find('p.done').find('i').show();
            setTimeout(function () {
                $(init.elem).find('p.done').hide();
            }, 500)
        },
        error: function (err) {
            $(init.elem).find('p.done').show().find('span').html('重新上传');
            $(init.elem).find('p.done').find('i').hide();
            $msg({
                content: '上传失败',
                icon: 0
            });
        }
    });
}