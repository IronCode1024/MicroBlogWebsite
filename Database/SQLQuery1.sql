 ������ �û���Ϣ��
  UserInfo
�����ֶ�  id name(��ʵ) �ǳ� sex ���� ����  ���� phone  ���� ����id���� ��עid����  ��˿id����(1,2,3(��������id)ͨ�������жϷ�˿����)

΢����
WBinformation
�����ֶ� id  ΢������ ΢������ ����(����,��Ƶ) ����ʱ�� ��ʶid



������Ϣ��
education
 id  ����  ѧУ����  Ժϵ  �����������ϵ

 ְҵ��Ϣ��
Occupation
 id ���ڵ�  ��λ���� ����ʱ��   ����/ְλ



 ������
 province
 PId ʡ���� 

 ��
 city
Cid  ������ PId  

 
  UserInfo    --������Ϣ

  UId  int primary key identity(1,1)             --id
  name nvarchar(20)                             --name(��ʵ)
  Nickname nvarchar(20)                         --�ǳ�
  sex nvarchar(10) check(sex='��'or sex='Ů')   --�Ա�
  region nvarchar(20)                           --����
  birthday datetime                             --����
  e-mail  nvarchar(100)                         --����
  phone nvarchar(50)                            --����
  pwd nvarchar(50)                              --����
  FriendsId  nvarchar(500)                      --����id����
  followId nvarchar(500)                        --��עid����
  FansId   nvarchar(500)                        --��˿id����(1,2,3(��������id)ͨ�������жϷ�˿����)



  WBinformation   --΢����Ϣ

  id int   primary key identity(1,1) --id(��������΢����)
  WBname nvarchar(50)                --΢������
  WBcontent nvarchar(100)            --΢������
  WBEnclosure  nvarchar(500)         --΢���������������֣���Ƶ��ַ��
  WBtime    datetime                 --����ʱ��
  UId       int                      --�����˵�id



  education    --������Ϣ

  Uid int �������UserInfo   --uid
 type  nvarchar(50)          --ѧУ����
 stuname nvarchar(50)        --ѧУ����
 Departments  nvarchar(50)   --Ժϵ


 Occupation    --ְҵ

 UId int �������UserInfo  --UId
 region nvarchar(20)       --����
 Company  nvarchar(20)     --��λ����
 time   nvarchar(50)       --����ʱ��
 position  nvarchar(30)    --ְλ


  province    --ʡ

  PId int primary key identity(1,1)  --ʡid
  Pname nvarchar(20)                 --ʡ����


   city      --��

   Cid int primary key identity(1,1) --��id
   Cname nvarchar(20)                --������
   PId int                           --��Ӧ��ʡid


   create database WBdb
   use wbdb
   create table UserInfo 
   (
    UId  int primary key identity(1,1)   ,          --id
  name nvarchar(20)             ,                --name(��ʵ)
  Nickname nvarchar(20)          ,               --�ǳ�
  sex nvarchar(10) check(sex='��'or sex='Ů'),   --�Ա�
  region nvarchar(20) ,                   --����
  birthday datetime ,                        --����
  mailbox  nvarchar(100),                      --����
  phone nvarchar(50),                     --����
  pwd nvarchar(50) ,                         --����
  FriendsId  nvarchar(500)   ,                   --����id����
  followId nvarchar(500)    ,                    --��עid����
  FansId   nvarchar(500)                        --��˿id����(1,2,3(��������id)ͨ�������жϷ�˿����)
   )
   create table  WBinformation
   (
   id int   primary key identity(1,1), --id(��������΢����)
  WBname nvarchar(50),                --΢������
  WBcontent nvarchar(100) ,           --΢������
  WBEnclosure  nvarchar(500),         --΢���������������֣���Ƶ��ַ��
  WBtime    datetime  ,               --����ʱ��
  UId       int                      --�����˵�id
   )

   create table education
   (
   Uid int ,--�������UserInfo   --uid
 type  nvarchar(50),          --ѧУ����
 stuname nvarchar(50),        --ѧУ����
 Departments  nvarchar(50)   --Ժϵ
   )

   create table  Occupation
   (
    UId int,  --�������UserInfo  --UId
 region nvarchar(20),       --����
 Company  nvarchar(20),     --��λ����
 time   nvarchar(50),       --����ʱ��
 position  nvarchar(30)    --ְλ
   )

   create table province  
   (
   PId int primary key identity(1,1) , --ʡid
  Pname nvarchar(20)                 --ʡ����
   )
   create table city
   (
   Cid int primary key identity(1,1), --��id
   Cname nvarchar(20)  ,              --������
   PId int                           --��Ӧ��ʡid
   )