

INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('公告',1,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('订购指南',2,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('安全指南',3,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('支付与取票',4,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('沟通与订阅',5,0)
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('会员公告',6,0)

INSERT INTO [tbl_Webmaster]  ([Username],[Password],[MD5Password],[Realname],[Telephone],[Fax],[Mobile],[Permissions],[IsEnable],[IsAdmin],[CreateTime])  VALUES  ('Admin','000000','670b14728ad9902aecba32e22fa4f6bd','网站管理员','','','','','1','1',GETDATE())





--2013-07-09

--插入定制游资讯类别
INSERT INTO tbl_TravelArticleClass(ClassName,IsSystem,SortRule) VALUES('定制游',7,0)
--Admin账号分配所有权限
UPDATE tbl_Webmaster SET [Permissions]='101,102,103,104,201,202,203,204,301,302,303,401,501,502,503,504,505,506,507,508,509,510,511,601,602,10001,10002' WHERE Id=2

--修改内容：酒店-地理位置（地标）表tbl_HotelLandMarks表添加CityId字段(城市编号)
ALTER TABLE tbl_HotelLandMarks ADD
	CityId int not NULL DEFAULT (0)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_HotelLandMarks', @level2type=N'COLUMN',@level2name=N'CityId'
GO

--资讯留言表
if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_TravelArticleLY')
            and   type = 'U')
   drop table tbl_TravelArticleLY
go
/*==============================================================*/
/* Table: tbl_TravelArticleLY                                   */
/*==============================================================*/
create table tbl_TravelArticleLY (
   LiuYanId             char(36)             not null,
   ArticleID            char(36)             not null,
   MemberID             char(36)             not null,
   LiuYanShiJian        datetime             not null default getdate(),
   LiuYanContet         nvarchar(max)         null,
   HuiFuContet          nvarchar(max)         null,
   IsCheck              char(1)              not null default '0',
   OperatorId           char(36)             null default '0',
   IssueTime            datetime             null,
   constraint PK_TBL_TRAVELARTICLELY primary key (LiuYanId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资讯留言',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '留言编号',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资讯编号',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'ArticleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '会员编号',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'MemberID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '留言时间',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanShiJian'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '留言内容',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'LiuYanContet'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '回复内容',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'HuiFuContet'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否审核',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'IsCheck'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核人',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核时间',
   'user', @CurrentUser, 'table', 'tbl_TravelArticleLY', 'column', 'IssueTime'
go

