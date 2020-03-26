$(function () {
    var element = layui.element;
    table.render({
        elem: '#lookDetailsList',
        height: 378,
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
                    title: '操作',
                    toolbar: '#lookDetailsListBar',
                    width: 100
                }
            ]
        ],
    });
    //监听行工具事件
    table.on('tool(lookDetailsList)', function (obj) {
        var data = obj.data;
        //console.log(obj)
        if (obj.event === 'down') {
           location.href="/lookingFor/lookDetails"
        }
    });
})