

--2013-04-18


/*==============================================================*/
/* Table: tbl_HotelTourCustoms   酒店团队定制                   */
/*==============================================================*/
create table tbl_HotelTourCustoms (
   Id                   int                  identity,
   UserID               char(36)             null,
   ContacterName        nvarchar(50)         null,
   ContacterMobile      varchar(50)          null,
   ContacterTelephone   varchar(50)          null,
   HotelId              char(36)             not null,
   HotelCode            varchar(36)          null,
   HotelName            nvarchar(255)        null,
   HotelStar            tinyint              not null default 0,
   CityCode             varchar(5)           null,
   LocationAsk          nvarchar(255)        null,
   RoomAsk              nvarchar(50)         null,
   LiveStartDate        datetime             null,
   LiveEndDate          datetime             null,
   RoomCount            int                  not null default 0,
   PeopleCount          int                  not null default 0,
   BudgetMin            money                not null default 0,
   BudgetMax            money                not null default 0,
   Payment              tinyint              not null default 0,
   GuestType            tinyint              not null default 0,
   TourType             tinyint              not null default 0,
   OtherRemark          nvarchar(500)        null,
   IssueTime            datetime             not null default getdate(),
   TreatState           tinyint              not null default 0,
   TreateTime           datetime             null,
   OperatorId           int                  not null default 0,
   Source               tinyint              not null default 0,
   constraint PK_TBL_HOTELTOURCUSTOMS primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'UserID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人姓名',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'ContacterName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人手机',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'ContacterMobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人电话',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'ContacterTelephone'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店代码',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'HotelCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'HotelName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '星级要求',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'HotelStar'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '目的地城市三字码',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'CityCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地理位置要求',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'LocationAsk'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间要求',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'RoomAsk'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '入住开始时间',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'LiveStartDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '入住结束时间',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'LiveEndDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间数',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'RoomCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '入住人数',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'PeopleCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '团预算最小值',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'BudgetMin'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '团预算最大值',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'BudgetMax'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '付款方式',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'Payment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '宾客类型[内宾,外宾]',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'GuestType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '团队类型',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'TourType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '其他要求',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'OtherRemark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '处理状态',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'TreatState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '处理时间',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'TreateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '处理人编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单来源',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustoms', 'column', 'Source'
go


/*==============================================================*/
/* Table: tbl_HotelTourCustomsAsk     酒店团队订单回复          */
/*==============================================================*/
create table tbl_HotelTourCustomsAsk (
   ID                   int                  identity,
   TourOrderID          int                  not null,
   AskName              nvarchar(50)         not null,
   AskTime              datetime             not null,
   AskContent           nvarchar(2000)       null,
   constraint PK_TBL_HOTELTOURCUSTOMSASK primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustomsAsk', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '团队定制编号',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustomsAsk', 'column', 'TourOrderID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '回复人',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustomsAsk', 'column', 'AskName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '回复时间',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustomsAsk', 'column', 'AskTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '回复内容',
   'user', @CurrentUser, 'table', 'tbl_HotelTourCustomsAsk', 'column', 'AskContent'
go


go

alter table tbl_HotelTourCustomsAsk
   add constraint FK_HotelTourCustomsAsk foreign key (TourOrderID)
      references tbl_HotelTourCustoms (Id)
         on delete cascade
go


/*==============================================================*/
/* Table: tbl_HotelLandMarks    酒店-地理位置（地标）           */
/*==============================================================*/
create table tbl_HotelLandMarks (
   Id                   int                  identity,
   Por                  nvarchar(100)        not null,
   CityCode             varchar(5)           not null,
   constraint PK_TBL_HOTELLANDMARKS primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_HotelLandMarks', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标',
   'user', @CurrentUser, 'table', 'tbl_HotelLandMarks', 'column', 'Por'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市三字码',
   'user', @CurrentUser, 'table', 'tbl_HotelLandMarks', 'column', 'CityCode'
go


/*==============================================================*/
/* Table: tbl_HotelCityAreas        区域列表                    */
/*==============================================================*/
create table tbl_HotelCityAreas (
   Id                   int                  identity,
   CityCode             varchar(5)           not null,
   AreaName             nvarchar(50)         not null,
   constraint PK_TBL_HOTELCITYAREAS primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_HotelCityAreas', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市三字码',
   'user', @CurrentUser, 'table', 'tbl_HotelCityAreas', 'column', 'CityCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '区域名称',
   'user', @CurrentUser, 'table', 'tbl_HotelCityAreas', 'column', 'AreaName'
go


/*==============================================================*/
/* Table: tbl_HotelCity          酒店城市信息                   */
/*==============================================================*/
create table tbl_HotelCity (
   ID                   int                  identity,
   CityName             nvarchar(250)        not null,
   Spelling             nvarchar(20)         null,
   SimpleSpelling       nvarchar(20)         null,
   CityCode             varchar(5)           not null,
   IsHot                char(1)              not null default '0',
   constraint PK_TBL_HOTELCITY primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店城市信息',
   'user', @CurrentUser, 'table', 'tbl_HotelCity'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'CityName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '全拼',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'Spelling'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '简拼',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'SimpleSpelling'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '三字码',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'CityCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否常用',
   'user', @CurrentUser, 'table', 'tbl_HotelCity', 'column', 'IsHot'
go


--基础数据日志


go

 SET IDENTITY_INSERT tbl_HotelCity ON 

 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 2, '阿坝州', 'Abazhou', 'ABZ', 'ABA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 3, '阿城', 'Acheng', 'AC', 'ACH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 4, '阿克苏', 'Akesu', 'AKS', 'AKU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 5, '阿勒泰', 'Aletai', 'ALT', 'AAT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 6, '阿图什', 'Atushen', 'ATS', 'ATU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 7, '安吉', 'Anji', 'AJ', 'ANJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 8, '安康', 'Ankang', 'AK', 'AKA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 9, '安陆', 'Anlu', 'AL', 'ANL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 10, '安庆', 'Anqing', 'AQ', 'AQG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 11, '安顺', 'Anshun', 'AS', 'ANS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 12, '安阳', 'Anyang', 'AY', 'AYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 13, '鞍山', 'Anshan', 'AS', 'AOG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 14, '澳门', 'Aomen', 'AM', 'MFM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 15, '巴中', 'Bazhong', 'BZ', 'BAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 16, '白城', 'Baicheng', 'BC', 'BAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 17, '白山', 'Baishan', 'BS', 'BAS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 18, '百色', 'Baise', 'BS', 'BSI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 19, '蚌埠', 'Bangbu', 'BB', 'BFU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 20, '包头', 'Baotou', 'BT', 'BAV', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 21, '宝鸡', 'Baoji', 'BJ', 'BAJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 22, '保定', 'Baoding', 'BD', 'BAD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 23, '保山', 'Baoshan', 'BS', 'BSD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 24, '北安', 'Beian', 'BA', 'BEA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 25, '北戴河', 'Beidaihe', 'BDH', 'BDH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 26, '北海', 'Beihai', 'BH', 'BHY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 27, '北京', 'Beijingshoudu', 'BJSD', 'PEK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 28, '北流', 'Beiliu', 'BL', 'BEL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 29, '北宁', 'Beining', 'BN', 'BEN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 30, '本溪', 'Benxi', 'BX', 'BEX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 31, '毕节', 'Bijie', 'BJ', 'BIJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 32, '滨州', 'Binzhou', 'BZ', 'BIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 33, '亳州', 'Bozhou', 'BZ', 'BOZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 34, '博乐', 'Bole', 'BL', 'BOL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 35, '沧州', 'Cangzhou', 'CZ', 'CAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 36, '昌都', 'Changdou', 'CD', 'CDA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 37, '昌都地区', 'Changdoudiqu', 'CDDQ', 'CDU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 38, '昌吉', 'Changji', 'CJ', 'CHJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 39, '长春', 'Changchun', 'CC', 'CGQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 40, '长葛', 'Zhangge', 'ZG', 'CGE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 41, '长沙', 'Changsha', 'CS', 'CSX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 42, '长治', 'Changzhi', 'CZ', 'CIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 43, '常德', 'Changde', 'CD', 'CGD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 44, '常宁', 'Changning', 'CN', 'CHN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 45, '常熟', 'Changshu', 'CS', 'CHS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 46, '常州', 'Changzhou', 'CZ', 'CZX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 47, '巢湖', 'Chaohu', 'CH', 'CHU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 48, '朝阳', 'Zhaoyang', 'ZY', 'CHG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 49, '潮阳', 'Chaoyang', 'CY', 'CHY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 50, '潮州', 'Chuzhou', 'CZ', 'CZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 51, '郴州', 'Chenzhou', 'CZ', 'CEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 52, '成都', 'Chengdu', 'CD', 'CTU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 53, '承德', 'Chengde', 'CD', 'CHD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 54, '澄海', 'Chenghai', 'CH', 'CHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 55, '池州', 'Chizhou', 'CZ', 'CZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 56, '赤壁', 'Chibi', 'CB', 'CHB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 57, '赤峰', 'Chifeng', 'CF', 'CIF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 58, '崇州', 'Chenzhou', 'CZ', 'CHZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 59, '滁州', 'Chuzhou', 'CZ', 'CUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 60, '楚雄', 'Chuxiong', 'CX', 'CHX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 61, '慈溪', 'Cixi', 'CX', 'CIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 62, '从化', 'Chaohu', 'CH', 'COH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 63, '达州', 'Dazhou', 'DZ', 'DZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 64, '大安', 'Daan', 'DA', 'DAA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 65, '大丰', 'Dafeng', 'DF', 'DAF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 66, '大理', 'Dali', 'DDL', 'DLU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 67, '大连', 'Dalian', 'DL', 'DLC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 68, '大庆', 'Daqing', 'DQ', 'DAQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 69, '大同', 'Datong', 'DT', 'DAT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 70, '大兴安岭', 'Daxian', 'DX', 'DAX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 71, '大冶', 'Daye', 'DY', 'DYE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 72, '丹东', 'Dandong', 'DD', 'DDG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 73, '丹江口', 'Danjiangkou', 'DJK', 'DAJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 74, '丹阳', 'Danyang', 'DY', 'DYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 75, '儋州', 'Danzhou', 'DZ', 'DAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 76, '当阳', 'Danyang', 'DY', 'DAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 77, '德令哈', 'Delingha', 'DLH', 'DEL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 78, '德阳', 'Deyang', 'DY', 'DEY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 79, '德州', 'Dezhou', 'DZ', 'DZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 80, '登封', 'Dengfeng', 'DF', 'DEF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 81, '邓州', 'Jiaozhou', 'DZ', 'DEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 82, '迪庆', 'Diqing', 'DQ', 'DIG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 83, '迪庆州', 'Diqingzhou', 'DQZ', 'DIQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 84, '定西', 'Dingxi', 'DX', 'DXN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 85, '定西地区', 'Dingxidiqu', 'DXDQ', 'DIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 86, '东台', 'Dongtai', 'DT', 'DOT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 87, '东莞', 'Dongguan', 'DG', 'DGM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 88, '东兴', 'Dongxing', 'DX', 'DOX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 89, '东阳', 'Dongyang', 'DY', 'DYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 90, '东营', 'Dongyin', 'DY', 'DOY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 91, '都江堰', 'Doujiangyan', 'DJY', 'DOJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 92, '都匀', 'Douyun', 'DY', 'DUJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 93, '敦化', 'Dunhua', 'DH', 'DUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 94, '敦煌', 'Dunhuang', 'DH', 'DNH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 95, '峨眉山', 'Emeishan', 'EMS', 'EMS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 96, '鄂尔多斯', 'Eerduosi', 'EEDS', 'ERD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 97, '鄂州', 'Ezhou', 'EZ', 'EZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 98, '恩平', 'Enping', 'EP', 'ENP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 99, '恩施', 'Enshi', 'ES', 'ENH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 100, '二连浩特', 'Erlianhaote', 'ELHT', 'ERL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 101, '番禺', 'Fanyu', 'FY', 'PAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 102, '防城港', 'Fangchenggang', 'FCG', 'FAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 103, '丰城', 'Fengcheng', 'FC', 'FEC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 104, '奉化', 'Fenghua', 'FH', 'FEH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 105, '佛山', 'Foshan', 'FS', 'FUO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 106, '福安', 'Fuan', 'FA', 'FUA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 107, '福鼎', 'Fuding', 'FD', 'FUD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 108, '福清', 'Fuqing', 'FQ', 'FUQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 109, '福州', 'Fuzhou', 'FZ', 'FOC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 110, '抚顺', 'Fushun', 'FS', 'FUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 111, '抚州', 'Wuzhou', 'FZ', 'FUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 112, '阜康', 'Fukang', 'FK', 'FUK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 113, '阜新', 'Fuxin', 'FX', 'FUX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 114, '阜阳', 'Fuyang', 'FY', 'FUG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 115, '富阳', 'Fuyang', 'FY', 'FUY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 116, '甘孜州', 'Ganzizhou', 'GZZ', 'GAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 117, '赣州', 'Ganzhou', 'GZ', 'GZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 118, '高明', 'Gaoming', 'GM', 'GAM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 119, '高邮', 'Gaoyou', 'GY', 'GAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 120, '藁城', 'Gaocheng', 'GC', 'GAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 121, '格尔木', 'Geermu', 'GEM', 'GOQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 122, '个旧', 'Gejiu', 'GJ', 'GEJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 123, '巩义', 'Gongyi', 'GY', 'GOY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 124, '广安', 'Guangan', 'GA', 'GUA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 125, '广汉', 'Guanghan', 'GH', 'GHN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 126, '广水', 'Guangshui', 'GS', 'GUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 127, '广元', 'Guangyuan', 'GY', 'GUY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 128, '广州', 'Guangzhou', 'GZ', 'CAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 129, '贵港', 'Guigang', 'GG', 'GUG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 130, '贵溪', 'Guixi', 'GX', 'GUX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 131, '贵阳', 'Guiyang', 'GY', 'KWE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 132, '桂林', 'Guilin', 'GL', 'KWL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 133, '桂平', 'Guiping', 'GP', 'GUP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 134, '哈尔滨', 'Haerbin', 'HEB', 'HRB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 135, '哈密', 'Hami', 'HM', 'HMI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 136, '海东', 'Haidong', 'HD', 'HDO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 137, '海东地区', 'Haidongdiqu', 'HDDQ', 'HAD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 138, '海口', 'Haikou', 'HK', 'HAK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 139, '海林', 'Hailin', 'HL', 'HAL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 140, '海门', 'Haimen', 'HM', 'HAM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 141, '海南州', 'Huian', 'HA', 'HAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 142, '海宁', 'Haining', 'HN', 'HAI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 143, '邯郸', 'Handan', 'HD', 'HDN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 144, '韩城', 'Hancheng', 'HC', 'HAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 145, '汉川', 'Hechi', 'HC', 'HCH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 146, '汉中', 'Hanzhong', 'HZ', 'HZG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 147, '杭州', 'Hangzhou', 'HZ', 'HGH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 148, '合肥', 'Hefei', 'HF', 'HFE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 149, '合作', 'Hezhou', 'HZ', 'HEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 150, '和田', 'Hetian', 'HT', 'HTN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 151, '河池', 'Hechi', 'HC', 'HEC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 152, '河源', 'Heyuan', 'HY', 'HEY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 153, '菏泽', 'Heze', 'HZ', 'HZE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 154, '贺州', 'Liping', 'LP', 'HZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 155, '鹤壁', 'Hebi', 'HB', 'HEB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 156, '鹤岗', 'Hegang', 'HG', 'HEG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 157, '鹤山', 'Heshan', 'HS', 'HSH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 158, '黑河', 'Heihe', 'HH', 'HEK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 159, '衡水', 'Hengshui', 'HS', 'HSU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 160, '衡阳', 'Hengyang', 'HY', 'HNY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 161, '洪湖', 'Honghu', 'HH', 'HOH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 162, '侯马', 'Houma', 'HM', 'HOM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 163, '呼和浩特', 'Huhehaote', 'HHHT', 'HET', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 164, '呼伦贝尔', 'Hulunbeier', 'HLBE', 'HUL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 165, '湖州', 'Huzhou', 'HZ', 'HZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 166, '葫芦岛', 'Hailaer', 'HLE', 'HLD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 167, '虎林', 'Hulin', 'HL', 'HLI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 168, '花都', 'Huadou', 'HD', 'HDU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 169, '华甸', 'Huadian', 'HD', 'HUD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 170, '华阴', 'Huayin', 'HY', 'HYI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 171, '化州', 'Huazhou', 'HZ', 'HZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 172, '怀化', 'Huaihua', 'HH', 'HUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 173, '淮安', 'Huaian', 'HA', 'HUA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 174, '淮北', 'Huaibei', 'HB', 'HUB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 175, '淮南', 'Huizhou', 'HZ', 'HUI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 176, '黄冈', 'Huanggang', 'HG', 'HUG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 177, '黄骅', 'Huanghua', 'HH', 'HYE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 178, '黄南州', 'Huangnanzhou', 'HNZ', 'HUN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 179, '黄山', 'Huangshan', 'HS', 'TXN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 180, '海宁', 'Haining', 'HN', 'HAI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 181, '黄石', 'Huangshi', 'HS', 'HUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 182, '黄岩', 'Huangyan', 'HY', 'HYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 183, '晖春', 'Huichun', 'HC', 'HUC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 184, '惠阳', 'Huiyang', 'HY', 'HYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 185, '惠州', 'Huzhou', 'HZ', 'HUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 186, '鸡西', 'Jixi', 'JX', 'JXI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 187, '吉安', 'Jian', 'JA', 'KNC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 188, '吉林', 'Jilin', 'JL', 'JIL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 189, '吉首', 'Jishou', 'JS', 'JSH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 190, '即墨', 'Jiangmen', 'JM', 'JMO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 191, '集安', 'Jian', 'JA', 'JIA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 192, '集宁', 'Jining', 'JN', 'JIN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 193, '济南', 'Jinan', 'JN', 'TNA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 194, '济宁', 'Jining', 'JN', 'JNG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 195, '济源', 'Jiyuan', 'JY', 'JYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 196, '佳木斯', 'Jiamusi', 'JMS', 'JMU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 197, '嘉兴', 'Jiaxing', 'JX', 'JIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 198, '嘉峪关', 'Jiayuguan', 'JYG', 'JGN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 199, '建德', 'Jiangdu', 'JD', 'JID', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 200, '建瓯', 'Jimo', 'JM', 'JIO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 201, '建阳', 'Jianyang', 'JY', 'JYG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 202, '江都', 'Jiangdou', 'JD', 'JDU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 203, '江门', 'Jingmen', 'JM', 'JIM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 204, '江山', 'Jiangshan', 'JS', 'JSA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 205, '江阴', 'Jieyang', 'JY', 'JIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 206, '江油', 'Jiangyou', 'JY', 'JYO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 207, '姜堰', 'Jiangyan', 'JY', 'JAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 208, '胶南', 'Jiaonan', 'JN', 'JNA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 209, '胶州', 'Jiaozuo', 'JZ', 'JIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 210, '焦作', 'Jiaozuo', 'JZ', 'JZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 211, '蛟河', 'Jiaohe', 'JH', 'JHE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 212, '揭阳', 'Jiangyin', 'JY', 'JYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 213, '界首', 'Jiashan', 'JS', 'JIS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 214, '金昌', 'Jinchang', 'JC', 'JCH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 215, '金华', 'Jinhua', 'JH', 'JHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 216, '金坛', 'Jintan', 'JT', 'JIT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 217, '锦州', 'Jinzhou', 'JZ', 'JNZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 218, '晋城', 'Jincheng', 'JC', 'JIC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 219, '晋江', 'Jinjiang', 'JJ', 'JJA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 220, '晋中', 'Jiaozhou', 'JZ', 'JZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 221, '荆门', 'Jingmen', 'JM', 'JMN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 222, '荆州', 'Jingzhou', 'JZ', 'JZG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 223, '井冈山', 'Jingangshan', 'JGS', 'JGS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 224, '景德镇', 'Jindezhen', 'JDZ', 'JDZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 225, '景洪', 'Jinhua', 'JH', 'JIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 226, '靖江', 'Jingjiang', 'JJ', 'JIJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 227, '九江', 'Jiujiang', 'JJ', 'JIU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 228, '九寨沟', 'Jinzhou', 'JZ', 'JZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 229, '酒泉', 'Jiuquan', 'JQ', 'CHW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 230, '句容', 'Jurong', 'JR', 'JUR', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 231, '喀什', 'Kashi', 'KS', 'KHG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 232, '开封', 'Kaifeng', 'KF', 'KAF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 233, '开平', 'Kaiping', 'KP', 'KAP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 234, '开原', 'Kaiyuan', 'KY', 'KYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 235, '开远', 'Kaiyuan', 'KY', 'KAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 236, '凯里', 'Kaili', 'KL', 'KAL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 237, '克拉玛依', 'Kelamayi', 'KLMY', 'KLY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 238, '库尔勒', 'Kuerle', 'KEL', 'KRL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 239, '奎屯', 'Kuitun', 'KT', 'KUT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 240, '昆明', 'Kunming', 'KM', 'KMG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 241, '昆山', 'Kunshan', 'KS', 'KUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 242, '拉萨', 'Lasha', 'LS', 'LXA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 243, '六安', 'Liuan', 'LA', 'LAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 244, '莱芜', 'Laiwu', 'LW', 'LAW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 245, '莱阳', 'Laiyang', 'LY', 'LAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 246, '莱州', 'Laizhou', 'LZ', 'LZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 247, '兰溪', 'Lanxi', 'LX', 'LAX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 248, '兰州', 'Lanzhou', 'LZ', 'LHW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 249, '廊坊', 'Langfang', 'LF', 'LAF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 250, '阆中', 'Langzhong', 'LZ', 'LAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 251, '老河口', 'Laohekou', 'LHK', 'LAH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 252, '乐昌', 'Lechang', 'LC', 'LEC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 253, '乐清', 'Leqing', 'LQ', 'LEQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 254, '乐山', 'Leshan', 'LS', 'LSA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 255, '雷州', 'Leizhou', 'LZ', 'LEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 256, '冷水江', 'Lengshuijiang', 'LSJ', 'LES', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 257, '离石', 'Lishi', 'LS', 'LSH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 258, '丽江', 'Lijiang', 'LJ', 'LJG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 259, '丽江地区', 'Lijiangdiqu', 'LJDQ', 'LIJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 260, '丽水', 'Lishui', 'LS', 'LIS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 261, '溧阳', 'Liyang', 'LY', 'LYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 262, '连云港', 'Lianyungang', 'LYG', 'LYG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 263, '连州', 'Lianzhou', 'LZ', 'LHO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 264, '涟源', 'Lianyuan', 'LY', 'LYU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 265, '辽阳', 'Liaoyuan', 'LY', 'LIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 266, '辽源', 'Liaoyuan', 'LY', 'LIU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 267, '聊城', 'Liaocheng', 'LC', 'LCN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 268, '林芝', 'Linzhi', 'LZ', 'LZI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 269, '林芝地区', 'Liaoyang', 'LY', 'LIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 270, '林州', 'Linzhou', 'LZ', 'LZN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 271, '临安', 'Linan', 'LA', 'LIA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 272, '临沧', 'Lincang', 'LC', 'LCH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 273, '临沧地区', 'Lincangdiqu', 'LCDQ', 'LIC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 274, '临汾', 'Linfen', 'LF', 'LIF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 275, '临海', 'Longhai', 'LH', 'LHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 276, '临江', 'Linjiang', 'LJ', 'LJN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 277, '临夏', 'Linxia', 'LX', 'LIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 278, '临沂', 'Linyi', 'LY', 'LYI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 279, '灵宝', 'Lingbao', 'LB', 'LIB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 280, '凌海', 'Linhai', 'LH', 'LIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 281, '柳州', 'Liuzhou', 'LZ', 'LZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 282, '六安', 'Liuan', 'LA', 'LAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 283, '六盘水', 'Liupanshui', 'LPS', 'LIP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 284, '龙井', 'Longjing', 'LJ', 'LOJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 285, '龙口', 'Longkou', 'LK', 'LOK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 286, '龙泉', 'Longquan', 'LQ', 'LOQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 287, '龙岩', 'Longyou', 'LY', 'LOY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 288, '娄底', 'Loudi', 'LD', 'LOD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 289, '庐山', 'Lushan', 'LS', 'LUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 290, '泸州', 'Luzhou', 'LZ', 'LZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 291, '陆丰', 'Lufeng', 'LF', 'LUF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 292, '潞西', 'Luxi', 'LX', 'LUX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 293, '罗定', 'Luoding', 'LD', 'LUD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 294, '洛阳', 'Luoyang', 'LY', 'LYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 295, '漯河', 'Luohe', 'LH', 'LUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 296, '麻城', 'Aomen', 'AM', 'MAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 297, '马鞍山', 'Maanshan', 'MAS', 'MAA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 298, '满洲里', 'Manzhouli', 'MZL', 'MAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 299, '茂名', 'Maoming', 'MM', 'MAM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 300, '眉山', 'Meishan', 'MS', 'MES', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 301, '梅河口', 'Meihekou', 'MHK', 'MEH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 302, '梅州', 'Meizhou', 'MZ', 'MZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 303, '孟州', 'Meizhou', 'MZ', 'MEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 304, '米泉', 'Miquan', 'MQ', 'MIQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 305, '密山', 'Mishan', 'MS', 'MIS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 306, '绵阳', 'Mianyang', 'MY', 'MIG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 307, '绵竹', 'Mianzhu', 'MZ', 'MIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 308, '牡丹江', 'Mudanjiang', 'MDJ', 'MDG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 309, '内江', 'Neijiang', 'NJ', 'NEJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 310, '那曲', 'Naqu', 'NQ', 'NAU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 311, '那曲地区', 'Naqudiqu', 'NQDQ', 'NAQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 312, '南安', 'Nanan', 'NA', 'NAA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 313, '南昌', 'Nanchang', 'NC', 'KHN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 314, '南充', 'Nanchong', 'NC', 'NAO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 315, '南海', 'Nanhai', 'NH', 'NAH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 316, '南京', 'Nanjin', 'NJ', 'NKG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 317, '南宁', 'Nanning', 'NN', 'NNG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 318, '南平', 'Nanping', 'NP', 'NAP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 319, '南通', 'Nantong', 'NT', 'NTG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 320, '南雄', 'Nanxiong', 'NX', 'NAX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 321, '南阳', 'Nanyang', 'NY', 'NNY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 322, '宁安', 'Ningan', 'NA', 'NIA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 323, '宁波', 'Ningbo', 'NB', 'NGB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 324, '宁德', 'Ningde', 'ND', 'NID', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 325, '宁国', 'Ningguo', 'NG', 'NIG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 326, '攀枝花', 'Panzhihua', 'PZH', 'PZI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 327, '盘锦', 'Panjin', 'PJ', 'PAJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 328, '彭州', 'Pengzhou', 'PZ', 'PEZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 329, '蓬莱', 'Penglai', 'PL', 'PEL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 330, '邳州', 'Pizhou', 'PZ', 'PIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 331, '平顶山', 'Pingdingshan', 'PDS', 'PDS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 332, '平度', 'Pingdu', 'PD', 'PID', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 333, '平湖', 'Pinghu', 'PH', 'PIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 334, '平凉', 'Pingliang', 'PL', 'PIL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 335, '凭祥', 'Pingxiang', 'PX', 'PXA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 336, '萍乡', 'Pingxiang', 'PX', 'PIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 337, '莆田', 'Putian', 'PT', 'PUT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 338, '濮阳', 'Puyang', 'PY', 'PUY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 339, '普宁', 'Puning', 'PN', 'PUN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 340, '七台河', 'Qitaihe', 'QTH', 'QIT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 341, '齐齐哈尔', 'Qiqihaer', 'QQHE', 'NDG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 342, '启东', 'Qidong', 'QD', 'QID', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 343, '千岛湖', 'Qionghai', 'QH', 'QIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 344, '潜江', 'Qianjiang', 'QJ', 'QIJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 345, '钦州', 'Qinzhou', 'QZ', 'QZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 346, '秦皇岛', 'Qinghuangdao', 'QHD', 'SHP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 347, '沁阳', 'Qinyang', 'QY', 'QYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 348, '青岛', 'Qingdao', 'QD', 'TAO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 349, '青州', 'Qingzhou', 'QZ', 'QIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 350, '清远', 'Qingyuan', 'QY', 'QYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 351, '庆阳', 'Qingyang', 'QY', 'IQN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 352, '庆阳地区', 'Qingyangdiqu', 'QYDQ', 'QIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 353, '邛崃', 'Qionglai', 'QL', 'QIL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 354, '琼海', 'Qionghai', 'QH', 'QHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 355, '曲阜', 'Qufu', 'QF', 'QUF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 356, '曲靖', 'Qujing', 'QJ', 'QUJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 357, '衢州', 'Quzhou', 'QZ', 'JUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 358, '泉州', 'Quanzhou', 'QZ', 'QUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 359, '仁怀', 'Renhuai', 'RH', 'REH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 360, '任丘', 'Renqiu', 'RQ', 'REQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 361, '日喀则', 'Rikaze', 'RKZ', 'RIK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 362, '日照', 'Rizhao', 'RZ', 'RIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 363, '荣城', 'Rongcheng', 'RC', 'ROC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 364, '如皋', 'Rugao', 'RG', 'RUG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 365, '汝州', 'Ruzhou', 'RZ', 'RUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 366, '乳山', 'Rushan', 'RS', 'RUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 367, '瑞安', 'Ruian', 'RA', 'RUA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 368, '瑞丽', 'Ruili', 'RL', 'RUL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 369, '三门峡', 'Sanmenxia', 'SMX', 'SAM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 370, '三明', 'Sanming', 'SM', 'SMI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 371, '三水', 'Sanshui', 'SS', 'SAS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 372, '三亚', 'Sanya', 'SY', 'SYX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 373, '山南', 'Shaoguan', 'SG', 'SHG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 374, '山南地区', 'Shangrao', 'SR', 'SHN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 375, '汕头', 'Shantou', 'ST', 'SWA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 376, '汕尾', 'Shanwei', 'SW', 'SHW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 377, '商洛', 'Shangluo', 'SL', 'SHL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 378, '商丘', 'Shangqiu', 'SQ', 'SHQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 379, '上海', 'Shanghaihongqiao', 'SHHQ', 'SHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 380, '上饶', 'Shangrao', 'SR', 'SHR', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 381, '上虞', 'Shangyu', 'SY', 'SYU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 382, '尚志', 'Shangzhi', 'SZ', 'SZI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 383, '韶关', 'Shaoguan', 'SG', 'HSC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 384, '韶山', 'Shaoshan', 'SS', 'SHS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 385, '邵武', 'Shaowu', 'SW', 'SWU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 386, '邵阳', 'Shaoyang', 'SY', 'SYG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 387, '绍兴', 'Shaoxing', 'SX', 'SHX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 388, '深圳', 'Shenzhen', 'SZ', 'SZX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 389, '神农架林区', 'Shennongjialinqu', 'SNJLQ', 'SNJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 390, '沈阳', 'Shenyang', 'SY', 'SHE', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 391, '嵊州', 'Shengzhou', 'SZ', 'SZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 392, '十堰', 'Shaoyang', 'SY', 'SYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 393, '石河子', 'Shihezi', 'SHZ', 'SHH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 394, '石家庄', 'Shijiazhuang', 'SJZ', 'SJW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 395, '石狮', 'Shishi', 'SS', 'SHI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 396, '石首', 'Shishou', 'SS', 'SSH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 397, '舒兰', 'Shulan', 'SL', 'SLA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 398, '双鸭山', 'Shangyu', 'SY', 'SHY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 399, '顺德', 'Shunde', 'SD', 'SHD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 400, '朔州', 'Shengzhou', 'SZ', 'SHZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 401, '思茅', 'Simao', 'SM', 'SYM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 402, '四会', 'Sihui', 'SH', 'SIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 403, '四平', 'Siping', 'SP', 'SIP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 404, '松原', 'Songyuan', 'SY', 'SOY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 405, '松滋', 'Songzi', 'SZ', 'SOH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 406, '松滋宾馆', 'Suzhou', 'SZ', 'SOZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 407, '苏州', 'Suzhou', 'SZ', 'SZV', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 408, '宿迁', 'Xinyi', 'XY', 'XIQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 409, '宿州', 'Xiuzhou', 'XZ', 'XIO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 410, '绥芬河', 'Suifenhe', 'SFH', 'SUF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 411, '绥化', 'Suihua', 'SH', 'SUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 412, '随州', 'Suizhou', 'SZ', 'SUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 413, '遂宁', 'Suining', 'SN', 'SUN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 414, '塔城', 'Tacheng', 'TC', 'TCG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 415, '台山', 'Taishan', 'TS', 'TSA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 416, '台州', 'Taizhou', 'TZ', 'TAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 417, '太仓', 'Taicang', 'TC', 'TAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 418, '太原', 'Taiyuan', 'TY', 'TYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 419, '泰安', 'Taian', 'TA', 'TAA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 420, '泰兴', 'Taixing', 'TX', 'TAX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 421, '泰州', 'Taizhou', 'TZ', 'TZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 422, '唐山', 'Tangshan', 'TS', 'TAS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 423, '天长', 'Tianzhang', 'TZ', 'TIC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 424, '天津', 'Tianjin', 'TJ', 'TSN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 425, '天门', 'Tianmen', 'TM', 'TIM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 426, '天水', 'Taishun', 'TS', 'TIS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 427, '铁力', 'Tieli', 'TL', 'TLI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 428, '铁岭', 'Tieling', 'TL', 'TIL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 429, '通化', 'Tonghua', 'TH', 'TNH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 430, '通辽', 'Tongliao', 'TL', 'TGO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 431, '通什', 'Tongshi', 'TS', 'TOS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 432, '通洲', 'Tongzhou', 'TZ', 'TOZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 433, '同里', 'Tongli', 'TL', 'TOL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 434, '桐乡', 'Tongxiang', 'TX', 'TOX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 435, '铜川', 'Tongchuan', 'TC', 'TOC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 436, '铜陵', 'Tongling', 'TL', 'TOG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 437, '铜仁', 'Tongren', 'TR', 'TOR', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 438, '吐鲁番', 'Tulufan', 'TLF', 'TUL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 439, '万宁', 'Baoting', 'BT', 'WAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 440, '威海', 'Weihai', 'WH', 'WEH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 441, '潍坊', 'Weifang', 'WF', 'WEF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 442, '渭南', 'Weinan', 'WN', 'WEN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 443, '温岭', 'Wenling', 'WL', 'WEG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 444, '温蛉', 'Wenling', 'WL', 'WEL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 445, '温州', 'Wenzhou', 'WZ', 'WNZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 446, '文昌', 'Wenchang', 'WC', 'WEC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 447, '文登', 'Wendeng', 'WD', 'WED', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 448, '文山州', 'Wenshanzhou', 'WSZ', 'WES', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 449, '乌海', 'Wuhai', 'WH', 'WHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 450, '乌兰浩特', 'Wulanhaote', 'WLHT', 'HLH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 451, '乌鲁木齐', 'Wulumuqi', 'WLMQ', 'URC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 452, '无锡', 'Wuxi', 'WX', 'WUX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 453, '吴江', 'Wujiang', 'WJ', 'WJI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 454, '芜湖', 'Wuhu', 'WH', 'WHU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 455, '梧州', 'Wuzhou', 'WZ', 'WUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 456, '五指山', 'Wuzhishan', 'WZS', 'XZS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 457, '武汉', 'Wuhan', 'WH', 'WUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 458, '武进', 'Wujiang', 'WJ', 'WUJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 459, '武威', 'Wuwei', 'WW', 'WUW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 460, '武穴', 'Wuxue', 'WX', 'WXI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 461, '武夷山', 'Wuyishan', 'WYS', 'WUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 462, '西安', 'Xian', 'XA', 'SIA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 463, '西昌', 'Xichang', 'XC', 'XIC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 464, '西宁', 'Xining', 'XN', 'XNN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 465, '西双版纳', 'Xishuangbanna', 'XSBN', 'JHG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 466, '锡林浩特', 'Xilinhaote', 'XLHT', 'XIL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 467, '厦门', 'Xiamen', 'XM', 'XMN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 468, '仙桃', 'Xiantao', 'XT', 'XIA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 469, '咸宁', 'Xianning', 'XN', 'XAN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 470, '咸阳', 'Xian', 'XA', 'XIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 471, '香港', 'Xianggang', 'XG', 'HKG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 472, '香格里拉', 'Xianggelila', 'XGLL', 'XIG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 473, '湘潭', 'Xiangtan', 'XT', 'XIT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 474, '襄樊', 'Xiangfan', 'XF', 'XFN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 475, '项城', 'Xinchang', 'XC', 'XCH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 476, '孝感', 'Xiaogan', 'XG', 'XGN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 477, '忻州', 'Xinzhou', 'XZ', 'XIU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 478, '新会', 'Xinhui', 'XH', 'XIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 479, '新密', 'Xinmi', 'XM', 'XIM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 480, '新乡', 'Xinxiang', 'XX', 'XIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 481, '新沂', 'Xinyi', 'XY', 'XIN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 482, '新余', 'Xinyu', 'XY', 'XYU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 483, '信阳', 'Xinyang', 'XY', 'XYA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 484, '信宜', 'Xinyi', 'XY', 'XYI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 485, '兴城', 'Xingcheng', 'XC', 'XEN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 486, '兴义', 'Xingyi', 'XY', 'XYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 487, '邢台', 'Xingtai', 'XT', 'XNT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 488, '徐州', 'Xuzhou', 'XZ', 'XUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 489, '许昌', 'Xuchang', 'XC', 'XCA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 490, '宣城', 'Xuchang', 'XC', 'XUC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 491, '雅安', 'Yaan', 'YA', 'YAA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 492, '烟台', 'Yantai', 'YT', 'YNT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 493, '延安', 'Yanan', 'YA', 'ENY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 494, '延吉', 'Yanji', 'YJ', 'YNJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 495, '盐城', 'Yancheng', 'YC', 'YNZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 496, '兖州', 'Yanzhou', 'YZ', 'YZH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 497, '偃师', 'Yangshuo', 'YS', 'YAS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 498, '雁荡山', 'Yandangshan', 'YDS', 'YAD', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 499, '扬中', 'Yangzhong', 'YZ', 'YAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 500, '扬州', 'Yangzhou', 'YZ', 'YZO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 501, '阳春', 'Yangchun', 'YC', 'YAC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 502, '阳江', 'Yangjiang', 'YJ', 'YAJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 503, '阳泉', 'Yangquan', 'YQ', 'YAQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 504, '阳朔', 'Yangshuo', 'YS', 'YAH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 505, '伊春', 'Yichun', 'YC', 'YCH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 506, '伊宁', 'Yining', 'YN', 'YIN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 507, '仪征', 'Yizheng', 'YZ', 'YIZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 508, '宜宾', 'Yibin', 'YB', 'YBP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 509, '宜昌', 'Yichang', 'YC', 'YIH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 510, '宜春', 'Yichun', 'YC', 'YIC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 511, '宜兴', 'Yixing', 'YX', 'YIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 512, '宜州', 'Yizhou', 'YZ', 'YZU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 513, '义乌', 'Yiwu', 'YW', 'YIW', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 514, '益阳', 'Yiyang', 'YY', 'YIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 515, '银川', 'Yinchuan', 'YC', 'INC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 516, '鹰潭', 'Yingtan', 'YT', 'YIT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 517, '荥阳', 'Xianyang', 'XY', 'XYG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 518, '营口', 'Yingkou', 'YK', 'YIK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 519, '永安', 'Yongan', 'YA', 'YOA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 520, '永康', 'Yongkang', 'YK', 'YOK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 521, '永州', 'Yongzhou', 'YZ', 'YOZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 522, '余姚', 'Yuyao', 'YY', 'YUA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 523, '榆林', 'Yulin', 'YL', 'UYN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 524, '禹州', 'Yuzhou', 'YZ', 'YUZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 525, '玉林', 'Yulin', 'YL', 'YUL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 526, '玉门', 'Yumen', 'YM', 'YUM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 527, '玉树州', 'Yushu', 'YS', 'YUS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 528, '玉溪', 'Yuxi', 'YX', 'YUX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 529, '岳阳', 'Yuyao', 'YY', 'YUY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 530, '云浮', 'Yunfu', 'YF', 'YNF', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 531, '运城', 'Yuncheng', 'YC', 'YUC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 532, '枣阳', 'Zaoyang', 'ZY', 'ZAY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 533, '枣庄', 'Zaozhuang', 'ZZ', 'ZAZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 534, '扎兰屯', 'Zhalantun', 'ZLT', 'ZHL', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 535, '湛江', 'Zhanjiang', 'ZJ', 'ZHA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 536, '张家港', 'Zhangjiagang', 'ZJG', 'ZHJ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 537, '张家界', 'Zhangjiajie', 'ZJJ', 'DYG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 538, '张家口', 'Zhangjiakou', 'ZZJK', 'ZJK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 539, '张掖', 'Zhangye', 'ZY', 'ZHY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 540, '漳平', 'Zhangping', 'ZP', 'ZHP', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 541, '漳州', 'Zhouzhuang', 'ZZ', 'ZHZ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 542, '昭通', 'Shaotong', 'ZT', 'ZAT', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 543, '肇庆', 'Zhaoqing', 'ZQ', 'ZHQ', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 544, '镇江', 'Zhenjiang', 'ZJ', 'ZJA', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 545, '郑州', 'Zhengzhou', 'ZZ', 'CGO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 546, '中山', 'Zhongshan', 'ZS', 'ZIS', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 547, '钟祥', 'Zhongxiang', 'ZX', 'ZHX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 548, '重庆', 'Chongqing', 'ZQ', 'CKG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 549, '舟山', 'Zhoushanputuoshan', 'ZSPTS', 'HSN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 550, '周口', 'Zhoukou', 'ZK', 'ZHK', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 551, '周庄', 'Zhouzhuang', 'ZZ', 'ZHN', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 552, '株州', 'Zhuzhou', 'ZZ', 'ZHO', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 553, '株洲', 'Zhuzhou', 'ZZ', 'ZHC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 554, '珠海', 'Zhuhai', 'ZH', 'ZUH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 555, '诸暨', 'Zhenjiang', 'ZJ', 'ZJI', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 556, '驻马店', 'Zhumadian', 'ZMD', 'ZHM', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 557, '涿州', 'Zhuozhou', 'ZZ', 'ZHU', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 558, '资兴', 'Zixing', 'ZX', 'ZIX', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 559, '资阳', 'Ziyang', 'ZY', 'ZIY', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 560, '淄博', 'Zibo', 'ZB', 'ZIB', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 561, '自贡', 'Zigong', 'ZG', 'ZIG', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 562, '邹城', 'Zoucheng', 'ZC', 'ZOC', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 563, '遵化', 'Zunhua', 'ZH', 'ZHH', '0' ) 
 Insert Into tbl_HotelCity (ID,CityName,Spelling,SimpleSpelling,CityCode,IsHot) Values ( 564, '遵义', 'Zunyi', 'ZY', 'ZYI', '0' ) 
 
 
  SET IDENTITY_INSERT tbl_HotelCity OFF 
 
 
 go
 
 
 
 
 go
 
 SET IDENTITY_INSERT tbl_HotelCityAreas ON 
 
 
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 1, 'ANS', '西秀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 2, 'ANS', '黄果树镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 3, 'AQG', '迎江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 4, 'AQG', '大观区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 5, 'AYN', '文峰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 6, 'AYN', '北关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 7, 'AYN', '铁西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 8, 'BAD', '三坡县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 9, 'BAD', '涞源县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 10, 'BAD', '南市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 11, 'BAD', '雄县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 12, 'BAD', '涞水县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 13, 'BAD', '北市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 14, 'BAD', '高新技术产业区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 15, 'BAD', '高新开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 16, 'BAD', '新市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 17, 'BAJ', '渭滨区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 18, 'BAJ', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 19, 'BAV', '昆区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 20, 'BAV', '东河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 21, 'BAV', '九原区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 22, 'BAV', '青山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 23, 'BEX', '平山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 24, 'BEX', '明山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 25, 'BFU', '龙子湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 26, 'BFU', '禹会区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 27, 'BFU', '蚌山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 28, 'BHY', '银海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 29, 'BHY', '海城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 30, 'BIZ', '滨城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 31, 'BOZ', '谯城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 32, 'CAN', '海珠区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 33, 'CAN', '增城市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 34, 'CAN', '萝岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 35, 'CAN', '越秀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 36, 'CAN', '白云区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 37, 'CAN', '从化市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 38, 'CAN', '番禺区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 39, 'CAN', '芳村区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 40, 'CAN', '花都区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 41, 'CAN', '黄埔区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 42, 'CAN', '荔湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 43, 'CAN', '南沙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 44, 'CAN', '天河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 45, 'CAZ', '运河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 46, 'CAZ', '新华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 47, 'CEZ', '北湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 48, 'CGD', '武陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 49, 'CGO', '新郑市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 50, 'CGO', '荥阳' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 51, 'CGO', '高新技术产业开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 52, 'CGO', '管城回族区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 53, 'CGO', '二七区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 54, 'CGO', '金水区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 55, 'CGO', '中原区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 56, 'CGQ', '朝阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 57, 'CGQ', '二道区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 58, 'CGQ', '高新开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 59, 'CGQ', '绿园区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 60, 'CGQ', '南关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 61, 'CGQ', '宽城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 62, 'CHD', '双桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 63, 'CHS', '辛庄镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 64, 'CHS', '东南开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 65, 'CHS', '市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 66, 'CHS', '沙家浜镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 67, 'CHS', '虞山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 68, 'CHU', '香泉镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 69, 'CHU', '居巢区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 70, 'CHW', '肃州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 71, 'CIF', '元宝山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 72, 'CIF', '红山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 73, 'CIF', '新城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 74, 'CIX', '浒山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 75, 'CIX', '观海卫镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 76, 'CKG', '大足县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 77, 'CKG', '渝中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 78, 'CKG', '江津区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 79, 'CKG', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 80, 'CKG', '巴南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 81, 'CKG', '北碚区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 82, 'CKG', '大渡口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 83, 'CKG', '垫江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 84, 'CKG', '丰都区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 85, 'CKG', '江北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 86, 'CKG', '九龙坡区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 87, 'CKG', '南岸区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 88, 'CKG', '沙坪坝区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 89, 'CKG', '万州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 90, 'CKG', '武隆县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 91, 'CKG', '渝北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 92, 'CKG', '北部新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 93, 'CSX', '芙蓉区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 94, 'CSX', '岳麓区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 95, 'CSX', '长沙县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 96, 'CSX', '雨花区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 97, 'CSX', '天心区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 98, 'CSX', '星沙经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 99, 'CSX', '开福区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 100, 'CTU', '成华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 101, 'CTU', '蒲江县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 102, 'CTU', '武侯区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 103, 'CTU', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 104, 'CTU', '金牛区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 105, 'CTU', '锦江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 106, 'CTU', '龙泉驿区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 107, 'CTU', '青羊区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 108, 'CTU', '双流县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 109, 'CTU', '温江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 110, 'CTU', '大邑县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 111, 'CUZ', '琅琊区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 112, 'CZH', '湘桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 113, 'CZH', '潮安县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 114, 'CZX', '新北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 115, 'CZX', '武进区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 116, 'CZX', '天宁区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 117, 'CZX', '钟楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 118, 'DAT', '城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 119, 'DDG', '沿江开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 120, 'DDG', '振兴区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 121, 'DDG', '元宝区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 122, 'DDG', '商贸旅游区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 123, 'DEY', '什邡市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 124, 'DEY', '旌阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 125, 'DEY', '广汉市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 126, 'DGM', '虎门镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 127, 'DGM', '松山湖科技产业园区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 128, 'DGM', '南城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 129, 'DGM', '洪梅镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 130, 'DGM', '大朗镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 131, 'DGM', '樟木头镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 132, 'DGM', '万江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 133, 'DGM', '莞城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 134, 'DGM', '塘厦镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 135, 'DGM', '石龙镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 136, 'DGM', '石碣镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 137, 'DGM', '清溪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 138, 'DGM', '桥头镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 139, 'DGM', '黄江镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 140, 'DGM', '厚街镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 141, 'DGM', '高埗镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 142, 'DGM', '凤岗镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 143, 'DGM', '东城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 144, 'DGM', '大岭山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 145, 'DGM', '常平镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 146, 'DGM', '长安镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 147, 'DGM', '茶山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 148, 'DLC', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 149, 'DLC', '甘井子区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 150, 'DLC', '中山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 151, 'DLC', '西岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 152, 'DLC', '瓦房店区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 153, 'DLC', '旅顺口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 154, 'DLC', '沙河口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 155, 'DLC', '金州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 156, 'DLC', '金石滩国家旅游度假区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 157, 'DLU', '下关' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 158, 'DLU', '古城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 159, 'DLU', '大理' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 160, 'DNH', '市内' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 161, 'DNH', '市外' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 162, 'DOY', '东城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 163, 'DOY', '西城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 164, 'DYG', '慈利县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 165, 'DYG', '武陵源区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 166, 'DYG', '永定区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 167, 'DZO', '德城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 168, 'DZO', '经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 169, 'EMS', '山脚' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 170, 'EMS', '峨眉山市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 171, 'ENY', '宝塔区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 172, 'ERD', '康巴什新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 173, 'ERD', '东胜区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 174, 'FEH', '溪口' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 175, 'FOC', '晋安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 176, 'FOC', '鼓楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 177, 'FOC', '台江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 178, 'FOC', '仓山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 179, 'FUD', '蕉城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 180, 'FUG', '颍州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 181, 'FUG', '颍泉区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 182, 'FUO', '南海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 183, 'FUO', '三水区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 184, 'FUO', '禅城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 185, 'FUO', '高明区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 186, 'FUO', '顺德区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 187, 'FUQ', '龙田镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 188, 'FUS', '新抚区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 189, 'GUA', '华蓥市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 190, 'GUA', '广安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 191, 'GUG', '港北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 192, 'GUY', '剑阁县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 193, 'GZH', '章贡区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 194, 'HAK', '龙华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 195, 'HAK', '澄迈县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 196, 'HAK', '博鳌镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 197, 'HAK', '秀英区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 198, 'HAK', '琼山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 199, 'HAK', '美兰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 200, 'HDN', '复兴区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 201, 'HDN', '丛台区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 202, 'HEB', '淇滨区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 203, 'HET', '临河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 204, 'HET', '新城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 205, 'HET', '金桥开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 206, 'HET', '赛罕区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 207, 'HET', '玉泉区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 208, 'HET', '回民区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 209, 'HEY', '紫金县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 210, 'HEY', '源城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 211, 'HFE', '包河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 212, 'HFE', '新站开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 213, 'HFE', '瑶海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 214, 'HFE', '蜀山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 215, 'HFE', '庐阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 216, 'HFE', '经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 217, 'HGH', '余杭区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 218, 'HGH', '上城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 219, 'HGH', '萧山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 220, 'HGH', '下沙经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 221, 'HGH', '下城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 222, 'HGH', '西湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 223, 'HGH', '江干区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 224, 'HGH', '海曙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 225, 'HGH', '滨江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 226, 'HGH', '拱墅区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 227, 'HKG', '荃湾' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 228, 'HKG', '湾仔' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 229, 'HKG', '中西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 230, 'HKG', '九龙城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 231, 'HKG', '屯门' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 232, 'HKG', '东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 233, 'HKG', '葵青' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 234, 'HKG', '离岛' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 235, 'HKG', '南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 236, 'HKG', '沙田' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 237, 'HKG', '油尖旺' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 238, 'HKG', '元朗' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 239, 'HLD', '连山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 240, 'HNY', '南岳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 241, 'HNY', '石鼓区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 242, 'HNY', '雁峰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 243, 'HRB', '香坊区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 244, 'HRB', '道外区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 245, 'HRB', '松北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 246, 'HRB', '南岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 247, 'HRB', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 248, 'HRB', '动力区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 249, 'HRB', '道里区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 250, 'HSC', '曲江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 251, 'HSC', '武江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 252, 'HSC', '湛江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 253, 'HSC', '乳源县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 254, 'HSN', '朱家尖' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 255, 'HSN', '沈家门' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 256, 'HSN', '定海' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 257, 'HSN', '临城新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 258, 'HSN', '普陀山' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 259, 'HSN', '嵊泗' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 260, 'HSU', '桃城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 261, 'HUA', '经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 262, 'HUA', '清河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 263, 'HUA', '清浦区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 264, 'HUA', '洪泽县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 265, 'HUA', '楚州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 266, 'HUH', '河西新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 267, 'HUI', '田家庵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 268, 'HUS', '大冶' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 269, 'HUZ', '惠阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 270, 'HUZ', '惠城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 271, 'HUZ', '龙门县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 272, 'HUZ', '惠东县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 273, 'HUZ', '大亚湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 274, 'HUZ', '博罗县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 275, 'HZE', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 276, 'HZE', '牡丹区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 277, 'HZG', '汉台区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 278, 'HZO', '武康镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 279, 'HZO', '南浔镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 280, 'HZO', '吴兴区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 281, 'HZO', '长兴县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 282, 'INC', '兴庆区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 283, 'INC', '金凤区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 284, 'JDZ', '珠山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 285, 'JDZ', '昌江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 286, 'JGS', '莰坪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 287, 'JHA', '义乌市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 288, 'JHA', '婺城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 289, 'JHA', '武义县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 290, 'JHG', '云南省昆明' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 291, 'JHG', '景洪' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 292, 'JIL', '丰满区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 293, 'JIL', '昌邑区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 294, 'JIL', '龙潭区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 295, 'JIL', '船营区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 296, 'JIM', '北新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 297, 'JIM', '台城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 298, 'JIM', '新会区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 299, 'JIM', '蓬江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 300, 'JIM', '鹤山市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 301, 'JIU', '庐山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 302, 'JIU', '浔阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 303, 'JIX', '秀洲区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 304, 'JIX', '南湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 305, 'JMU', '向阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 306, 'JMU', '前进区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 307, 'JNA', '经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 308, 'JNG', '泗水县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 309, 'JNG', '市中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 310, 'JNG', '任城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 311, 'JNZ', '凌河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 312, 'JNZ', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 313, 'JUR', '茅山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 314, 'JUR', '句容市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 315, 'JUZ', '柯城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 316, 'JZG', '荆州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 317, 'JZG', '沙市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 318, 'JZH', '漳扎镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 319, 'JZU', '山阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 320, 'JZU', '解放区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 321, 'KAF', '金明区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 322, 'KAF', '龙亭区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 323, 'KAF', '南关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 324, 'KAF', '顺河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 325, 'KAF', '鼓楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 326, 'KAP', '长沙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 327, 'KAP', '新昌区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 328, 'KAP', '祥龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 329, 'KHN', '西湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 330, 'KHN', '青云谱区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 331, 'KHN', '青山湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 332, 'KHN', '莲塘镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 333, 'KHN', '东湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 334, 'KHN', '红谷新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 335, 'KMG', '官渡区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 336, 'KMG', '安宁市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 337, 'KMG', '盘龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 338, 'KMG', '五华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 339, 'KMG', '西山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 340, 'KUS', '周市镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 341, 'KUS', '正仪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 342, 'KUS', '张浦镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 343, 'KUS', '千灯镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 344, 'KUS', '花桥镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 345, 'KUS', '玉山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 346, 'KUS', '巴城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 347, 'KUS', '周庄镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 348, 'KUS', '昆山经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 349, 'KWE', '白云区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 350, 'KWE', '南明区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 351, 'KWE', '云岩区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 352, 'KWL', '雁山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 353, 'KWL', '兴安县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 354, 'KWL', '象山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 355, 'KWL', '西城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 356, 'KWL', '秀峰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 357, 'KWL', '七星区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 358, 'KWL', '阳朔县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 359, 'KWL', '龙胜县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 360, 'KWL', '叠彩区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 361, 'LAF', '广阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 362, 'LAF', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 363, 'LAW', '莱城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 364, 'LAW', '莱钢区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 365, 'LCN', '东昌府区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 366, 'LCN', '阳谷镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 367, 'LHW', '城关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 368, 'LHW', '七里河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 369, 'LIA', '锦城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 370, 'LIA', '昌化镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 371, 'LIS', '遂昌县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 372, 'LIS', '市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 373, 'LIS', '青田县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 374, 'LJG', '新城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 375, 'LJG', '古城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 376, 'LJG', '宁蒗县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 377, 'LOK', '东江镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 378, 'LOY', '新罗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 379, 'LSA', '山湾地区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 380, 'LSA', '市中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 381, 'LUH', '源汇区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 382, 'LUH', '经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 383, 'LUZ', '牯岭镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 384, 'LUZ', '星子县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 385, 'LXA', '城关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 386, 'LXA', '中部' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 387, 'LXA', '拉萨' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 388, 'LXA', '西部' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 389, 'LYA', '洛南新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 390, 'LYA', '涧西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 391, 'LYA', '洛龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 392, 'LYA', '西工区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 393, 'LYA', '老城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 394, 'LYG', '东海县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 395, 'LYG', '连云区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 396, 'LYG', '新浦区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 397, 'LYI', '罗庄区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 398, 'LYI', '兰山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 399, 'LYN', '溧城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 400, 'LYN', '市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 401, 'LYN', '天目湖镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 402, 'LZH', '柳北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 403, 'LZH', '城中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 404, 'LZH', '柳南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 405, 'LZO', '江阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 406, 'MAA', '雨山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 407, 'MAA', '花山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 408, 'MAM', '茂南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 409, 'MAZ', '市北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 410, 'MDG', '东安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 411, 'MDG', '西安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 412, 'MDG', '爱民区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 413, 'MFM', '路氹' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 414, 'MFM', '西部' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 415, 'MFM', '中部' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 416, 'MFM', '路环岛' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 417, 'MIG', '游仙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 418, 'MIG', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 419, 'MIG', '梓潼县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 420, 'MIG', '安县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 421, 'MZU', '梅江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 422, 'NAO', '顺庆区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 423, 'NAO', '高坪区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 424, 'NDG', '龙沙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 425, 'NDG', '铁锋区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 426, 'NEJ', '市中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 427, 'NEJ', '隆昌县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 428, 'NEJ', '东兴区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 429, 'NGB', '镇海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 430, 'NGB', '江北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 431, 'NGB', '江东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 432, 'NGB', '海曙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 433, 'NGB', '北仑区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 434, 'NGB', '鄞州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 435, 'NKG', '雨花台区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 436, 'NKG', '玄武区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 437, 'NKG', '秦淮区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 438, 'NKG', '栖霞区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 439, 'NKG', '浦口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 440, 'NKG', '六合区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 441, 'NKG', '建邺区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 442, 'NKG', '鼓楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 443, 'NKG', '白下区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 444, 'NKG', '下关区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 445, 'NKG', '江宁区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 446, 'NKG', '高淳县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 447, 'NNG', '青秀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 448, 'NNG', '西乡塘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 449, 'NNG', '江南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 450, 'NNG', '兴宁区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 451, 'NNY', '宛城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 452, 'NNY', '卧龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 453, 'NNY', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 454, 'NTG', '海安县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 455, 'NTG', '港闸区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 456, 'NTG', '崇川区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 457, 'PAJ', '兴隆台区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 458, 'PDS', '新华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 459, 'PDS', '卫东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 460, 'PEK', '顺义区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 461, 'PEK', '燕郊' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 462, 'PEK', '朝阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 463, 'PEK', '崇文区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 464, 'PEK', '大兴区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 465, 'PEK', '房山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 466, 'PEK', '门头沟区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 467, 'PEK', '东城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 468, 'PEK', '昌平区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 469, 'PEK', '丰台区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 470, 'PEK', '延庆县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 471, 'PEK', '宣武区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 472, 'PEK', '海淀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 473, 'PEK', '怀柔区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 474, 'PEK', '密云县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 475, 'PEK', '平谷区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 476, 'PEK', '三河' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 477, 'PEK', '石景山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 478, 'PEK', '通州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 479, 'PEK', '西城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 480, 'PIH', '乍浦镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 481, 'PIH', '当湖镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 482, 'PIX', '安源区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 483, 'PUT', '涵江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 484, 'PUT', '秀屿区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 485, 'PUT', '城厢区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 486, 'PUY', '华龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 487, 'PUY', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 488, 'PYO', '平遥县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 489, 'PZI', '盐边县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 490, 'PZI', '东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 491, 'QHA', '博鳌镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 492, 'QHA', '官塘' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 493, 'QIH', '千岛湖镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 494, 'QUF', '曲阜' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 495, 'QUZ', '鲤城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 496, 'QUZ', '丰泽区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 497, 'QYN', '英德' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 498, 'QYN', '阳山县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 499, 'QYN', '清城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 500, 'QYN', '清新县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 501, 'QYN', '佛冈县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 502, 'QZO', '钦南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 503, 'RIZ', '东港区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 504, 'RIZ', '东岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 505, 'RIZ', '新市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 506, 'RIZ', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 507, 'RUA', '城关镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 508, 'SAM', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 509, 'SAM', '湖滨区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 510, 'SHA', '徐汇区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 511, 'SHA', '闸北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 512, 'SHA', '杨浦区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 513, 'SHA', '松江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 514, 'SHA', '青浦区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 515, 'SHA', '普陀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 516, 'SHA', '浦东新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 517, 'SHA', '闵行区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 518, 'SHA', '卢湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 519, 'SHA', '静安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 520, 'SHA', '嘉定区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 521, 'SHA', '黄浦区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 522, 'SHA', '虹口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 523, 'SHA', '奉贤区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 524, 'SHA', '长宁区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 525, 'SHA', '宝山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 526, 'SHA', '南汇区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 527, 'SHA', '金山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 528, 'SHA', '崇明县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 529, 'SHE', '于洪区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 530, 'SHE', '铁西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 531, 'SHE', '沈河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 532, 'SHE', '和平区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 533, 'SHE', '大东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 534, 'SHE', '东陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 535, 'SHE', '皇姑区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 536, 'SHP', '南戴河' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 537, 'SHP', '秦皇岛' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 538, 'SHP', '海港区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 539, 'SHP', '北戴河' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 540, 'SHP', '昌黎县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 541, 'SHP', '山海关' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 542, 'SHP', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 543, 'SHQ', '睢阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 544, 'SHR', '广丰县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 545, 'SHR', '上饶县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 546, 'SHR', '信州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 547, 'SHR', '婺源县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 548, 'SHR', '鄱阳县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 549, 'SHR', '余干县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 550, 'SHR', '万年县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 551, 'SHR', '弋阳县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 552, 'SHR', '横峰县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 553, 'SHR', '铅山县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 554, 'SHR', '紫阳镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 555, 'SHR', '玉山县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 556, 'SHR', '晋州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 557, 'SHR', '城西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 558, 'SHS', '竹鸡村' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 559, 'SHS', '韶山冲' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 560, 'SHS', '清溪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 561, 'SHW', '红海湾经济开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 562, 'SHW', '市城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 563, 'SHX', '越城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 564, 'SHX', '柯桥镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 565, 'SHX', '绍兴县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 566, 'SIA', '雁塔区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 567, 'SIA', '莲湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 568, 'SIA', '西高新开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 569, 'SIA', '新城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 570, 'SIA', '长安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 571, 'SIA', '碑林区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 572, 'SIA', '未央区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 573, 'SIA', '临潼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 574, 'SIA', '灞桥生态区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 575, 'SJW', '新华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 576, 'SJW', '长安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 577, 'SJW', '正定县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 578, 'SJW', '裕华区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 579, 'SJW', '桥西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 580, 'SJW', '桥东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 581, 'SJW', '高新技术产业开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 582, 'SMI', '梅列区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 583, 'SMI', '永安县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 584, 'SUH', '北林区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 585, 'SUN', '船山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 586, 'SWA', '澄海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 587, 'SWA', '龙湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 588, 'SWA', '金平区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 589, 'SWA', '潮南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 590, 'SYA', '茅箭区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 591, 'SYA', '张湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 592, 'SYX', '三亚湾' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 593, 'SYX', '亚龙湾' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 594, 'SYX', '大东海' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 595, 'SYX', '市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 596, 'SYX', '三亚湾海坡开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 597, 'SYX', '河西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 598, 'SYX', '海棠湾' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 599, 'SYX', '西岛' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 600, 'SZV', '吴中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 601, 'SZV', '苏州新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 602, 'SZV', '苏州工业园区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 603, 'SZV', '金阊区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 604, 'SZV', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 605, 'SZV', '相城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 606, 'SZV', '木渎镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 607, 'SZV', '平江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 608, 'SZV', '沧浪区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 609, 'SZX', '南山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 610, 'SZX', '罗湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 611, 'SZX', '龙岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 612, 'SZX', '福田区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 613, 'SZX', '光明新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 614, 'SZX', '盐田区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 615, 'SZX', '宝安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 616, 'TAA', '泰山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 617, 'TAC', '浏家港镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 618, 'TAC', '市中心' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 619, 'TAO', '李沧区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 620, 'TAO', '市南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 621, 'TAO', '四方区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 622, 'TAO', '市北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 623, 'TAO', '城阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 624, 'TAO', '黄岛经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 625, 'TAO', '崂山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 626, 'TAS', '京唐港开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 627, 'TAS', '迁安市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 628, 'TAS', '丰南区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 629, 'TAS', '开平区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 630, 'TAS', '路北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 631, 'TAZ', '椒江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 632, 'TAZ', '黄岩区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 633, 'TAZ', '路桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 634, 'TGO', '科尔沁区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 635, 'TGO', '商业区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 636, 'TIL', '银州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 637, 'TIS', '麦积区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 638, 'TIS', '秦州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 639, 'TNA', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 640, 'TNA', '历下区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 641, 'TNA', '市中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 642, 'TNA', '槐荫区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 643, 'TNA', '章丘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 644, 'TNA', '历城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 645, 'TNA', '天桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 646, 'TOG', '铜官山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 647, 'TOG', '大通镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 648, 'TOX', '市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 649, 'TOX', '乌镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 650, 'TSA', '川岛镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 651, 'TSA', '白沙镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 652, 'TSA', '台城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 653, 'TSN', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 654, 'TSN', '武清区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 655, 'TSN', '静海县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 656, 'TSN', '塘沽区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 657, 'TSN', '大港区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 658, 'TSN', '河东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 659, 'TSN', '宝坻区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 660, 'TSN', '北辰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 661, 'TSN', '滨海新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 662, 'TSN', '东丽区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 663, 'TSN', '和平区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 664, 'TSN', '河北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 665, 'TSN', '河西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 666, 'TSN', '红桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 667, 'TSN', '南开区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 668, 'TUL', '鄯善县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 669, 'TUL', '市内' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 670, 'TXN', '休宁县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 671, 'TXN', '黄山风景区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 672, 'TXN', '黄山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 673, 'TXN', '黟县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 674, 'TXN', '屯溪区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 675, 'TXN', '徽州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 676, 'TYN', '晋源区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 677, 'TYN', '小店区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 678, 'TYN', '杏花岭区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 679, 'TYN', '迎泽区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 680, 'TYN', '尖草坪区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 681, 'TZU', '口岸镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 682, 'TZU', '海陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 683, 'URC', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 684, 'URC', '市内' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 685, 'URC', '新市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 686, 'URC', '水磨沟区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 687, 'URC', '天山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 688, 'URC', '沙依巴克区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 689, 'WAN', '兴隆旅游度假区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 690, 'WAN', '礼纪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 691, 'WEF', '潍城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 692, 'WEF', '奎文区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 693, 'WEF', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 694, 'WEH', '高技术产业开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 695, 'WEH', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 696, 'WEH', '环翠区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 697, 'WHA', '海勃湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 698, 'WHU', '镜湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 699, 'WHU', '经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 700, 'WHU', '鸠江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 701, 'WHU', '繁昌县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 702, 'WHU', '南陵县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 703, 'WJI', '七都镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 704, 'WJI', '松陵镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 705, 'WJI', '震泽镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 706, 'WJI', '芦墟镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 707, 'WNZ', '瓯海区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 708, 'WNZ', '苍南县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 709, 'WNZ', '龙湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 710, 'WNZ', '鹿城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 711, 'WUH', '黄陂区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 712, 'WUH', '洪山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 713, 'WUH', '汉阳区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 714, 'WUH', '东西湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 715, 'WUH', '青山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 716, 'WUH', '武昌区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 717, 'WUH', '硚口区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 718, 'WUH', '江岸区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 719, 'WUH', '蔡甸区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 720, 'WUH', '江汉区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 721, 'WUX', '北塘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 722, 'WUX', '锡山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 723, 'WUX', '新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 724, 'WUX', '南长区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 725, 'WUX', '惠山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 726, 'WUX', '崇安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 727, 'WUX', '滨湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 728, 'WUY', '紫阳镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 729, 'WUZ', '万秀区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 730, 'WUZ', '长洲区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 731, 'XCA', '魏都区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 732, 'XCA', '东城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 733, 'XFN', '樊城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 734, 'XIO', '墉桥区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 735, 'XIQ', '宿城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 736, 'XIT', '岳塘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 737, 'XIT', '雨湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 738, 'XIX', '牧野区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 739, 'XIX', '卫滨区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 740, 'XIX', '红旗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 741, 'XIY', '秦都区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 742, 'XMN', '翔安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 743, 'XMN', '同安区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 744, 'XMN', '集美区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 745, 'XMN', '湖里区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 746, 'XMN', '海沧区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 747, 'XMN', '思明区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 748, 'XNN', '城东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 749, 'XNN', '城中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 750, 'XNN', '城西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 751, 'XNT', '桥东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 752, 'XNT', '桥西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 753, 'XUZ', '泉山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 754, 'XUZ', '云龙区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 755, 'XUZ', '鼓楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 756, 'XYA', '浉河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 757, 'XYU', '渝水区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 758, 'YAA', '宝兴县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 759, 'YAA', '天全县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 760, 'YAA', '雨城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 761, 'YAJ', '江城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 762, 'YAJ', '阳春市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 763, 'YAJ', '海陵岛试验区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 764, 'YAJ', '阳东县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 765, 'YBP', '翠屏区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 766, 'YIC', '万载县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 767, 'YIC', '袁州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 768, 'YIH', '伍家区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 769, 'YIH', '三峡坝区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 770, 'YIH', '夷陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 771, 'YIH', '东山开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 772, 'YIH', '西陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 773, 'YIK', '站前区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 774, 'YIK', '西市区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 775, 'YIK', '鲅鱼圈经济技术开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 776, 'YIW', '稠城' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 777, 'YIW', '商贸区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 778, 'YIW', '江东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 779, 'YIX', '宜城镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 780, 'YIY', '赫山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 781, 'YNT', '莱山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 782, 'YNT', '芝罘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 783, 'YNT', '长岛县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 784, 'YNT', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 785, 'YNZ', '亭湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 786, 'YUL', '玉州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 787, 'YUY', '岳阳开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 788, 'YUY', '岳阳楼区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 789, 'YZO', '汶河区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 790, 'YZO', '维扬区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 791, 'YZO', '邗江区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 792, 'YZO', '广陵区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 793, 'ZAZ', '薛城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 794, 'ZAZ', '滕州市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 795, 'ZAZ', '市中区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 796, 'ZHA', '坡头区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 797, 'ZHA', '赤坎区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 798, 'ZHA', '霞山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 799, 'ZHA', '开发区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 800, 'ZHJ', '市内' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 801, 'ZHJ', '杨舍镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 802, 'ZHJ', '金港镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 803, 'ZHJ', '大新镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 804, 'ZHM', '驿城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 805, 'ZHO', '芦淞区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 806, 'ZHO', '荷塘区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 807, 'ZHO', '天元区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 808, 'ZHO', '石峰区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 809, 'ZHQ', '鼎湖区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 810, 'ZHQ', '德庆县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 811, 'ZHQ', '封开县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 812, 'ZHQ', '端州区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 813, 'ZHQ', '高要市' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 814, 'ZHZ', '龙文区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 815, 'ZHZ', '东山岛' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 816, 'ZHZ', '芗城区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 817, 'ZHZ', '东山县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 818, 'ZIB', '周村区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 819, 'ZIB', '临淄区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 820, 'ZIB', '博山区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 821, 'ZIB', '张店区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 822, 'ZIG', '自流井区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 823, 'ZIG', '高新区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 824, 'ZIS', '小榄镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 825, 'ZIS', '东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 826, 'ZIS', '三角镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 827, 'ZIS', '三乡镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 828, 'ZIS', '沙溪镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 829, 'ZIS', '石岐区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 830, 'ZIS', '坦洲镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 831, 'ZIS', '五桂山镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 832, 'ZIS', '西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 833, 'ZIS', '古镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 834, 'ZIS', '南头镇' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 835, 'ZJK', '桥东区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 836, 'ZJK', '桥西区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 837, 'ZJK', '崇礼县' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 838, 'ZJK', '宣化区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 839, 'ZUH', '金湾区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 840, 'ZUH', '拱北区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 841, 'ZUH', '斗门区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 842, 'ZUH', '吉大区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 843, 'ZUH', '香洲区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 844, 'ZYI', '红花岗区' )
 Insert Into tbl_HotelCityAreas (Id,CityCode,AreaName) Values ( 845, 'ZYI', '怀仁市' )
 
 
 SET IDENTITY_INSERT tbl_HotelCityAreas OFF 
 
 go
 
 
 
 
 go
 
 SET IDENTITY_INSERT tbl_HotelLandMarks ON 
 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 412, '安康机场', 'AKA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 413, '火车站', 'AKA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 414, '火车站', 'ANJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 415, '黄果树景区', 'ANS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 416, '火车站', 'ANS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 417, '市区', 'ANS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 418, '火车站', 'AOG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 419, '火车站', 'AQG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 420, '火车站', 'AYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 421, '火车站', 'BAD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 422, '火车站', 'BAJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 423, '火车站', 'BAS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 424, '包头二里半机场', 'BAV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 425, '火车站', 'BAV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 426, '昆都仑区', 'BAV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 427, '青山区', 'BAV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 428, '中部地区', 'BAV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 429, '火车站', 'BDH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 430, '火车站', 'BEX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 431, '火车站', 'BFU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 432, '北海福城机场', 'BHY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 433, '海城区', 'BHY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 434, '银海地区', 'BHY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 435, '火车站', 'BOZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 436, '火车站', 'BSI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 437, '白云区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 438, '北京路步行街', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 439, '北京路步行街、海珠广场', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 440, '东圃', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 441, '东圃、经济开发区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 442, '番禺区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 443, '芳村花地湾', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 444, '广州新白云国际机场', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 445, '海珠广场', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 446, '花都区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 447, '环市东路附近', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 448, '火车东站', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 449, '火车站', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 450, '火车站、越秀公园附近', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 451, '经济开发区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 452, '萝岗', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 453, '琶洲国际会展中心附近', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 454, '其它', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 455, '沙面岛', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 456, '沙面岛、上下九步行街', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 457, '上下九步行街', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 458, '天河体育中心', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 459, '新白云国际机场', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 460, '越秀公园附近', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 461, '增城区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 462, '珠江南（河南）地区', 'CAN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 463, '火车站', 'CAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 464, '火车站', 'CEZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 465, '常德桃花源机场', 'CGD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 466, '火车站地区', 'CGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 467, '老工业基地', 'CGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 468, '商业金融中心', 'CGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 469, '郑东新区', 'CGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 470, '郑州新郑国际机场', 'CGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 471, '长春经济技术开发区', 'CGQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 472, '工业区', 'CGQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 473, '商业金融中心', 'CGQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 474, '文化教育区', 'CGQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 475, '火车站', 'CHB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 476, '火车站', 'CHD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 477, '市中心地区', 'CHJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 478, '方塔东街', 'CHS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 479, '市中心地区', 'CHS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 480, '虞山尚湖风景区', 'CHS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 481, '火车站', 'CHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 482, '火车站', 'CIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 483, '北碚区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 484, '菜园坝火车站', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 485, '长寿区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 486, '朝天门地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 487, '大渡口区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 488, '大田湾体育场', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 489, '大足县', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 490, '丰都县城', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 491, '高新技术开发区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 492, '观音桥步行街', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 493, '国际会展中心', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 494, '火车站', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 495, '江北地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 496, '江津区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 497, '解放碑地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 498, '南岸地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 499, '人民广场地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 500, '沙坪坝地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 501, '石桥铺电脑城', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 502, '武隆县城', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 503, '小梅沙）地区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 504, '盐田（大', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 505, '重庆大学老校区', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 506, '重庆江北国际机场', 'CKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 507, '长沙黄花国际机场', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 508, '贺龙体育中心地区', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 509, '火车站地区', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 510, '开福寺地区', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 511, '南城区', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 512, '文教区', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 513, '五一广场地区（市中心）', 'CSX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 514, '成都双流国际机场', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 515, '春熙路商业区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 516, '火车北站地区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 517, '火车南站地区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 518, '火车站', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 519, '机场地区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 520, '骡马市商业区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 521, '世纪城新会展商业圈', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 522, '市中心文化区', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 523, '水碾河商业圈', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 524, '太升路商业圈', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 525, '武侯祠商业圈', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 526, '一品天下商业圈', 'CTU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 527, '火车站', 'CZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 528, '山上', 'CZU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 529, '山下', 'CZU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 530, '常州奔牛机场', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 531, '常州新区', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 532, '火车站地区', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 533, '市中心火车站区域', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 534, '市中心区域', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 535, '武进高新区', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 536, '新北开发区', 'CZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 537, '高新区', 'DAQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 538, '火车站', 'DAQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 539, '亚龙湾', 'DAQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 540, '宾西街', 'DAT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 541, '大南街', 'DAT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 542, '大西街', 'DAT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 543, '火车站', 'DAT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 544, '市中心', 'DAT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 545, '火车站', 'DAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 546, '火车站', 'DDG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 547, '火车站', 'DEF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 548, '茶山镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 549, '长安镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 550, '常平镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 551, '大朗镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 552, '大岭山镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 553, '东坑镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 554, '东莞市区', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 555, '凤岗镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 556, '高埗镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 557, '洪梅镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 558, '厚街镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 559, '虎门镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 560, '黄江镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 561, '寮步镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 562, '桥头镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 563, '石碣镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 564, '石龙镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 565, '石排镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 566, '塘厦镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 567, '樟木头镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 568, '中堂镇', 'DGM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 569, '大连开发区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 570, '大连开发区、金石滩国家旅游度假区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 571, '大连周水子国际机场', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 572, '甘井子地区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 573, '海滨风景旅游度假区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 574, '火车站', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 575, '金石滩国家旅游度假区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 576, '沙河口', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 577, '沙河口、甘井子地区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 578, '商业金融中心', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 579, '商业金融中心区', 'DLC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 580, '大理机场', 'DLU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 581, '火车站', 'DLU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 582, '敦煌机场', 'DNH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 583, '东营机场', 'DOY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 584, '火车站', 'DOY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 585, '火车站', 'DYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 586, '景区', 'DYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 587, '森林公园', 'DYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 588, '市区', 'DYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 589, '索溪峪', 'DYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 590, '国际商贸城区域', 'DYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 591, '火车站', 'DZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 592, '火车站', 'DZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 593, '山脚', 'EMS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 594, '市区', 'EMS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 595, '恩施机场', 'ENH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 596, '火车站', 'ENY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 597, '延安二十里铺机场', 'ENY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 598, '火车站', 'ERD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 599, '城东地区', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 600, '福州长乐国际机场', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 601, '火车站地区', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 602, '温泉公园附近（市中心）', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 603, '五一广场附近', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 604, '西湖公园附近', 'FOC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 605, '火车站', 'FUD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 606, '阜阳西关机场', 'FUG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 607, '火车站', 'FUG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 608, '禅城区', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 609, '高明区', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 610, '火车站', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 611, '南海区', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 612, '三水区', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 613, '顺德区', 'FUO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 614, '火车站', 'FUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 615, '火车站', 'GOQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 616, '赣州黄金机场', 'GZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 617, '火车站', 'GZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 618, '火车站', 'HAI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 619, '海甸岛', 'HAK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 620, '海口美兰机场', 'HAK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 621, '市区', 'HAK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 622, '西海岸', 'HAK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 623, '火车站', 'HAM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 624, '火车站', 'HDN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 625, '火车站', 'HEB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 626, '北区', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 627, '东区', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 628, '呼和浩特白塔国际机场', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 629, '火车站', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 630, '南区', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 631, '市中心区', 'HET  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 632, '火车站', 'HEY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 633, '包河公园商业区', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 634, '合肥经济技术开发区', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 635, '合肥骆岗国际机场', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 636, '淮河路商业区（市中心）', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 637, '火车站', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 638, '火车站区域', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 639, '市中心区域', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 640, '政务文化新区', 'HFE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 641, '滨江地区', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 642, '杭州萧山机场', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 643, '黄龙体育中心', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 644, '火车城站', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 645, '火车东站', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 646, '火车站', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 647, '文教区', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 648, '武林广场附近（市中心）', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 649, '西湖景区', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 650, '萧山区', 'HGH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 651, '北角', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 652, '北角、鰂鱼涌', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 653, '大角咀 ', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 654, '大角嘴', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 655, '迪士尼景区', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 656, '红勘', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 657, '红磡', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 658, '机场', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 659, '尖沙咀', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 660, '尖沙嘴', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 661, '金钟', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 662, '九龙城', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 663, '荃湾', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 664, '沙田', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 665, '上环', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 666, '太子', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 667, '铜锣湾', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 668, '湾仔', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 669, '湾仔、铜锣湾', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 670, '旺角', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 671, '旺角、油麻地', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 672, '西环', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 673, '西九龙', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 674, '香港赤喇角机场', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 675, '新界', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 676, '油麻地', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 677, '鲗鱼涌', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 678, '中环', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 679, '中环、金钟', 'HKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 680, '火车站', 'HLD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 681, '火车站', 'HNY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 682, '高新技术开发区', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 683, '果戈里大街', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 684, '哈尔滨火车站附近', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 685, '哈尔滨太平国际机场', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 686, '红博国际会展中心', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 687, '火车站', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 688, '机场大巴乘车站', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 689, '建设街', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 690, '秋林商业区', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 691, '商业金融中心（市中心）', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 692, '省政府附近', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 693, '太阳岛', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 694, '文化教育区', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 695, '中山路', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 696, '中央大街', 'HRB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 697, '火车站', 'HSC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 698, '普陀山', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 699, '沈家门', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 700, '嵊泗列岛', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 701, '桃花岛', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 702, '舟山市(定海)', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 703, '朱家尖', 'HSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 704, '火车站', 'HSU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 705, '火车站', 'HUA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 706, '火车站', 'HUI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 707, '博罗县', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 708, '大亚湾', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 709, '惠城区', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 710, '惠东县', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 711, '惠阳区', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 712, '火车站', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 713, '龙门县', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 714, '自治区政府区域', 'HUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 715, '火车站', 'HZE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 716, '火车站', 'HZG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 717, '火车站', 'HZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 718, '火车站', 'INC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 719, '火车站', 'JDU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 720, '火车站', 'JDZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 721, '景德镇罗家机场', 'JDZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 722, '火车站', 'JGN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 723, '火车站', 'JGS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 724, '江北商业区域', 'JHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 725, '江南商业区域', 'JHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 726, '火车站', 'JHG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 727, '火车站', 'JID  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 728, '火车站', 'JIL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 729, '火车站', 'JIN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 730, '火车站', 'JIU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 731, '星子县', 'JIU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 732, '江南摩尔区域', 'JIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 733, '南湖景区', 'JIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 734, '其它', 'JIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 735, '市中心商业区', 'JIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 736, '火车站', 'JIY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 737, '火车站', 'JMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 738, '火车站', 'JMU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 739, '火车站', 'JNG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 740, '火车站', 'JNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 741, '火车站', 'JUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 742, '火车站', 'JYA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 743, '火车站', 'JYO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 744, '沟口', 'JZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 745, '火车站', 'JZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 746, '火车站', 'JZU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 747, '火车站', 'KAF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 748, '火车站', 'KAL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 749, '市中心地区', 'KHG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 750, '八一广场地区（市中心）', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 751, '抚河公园风景区', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 752, '红谷滩城市新区', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 753, '火车站地区', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 754, '青山湖风景区', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 755, '滕王阁风景区', 'KHN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 756, '市中心地区', 'KLY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 757, '翠湖地区', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 758, '火车站地区', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 759, '昆明巫家坝国际机场', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 760, '市中心商业地区', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 761, '政治文化地区', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 762, '周边地区', 'KMG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 763, '火车站', 'KNC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 764, '市中心地区', 'KRL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 765, '北部工业区', 'KUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 766, '火车站地区', 'KUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 767, '经济开发区', 'KUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 768, '市中心地区', 'KUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 769, '贵阳龙洞堡国际机场', 'KWE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 770, '火车站地区', 'KWE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 771, '甲秀楼地区', 'KWE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 772, '黔灵公园地区', 'KWE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 773, '市中心地区', 'KWE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 774, '桂林两江国际机场', 'KWL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 775, '国展中心地区', 'KWL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 776, '火车站地区', 'KWL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 777, '市中心湖景地区', 'KWL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 778, '市中心江景地区', 'KWL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 779, '火车站', 'LAF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 780, '火车站', 'LAW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 781, '火车站', 'LCN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 782, '火车站', 'LHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 783, '兰州中川机场', 'LHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 784, '七里河体育场地区', 'LHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 785, '市中心商业区', 'LHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 786, '西区', 'LHW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 787, '火车站', 'LIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 788, '火车站', 'LIF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 789, '白沙古镇', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 790, '大研古镇内', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 791, '大研古镇外', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 792, '火车站', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 793, '丽江三义机场', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 794, '泸沽湖', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 795, '束河古镇', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 796, '新城', 'LJG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 797, '火车站', 'LOD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 798, '火车站', 'LOY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 799, '火车站', 'LSA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 800, '土桥街', 'LSA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 801, '山上', 'LUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 802, '星子县', 'LUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 803, '火车站', 'LXA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 804, '拉萨贡嘎机场', 'LXA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 805, '中部', 'LXA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 806, '经济开发区', 'LYA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 807, '老城区', 'LYA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 808, '市中心区域', 'LYA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 809, '海滨度假区', 'LYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 810, '火车站', 'LYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 811, '商业金融中心区', 'LYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 812, '火车站', 'LYI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 813, '火车站', 'LZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 814, '柳州白莲机场', 'LZH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 815, '火车站', 'MAA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 816, '火车站', 'MAM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 817, '火车站', 'MAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 818, '澳门半岛', 'MFM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 819, '凼仔', 'MFM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 820, '路凼', 'MFM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 821, '路环', 'MFM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 822, '绵阳南郊机场', 'MIG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 823, '南充高坪机场', 'NAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 824, '火车站', 'NDG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 825, '火车站', 'NEJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 826, '北仑港区', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 827, '东钱湖风景区', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 828, '海曙商业区（市中心）', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 829, '火车站', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 830, '江北商业区', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 831, '江东商业区', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 832, '宁波栎社国际机场', 'NGB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 833, '城东地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 834, '夫子庙地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 835, '鼓楼地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 836, '河西奥体中心地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 837, '湖南路地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 838, '火车站地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 839, '江宁开发区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 840, '南部地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 841, '南京禄口国际机场', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 842, '山西路地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 843, '汤山温泉度假区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 844, '新街口地区（市中心）', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 845, '玄武湖景区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 846, '珍珠泉景区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 847, '中山陵地区', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 848, '珠江路电子一条街', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 849, '总统府附近', 'NKG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 850, '国际会展中心', 'NNG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 851, '火车站地区', 'NNG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 852, '南湖开发区', 'NNG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 853, '自治区政府区域', 'NNG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 854, '火车站', 'NNY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 855, '白沙古镇', 'NTG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 856, '城东南', 'NTG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 857, '火车站', 'NTG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 858, '南通汽车站', 'NTG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 859, '市中心区域', 'NTG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 860, '安贞地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 861, '奥运村商圈', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 862, '八角游乐园地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 863, '北京南苑国际机场', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 864, '北京首都国际机场、新国展地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 865, '北京站', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 866, '北京站、建国门、国贸地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 867, '北京周边度假区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 868, '崇文门商贸区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 869, '东二环工人体育场地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 870, '公主坟', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 871, '公主坟、万寿路商贸区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 872, '国贸地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 873, '国展中心地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 874, '后海地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 875, '火车站', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 876, '建国门地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 877, '金融街地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 878, '劲松', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 879, '劲松、潘家园地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 880, '马甸', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 881, '马甸地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 882, '南海区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 883, '南站地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 884, '潘家园地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 885, '前门', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 886, '前门、崇文门商贸区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 887, '上地', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 888, '上地、中关村地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 889, '首都机场', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 890, '天安门、王府井地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 891, '万寿路', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 892, '望京地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 893, '西单', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 894, '西单、金融街地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 895, '西客站地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 896, '西直门及北京展览馆地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 897, '新国展地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 898, '亚运村', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 899, '亚运村、奥运村商圈', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 900, '燕莎商业区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 901, '亦庄地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 902, '永定门', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 903, '永定门、南站地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 904, '中关村地区', 'PEK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 905, '火车站', 'PIX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 906, '火车站', 'PIZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 907, '火车站', 'PUT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 908, '火车站地区', 'PUY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 909, '火车站', 'PZI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 910, '火车站', 'QHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 911, '火车站', 'QUF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 912, '火车站', 'QUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 913, '泉州晋江机场', 'QUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 914, '火车站', 'QYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 915, '火车站', 'RIK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 916, '火车站', 'RIZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 917, '火车站', 'RUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 918, '北外滩地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 919, '曹杨', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 920, '曹杨、真如地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 921, '漕河泾开发区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 922, '打浦桥地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 923, '番禺区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 924, '虹桥地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 925, '虹桥枢纽地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 926, '沪太', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 927, '沪太、彭浦地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 928, '淮海路地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 929, '江湾', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 930, '静安寺地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 931, '南汇', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 932, '南外滩地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 933, '彭浦地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 934, '浦东机场区域', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 935, '浦东金桥地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 936, '浦东陆家嘴金融贸易区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 937, '浦东世博园区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 938, '浦东外高桥地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 939, '浦东新国际博览中心', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 940, '浦东张江地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 941, '七宝', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 942, '人民广场地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 943, '人民广场附近', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 944, '上海虹桥机场', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 945, '上海火车南站地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 946, '上海火车站地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 947, '上海浦东国际机场', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 948, '上海周边地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 949, '上海周边度假区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 950, '佘山', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 951, '蛇口（南山）地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 952, '世博园区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 953, '四川北路商业区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 954, '松江大学城', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 955, '外滩地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 956, '外滩附近', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 957, '五角场商业区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 958, '莘庄', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 959, '徐家汇', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 960, '徐家汇地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 961, '豫园', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 962, '豫园地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 963, '真如地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 964, '中山公园商业区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 965, '周边地区', 'SHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 966, '顺德区', 'SHD  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 967, '大东区', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 968, '火车站', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 969, '老工业区', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 970, '商业金融中心区', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 971, '沈阳桃仙国际机场', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 972, '太原街', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 973, '文教区', 'SHE  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 974, '火车站', 'SHI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 975, '火车站', 'SHL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 976, '火车站', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 977, '火车站区', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 978, '秦皇岛港区', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 979, '秦皇岛山海关机场', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 980, '人民广场区', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 981, '山海关区', 'SHP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 982, '火车站', 'SHR  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 983, '火车站', 'SHS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 984, '城南新区', 'SHX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 985, '火车站地区', 'SHX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 986, '柯桥', 'SHX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 987, '绍兴经济开发区', 'SHX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 988, '市中心地区', 'SHX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 989, '北部地区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 990, '东部地区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 991, '高新技术开发区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 992, '火车站', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 993, '南部地区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 994, '曲江会展区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 995, '市中心地区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 996, '西安咸阳国际机场', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 997, '西部地区', 'SIA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 998, '长安公园', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 999, '长安公园、省博物馆地区', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1000, '城西区', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1001, '火车站地区', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1002, '省博物馆地区', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1003, '石家庄正定机场', 'SJW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1004, '火车站', 'SUN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1005, '火车站', 'SUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1006, '火车站地区', 'SWA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1007, '汕头外砂机场', 'SWA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1008, '市中心区域', 'SWA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1009, '火车站', 'SYG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1010, '大东海', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1011, '火车站', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1012, '南田温泉', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1013, '三亚凤凰机场', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1014, '三亚湾', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1015, '市区', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1016, '小东海', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1017, '亚龙湾', 'SYX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1018, '北京路步行街', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1019, '观前街地区（市中心）', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1020, '海珠广场', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1021, '火车站地区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1022, '盘门地区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1023, '十全街地区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1024, '石路商业区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1025, '苏州工业园区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1026, '苏州新区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1027, '太湖风景区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1028, '万达广场', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1029, '阳澄湖旅游度假区', 'SZV  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1030, '宝安区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1031, '地王大厦附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1032, '高交会', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1033, '高交会、皇岗口岸地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1034, '华强北地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1035, '华侨城地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1036, '皇岗口岸地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1037, '科技园地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1038, '龙岗区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1039, '龙岗中心城地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1040, '罗湖地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1041, '罗湖东门步行街地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1042, '罗湖国贸大厦附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1043, '罗湖口岸、火车站附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1044, '南澳海滨度假区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1045, '蛇口（南山）地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1046, '深南东路新秀立交附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1047, '深圳宝安国际机场', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1048, '深圳大学附近地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1049, '深圳体育馆附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1050, '深圳周边度假区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1051, '天安数码城、竹子林地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1052, '西丽湖野生动物园附近', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1053, '小梅沙）地区', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1054, '盐田（大', 'SZX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1055, '红门区', 'TAA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1056, '火车站', 'TAA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1057, '泰山广场区', 'TAA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1058, '火车站', 'TAC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1059, '市中心', 'TAC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1060, '奥帆中心区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1061, '八大关景区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1062, '半岛商务中心（市政府）', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1063, '第一海滨浴场', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1064, '第一海水浴场', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1065, '黄岛经济技术开发区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1066, '火车站', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1067, '李沧商圈', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1068, '青岛流亭国际机场', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1069, '石老人风景区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1070, '市北中央商务区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1071, '市政府区（市中心）', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1072, '四方长途汽车站区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1073, '四方区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1074, '台东商圈特色旅游区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1075, '栈桥区', 'TAO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1076, '黄岩城区', 'TAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1077, '火车站', 'TAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1078, '椒江城区', 'TAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1079, '路桥城区', 'TAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1080, '通辽机场', 'TGO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1081, '火车站', 'TIL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1082, '火车站', 'TIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1083, '长途汽车总站区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1084, '高新技术开发区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1085, '洪楼广场区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1086, '火车站', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1087, '济南遥墙机场', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1088, '泉城广场商业区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1089, '人民商场商业区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1090, '市中心商业区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1091, '舜耕国际会展中心区', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1092, '植物园', 'TNA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1093, '火车站', 'TOG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1094, '火车站', 'TOL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1095, '火车站', 'TOX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1096, '北辰区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1097, '滨海国际机场地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1098, '滨海新区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1099, '滨江道', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1100, '长虹公园地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1101, '古文化街地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1102, '国际展览中心地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1103, '和平区（市中心）', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1104, '河北区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1105, '河东区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1106, '河西区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1107, '红桥区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1108, '华苑地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1109, '火车站', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1110, '梅江会展中心地区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1111, '南开区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1112, '天津滨海国际机场', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1113, '旺角', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1114, '望海楼', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1115, '小白楼商业区', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1116, '油麻地', 'TSN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1117, '市中心地区', 'TUL  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1118, '黄山屯溪国际机场', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1119, '火车站', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1120, '山脚北大门', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1121, '山脚南大门', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1122, '山上', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1123, '山下', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1124, '市区(屯溪区)', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1125, '汤口', 'TXN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1126, '长枫桥', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1127, '大营盘', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1128, '府东商业区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1129, '火车站', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1130, '建南汽车站', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1131, '宽银幕', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1132, '龙潭公园', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1133, '南部地区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1134, '山西省人大', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1135, '山西省政府', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1136, '太原东站', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1137, '太原高新技术产业开发区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1138, '太原理工大学', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1139, '太原武宿国际机场', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1140, '汤山温泉度假区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1141, '五一广场', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1142, '西部地区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1143, '漪汾桥', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1144, '迎宾汽车站', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1145, '迎泽商业区', 'TYN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1146, '经济开发区', 'TZU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1147, '北京路', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1148, '高新区', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1149, '国际博览中心地区', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1150, '开发区', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1151, '市中心地区', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1152, '乌鲁木齐地窝堡机场', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1153, '乌鲁木齐铁路局', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1154, '新疆医科大学医学院', 'URC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1155, '火车站', 'WEC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1156, '火车站', 'WED  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1157, '开发区', 'WEF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1158, '市中心', 'WEF  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1159, '北海旅游度假区', 'WEH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1160, '东海岸', 'WEH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1161, '火车站', 'WEH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1162, '市中心', 'WEH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1163, '西海岸', 'WEH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1164, '火车站', 'WHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1165, '火车站区域', 'WHU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1166, '经济技术开发区', 'WHU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1167, '镜湖广场', 'WHU  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1168, '火车站', 'WJI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1169, '火车站地区', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1170, '鹿城区', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1171, '路桥城区', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1172, '市中心地区', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1173, '温州经济开发区', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1174, '温州永强机场', 'WNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1175, '东湖高新技术开发区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1176, '光谷科技中心', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1177, '汉口火车站地区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1178, '汉口商业金融区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1179, '汉阳', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1180, '洪山广场、东湖国家旅游风景区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1181, '青山工业区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1182, '三环线', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1183, '王家墩商业区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1184, '武昌火车站地区', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1185, '武汉天河国际机场', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1186, '中南商业圈', 'WUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1187, '度假区', 'WUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1188, '市区', 'WUS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1189, '高新开发区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1190, '工业园区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1191, '惠山风景区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1192, '火车站附近地区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1193, '马山风景区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1194, '汽车南站区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1195, '汽车西站区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1196, '三阳广场(市中心)地区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1197, '太湖风景区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1198, '无锡硕放机场', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1199, '五爱广场', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1200, '锡山体育场区', 'WUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1201, '火车站', 'WUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1202, '火车站', 'XEN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1203, '火车站', 'XFN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1204, '火车站', 'XGN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1205, '火车站', 'XIC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1206, '火车站', 'XIN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1207, '市中心', 'XIN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1208, '市中心', 'XIO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1209, '火车站', 'XIT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1210, '火车站', 'XIY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1211, '白鹭洲风景区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1212, '东渡', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1213, '鼓浪屿风景区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1214, '湖里工业园区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1215, '环岛路风景区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1216, '会展中心', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1217, '火车站附近', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1218, '江头', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1219, '莲坂', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1220, '轮渡区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1221, '南普陀厦大', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1222, '松柏小区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1223, '厦门高崎国际机场', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1224, '中山路', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1225, '中山路、轮渡区', 'XMN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1226, '东部地区', 'XNN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1227, '火车站', 'XNN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1228, '市中心', 'XNN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1229, '西部地区', 'XNN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1230, '火车站', 'XNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1231, '火车站', 'XUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1232, '商业金融（市中心）区', 'XUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1233, '云龙湖景区', 'XUZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1234, '火车站', 'YAA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1235, '宜宾莱坝机场', 'YBP  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1236, '火车站', 'YIC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1237, '火车站', 'YIH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1238, '火车站', 'YIK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1239, '市中心地区', 'YIN  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1240, '火车站', 'YIT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1241, '国际商贸城及东阳市区域', 'YIW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1242, '国际商贸城区域', 'YIW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1243, '义乌市中心区域', 'YIW  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1244, '火车站', 'YIY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1245, '火车站', 'YIZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1246, '火车站', 'YNJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1247, '第二海水浴场', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1248, '第一海水浴场', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1249, '经济开发区', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1250, '莱山区', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1251, '商业中心区', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1252, '市中心地区', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1253, '烟台莱山机场', 'YNT  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1254, '火车站', 'YNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1255, '江苏盐城南洋机场', 'YNZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1256, '火车站', 'YOA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1257, '火车站', 'YOK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1258, '火车站', 'YUA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1259, '火车站', 'YUC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1260, '运城关公机场', 'YUC  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1261, '火车站', 'YUX  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1262, '火车站', 'YUY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1263, '火车站', 'YZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1264, '市中心区域', 'YZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1265, '瘦西湖风景区', 'YZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1266, '扬州新区', 'YZO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1267, '火车站', 'ZAZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1268, '火车站', 'ZHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1269, '湛江机场', 'ZHA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1270, '海城区', 'ZHJ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1271, '火车站', 'ZHM  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1272, '火车站', 'ZHO  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1273, '火车站', 'ZHQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1274, '市区', 'ZHQ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1275, '火车站', 'ZHY  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1276, '火车站', 'ZHZ  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1277, '火车站', 'ZIB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1278, '市中心', 'ZIB  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1279, '火车站', 'ZIG  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1280, '东区', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1281, '古镇', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1282, '三角镇', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1283, '三乡镇', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1284, '沙溪镇', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1285, '石岐区', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1286, '西区', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1287, '小榄镇', 'ZIS  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1288, '火车站地区', 'ZJA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1289, '南山风景区', 'ZJA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1290, '市中心地区', 'ZJA  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1291, '火车站', 'ZJI  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1292, '火车站', 'ZJK  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1293, '拱北', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1294, '火车站', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1295, '吉大', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1296, '南屏镇', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1297, '前山', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1298, '唐家', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1299, '香洲', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1300, '珠海三灶机场', 'ZUH  ' ) 
 Insert Into tbl_HotelLandMarks (Id,Por,CityCode) Values ( 1301, '火车站', 'ZYI  ' ) 
 
 SET IDENTITY_INSERT tbl_HotelLandMarks OFF 
 
 go
 
 
 
 
 
 
 
-- =============================================
-- Author:		邵权江
-- Create date: 2013-04-22
-- Description:	酒店团队定制添加
-- =============================================
CREATE PROCEDURE [dbo].[proc_HotelTourCustoms_Add]
	@UserID char(36),
	@ContacterName nvarchar(50),
	@ContacterMobile varchar(50),
	@ContacterTelephone varchar(50),
	@HotelId char(36),
	@HotelCode varchar(36),
	@HotelName nvarchar(255),
	@HotelStar tinyint,
	@CityCode varchar(5),
	@LocationAsk nvarchar(255),
	@RoomAsk nvarchar(50),
	@LiveStartDate datetime,
	@LiveEndDate datetime,
	@RoomCount int,
	@PeopleCount int,
	@BudgetMin money,
	@BudgetMax money,
	@Payment tinyint,
	@GuestType tinyint,
	@TourType tinyint,
	@OtherRemark nvarchar(500),
	@IssueTime datetime,
	@TreatState tinyint,
	@TreateTime datetime,
	@OperatorId int,
	@Source TINYINT,
	@AskListXML xml,
	@Result int output
AS
BEGIN
	DECLARE @error INT,@doc INT
	SET @error=0
	BEGIN TRANSACTION
	INSERT INTO [tbl_HotelTourCustoms]([UserID],[ContacterName],[ContacterMobile]
			,[ContacterTelephone],[HotelId],[HotelCode],[HotelName],[HotelStar]
			,[CityCode],[LocationAsk],[RoomAsk],[LiveStartDate],[LiveEndDate],[RoomCount]
			,[PeopleCount],[BudgetMin],[BudgetMax],[Payment],[GuestType],[TourType],[OtherRemark]
			,[IssueTime],[TreatState],[TreateTime],[OperatorId],[Source])
		VALUES(@UserID,@ContacterName,@ContacterMobile,@ContacterTelephone,@HotelId,@HotelCode,@HotelName,@HotelStar
			,@CityCode,@LocationAsk,@RoomAsk,@LiveStartDate,@LiveEndDate,@RoomCount
			,@PeopleCount,@BudgetMin,@BudgetMax,@Payment,@GuestType,@TourType,@OtherRemark
			,@IssueTime,@TreatState,@TreateTime,@OperatorId,@Source)
	SET @Result = @@IDENTITY
	SET @error=@error+@@ERROR
	IF(@AskListXML IS NOT NULL and @error=0)
	BEGIN
		EXEC sys.sp_xml_preparedocument @doc OUTPUT,@AskListXML
		INSERT INTO [tbl_HotelTourCustomsAsk]([TourOrderID],[AskName],[AskTime],[AskContent])
			SELECT @Result,AskName,AskTime,AskContent
			FROM OPENXML(@doc,N'/Root/HotelTourCustomsAsk',1)
			WITH(AskName nvarchar(50),AskTime DATETIME,AskContent nvarchar(2000))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	END
	IF(@error=0)
	BEGIN
		COMMIT TRANSACTION
	END
	ELSE
	BEGIN
		SET @Result=0
		ROLLBACK TRANSACTION
	END
	return @Result
END
GO

-- =============================================
-- Author:		邵权江
-- Create date: 2013-04-22
-- Description:	酒店团队定制修改
-- =============================================
CREATE PROCEDURE [dbo].[proc_HotelTourCustoms_Update]
	@Id int,
	@UserID char(36),
	@ContacterName nvarchar(50),
	@ContacterMobile varchar(50),
	@ContacterTelephone varchar(50),
	@HotelId char(36),
	@HotelCode varchar(36),
	@HotelName nvarchar(255),
	@HotelStar tinyint,
	@CityCode varchar(5),
	@LocationAsk nvarchar(255),
	@RoomAsk nvarchar(50),
	@LiveStartDate datetime,
	@LiveEndDate datetime,
	@RoomCount int,
	@PeopleCount int,
	@BudgetMin money,
	@BudgetMax money,
	@Payment tinyint,
	@GuestType tinyint,
	@TourType tinyint,
	@OtherRemark nvarchar(500),
	@IssueTime datetime,
	@TreatState tinyint,
	@TreateTime datetime,
	@OperatorId int,
	@Source TINYINT,
	@AskListXML xml,
	@Result int output
AS
BEGIN
	DECLARE @error INT,@doc INT
	SET @error=0
	BEGIN TRANSACTION
	UPDATE [tbl_HotelTourCustoms] SET [UserID] = @UserID,[HotelId] = @HotelId,[HotelCode] = @HotelCode
			,[ContacterName] = @ContacterName,[ContacterMobile] = @ContacterMobile,[ContacterTelephone] = @ContacterTelephone
			,[HotelName] = @HotelName,[HotelStar] = @HotelStar,[CityCode] = @CityCode,[LocationAsk] = @LocationAsk
			,[RoomAsk] = @RoomAsk,[LiveStartDate] = @LiveStartDate,[LiveEndDate] = @LiveEndDate,[RoomCount] = @RoomCount
			,[PeopleCount] = @PeopleCount,[BudgetMin] = @BudgetMin,[BudgetMax] = @BudgetMax,[Payment] = @Payment
			,[GuestType] = @GuestType,[TourType] = @TourType,[OtherRemark] = @OtherRemark,[IssueTime] = @IssueTime
			,[TreatState] = @TreatState,[TreateTime] = @TreateTime,[OperatorId] = @OperatorId,[Source] = @Source
		WHERE Id=@Id 
	SET @error=@error+@@ERROR
	delete from tbl_HotelTourCustomsAsk where TourOrderID=@Id 
	set @error=@error+@@error
	IF(@AskListXML IS NOT NULL and @error=0)
	BEGIN
		EXEC sys.sp_xml_preparedocument @doc OUTPUT,@AskListXML
		INSERT INTO [tbl_HotelTourCustomsAsk]([TourOrderID],[AskName],[AskTime],[AskContent])
			SELECT @Id,AskName,AskTime,AskContent
			FROM OPENXML(@doc,N'/Root/HotelTourCustomsAsk',1)
			WITH(AskName nvarchar(50),AskTime DATETIME,AskContent nvarchar(2000))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	END
	IF(@error=0)
	BEGIN
		SET @Result=1
		COMMIT TRANSACTION
	END
	ELSE
	BEGIN
		SET @Result=0
		ROLLBACK TRANSACTION
	END
	return @Result
END
GO

-- =============================================
-- Author:		邵权江
-- Create date: 2013-04-22
-- Description:	酒店团队定制删除
-- =============================================
CREATE PROCEDURE [dbo].[proc_HotelTourCustoms_Delete]
	@IDs varchar(Max),--id集合
	@Result int output --操作结果 正值1：成功 负值或0：失败
AS
BEGIN
	declare @error int
	set @Result=0
	set @error=0
	begin TRAN
	delete from tbl_HotelTourCustoms where Id IN(@IDs)
	set @error=@error+@@error
	if(@error=0)
	BEGIN	
		delete from tbl_HotelTourCustomsAsk where TourOrderID in(@IDs)
		set @error=@error+@@error
	end
	IF(@error>0)
	BEGIN
		ROLLBACK TRAN
		SET @Result=0
	END
	ELSE
	BEGIN		
		COMMIT TRAN
		SET @Result=1
	end
END




go
 
 
 --428---------
 
 --tbl_Hotel------------------------
 if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_Hotel')
            and   type = 'U')
   drop table tbl_Hotel
go

/*==============================================================*/
/* Table: tbl_Hotel                                             */
/*==============================================================*/
create table tbl_Hotel (
   HotelId              char(36)             not null,
   HotelCode            nvarchar(50)         not null,
   HotelName            nvarchar(255)        null,
   HotelNameEn          nvarchar(255)        null,
   Latitude             varchar(20)          null,
   Longitude            varchar(20)          null,
   ServiceTel           nvarchar(50)         null,
   ProvinceId           int                  not null default 0,
   CityId               int                  not null default 0,
   CountyId             int                  not null default 0,
   Address              nvarchar(255)        null,
   EnAddress            nvarchar(255)        null,
   Star                 tinyint              null,
   PostalCode           varchar(15)          null,
   OpenDate             varchar(50)          null,
   Fitment              varchar(50)          null,
   RoomQuantity         int                  not null default 0,
   Floor                int                  not null default 0,
   LongDesc             nvarchar(max)        null,
   Transport            nvarchar(255)        null,
   AdditionalCost       varchar(255)         not null default '0',
   Status               tinyint              not null default 0,
   OperatorId           int                  not null default 0,
   IssueTime            datetime             not null default getdate(),
   IsDelete             char(1)              not null default '0',
   IsHot                char(1)              not null default '0',
   IsRecommend          char(1)              not null default '0',
   CityCode             varchar(5)           not null,
   constraint PK_TBL_HOTEL primary key (HotelId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店代码',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'HotelCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称（中）',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'HotelName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称（英）',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'HotelNameEn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '纬度',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Latitude'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经度',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Longitude'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '客服电话',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'ServiceTel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'ProvinceId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'CityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '县区',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'CountyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地址',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Address'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '英文地址',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'EnAddress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '星级代码',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Star'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮编',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'PostalCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '开业时间 ',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'OpenDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '装修时间',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Fitment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间数量',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'RoomQuantity'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '楼层',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Floor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '详细描述',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'LongDesc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交通情况',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Transport'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '额外收费',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'AdditionalCost'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否热门',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'IsHot'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否推荐',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'IsRecommend'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市三字码',
   'user', @CurrentUser, 'table', 'tbl_Hotel', 'column', 'CityCode'
go

--tbl_HotelLandMark--------------------------------------------------------------------------
if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelLandMark')
            and   type = 'U')
   drop table tbl_HotelLandMark
go

/*==============================================================*/
/* Table: tbl_HotelLandMark                                     */
/*==============================================================*/
create table tbl_HotelLandMark (
   HotelId              char(36)             not null,
   LandMarkId           int                  not null default 0
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelLandMark', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标编号',
   'user', @CurrentUser, 'table', 'tbl_HotelLandMark', 'column', 'LandMarkId'
go


--tbl_HotelImg--------------------------------------------------------------------
if exists (select 1
            from  sysindexes
           where  id    = object_id('tbl_HotelImg')
            and   name  = 'IX_tbl_HotelImg_HotelId'
            and   indid > 0
            and   indid < 255)
   drop index tbl_HotelImg.IX_tbl_HotelImg_HotelId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelImg')
            and   type = 'U')
   drop table tbl_HotelImg
go

/*==============================================================*/
/* Table: tbl_HotelImg                                          */
/*==============================================================*/
create table tbl_HotelImg (
   ImgId                int                  identity,
   HotelId              char(36)             null,
   ImgCategory          tinyint              not null,
   FilePath             varchar(255)         null,
   "Desc"               nvarchar(255)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   constraint PK_TBL_HOTELIMG primary key (ImgId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片编号',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'ImgId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片类型',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'ImgCategory'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片路径',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'FilePath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片描述',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'Desc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_HotelImg', 'column', 'OperatorId'
go

/*==============================================================*/
/* Index: IX_tbl_HotelImg_HotelId                               */
/*==============================================================*/
create index IX_tbl_HotelImg_HotelId on tbl_HotelImg (
HotelId ASC
)
go

--tbl_HotelRoomType---------------------------------------------------------------
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_HotelRoomImg') and o.name = 'FK_TBL_HOTELROOMIMG_REFERENCE_TBL_HOTELROOMTYPE')
alter table tbl_HotelRoomImg
   drop constraint FK_TBL_HOTELROOMIMG_REFERENCE_TBL_HOTELROOMTYPE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('tbl_HotelRoomType')
            and   name  = 'IX_tbl_HotelRoomType_HotelId'
            and   indid > 0
            and   indid < 255)
   drop index tbl_HotelRoomType.IX_tbl_HotelRoomType_HotelId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelRoomType')
            and   type = 'U')
   drop table tbl_HotelRoomType
go

/*==============================================================*/
/* Table: tbl_HotelRoomType                                     */
/*==============================================================*/
create table tbl_HotelRoomType (
   RoomTypeId           char(36)             not null,
   HotelId              char(36)             not null,
   RoomName             nvarchar(255)        null,
   TotalNumber          int                  not null default 0,
   RoomType             tinyint              not null,
   RoomArea             nvarchar(255)        null,
   Floor                nvarchar(255)        not null default '0',
   BedType              tinyint              null,
   BedHeight            decimal              not null default 0,
   BedWidth             decimal              not null default 0,
   MaxGuestNum          int                  not null default 0,
   IsSmoking            char(1)              null,
   IsInternet           tinyint              not null default 0,
   IsInternetPrice      money                not null default 0,
   Orientation          tinyint              not null default 0,
   IsBreakfast          tinyint              not null default 0,
   IsBreakfastPrice     money                not null default 0,
   IsWindow             tinyint              not null default 0,
   IsAddBed             tinyint              null,
   IsAddBedPrice        money                null,
   Payment              tinyint              not null default 0,
   "Desc"               nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null default 0,
   IsDelete             char(1)              not null default '0',
   SortId               int                  not null default 0,
   RoomStatus           tinyint              not null default 0,
   constraint PK_TBL_HOTELROOMTYPE primary key (RoomTypeId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'RoomTypeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型名称',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'RoomName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总房间数',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'TotalNumber'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间类型',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'RoomType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型面积',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'RoomArea'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '楼层',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'Floor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '床型',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'BedType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '床长',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'BedHeight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '床宽',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'BedWidth'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型最大入住人数',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'MaxGuestNum'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否无烟',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsSmoking'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否上网',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsInternet'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '宽带费用',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsInternetPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '朝向',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'Orientation'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '早餐',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsBreakfast'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '早餐费用',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsBreakfastPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '开窗',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsWindow'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否加床',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsAddBed'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '加床价格',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsAddBedPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '支付方式',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'Payment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型描述',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'Desc'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作员',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'SortId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型状态',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomType', 'column', 'RoomStatus'
go

/*==============================================================*/
/* Index: IX_tbl_HotelRoomType_HotelId                          */
/*==============================================================*/
create index IX_tbl_HotelRoomType_HotelId on tbl_HotelRoomType (
HotelId ASC
)
go

--tbl_HotelRoomImg----------------------------------------------------------
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_HotelRoomImg') and o.name = 'FK_TBL_HOTELROOMIMG_REFERENCE_TBL_HOTELROOMTYPE')
alter table tbl_HotelRoomImg
   drop constraint FK_TBL_HOTELROOMIMG_REFERENCE_TBL_HOTELROOMTYPE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelRoomImg')
            and   type = 'U')
   drop table tbl_HotelRoomImg
go

/*==============================================================*/
/* Table: tbl_HotelRoomImg                                      */
/*==============================================================*/
create table tbl_HotelRoomImg (
   RoomImgId            int                  identity,
   RoomTypeId           char(36)             null,
   FilePath             varchar(255)         null,
   "Desc"               nvarchar(255)        null,
   constraint PK_TBL_HOTELROOMIMG primary key (RoomImgId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomImg', 'column', 'RoomImgId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomImg', 'column', 'RoomTypeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片路径',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomImg', 'column', 'FilePath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片描述',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomImg', 'column', 'Desc'
go

alter table tbl_HotelRoomImg
   add constraint FK_TBL_HOTELROOMIMG_REFERENCE_TBL_HOTELROOMTYPE foreign key (RoomTypeId)
      references tbl_HotelRoomType (RoomTypeId)
go

--tbl_HotelRoomRate--------------------------------------------------------
if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelRoomRate')
            and   type = 'U')
   drop table tbl_HotelRoomRate
go

/*==============================================================*/
/* Table: tbl_HotelRoomRate                                     */
/*==============================================================*/
create table tbl_HotelRoomRate (
   RoomRateId           int                  identity,
   HotelId              char(36)             not null,
   RoomTypeId           char(36)             not null,
   AmountPrice          money                not null default 0,
   PreferentialPrice    money                not null default 0,
   SettlementPrice      money                not null default 0,
   StartDate            datetime             not null default getdate(),
   EndDate              datetime             not null default getdate(),
   Reason               nvarchar(255)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           int                  not null default 0,
   constraint PK_TBL_HOTELROOMRATE primary key (RoomRateId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店价格编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'RoomRateId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型编号',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'RoomTypeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '销售价，税前价格+其他费用（如服务费、税）',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'AmountPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '优惠价',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'PreferentialPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '结算价',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'SettlementPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '开始日期',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'StartDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '结束日期',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'EndDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '原因',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'Reason'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加人',
   'user', @CurrentUser, 'table', 'tbl_HotelRoomRate', 'column', 'OperatorId'
go


--tbl_HotelOrder-------------------------------------------------------------------------------
if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_HotelOrder')
            and   type = 'U')
   drop table tbl_HotelOrder
go

/*==============================================================*/
/* Table: tbl_HotelOrder                                        */
/*==============================================================*/
create table tbl_HotelOrder (
   OrderId              char(36)             not null,
   HotelId              char(36)             not null,
   RoomTypeId           char(36)             not null,
   OrderCode            nvarchar(50)         not null,
   RoomCount            int                  not null default 0,
   CheckInDate          datetime             not null,
   CheckOutDate         datetime             not null,
   TotalAmount          money                not null default 0,
   ContactName          nvarchar(50)         null,
   ContactMobile        nvarchar(50)         null,
   Remark               nvarchar(max)        null,
   PaymentType          tinyint              not null default 0,
   PaymentState         tinyint              not null default 0,
   OrderState           tinyint              not null default 0,
   Source               tinyint              not null default 0,
   OperatorId           char(36)             not null,
   IssueTime            datetime             not null default getdate(),
   constraint PK_TBL_HOTELORDER primary key (OrderId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单编号（平台）',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'OrderId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店编号',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'HotelId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型编号',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'RoomTypeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单号',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'OrderCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间数',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'RoomCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '入住时间',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'CheckInDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '离店时间',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'CheckOutDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '总房价',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'TotalAmount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人姓名',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'ContactName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人手机',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'ContactMobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '支付方式',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'PaymentType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '支付状态',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'PaymentState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单状态',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'OrderState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单来源',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'Source'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作员编号',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'tbl_HotelOrder', 'column', 'IssueTime'
go




-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店添加
-- =============================================
create proc [dbo].[proc_Hotel_Add]
@HotelId char(36),
@HotelName nvarchar(255),
@HotelNameEn nvarchar(255),
@Latitude varchar(20),
@Longitude varchar(20),
@ServiceTel nvarchar(50),
@ProvinceId int,
@CityId int,
@CountyId int,
@Address nvarchar(255),
@EnAddress nvarchar(255),
@Star tinyint,
@PostalCode varchar(15),
@OpenDate varchar(50),
@Fitment varchar(50),
@RoomQuantity int,
@Floor int,
@LongDesc nvarchar(max),
@Transport nvarchar(255),
@AdditionalCost varchar(255),
@Status tinyint,
@OperatorId int,
@IsHot char(1),
@IsRecommend char(1),
@CityCode varchar(5),
@HotelLandMark xml,
@Result int output
as
begin
	declare @error int
	set @error=0
	
	begin transaction


		
	declare	@HotelCode nvarchar(50)
	declare @LiuShuiHiao int
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM tbl_Hotel
	SET @HotelCode='JD'+CONVERT(VARCHAR(8),GETDATE(),112)+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)


	INSERT INTO tbl_Hotel
           (HotelId,HotelCode,HotelName,HotelNameEn,Latitude,Longitude
           ,ServiceTel,ProvinceId,CityId,CountyId,Address,EnAddress
           ,Star,PostalCode,OpenDate,Fitment,RoomQuantity,[Floor],LongDesc
           ,Transport,AdditionalCost,Status,OperatorId,IssueTime,IsHot,IsRecommend,CityCode)
     VALUES(@HotelId, @HotelCode,@HotelName,@HotelNameEn,@Latitude,@Longitude,
           @ServiceTel,@ProvinceId,@CityId,@CountyId,@Address,@EnAddress,
           @Star,@PostalCode,@OpenDate,@Fitment,@RoomQuantity,@Floor,@LongDesc,
           @Transport,@AdditionalCost,@Status,@OperatorId,getdate(),@IsHot,@IsRecommend,@CityCode)
	set @error=@error+@@error

	if(@HotelLandMark is not null)
	begin
		declare @i int
		exec sp_xml_preparedocument @i output,@HotelLandMark
		set @error=@error+@@error

		INSERT INTO tbl_HotelLandMark(HotelId,LandMarkId)
		select @HotelId,LandMarkId from openxml(@i,'/Root/HotelLandMark')
		with(LandMarkId int)
		set @error=@error+@@error
		
		exec sp_xml_removedocument @i
		set @error=@error+@@error
	end

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end


GO


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店修改
-- =============================================
create proc [dbo].[proc_Hotel_Update]
@HotelId char(36),
@HotelName nvarchar(255),
@HotelNameEn nvarchar(255),
@Latitude varchar(20),
@Longitude varchar(20),
@ServiceTel nvarchar(50),
@ProvinceId int,
@CityId int,
@CountyId int,
@Address nvarchar(255),
@EnAddress nvarchar(255),
@Star tinyint,
@PostalCode varchar(15),
@OpenDate varchar(50),
@Fitment varchar(50),
@RoomQuantity int,
@Floor int,
@LongDesc nvarchar(max),
@Transport nvarchar(255),
@AdditionalCost varchar(255),
@Status tinyint,
@IsHot char(1),
@IsRecommend char(1),
@CityCode varchar(5),
@HotelLandMark xml,
@Result int output
as
begin
	declare @error int
	set @error=0
	BEGIN TRANSACTION

	UPDATE tbl_Hotel
	SET HotelName = @HotelName,HotelNameEn = @HotelNameEn
      ,Latitude = @Latitude,Longitude = @Longitude,ServiceTel = @ServiceTel
      ,ProvinceId = @ProvinceId,CityId = @CityId,CountyId = @CountyId
      ,Address = @Address,EnAddress = @EnAddress,Star = @Star,PostalCode = @PostalCode
      ,OpenDate = @OpenDate,Fitment = @Fitment,RoomQuantity = @RoomQuantity
      ,[Floor] = @Floor,LongDesc = @LongDesc,Transport = @Transport
	  ,AdditionalCost = @AdditionalCost,Status = @Status,IsHot=@IsHot
	  ,IsRecommend=@IsRecommend,CityCode=@CityCode
	WHERE HotelId = @HotelId
	set @error=@error+@@error

	delete from tbl_HotelLandMark where HotelId=@HotelId
	set @error=@error+@@error

	if(@HotelLandMark is not null)
	begin
		declare @i int
		exec sp_xml_preparedocument @i output,@HotelLandMark
		set @error=@error+@@error

		INSERT INTO tbl_HotelLandMark(HotelId,LandMarkId)
		select @HotelId,LandMarkId from openxml(@i,'/Root/HotelLandMark')
		with(LandMarkId int)
		set @error=@error+@@error
		
		exec sp_xml_removedocument @i
		set @error=@error+@@error
	end

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end


go

-- =============================================
-- Author:		王磊
-- Create date: 2013-04-23
-- Description:	酒店删除
-- -1：酒店存在订单 不允许删除
--	1:成功
--  0:失败
-- =============================================
create proc [dbo].[proc_Hotel_Delete]
@HotelId char(36),
@Result int output
as
begin
	declare @error int
	set @error=0
	
	if exists(select 1 from tbl_HotelOrder where HotelId=@HotelId)
	begin
		set @Result=-1
		return @Result
	end

	BEGIN transaction
	
	DELETE FROM tbl_HotelImg WHERE HotelId = @HotelId
	set @error=@error+@@error
	
	DELETE FROM tbl_HotelLandMark WHERE HotelId = @HotelId
	set @error=@error+@@error
	
	DELETE FROM tbl_HotelRoomImg WHERE RoomTypeId IN (SELECT hrt.RoomTypeId FROM tbl_HotelRoomType hrt WHERE hrt.HotelId = @HotelId)
	set @error=@error+@@error
	
	DELETE FROM tbl_HotelRoomRate WHERE HotelId = @HotelId
	set @error=@error+@@error
	
	DELETE FROM tbl_HotelRoomType WHERE HotelId = @HotelId
	set @error=@error+@@error

	delete from tbl_Hotel where HotelId=@HotelId
	set @error=@error+@@error
	
	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end

GO

-- =============================================
-- Author:		王磊
-- Create date: 2013-04-11
-- Description:	景点图片添加
-- =============================================
create proc [dbo].[proc_HotelImg_Add]
@HotelImg xml,
@Result int output
as
begin
	declare @error int
	declare @i int
	exec sp_xml_preparedocument @i output,@HotelImg
	set @error=@error+@@error

	INSERT INTO tbl_HotelImg(HotelId,ImgCategory,FilePath,[Desc],IssueTime,OperatorId)
	select HotelId,ImgCategory,FilePath,[Desc],getdate(),OperatorId
	from openxml(@i,'/Root/HotelImg')
	with(HotelId char(36),ImgCategory tinyint,FilePath varchar(255),[Desc] nvarchar(255),OperatorId char(36))
	set @error=@error+@@error

	exec sp_xml_removedocument @i
	set @error=@error+@@error
	
	if(@error<>0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end

	return @Result
end

GO


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店房型添加
-- =============================================
create proc [dbo].[proc_HotelRoomType_Add]
@RoomTypeId char(36),
@HotelId char(36),
@RoomName nvarchar(255),
@TotalNumber int,
@RoomType tinyint,
@RoomArea nvarchar(255),
@Floor nvarchar(255),
@BedType tinyint,
@BedHeight decimal(18,0),
@BedWidth decimal(18,0),
@MaxGuestNum int,
@IsSmoking char(1),
@IsInternet tinyint,
@IsInternetPrice money,
@Orientation tinyint,
@IsBreakfast tinyint,
@IsBreakfastPrice money,
@IsWindow tinyint,
@IsAddBed tinyint,
@IsAddBedPrice money,
@Payment tinyint,
@Desc nvarchar(max),
@OperatorId int,
@SortId int,
@RoomStatus tinyint,
@HotelRoomImg xml,
@Result int output
as
begin
	declare @error int
	set @error=0

	begin transaction

	INSERT INTO tbl_HotelRoomType
           (RoomTypeId,HotelId,RoomName,TotalNumber,RoomType,RoomArea,[Floor],BedType
           ,BedHeight,BedWidth,MaxGuestNum,IsSmoking,IsInternet,IsInternetPrice
           ,Orientation,IsBreakfast,IsBreakfastPrice,IsWindow,IsAddBed,IsAddBedPrice
           ,Payment,[Desc],IssueTime,OperatorId,SortId,RoomStatus)
     VALUES
           (@RoomTypeId,@HotelId,@RoomName,@TotalNumber,@RoomType,@RoomArea,@Floor,@BedType,
           @BedHeight,@BedWidth,@MaxGuestNum,@IsSmoking,@IsInternet,@IsInternetPrice,
           @Orientation,@IsBreakfast,@IsBreakfastPrice,@IsWindow,@IsAddBed,@IsAddBedPrice, 
           @Payment,@Desc,getdate(),@OperatorId,@SortId,@RoomStatus)
	set @error=@error+@@error

	if(@HotelRoomImg is not null)
	begin
		declare @i int
		exec sp_xml_preparedocument @i output,@HotelRoomImg
		set @error=@error+@@error

		INSERT INTO tbl_HotelRoomImg(RoomTypeId,FilePath,[Desc])
		SELECT @RoomTypeId,FilePath,[Desc]
		from openxml(@i,'/Root/HotelRoomImg')
		with(FilePath varchar(255),[Desc] nvarchar(255))
		set @error=@error+@@error

		exec sp_xml_removedocument @i
		set @error=@error+@@error
	end

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end
go


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店房型修改
-- =============================================
create proc [dbo].[proc_HotelRoomType_Update]
@RoomTypeId char(36),
@HotelId char(36),
@RoomName nvarchar(255),
@TotalNumber int,
@RoomType tinyint,
@RoomArea nvarchar(255),
@Floor nvarchar(255),
@BedType tinyint,
@BedHeight decimal(18,0),
@BedWidth decimal(18,0),
@MaxGuestNum int,
@IsSmoking char(1),
@IsInternet tinyint,
@IsInternetPrice money,
@Orientation tinyint,
@IsBreakfast tinyint,
@IsBreakfastPrice money,
@IsWindow tinyint,
@IsAddBed tinyint,
@IsAddBedPrice money,
@Payment tinyint,
@Desc nvarchar(max),
@OperatorId int,
@SortId int,
@RoomStatus tinyint,
@HotelRoomImg xml,
@Result int output
as
begin
	declare @error int
	set @error=0

	begin transaction

	UPDATE tbl_HotelRoomType 
	SET HotelId=@HotelId,RoomName=@RoomName,TotalNumber=@TotalNumber,RoomType= @RoomType
      ,RoomArea=@RoomArea,Floor=@Floor,BedType=@BedType,BedHeight=@BedHeight,BedWidth=@BedWidth
      ,MaxGuestNum=@MaxGuestNum,IsSmoking=@IsSmoking,IsInternet=@IsInternet
      ,IsInternetPrice= @IsInternetPrice,Orientation=@Orientation,IsBreakfast=@IsBreakfast
      ,IsBreakfastPrice=@IsBreakfastPrice,IsWindow=@IsWindow,IsAddBed=@IsAddBed
      ,IsAddBedPrice=@IsAddBedPrice,Payment=@Payment,[Desc]=@Desc,SortId=@SortId,RoomStatus=@RoomStatus
	WHERE RoomTypeId = @RoomTypeId
	set @error=@error+@@error

	delete from tbl_HotelRoomImg where RoomTypeId=@RoomTypeId
	set @error=@error+@@error

	if(@HotelRoomImg is not null)
	begin
		declare @i int
		exec sp_xml_preparedocument @i output,@HotelRoomImg
		set @error=@error+@@error

		INSERT INTO tbl_HotelRoomImg(RoomTypeId,FilePath,[Desc])
		SELECT @RoomTypeId,FilePath,[Desc]
		from openxml(@i,'/Root/HotelRoomImg')
		with(FilePath varchar(255),[Desc] nvarchar(255))
		set @error=@error+@@error

		exec sp_xml_removedocument @i
		set @error=@error+@@error
	end

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end


GO


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-25
-- Description:	酒店房型删除
-- -1:房型存在订单不允许删除
--  1:成功
--	0:失败
-- =============================================
create proc [dbo].[proc_HotelRoomType_Delete]
@RoomTypeId char(36),
@Result int output
as
begin
	declare @error int
	set @error=0
	
	if exists(select 1 from tbl_HotelOrder where RoomTypeId=@RoomTypeId)
	begin
		set @Result=-1
		return @Result
	END
	
	BEGIN transaction

	DELETE FROM tbl_HotelRoomImg WHERE RoomTypeId = @RoomTypeId
	set @error=@error+@@error
	
	DELETE FROM tbl_HotelRoomRate WHERE RoomTypeId = @RoomTypeId
	set @error=@error+@@error

	delete from tbl_HotelRoomType where RoomTypeId=@RoomTypeId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
		commit transaction
	end
	else
	begin
		set @Result=0
		rollback transaction
	end
	
	return @Result
end
GO



-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店价格的增加
-- -1:开始时间已存在价格
-- -2:结束时间已存在价格
--  1:成功
--  0:失败
-- =============================================
create proc [dbo].[proc_HotelRoomRate_Add]
@HotelId char(36),
@RoomTypeId char(36),
@AmountPrice money,
@PreferentialPrice money,
@SettlementPrice money,
@StartDate datetime,
@EndDate datetime,
@Reason nvarchar(255),
@OperatorId int,
@Result int output
as
begin
	declare @error int
	set @error=0
	
	--开始时间已存在价格
	if exists(select 1 from tbl_HotelRoomRate where RoomTypeId=@RoomTypeId and (@StartDate<=EndDate) and (@StartDate>=StartDate))
	begin
		set @Result=-1
		return @Result
	end

	--结束时间已存在价格
	if exists(select 1 from tbl_HotelRoomRate where RoomTypeId=@RoomTypeId and  (@EndDate<=EndDate) and (@EndDate>=StartDate))
	begin
		set @Result=-2
		return @Result
	end	

	INSERT INTO tbl_HotelRoomRate
           (HotelId,RoomTypeId,AmountPrice,PreferentialPrice,SettlementPrice
           ,StartDate,EndDate,Reason,IssueTime,OperatorId)
	VALUES(@HotelId,@RoomTypeId,@AmountPrice,@PreferentialPrice,@SettlementPrice,
           @StartDate,@EndDate,@Reason,getdate(),@OperatorId)
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end

go



-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店价格的修改
-- -1:开始时间已存在价格
-- -2:结束时间已存在价格
--  1:成功
--  0:失败
-- =============================================
create proc [dbo].[proc_HotelRoomRate_Update]
@RoomRateId int,
@HotelId char(36),
@RoomTypeId char(36),
@AmountPrice money,
@PreferentialPrice money,
@SettlementPrice money,
@StartDate datetime,
@EndDate datetime,
@Reason nvarchar(255),
@OperatorId int,
@Result int output
as
begin
	declare @error int
	set @error=0
	
	--开始时间已存在价格
	if exists(select 1 from tbl_HotelRoomRate where RoomTypeId=@RoomTypeId and  (@StartDate<=EndDate) and (@StartDate>=StartDate) and RoomRateId<>@RoomRateId)
	begin
		set @Result=-1
		return @Result
	end

	--结束时间已存在价格
	if exists(select 1 from tbl_HotelRoomRate where RoomTypeId=@RoomTypeId and  (@EndDate<=EndDate) and (@EndDate>=StartDate)and RoomRateId<>@RoomRateId)
	begin
		set @Result=-2
		return @Result
	end	
	--存在订单不允许修改
	if exists(select 1 from tbl_HotelOrder where IssueTime<=@EndDate and  IssueTime>=@StartDate)
	begin
		set @Result=-3
		return @Result
	end

	UPDATE tbl_HotelRoomRate
	SET HotelId = @HotelId,RoomTypeId = @RoomTypeId,AmountPrice = @AmountPrice
      ,PreferentialPrice = @PreferentialPrice,SettlementPrice = @SettlementPrice
      ,StartDate = @StartDate,EndDate = @EndDate,Reason=@Reason 
	WHERE RoomRateId=@RoomRateId

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end


GO


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-19
-- Description:	酒店价格的删除
--  -1:存在订单不允许修改
--  1:成功
--  0:失败
-- =============================================
create proc [dbo].[proc_HotelRoomRate_Delete]
@RoomRateId int,
@Result int output
as
begin
	declare @error int
	set @error=0

	declare @StartDate datetime
	declare @EndDate datetime
	
	select 	@StartDate=StartDate,@EndDate=EndDate from tbl_HotelRoomRate
	where RoomRateId=@RoomRateId

	--存在订单不允许修改
	if exists(select 1 from tbl_HotelOrder where IssueTime<=@EndDate and  IssueTime>=@StartDate)
	begin
		set @Result=-1
		return @Result
	end


	delete from tbl_HotelRoomRate where RoomRateId=@RoomRateId
	set @error=@error+@@error

	if(@error=0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end
	
	return @Result
end

GO



-- =============================================
-- Author:		邵权江
-- Create date: 2013-04-19
-- Description:	酒店订单添加
-- -1：酒店已删除或下架
-- -2：房型已删除或下架
-- -3:入住时间段存在错误价格信息
-- -4:订单预订房间数超过房型最大房间数
-- 1:成功  0:失败 
-- =============================================
create PROCEDURE [dbo].[proc_HotelOrder_Add]
@OrderId char(36),
@HotelId char(36),
@RoomTypeId char(36),
@OrderCode varchar(50),
@RoomCount int,
@CheckInDate datetime,
@CheckOutDate datetime,
@TotalAmount money,
@ContactName nvarchar(50),
@ContactMobile nvarchar(50),
@Remark nvarchar(max),
@PaymentType tinyint,
@PaymentState tinyint,
@OrderState tinyint,
@Source tinyint,
@OperatorId char(36),
@Result int output
AS
BEGIN
	DECLARE @error INT
	SET @error=0
	
	if exists(select 1 from tbl_Hotel where HotelId=@HotelId and (IsDelete='1' or Status=1))
	begin
		set @Result=-1 --酒店已删除或下架
		return @Result
	end

	if exists(select 1 from tbl_HotelRoomType where RoomTypeId=@RoomTypeId and (IsDelete='1' or RoomStatus=1))
	begin
		set @Result=-2 --房型已删除或下架
		return @Result
	end

	declare @days int
	declare @i int
	select @days=datediff(day,@CheckInDate,@CheckOutDate)
	set @i=0
	while(@i<=@days)
	begin
		--dateadd(day,@i,getdate())
		
		if not exists(select 1 from tbl_HotelRoomRate 
					  where RoomTypeId=@RoomTypeId 
					  and datediff(day,StartDate,dateadd(day,@i,getdate()))>=0 
			          and datediff(day,EndDate,dateadd(day,@i,getdate()))<=0 )
		begin
			 set @Result=-3 --入住时间段存在错误价格信息
			 break 
		end		

		set @i=@i+1
	end


	declare @orderRoomCount int
	select @orderRoomCount=sum(RoomCount) from tbl_HotelOrder 
	where HotelId=@HotelId and RoomTypeId=@RoomTypeId and OrderState in (0,3,4)

	declare @TotalRoomCount int
	select @TotalRoomCount=TotalNumber from tbl_HotelRoomType 
	where HotelId=@HotelId and RoomTypeId=@RoomTypeId

--	if(@TotalRoomCount<@orderRoomCount+@RoomCount)
--	begin
--		set @Result=-4	--订单预订房间数超过房型最大房间数
--		return @Result
--	end
	

	BEGIN TRANSACTION
	
	declare @LiuShuiHiao int
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM [tbl_HotelOrder]
	SET @OrderCode='JDO'+CONVERT(VARCHAR(8),GETDATE(),112)+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)

	INSERT INTO tbl_HotelOrder(OrderId,HotelId,RoomTypeId,OrderCode,RoomCount,
	CheckInDate,CheckOutDate,TotalAmount,ContactName,ContactMobile,Remark
	,PaymentType,PaymentState,OrderState,Source,OperatorId,IssueTime)
	VALUES(@OrderId,@HotelId,@RoomTypeId,@OrderCode,@RoomCount,@CheckInDate,
	@CheckOutDate,@TotalAmount,@ContactName,@ContactMobile,@Remark,
	@PaymentType,@PaymentState,@OrderState,@Source,@OperatorId,getdate())
	SET @error=@error+@@ERROR
	
	IF(@error=0)
	BEGIN
		SET @Result=1
		COMMIT TRANSACTION
	END
	ELSE
	BEGIN
		SET @Result=0
		ROLLBACK TRANSACTION
	END
	return @Result
END




GO




-- =============================================
-- Author:		邵权江
-- Create date: 2013-04-19
-- Description:	酒店订单添加
-- -1：酒店已删除或下架
-- -2：房型已删除或下架
-- -3:入住时间段存在错误价格信息
-- -4:订单预订房间数超过房型最大房间数
-- 1:成功  0:失败 
-- =============================================
create PROCEDURE [dbo].[proc_HotelOrder_Update]
@OrderId char(36),
@HotelId char(36),
@RoomTypeId char(36),
@OrderCode varchar(50),
@RoomCount int,
@CheckInDate datetime,
@CheckOutDate datetime,
@TotalAmount money,
@ContactName nvarchar(50),
@ContactMobile nvarchar(50),
@Remark nvarchar(max),
@PaymentType tinyint,
@PaymentState tinyint,
@OrderState tinyint,
@Source tinyint,
@OperatorId char(36),
@Result int output
AS
BEGIN
	DECLARE @error INT
	SET @error=0
	
	if exists(select 1 from tbl_Hotel where HotelId=@HotelId and (IsDelete='1' or Status=1))
	begin
		set @Result=-1 --酒店已删除或下架
		return @Result
	end

	if exists(select 1 from tbl_HotelRoomType where RoomTypeId=@RoomTypeId and (IsDelete='1' or RoomStatus=1))
	begin
		set @Result=-2 --房型已删除或下架
		return @Result
	end

	declare @days int
	declare @i int
	select @days=datediff(day,@CheckInDate,@CheckOutDate)
	set @i=0
	while(@i<=@days)
	begin
		--dateadd(day,@i,getdate())
		
		if not exists(select 1 from tbl_HotelRoomRate 
					  where RoomTypeId=@RoomTypeId 
					  and datediff(day,StartDate,dateadd(day,@i,getdate()))>=0 
			          and datediff(day,EndDate,dateadd(day,@i,getdate()))<=0 )
		begin
			 set @Result=-3 --入住时间段存在错误价格信息
			 break 
		end		

		set @i=@i+1
	end


	declare @orderRoomCount int
	select @orderRoomCount=sum(RoomCount) from tbl_HotelOrder 
	where HotelId=@HotelId and RoomTypeId=@RoomTypeId and OrderState in (0,3,4) and OrderId<>@OrderId

	declare @TotalRoomCount int
	select @TotalRoomCount=TotalNumber from tbl_HotelRoomType 
	where HotelId=@HotelId and RoomTypeId=@RoomTypeId

--	if(@TotalRoomCount<@orderRoomCount+@RoomCount)
--	begin
--		set @Result=-4	--订单预订房间数超过房型最大房间数
--		return @Result
--	end
	

	BEGIN TRANSACTION
	
	declare @LiuShuiHiao int
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM [tbl_HotelOrder]
	SET @OrderCode='JDO'+CONVERT(VARCHAR(8),GETDATE(),112)+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)

	UPDATE tbl_HotelOrder
	SET RoomCount = @RoomCount,CheckInDate = @CheckInDate,CheckOutDate = @CheckOutDate
    ,TotalAmount = @TotalAmount,ContactName = @ContactName,ContactMobile = @ContactMobile
    ,Remark = @Remark,PaymentType = @PaymentType,PaymentState = @PaymentState
    ,OrderState = @OrderState,Source = @Source
	WHERE OrderId = @OrderId

	SET @error=@error+@@ERROR
	
	IF(@error=0)
	BEGIN
		SET @Result=1
		COMMIT TRANSACTION
	END
	ELSE
	BEGIN
		SET @Result=0
		ROLLBACK TRANSACTION
	END
	return @Result
END



GO







--------------------------------------------------------------------
CREATE view [dbo].[view_Hotel]
as
SELECT A.HotelId
      ,A.HotelCode
      ,A.HotelName
      ,A.HotelNameEn
      ,A.Latitude
      ,A.Longitude
      ,A.ServiceTel
      ,A.ProvinceId
      ,A.CityId
      ,A.CountyId
      ,A.Address
      ,A.EnAddress
      ,A.Star
      ,A.PostalCode
      ,A.OpenDate
      ,A.Fitment
      ,A.RoomQuantity
      ,A.Floor
      ,A.LongDesc
      ,A.Transport
      ,A.AdditionalCost
      ,A.Status
      ,A.IssueTime
	  ,A.IsDelete
	  ,A.IsHot
	  ,A.IsRecommend
	  ,A.CityCode	
	  ,(SELECT B.RoomTypeId,B.HotelId,B.RoomName,B.TotalNumber,B.RoomType,B.RoomArea
		,B.Floor,B.BedType,B.BedHeight,B.BedWidth,B.MaxGuestNum,B.IsSmoking,B.IsInternet
		,B.IsInternetPrice,B.Orientation,B.IsBreakfast,B.IsBreakfastPrice,B.IsWindow
		,B.IsAddBed,B.IsAddBedPrice,B.Payment,B.[Desc],B.IssueTime,B.OperatorId,B.SortId,B.RoomStatus
		,C.AmountPrice,C.PreferentialPrice,C.SettlementPrice
		FROM tbl_HotelRoomType as B	left join tbl_HotelRoomRate as C
		on B.RoomTypeId=C.RoomTypeId and datediff(day,C.StartDate,getdate())>=0 and datediff(day,C.EndDate,getdate())<=0
		where B.HotelId=A.HotelId 
		and B.IsDelete='0'  for xml raw,root('Root')
	   ) 
		as HotelRoomType,
	   (
			SELECT D.ImgId,D.HotelId,D.ImgCategory,D.FilePath,D.[Desc],D.IssueTime,D.OperatorId
			FROM tbl_HotelImg as D where D.HotelId=A.HotelId for xml raw,root('Root')
		) 
		as HotelImg,
		(
			select E.HotelId,E.LandMarkId,(select Por from tbl_HotelLandMarks where Id=E.LandMarkId) as Por 
			from tbl_HotelLandMark as E
			where E.HotelId=A.HotelId for xml raw,root('Root')
		)
		as HotelLandMark
  FROM tbl_Hotel as A
  
  GO
  
 -------------------------------------------------------------
  create view [dbo].[view_HotelOrder]
as
SELECT OrderId
      ,HotelId
	  ,(select HotelName from tbl_Hotel where HotelId=tbl_HotelOrder.HotelId) as HotelName
      ,RoomTypeId
	  ,(select RoomName from tbl_HotelRoomType where RoomTypeId=tbl_HotelOrder.RoomTypeId) as RoomName
      ,OrderCode
      ,RoomCount
      ,CheckInDate
      ,CheckOutDate
      ,TotalAmount
      ,ContactName
      ,ContactMobile
      ,Remark
      ,PaymentType
      ,PaymentState
      ,OrderState
      ,Source
      ,OperatorId
	  ,(select MemberName from tbl_Member where MemberID=tbl_HotelOrder.OperatorId) as OperatorName
      ,IssueTime
  FROM tbl_HotelOrder

GO
-------------------------------------------------------------------------
create view [dbo].[view_HotelRoomRate]
as
SELECT A.RoomRateId
      ,A.HotelId
      ,A.RoomTypeId
      ,A.AmountPrice
      ,A.PreferentialPrice
      ,A.SettlementPrice
      ,A.StartDate
      ,A.EndDate
      ,A.Reason
      ,A.IssueTime
      ,A.OperatorId
	  ,B.RoomName
	  ,B.RoomType
	  ,(select HotelName from tbl_Hotel where HotelId=A.HotelId) as HotelName 
	  ,(select Realname from tbl_Webmaster where Id=A.OperatorId) as OperatorName 
  FROM tbl_HotelRoomRate as A  inner join tbl_HotelRoomType as B
  ON A.RoomTypeId=B.RoomTypeId
  
 GO
 -----------------------------------------------------------------------
 CREATE view [dbo].[view_HotelRoomType]
as
SELECT 
B.RoomTypeId,
B.HotelId,
B.RoomName,
B.TotalNumber,
B.RoomType,
B.RoomArea,
B.Floor,
B.BedType,
B.BedHeight,
B.BedWidth,
B.MaxGuestNum,
B.IsSmoking,
B.IsInternet,
B.IsInternetPrice,
B.Orientation,
B.IsBreakfast,
B.IsBreakfastPrice,
B.IsWindow,
B.IsAddBed,
B.IsAddBedPrice,
B.Payment,
B.[Desc],
B.IssueTime,
B.OperatorId,
B.SortId,
B.RoomStatus,
C.AmountPrice,
C.PreferentialPrice,
C.SettlementPrice
FROM tbl_HotelRoomType as B	inner join tbl_HotelRoomRate as C
on B.RoomTypeId=C.RoomTypeId 
where datediff(day,C.StartDate,getdate())>=0
and datediff(day,C.EndDate,getdate())<=0  and B.IsDelete='0'
GO


 

