let tableData = [{
    id: 1
}, {
    id: 2
}, {
    id: 3
}, {
    id: 4
}];
var tableIns = {};
$(function () {
    tableIns = table.render({
        elem: '#table1',
        height: 467,
        page: true,
        data: tableData,
        cols: [
            [ //表头
                {
                    type: 'checkbox'
                },
                {
                    field: 'id',
                    title: 'ID',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '开始时间',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '截止时间',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '设计内容',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '任务属性',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '接单人',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '把控人',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '<p style="line-height:20px; text-align:center;">费用拆分<br/>(剩余60%)</p>',
                    align: 'center'
                }, {
                    field: 'id',
                    title: '<p style="line-height:20px; text-align:center;">实际费用 <br/>(100000元)</p>',
                    align: 'center'
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
        } else if (obj.event === 'upMove') {
            let _i = 0;
            tableData.forEach(function (item, index) {
                if (item.id == data.id) {
                    _i = index;
                }
            })
            upGo(tableData, _i);
            tableIns.reload({
                data: tableData
            });
        } else if (obj.event === 'downMove') {
            let _i = 0;
            tableData.forEach(function (item, index) {
                if (item.id == data.id) {
                    _i = index;
                }
            })
            downGo(tableData, _i);
            tableIns.reload({
                data: tableData
            });
        } else if (obj.event === 'stick') {
            let _i = 0;
            tableData.forEach(function (item, index) {
                if (item.id == data.id) {
                    _i = index;
                }
            })
            toFirst(tableData, _i);
            tableIns.reload({
                data: tableData
            });
        } else if (obj.event === 'rear') {
            let _i = 0;
            tableData.forEach(function (item, index) {
                if (item.id == data.id) {
                    _i = index;
                }
            })
            toRear(tableData, _i);
            tableIns.reload({
                data: tableData
            });
            
        } else if (obj.event === 'collect') {
            location.href = location.protocol + '//' + location.host + "/PublishProject/History"
        }
    });


    element.init();
})

function toFirst(fieldData, index) {

    if (index != 0) {

        // fieldData[index] = fieldData.splice(0, 1, fieldData[index])[0]; 这种方法是与另一个元素交换了位子，

        fieldData.unshift(fieldData.splice(index, 1)[0]);

    }

}

function toRear(fieldData, index) {

    if (index != fieldData.length - 1) {

        // fieldData[index] = fieldData.splice(0, 1, fieldData[index])[0]; 这种方法是与另一个元素交换了位子，

        swapArr(fieldData, index, fieldData.length - 1)

    }

}

function swapArr(arr, index1, index2) {
    arr[index1] = arr.splice(index2, 1, arr[index1])[0];
    return arr;
}

function upGo(fieldData, index) {

    if (index != 0) {

        fieldData[index] = fieldData.splice(index - 1, 1, fieldData[index])[0];

    }

}

function downGo(fieldData, index) {

    if (index != fieldData.length - 1) {

        fieldData[index] = fieldData.splice(index + 1, 1, fieldData[index])[0];

    }

}