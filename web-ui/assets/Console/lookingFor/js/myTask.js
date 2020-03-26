let file_name = "";
$(function () {
    var element = layui.element;
    table.render({
        elem: '#applyList',
        height: 569,
        url: '/Assets/console/lookingFor/js/task.json' //数据接口
            ,
        page: true //开启分页
            ,
        cols: [
            [ //表头
                {
                    type: 'checkbox'
                },
                {
                    field: 'id',
                    title: 'ID'
                }, {
                    field: 'startTime',
                    title: '开始时间'
                }, {
                    field: 'endTime',
                    title: '截止时间'
                }, {
                    field: 'content',
                    title: '设计内容'
                }, {
                    field: 'jdr',
                    title: '接单人',
                } //minWidth：局部定义当前单元格的最小宽度，layui 2.2.1 新增
                , {
                    field: 'excel',
                    title: '格式图表样板',
                    templet: '#excelTp'
                }, {
                    field: 'endExcel',
                    title: '成果表'
                }, {
                    field: 'isUp',
                    title: '成果提交',
                    templet: '#isUpTp'
                }, {
                    field: 'file',
                    title: '指引类资料'
                }, {
                    field: 'shr',
                    title: '特殊接单人'
                }, {
                    field: 'shr',
                    title: '把控人'
                }, {
                    field: 'shr',
                    title: '费用分配'
                }
            ]
        ],
        done: function () {
            $('a.notup').each(function () {
                $(this).closest('tr').addClass('not-up-tr');
            })

            $('#downWord').click(function () {
                $('#down span').click();
            })
            var upload = layui.upload;
            //普通图片上传
            var uploadInst = upload.render({
                elem: '#upWord',
                url: 'http://localhost:8083/api/image',
                progress: function (n, elem) {
                    upWin.percent(file_name, n);
                    console.log(elem); //得到当前触发的元素 DOM 对象。可通过该元素定义的属性值匹配到对应的进度条。
                },
                before: function (obj) {
                    //预读本地文件示例，不支持ie8
                    obj.preview(function (index, file, result) {
                        upWin.init(function () {
                            file_name = file.name;
                            upWin.start(file.name);
                        });
                    });
                },
                done: function (res) {
                    //如果上传失败
                    if (res.code > 0) {
                        return $msg({
                            content: '上传失败',
                            icon: 0
                        });
                    }
                    return $msg({
                        content: '成功',
                        icon: 1
                    });
                    //上传成功
                },
                error: function () {
                    $msg({
                        content: '上传失败',
                        icon: 0
                    });
                }
            });
        }
    });
    // 选择类别
    $('#myTaskform .l button').click(function () {
        if ($(this)[0].getAttribute('data-id') == 0) {
            //初步设计阶段
        } else {
            //施工图阶段
        }
        $(this).removeClass('layui-btn-white').siblings().addClass('layui-btn-white');
    })
})