 基本表 用户信息表
  UserInfo
包含字段  id name(真实) 昵称 sex 地区 生日  邮箱 phone  密码 好友id集合 关注id集合  粉丝id集合(1,2,3(代表他人id)通过这样判断粉丝人数)

微博表
WBinformation
包含字段 id  微博名称 微博内容 附件(音乐,视频) 发布时间 标识id



教育信息表
education
 id  类型  学校名称  院系  基本表外键关系

 职业信息表
Occupation
 id 所在地  单位名称 工作时间   部门/职位



 地区表
 province
 PId 省名称 

 市
 city
Cid  市名称 PId  

 
  UserInfo    --基本信息

  UId  int primary key identity(1,1)             --id
  name nvarchar(20)                             --name(真实)
  Nickname nvarchar(20)                         --昵称
  sex nvarchar(10) check(sex='男'or sex='女')   --性别
  region nvarchar(20)                           --地区
  birthday datetime                             --生日
  e-mail  nvarchar(100)                         --邮箱
  phone nvarchar(50)                            --邮箱
  pwd nvarchar(50)                              --密码
  FriendsId  nvarchar(500)                      --好友id集合
  followId nvarchar(500)                        --关注id集合
  FansId   nvarchar(500)                        --粉丝id集合(1,2,3(代表他人id)通过这样判断粉丝人数)



  WBinformation   --微博信息

  id int   primary key identity(1,1) --id(包含所有微博的)
  WBname nvarchar(50)                --微博标题
  WBcontent nvarchar(100)            --微博内容
  WBEnclosure  nvarchar(500)         --微博所发附件（音乐，视频地址）
  WBtime    datetime                 --发布时间
  UId       int                      --所发人的id



  education    --教育信息

  Uid int 外键关联UserInfo   --uid
 type  nvarchar(50)          --学校类型
 stuname nvarchar(50)        --学校名称
 Departments  nvarchar(50)   --院系


 Occupation    --职业

 UId int 外键关联UserInfo  --UId
 region nvarchar(20)       --地区
 Company  nvarchar(20)     --单位名称
 time   nvarchar(50)       --工作时间
 position  nvarchar(30)    --职位


  province    --省

  PId int primary key identity(1,1)  --省id
  Pname nvarchar(20)                 --省名称


   city      --市

   Cid int primary key identity(1,1) --市id
   Cname nvarchar(20)                --市名称
   PId int                           --对应的省id


   create database WBdb
   use wbdb
   create table UserInfo 
   (
    UId  int primary key identity(1,1)   ,          --id
  name nvarchar(20)             ,                --name(真实)
  Nickname nvarchar(20)          ,               --昵称
  sex nvarchar(10) check(sex='男'or sex='女'),   --性别
  region nvarchar(20) ,                   --地区
  birthday datetime ,                        --生日
  mailbox  nvarchar(100),                      --邮箱
  phone nvarchar(50),                     --邮箱
  pwd nvarchar(50) ,                         --密码
  FriendsId  nvarchar(500)   ,                   --好友id集合
  followId nvarchar(500)    ,                    --关注id集合
  FansId   nvarchar(500)                        --粉丝id集合(1,2,3(代表他人id)通过这样判断粉丝人数)
   )
   create table  WBinformation
   (
   id int   primary key identity(1,1), --id(包含所有微博的)
  WBname nvarchar(50),                --微博标题
  WBcontent nvarchar(100) ,           --微博内容
  WBEnclosure  nvarchar(500),         --微博所发附件（音乐，视频地址）
  WBtime    datetime  ,               --发布时间
  UId       int                      --所发人的id
   )

   create table education
   (
   Uid int ,--外键关联UserInfo   --uid
 type  nvarchar(50),          --学校类型
 stuname nvarchar(50),        --学校名称
 Departments  nvarchar(50)   --院系
   )

   create table  Occupation
   (
    UId int,  --外键关联UserInfo  --UId
 region nvarchar(20),       --地区
 Company  nvarchar(20),     --单位名称
 time   nvarchar(50),       --工作时间
 position  nvarchar(30)    --职位
   )

   create table province  
   (
   PId int primary key identity(1,1) , --省id
  Pname nvarchar(20)                 --省名称
   )
   create table city
   (
   Cid int primary key identity(1,1), --市id
   Cname nvarchar(20)  ,              --市名称
   PId int                           --对应的省id
   )