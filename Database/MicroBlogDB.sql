select * from Tana_GoodFriend

--�����û�ID��ѯĳ���û���FansUserID����
select count(FansUserID) from Tana_GoodFriend where MyUserID=3 group by MyUserID;
--�����û�ID��ѯĳ���û���FollowUserID����
select count(FollowUserID) from Tana_GoodFriend where MyUserID=3 group by MyUserID;