var fs = require("fs");
var http = require('http');
var route = require('./route');
http.createServer(function (request, response) {
    let _url = request.url;
    // 静态资源类型
    let contentType = {
        "css": "text/css",
        "gif": "image/gif",
        "ico": "image/x-icon",
        "jpeg": "image/jpeg",
        "jpg": "image/jpeg",
        "js": "text/javascript",
        "json": "application/json",
        "pdf": "application/pdf",
        "png": "image/png",
        "svg": "image/svg+xml",
        "swf": "application/x-shockwave-flash",
        "tiff": "image/tiff",
        "txt": "text/plain",
        "wav": "audio/x-wav",
        "wma": "audio/x-ms-wma",
        "wmv": "video/x-ms-wmv",
        "xml": "text/xml",
        "ttf":"font/truetype"
    };
    //返回静态资源
    if (_url != '' && _url.split('.').length >= 1) {
        _url = _url.split('?')[0];
        let _suffix = _url.split('.')[_url.split('.').length - 1];
        if (contentType[_suffix]) {
            response.setHeader("Content-Type", contentType[_suffix]);
            //格式必须为 binary 否则会出错
            fs.readFile(__dirname + _url, 'binary', function (err, data) {
                if (err) {
                    response.writeHead(404, "Error");
                    response.end();
                } else {
                    response.writeHead(200, "Ok");
                    response.write(data, "binary"); //格式必须为 binary，否则会出错
                    response.end();
                }
            });
            return false;
        }
    };
    let _is = true;
    //根据路由返回对应页面
    let _urlArr = _url.split('?');
    route.forEach(value => {
        if (_urlArr[0].toLowerCase() == value.route.toLowerCase()) {
            //获取公共页面
            fs.readFile(`${__dirname}/leader/${_urlArr[0].indexOf('/Web')==0?'webLeader.html':_urlArr[0].indexOf('/Login')==0 || _urlArr[0].indexOf('/Web/Home')==0?'login.html':'leader.html'}`, 'utf-8', function (err, data) {
                console.log(err);
                if (err) {
                    response.writeHead(404, "Error");
                    response.end();
                } else {
                    // 替换{{ }}关键字符串
                    let _data = data.match(/\{\{(\S*?)\}\}/g);
                    _data.forEach(_value=>{
                        let _name = _value.split('\{\{')[1].split('\}\}')[0];
                        data = data.replace(_value, value[_name]);
                    });
                    //找到<% %>关键字符串 替换对应的模块
                    let _mod = data.match(/<%(\S*?)%>/g);
                    let _i = 0;
                    _mod.forEach((_value, index) => {
                        let _name = _value.split('<%')[1].split('%>')[0];
                        if (_name === 'Main') {
                            //根据路由路径获取主体内容
                            fs.readFile(`${__dirname}/pages/${value.page}`, 'utf-8', function (err, _data) {
                                if (err) {
                                    response.writeHead(404, "Error");
                                    response.end();
                                } else {
                                    data = data.replace(_value, _data);
                                    if (_i == _mod.length - 1) {
                                        response.writeHead(200, "Ok");
                                        response.write(data, "utf-8"); //格式必须为 binary，否则会出错
                                        response.end();
                                    }
                                }
                                _i++;
                            });
                        } else {
                            //根据关键字符串 获取通用模块并替换
                            fs.readFile(`${__dirname}/common/${_name}.html`, 'utf-8', function (err, _data) {
                                if (err) {
                                    response.writeHead(404, "Error");
                                    response.end();
                                } else {
                                    data = data.replace(_value, _data);
                                    if (_i == _mod.length - 1) {
                                        response.writeHead(200, "Ok");
                                        response.write(data, "utf-8"); //格式必须为 binary，否则会出错
                                        response.end();
                                    }
                                }
                                _i++;
                            });
                        }
                    })
                }
            });
            _is = false;
        }
    });
    if (_is) {
        //若没有对应的路由，则返回错误页
        getLeader(response, function (header,footer) {
            fs.readFile(`${__dirname}/error/404.html`, 'utf-8', function (err, data) {
                if (err) {
                    response.writeHead(404, "Error");
                    response.end();
                } else {
                    response.writeHead(200, "Ok");
                    response.write(`<html>
                    <head>
                        <title>404</title>
                        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                        <meta name="apple-mobile-web-app-capable" content="yes">
                        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
                        <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=no">
                    </head>
                    <body>
                        ${header+data+footer}
                    </body>
                    </html>`, "utf-8");
                    response.end();
                }
            });
        });
    };
}).listen(5555);

//获取头部底部
function getLeader(response, callback) {
    fs.readFile(`${__dirname}/common/header.html`, 'utf-8', function (err, header) {
        if (err) {
            response.writeHead(404, "Error");
            response.end();
        } else {
            fs.readFile(`${__dirname}/common/footer.html`, 'utf-8', function (err, footer) {
                if (err) {
                    response.writeHead(404, "Error");
                    response.end();
                } else {
                    callback(header, footer);
                }
            });
        }
    });
}
// 终端打印如下信息
console.log('http://127.0.0.1:5555/');