Create Table Tunnel_Chat
(
  Chat_ID identity bigint not null,
  Chat_UserID bigint not null default 0,
  Chat_UserName varchar(50) null,
  Chat_Content  varChar(200) null,
  Chat_Date datetime null,
  Chat_State int(4) not null default 0,--0Ϊ������˵,1Ϊ��**˵��2Ϊ��**����˵��
  Chat_ToUserID bigint not null default 0,
)