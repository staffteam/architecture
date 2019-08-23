function importSearch(o) {
    alert($(this).parent().find('input').val());
}
$(function () {
    var element = layui.element;
    table.render({
        elem: '#table1',
        height: 523,
        toolbar: '#table1Btn',
        url: '/Assets/console/lookingFor/js/test.json' //数据接口
            ,
        page: true //开启分页
            ,
        cols: [
            [ //表头
                {
                    field: 'id',
                    width: 80,
                    title: 'ID'
                }, {
                    field: 'username',
                    width: 80,
                    title: '用户名'
                }, {
                    field: 'sex',
                    width: 80,
                    title: '性别'
                }, {
                    field: 'city',
                    width: 80,
                    title: '城市'
                }, {
                    field: 'sign',
                    title: '签名',
                    width: '30%',
                    minWidth: 100
                } //minWidth：局部定义当前单元格的最小宽度，layui 2.2.1 新增
                , {
                    field: 'experience',
                    title: '积分'
                }, {
                    field: 'score',
                    title: '评分'
                }, {
                    field: 'classify',
                    title: '职业'
                }, {
                    field: 'wealth',
                    width: 137,
                    title: '财富'
                }, {
                    fixed: 'right',
                    title: '收藏简历',
                    toolbar: '#table1Bar',
                    width:100
                }
            ]
        ],
        done: function (res, curr, count) {
            laydate.render({
                elem: '#date'
            });
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
})