function importSearch(o) {
    alert($(this).parent().find('input').val());
}
$(function () {
    var element = layui.element;
    table.render({
        elem: '#table1',
        height: 523,
        toolbar: '#table1Btn',
        url: '/Assets/console/talentPool/js/test.json',
        page: true,
        cols: [
            [ //表头
                {type: 'checkbox'},
                {
                    field: 'gender',
                    hide: true,
                    title: '性别'
                }, {
                    field: 'recentWork',
                    hide: true,
                    title: '最近工作'
                }, {
                    field: 'currentIndustry',
                    hide: true,
                    title: '现从事行业'
                }, {
                    field: 'fullEducation',
                    hide: true,
                    title: '全部学历'
                }, {
                    field: 'id',
                    hide: true,
                    title: 'ID'
                }, {
                    field: 'name',
                    width: 80,
                    title: '姓名'
                }, {
                    field: 'position',
                    width: 80,
                    title: '职位'
                }, {
                    field: 'address',
                    width: 80,
                    title: '地址'
                }, {
                    field: 'age',
                    title: '年龄',
                    width: '30%',
                    minWidth: 100
                }, {
                    field: 'yearsOfWork',
                    title: '工作年限'
                }, {
                    field: 'degree',
                    title: '学历'
                }, {
                    field: 'graduatedInstitution',
                    title: '毕业院校'
                }, {
                    field: 'platformPost',
                    width: 137,
                    title: '平台岗位'
                }, {
                    field: 'creditScore',
                    width: 137,
                    title: '信誉积分'
                }, {
                    fixed: 'right',
                    title: '收藏简历',
                    toolbar: '#table1Bar',
                    width: 100
                }
            ]
        ],
        done: function (res, curr, count) {
            laydate.render({
                elem: '#date'
            });
            //$("[data-field='id']").css('display','none');
        }
    });
    //头工具栏事件
    table.on('toolbar(test)', function (obj) {
        var checkStatus = table.checkStatus(obj.config.id);
        switch (obj.event) {
            case 'getCheckData':
                var data = checkStatus.data;
                layer.alert(JSON.stringify(data));
                break;
            case 'getCheckLength':
                var data = checkStatus.data;
                layer.msg('选中了：' + data.length + ' 个');
                break;
            case 'isAll':
                layer.msg(checkStatus.isAll ? '全选' : '未全选');
                break;
        };
    });

    //监听行工具事件
    table.on('tool(table1)', function (obj) {
        var data = obj.data;
        //console.log(obj)
        if (obj.event === 'look') {
            location.href = "/lookingFor/lookDetails"
        } else if (obj.event === 'task') {

        } else if (obj.event === 'collect') {

        }
    });
    //监听行单击事件（单击事件为：rowDouble）
    table.on('row(table1)', function (obj) {
        var data = obj.data;
        if (!obj.tr.hasClass('layui-table-click')) {
            var recentWork = '',
                fullEducation = '';
            data.recentWork ? data.recentWork.split('#').forEach(function (value) {
                recentWork += '<p>'+value+'</p>';
            }) : null;
            data.fullEducation ? data.fullEducation.split('#').forEach(function (value) {
                fullEducation += '<p>'+value+'</p>';
            }) : null;
            obj.tr.eq(0).after('<tr><td colspan="11" >' +
                '<div class="sketch"><div class="c" >' +
                '<div class="l" >' +
                '<div class="list">' +
                '<span>性别</span>' +
                '<p>' + data.gender + '</p>' +
                '</div>' +
                '<div class="list">' +
                '<span>现从事行业</span>' +
                '<p>' + data.currentIndustry + '</p>' +
                '</div>' +
                '</div>' +
                '<div class="r" >' +
                '<div class="list">' +
                '<span>最近工作</span>' +
                recentWork +
                '</div>' +
                '<div class="list">' +
                '<span>全部学历</span>' +
                fullEducation +
                '</div>' +
                '</div>' +
                '<div class="btn" ><button type="button" class="layui-btn layui-btn-normal" onclick="showResume(this)">查看完整简历</button></div>' +
                '</div></div>' +
                '</td></tr>');
            obj.tr.addClass('layui-table-click');
        } else {
            obj.tr.eq(0).next().remove();
            obj.tr.removeClass('layui-table-click');
        }
    });
})

function showResume(obj) {
    layui.layer.open({
        title:false,
        btn:false,
        content:$('#serviceWin').html(),
    })
}