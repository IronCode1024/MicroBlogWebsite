# MicroBlogWebsite==解决方案名称
微博门户网站项目，基于ASP.NET MVC+三层架构和EntityFramework

## MicroBlogWebsite项目为MVC
## DAL 数据访问层
## BLL 业务逻辑层
## Models 数据实体模型层
数据库访问使用的Code First模式，手写上下文。
## DTO 是Data Transfer Object 的简写，既数据传输对象。
是一种设计模式之间传输数据的软件应用系统。数据传输目标往往是数据访问对象从数据库中检索的数据。数据传输对象与数据交互对象或数据访问对象之间是一个不具备有任何行为除了存储和检索的数据。（访问和存取器）
<br>DTO没有任何业务行为（贫血模式）只作为数据的存储。

## 数据库：MSSQLServer
## 数据库SQL文件在Database文件夹下面，直接在数据库中执行既可。

## 直接下载
```bash
git clone git@github.com:IronCode1024/MicroBlogWebsite.git
```
使用Visual Studio2013以上版本打开项目文件即可！
