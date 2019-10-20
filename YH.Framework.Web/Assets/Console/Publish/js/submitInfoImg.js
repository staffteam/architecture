var data = [{
    imgUrl: '/Assets/console/identity/images/icon_personal_list_1.jpg',
    title: '图片序号：01'
},
{
    imgUrl: '/Assets/console/identity/images/icon_personal_list_1.jpg',
    title: '图片序号：02'
},
{
    imgUrl: '/Assets/console/identity/images/icon_personal_list_1.jpg',
    title: '图片序号：03'
}
]
$(function () {
    data.forEach(function (value, index) {
        $('.info-img-main').append(['<li onclick="infoImgMain(this)" data-index="' + index + '" >',
            '<p><img src="' + value.imgUrl + '" /></p>',
            '<h2>' + value.title + '</h2>',
            '</li >'
        ].join(''));
    })
})

function infoImgMain(obj) {
    var _html = [];

    data.forEach(function (value, index) {
        _html.push('<div class="swiper-slide"><img src="' + value.imgUrl + '" /></div>');
    })
    top.layui.layer.open({
        title: false,
        btn:false,
        area:['50vw','25vw'],
        content: ['<div class="swiper-container" id="swipers">',
            '<div class="swiper-wrapper">',
            _html.join(''),
            ' </div>',
            '<div class="swiper-button-prev"><i class="iconfont" >&#xe630;</i></div>',
            '<div class="swiper-button-next"><i class="iconfont" >&#xe608;</i></div>',
            '</div>'
        ].join(''),
        success: function (layero, index) {
            var mySwiper = new Swiper('#swipers', {
                loop: true, // 循环模式选项
                // 如果需要前进后退按钮
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                }
            })
            mySwiper.slideTo(+obj.getAttribute('data-index'));
        }
    })
}