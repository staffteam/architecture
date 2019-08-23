$(function () {
    var element = layui.element;
    table.render({
        elem: '#applyList',
        height: 569,
        url: '/Assets/console/lookingFor/js/test.json' //数据接口
            ,
        page: true //开启分页
            ,
        cols: [
            [ //表头
                {type:'checkbox'},
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
                }
            ]
        ],
    });
    // 选择类别
    $('#myTaskform .l button').click(function(){
        if($(this)[0].getAttribute('data-id')==0){
            //初步设计阶段
        }else{
            //施工图阶段
        }
         $(this).removeClass('layui-btn-white').siblings().addClass('layui-btn-white');
    })
})