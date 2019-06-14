select * from Tana_GoodFriend

--根据用户ID查询某个用户的FansUserID数量
select count(FansUserID) from Tana_GoodFriend where MyUserID=3 group by MyUserID;
--根据用户ID查询某个用户的FollowUserID数量
select count(FollowUserID) from Tana_GoodFriend where MyUserID=3 group by MyUserID;