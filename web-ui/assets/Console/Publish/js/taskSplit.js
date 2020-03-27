$(function () {
    table.render({
        elem: '#table1',
        height: 578,
        url: '/Assets/console/lookingFor/js/test.json' //数据接口
        ,
        page: true //开启分页
        ,
        cols: [
            [ //表头
                { type: 'checkbox' },
                {
                    field: 'id',
                    title: 'ID'
                }, {
                    field: 'username',
                    title: '用户名'
                }, {
                    field: 'sex',
                    title: '性别'
                }, {
                    field: 'city',
                    title: '城市'
                }, {
                    field: 'sign',
                    title: '签名',
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
                    title: '财富'
                }, {
                    fixed: 'right',
                    title: '操作',
                    toolbar: '#table1Bar',
                    width: 345
                }
            ]
        ],
    });

    //监听行工具事件
    table.on('tool(table1)', function (obj) {
        var data = obj.data;
        //console.log(obj)
        if (obj.event === 'look') {
            location.href = "/lookingFor/lookDetails"
        } else if (obj.event === 'task') {

        } else if (obj.event === 'collect') {
            location.href = location.protocol + '//' + location.host + "/PublishProject/History"
        }
    });


    element.init();
})