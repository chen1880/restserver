# 物联网通信 - RESTDemo示例程序（C#版本）
Server开放RESTful API接口，供应用程序/移动App/嵌入式qt通过http post调用，实现获取服务端数据，更新服务器数据
技术：wcf+http post+json(.net4.0 + jdk1.8)

运行环境：vs2010+java 

概述
Server开放RESTful API接口，供应用程序/移动App/嵌入式qt通过http post调用，实现获取服务端数据，更新服务器数据

详细
物联网通信 - REST
什么是REST
REST即表述性状态传递(英文:Representational State Transfer，简称REST)，描述的是在网络中client和server的一种交互形式。

 
REST能干什么
REST可以通过一套统一的接口为 Web，iOS和Android提供服务。另外对于广大平台来说，比如Facebook platform，微博开放平台，微信公共平台等，它们不需要有显式的前端，只需要一套提供服务的接口，于是REST更是它们最好的选择。



实战解析
API接口说明：

测试接口：                              http://127.0.0.1:8888/JsonService/Test

参数接口：                              http://127.0.0.1:8888/JsonService/MultiParam

获取数据(未加密)接口：           http://127.0.0.1:8888/JsonService/GetDataTable

获取数据(DES加密)接口：        http://127.0.0.1:8888/JsonService/GetDataTable_DES

执行操作(未加密)接口：           http://127.0.0.1:8888/JsonService/ExecuteNonQuery

执行操作(DES加密)接口：        http://127.0.0.1:8888/JsonService/ExecuteNonQuery_DES

效果演示
服务端程序（C#）



客户端程序（c#）



客户端程序（java）

代码框架







QQ群：683060289
