function Provinces(init){
    $.ajax({
        url:'/Assets/Console/common/provinces/provinces.json',
        success:function(data){
            var _data = data.data;
            var _html1 = '',_html2='',_html3='',_name1={},_name2={},_name3={};
            _data.forEach(function(value,index){
                _html1+='<option value="'+value.label+'">'+value.value+'</option>';
                _name1[value.label]={index:index,name:value.value};
            });
            _data[0].children.forEach(function(value,index){
                _html2+='<option value="'+value.label+'">'+value.value+'</option>';
                _name2[value.label]={index:index,name:value.value};
            });
            _data[0].children[0].children.forEach(function(value,index){
                _html3+='<option value="'+value.label+'">'+value.value+'</option>';
                _name3[value.label]={index:index,name:value.value};
            });
            $('#'+init.elem).append('<label class="layui-form-label">'+init.label+' '+(init.required?'<i style="color:red;" >*</i>':'')+'</label>'+
            '<div class="layui-input-block"><div class="layui-input-inline" style="width:150px;" >'+
            '<select name="province" lay-filter="province"  ><option value="">请选择</option>'+_html1+'</select>'+
            '<input type="hidden" name="site" value="" class="selects" '+(init.required?'verifys="required"':'')+' tips="'+init.label+'"></div>'+
            '<div class="layui-input-inline" style="width:150px;">'+
            '<select name="city" lay-filter="city" ><option value="">请选择</option>'+_html2+'</select>'+
            '</div>'+
            '<div class="layui-input-inline" style="width:150px; margin-right:0px;">'+
            '<select name="district" lay-filter="district" ><option value="">请选择</option>'+_html3+'</select>'+
            '</div>'+
            '</div></div>');
            form.render();
            form.on('select(province)', function(data){
                var _data_ = _name1[data.value].index;
                var _val = _name1[data.value].name;
                if($(this).find('option').length != _name1.length){
                    _html1="";
                    _data.forEach(function(value,index){
                        _html1+='<option value="'+value.label+'" '+(data.value==value.label?'selected':'')+' >'+value.value+'</option>';
                        _name1[value.label]={index:index,name:value.value};
                    });
                    $('#'+init.elem).find('select[name="province"]').html(_html1);
                    form.render('select');
                }
                if(_data_!=undefined){
                    _html2="";
                    _data[_data_].children.forEach(function(value,index){
                        index==0?_val+=' '+value.value:'';
                        _html2+='<option value="'+value.label+'">'+value.value+'</option>';
                        _name2[value.label]={index:index,name:value.value};
                    });
                    _html3="";
                    _data[_data_].children[0].children.forEach(function(value,index){
                        index==0?_val+=' '+value.value:'';
                        _html3+='<option value="'+value.label+'">'+value.value+'</option>';
                        _name3[value.label]={index:index,name:value.value};
                    });
                    $('#'+init.elem).find('select[name="city"]').html(_html2);
                    $('#'+init.elem).find('select[name="district"]').html(_html3);
                }
                $('#'+init.elem).find('input[name="site"]').val(_val);
                form.render('select');
			});
            form.on('select(city)', function(data){
                var _data_1 = _name1[$('#'+init.elem).find('select[name="province"]').val()].index;
                var _data_ = _name2[data.value].index;
                var _val = _name1[$('#'+init.elem).find('select[name="province"]').val()].name+' '+_name2[data.value].name;
                if(_data_!=undefined){
                    _html3="";
                    _data[_data_1].children[_data_].children.forEach(function(value,index){
                        index==0?_val+=' '+value.value:'';
                        _html3+='<option value="'+value.label+'">'+value.value+'</option>';
                        _name3[value.label]={index:index,name:value.value};
                    });
                    $('#'+init.elem).find('select[name="district"]').html(_html3);
                }
                $('#'+init.elem).find('input[name="site"]').val(_val);
                form.render('select');
            });
            form.on('select(district)', function(data){
                var _val = _name1[$('#'+init.elem).find('select[name="province"]').val()].name+' '+_name2[$('#'+init.elem).find('select[name="city"]').val()].name+' '+_name3[$('#'+init.elem).find('select[name="district"]').val()].name;
                $('#'+init.elem).find('input[name="site"]').val(_val);
                form.render('select');
            });
            typeof init.call === 'function'?init.call():null;
        }
    });
}