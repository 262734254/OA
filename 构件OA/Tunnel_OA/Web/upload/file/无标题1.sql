Create Table Tunnel_Chat
(
  Chat_ID identity bigint not null,
  Chat_UserID bigint not null default 0,
  Chat_UserName varchar(50) null,
  Chat_Content  varChar(200) null,
  Chat_Date datetime null,
  Chat_State int(4) not null default 0,--0为所有人说,1为对**说，2为对**悄悄说。
  Chat_ToUserID bigint not null default 0,
)