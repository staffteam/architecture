var uploadListIns,loads;
$(function () {
    //拖拽上传
    uploadListIns = layui.upload.render({
        elem: '#updatas',
        url: 'http://127.0.0.1:8083/api/image',
        accept: 'file', //普通文件
        auto: false,
        multiple: true,
        bindAction: '#upAfter',
        choose: function (obj) {
            var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
            $('.updatalist .up').remove();
            //读取本地文件
            obj.preview(function (index, file, result) {
                var _is = true;
                $('.upload-list').each(function(){
                    if(file.name == $(this).find('h2').html()){
                        _is = false;
                    }
                })
                if(!_is){
                    delete files[index]; //删除对应的文件
                    $msg({
                        content: '请勿上传重复文件！',
                        icon: 2
                    });
                    return;
                }
                var _html = $(['<div id="upload-' + index + '" class="upload-list"><span class="upload-delete" ><i class="iconfont" >&#xe603;</i></span>', '<div><i class="iconfont" >&#xe616;</i></div>', '<h2>' + file.name + '</h2>', '<p>' + (file.size / 1014).toFixed(1) + 'kb</p>', '</div>'].join(''));
                //删除
                _html.find('.upload-delete').on('click', function () {
                    delete files[index]; //删除对应的文件
                    _html.remove();
                    uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                });
                $('.updatalist #updatas').before(_html);
            });
            $('.updatalist').append($('#updatas'));
        },
        before: function (obj) {
            loads = top.layui.layer.load(3, {
                shade: [0.1, '#000'] //0.1透明度的白色背景
            });
        },
        progress: function (e, percent) {
            debugger;
            // $(init.elem).find('.layui-progress').show();
            // element.progress(init.percent, percent + '%')
        },
        allDone: function (res) {
            //如果上传失败
            if (res.code > 0) {
                return $msg({
                    content: '上传失败',
                    icon: 0
                });
            }
            //上传成功
            $msg({
                content: '上传成功',
                icon: 1
            });
            setTimeout(function () {
                location.href = location.protocol + '//' + location.host + '/PublishProject/Audit?state=0'
            },1000)
            top.layui.layer.close(loads);
        },
        error: function (err) {
            debugger;
            $msg({
                content: '上传失败',
                icon: 0
            });
        }
    });
})

function upAfter() {
    if($('.updatalist .upload-list').length==0){
        return $msg({
            content: '请上传项目资料附件',
            icon: 0
        }); 
    }else{
        $('#upAfter').click();
    }
}

var _is = true;
layui.use('form', function () {
    var form = layui.form; //只有执行了这一步，部分表单元素才会自动修饰成功
    form.on('checkbox(upimgitem)', function (data) {
        upImglist(data.elem);
        $('input[name="up-img-notcheck"]').prop('checked', false);
        form.render();
        setTimeout(function () {
            _is = true;
        }, 10)
    })
    form.on('checkbox(upimgnotcheck)', function (data) {
        if ($(data.elem).is(':checked')) {
            $('input[name="up-img-item"]').prop('checked', false);
            form.render();
        }
    })
    //但是，如果你的HTML是动态生成的，自动渲染就会失效
    //因此你需要在相应的地方，执行下述方法来进行渲染
    form.render();
});

function upimgChange(obj) {
    // if (!$(event.srcElement).hasClass('layui-icon') && !$(event.srcElement).hasClass('layui-unselect') && _is) {
    //     _is = false;
    //     $(obj).find('.layui-icon').click();
    // }
    location.href = location.protocol+'//'+location.host+'/PublishProject/SubmitInfoImg'
}

function upImglist(obj) {
    var _val = [];
    $('input[name="up-img-item"]').each(function () {
        if ($(this).is(':checked')) {
            _val.push($(this).val());
        }
    })
    $('.up-img-check span').html(_val.join(',') == '' ? '' : _val.join(',') + ' <em>图库</em>');
}