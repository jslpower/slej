


--2013-04-11

--景区地标表 
GO
CREATE TABLE [dbo].[tbl_SystemLandMark](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Por] [nvarchar](100) NOT NULL,
	[CityId] [int] NOT NULL,
	[CityCode] [varchar](3) NOT NULL,
 CONSTRAINT [PK_TBL_SYSTEMLANDMARK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SystemLandMark', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地标名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SystemLandMark', @level2type=N'COLUMN',@level2name=N'Por'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SystemLandMark', @level2type=N'COLUMN',@level2name=N'CityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三字码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_SystemLandMark', @level2type=N'COLUMN',@level2name=N'CityCode'



--省份处理

go

delete from tbl_SysProvince

go

SET IDENTITY_INSERT tbl_SysProvince ON

 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (1,1,'A','安徽',3,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (2,1,'A','澳门',6,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (3,1,'B','北京',1,6) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (4,1,'F','福建',3,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (5,1,'G','甘肃',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (6,1,'G','广东',4,1) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (7,1,'G','广西',4,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (8,1,'G','贵州',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (9,1,'H','海南',4,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (10,1,'H','河北',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (11,1,'H','河南',4,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (12,1,'H','黑龙江',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (13,1,'H','湖北',4,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (14,1,'H','湖南',4,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (15,1,'J','吉林',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (16,1,'J','江苏',3,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (17,1,'J','江西',3,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (18,1,'L','辽宁',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (19,1,'N','内蒙古',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (20,1,'N','宁夏',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (21,1,'Q','青海',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (22,1,'S','山东',3,2) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (23,1,'S','山西',2,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (24,1,'S','陕西',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (25,1,'S','上海',1,4) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (26,1,'S','四川',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (27,1,'T','台湾',6,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (28,1,'T','天津',1,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (29,1,'X','西藏',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (30,1,'X','香港',6,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (31,1,'X','新疆',5,0) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (32,1,'Y','云南',5,3) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (33,1,'Z','浙江',3,5) 
 insert into tbl_SysProvince(ID,CountryId,HeaderLetter,Name,AreaId,SortId) values (34,1,'C','重庆',1,0)
 
 
 SET IDENTITY_INSERT tbl_SysProvince OFF 
 
 go
 
 
 --城市处理
 
 go
 
 delete from tbl_SysCity
 
 go
 
 SET IDENTITY_INSERT tbl_SysCity ON 
 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (1,1,'安庆',8,'anqing','1','anqing.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (2,1,'蚌埠',8,'bangbu','0','bangbu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (3,1,'巢湖',8,'chaohu','0','chaohu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (4,1,'池州',8,'chizhou','0','chizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (5,1,'滁州',8,'chuzhou','0','chuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (6,1,'阜阳',8,'fuyang','0','fuyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (7,1,'毫州',8,'haozhou','0','haozhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (8,1,'合肥',8,'hefei','1','hefei.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (9,1,'淮北',8,'huaibei','0','huaibei.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (10,1,'淮南',8,'huainan','0','huainan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (11,1,'黄山',8,'huangshan','0','huangshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (12,1,'六安',8,'liuan','0','liuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (13,1,'马鞍山',8,'maanshan','0','maanshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (14,1,'宿州',8,'suzhou','0','suzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (15,1,'铜陵',8,'tongling','0','tongling.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (16,1,'芜湖',8,'wuhu','0','wuhu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (17,1,'宣城',8,'xuancheng','0','xuancheng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (18,2,'澳门',18,'aomen','0','aomen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (19,3,'北京',19,'beijing','1','beijing.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (20,4,'福州',20,'fuzhou','1','fuzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (21,4,'龙岩',20,'longyan','0','longyan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (22,4,'南平',20,'nanping','0','nanping.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (23,4,'宁德',20,'ningde','0','ningde.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (24,4,'莆田',20,'putian','0','putian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (25,4,'泉州',20,'quanzhou','1','quanzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (26,4,'三明',20,'sanming','0','sanming.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (27,4,'武夷山',20,'wuyishan','0','wuyishan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (28,4,'厦门',20,'xiamen','1','xiamen.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (29,4,'漳州',20,'zhangzhou','0','zhangzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (30,5,'白银',37,'baiyin','0','baiyin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (31,5,'定西',37,'dingxi','0','dingxi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (32,5,'敦煌',37,'dunhuang','0','dunhuang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (33,5,'甘南',37,'gannan','0','gannan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (34,5,'嘉峪关',37,'jiayuguan','0','jiayuguan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (35,5,'金昌',37,'jinchang','0','jinchang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (36,5,'酒泉',37,'jiuquan','0','jiuquan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (37,5,'兰州',37,'lanzhou','0','lanzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (38,5,'临夏',37,'linxia','0','linxia.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (39,5,'陇南',37,'longnan','0','longnan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (40,5,'平凉',37,'pingliang','0','pingliang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (41,5,'庆阳',37,'qingyang','0','qingyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (42,5,'天水',37,'tianshui','0','tianshui.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (43,5,'武威',37,'wuwei','0','wuwei.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (44,5,'张掖',37,'zhangye','0','zhangye.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (45,6,'潮州',48,'chaozhou','0','chaozhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (46,6,'东莞',48,'dongwan','0','dongwan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (47,6,'佛山',48,'foshan','0','foshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (48,6,'广州',48,'guangzhou','1','guangzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (49,6,'河源',48,'heyuan','0','heyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (50,6,'惠州',48,'huizhou','0','huizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (51,6,'江门',48,'jiangmen','0','jiangmen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (52,6,'揭阳',48,'jieyang','0','jieyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (53,6,'茂名',48,'maoming','0','maoming.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (54,6,'梅州',48,'meizhou','0','meizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (55,6,'清远',48,'qingyuan','0','qingyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (56,6,'汕头',48,'shantou','0','shantou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (57,6,'汕尾',48,'shanwei','0','shanwei.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (58,6,'韶关',48,'shaoguan','0','shaoguan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (59,6,'深圳',48,'shenzhen','1','shenzhen.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (60,6,'阳江',48,'yangjiang','0','yangjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (61,6,'云浮',48,'yunfu','0','yunfu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (62,6,'湛江',48,'zhanjiang','0','zhanjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (63,6,'肇庆',48,'zhaoqing','0','zhaoqing.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (64,6,'中山',48,'zhongshan','0','zhongshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (65,6,'珠海',48,'zhuhai','0','zhuhai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (66,7,'百色',76,'baise','0','baise.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (67,7,'北海',76,'beihai','0','beihai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (68,7,'崇左',76,'chongzuo','0','chongzuo.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (69,7,'防城港',76,'fangchenggang','0','fangchenggang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (70,7,'贵港',76,'guigang','0','guigang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (71,7,'桂林',76,'guilin','1','guilin.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (72,7,'河池',76,'hechi','0','hechi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (73,7,'贺州',76,'hezhou','0','hezhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (74,7,'来宾',76,'laibin','0','laibin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (75,7,'柳州',76,'liuzhou','0','liuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (76,7,'南宁',76,'nanning','1','nanning.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (77,7,'钦州',76,'qinzhou','0','qinzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (78,7,'梧州',76,'wuzhou','0','wuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (79,7,'玉林',76,'yulin','0','yulin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (80,8,'安顺',82,'anshun','0','anshun.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (81,8,'毕节',82,'bijie','0','bijie.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (82,8,'贵阳',82,'guiyang','1','guiyang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (83,8,'六盘水',82,'liupanshui','0','liupanshui.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (84,8,'黔东',82,'qiandong','0','qiandong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (85,8,'黔南',82,'qiannan','0','qiannan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (86,8,'黔西',82,'qianxi','0','qianxi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (87,8,'铜仁',82,'tongren','0','tongren.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (88,8,'遵义',82,'zunyi','0','zunyi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (89,9,'白沙',96,'baisha','0','baisha.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (90,9,'保亭',96,'baoting','0','baoting.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (91,9,'昌江',96,'changjiang','0','changjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (92,9,'澄迈',96,'chengmai','0','chengmai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (93,9,'儋州',96,'danzhou','0','danzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (94,9,'定安',96,'dingan','0','dingan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (95,9,'东方',96,'dongfang','0','dongfang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (96,9,'海口',96,'haikou','1','haikou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (97,9,'乐东',96,'ledong','0','ledong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (98,9,'临高',96,'lingao','0','lingao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (99,9,'陵水',96,'lingshui','0','lingshui.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (100,9,'琼海',96,'qionghai','0','qionghai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (101,9,'琼中',96,'qiongzhong','0','qiongzhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (102,9,'三亚',96,'sanya','1','sanya.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (103,9,'屯昌',96,'tunchang','0','tunchang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (104,9,'万宁',96,'wanning','0','wanning.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (105,9,'文昌',96,'wenchang','0','wenchang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (106,9,'五指山',96,'wuzhishan','0','wuzhishan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (107,10,'保定',114,'baoding','1','baoding.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (108,10,'沧州',114,'cangzhou','0','cangzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (109,10,'承德',114,'chengde','0','chengde.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (110,10,'邯郸',114,'handan','0','handan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (111,10,'衡水',114,'hengshui','0','hengshui.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (112,10,'廊坊',114,'langfang','0','langfang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (113,10,'秦皇岛',114,'qinhuangdao','0','qinhuangdao.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (114,10,'石家庄',114,'shijiazhuang','1','shijiazhuang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (115,10,'唐山',114,'tangshan','0','tangshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (116,10,'邢台',114,'xingtai','0','xingtai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (117,10,'张家口',114,'zhangjiakou','0','zhangjiakou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (118,11,'安阳',123,'anyang','0','anyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (119,11,'鹤壁',123,'hebi','0','hebi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (120,11,'济源',123,'jiyuan','0','jiyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (121,11,'焦作',123,'jiaozuo','0','jiaozuo.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (122,11,'开封',123,'kaifeng','0','kaifeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (123,11,'洛阳',123,'luoyang','0','luoyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (124,11,'漯河',123,'luohe','0','luohe.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (125,11,'南阳',123,'nanyang','0','nanyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (126,11,'平顶山',123,'pingdingshan','0','pingdingshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (127,11,'濮阳',123,'puyang','0','puyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (128,11,'三门峡',123,'sanmenxia','0','sanmenxia.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (129,11,'商丘',123,'shangqiu','0','shangqiu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (130,11,'新乡',123,'xinxiang','0','xinxiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (131,11,'信阳',123,'xinyang','0','xinyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (132,11,'许昌',123,'xuchang','0','xuchang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (133,11,'郑州',123,'zhengzhou','1','zhengzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (134,11,'周口',123,'zhoukou','0','zhoukou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (135,11,'驻马店',123,'zhumadian','0','zhumadian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (136,12,'大庆',138,'daqing','0','daqing.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (137,12,'大兴安岭',138,'daxinganling','0','daxinganling.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (138,12,'哈尔滨',138,'haerbin','1','haerbin.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (139,12,'鹤岗',138,'hegang','0','hegang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (140,12,'黑河',138,'heihe','0','heihe.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (141,12,'鸡西',138,'jixi','0','jixi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (142,12,'佳木斯',138,'jiamusi','0','jiamusi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (143,12,'牡丹江',138,'mudanjiang','0','mudanjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (144,12,'七台河',138,'qitaihe','0','qitaihe.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (145,12,'齐齐哈尔',138,'qiqihaer','0','qiqihaer.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (146,12,'双鸭山',138,'shuangyashan','0','shuangyashan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (147,12,'绥化',138,'suihua','0','suihua.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (148,12,'伊春',138,'yichun','0','yichun.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (149,13,'鄂州',160,'ezhou','0','ezhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (150,13,'恩施',160,'enshi','0','enshi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (151,13,'黄冈',160,'huanggang','0','huanggang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (152,13,'黄石',160,'huangshi','0','huangshi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (153,13,'荆门',160,'jingmen','0','jingmen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (154,13,'荆州',160,'jingzhou','0','jingzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (155,13,'潜江',160,'qianjiang','0','qianjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (156,13,'神农架',160,'shennongjia','0','shennongjia.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (157,13,'十堰',160,'shiyan','0','shiyan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (158,13,'随州',160,'suizhou','0','suizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (159,13,'天门',160,'tianmen','0','tianmen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (160,13,'武汉',160,'wuhan','1','wuhan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (161,13,'仙桃',160,'xiantao','0','xiantao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (162,13,'咸宁',160,'xianning','0','xianning.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (163,13,'襄樊',160,'xiangfan','1','xiangfan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (164,13,'孝感',160,'xiaogan','0','xiaogan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (165,13,'宜昌',160,'yichang','1','yichang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (166,14,'长沙',166,'changsha','1','changsha.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (167,14,'常德',166,'changde','0','changde.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (168,14,'郴州',166,'chenzhou','0','chenzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (169,14,'衡阳',166,'hengyang','0','hengyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (170,14,'怀化',166,'huaihua','0','huaihua.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (171,14,'娄底',166,'loudi','0','loudi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (172,14,'邵阳',166,'shaoyang','0','shaoyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (173,14,'湘潭',166,'xiangtan','0','xiangtan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (174,14,'湘西',166,'xiangxi','0','xiangxi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (175,14,'益阳',166,'yiyang','0','yiyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (176,14,'永州',166,'yongzhou','0','yongzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (177,14,'岳阳',166,'yueyang','0','yueyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (178,14,'张家界',166,'zhangjiajie','0','zhangjiajie.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (179,14,'株州',166,'zhuzhou','0','zhuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (180,15,'白城',182,'baicheng','0','baicheng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (181,15,'白山',182,'baishan','0','baishan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (182,15,'长春',182,'changchun','1','changchun.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (183,15,'吉林',182,'jilin','0','jilin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (184,15,'辽源',182,'liaoyuan','0','liaoyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (185,15,'四平',182,'siping','0','siping.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (186,15,'松原',182,'songyuan','0','songyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (187,15,'通化',182,'tonghua','0','tonghua.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (188,15,'延边',182,'yanbian','1','yanbian.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (189,16,'常州',192,'changzhou','0','changzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (190,16,'淮安',192,'huaian','0','huaian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (191,16,'连云港',192,'lianyungang','0','lianyungang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (192,16,'南京',192,'nanjing','1','nanjing.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (193,16,'南通',192,'nantong','1','nantong.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (194,16,'苏州',192,'suzhou','1','suzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (195,16,'宿迁',192,'suqian','0','suqian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (196,16,'泰州',192,'taizhou','0','taizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (197,16,'无锡',192,'wuxi','1','wuxi.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (198,16,'徐州',192,'xuzhou','0','xuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (199,16,'盐城',192,'yancheng','0','yancheng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (200,16,'扬州',192,'yangzhou','0','yangzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (201,16,'镇江',192,'zhenjiang','0','zhenjiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (202,17,'抚州',207,'fuzhou','0','fuzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (203,17,'赣州',207,'ganzhou','1','ganzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (204,17,'吉安',207,'jian','0','jian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (205,17,'景德镇',207,'jingdezhen','0','jingdezhen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (206,17,'九江',207,'jiujiang','1','jiujiang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (207,17,'南昌',207,'nanchang','1','nanchang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (208,17,'萍乡',207,'pingxiang','0','pingxiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (209,17,'上饶',207,'shangrao','0','shangrao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (210,17,'婺源',207,'wuyuan','0','wuyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (211,17,'新余',207,'xinyu','0','xinyu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (212,17,'宜春',207,'yichun','0','yichun.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (213,17,'鹰潭',207,'yingtan','0','yingtan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (214,18,'鞍山',217,'anshan','0','anshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (215,18,'本溪',217,'benxi','0','benxi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (216,18,'朝阳',217,'chaoyang','0','chaoyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (217,18,'大连',217,'dalian','1','dalian.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (218,18,'丹东',217,'dandong','0','dandong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (219,18,'抚顺',217,'fushun','0','fushun.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (220,18,'阜新',217,'fuxin','0','fuxin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (221,18,'葫芦岛',217,'huludao','0','huludao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (222,18,'锦州',217,'jinzhou','0','jinzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (223,18,'辽阳',217,'liaoyang','0','liaoyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (224,18,'盘锦',217,'panjin','0','panjin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (225,18,'沈阳',217,'shenyang','1','shenyang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (226,18,'铁岭',217,'tieling','0','tieling.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (227,18,'营口',217,'yingkou','0','yingkou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (228,19,'阿拉善盟',233,'alashanmeng','1','alashanmeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (229,19,'巴彦淖尔盟',233,'bayannaoermeng','0','bayannaoermeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (230,19,'包头',233,'baotou','0','baotou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (231,19,'赤峰',233,'chifeng','0','chifeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (232,19,'鄂尔多斯',233,'eerduosi','0','eerduosi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (233,19,'呼和浩特',233,'huhehaote','1','huhehaote.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (234,19,'呼伦贝尔',233,'hulunbeier','0','hulunbeier.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (235,19,'通辽',233,'tongliao','0','tongliao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (236,19,'乌海',233,'wuhai','0','wuhai.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (237,19,'乌兰察布盟',233,'wulanchabumeng','0','wulanchabumeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (238,19,'锡林郭勒盟',233,'xilinguolemeng','0','xilinguolemeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (239,19,'兴安盟',233,'xinganmeng','0','xinganmeng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (240,20,'固原',243,'guyuan','0','guyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (241,20,'石嘴山',243,'shizuishan','0','shizuishan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (242,20,'吴忠',243,'wuzhong','0','wuzhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (243,20,'银川',243,'yinchuan','0','yinchuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (244,21,'格尔木',248,'geermu','0','geermu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (245,21,'果洛',248,'guoluo','0','guoluo.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (246,21,'海北',248,'haibei','0','haibei.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (247,21,'海东',248,'haidong','0','haidong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (248,21,'海南',248,'hainan','0','hainan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (249,21,'海西',248,'haixi','0','haixi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (250,21,'黄南',248,'huangnan','0','huangnan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (251,21,'西宁',248,'xining','1','xining.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (252,21,'玉树',248,'yushu','0','yushu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (253,22,'滨州',257,'binzhou','0','binzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (254,22,'德州',257,'dezhou','0','dezhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (255,22,'东营',257,'dongying','0','dongying.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (256,22,'菏泽',257,'heze','0','heze.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (257,22,'济南',257,'jinan','1','jinan.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (258,22,'济宁',257,'jining','1','jining.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (259,22,'莱芜',257,'laiwu','0','laiwu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (260,22,'聊城',257,'liaocheng','1','liaocheng.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (261,22,'临沂',257,'linyi','1','linyi.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (262,22,'青岛',257,'qingdao','1','qingdao.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (263,22,'日照',257,'rizhao','0','rizhao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (264,22,'泰安',257,'taian','1','taian.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (266,22,'威海',257,'weihai','1','weihai.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (267,22,'潍坊',257,'weifang','1','weifang.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (268,22,'烟台',257,'yantai','1','yantai.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (269,22,'枣庄',257,'zaozhuang','0','zaozhuang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (270,22,'淄博',257,'zibo','1','zibo.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (271,23,'长治',278,'changzhi','0','changzhi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (272,23,'大同',278,'datong','0','datong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (273,23,'晋城',278,'jincheng','0','jincheng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (274,23,'晋中',278,'jinzhong','0','jinzhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (275,23,'临汾',278,'linfen','0','linfen.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (276,23,'吕梁',278,'lvliang','0','lvliang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (277,23,'朔州',278,'shuozhou','0','shuozhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (278,23,'太原',278,'taiyuan','1','taiyuan.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (279,23,'忻州',278,'xinzhou','0','xinzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (280,23,'阳泉',278,'yangquan','0','yangquan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (281,23,'运城',278,'yuncheng','0','yuncheng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (282,24,'安康',288,'ankang','0','ankang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (283,24,'宝鸡',288,'baoji','0','baoji.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (284,24,'汉中',288,'hanzhong','0','hanzhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (285,24,'商洛',288,'shangluo','0','shangluo.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (286,24,'铜川',288,'tongchuan','0','tongchuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (287,24,'渭南',288,'weinan','0','weinan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (288,24,'西安',288,'xian','1','xian.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (289,24,'咸阳',288,'xianyang','0','xianyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (290,24,'延安',288,'yanan','0','yanan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (291,24,'榆林',288,'yulin','0','yulin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (292,25,'上海',292,'shanghai','1','shanghai.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (293,26,'阿坝',295,'aba','1','aba.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (294,26,'巴中',295,'bazhong','0','bazhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (295,26,'成都',295,'chengdou','1','chengdou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (296,26,'达州',295,'dazhou','0','dazhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (297,26,'德阳',295,'deyang','0','deyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (298,26,'甘孜',295,'ganzi','0','ganzi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (299,26,'广安',295,'guangan','0','guangan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (300,26,'广元',295,'guangyuan','0','guangyuan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (301,26,'乐山',295,'leshan','0','leshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (302,26,'凉山',295,'liangshan','0','liangshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (303,26,'泸州',295,'luzhou','0','luzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (304,26,'眉山',295,'meishan','0','meishan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (305,26,'绵阳',295,'mianyang','0','mianyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (306,26,'内江',295,'najiang','0','najiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (307,26,'南充',295,'nanchong','0','nanchong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (308,26,'攀枝花',295,'panzhihua','0','panzhihua.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (309,26,'遂宁',295,'suining','0','suining.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (310,26,'雅安',295,'yaan','0','yaan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (311,26,'宜宾',295,'yibin','0','yibin.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (312,26,'资阳',295,'ziyang','0','ziyang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (313,26,'自贡',295,'zigong','0','zigong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (314,27,'高雄',317,'gaoxiong','0','gaoxiong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (315,27,'基隆',317,'jilong','0','jilong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (316,27,'嘉义',317,'jiayi','0','jiayi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (317,27,'台北',317,'taibei','0','taibei.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (318,27,'台南',317,'tainan','0','tainan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (319,27,'台中',317,'taizhong','0','taizhong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (320,27,'新竹',317,'xinzhu','0','xinzhu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (321,28,'天津',321,'tianjin','1','tianjin.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (322,29,'阿里',324,'ali','0','ali.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (323,29,'昌都',324,'changdou','0','changdou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (324,29,'拉萨',324,'lasa','1','lasa.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (325,29,'林芝',324,'linzhi','0','linzhi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (326,29,'那曲',324,'naqu','0','naqu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (327,29,'日喀则',324,'rikaze','0','rikaze.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (328,29,'山南',324,'shannan','0','shannan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (329,30,'香港',329,'xianggang','0','xianggang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (330,31,'阿克苏',343,'akesu','1','akesu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (331,31,'阿拉尔',343,'alaer','0','alaer.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (332,31,'巴音郭楞',343,'bayinguoleng','0','bayinguoleng.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (333,31,'博尔塔拉',343,'boertala','0','boertala.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (334,31,'昌吉',343,'changji','0','changji.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (335,31,'哈密',343,'hami','0','hami.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (336,31,'和田',343,'hetian','0','hetian.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (337,31,'喀什',343,'kashi','0','kashi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (338,31,'克拉玛依',343,'kelamayi','0','kelamayi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (339,31,'克孜勒',343,'kezile','0','kezile.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (340,31,'石河子',343,'shihezi','0','shihezi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (341,31,'图木舒克',343,'tumushuke','0','tumushuke.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (342,31,'吐鲁番',343,'tulufan','0','tulufan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (343,31,'乌鲁木齐',343,'wulumuqi','0','wulumuqi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (344,31,'五家渠',343,'wujiaqu','0','wujiaqu.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (345,31,'伊犁',343,'yili','0','yili.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (346,32,'保山',352,'baoshan','0','baoshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (347,32,'楚雄',352,'chuxiong','0','chuxiong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (348,32,'大理',352,'dali','1','dali.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (349,32,'德宏',352,'dehong','0','dehong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (350,32,'迪庆',352,'diqing','0','diqing.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (351,32,'红河',352,'honghe','0','honghe.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (352,32,'昆明',352,'kunming','1','kunming.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (353,32,'丽江',352,'lijiang','0','lijiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (354,32,'临沧',352,'lincang','0','lincang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (355,32,'怒江',352,'nujiang','0','nujiang.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (356,32,'曲靖',352,'qujing','0','qujing.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (357,32,'思茅',352,'simao','0','simao.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (358,32,'文山',352,'wenshan','0','wenshan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (359,32,'西双版纳',352,'xishuangbanna','0','xishuangbanna.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (360,32,'玉溪',352,'yuxi','0','yuxi.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (361,32,'昭通',352,'zhaotong','0','zhaotong.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (362,33,'杭州',362,'hangzhou','1','hangzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (363,33,'湖州',362,'huzhou','0','huzhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (364,33,'嘉兴',362,'jiaxing','0','jiaxing.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (365,33,'金华',362,'jinhua','0','jinhua.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (366,33,'丽水',362,'lishui','1','lishui.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (367,33,'宁波',362,'ningbo','1','ningbo.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (368,33,'衢州',362,'quzhou','1','quzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (369,33,'绍兴',362,'shaoxing','0','shaoxing.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (370,33,'台州',362,'taizhou','0','taizhou.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (371,33,'温州',362,'wenzhou','1','wenzhou.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (372,33,'舟山',362,'zhoushan','0','zhoushan.tongye114.com','0') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (373,34,'重庆',373,'chongqing','1','chongqing.tongye114.com','1') 
 insert into tbl_SysCity(Id,ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) values (374,31,'阿勒泰',343,'aletai','0','aletai.tongye114.com','0') 
 
 
 SET IDENTITY_INSERT tbl_SysCity OFF 
 
 go
 
 --县区处理
 
 go
 
 delete from tbl_SysDistrict
 
 go
 
 
SET IDENTITY_INSERT tbl_SysDistrict ON


 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1,'东城区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2,'西城区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 3,'崇文区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 4,'宣武区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 5,'朝阳区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 6,'丰台区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 7,'石景山区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 8,'海淀区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 9,'门头沟区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 10,'房山区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 11,'通州区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 12,'顺义区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 13,'昌平区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 14,'大兴区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 15,'怀柔区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 16,'平谷区',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 17,'密云县',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 18,'延庆县',3,19,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 19,'和平区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 20,'河东区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 21,'河西区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 22,'南开区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 23,'河北区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 24,'红桥区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 25,'塘沽区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 26,'汉沽区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 27,'大港区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 28,'东丽区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 29,'西青区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 30,'津南区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 31,'北辰区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 32,'武清区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 33,'宝坻区',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 34,'宁河县',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 35,'静海县',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 36,'蓟县',28,321,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 37,'长安区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 38,'桥东区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 39,'桥西区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 40,'新华区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 41,'井陉矿区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 42,'裕华区',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 43,'井陉县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 44,'正定县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 45,'栾城县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 46,'行唐县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 47,'灵寿县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 48,'高邑县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 49,'深泽县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 50,'赞皇县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 51,'无极县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 52,'平山县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 53,'元氏县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 54,'赵县',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 55,'辛集市',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 56,'藁城市',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 57,'晋州市',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 58,'新乐市',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 59,'鹿泉市',10,114,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 60,'路南区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 61,'路北区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 62,'古冶区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 63,'开平区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 64,'丰南区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 65,'丰润区',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 66,'滦县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 67,'滦南县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 68,'乐亭县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 69,'迁西县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 70,'玉田县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 71,'唐海县',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 72,'遵化市',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 73,'迁安市',10,115,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 74,'海港区',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 75,'山海关区',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 76,'北戴河区',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 77,'青龙满族自治县',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 78,'昌黎县',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 79,'抚宁县',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 80,'卢龙县',10,113,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 81,'邯山区',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 82,'丛台区',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 83,'复兴区',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 84,'峰峰矿区',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 85,'邯郸县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 86,'临漳县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 87,'成安县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 88,'大名县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 89,'涉县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 90,'磁县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 91,'肥乡县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 92,'永年县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 93,'邱县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 94,'鸡泽县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 95,'广平县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 96,'馆陶县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 97,'魏县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 98,'曲周县',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 99,'武安市',10,110,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 100,'桥东区',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 101,'桥西区',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 102,'邢台县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 103,'临城县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 104,'内丘县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 105,'柏乡县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 106,'隆尧县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 107,'任县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 108,'南和县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 109,'宁晋县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 110,'巨鹿县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 111,'新河县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 112,'广宗县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 113,'平乡县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 114,'威县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 115,'清河县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 116,'临西县',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 117,'南宫市',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 118,'沙河市',10,116,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 119,'新市区',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 120,'北市区',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 121,'南市区',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 122,'满城县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 123,'清苑县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 124,'涞水县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 125,'阜平县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 126,'徐水县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 127,'定兴县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 128,'唐县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 129,'高阳县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 130,'容城县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 131,'涞源县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 132,'望都县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 133,'安新县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 134,'易县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 135,'曲阳县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 136,'蠡县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 137,'顺平县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 138,'博野县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 139,'雄县',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 140,'涿州市',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 141,'定州市',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 142,'安国市',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 143,'高碑店市',10,107,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 144,'桥东区',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 145,'桥西区',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 146,'宣化区',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 147,'下花园区',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 148,'宣化县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 149,'张北县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 150,'康保县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 151,'沽源县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 152,'尚义县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 153,'蔚县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 154,'阳原县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 155,'怀安县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 156,'万全县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 157,'怀来县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 158,'涿鹿县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 159,'赤城县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 160,'崇礼县',10,117,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 161,'双桥区',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 162,'双滦区',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 163,'鹰手营子矿区',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 164,'承德县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 165,'兴隆县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 166,'平泉县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 167,'滦平县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 168,'隆化县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 169,'丰宁满族自治县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 170,'宽城满族自治县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 171,'围场满族蒙古族自治县',10,109,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 172,'新华区',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 173,'运河区',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 174,'沧县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 175,'青县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 176,'东光县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 177,'海兴县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 178,'盐山县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 179,'肃宁县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 180,'南皮县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 181,'吴桥县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 182,'献县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 183,'孟村回族自治县',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 184,'泊头市',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 185,'任丘市',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 186,'黄骅市',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 187,'河间市',10,108,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 188,'安次区',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 189,'广阳区',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 190,'固安县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 191,'永清县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 192,'香河县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 193,'大城县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 194,'文安县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 195,'大厂回族自治县',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 196,'霸州市',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 197,'三河市',10,112,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 198,'桃城区',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 199,'枣强县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 200,'武邑县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 201,'武强县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 202,'饶阳县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 203,'安平县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 204,'故城县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 205,'景县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 206,'阜城县',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 207,'冀州市',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 208,'深州市',10,111,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 209,'小店区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 210,'迎泽区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 211,'杏花岭区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 212,'尖草坪区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 213,'万柏林区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 214,'晋源区',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 215,'清徐县',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 216,'阳曲县',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 217,'娄烦县',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 218,'古交市',23,278,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 219,'城区',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 220,'矿区',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 221,'南郊区',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 222,'新荣区',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 223,'阳高县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 224,'天镇县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 225,'广灵县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 226,'灵丘县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 227,'浑源县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 228,'左云县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 229,'大同县',23,272,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 230,'城区',23,280,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 231,'矿区',23,280,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 232,'郊区',23,280,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 233,'平定县',23,280,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 234,'盂县',23,280,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 235,'城区',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 236,'郊区',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 237,'长治县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 238,'襄垣县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 239,'屯留县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 240,'平顺县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 241,'黎城县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 242,'壶关县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 243,'长子县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 244,'武乡县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 245,'沁县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 246,'沁源县',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 247,'潞城市',23,271,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 248,'城区',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 249,'沁水县',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 250,'阳城县',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 251,'陵川县',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 252,'泽州县',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 253,'高平市',23,273,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 254,'朔城区',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 255,'平鲁区',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 256,'山阴县',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 257,'应县',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 258,'右玉县',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 259,'怀仁县',23,277,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 260,'榆次区',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 261,'榆社县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 262,'左权县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 263,'和顺县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 264,'昔阳县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 265,'寿阳县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 266,'太谷县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 267,'祁县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 268,'平遥县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 269,'灵石县',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 270,'介休市',23,274,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 271,'盐湖区',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 272,'临猗县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 273,'万荣县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 274,'闻喜县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 275,'稷山县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 276,'新绛县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 277,'绛县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 278,'垣曲县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 279,'夏县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 280,'平陆县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 281,'芮城县',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 282,'永济市',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 283,'河津市',23,281,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 284,'忻府区',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 285,'定襄县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 286,'五台县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 287,'代县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 288,'繁峙县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 289,'宁武县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 290,'静乐县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 291,'神池县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 292,'五寨县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 293,'岢岚县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 294,'河曲县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 295,'保德县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 296,'偏关县',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 297,'原平市',23,279,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 298,'尧都区',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 299,'曲沃县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 300,'翼城县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 301,'襄汾县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 302,'洪洞县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 303,'古县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 304,'安泽县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 305,'浮山县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 306,'吉县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 307,'乡宁县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 308,'大宁县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 309,'隰县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 310,'永和县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 311,'蒲县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 312,'汾西县',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 313,'侯马市',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 314,'霍州市',23,275,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 315,'离石区',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 316,'文水县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 317,'交城县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 318,'兴县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 319,'临县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 320,'柳林县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 321,'石楼县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 322,'岚县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 323,'方山县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 324,'中阳县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 325,'交口县',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 326,'孝义市',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 327,'汾阳市',23,276,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 328,'新城区',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 329,'回民区',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 330,'玉泉区',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 331,'赛罕区',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 332,'土默特左旗',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 333,'托克托县',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 334,'和林格尔县',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 335,'清水河县',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 336,'武川县',19,233,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 337,'东河区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 338,'昆都仑区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 339,'青山区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 340,'石拐区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 341,'白云矿区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 342,'九原区',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 343,'土默特右旗',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 344,'固阳县',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 345,'达尔罕茂明安联合旗',19,230,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 346,'海勃湾区',19,236,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 347,'海南区',19,236,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 348,'乌达区',19,236,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 349,'红山区',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 350,'元宝山区',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 351,'松山区',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 352,'阿鲁科尔沁旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 353,'巴林左旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 354,'巴林右旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 355,'林西县',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 356,'克什克腾旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 357,'翁牛特旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 358,'喀喇沁旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 359,'宁城县',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 360,'敖汉旗',19,231,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 361,'科尔沁区',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 362,'科尔沁左翼中旗',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 363,'科尔沁左翼后旗',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 364,'开鲁县',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 365,'库伦旗',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 366,'奈曼旗',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 367,'扎鲁特旗',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 368,'霍林郭勒市',19,235,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 369,'东胜区',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 370,'达拉特旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 371,'准格尔旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 372,'鄂托克前旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 373,'鄂托克旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 374,'杭锦旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 375,'乌审旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 376,'伊金霍洛旗',19,232,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 377,'海拉尔区',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 378,'阿荣旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 379,'莫力达瓦达斡尔族自治旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 380,'鄂伦春自治旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 381,'鄂温克族自治旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 382,'陈巴尔虎旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 383,'新巴尔虎左旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 384,'新巴尔虎右旗',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 385,'满洲里市',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 386,'牙克石市',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 387,'扎兰屯市',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 388,'额尔古纳市',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 389,'根河市',19,234,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 390,'乌兰浩特市',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 391,'阿尔山市',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 392,'科尔沁右翼前旗',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 393,'科尔沁右翼中旗',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 394,'扎赉特旗',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 395,'突泉县',19,239,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 396,'二连浩特市',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 397,'锡林浩特市',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 398,'阿巴嘎旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 399,'苏尼特左旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 400,'苏尼特右旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 401,'东乌珠穆沁旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 402,'西乌珠穆沁旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 403,'太仆寺旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 404,'镶黄旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 405,'正镶白旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 406,'正蓝旗',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 407,'多伦县',19,238,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 408,'阿拉善左旗',19,228,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 409,'阿拉善右旗',19,228,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 410,'额济纳旗',19,228,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 411,'和平区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 412,'沈河区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 413,'大东区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 414,'皇姑区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 415,'铁西区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 416,'苏家屯区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 417,'东陵区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 418,'新城子区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 419,'于洪区',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 420,'辽中县',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 421,'康平县',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 422,'法库县',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 423,'新民市',18,225,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 424,'中山区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 425,'西岗区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 426,'沙河口区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 427,'甘井子区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 428,'旅顺口区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 429,'金州区',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 430,'长海县',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 431,'瓦房店市',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 432,'普兰店市',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 433,'庄河市',18,217,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 434,'铁东区',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 435,'铁西区',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 436,'立山区',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 437,'千山区',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 438,'台安县',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 439,'岫岩满族自治县',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 440,'海城市',18,214,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 441,'新抚区',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 442,'东洲区',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 443,'望花区',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 444,'顺城区',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 445,'抚顺县',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 446,'新宾满族自治县',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 447,'清原满族自治县',18,219,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 448,'平山区',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 449,'溪湖区',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 450,'明山区',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 451,'南芬区',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 452,'本溪满族自治县',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 453,'桓仁满族自治县',18,215,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 454,'元宝区',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 455,'振兴区',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 456,'振安区',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 457,'宽甸满族自治县',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 458,'东港市',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 459,'凤城市',18,218,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 460,'古塔区',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 461,'凌河区',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 462,'太和区',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 463,'黑山县',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 464,'义县',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 465,'凌海市',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 466,'北宁市',18,222,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 467,'站前区',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 468,'西市区',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 469,'鲅鱼圈区',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 470,'老边区',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 471,'盖州市',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 472,'大石桥市',18,227,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 473,'海州区',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 474,'新邱区',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 475,'太平区',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 476,'清河门区',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 477,'细河区',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 478,'阜新蒙古族自治县',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 479,'彰武县',18,220,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 480,'白塔区',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 481,'文圣区',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 482,'宏伟区',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 483,'弓长岭区',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 484,'太子河区',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 485,'辽阳县',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 486,'灯塔市',18,223,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 487,'双台子区',18,224,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 488,'兴隆台区',18,224,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 489,'大洼县',18,224,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 490,'盘山县',18,224,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 491,'银州区',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 492,'清河区',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 493,'铁岭县',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 494,'西丰县',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 495,'昌图县',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 496,'调兵山市',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 497,'开原市',18,226,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 498,'双塔区',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 499,'龙城区',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 500,'朝阳县',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 501,'建平县',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 502,'喀喇沁左翼蒙古族自治县',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 503,'北票市',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 504,'凌源市',18,216,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 505,'连山区',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 506,'龙港区',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 507,'南票区',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 508,'绥中县',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 509,'建昌县',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 510,'兴城市',18,221,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 511,'南关区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 512,'宽城区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 513,'朝阳区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 514,'二道区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 515,'绿园区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 516,'双阳区',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 517,'农安县',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 518,'九台市',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 519,'榆树市',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 520,'德惠市',15,182,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 521,'昌邑区',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 522,'龙潭区',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 523,'船营区',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 524,'丰满区',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 525,'永吉县',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 526,'蛟河市',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 527,'桦甸市',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 528,'舒兰市',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 529,'磐石市',15,183,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 530,'铁西区',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 531,'铁东区',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 532,'梨树县',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 533,'伊通满族自治县',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 534,'公主岭市',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 535,'双辽市',15,185,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 536,'龙山区',15,184,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 537,'西安区',15,184,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 538,'东丰县',15,184,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 539,'东辽县',15,184,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 540,'东昌区',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 541,'二道江区',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 542,'通化县',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 543,'辉南县',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 544,'柳河县',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 545,'梅河口市',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 546,'集安市',15,187,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 547,'八道江区',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 548,'抚松县',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 549,'靖宇县',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 550,'长白朝鲜族自治县',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 551,'江源县',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 552,'临江市',15,181,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 553,'宁江区',15,186,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 554,'前郭尔罗斯蒙古族自治县',15,186,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 555,'长岭县',15,186,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 556,'乾安县',15,186,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 557,'扶余县',15,186,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 558,'洮北区',15,180,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 559,'镇赉县',15,180,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 560,'通榆县',15,180,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 561,'洮南市',15,180,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 562,'大安市',15,180,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 563,'延吉市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 564,'图们市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 565,'敦化市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 566,'珲春市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 567,'龙井市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 568,'和龙市',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 569,'汪清县',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 570,'安图县',15,188,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 571,'道里区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 572,'南岗区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 573,'道外区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 574,'香坊区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 575,'动力区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 576,'平房区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 577,'松北区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 578,'呼兰区',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 579,'依兰县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 580,'方正县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 581,'宾县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 582,'巴彦县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 583,'木兰县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 584,'通河县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 585,'延寿县',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 586,'阿城市',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 587,'双城市',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 588,'尚志市',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 589,'五常市',12,138,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 590,'龙沙区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 591,'建华区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 592,'铁锋区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 593,'昂昂溪区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 594,'富拉尔基区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 595,'碾子山区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 596,'梅里斯达斡尔族区',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 597,'龙江县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 598,'依安县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 599,'泰来县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 600,'甘南县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 601,'富裕县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 602,'克山县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 603,'克东县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 604,'拜泉县',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 605,'讷河市',12,145,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 606,'鸡冠区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 607,'恒山区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 608,'滴道区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 609,'梨树区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 610,'城子河区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 611,'麻山区',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 612,'鸡东县',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 613,'虎林市',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 614,'密山市',12,141,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 615,'向阳区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 616,'工农区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 617,'南山区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 618,'兴安区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 619,'东山区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 620,'兴山区',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 621,'萝北县',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 622,'绥滨县',12,139,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 623,'尖山区',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 624,'岭东区',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 625,'四方台区',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 626,'宝山区',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 627,'集贤县',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 628,'友谊县',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 629,'宝清县',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 630,'饶河县',12,146,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 631,'萨尔图区',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 632,'龙凤区',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 633,'让胡路区',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 634,'红岗区',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 635,'大同区',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 636,'肇州县',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 637,'肇源县',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 638,'林甸县',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 639,'杜尔伯特蒙古族自治县',12,136,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 640,'伊春区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 641,'南岔区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 642,'友好区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 643,'西林区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 644,'翠峦区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 645,'新青区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 646,'美溪区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 647,'金山屯区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 648,'五营区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 649,'乌马河区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 650,'汤旺河区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 651,'带岭区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 652,'乌伊岭区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 653,'红星区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 654,'上甘岭区',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 655,'嘉荫县',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 656,'铁力市',12,148,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 657,'永红区',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 658,'向阳区',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 659,'前进区',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 660,'东风区',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 661,'郊区',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 662,'桦南县',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 663,'桦川县',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 664,'汤原县',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 665,'抚远县',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 666,'同江市',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 667,'富锦市',12,142,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 668,'新兴区',12,144,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 669,'桃山区',12,144,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 670,'茄子河区',12,144,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 671,'勃利县',12,144,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 672,'东安区',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 673,'阳明区',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 674,'爱民区',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 675,'西安区',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 676,'东宁县',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 677,'林口县',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 678,'绥芬河市',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 679,'海林市',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 680,'宁安市',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 681,'穆棱市',12,143,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 682,'爱辉区',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 683,'嫩江县',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 684,'逊克县',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 685,'孙吴县',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 686,'北安市',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 687,'五大连池市',12,140,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 688,'北林区',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 689,'望奎县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 690,'兰西县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 691,'青冈县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 692,'庆安县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 693,'明水县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 694,'绥棱县',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 695,'安达市',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 696,'肇东市',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 697,'海伦市',12,147,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 698,'呼玛县',12,137,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 699,'塔河县',12,137,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 700,'漠河县',12,137,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 701,'黄浦区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 702,'卢湾区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 703,'徐汇区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 704,'长宁区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 705,'静安区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 706,'普陀区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 707,'闸北区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 708,'虹口区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 709,'杨浦区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 710,'闵行区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 711,'宝山区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 712,'嘉定区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 713,'浦东新区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 714,'金山区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 715,'松江区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 716,'青浦区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 717,'南汇区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 718,'奉贤区',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 719,'崇明县',25,292,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 720,'玄武区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 721,'白下区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 722,'秦淮区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 723,'建邺区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 724,'鼓楼区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 725,'下关区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 726,'浦口区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 727,'栖霞区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 728,'雨花台区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 729,'江宁区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 730,'六合区',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 731,'溧水县',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 732,'高淳县',16,192,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 733,'崇安区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 734,'南长区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 735,'北塘区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 736,'锡山区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 737,'惠山区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 738,'滨湖区',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 739,'江阴市',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 740,'宜兴市',16,197,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 741,'鼓楼区',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 742,'云龙区',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 743,'九里区',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 744,'贾汪区',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 745,'泉山区',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 746,'丰县',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 747,'沛县',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 748,'铜山县',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 749,'睢宁县',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 750,'新沂市',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 751,'邳州市',16,198,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 752,'天宁区',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 753,'钟楼区',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 754,'戚墅堰区',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 755,'新北区',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 756,'武进区',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 757,'溧阳市',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 758,'金坛市',16,189,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 759,'沧浪区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 760,'平江区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 761,'金阊区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 762,'虎丘区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 763,'吴中区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 764,'相城区',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 765,'常熟市',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 766,'张家港市',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 767,'昆山市',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 768,'吴江市',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 769,'太仓市',16,194,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 770,'崇川区',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 771,'港闸区',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 772,'海安县',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 773,'如东县',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 774,'启东市',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 775,'如皋市',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 776,'通州市',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 777,'海门市',16,193,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 778,'连云区',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 779,'新浦区',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 780,'海州区',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 781,'赣榆县',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 782,'东海县',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 783,'灌云县',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 784,'灌南县',16,191,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 785,'清河区',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 786,'楚州区',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 787,'淮阴区',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 788,'清浦区',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 789,'涟水县',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 790,'洪泽县',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 791,'盱眙县',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 792,'金湖县',16,190,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 793,'亭湖区',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 794,'盐都区',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 795,'响水县',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 796,'滨海县',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 797,'阜宁县',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 798,'射阳县',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 799,'建湖县',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 800,'东台市',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 801,'大丰市',16,199,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 802,'广陵区',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 803,'邗江区',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 804,'维扬区',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 805,'宝应县',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 806,'仪征市',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 807,'高邮市',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 808,'江都市',16,200,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 809,'京口区',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 810,'润州区',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 811,'丹徒区',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 812,'丹阳市',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 813,'扬中市',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 814,'句容市',16,201,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 815,'海陵区',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 816,'高港区',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 817,'兴化市',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 818,'靖江市',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 819,'泰兴市',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 820,'姜堰市',16,196,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 821,'宿城区',16,195,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 822,'宿豫区',16,195,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 823,'沭阳县',16,195,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 824,'泗阳县',16,195,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 825,'泗洪县',16,195,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 826,'上城区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 827,'下城区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 828,'江干区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 829,'拱墅区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 830,'西湖区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 831,'滨江区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 832,'萧山区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 833,'余杭区',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 834,'桐庐县',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 835,'淳安县',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 836,'建德市',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 837,'富阳市',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 838,'临安市',33,362,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 839,'海曙区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 840,'江东区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 841,'江北区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 842,'北仑区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 843,'镇海区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 844,'鄞州区',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 845,'象山县',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 846,'宁海县',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 847,'余姚市',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 848,'慈溪市',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 849,'奉化市',33,367,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 850,'鹿城区',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 851,'龙湾区',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 852,'瓯海区',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 853,'洞头县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 854,'永嘉县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 855,'平阳县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 856,'苍南县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 857,'文成县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 858,'泰顺县',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 859,'瑞安市',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 860,'乐清市',33,371,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 861,'秀城区',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 862,'秀洲区',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 863,'嘉善县',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 864,'海盐县',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 865,'海宁市',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 866,'平湖市',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 867,'桐乡市',33,364,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 868,'吴兴区',33,363,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 869,'南浔区',33,363,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 870,'德清县',33,363,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 871,'长兴县',33,363,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 872,'安吉县',33,363,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 873,'越城区',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 874,'绍兴县',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 875,'新昌县',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 876,'诸暨市',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 877,'上虞市',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 878,'嵊州市',33,369,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 879,'婺城区',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 880,'金东区',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 881,'武义县',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 882,'浦江县',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 883,'磐安县',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 884,'兰溪市',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 885,'义乌市',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 886,'东阳市',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 887,'永康市',33,365,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 888,'柯城区',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 889,'衢江区',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 890,'常山县',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 891,'开化县',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 892,'龙游县',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 893,'江山市',33,368,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 894,'定海区',33,372,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 895,'普陀区',33,372,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 896,'岱山县',33,372,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 897,'嵊泗县',33,372,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 898,'椒江区',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 899,'黄岩区',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 900,'路桥区',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 901,'玉环县',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 902,'三门县',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 903,'天台县',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 904,'仙居县',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 905,'温岭市',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 906,'临海市',33,370,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 907,'莲都区',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 908,'青田县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 909,'缙云县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 910,'遂昌县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 911,'松阳县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 912,'云和县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 913,'庆元县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 914,'景宁畲族自治县',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 915,'龙泉市',33,366,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 916,'瑶海区',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 917,'庐阳区',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 918,'蜀山区',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 919,'包河区',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 920,'长丰县',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 921,'肥东县',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 922,'肥西县',1,8,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 923,'镜湖区',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 924,'马塘区',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 925,'新芜区',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 926,'鸠江区',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 927,'芜湖县',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 928,'繁昌县',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 929,'南陵县',1,16,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 930,'龙子湖区',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 931,'蚌山区',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 932,'禹会区',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 933,'淮上区',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 934,'怀远县',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 935,'五河县',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 936,'固镇县',1,2,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 937,'大通区',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 938,'田家庵区',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 939,'谢家集区',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 940,'八公山区',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 941,'潘集区',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 942,'凤台县',1,10,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 943,'金家庄区',1,13,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 944,'花山区',1,13,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 945,'雨山区',1,13,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 946,'当涂县',1,13,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 947,'杜集区',1,9,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 948,'相山区',1,9,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 949,'烈山区',1,9,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 950,'濉溪县',1,9,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 951,'铜官山区',1,15,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 952,'狮子山区',1,15,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 953,'郊区',1,15,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 954,'铜陵县',1,15,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 955,'迎江区',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 956,'大观区',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 957,'郊区',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 958,'怀宁县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 959,'枞阳县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 960,'潜山县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 961,'太湖县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 962,'宿松县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 963,'望江县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 964,'岳西县',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 965,'桐城市',1,1,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 966,'屯溪区',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 967,'黄山区',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 968,'徽州区',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 969,'歙县',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 970,'休宁县',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 971,'黟县',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 972,'祁门县',1,11,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 973,'琅琊区',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 974,'南谯区',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 975,'来安县',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 976,'全椒县',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 977,'定远县',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 978,'凤阳县',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 979,'天长市',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 980,'明光市',1,5,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 981,'颍州区',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 982,'颍东区',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 983,'颍泉区',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 984,'临泉县',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 985,'太和县',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 986,'阜南县',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 987,'颍上县',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 988,'界首市',1,6,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 989,'埇桥区',1,14,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 990,'砀山县',1,14,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 991,'萧县',1,14,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 992,'灵璧县',1,14,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 993,'泗县',1,14,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 994,'居巢区',1,3,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 995,'庐江县',1,3,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 996,'无为县',1,3,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 997,'含山县',1,3,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 998,'和县',1,3,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 999,'金安区',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1000,'裕安区',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1001,'寿县',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1002,'霍邱县',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1003,'舒城县',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1004,'金寨县',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1005,'霍山县',1,12,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1006,'贵池区',1,4,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1007,'东至县',1,4,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1008,'石台县',1,4,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1009,'青阳县',1,4,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1010,'宣州区',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1011,'郎溪县',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1012,'广德县',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1013,'泾县',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1014,'绩溪县',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1015,'旌德县',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1016,'宁国市',1,17,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1017,'鼓楼区',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1018,'台江区',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1019,'仓山区',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1020,'马尾区',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1021,'晋安区',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1022,'闽侯县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1023,'连江县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1024,'罗源县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1025,'闽清县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1026,'永泰县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1027,'平潭县',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1028,'福清市',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1029,'长乐市',4,20,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1030,'思明区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1031,'海沧区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1032,'湖里区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1033,'集美区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1034,'同安区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1035,'翔安区',4,28,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1036,'城厢区',4,24,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1037,'涵江区',4,24,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1038,'荔城区',4,24,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1039,'秀屿区',4,24,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1040,'仙游县',4,24,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1041,'梅列区',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1042,'三元区',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1043,'明溪县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1044,'清流县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1045,'宁化县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1046,'大田县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1047,'尤溪县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1048,'沙县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1049,'将乐县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1050,'泰宁县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1051,'建宁县',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1052,'永安市',4,26,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1053,'鲤城区',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1054,'丰泽区',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1055,'洛江区',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1056,'泉港区',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1057,'惠安县',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1058,'安溪县',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1059,'永春县',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1060,'德化县',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1061,'金门县',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1062,'石狮市',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1063,'晋江市',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1064,'南安市',4,25,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1065,'芗城区',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1066,'龙文区',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1067,'云霄县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1068,'漳浦县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1069,'诏安县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1070,'长泰县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1071,'东山县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1072,'南靖县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1073,'平和县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1074,'华安县',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1075,'龙海市',4,29,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1076,'延平区',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1077,'顺昌县',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1078,'浦城县',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1079,'光泽县',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1080,'松溪县',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1081,'政和县',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1082,'邵武市',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1083,'武夷山市',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1084,'建瓯市',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1085,'建阳市',4,22,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1086,'新罗区',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1087,'长汀县',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1088,'永定县',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1089,'上杭县',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1090,'武平县',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1091,'连城县',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1092,'漳平市',4,21,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1093,'蕉城区',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1094,'霞浦县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1095,'古田县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1096,'屏南县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1097,'寿宁县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1098,'周宁县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1099,'柘荣县',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1100,'福安市',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1101,'福鼎市',4,23,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1102,'东湖区',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1103,'西湖区',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1104,'青云谱区',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1105,'湾里区',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1106,'青山湖区',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1107,'南昌县',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1108,'新建县',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1109,'安义县',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1110,'进贤县',17,207,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1111,'昌江区',17,205,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1112,'珠山区',17,205,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1113,'浮梁县',17,205,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1114,'乐平市',17,205,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1115,'安源区',17,208,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1116,'湘东区',17,208,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1117,'莲花县',17,208,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1118,'上栗县',17,208,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1119,'芦溪县',17,208,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1120,'庐山区',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1121,'浔阳区',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1122,'九江县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1123,'武宁县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1124,'修水县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1125,'永修县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1126,'德安县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1127,'星子县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1128,'都昌县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1129,'湖口县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1130,'彭泽县',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1131,'瑞昌市',17,206,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1132,'渝水区',17,211,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1133,'分宜县',17,211,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1134,'月湖区',17,213,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1135,'余江县',17,213,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1136,'贵溪市',17,213,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1137,'章贡区',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1138,'赣县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1139,'信丰县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1140,'大余县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1141,'上犹县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1142,'崇义县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1143,'安远县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1144,'龙南县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1145,'定南县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1146,'全南县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1147,'宁都县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1148,'于都县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1149,'兴国县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1150,'会昌县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1151,'寻乌县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1152,'石城县',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1153,'瑞金市',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1154,'南康市',17,203,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1155,'吉州区',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1156,'青原区',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1157,'吉安县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1158,'吉水县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1159,'峡江县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1160,'新干县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1161,'永丰县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1162,'泰和县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1163,'遂川县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1164,'万安县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1165,'安福县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1166,'永新县',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1167,'井冈山市',17,204,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1168,'袁州区',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1169,'奉新县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1170,'万载县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1171,'上高县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1172,'宜丰县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1173,'靖安县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1174,'铜鼓县',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1175,'丰城市',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1176,'樟树市',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1177,'高安市',17,212,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1178,'临川区',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1179,'南城县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1180,'黎川县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1181,'南丰县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1182,'崇仁县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1183,'乐安县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1184,'宜黄县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1185,'金溪县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1186,'资溪县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1187,'东乡县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1188,'广昌县',17,202,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1189,'信州区',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1190,'上饶县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1191,'广丰县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1192,'玉山县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1193,'铅山县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1194,'横峰县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1195,'弋阳县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1196,'余干县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1197,'鄱阳县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1198,'万年县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1199,'婺源县',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1200,'德兴市',17,209,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1201,'历下区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1202,'市中区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1203,'槐荫区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1204,'天桥区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1205,'历城区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1206,'长清区',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1207,'平阴县',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1208,'济阳县',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1209,'商河县',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1210,'章丘市',22,257,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1211,'市南区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1212,'市北区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1213,'四方区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1214,'黄岛区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1215,'崂山区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1216,'李沧区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1217,'城阳区',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1218,'胶州市',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1219,'即墨市',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1220,'平度市',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1221,'胶南市',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1222,'莱西市',22,262,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1223,'淄川区',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1224,'张店区',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1225,'博山区',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1226,'临淄区',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1227,'周村区',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1228,'桓台县',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1229,'高青县',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1230,'沂源县',22,270,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1231,'市中区',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1232,'薛城区',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1233,'峄城区',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1234,'台儿庄区',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1235,'山亭区',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1236,'滕州市',22,269,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1237,'东营区',22,255,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1238,'河口区',22,255,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1239,'垦利县',22,255,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1240,'利津县',22,255,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1241,'广饶县',22,255,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1242,'芝罘区',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1243,'福山区',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1244,'牟平区',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1245,'莱山区',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1246,'长岛县',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1247,'龙口市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1248,'莱阳市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1249,'莱州市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1250,'蓬莱市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1251,'招远市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1252,'栖霞市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1253,'海阳市',22,268,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1254,'潍城区',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1255,'寒亭区',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1256,'坊子区',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1257,'奎文区',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1258,'临朐县',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1259,'昌乐县',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1260,'青州市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1261,'诸城市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1262,'寿光市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1263,'安丘市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1264,'高密市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1265,'昌邑市',22,267,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1266,'市中区',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1267,'任城区',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1268,'微山县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1269,'鱼台县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1270,'金乡县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1271,'嘉祥县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1272,'汶上县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1273,'泗水县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1274,'梁山县',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1275,'曲阜市',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1276,'兖州市',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1277,'邹城市',22,258,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1278,'泰山区',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1279,'岱岳区',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1280,'宁阳县',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1281,'东平县',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1282,'新泰市',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1283,'肥城市',22,264,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1284,'环翠区',22,266,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1285,'文登市',22,266,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1286,'荣成市',22,266,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1287,'乳山市',22,266,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1288,'东港区',22,263,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1289,'岚山区',22,263,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1290,'五莲县',22,263,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1291,'莒县',22,263,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1292,'莱城区',22,259,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1293,'钢城区',22,259,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1294,'兰山区',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1295,'罗庄区',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1296,'河东区',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1297,'沂南县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1298,'郯城县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1299,'沂水县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1300,'苍山县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1301,'费县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1302,'平邑县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1303,'莒南县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1304,'蒙阴县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1305,'临沭县',22,261,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1306,'德城区',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1307,'陵县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1308,'宁津县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1309,'庆云县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1310,'临邑县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1311,'齐河县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1312,'平原县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1313,'夏津县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1314,'武城县',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1315,'乐陵市',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1316,'禹城市',22,254,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1317,'东昌府区',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1318,'阳谷县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1319,'莘县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1320,'茌平县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1321,'东阿县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1322,'冠县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1323,'高唐县',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1324,'临清市',22,260,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1325,'滨城区',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1326,'惠民县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1327,'阳信县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1328,'无棣县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1329,'沾化县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1330,'博兴县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1331,'邹平县',22,253,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1332,'中原区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1333,'二七区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1334,'管城回族区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1335,'金水区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1336,'上街区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1337,'惠济区',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1338,'中牟县',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1339,'巩义市',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1340,'荥阳市',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1341,'新密市',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1342,'新郑市',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1343,'登封市',11,133,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1344,'龙亭区',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1345,'顺河回族区',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1346,'鼓楼区',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1347,'南关区',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1348,'郊区',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1349,'杞县',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1350,'通许县',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1351,'尉氏县',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1352,'开封县',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1353,'兰考县',11,122,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1354,'老城区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1355,'西工区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1356,'廛河回族区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1357,'涧西区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1358,'吉利区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1359,'洛龙区',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1360,'孟津县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1361,'新安县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1362,'栾川县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1363,'嵩县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1364,'汝阳县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1365,'宜阳县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1366,'洛宁县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1367,'伊川县',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1368,'偃师市',11,123,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1369,'新华区',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1370,'卫东区',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1371,'石龙区',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1372,'湛河区',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1373,'宝丰县',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1374,'叶县',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1375,'鲁山县',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1376,'郏县',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1377,'舞钢市',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1378,'汝州市',11,126,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1379,'文峰区',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1380,'北关区',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1381,'殷都区',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1382,'龙安区',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1383,'安阳县',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1384,'汤阴县',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1385,'滑县',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1386,'内黄县',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1387,'林州市',11,118,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1388,'鹤山区',11,119,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1389,'山城区',11,119,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1390,'淇滨区',11,119,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1391,'浚县',11,119,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1392,'淇县',11,119,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1393,'红旗区',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1394,'卫滨区',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1395,'凤泉区',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1396,'牧野区',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1397,'新乡县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1398,'获嘉县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1399,'原阳县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1400,'延津县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1401,'封丘县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1402,'长垣县',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1403,'卫辉市',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1404,'辉县市',11,130,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1405,'解放区',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1406,'中站区',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1407,'马村区',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1408,'山阳区',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1409,'修武县',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1410,'博爱县',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1411,'武陟县',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1412,'温县',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1413,'济源市',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1414,'沁阳市',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1415,'孟州市',11,121,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1416,'华龙区',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1417,'清丰县',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1418,'南乐县',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1419,'范县',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1420,'台前县',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1421,'濮阳县',11,127,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1422,'魏都区',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1423,'许昌县',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1424,'鄢陵县',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1425,'襄城县',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1426,'禹州市',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1427,'长葛市',11,132,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1428,'源汇区',11,124,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1429,'郾城区',11,124,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1430,'召陵区',11,124,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1431,'舞阳县',11,124,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1432,'临颍县',11,124,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1433,'市辖区',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1434,'湖滨区',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1435,'渑池县',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1436,'陕县',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1437,'卢氏县',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1438,'义马市',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1439,'灵宝市',11,128,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1440,'宛城区',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1441,'卧龙区',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1442,'南召县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1443,'方城县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1444,'西峡县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1445,'镇平县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1446,'内乡县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1447,'淅川县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1448,'社旗县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1449,'唐河县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1450,'新野县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1451,'桐柏县',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1452,'邓州市',11,125,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1453,'梁园区',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1454,'睢阳区',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1455,'民权县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1456,'睢县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1457,'宁陵县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1458,'柘城县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1459,'虞城县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1460,'夏邑县',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1461,'永城市',11,129,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1462,'浉河区',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1463,'平桥区',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1464,'罗山县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1465,'光山县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1466,'新县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1467,'商城县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1468,'固始县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1469,'潢川县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1470,'淮滨县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1471,'息县',11,131,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1472,'川汇区',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1473,'扶沟县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1474,'西华县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1475,'商水县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1476,'沈丘县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1477,'郸城县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1478,'淮阳县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1479,'太康县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1480,'鹿邑县',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1481,'项城市',11,134,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1482,'驿城区',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1483,'西平县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1484,'上蔡县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1485,'平舆县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1486,'正阳县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1487,'确山县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1488,'泌阳县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1489,'汝南县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1490,'遂平县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1491,'新蔡县',11,135,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1492,'江岸区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1493,'江汉区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1494,'硚口区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1495,'汉阳区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1496,'武昌区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1497,'青山区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1498,'洪山区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1499,'东西湖区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1500,'汉南区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1501,'蔡甸区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1502,'江夏区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1503,'黄陂区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1504,'新洲区',13,160,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1505,'黄石港区',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1506,'西塞山区',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1507,'下陆区',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1508,'铁山区',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1509,'阳新县',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1510,'大冶市',13,152,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1511,'茅箭区',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1512,'张湾区',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1513,'郧县',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1514,'郧西县',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1515,'竹山县',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1516,'竹溪县',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1517,'房县',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1518,'丹江口市',13,157,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1519,'西陵区',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1520,'伍家岗区',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1521,'点军区',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1522,'猇亭区',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1523,'夷陵区',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1524,'远安县',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1525,'兴山县',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1526,'秭归县',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1527,'长阳土家族自治县',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1528,'五峰土家族自治县',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1529,'宜都市',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1530,'当阳市',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1531,'枝江市',13,165,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1532,'襄城区',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1533,'樊城区',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1534,'襄阳区',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1535,'南漳县',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1536,'谷城县',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1537,'保康县',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1538,'老河口市',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1539,'枣阳市',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1540,'宜城市',13,163,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1541,'梁子湖区',13,149,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1542,'华容区',13,149,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1543,'鄂城区',13,149,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1544,'东宝区',13,153,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1545,'掇刀区',13,153,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1546,'京山县',13,153,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1547,'沙洋县',13,153,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1548,'钟祥市',13,153,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1549,'孝南区',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1550,'孝昌县',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1551,'大悟县',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1552,'云梦县',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1553,'应城市',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1554,'安陆市',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1555,'汉川市',13,164,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1556,'沙市区',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1557,'荆州区',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1558,'公安县',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1559,'监利县',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1560,'江陵县',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1561,'石首市',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1562,'洪湖市',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1563,'松滋市',13,154,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1564,'黄州区',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1565,'团风县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1566,'红安县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1567,'罗田县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1568,'英山县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1569,'浠水县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1570,'蕲春县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1571,'黄梅县',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1572,'麻城市',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1573,'武穴市',13,151,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1574,'咸安区',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1575,'嘉鱼县',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1576,'通城县',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1577,'崇阳县',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1578,'通山县',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1579,'赤壁市',13,162,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1580,'曾都区',13,158,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1581,'广水市',13,158,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1582,'恩施市',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1583,'利川市',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1584,'建始县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1585,'巴东县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1586,'宣恩县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1587,'咸丰县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1588,'来凤县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1589,'鹤峰县',13,150,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1590,'仙桃市',13,156,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1591,'潜江市',13,156,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1592,'天门市',13,156,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1593,'神农架林区',13,156,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1594,'芙蓉区',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1595,'天心区',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1596,'岳麓区',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1597,'开福区',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1598,'雨花区',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1599,'长沙县',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1600,'望城县',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1601,'宁乡县',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1602,'浏阳市',14,166,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1603,'雨湖区',14,173,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1604,'岳塘区',14,173,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1605,'湘潭县',14,173,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1606,'湘乡市',14,173,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1607,'韶山市',14,173,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1608,'珠晖区',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1609,'雁峰区',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1610,'石鼓区',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1611,'蒸湘区',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1612,'南岳区',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1613,'衡阳县',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1614,'衡南县',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1615,'衡山县',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1616,'衡东县',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1617,'祁东县',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1618,'耒阳市',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1619,'常宁市',14,169,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1620,'双清区',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1621,'大祥区',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1622,'北塔区',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1623,'邵东县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1624,'新邵县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1625,'邵阳县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1626,'隆回县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1627,'洞口县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1628,'绥宁县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1629,'新宁县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1630,'城步苗族自治县',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1631,'武冈市',14,172,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1632,'岳阳楼区',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1633,'云溪区',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1634,'君山区',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1635,'岳阳县',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1636,'华容县',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1637,'湘阴县',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1638,'平江县',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1639,'汨罗市',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1640,'临湘市',14,177,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1641,'武陵区',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1642,'鼎城区',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1643,'安乡县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1644,'汉寿县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1645,'澧县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1646,'临澧县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1647,'桃源县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1648,'石门县',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1649,'津市市',14,167,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1650,'永定区',14,178,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1651,'武陵源区',14,178,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1652,'慈利县',14,178,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1653,'桑植县',14,178,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1654,'资阳区',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1655,'赫山区',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1656,'南县',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1657,'桃江县',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1658,'安化县',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1659,'沅江市',14,175,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1660,'北湖区',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1661,'苏仙区',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1662,'桂阳县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1663,'宜章县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1664,'永兴县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1665,'嘉禾县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1666,'临武县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1667,'汝城县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1668,'桂东县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1669,'安仁县',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1670,'资兴市',14,168,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1671,'芝山区',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1672,'冷水滩区',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1673,'祁阳县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1674,'东安县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1675,'双牌县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1676,'道县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1677,'江永县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1678,'宁远县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1679,'蓝山县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1680,'新田县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1681,'江华瑶族自治县',14,176,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1682,'鹤城区',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1683,'中方县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1684,'沅陵县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1685,'辰溪县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1686,'溆浦县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1687,'会同县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1688,'麻阳苗族自治县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1689,'新晃侗族自治县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1690,'芷江侗族自治县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1691,'靖州苗族侗族自治县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1692,'通道侗族自治县',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1693,'洪江市',14,170,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1694,'娄星区',14,171,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1695,'双峰县',14,171,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1696,'新化县',14,171,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1697,'冷水江市',14,171,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1698,'涟源市',14,171,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1699,'吉首市',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1700,'泸溪县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1701,'凤凰县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1702,'花垣县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1703,'保靖县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1704,'古丈县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1705,'永顺县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1706,'龙山县',14,174,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1707,'东山区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1708,'荔湾区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1709,'越秀区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1710,'海珠区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1711,'天河区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1712,'芳村区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1713,'白云区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1714,'黄埔区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1715,'番禺区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1716,'花都区',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1717,'增城市',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1718,'从化市',6,48,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1719,'武江区',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1720,'浈江区',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1721,'曲江区',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1722,'始兴县',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1723,'仁化县',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1724,'翁源县',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1725,'乳源瑶族自治县',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1726,'新丰县',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1727,'乐昌市',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1728,'南雄市',6,58,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1729,'罗湖区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1730,'福田区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1731,'南山区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1732,'宝安区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1733,'龙岗区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1734,'盐田区',6,59,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1735,'香洲区',6,65,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1736,'斗门区',6,65,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1737,'金湾区',6,65,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1738,'龙湖区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1739,'金平区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1740,'濠江区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1741,'潮阳区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1742,'潮南区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1743,'澄海区',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1744,'南澳县',6,56,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1745,'禅城区',6,47,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1746,'南海区',6,47,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1747,'顺德区',6,47,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1748,'三水区',6,47,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1749,'高明区',6,47,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1750,'蓬江区',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1751,'江海区',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1752,'新会区',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1753,'台山市',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1754,'开平市',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1755,'鹤山市',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1756,'恩平市',6,51,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1757,'赤坎区',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1758,'霞山区',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1759,'坡头区',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1760,'麻章区',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1761,'遂溪县',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1762,'徐闻县',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1763,'廉江市',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1764,'雷州市',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1765,'吴川市',6,62,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1766,'茂南区',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1767,'茂港区',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1768,'电白县',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1769,'高州市',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1770,'化州市',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1771,'信宜市',6,53,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1772,'端州区',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1773,'鼎湖区',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1774,'广宁县',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1775,'怀集县',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1776,'封开县',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1777,'德庆县',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1778,'高要市',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1779,'四会市',6,63,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1780,'惠城区',6,50,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1781,'惠阳区',6,50,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1782,'博罗县',6,50,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1783,'惠东县',6,50,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1784,'龙门县',6,50,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1785,'梅江区',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1786,'梅县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1787,'大埔县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1788,'丰顺县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1789,'五华县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1790,'平远县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1791,'蕉岭县',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1792,'兴宁市',6,54,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1793,'城区',6,57,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1794,'海丰县',6,57,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1795,'陆河县',6,57,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1796,'陆丰市',6,57,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1797,'源城区',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1798,'紫金县',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1799,'龙川县',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1800,'连平县',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1801,'和平县',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1802,'东源县',6,49,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1803,'江城区',6,60,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1804,'阳西县',6,60,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1805,'阳东县',6,60,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1806,'阳春市',6,60,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1807,'清城区',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1808,'佛冈县',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1809,'阳山县',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1810,'连山壮族瑶族自治县',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1811,'连南瑶族自治县',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1812,'清新县',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1813,'英德市',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1814,'连州市',6,55,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1815,'湘桥区',6,45,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1816,'潮安县',6,45,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1817,'饶平县',6,45,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1818,'榕城区',6,52,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1819,'揭东县',6,52,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1820,'揭西县',6,52,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1821,'惠来县',6,52,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1822,'普宁市',6,52,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1823,'云城区',6,61,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1824,'新兴县',6,61,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1825,'郁南县',6,61,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1826,'云安县',6,61,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1827,'罗定市',6,61,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1828,'兴宁区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1829,'青秀区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1830,'江南区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1831,'西乡塘区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1832,'良庆区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1833,'邕宁区',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1834,'武鸣县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1835,'隆安县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1836,'马山县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1837,'上林县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1838,'宾阳县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1839,'横县',7,76,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1840,'城中区',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1841,'鱼峰区',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1842,'柳南区',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1843,'柳北区',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1844,'柳江县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1845,'柳城县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1846,'鹿寨县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1847,'融安县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1848,'融水苗族自治县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1849,'三江侗族自治县',7,75,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1850,'秀峰区',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1851,'叠彩区',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1852,'象山区',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1853,'七星区',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1854,'雁山区',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1855,'阳朔县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1856,'临桂县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1857,'灵川县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1858,'全州县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1859,'兴安县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1860,'永福县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1861,'灌阳县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1862,'龙胜各族自治县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1863,'资源县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1864,'平乐县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1865,'荔蒲县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1866,'恭城瑶族自治县',7,71,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1867,'万秀区',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1868,'蝶山区',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1869,'长洲区',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1870,'苍梧县',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1871,'藤县',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1872,'蒙山县',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1873,'岑溪市',7,78,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1874,'海城区',7,67,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1875,'银海区',7,67,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1876,'铁山港区',7,67,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1877,'合浦县',7,67,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1878,'港口区',7,69,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1879,'防城区',7,69,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1880,'上思县',7,69,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1881,'东兴市',7,69,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1882,'钦南区',7,77,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1883,'钦北区',7,77,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1884,'灵山县',7,77,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1885,'浦北县',7,77,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1886,'港北区',7,70,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1887,'港南区',7,70,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1888,'覃塘区',7,70,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1889,'平南县',7,70,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1890,'桂平市',7,70,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1891,'玉州区',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1892,'容县',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1893,'陆川县',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1894,'博白县',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1895,'兴业县',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1896,'北流市',7,79,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1897,'右江区',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1898,'田阳县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1899,'田东县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1900,'平果县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1901,'德保县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1902,'靖西县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1903,'那坡县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1904,'凌云县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1905,'乐业县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1906,'田林县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1907,'西林县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1908,'隆林各族自治县',7,66,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1909,'八步区',7,73,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1910,'昭平县',7,73,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1911,'钟山县',7,73,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1912,'富川瑶族自治县',7,73,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1913,'金城江区',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1914,'南丹县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1915,'天峨县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1916,'凤山县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1917,'东兰县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1918,'罗城仫佬族自治县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1919,'环江毛南族自治县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1920,'巴马瑶族自治县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1921,'都安瑶族自治县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1922,'大化瑶族自治县',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1923,'宜州市',7,72,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1924,'兴宾区',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1925,'忻城县',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1926,'象州县',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1927,'武宣县',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1928,'金秀瑶族自治县',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1929,'合山市',7,74,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1930,'江洲区',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1931,'扶绥县',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1932,'宁明县',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1933,'龙州县',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1934,'大新县',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1935,'天等县',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1936,'凭祥市',7,68,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1937,'秀英区',9,96,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1938,'龙华区',9,96,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1939,'琼山区',9,96,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1940,'美兰区',9,96,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1941,'五指山市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1942,'琼海市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1943,'儋州市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1944,'文昌市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1945,'万宁市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1946,'东方市',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1947,'定安县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1948,'屯昌县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1949,'澄迈县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1950,'临高县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1951,'白沙黎族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1952,'昌江黎族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1953,'乐东黎族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1954,'陵水黎族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1955,'保亭黎族苗族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1956,'琼中黎族苗族自治县',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1957,'西沙群岛',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1958,'南沙群岛',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1959,'中沙群岛的岛礁及其海域',9,102,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1960,'万州区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1961,'涪陵区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1962,'渝中区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1963,'大渡口区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1964,'江北区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1965,'沙坪坝区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1966,'九龙坡区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1967,'南岸区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1968,'北碚区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1969,'万盛区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1970,'双桥区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1971,'渝北区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1972,'巴南区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1973,'黔江区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1974,'长寿区',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1975,'綦江县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1976,'潼南县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1977,'铜梁县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1978,'大足县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1979,'荣昌县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1980,'璧山县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1981,'梁平县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1982,'城口县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1983,'丰都县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1984,'垫江县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1985,'武隆县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1986,'忠县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1987,'开县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1988,'云阳县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1989,'奉节县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1990,'巫山县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1991,'巫溪县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1992,'石柱土家族自治县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1993,'秀山土家族苗族自治县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1994,'酉阳土家族苗族自治县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1995,'彭水苗族土家族自治县',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1996,'江津市',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1997,'合川市',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1998,'永川市',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 1999,'南川市',34,373,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2000,'锦江区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2001,'青羊区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2002,'金牛区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2003,'武侯区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2004,'成华区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2005,'龙泉驿区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2006,'青白江区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2007,'新都区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2008,'温江区',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2009,'金堂县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2010,'双流县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2011,'郫县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2012,'大邑县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2013,'蒲江县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2014,'新津县',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2015,'都江堰市',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2016,'彭州市',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2017,'邛崃市',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2018,'崇州市',26,295,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2019,'自流井区',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2020,'贡井区',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2021,'大安区',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2022,'沿滩区',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2023,'荣县',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2024,'富顺县',26,313,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2025,'东区',26,308,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2026,'西区',26,308,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2027,'仁和区',26,308,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2028,'米易县',26,308,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2029,'盐边县',26,308,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2030,'江阳区',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2031,'纳溪区',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2032,'龙马潭区',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2033,'泸县',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2034,'合江县',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2035,'叙永县',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2036,'古蔺县',26,303,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2037,'旌阳区',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2038,'中江县',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2039,'罗江县',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2040,'广汉市',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2041,'什邡市',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2042,'绵竹市',26,297,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2043,'涪城区',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2044,'游仙区',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2045,'三台县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2046,'盐亭县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2047,'安县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2048,'梓潼县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2049,'北川羌族自治县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2050,'平武县',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2051,'江油市',26,305,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2052,'市中区',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2053,'元坝区',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2054,'朝天区',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2055,'旺苍县',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2056,'青川县',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2057,'剑阁县',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2058,'苍溪县',26,300,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2059,'船山区',26,309,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2060,'安居区',26,309,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2061,'蓬溪县',26,309,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2062,'射洪县',26,309,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2063,'大英县',26,309,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2064,'市中区',26,306,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2065,'东兴区',26,306,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2066,'威远县',26,306,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2067,'资中县',26,306,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2068,'隆昌县',26,306,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2069,'市中区',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2070,'沙湾区',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2071,'五通桥区',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2072,'金口河区',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2073,'犍为县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2074,'井研县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2075,'夹江县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2076,'沐川县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2077,'峨边彝族自治县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2078,'马边彝族自治县',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2079,'峨眉山市',26,301,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2080,'顺庆区',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2081,'高坪区',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2082,'嘉陵区',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2083,'南部县',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2084,'营山县',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2085,'蓬安县',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2086,'仪陇县',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2087,'西充县',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2088,'阆中市',26,307,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2089,'东坡区',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2090,'仁寿县',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2091,'彭山县',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2092,'洪雅县',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2093,'丹棱县',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2094,'青神县',26,304,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2095,'翠屏区',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2096,'宜宾县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2097,'南溪县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2098,'江安县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2099,'长宁县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2100,'高县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2101,'珙县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2102,'筠连县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2103,'兴文县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2104,'屏山县',26,311,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2105,'广安区',26,299,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2106,'岳池县',26,299,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2107,'武胜县',26,299,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2108,'邻水县',26,299,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2109,'华蓥市',26,299,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2110,'通川区',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2111,'达县',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2112,'宣汉县',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2113,'开江县',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2114,'大竹县',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2115,'渠县',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2116,'万源市',26,296,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2117,'雨城区',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2118,'名山县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2119,'荥经县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2120,'汉源县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2121,'石棉县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2122,'天全县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2123,'芦山县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2124,'宝兴县',26,310,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2125,'巴州区',26,294,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2126,'通江县',26,294,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2127,'南江县',26,294,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2128,'平昌县',26,294,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2129,'雁江区',26,312,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2130,'安岳县',26,312,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2131,'乐至县',26,312,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2132,'简阳市',26,312,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2133,'汶川县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2134,'理县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2135,'茂县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2136,'松潘县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2137,'九寨沟县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2138,'金川县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2139,'小金县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2140,'黑水县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2141,'马尔康县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2142,'壤塘县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2143,'阿坝县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2144,'若尔盖县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2145,'红原县',26,293,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2146,'康定县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2147,'泸定县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2148,'丹巴县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2149,'九龙县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2150,'雅江县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2151,'道孚县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2152,'炉霍县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2153,'甘孜县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2154,'新龙县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2155,'德格县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2156,'白玉县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2157,'石渠县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2158,'色达县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2159,'理塘县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2160,'巴塘县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2161,'乡城县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2162,'稻城县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2163,'得荣县',26,298,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2164,'西昌市',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2165,'木里藏族自治县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2166,'盐源县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2167,'德昌县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2168,'会理县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2169,'会东县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2170,'宁南县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2171,'普格县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2172,'布拖县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2173,'金阳县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2174,'昭觉县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2175,'喜德县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2176,'冕宁县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2177,'越西县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2178,'甘洛县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2179,'美姑县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2180,'雷波县',26,302,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2181,'南明区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2182,'云岩区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2183,'花溪区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2184,'乌当区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2185,'白云区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2186,'小河区',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2187,'开阳县',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2188,'息烽县',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2189,'修文县',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2190,'清镇市',8,82,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2191,'钟山区',8,83,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2192,'六枝特区',8,83,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2193,'水城县',8,83,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2194,'盘县',8,83,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2195,'红花岗区',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2196,'汇川区',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2197,'遵义县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2198,'桐梓县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2199,'绥阳县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2200,'正安县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2201,'道真仡佬族苗族自治县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2202,'务川仡佬族苗族自治县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2203,'凤冈县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2204,'湄潭县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2205,'余庆县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2206,'习水县',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2207,'赤水市',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2208,'仁怀市',8,88,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2209,'西秀区',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2210,'平坝县',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2211,'普定县',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2212,'镇宁布依族苗族自治县',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2213,'关岭布依族苗族自治县',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2214,'紫云苗族布依族自治县',8,80,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2215,'铜仁市',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2216,'江口县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2217,'玉屏侗族自治县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2218,'石阡县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2219,'思南县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2220,'印江土家族苗族自治县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2221,'德江县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2222,'沿河土家族自治县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2223,'松桃苗族自治县',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2224,'万山特区',8,87,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2225,'兴义市',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2226,'兴仁县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2227,'普安县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2228,'晴隆县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2229,'贞丰县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2230,'望谟县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2231,'册亨县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2232,'安龙县',8,86,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2233,'毕节市',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2234,'大方县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2235,'黔西县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2236,'金沙县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2237,'织金县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2238,'纳雍县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2239,'威宁彝族回族苗族自治县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2240,'赫章县',8,81,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2241,'凯里市',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2242,'黄平县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2243,'施秉县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2244,'三穗县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2245,'镇远县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2246,'岑巩县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2247,'天柱县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2248,'锦屏县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2249,'剑河县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2250,'台江县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2251,'黎平县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2252,'榕江县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2253,'从江县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2254,'雷山县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2255,'麻江县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2256,'丹寨县',8,84,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2257,'都匀市',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2258,'福泉市',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2259,'荔波县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2260,'贵定县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2261,'瓮安县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2262,'独山县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2263,'平塘县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2264,'罗甸县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2265,'长顺县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2266,'龙里县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2267,'惠水县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2268,'三都水族自治县',8,85,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2269,'五华区',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2270,'盘龙区',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2271,'官渡区',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2272,'西山区',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2273,'东川区',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2274,'呈贡县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2275,'晋宁县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2276,'富民县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2277,'宜良县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2278,'石林彝族自治县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2279,'嵩明县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2280,'禄劝彝族苗族自治县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2281,'寻甸回族彝族自治县',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2282,'安宁市',32,352,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2283,'麒麟区',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2284,'马龙县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2285,'陆良县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2286,'师宗县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2287,'罗平县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2288,'富源县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2289,'会泽县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2290,'沾益县',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2291,'宣威市',32,356,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2292,'红塔区',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2293,'江川县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2294,'澄江县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2295,'通海县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2296,'华宁县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2297,'易门县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2298,'峨山彝族自治县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2299,'新平彝族傣族自治县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2300,'元江哈尼族彝族傣族自治县',32,360,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2301,'隆阳区',32,346,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2302,'施甸县',32,346,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2303,'腾冲县',32,346,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2304,'龙陵县',32,346,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2305,'昌宁县',32,346,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2306,'昭阳区',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2307,'鲁甸县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2308,'巧家县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2309,'盐津县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2310,'大关县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2311,'永善县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2312,'绥江县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2313,'镇雄县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2314,'彝良县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2315,'威信县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2316,'水富县',32,361,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2317,'古城区',32,353,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2318,'玉龙纳西族自治县',32,353,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2319,'永胜县',32,353,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2320,'华坪县',32,353,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2321,'宁蒗彝族自治县',32,353,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2322,'翠云区',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2323,'普洱哈尼族彝族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2324,'墨江哈尼族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2325,'景东彝族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2326,'景谷傣族彝族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2327,'镇沅彝族哈尼族拉祜族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2328,'江城哈尼族彝族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2329,'孟连傣族拉祜族佤族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2330,'澜沧拉祜族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2331,'西盟佤族自治县',32,357,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2332,'临翔区',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2333,'凤庆县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2334,'云县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2335,'永德县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2336,'镇康县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2337,'双江拉祜族佤族布朗族傣族自治县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2338,'耿马傣族佤族自治县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2339,'沧源佤族自治县',32,354,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2340,'楚雄市',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2341,'双柏县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2342,'牟定县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2343,'南华县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2344,'姚安县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2345,'大姚县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2346,'永仁县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2347,'元谋县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2348,'武定县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2349,'禄丰县',32,347,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2350,'个旧市',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2351,'开远市',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2352,'蒙自县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2353,'屏边苗族自治县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2354,'建水县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2355,'石屏县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2356,'弥勒县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2357,'泸西县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2358,'元阳县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2359,'红河县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2360,'金平苗族瑶族傣族自治县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2361,'绿春县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2362,'河口瑶族自治县',32,351,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2363,'文山县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2364,'砚山县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2365,'西畴县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2366,'麻栗坡县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2367,'马关县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2368,'丘北县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2369,'广南县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2370,'富宁县',32,358,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2371,'景洪市',32,359,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2372,'勐海县',32,359,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2373,'勐腊县',32,359,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2374,'大理市',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2375,'漾濞彝族自治县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2376,'祥云县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2377,'宾川县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2378,'弥渡县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2379,'南涧彝族自治县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2380,'巍山彝族回族自治县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2381,'永平县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2382,'云龙县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2383,'洱源县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2384,'剑川县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2385,'鹤庆县',32,348,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2386,'瑞丽市',32,349,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2387,'潞西市',32,349,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2388,'梁河县',32,349,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2389,'盈江县',32,349,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2390,'陇川县',32,349,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2391,'泸水县',32,355,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2392,'福贡县',32,355,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2393,'贡山独龙族怒族自治县',32,355,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2394,'兰坪白族普米族自治县',32,355,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2395,'香格里拉县',32,350,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2396,'德钦县',32,350,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2397,'维西傈僳族自治县',32,350,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2398,'城关区',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2399,'林周县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2400,'当雄县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2401,'尼木县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2402,'曲水县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2403,'堆龙德庆县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2404,'达孜县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2405,'墨竹工卡县',29,324,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2406,'昌都县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2407,'江达县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2408,'贡觉县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2409,'类乌齐县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2410,'丁青县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2411,'察雅县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2412,'八宿县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2413,'左贡县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2414,'芒康县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2415,'洛隆县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2416,'边坝县',29,323,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2417,'乃东县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2418,'扎囊县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2419,'贡嘎县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2420,'桑日县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2421,'琼结县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2422,'曲松县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2423,'措美县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2424,'洛扎县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2425,'加查县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2426,'隆子县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2427,'错那县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2428,'浪卡子县',29,328,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2429,'日喀则市',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2430,'南木林县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2431,'江孜县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2432,'定日县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2433,'萨迦县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2434,'拉孜县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2435,'昂仁县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2436,'谢通门县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2437,'白朗县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2438,'仁布县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2439,'康马县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2440,'定结县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2441,'仲巴县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2442,'亚东县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2443,'吉隆县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2444,'聂拉木县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2445,'萨嘎县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2446,'岗巴县',29,327,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2447,'那曲县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2448,'嘉黎县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2449,'比如县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2450,'聂荣县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2451,'安多县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2452,'申扎县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2453,'索县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2454,'班戈县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2455,'巴青县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2456,'尼玛县',29,326,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2457,'普兰县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2458,'札达县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2459,'噶尔县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2460,'日土县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2461,'革吉县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2462,'改则县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2463,'措勤县',29,322,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2464,'林芝县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2465,'工布江达县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2466,'米林县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2467,'墨脱县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2468,'波密县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2469,'察隅县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2470,'朗县',29,325,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2471,'新城区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2472,'碑林区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2473,'莲湖区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2474,'灞桥区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2475,'未央区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2476,'雁塔区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2477,'阎良区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2478,'临潼区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2479,'长安区',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2480,'蓝田县',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2481,'周至县',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2482,'户县',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2483,'高陵县',24,288,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2484,'王益区',24,286,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2485,'印台区',24,286,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2486,'耀州区',24,286,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2487,'宜君县',24,286,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2488,'渭滨区',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2489,'金台区',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2490,'陈仓区',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2491,'凤翔县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2492,'岐山县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2493,'扶风县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2494,'眉县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2495,'陇县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2496,'千阳县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2497,'麟游县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2498,'凤县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2499,'太白县',24,283,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2500,'秦都区',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2501,'杨凌区',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2502,'渭城区',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2503,'三原县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2504,'泾阳县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2505,'乾县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2506,'礼泉县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2507,'永寿县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2508,'彬县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2509,'长武县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2510,'旬邑县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2511,'淳化县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2512,'武功县',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2513,'兴平市',24,289,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2514,'临渭区',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2515,'华县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2516,'潼关县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2517,'大荔县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2518,'合阳县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2519,'澄城县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2520,'蒲城县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2521,'白水县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2522,'富平县',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2523,'韩城市',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2524,'华阴市',24,287,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2525,'宝塔区',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2526,'延长县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2527,'延川县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2528,'子长县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2529,'安塞县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2530,'志丹县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2531,'吴旗县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2532,'甘泉县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2533,'富县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2534,'洛川县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2535,'宜川县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2536,'黄龙县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2537,'黄陵县',24,290,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2538,'汉台区',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2539,'南郑县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2540,'城固县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2541,'洋县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2542,'西乡县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2543,'勉县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2544,'宁强县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2545,'略阳县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2546,'镇巴县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2547,'留坝县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2548,'佛坪县',24,284,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2549,'榆阳区',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2550,'神木县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2551,'府谷县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2552,'横山县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2553,'靖边县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2554,'定边县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2555,'绥德县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2556,'米脂县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2557,'佳县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2558,'吴堡县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2559,'清涧县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2560,'子洲县',24,291,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2561,'汉滨区',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2562,'汉阴县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2563,'石泉县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2564,'宁陕县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2565,'紫阳县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2566,'岚皋县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2567,'平利县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2568,'镇坪县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2569,'旬阳县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2570,'白河县',24,282,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2571,'商州区',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2572,'洛南县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2573,'丹凤县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2574,'商南县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2575,'山阳县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2576,'镇安县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2577,'柞水县',24,285,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2578,'城关区',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2579,'七里河区',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2580,'西固区',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2581,'安宁区',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2582,'红古区',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2583,'永登县',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2584,'皋兰县',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2585,'榆中县',5,37,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2586,'金川区',5,35,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2587,'永昌县',5,35,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2588,'白银区',5,30,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2589,'平川区',5,30,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2590,'靖远县',5,30,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2591,'会宁县',5,30,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2592,'景泰县',5,30,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2593,'秦城区',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2594,'北道区',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2595,'清水县',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2596,'秦安县',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2597,'甘谷县',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2598,'武山县',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2599,'张家川回族自治县',5,42,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2600,'凉州区',5,43,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2601,'民勤县',5,43,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2602,'古浪县',5,43,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2603,'天祝藏族自治县',5,43,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2604,'甘州区',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2605,'肃南裕固族自治县',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2606,'民乐县',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2607,'临泽县',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2608,'高台县',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2609,'山丹县',5,44,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2610,'崆峒区',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2611,'泾川县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2612,'灵台县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2613,'崇信县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2614,'华亭县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2615,'庄浪县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2616,'静宁县',5,40,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2617,'肃州区',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2618,'金塔县',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2619,'安西县',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2620,'肃北蒙古族自治县',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2621,'阿克塞哈萨克族自治县',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2622,'玉门市',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2623,'敦煌市',5,36,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2624,'西峰区',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2625,'庆城县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2626,'环县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2627,'华池县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2628,'合水县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2629,'正宁县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2630,'宁县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2631,'镇原县',5,41,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2632,'安定区',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2633,'通渭县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2634,'陇西县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2635,'渭源县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2636,'临洮县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2637,'漳县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2638,'岷县',5,31,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2639,'武都区',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2640,'成县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2641,'文县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2642,'宕昌县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2643,'康县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2644,'西和县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2645,'礼县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2646,'徽县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2647,'两当县',5,39,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2648,'临夏市',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2649,'临夏县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2650,'康乐县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2651,'永靖县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2652,'广河县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2653,'和政县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2654,'东乡族自治县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2655,'积石山保安族东乡族撒拉族自治县',5,38,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2656,'合作市',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2657,'临潭县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2658,'卓尼县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2659,'舟曲县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2660,'迭部县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2661,'玛曲县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2662,'碌曲县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2663,'夏河县',5,33,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2664,'城东区',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2665,'城中区',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2666,'城西区',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2667,'城北区',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2668,'大通回族土族自治县',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2669,'湟中县',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2670,'湟源县',21,251,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2671,'平安县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2672,'民和回族土族自治县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2673,'乐都县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2674,'互助土族自治县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2675,'化隆回族自治县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2676,'循化撒拉族自治县',21,247,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2677,'门源回族自治县',21,246,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2678,'祁连县',21,246,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2679,'海晏县',21,246,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2680,'刚察县',21,246,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2681,'同仁县',21,250,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2682,'尖扎县',21,250,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2683,'泽库县',21,250,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2684,'河南蒙古族自治县',21,250,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2685,'共和县',21,248,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2686,'同德县',21,248,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2687,'贵德县',21,248,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2688,'兴海县',21,248,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2689,'贵南县',21,248,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2690,'玛沁县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2691,'班玛县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2692,'甘德县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2693,'达日县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2694,'久治县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2695,'玛多县',21,245,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2696,'玉树县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2697,'杂多县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2698,'称多县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2699,'治多县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2700,'囊谦县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2701,'曲麻莱县',21,252,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2702,'格尔木市',21,249,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2703,'德令哈市',21,249,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2704,'乌兰县',21,249,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2705,'都兰县',21,249,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2706,'天峻县',21,249,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2707,'兴庆区',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2708,'西夏区',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2709,'金凤区',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2710,'永宁县',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2711,'贺兰县',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2712,'灵武市',20,243,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2713,'大武口区',20,241,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2714,'惠农区',20,241,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2715,'平罗县',20,241,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2716,'利通区',20,242,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2717,'盐池县',20,242,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2718,'同心县',20,242,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2719,'青铜峡市',20,242,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2720,'原州区',20,240,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2721,'西吉县',20,240,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2722,'隆德县',20,240,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2723,'泾源县',20,240,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2724,'彭阳县',20,240,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2725,'天山区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2726,'沙依巴克区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2727,'新市区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2728,'水磨沟区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2729,'头屯河区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2730,'达坂城区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2731,'东山区',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2732,'乌鲁木齐县',31,343,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2733,'独山子区',31,338,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2734,'克拉玛依区',31,338,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2735,'白碱滩区',31,338,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2736,'乌尔禾区',31,338,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2737,'吐鲁番市',31,342,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2738,'鄯善县',31,342,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2739,'托克逊县',31,342,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2740,'哈密市',31,335,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2741,'巴里坤哈萨克自治县',31,335,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2742,'伊吾县',31,335,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2743,'昌吉市',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2744,'阜康市',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2745,'米泉市',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2746,'呼图壁县',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2747,'玛纳斯县',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2748,'奇台县',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2749,'吉木萨尔县',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2750,'木垒哈萨克自治县',31,334,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2751,'博乐市',31,333,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2752,'精河县',31,333,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2753,'温泉县',31,333,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2754,'库尔勒市',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2755,'轮台县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2756,'尉犁县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2757,'若羌县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2758,'且末县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2759,'焉耆回族自治县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2760,'和静县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2761,'和硕县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2762,'博湖县',31,332,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2763,'阿克苏市',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2764,'温宿县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2765,'库车县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2766,'沙雅县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2767,'新和县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2768,'拜城县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2769,'乌什县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2770,'阿瓦提县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2771,'柯坪县',31,330,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2772,'阿图什市',31,339,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2773,'阿克陶县',31,339,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2774,'阿合奇县',31,339,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2775,'乌恰县',31,339,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2776,'喀什市',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2777,'疏附县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2778,'疏勒县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2779,'英吉沙县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2780,'泽普县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2781,'莎车县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2782,'叶城县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2783,'麦盖提县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2784,'岳普湖县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2785,'伽师县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2786,'巴楚县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2787,'塔什库尔干塔吉克自治县',31,337,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2788,'和田市',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2789,'和田县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2790,'墨玉县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2791,'皮山县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2792,'洛浦县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2793,'策勒县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2794,'于田县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2795,'民丰县',31,336,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2796,'伊宁市',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2797,'奎屯市',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2798,'伊宁县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2799,'察布查尔锡伯自治县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2800,'霍城县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2801,'巩留县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2802,'新源县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2803,'昭苏县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2804,'特克斯县',31,345,'')
 INSERT [tbl_SysDistrict] ([Id],[Name],[ProvinceId],[CityId],[HeaderLetter]) VALUES ( 2805,'尼勒克县',31,345,'')

 
SET IDENTITY_INSERT tbl_SysDistrict OFF



go


--地标处理

SET IDENTITY_INSERT tbl_SystemLandMark ON


 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1,'安康机场',282,'AKA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (2,'火车站',282,'AKA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (3,'黄果树景区',80,'ANS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (4,'火车站',80,'ANS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (5,'市区',80,'ANS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (6,'火车站',214,'AOG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (7,'火车站',1,'AQG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (8,'火车站',118,'AYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (9,'火车站',107,'BAD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (10,'火车站',283,'BAJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (11,'火车站',181,'BAS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (12,'包头二里半机场',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (13,'火车站',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (14,'昆都仑区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (15,'青山区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (16,'中部地区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (17,'火车站',215,'BEX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (18,'火车站',2,'BFU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (19,'北海福城机场',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (20,'海城区',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (21,'银海地区',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (22,'火车站',66,'BSI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (23,'白云区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (24,'北京路步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (25,'北京路步行街、海珠广场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (26,'东圃',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (27,'东圃、经济开发区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (28,'番禺区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (29,'芳村花地湾',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (30,'广州新白云国际机场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (31,'海珠广场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (32,'花都区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (33,'环市东路附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (34,'火车东站',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (35,'火车站',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (36,'火车站、越秀公园附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (37,'经济开发区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (38,'萝岗',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (39,'琶洲国际会展中心附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (40,'其它',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (41,'沙面岛',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (42,'沙面岛、上下九步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (43,'上下九步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (44,'天河体育中心',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (45,'新白云国际机场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (46,'越秀公园附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (47,'增城区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (48,'珠江南（河南）地区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (49,'火车站',108,'CAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (50,'火车站',168,'CEZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (51,'常德桃花源机场',167,'CGD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (52,'火车站地区',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (53,'老工业基地',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (54,'商业金融中心',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (55,'郑东新区',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (56,'郑州新郑国际机场',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (57,'长春经济技术开发区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (58,'工业区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (59,'商业金融中心',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (60,'文化教育区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (61,'火车站',109,'CHD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (62,'市中心地区',334,'CHJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (63,'火车站',36,'CHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (64,'北碚区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (65,'菜园坝火车站',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (66,'长寿区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (67,'朝天门地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (68,'大渡口区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (69,'大田湾体育场',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (70,'大足县',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (71,'丰都县城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (72,'高新技术开发区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (73,'观音桥步行街',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (74,'国际会展中心',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (75,'火车站',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (76,'江北地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (77,'江津区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (78,'解放碑地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (79,'南岸地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (80,'人民广场地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (81,'沙坪坝地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (82,'石桥铺电脑城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (83,'武隆县城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (84,'小梅沙）地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (85,'盐田（大',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (86,'重庆大学老校区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (87,'重庆江北国际机场',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (88,'长沙黄花国际机场',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (89,'贺龙体育中心地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (90,'火车站地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (91,'开福寺地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (92,'南城区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (93,'文教区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (94,'五一广场地区（市中心）',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (95,'成都双流国际机场',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (96,'春熙路商业区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (97,'火车北站地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (98,'火车南站地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (99,'火车站',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (100,'机场地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (101,'骡马市商业区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (102,'世纪城新会展商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (103,'市中心文化区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (104,'水碾河商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (105,'太升路商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (106,'武侯祠商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (107,'一品天下商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (108,'火车站',45,'CZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (109,'山上',4,'CZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (110,'山下',4,'CZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (111,'常州奔牛机场',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (112,'常州新区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (113,'火车站地区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (114,'市中心火车站区域',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (115,'市中心区域',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (116,'武进高新区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (117,'新北开发区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (118,'高新区',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (119,'火车站',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (120,'亚龙湾',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (121,'宾西街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (122,'大南街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (123,'大西街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (124,'火车站',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (125,'市中心',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (126,'火车站',93,'DAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (127,'火车站',218,'DDG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (128,'茶山镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (129,'长安镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (130,'常平镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (131,'大朗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (132,'大岭山镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (133,'东坑镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (134,'东莞市区',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (135,'凤岗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (136,'高埗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (137,'洪梅镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (138,'厚街镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (139,'虎门镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (140,'黄江镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (141,'寮步镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (142,'桥头镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (143,'石碣镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (144,'石龙镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (145,'石排镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (146,'塘厦镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (147,'樟木头镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (148,'中堂镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (149,'大连开发区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (150,'大连开发区、金石滩国家旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (151,'大连周水子国际机场',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (152,'甘井子地区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (153,'海滨风景旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (154,'火车站',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (155,'金石滩国家旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (156,'沙河口',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (157,'沙河口、甘井子地区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (158,'商业金融中心',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (159,'商业金融中心区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (160,'大理机场',348,'DLU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (161,'火车站',348,'DLU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (162,'敦煌机场',32,'DNH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (163,'东营机场',255,'DOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (164,'火车站',255,'DOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (165,'火车站',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (166,'景区',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (167,'森林公园',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (168,'市区',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (169,'索溪峪',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (170,'火车站',296,'DZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (171,'火车站',254,'DZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (172,'恩施机场',150,'ENH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (173,'火车站',290,'ENY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (174,'延安二十里铺机场',290,'ENY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (175,'火车站',232,'ERD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (176,'城东地区',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (177,'福州长乐国际机场',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (178,'火车站地区',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (179,'温泉公园附近（市中心）',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (180,'五一广场附近',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (181,'西湖公园附近',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (182,'阜阳西关机场',6,'FUG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (183,'火车站',6,'FUG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (184,'禅城区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (185,'高明区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (186,'火车站',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (187,'南海区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (188,'三水区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (189,'顺德区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (190,'火车站',219,'FUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (191,'火车站',244,'GOQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (192,'赣州黄金机场',203,'GZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (193,'火车站',203,'GZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (194,'海甸岛',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (195,'海口美兰机场',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (196,'市区',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (197,'西海岸',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (198,'火车站',110,'HDN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (199,'火车站',119,'HEB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (200,'北区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (201,'东区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (202,'呼和浩特白塔国际机场',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (203,'火车站',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (204,'南区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (205,'市中心区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (206,'火车站',49,'HEY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (207,'包河公园商业区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (208,'合肥经济技术开发区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (209,'合肥骆岗国际机场',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (210,'淮河路商业区（市中心）',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (211,'火车站',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (212,'火车站区域',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (213,'市中心区域',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (214,'政务文化新区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (215,'滨江地区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (216,'杭州萧山机场',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (217,'黄龙体育中心',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (218,'火车城站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (219,'火车东站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (220,'火车站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (221,'文教区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (222,'武林广场附近（市中心）',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (223,'西湖景区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (224,'萧山区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (225,'北角',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (226,'北角、鰂鱼涌',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (227,'大角咀 ',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (228,'大角嘴',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (229,'迪士尼景区',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (230,'红勘',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (231,'红磡',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (232,'机场',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (233,'尖沙咀',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (234,'尖沙嘴',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (235,'金钟',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (236,'九龙城',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (237,'荃湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (238,'沙田',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (239,'上环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (240,'太子',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (241,'铜锣湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (242,'湾仔',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (243,'湾仔、铜锣湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (244,'旺角',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (245,'旺角、油麻地',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (246,'西环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (247,'西九龙',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (248,'香港赤喇角机场',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (249,'新界',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (250,'油麻地',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (251,'鲗鱼涌',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (252,'中环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (253,'中环、金钟',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (254,'火车站',221,'HLD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (255,'火车站',169,'HNY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (256,'高新技术开发区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (257,'果戈里大街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (258,'哈尔滨火车站附近',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (259,'哈尔滨太平国际机场',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (260,'红博国际会展中心',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (261,'火车站',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (262,'机场大巴乘车站',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (263,'建设街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (264,'秋林商业区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (265,'商业金融中心（市中心）',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (266,'省政府附近',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (267,'太阳岛',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (268,'文化教育区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (269,'中山路',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (270,'中央大街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (271,'火车站',58,'HSC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (272,'普陀山',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (273,'沈家门',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (274,'嵊泗列岛',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (275,'桃花岛',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (276,'舟山市(定海)',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (277,'朱家尖',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (278,'火车站',111,'HSU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (279,'火车站',190,'HUA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (280,'火车站',10,'HUI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (281,'博罗县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (282,'大亚湾',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (283,'惠城区',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (284,'惠东县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (285,'惠阳区',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (286,'火车站',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (287,'龙门县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (288,'自治区政府区域',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (289,'火车站',256,'HZE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (290,'火车站',284,'HZG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (291,'火车站',73,'HZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (292,'火车站',243,'INC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (293,'火车站',205,'JDZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (294,'景德镇罗家机场',205,'JDZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (295,'火车站',34,'JGN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (296,'江北商业区域',365,'JHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (297,'江南商业区域',365,'JHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (298,'火车站',359,'JHG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (299,'火车站',183,'JIL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (300,'火车站',206,'JIU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (301,'星子县',206,'JIU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (302,'江南摩尔区域',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (303,'南湖景区',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (304,'其它',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (305,'市中心商业区',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (306,'火车站',153,'JMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (307,'火车站',142,'JMU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (308,'火车站',258,'JNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (309,'火车站',222,'JNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (310,'火车站',368,'JUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (311,'火车站',120,'JYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (312,'火车站',274,'JZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (313,'火车站',121,'JZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (314,'火车站',122,'KAF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (315,'市中心地区',337,'KHG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (316,'八一广场地区（市中心）',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (317,'抚河公园风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (318,'红谷滩城市新区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (319,'火车站地区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (320,'青山湖风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (321,'滕王阁风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (322,'市中心地区',338,'KLY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (323,'翠湖地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (324,'火车站地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (325,'昆明巫家坝国际机场',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (326,'市中心商业地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (327,'政治文化地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (328,'周边地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (329,'火车站',204,'KNC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (330,'贵阳龙洞堡国际机场',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (331,'火车站地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (332,'甲秀楼地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (333,'黔灵公园地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (334,'市中心地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (335,'桂林两江国际机场',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (336,'国展中心地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (337,'火车站地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (338,'市中心湖景地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (339,'市中心江景地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (340,'火车站',112,'LAF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (341,'火车站',259,'LAW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (342,'火车站',260,'LCN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (343,'火车站',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (344,'兰州中川机场',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (345,'七里河体育场地区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (346,'市中心商业区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (347,'西区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (348,'火车站',275,'LIF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (349,'白沙古镇',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (350,'大研古镇内',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (351,'大研古镇外',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (352,'火车站',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (353,'丽江三义机场',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (354,'泸沽湖',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (355,'束河古镇',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (356,'新城',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (357,'火车站',171,'LOD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (358,'火车站',21,'LOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (359,'火车站',301,'LSA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (360,'土桥街',301,'LSA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (361,'火车站',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (362,'拉萨贡嘎机场',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (363,'中部',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (364,'经济开发区',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (365,'老城区',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (366,'市中心区域',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (367,'海滨度假区',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (368,'火车站',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (369,'商业金融中心区',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (370,'火车站',261,'LYI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (371,'火车站',75,'LZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (372,'柳州白莲机场',75,'LZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (373,'火车站',13,'MAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (374,'火车站',53,'MAM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (375,'澳门半岛',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (376,'凼仔',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (377,'路凼',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (378,'路环',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (379,'绵阳南郊机场',305,'MIG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (380,'南充高坪机场',307,'NAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (381,'火车站',145,'NDG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (382,'火车站',306,'NEJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (383,'北仑港区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (384,'东钱湖风景区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (385,'海曙商业区（市中心）',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (386,'火车站',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (387,'江北商业区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (388,'江东商业区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (389,'宁波栎社国际机场',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (390,'城东地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (391,'夫子庙地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (392,'鼓楼地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (393,'河西奥体中心地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (394,'湖南路地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (395,'火车站地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (396,'江宁开发区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (397,'南部地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (398,'南京禄口国际机场',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (399,'山西路地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (400,'汤山温泉度假区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (401,'新街口地区（市中心）',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (402,'玄武湖景区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (403,'珍珠泉景区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (404,'中山陵地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (405,'珠江路电子一条街',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (406,'总统府附近',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (407,'国际会展中心',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (408,'火车站地区',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (409,'南湖开发区',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (410,'自治区政府区域',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (411,'火车站',125,'NNY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (412,'白沙古镇',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (413,'城东南',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (414,'火车站',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (415,'南通汽车站',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (416,'市中心区域',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (417,'安贞地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (418,'奥运村商圈',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (419,'八角游乐园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (420,'北京南苑国际机场',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (421,'北京首都国际机场、新国展地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (422,'北京站',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (423,'北京站、建国门、国贸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (424,'北京周边度假区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (425,'崇文门商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (426,'东二环工人体育场地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (427,'公主坟',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (428,'公主坟、万寿路商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (429,'国贸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (430,'国展中心地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (431,'后海地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (432,'火车站',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (433,'建国门地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (434,'金融街地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (435,'劲松',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (436,'劲松、潘家园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (437,'马甸',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (438,'马甸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (439,'南海区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (440,'南站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (441,'潘家园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (442,'前门',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (443,'前门、崇文门商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (444,'上地',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (445,'上地、中关村地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (446,'首都机场',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (447,'天安门、王府井地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (448,'万寿路',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (449,'望京地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (450,'西单',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (451,'西单、金融街地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (452,'西客站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (453,'西直门及北京展览馆地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (454,'新国展地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (455,'亚运村',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (456,'亚运村、奥运村商圈',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (457,'燕莎商业区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (458,'亦庄地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (459,'永定门',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (460,'永定门、南站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (461,'中关村地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (462,'火车站',208,'PIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (463,'火车站',24,'PUT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (464,'火车站地区',127,'PUY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (465,'火车站',308,'PZI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (466,'火车站',100,'QHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (467,'火车站',25,'QUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (468,'泉州晋江机场',25,'QUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (469,'火车站',55,'QYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (470,'火车站',327,'RIK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (471,'火车站',263,'RIZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (472,'北外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (473,'曹杨',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (474,'曹杨、真如地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (475,'漕河泾开发区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (476,'打浦桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (477,'番禺区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (478,'虹桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (479,'虹桥枢纽地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (480,'沪太',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (481,'沪太、彭浦地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (482,'淮海路地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (483,'江湾',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (484,'静安寺地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (485,'南汇',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (486,'南外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (487,'彭浦地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (488,'浦东机场区域',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (489,'浦东金桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (490,'浦东陆家嘴金融贸易区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (491,'浦东世博园区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (492,'浦东外高桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (493,'浦东新国际博览中心',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (494,'浦东张江地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (495,'七宝',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (496,'人民广场地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (497,'人民广场附近',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (498,'上海虹桥机场',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (499,'上海火车南站地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (500,'上海火车站地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (501,'上海浦东国际机场',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (502,'上海周边地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (503,'上海周边度假区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (504,'佘山',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (505,'蛇口（南山）地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (506,'世博园区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (507,'四川北路商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (508,'松江大学城',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (509,'外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (510,'外滩附近',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (511,'五角场商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (512,'莘庄',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (513,'徐家汇',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (514,'徐家汇地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (515,'豫园',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (516,'豫园地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (517,'真如地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (518,'中山公园商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (519,'周边地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (520,'大东区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (521,'火车站',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (522,'老工业区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (523,'商业金融中心区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (524,'沈阳桃仙国际机场',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (525,'太原街',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (526,'文教区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (527,'火车站',285,'SHL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (528,'火车站',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (529,'火车站区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (530,'秦皇岛港区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (531,'秦皇岛山海关机场',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (532,'人民广场区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (533,'山海关区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (534,'火车站',209,'SHR') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (535,'城南新区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (536,'火车站地区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (537,'柯桥',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (538,'绍兴经济开发区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (539,'市中心地区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (540,'北部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (541,'东部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (542,'高新技术开发区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (543,'火车站',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (544,'南部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (545,'曲江会展区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (546,'市中心地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (547,'西安咸阳国际机场',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (548,'西部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (549,'长安公园',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (550,'长安公园、省博物馆地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (551,'城西区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (552,'火车站地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (553,'省博物馆地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (554,'石家庄正定机场',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (555,'火车站',309,'SUN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (556,'火车站',158,'SUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (557,'火车站地区',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (558,'汕头外砂机场',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (559,'市中心区域',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (560,'火车站',172,'SYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (561,'大东海',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (562,'火车站',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (563,'南田温泉',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (564,'三亚凤凰机场',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (565,'三亚湾',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (566,'市区',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (567,'小东海',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (568,'亚龙湾',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (569,'北京路步行街',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (570,'观前街地区（市中心）',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (571,'海珠广场',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (572,'火车站地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (573,'盘门地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (574,'十全街地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (575,'石路商业区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (576,'苏州工业园区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (577,'苏州新区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (578,'太湖风景区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (579,'万达广场',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (580,'阳澄湖旅游度假区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (581,'宝安区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (582,'地王大厦附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (583,'高交会',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (584,'高交会、皇岗口岸地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (585,'华强北地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (586,'华侨城地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (587,'皇岗口岸地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (588,'科技园地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (589,'龙岗区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (590,'龙岗中心城地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (591,'罗湖地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (592,'罗湖东门步行街地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (593,'罗湖国贸大厦附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (594,'罗湖口岸、火车站附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (595,'南澳海滨度假区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (596,'蛇口（南山）地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (597,'深南东路新秀立交附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (598,'深圳宝安国际机场',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (599,'深圳大学附近地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (600,'深圳体育馆附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (601,'深圳周边度假区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (602,'天安数码城、竹子林地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (603,'西丽湖野生动物园附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (604,'小梅沙）地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (605,'盐田（大',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (606,'红门区',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (607,'火车站',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (608,'泰山广场区',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (609,'奥帆中心区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (610,'八大关景区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (611,'半岛商务中心（市政府）',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (612,'第一海滨浴场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (613,'第一海水浴场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (614,'黄岛经济技术开发区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (615,'火车站',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (616,'李沧商圈',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (617,'青岛流亭国际机场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (618,'石老人风景区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (619,'市北中央商务区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (620,'市政府区（市中心）',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (621,'四方长途汽车站区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (622,'四方区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (623,'台东商圈特色旅游区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (624,'栈桥区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (625,'黄岩城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (626,'火车站',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (627,'椒江城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (628,'路桥城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (629,'通辽机场',235,'TGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (630,'火车站',226,'TIL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (631,'火车站',42,'TIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (632,'长途汽车总站区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (633,'高新技术开发区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (634,'洪楼广场区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (635,'火车站',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (636,'济南遥墙机场',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (637,'泉城广场商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (638,'人民商场商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (639,'市中心商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (640,'舜耕国际会展中心区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (641,'植物园',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (642,'火车站',15,'TOG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (643,'北辰区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (644,'滨海国际机场地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (645,'滨海新区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (646,'滨江道',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (647,'长虹公园地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (648,'古文化街地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (649,'国际展览中心地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (650,'和平区（市中心）',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (651,'河北区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (652,'河东区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (653,'河西区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (654,'红桥区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (655,'华苑地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (656,'火车站',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (657,'梅江会展中心地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (658,'南开区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (659,'天津滨海国际机场',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (660,'旺角',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (661,'望海楼',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (662,'小白楼商业区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (663,'油麻地',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (664,'市中心地区',342,'TUL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (665,'黄山屯溪国际机场',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (666,'火车站',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (667,'山脚北大门',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (668,'山脚南大门',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (669,'山上',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (670,'山下',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (671,'市区(屯溪区)',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (672,'汤口',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (673,'长枫桥',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (674,'大营盘',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (675,'府东商业区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (676,'火车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (677,'建南汽车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (678,'宽银幕',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (679,'龙潭公园',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (680,'南部地区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (681,'山西省人大',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (682,'山西省政府',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (683,'太原东站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (684,'太原高新技术产业开发区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (685,'太原理工大学',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (686,'太原武宿国际机场',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (687,'汤山温泉度假区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (688,'五一广场',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (689,'西部地区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (690,'漪汾桥',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (691,'迎宾汽车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (692,'迎泽商业区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (693,'经济开发区',196,'TZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (694,'北京路',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (695,'高新区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (696,'国际博览中心地区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (697,'开发区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (698,'市中心地区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (699,'乌鲁木齐地窝堡机场',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (700,'乌鲁木齐铁路局',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (701,'新疆医科大学医学院',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (702,'火车站',105,'WEC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (703,'开发区',267,'WEF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (704,'市中心',267,'WEF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (705,'北海旅游度假区',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (706,'东海岸',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (707,'火车站',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (708,'市中心',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (709,'西海岸',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (710,'火车站',236,'WHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (711,'火车站区域',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (712,'经济技术开发区',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (713,'镜湖广场',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (714,'火车站地区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (715,'鹿城区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (716,'路桥城区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (717,'市中心地区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (718,'温州经济开发区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (719,'温州永强机场',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (720,'东湖高新技术开发区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (721,'光谷科技中心',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (722,'汉口火车站地区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (723,'汉口商业金融区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (724,'汉阳',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (725,'洪山广场、东湖国家旅游风景区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (726,'青山工业区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (727,'三环线',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (728,'王家墩商业区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (729,'武昌火车站地区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (730,'武汉天河国际机场',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (731,'中南商业圈',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (732,'度假区',27,'WUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (733,'市区',27,'WUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (734,'高新开发区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (735,'工业园区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (736,'惠山风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (737,'火车站附近地区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (738,'马山风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (739,'汽车南站区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (740,'汽车西站区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (741,'三阳广场(市中心)地区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (742,'太湖风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (743,'无锡硕放机场',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (744,'五爱广场',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (745,'锡山体育场区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (746,'火车站',78,'WUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (747,'火车站',163,'XFN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (748,'火车站',164,'XGN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (749,'市中心',14,'XIO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (750,'火车站',173,'XIT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (751,'火车站',289,'XIY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (752,'白鹭洲风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (753,'东渡',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (754,'鼓浪屿风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (755,'湖里工业园区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (756,'环岛路风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (757,'会展中心',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (758,'火车站附近',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (759,'江头',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (760,'莲坂',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (761,'轮渡区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (762,'南普陀厦大',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (763,'松柏小区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (764,'厦门高崎国际机场',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (765,'中山路',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (766,'中山路、轮渡区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (767,'东部地区',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (768,'火车站',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (769,'市中心',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (770,'西部地区',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (771,'火车站',116,'XNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (772,'火车站',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (773,'商业金融（市中心）区',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (774,'云龙湖景区',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (775,'火车站',310,'YAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (776,'宜宾莱坝机场',311,'YBP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (777,'火车站',212,'YIC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (778,'火车站',165,'YIH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (779,'火车站',227,'YIK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (780,'火车站',213,'YIT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (781,'火车站',175,'YIY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (782,'第二海水浴场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (783,'第一海水浴场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (784,'经济开发区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (785,'莱山区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (786,'商业中心区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (787,'市中心地区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (788,'烟台莱山机场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (789,'火车站',199,'YNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (790,'江苏盐城南洋机场',199,'YNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (791,'火车站',281,'YUC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (792,'运城关公机场',281,'YUC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (793,'火车站',360,'YUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (794,'火车站',177,'YUY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (795,'火车站',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (796,'市中心区域',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (797,'瘦西湖风景区',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (798,'扬州新区',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (799,'火车站',269,'ZAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (800,'火车站',62,'ZHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (801,'湛江机场',62,'ZHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (802,'火车站',135,'ZHM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (803,'火车站',179,'ZHO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (804,'火车站',63,'ZHQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (805,'市区',63,'ZHQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (806,'火车站',44,'ZHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (807,'火车站',29,'ZHZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (808,'火车站',270,'ZIB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (809,'市中心',270,'ZIB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (810,'火车站',313,'ZIG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (811,'东区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (812,'古镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (813,'三角镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (814,'三乡镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (815,'沙溪镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (816,'石岐区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (817,'西区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (818,'小榄镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (819,'火车站地区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (820,'南山风景区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (821,'市中心地区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (822,'火车站',117,'ZJK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (823,'拱北',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (824,'火车站',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (825,'吉大',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (826,'南屏镇',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (827,'前山',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (828,'唐家',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (829,'香洲',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (830,'珠海三灶机场',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (831,'火车站',88,'ZYI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (832,'安康机场',282,'AKA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (833,'火车站',282,'AKA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (837,'火车站',214,'AOG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (838,'火车站',1,'AQG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (839,'火车站',118,'AYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (841,'火车站',283,'BAJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (842,'火车站',181,'BAS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (843,'包头二里半机场',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (844,'火车站',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (845,'昆都仑区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (846,'青山区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (847,'中部地区',230,'BAV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (848,'火车站',215,'BEX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (849,'火车站',2,'BFU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (850,'北海福城机场',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (851,'海城区',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (852,'银海地区',67,'BHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (853,'火车站',66,'BSI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (854,'白云区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (855,'北京路步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (856,'北京路步行街、海珠广场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (857,'东圃',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (858,'东圃、经济开发区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (859,'番禺区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (860,'芳村花地湾',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (861,'广州新白云国际机场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (862,'海珠广场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (863,'花都区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (864,'环市东路附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (865,'火车东站',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (866,'火车站',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (867,'火车站、越秀公园附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (868,'经济开发区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (869,'萝岗',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (870,'琶洲国际会展中心附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (871,'其它',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (872,'沙面岛',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (873,'沙面岛、上下九步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (874,'上下九步行街',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (875,'天河体育中心',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (876,'新白云国际机场',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (877,'越秀公园附近',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (878,'增城区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (879,'珠江南（河南）地区',48,'CAN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (880,'火车站',108,'CAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (881,'火车站',168,'CEZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (882,'常德桃花源机场',167,'CGD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (883,'火车站地区',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (884,'老工业基地',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (885,'商业金融中心',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (886,'郑东新区',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (887,'郑州新郑国际机场',133,'CGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (888,'长春经济技术开发区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (889,'工业区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (890,'商业金融中心',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (891,'文化教育区',182,'CGQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (892,'火车站',109,'CHD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (893,'市中心地区',334,'CHJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (894,'火车站',36,'CHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (895,'北碚区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (896,'菜园坝火车站',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (897,'长寿区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (898,'朝天门地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (899,'大渡口区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (900,'大田湾体育场',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (901,'大足县',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (902,'丰都县城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (903,'高新技术开发区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (904,'观音桥步行街',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (905,'国际会展中心',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (906,'火车站',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (907,'江北地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (908,'江津区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (909,'解放碑地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (910,'南岸地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (911,'人民广场地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (912,'沙坪坝地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (913,'石桥铺电脑城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (914,'武隆县城',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (915,'小梅沙）地区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (916,'盐田（大',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (917,'重庆大学老校区',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (918,'重庆江北国际机场',373,'CKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (919,'长沙黄花国际机场',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (920,'贺龙体育中心地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (921,'火车站地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (922,'开福寺地区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (923,'南城区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (924,'文教区',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (925,'五一广场地区（市中心）',166,'CSX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (926,'成都双流国际机场',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (927,'春熙路商业区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (928,'火车北站地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (929,'火车南站地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (930,'火车站',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (931,'机场地区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (932,'骡马市商业区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (933,'世纪城新会展商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (934,'市中心文化区',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (935,'水碾河商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (936,'太升路商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (937,'武侯祠商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (938,'一品天下商业圈',295,'CTU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (939,'火车站',45,'CZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (940,'山上',4,'CZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (941,'山下',4,'CZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (942,'常州奔牛机场',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (943,'常州新区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (944,'火车站地区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (945,'市中心火车站区域',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (946,'市中心区域',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (947,'武进高新区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (948,'新北开发区',189,'CZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (949,'高新区',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (950,'火车站',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (951,'亚龙湾',136,'DAQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (952,'宾西街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (953,'大南街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (954,'大西街',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (955,'火车站',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (956,'市中心',272,'DAT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (957,'火车站',93,'DAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (958,'火车站',218,'DDG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (959,'茶山镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (960,'长安镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (961,'常平镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (962,'大朗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (963,'大岭山镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (964,'东坑镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (965,'东莞市区',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (966,'凤岗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (967,'高埗镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (968,'洪梅镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (969,'厚街镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (970,'虎门镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (971,'黄江镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (972,'寮步镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (973,'桥头镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (974,'石碣镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (975,'石龙镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (976,'石排镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (977,'塘厦镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (978,'樟木头镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (979,'中堂镇',46,'DGM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (980,'大连开发区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (981,'大连开发区、金石滩国家旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (982,'大连周水子国际机场',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (983,'甘井子地区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (984,'海滨风景旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (985,'火车站',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (986,'金石滩国家旅游度假区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (987,'沙河口',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (988,'沙河口、甘井子地区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (989,'商业金融中心',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (990,'商业金融中心区',217,'DLC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (991,'大理机场',348,'DLU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (992,'火车站',348,'DLU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (993,'敦煌机场',32,'DNH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (994,'东营机场',255,'DOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (995,'火车站',255,'DOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (996,'火车站',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (997,'景区',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (998,'森林公园',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (999,'市区',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1000,'索溪峪',178,'DYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1001,'火车站',296,'DZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1002,'火车站',254,'DZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1003,'恩施机场',150,'ENH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1004,'火车站',290,'ENY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1005,'延安二十里铺机场',290,'ENY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1006,'火车站',232,'ERD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1007,'城东地区',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1008,'福州长乐国际机场',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1009,'火车站地区',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1010,'温泉公园附近（市中心）',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1011,'五一广场附近',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1012,'西湖公园附近',20,'FOC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1013,'阜阳西关机场',6,'FUG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1014,'火车站',6,'FUG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1015,'禅城区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1016,'高明区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1017,'火车站',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1018,'南海区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1019,'三水区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1020,'顺德区',47,'FUO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1021,'火车站',219,'FUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1022,'火车站',244,'GOQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1023,'赣州黄金机场',203,'GZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1024,'火车站',203,'GZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1025,'海甸岛',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1026,'海口美兰机场',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1027,'市区',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1028,'西海岸',96,'HAK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1029,'火车站',110,'HDN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1030,'火车站',119,'HEB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1031,'北区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1032,'东区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1033,'呼和浩特白塔国际机场',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1034,'火车站',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1035,'南区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1036,'市中心区',233,'HET') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1037,'火车站',49,'HEY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1038,'包河公园商业区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1039,'合肥经济技术开发区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1040,'合肥骆岗国际机场',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1041,'淮河路商业区（市中心）',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1042,'火车站',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1043,'火车站区域',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1044,'市中心区域',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1045,'政务文化新区',8,'HFE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1046,'滨江地区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1047,'杭州萧山机场',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1048,'黄龙体育中心',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1049,'火车城站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1050,'火车东站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1051,'火车站',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1052,'文教区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1053,'武林广场附近（市中心）',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1054,'西湖景区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1055,'萧山区',362,'HGH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1056,'北角',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1057,'北角、鰂鱼涌',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1058,'大角咀 ',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1059,'大角嘴',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1060,'迪士尼景区',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1061,'红勘',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1062,'红磡',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1063,'机场',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1064,'尖沙咀',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1065,'尖沙嘴',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1066,'金钟',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1067,'九龙城',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1068,'荃湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1069,'沙田',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1070,'上环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1071,'太子',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1072,'铜锣湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1073,'湾仔',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1074,'湾仔、铜锣湾',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1075,'旺角',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1076,'旺角、油麻地',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1077,'西环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1078,'西九龙',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1079,'香港赤喇角机场',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1080,'新界',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1081,'油麻地',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1082,'鲗鱼涌',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1083,'中环',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1084,'中环、金钟',329,'HKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1085,'火车站',221,'HLD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1086,'火车站',169,'HNY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1087,'高新技术开发区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1088,'果戈里大街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1089,'哈尔滨火车站附近',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1090,'哈尔滨太平国际机场',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1091,'红博国际会展中心',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1092,'火车站',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1093,'机场大巴乘车站',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1094,'建设街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1095,'秋林商业区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1096,'商业金融中心（市中心）',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1097,'省政府附近',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1098,'太阳岛',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1099,'文化教育区',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1100,'中山路',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1101,'中央大街',138,'HRB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1102,'火车站',58,'HSC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1103,'普陀山',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1104,'沈家门',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1105,'嵊泗列岛',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1106,'桃花岛',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1107,'舟山市(定海)',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1108,'朱家尖',372,'HSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1109,'火车站',111,'HSU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1110,'火车站',190,'HUA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1111,'火车站',10,'HUI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1112,'博罗县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1113,'大亚湾',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1114,'惠城区',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1115,'惠东县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1116,'惠阳区',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1117,'火车站',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1118,'龙门县',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1119,'自治区政府区域',50,'HUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1120,'火车站',256,'HZE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1121,'火车站',284,'HZG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1122,'火车站',73,'HZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1123,'火车站',243,'INC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1124,'火车站',205,'JDZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1125,'景德镇罗家机场',205,'JDZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1126,'火车站',34,'JGN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1127,'江北商业区域',365,'JHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1128,'江南商业区域',365,'JHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1129,'火车站',359,'JHG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1130,'火车站',183,'JIL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1131,'火车站',206,'JIU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1132,'星子县',206,'JIU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1133,'江南摩尔区域',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1134,'南湖景区',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1135,'其它',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1136,'市中心商业区',364,'JIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1137,'火车站',153,'JMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1138,'火车站',142,'JMU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1139,'火车站',258,'JNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1140,'火车站',222,'JNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1141,'火车站',368,'JUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1142,'火车站',120,'JYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1143,'火车站',274,'JZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1144,'火车站',121,'JZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1145,'火车站',122,'KAF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1146,'市中心地区',337,'KHG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1147,'八一广场地区（市中心）',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1148,'抚河公园风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1149,'红谷滩城市新区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1150,'火车站地区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1151,'青山湖风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1152,'滕王阁风景区',207,'KHN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1153,'市中心地区',338,'KLY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1154,'翠湖地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1155,'火车站地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1156,'昆明巫家坝国际机场',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1157,'市中心商业地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1158,'政治文化地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1159,'周边地区',352,'KMG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1160,'火车站',204,'KNC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1161,'贵阳龙洞堡国际机场',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1162,'火车站地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1163,'甲秀楼地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1164,'黔灵公园地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1165,'市中心地区',82,'KWE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1166,'桂林两江国际机场',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1167,'国展中心地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1168,'火车站地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1169,'市中心湖景地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1170,'市中心江景地区',71,'KWL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1171,'火车站',112,'LAF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1172,'火车站',259,'LAW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1173,'火车站',260,'LCN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1174,'火车站',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1175,'兰州中川机场',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1176,'七里河体育场地区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1177,'市中心商业区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1178,'西区',37,'LHW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1179,'火车站',275,'LIF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1180,'白沙古镇',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1181,'大研古镇内',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1182,'大研古镇外',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1183,'火车站',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1184,'丽江三义机场',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1185,'泸沽湖',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1186,'束河古镇',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1187,'新城',353,'LJG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1188,'火车站',171,'LOD') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1189,'火车站',21,'LOY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1190,'火车站',301,'LSA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1191,'土桥街',301,'LSA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1192,'火车站',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1193,'拉萨贡嘎机场',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1194,'中部',324,'LXA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1195,'经济开发区',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1196,'老城区',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1197,'市中心区域',123,'LYA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1198,'海滨度假区',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1199,'火车站',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1200,'商业金融中心区',191,'LYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1201,'火车站',261,'LYI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1202,'火车站',75,'LZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1203,'柳州白莲机场',75,'LZH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1204,'火车站',13,'MAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1205,'火车站',53,'MAM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1206,'澳门半岛',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1207,'凼仔',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1208,'路凼',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1209,'路环',18,'MFM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1210,'绵阳南郊机场',305,'MIG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1211,'南充高坪机场',307,'NAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1212,'火车站',145,'NDG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1213,'火车站',306,'NEJ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1214,'北仑港区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1215,'东钱湖风景区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1216,'海曙商业区（市中心）',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1217,'火车站',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1218,'江北商业区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1219,'江东商业区',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1220,'宁波栎社国际机场',367,'NGB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1221,'城东地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1222,'夫子庙地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1223,'鼓楼地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1224,'河西奥体中心地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1225,'湖南路地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1226,'火车站地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1227,'江宁开发区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1228,'南部地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1229,'南京禄口国际机场',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1230,'山西路地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1231,'汤山温泉度假区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1232,'新街口地区（市中心）',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1233,'玄武湖景区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1234,'珍珠泉景区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1235,'中山陵地区',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1236,'珠江路电子一条街',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1237,'总统府附近',192,'NKG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1238,'国际会展中心',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1239,'火车站地区',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1240,'南湖开发区',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1241,'自治区政府区域',76,'NNG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1242,'火车站',125,'NNY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1243,'白沙古镇',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1244,'城东南',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1245,'火车站',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1246,'南通汽车站',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1247,'市中心区域',193,'NTG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1248,'安贞地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1249,'奥运村商圈',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1250,'八角游乐园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1251,'北京南苑国际机场',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1252,'北京首都国际机场、新国展地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1253,'北京站',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1254,'北京站、建国门、国贸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1255,'北京周边度假区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1256,'崇文门商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1257,'东二环工人体育场地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1258,'公主坟',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1259,'公主坟、万寿路商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1260,'国贸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1261,'国展中心地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1262,'后海地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1263,'火车站',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1264,'建国门地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1265,'金融街地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1266,'劲松',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1267,'劲松、潘家园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1268,'马甸',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1269,'马甸地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1270,'南海区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1271,'南站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1272,'潘家园地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1273,'前门',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1274,'前门、崇文门商贸区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1275,'上地',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1276,'上地、中关村地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1277,'首都机场',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1278,'天安门、王府井地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1279,'万寿路',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1280,'望京地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1281,'西单',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1282,'西单、金融街地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1283,'西客站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1284,'西直门及北京展览馆地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1285,'新国展地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1286,'亚运村',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1287,'亚运村、奥运村商圈',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1288,'燕莎商业区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1289,'亦庄地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1290,'永定门',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1291,'永定门、南站地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1292,'中关村地区',19,'PEK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1293,'火车站',208,'PIX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1294,'火车站',24,'PUT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1295,'火车站地区',127,'PUY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1296,'火车站',308,'PZI') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1297,'火车站',100,'QHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1298,'火车站',25,'QUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1299,'泉州晋江机场',25,'QUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1300,'火车站',55,'QYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1301,'火车站',327,'RIK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1302,'火车站',263,'RIZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1303,'北外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1304,'曹杨',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1305,'曹杨、真如地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1306,'漕河泾开发区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1307,'打浦桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1308,'番禺区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1309,'虹桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1310,'虹桥枢纽地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1311,'沪太',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1312,'沪太、彭浦地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1313,'淮海路地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1314,'江湾',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1315,'静安寺地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1316,'南汇',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1317,'南外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1318,'彭浦地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1319,'浦东机场区域',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1320,'浦东金桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1321,'浦东陆家嘴金融贸易区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1322,'浦东世博园区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1323,'浦东外高桥地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1324,'浦东新国际博览中心',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1325,'浦东张江地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1326,'七宝',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1327,'人民广场地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1328,'人民广场附近',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1329,'上海虹桥机场',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1330,'上海火车南站地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1331,'上海火车站地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1332,'上海浦东国际机场',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1333,'上海周边地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1334,'上海周边度假区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1335,'佘山',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1336,'蛇口（南山）地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1337,'世博园区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1338,'四川北路商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1339,'松江大学城',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1340,'外滩地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1341,'外滩附近',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1342,'五角场商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1343,'莘庄',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1344,'徐家汇',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1345,'徐家汇地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1346,'豫园',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1347,'豫园地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1348,'真如地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1349,'中山公园商业区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1350,'周边地区',292,'SHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1351,'大东区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1352,'火车站',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1353,'老工业区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1354,'商业金融中心区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1355,'沈阳桃仙国际机场',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1356,'太原街',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1357,'文教区',225,'SHE') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1358,'火车站',285,'SHL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1359,'火车站',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1360,'火车站区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1361,'秦皇岛港区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1362,'秦皇岛山海关机场',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1363,'人民广场区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1364,'山海关区',113,'SHP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1365,'火车站',209,'SHR') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1366,'城南新区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1367,'火车站地区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1368,'柯桥',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1369,'绍兴经济开发区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1370,'市中心地区',369,'SHX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1371,'北部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1372,'东部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1373,'高新技术开发区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1374,'火车站',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1375,'南部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1376,'曲江会展区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1377,'市中心地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1378,'西安咸阳国际机场',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1379,'西部地区',288,'SIA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1380,'长安公园',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1381,'长安公园、省博物馆地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1382,'城西区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1383,'火车站地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1384,'省博物馆地区',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1385,'石家庄正定机场',114,'SJW') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1386,'火车站',309,'SUN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1387,'火车站',158,'SUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1388,'火车站地区',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1389,'汕头外砂机场',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1390,'市中心区域',56,'SWA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1391,'火车站',172,'SYG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1392,'大东海',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1393,'火车站',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1394,'南田温泉',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1395,'三亚凤凰机场',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1396,'三亚湾',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1397,'市区',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1398,'小东海',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1399,'亚龙湾',102,'SYX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1400,'北京路步行街',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1401,'观前街地区（市中心）',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1402,'海珠广场',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1403,'火车站地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1404,'盘门地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1405,'十全街地区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1406,'石路商业区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1407,'苏州工业园区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1408,'苏州新区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1409,'太湖风景区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1410,'万达广场',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1411,'阳澄湖旅游度假区',194,'SZV') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1412,'宝安区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1413,'地王大厦附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1414,'高交会',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1415,'高交会、皇岗口岸地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1416,'华强北地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1417,'华侨城地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1418,'皇岗口岸地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1419,'科技园地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1420,'龙岗区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1421,'龙岗中心城地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1422,'罗湖地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1423,'罗湖东门步行街地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1424,'罗湖国贸大厦附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1425,'罗湖口岸、火车站附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1426,'南澳海滨度假区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1427,'蛇口（南山）地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1428,'深南东路新秀立交附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1429,'深圳宝安国际机场',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1430,'深圳大学附近地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1431,'深圳体育馆附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1432,'深圳周边度假区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1433,'天安数码城、竹子林地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1434,'西丽湖野生动物园附近',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1435,'小梅沙）地区',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1436,'盐田（大',59,'SZX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1437,'红门区',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1438,'火车站',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1439,'泰山广场区',264,'TAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1440,'奥帆中心区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1441,'八大关景区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1442,'半岛商务中心（市政府）',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1443,'第一海滨浴场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1444,'第一海水浴场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1445,'黄岛经济技术开发区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1446,'火车站',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1447,'李沧商圈',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1448,'青岛流亭国际机场',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1449,'石老人风景区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1450,'市北中央商务区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1451,'市政府区（市中心）',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1452,'四方长途汽车站区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1453,'四方区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1454,'台东商圈特色旅游区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1455,'栈桥区',262,'TAO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1456,'黄岩城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1457,'火车站',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1458,'椒江城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1459,'路桥城区',370,'TAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1460,'通辽机场',235,'TGO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1461,'火车站',226,'TIL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1462,'火车站',42,'TIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1463,'长途汽车总站区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1464,'高新技术开发区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1465,'洪楼广场区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1466,'火车站',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1467,'济南遥墙机场',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1468,'泉城广场商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1469,'人民商场商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1470,'市中心商业区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1471,'舜耕国际会展中心区',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1472,'植物园',257,'TNA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1473,'火车站',15,'TOG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1474,'北辰区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1475,'滨海国际机场地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1476,'滨海新区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1477,'滨江道',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1478,'长虹公园地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1479,'古文化街地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1480,'国际展览中心地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1481,'和平区（市中心）',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1482,'河北区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1483,'河东区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1484,'河西区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1485,'红桥区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1486,'华苑地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1487,'火车站',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1488,'梅江会展中心地区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1489,'南开区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1490,'天津滨海国际机场',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1491,'旺角',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1492,'望海楼',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1493,'小白楼商业区',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1494,'油麻地',321,'TSN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1495,'市中心地区',342,'TUL') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1496,'黄山屯溪国际机场',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1497,'火车站',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1498,'山脚北大门',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1499,'山脚南大门',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1500,'山上',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1501,'山下',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1502,'市区(屯溪区)',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1503,'汤口',11,'TXN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1504,'长枫桥',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1505,'大营盘',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1506,'府东商业区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1507,'火车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1508,'建南汽车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1509,'宽银幕',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1510,'龙潭公园',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1511,'南部地区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1512,'山西省人大',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1513,'山西省政府',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1514,'太原东站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1515,'太原高新技术产业开发区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1516,'太原理工大学',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1517,'太原武宿国际机场',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1518,'汤山温泉度假区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1519,'五一广场',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1520,'西部地区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1521,'漪汾桥',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1522,'迎宾汽车站',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1523,'迎泽商业区',278,'TYN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1524,'经济开发区',196,'TZU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1525,'北京路',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1526,'高新区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1527,'国际博览中心地区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1528,'开发区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1529,'市中心地区',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1530,'乌鲁木齐地窝堡机场',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1531,'乌鲁木齐铁路局',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1532,'新疆医科大学医学院',343,'URC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1533,'火车站',105,'WEC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1534,'开发区',267,'WEF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1535,'市中心',267,'WEF') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1536,'北海旅游度假区',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1537,'东海岸',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1538,'火车站',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1539,'市中心',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1540,'西海岸',266,'WEH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1541,'火车站',236,'WHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1542,'火车站区域',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1543,'经济技术开发区',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1544,'镜湖广场',16,'WHU') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1545,'火车站地区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1546,'鹿城区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1547,'路桥城区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1548,'市中心地区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1549,'温州经济开发区',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1550,'温州永强机场',371,'WNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1551,'东湖高新技术开发区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1552,'光谷科技中心',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1553,'汉口火车站地区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1554,'汉口商业金融区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1555,'汉阳',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1556,'洪山广场、东湖国家旅游风景区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1557,'青山工业区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1558,'三环线',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1559,'王家墩商业区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1560,'武昌火车站地区',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1561,'武汉天河国际机场',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1562,'中南商业圈',160,'WUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1563,'度假区',27,'WUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1564,'市区',27,'WUS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1565,'高新开发区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1566,'工业园区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1567,'惠山风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1568,'火车站附近地区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1569,'马山风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1570,'汽车南站区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1571,'汽车西站区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1572,'三阳广场(市中心)地区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1573,'太湖风景区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1574,'无锡硕放机场',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1575,'五爱广场',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1576,'锡山体育场区',197,'WUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1577,'火车站',78,'WUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1578,'火车站',163,'XFN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1579,'火车站',164,'XGN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1580,'市中心',14,'XIO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1581,'火车站',173,'XIT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1582,'火车站',289,'XIY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1583,'白鹭洲风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1584,'东渡',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1585,'鼓浪屿风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1586,'湖里工业园区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1587,'环岛路风景区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1588,'会展中心',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1589,'火车站附近',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1590,'江头',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1591,'莲坂',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1592,'轮渡区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1593,'南普陀厦大',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1594,'松柏小区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1595,'厦门高崎国际机场',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1596,'中山路',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1597,'中山路、轮渡区',28,'XMN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1598,'东部地区',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1599,'火车站',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1600,'市中心',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1601,'西部地区',251,'XNN') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1602,'火车站',116,'XNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1603,'火车站',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1604,'商业金融（市中心）区',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1605,'云龙湖景区',198,'XUZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1606,'火车站',310,'YAA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1607,'宜宾莱坝机场',311,'YBP') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1608,'火车站',212,'YIC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1609,'火车站',165,'YIH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1610,'火车站',227,'YIK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1611,'火车站',213,'YIT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1612,'火车站',175,'YIY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1613,'第二海水浴场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1614,'第一海水浴场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1615,'经济开发区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1616,'莱山区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1617,'商业中心区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1618,'市中心地区',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1619,'烟台莱山机场',268,'YNT') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1620,'火车站',199,'YNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1621,'江苏盐城南洋机场',199,'YNZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1622,'火车站',281,'YUC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1623,'运城关公机场',281,'YUC') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1624,'火车站',360,'YUX') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1625,'火车站',177,'YUY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1626,'火车站',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1627,'市中心区域',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1628,'瘦西湖风景区',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1629,'扬州新区',200,'YZO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1630,'火车站',269,'ZAZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1631,'火车站',62,'ZHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1632,'湛江机场',62,'ZHA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1633,'火车站',135,'ZHM') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1634,'火车站',179,'ZHO') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1635,'火车站',63,'ZHQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1636,'市区',63,'ZHQ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1637,'火车站',44,'ZHY') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1638,'火车站',29,'ZHZ') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1639,'火车站',270,'ZIB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1640,'市中心',270,'ZIB') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1641,'火车站',313,'ZIG') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1642,'东区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1643,'古镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1644,'三角镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1645,'三乡镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1646,'沙溪镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1647,'石岐区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1648,'西区',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1649,'小榄镇',64,'ZIS') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1650,'火车站地区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1651,'南山风景区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1652,'市中心地区',201,'ZJA') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1653,'火车站',117,'ZJK') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1654,'拱北',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1655,'火车站',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1656,'吉大',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1657,'南屏镇',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1658,'前山',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1659,'唐家',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1660,'香洲',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1661,'珠海三灶机场',65,'ZUH') 
 insert into tbl_SystemLandMark(Id,Por,CityId,CityCode) values (1662,'火车站',88,'ZYI') 


SET IDENTITY_INSERT tbl_SystemLandMark OFF






--表：tbl_ScenicTheme-----------------------------------------

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicTheme')
            and   type = 'U')
   drop table tbl_ScenicTheme
go

/*==============================================================*/
/* Table: tbl_ScenicTheme                                       */
/*==============================================================*/
create table tbl_ScenicTheme (
   ThemeId              int                  identity,
   ThemeName            nvarchar(100)        not null,
   IsDelete             char(1)              not null default '0',
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   constraint PK_TBL_SCENICTHEME primary key (ThemeId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主题编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicTheme', 'column', 'ThemeId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主题名称',
   'user', @CurrentUser, 'table', 'tbl_ScenicTheme', 'column', 'ThemeName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除(0:否1：是)',
   'user', @CurrentUser, 'table', 'tbl_ScenicTheme', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicTheme', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_ScenicTheme', 'column', 'OperatorId'
go

--表：tbl_ScenicArea-----------------------------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicAreaImg') and o.name = 'FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicAreaImg
   drop constraint FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicRelationLandMark') and o.name = 'FK_TBL_SCENICRELATIONLA_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicRelationLandMark
   drop constraint FK_TBL_SCENICRELATIONLA_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicRelationTheme') and o.name = 'FK_TBL_SCENICRELATIONTH_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicRelationTheme
   drop constraint FK_TBL_SCENICRELATIONTH_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicTickets') and o.name = 'FK_TBL_SCENICTICKETS_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicTickets
   drop constraint FK_TBL_SCENICTICKETS_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicArea')
            and   type = 'U')
   drop table tbl_ScenicArea
go

/*==============================================================*/
/* Table: tbl_ScenicArea                                        */
/*==============================================================*/
create table tbl_ScenicArea (
   ScenicId             char(36)             not null,
   IsRecommend          char(1)              not null default '0',
   ScenicName           nvarchar(100)        not null,
   EnName               varchar(100)         null,
   X                    varchar(100)         null,
   Y                    varchar(100)         null,
   ServiceTel           varchar(50)          null,
   Contact              varchar(50)          null,
   ContactTel           varchar(50)          null,
   ContactMobile        varchar(50)          null,
   ContactFax           varchar(50)          null,
   ProvinceId           int                  not null default 0,
   CityId               int                  not null default 0,
   CountyId             int                  not null default 0,
   CnAddress            nvarchar(100)        null,
   EnAddress            varchar(100)         null,
   ScenicLevel          tinyint              not null default 0,
   Year                 int                  null default 0,
   OpenTime             nvarchar(max)        null,
   Description          nvarchar(max)        null,
   Traffic              nvarchar(max)        null,
   Facilities           nvarchar(max)        null,
   Notes                nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   ClickNum             int                  not null default 0,
   LastUpdateTime       datetime             null,
   Id                   bigint               identity,
   IsDelete             char(1)              not null default '0',
   constraint PK_TBL_SCENICAREA primary key (ScenicId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否推荐',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'IsRecommend'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区名称',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ScenicName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '英文名',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'EnName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经纬度横坐标',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'X'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经纬度纵坐标',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Y'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '客服电话',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ServiceTel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Contact'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ContactTel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '手机号码',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ContactMobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系传真',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ContactFax'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ProvinceId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'CityId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '县区',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'CountyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '中文地址',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'CnAddress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '英文地址',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'EnAddress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区A级',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ScenicLevel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '成立年份',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Year'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '日程开放时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'OpenTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区详细介绍',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交通说明',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Traffic'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '周边设施',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Facilities'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Notes'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '点击量',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'ClickNum'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'LastUpdateTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'tbl_ScenicArea', 'column', 'IsDelete'
go

--表：tbl_ScenicRelationTheme---------------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicRelationTheme') and o.name = 'FK_TBL_SCENICRELATIONTH_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicRelationTheme
   drop constraint FK_TBL_SCENICRELATIONTH_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicRelationTheme')
            and   type = 'U')
   drop table tbl_ScenicRelationTheme
go

/*==============================================================*/
/* Table: tbl_ScenicRelationTheme                               */
/*==============================================================*/
create table tbl_ScenicRelationTheme (
   Id                   int                  identity,
   ScenicId             char(36)             null,
   ThemeId              int                  not null,
   constraint PK_TBL_SCENICRELATIONTHEME primary key (Id),
   constraint AK_KEY_1_TBL_SCEN unique (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationTheme', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationTheme', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主题编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationTheme', 'column', 'ThemeId'
go

alter table tbl_ScenicRelationTheme
   add constraint FK_TBL_SCENICRELATIONTH_REFERENCE_TBL_SCENICAREA foreign key (ScenicId)
      references tbl_ScenicArea (ScenicId)
go

--表：tbl_ScenicRelationLandMark--------------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicRelationLandMark') and o.name = 'FK_TBL_SCENICRELATIONLA_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicRelationLandMark
   drop constraint FK_TBL_SCENICRELATIONLA_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicRelationLandMark')
            and   type = 'U')
   drop table tbl_ScenicRelationLandMark
go

/*==============================================================*/
/* Table: tbl_ScenicRelationLandMark                            */
/*==============================================================*/
create table tbl_ScenicRelationLandMark (
   Id                   int                  identity,
   ScenicId             char(36)             not null,
   LandMarkId           int                  not null,
   constraint PK_TBL_SCENICRELATIONLANDMARK primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationLandMark', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationLandMark', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicRelationLandMark', 'column', 'LandMarkId'
go

alter table tbl_ScenicRelationLandMark
   add constraint FK_TBL_SCENICRELATIONLA_REFERENCE_TBL_SCENICAREA foreign key (ScenicId)
      references tbl_ScenicArea (ScenicId)
go

--表:tbl_ScenicAreaImg----------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicAreaImg') and o.name = 'FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicAreaImg
   drop constraint FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicAreaImg')
            and   type = 'U')
   drop table tbl_ScenicAreaImg
go

/*==============================================================*/
/* Table: tbl_ScenicAreaImg                                     */
/*==============================================================*/
create table tbl_ScenicAreaImg (
   ImgId                char(36)             not null,
   ScenicId             char(36)             null,
   ImgType              tinyint              not null,
   Address              nvarchar(500)        not null,
   ThumbAddress         nvarchar(500)        null,
   Description          nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   constraint PK_TBL_SCENICAREAIMG primary key (ImgId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ImgId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片类型',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ImgType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片地址',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'Address'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片缩略图',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ThumbAddress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片说明',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'OperatorId'
go

alter table tbl_ScenicAreaImg
   add constraint FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA foreign key (ScenicId)
      references tbl_ScenicArea (ScenicId)
go

--表：tbl_ScenicTickets---------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicTickets') and o.name = 'FK_TBL_SCENICTICKETS_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicTickets
   drop constraint FK_TBL_SCENICTICKETS_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicTickets')
            and   type = 'U')
   drop table tbl_ScenicTickets
go

/*==============================================================*/
/* Table: tbl_ScenicTickets                                     */
/*==============================================================*/
create table tbl_ScenicTickets (
   TicketsId            char(36)             not null,
   ScenicId             char(36)             null,
   TypeName             nvarchar(50)         not null,
   EnName               varchar(100)         null,
   RetailPrice          money                null,
   WebsitePrices        money                null,
   MarketPrice          money                null,
   DistributionPrice    money                null,
   Limit                int                  not null default 0,
   StartTime            datetime             null,
   EndTime              datetime             null,
   Description          nvarchar(max)        null,
   SaleDescription      nvarchar(max)        null,
   Status               tinyint              not null default 0,
   CustomOrder          int                  not null default 0,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   LastUpdateTime       datetime             null,
   constraint PK_TBL_SCENICTICKETS primary key (TicketsId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'TicketsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票类型名称',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'TypeName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '英文名称',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'EnName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门市价',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'RetailPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '网站优惠价',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'WebsitePrices'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '市场限制最低价',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'MarketPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '同行分销价',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'DistributionPrice'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最少限制（张/套）',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'Limit'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '票价有效时间_始',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'StartTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '票价游戏时间_止',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'EndTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票说明',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '同业销售须知 （只有同业分销商能看到）',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'SaleDescription'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态（上架，下架）',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自定义排序',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'CustomOrder'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布人',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicTickets', 'column', 'LastUpdateTime'
go

alter table tbl_ScenicTickets
   add constraint FK_TBL_SCENICTICKETS_REFERENCE_TBL_SCENICAREA foreign key (ScenicId)
      references tbl_ScenicArea (ScenicId)
go
---------------------------------------------------------------------







-- =============================================
-- Author:		王磊
-- Create date: 2013-04-11
-- Description:	景点添加
-- =============================================
Create proc [dbo].[proc_ScenicArea_Add]
@ScenicId char(36), 
@IsRecommend char(1), 
@ScenicName nvarchar(100), 
@EnName varchar(100), 
@X varchar(100), 
@Y varchar(100), 
@ServiceTel varchar(50),
@Contact nvarchar(50), 
@ContactTel nvarchar(50), 
@ContactMobile nvarchar(50), 
@ContactFax char(10), 
@ProvinceId int, 
@CityId int, 
@CountyId int, 
@CnAddress nvarchar(100), 
@EnAddress varchar(100), 
@ScenicLevel tinyint, 
@Year int,
@OpenTime nvarchar(max), 
@Description nvarchar(max), 
@Traffic nvarchar(max), 
@Facilities nvarchar(max), 
@Notes nvarchar(max), 
@OperatorId char(36), 
@ScenicRelationLandMark xml,
@ScenicRelationTheme xml,
@Result int output
as
begin
	declare @error int
	set @error=0	
	
	begin transaction
	INSERT INTO tbl_ScenicArea(ScenicId,IsRecommend,ScenicName,EnName,X,Y,ServiceTel,Contact,ContactTel,ContactMobile,
      ContactFax,ProvinceId,CityId,CountyId,CnAddress,EnAddress,ScenicLevel,[Year],
      OpenTime,Description,Traffic,Facilities,Notes,OperatorId)
     VALUES(@ScenicId,@IsRecommend,@ScenicName,@EnName,@X,@Y,@ServiceTel,@Contact,@ContactTel,@ContactMobile, 
      @ContactFax,@ProvinceId,@CityId,@CountyId,@CnAddress,@EnAddress,@ScenicLevel,@Year,
      @OpenTime,@Description,@Traffic,@Facilities,@Notes,@OperatorId)
	set @error=@error+@@error


	if(@ScenicRelationLandMark is not null)
	begin
		declare @iMark int
		exec sp_xml_preparedocument @iMark output,@ScenicRelationLandMark

		INSERT INTO tbl_ScenicRelationLandMark(ScenicId,LandMarkId)
		select @ScenicId,LandMarkId from openxml(@iMark,'/Root/ScenicRelationLandMark')
		with(LandMarkId int)	
		set @error=@error+@@error

		exec sp_xml_removedocument @iMark
		set @error=@error+@@error
	end

	if(@ScenicRelationTheme is not null)
	begin
		declare @itheme int
		exec sp_xml_preparedocument @itheme output,@ScenicRelationTheme

		INSERT INTO tbl_ScenicRelationTheme(ScenicId,ThemeId)
		select @ScenicId,ThemeId from openxml(@itheme,'/Root/ScenicRelationTheme') 
		with(ThemeId int)
		set @error=@error+@@error

		exec sp_xml_removedocument @itheme
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


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tbl_ScenicAreaImg') and o.name = 'FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA')
alter table tbl_ScenicAreaImg
   drop constraint FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicAreaImg')
            and   type = 'U')
   drop table tbl_ScenicAreaImg
go

/*==============================================================*/
/* Table: tbl_ScenicAreaImg                                     */
/*==============================================================*/
create table tbl_ScenicAreaImg (
   ImgId                char(36)             not null,
   ScenicId             char(36)             null,
   ImgType              tinyint              not null,
   Address              nvarchar(500)        not null,
   ThumbAddress         nvarchar(500)        null,
   Description          nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   constraint PK_TBL_SCENICAREAIMG primary key (ImgId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ImgId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片类型',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ImgType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片地址',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'Address'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片缩略图',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'ThumbAddress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片说明',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaImg', 'column', 'OperatorId'
go

alter table tbl_ScenicAreaImg
   add constraint FK_TBL_SCENICAREAIMG_REFERENCE_TBL_SCENICAREA foreign key (ScenicId)
      references tbl_ScenicArea (ScenicId)
go

GO



-- =============================================
-- Author:		王磊
-- Create date: 2013-04-11
-- Description:	景点修改
-- =============================================
create  proc [dbo].[proc_ScenicArea_Update]
@ScenicId char(36), 
@IsRecommend char(1), 
@ScenicName nvarchar(100), 
@EnName varchar(100), 
@X varchar(100), 
@Y varchar(100), 
@ServiceTel nvarchar(50),
@Contact nvarchar(50), 
@ContactTel nvarchar(50), 
@ContactMobile nvarchar(50), 
@ContactFax char(10), 
@ProvinceId int, 
@CityId int, 
@CountyId int, 
@CnAddress nvarchar(100), 
@EnAddress varchar(100), 
@ScenicLevel tinyint, 
@Year int,
@OpenTime nvarchar(max), 
@Description nvarchar(max), 
@Traffic nvarchar(max), 
@Facilities nvarchar(max), 
@Notes nvarchar(max), 
@OperatorId char(36), 
@ScenicRelationLandMark xml,
@ScenicRelationTheme xml,
@Result int output
as
begin
	declare @error int
	set @error=0	
	
	begin transaction
	UPDATE tbl_ScenicArea
    SET IsRecommend = @IsRecommend,ScenicName = @ScenicName,
        EnName = @EnName,X = @X,Y = @Y,ServiceTel=@ServiceTel,Contact = @Contact, ContactTel = @ContactTel, 
        ContactMobile = @ContactMobile,ContactFax = @ContactFax,ProvinceId = @ProvinceId, 
        CityId = @CityId,CountyId = @CountyId,CnAddress = @CnAddress,EnAddress = @EnAddress, 
        ScenicLevel = @ScenicLevel,[Year]=@Year,OpenTime = @OpenTime,Description = @Description, 
	    Traffic = @Traffic,Facilities = @Facilities,Notes = @Notes,OperatorId = @OperatorId, 
        LastUpdateTime = getdate()
    WHERE ScenicId = @ScenicId
	set @error=@error+@@error

	delete from tbl_ScenicRelationLandMark where ScenicId=@ScenicId
	set @error=@error+@@error

	if(@ScenicRelationLandMark is not null)
	begin
		declare @iMark int
		exec sp_xml_preparedocument @iMark output,@ScenicRelationLandMark

		INSERT INTO tbl_ScenicRelationLandMark(ScenicId,LandMarkId)
		select @ScenicId,LandMarkId from openxml(@iMark,'/Root/ScenicRelationLandMark')
		with(LandMarkId int)	
		set @error=@error+@@error

		exec sp_xml_removedocument @iMark
		set @error=@error+@@error
	end

	delete from tbl_ScenicRelationTheme where ScenicId=@ScenicId
	set @error=@error+@@error

	if(@ScenicRelationTheme is not null)
	begin
		declare @itheme int
		exec sp_xml_preparedocument @itheme output,@ScenicRelationTheme
		
		INSERT INTO tbl_ScenicRelationTheme(ScenicId,ThemeId)
		select @ScenicId,ThemeId from openxml(@itheme,'/Root/ScenicRelationTheme') 
		with(ThemeId int)
		set @error=@error+@@error

		exec sp_xml_removedocument @itheme
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
-- Create date: 2013-04-11
-- Description:	景点图片添加
-- =============================================
Create proc proc_ScenicAreaImage_Add
@ScenicAreaImg xml,
@Result int output
as
begin
	declare @error int
	declare @i int
	exec sp_xml_preparedocument @i output,@ScenicAreaImg
	set @error=@error+@@error

	INSERT INTO tbl_ScenicAreaImg(ImgId,ScenicId,ImgType,Address,ThumbAddress,Description,IssueTime,OperatorId)
	select ImgId,ScenicId,ImgType,Address,ThumbAddress,Description,getdate(),OperatorId 
	from openxml(@i,'/Root/ScenicAreaImg')
	with(ImgId char(36),ScenicId char(36),ImgType tinyint,Address nvarchar(500),
		ThumbAddress nvarchar(500),Description nvarchar(max),OperatorId char(36))
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
go

--表：tbl_ScenicAreaOrder------------------------------------------------------

if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_ScenicAreaOrder')
            and   type = 'U')
   drop table tbl_ScenicAreaOrder
go

/*==============================================================*/
/* Table: tbl_ScenicAreaOrder                                   */
/*==============================================================*/
create table tbl_ScenicAreaOrder (
   OrderId              char(36)             not null,
   OrderCode            nvarchar(50)         null,
   ScenicId             char(36)             not null,
   TicketsId            char(36)             not null,
   Price                money                not null default 0,
   Num                  int                  not null default 0,
   Status               tinyint              not null default 0,
   Source               tinyint              null,
   FuKuanStatus         tinyint              not null default 0,
   OperatorId           char(36)             not null,
   IssueTime            datetime             not null default getdate(),
   constraint PK_TBL_SCENICAREAORDER primary key (OrderId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区门票订单',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'OrderId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'OrderCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '景区编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'ScenicId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'TicketsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票价格',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '门票数量',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'Num'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单状态',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单来源',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'Source'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '付款状态',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'FuKuanStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '下单人编号',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '下单时间',
   'user', @CurrentUser, 'table', 'tbl_ScenicAreaOrder', 'column', 'IssueTime'
go


GO

-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	写入景区产品订单信息，返回1成功，其它失败
-- =============================================
create proc proc_ScenicAreaOrder_Add
@OrderId char(36),
@ScenicId char(36),
@TicketsId char(36),
@Price decimal(18,0),
@Num int,
@Status tinyint,
@Source tinyint,
@FuKuanStatus tinyint,
@OperatorId char(36),
@Result int output
as
begin
	declare @error int
	set @error=0
	
	declare	@OrderCode nvarchar(50)
	declare @LiuShuiHiao int
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM tbl_ScenicAreaOrder
	SET @OrderCode=CONVERT(VARCHAR(8),GETDATE(),112)+'J'+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)
	
	INSERT INTO tbl_ScenicAreaOrder
           (OrderId,OrderCode,ScenicId,TicketsId,Price,Num,Status,Source,FuKuanStatus,OperatorId,IssueTime)
     VALUES
           (@OrderId,@OrderCode,@ScenicId,@TicketsId,@Price,@Num,@Status,@Source,@FuKuanStatus,@OperatorId,getdate())

	if(@@identity<>0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end

	return @Result
end

Go


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	修改景区产品订单信息，返回1成功，其它失败
-- =============================================
create proc proc_ScenicAreaOrder_Update
@OrderId char(36),
@ScenicId char(36),
@TicketsId char(36),
@Price decimal(18,0),
@Num int,
@Status tinyint,
@Source tinyint,
@FuKuanStatus tinyint,
@OperatorId char(36),
@Result int output
as
begin
	
	UPDATE tbl_ScenicAreaOrder
    SET  ScenicId = @ScenicId,TicketsId = @TicketsId
		,Price = @Price,Num = @Num,Status = @Status,Source = @Source,FuKuanStatus = @FuKuanStatus
		,OperatorId = @OperatorId 
    WHERE OrderId = @OrderId
	

	if(@@identity<>0)
	begin
		set @Result=1
	end
	else
	begin
		set @Result=0
	end

	return @Result
end
Go

-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	修改景区产品订单状态信息，返回1成功，其它失败
-- =============================================
create proc proc_ScenicAreaOrder_Update_Status
@OrderId char(36),
@Status tinyint,
@Result int output
as
begin
	
	UPDATE tbl_ScenicAreaOrder SET  Status = @Status WHERE OrderId = @OrderId
	
	if(@@identity<>0)
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

create view view_ScenicAreaOrder
as
SELECT 
A.OrderId,
A.OrderCode,
A.ScenicId,
A.TicketsId,
A.Price,
A.Num,
A.Status,
A.Source,
A.FuKuanStatus,
A.OperatorId,
A.IssueTime,
B.ScenicName, 
C.TypeName
FROM 
tbl_ScenicAreaOrder as A 
inner join tbl_ScenicArea as B on A.ScenicId=B.ScenicId
inner join tbl_ScenicTickets as C on A.TicketsId=C.TicketsId 

GO





-- 2013-04-20    


--景区订单 添加 联系人 联系电话 备注字段
GO
ALTER TABLE dbo.tbl_ScenicAreaOrder ADD
	ContactName nvarchar(255) NULL,
	ContactTel nvarchar(255) NULL,
	Remark nvarchar(MAX) NULL
GO
DECLARE @v sql_variant 
SET @v = N'联系人'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_ScenicAreaOrder', N'COLUMN', N'ContactName'
GO
DECLARE @v sql_variant 
SET @v = N'联系电话'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_ScenicAreaOrder', N'COLUMN', N'ContactTel'
GO
DECLARE @v sql_variant 
SET @v = N'备注'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'tbl_ScenicAreaOrder', N'COLUMN', N'Remark'
GO




GO



-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	写入景区产品订单信息，返回1成功，其它失败
-- =============================================
ALTER proc [dbo].[proc_ScenicAreaOrder_Add]
@OrderId char(36),
@ScenicId char(36),
@TicketsId char(36),
@Price decimal(18,0),
@Num int,
@Status tinyint,
@Source tinyint,
@FuKuanStatus tinyint,
@OperatorId char(36),
@ContactName NVARCHAR(255),
@ContactTel NVARCHAR(255),
@Remark NVARCHAR(max),
@Result int output
as
begin
	declare @error int
	set @error=0
	
	declare	@OrderCode nvarchar(50)
	declare @LiuShuiHiao int
	SELECT @LiuShuiHiao=COUNT(*)+1 FROM tbl_ScenicAreaOrder
	SET @OrderCode=CONVERT(VARCHAR(8),GETDATE(),112)+'J'+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)
	
	INSERT INTO tbl_ScenicAreaOrder
           (OrderId,OrderCode,ScenicId,TicketsId,Price,Num,Status,Source,FuKuanStatus,OperatorId,IssueTime,ContactName,ContactTel,Remark)
     VALUES
           (@OrderId,@OrderCode,@ScenicId,@TicketsId,@Price,@Num,@Status,@Source,@FuKuanStatus,@OperatorId,getdate(),@ContactName,@ContactTel,@Remark)

	if(1 = 1)
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



GO


-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	修改景区产品订单信息，返回1成功，其它失败
-- =============================================
ALTER proc [dbo].[proc_ScenicAreaOrder_Update]
@OrderId char(36),
@ScenicId char(36),
@TicketsId char(36),
@Price decimal(18,0),
@Num int,
@Status tinyint,
@Source tinyint,
@FuKuanStatus tinyint,
@OperatorId char(36),
@ContactName NVARCHAR(255),
@ContactTel NVARCHAR(255),
@Remark NVARCHAR(max),
@Result int output
as
begin
	
	UPDATE tbl_ScenicAreaOrder
    SET  ScenicId = @ScenicId,TicketsId = @TicketsId
		,Price = @Price,Num = @Num,Status = @Status,Source = @Source,FuKuanStatus = @FuKuanStatus
		,ContactName = @ContactName,ContactTel = @ContactTel,Remark = @Remark 
    WHERE OrderId = @OrderId
	

	if(1 = 1)
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




GO

ALTER view [dbo].[view_ScenicAreaOrder]
as
SELECT 
A.OrderId,
A.OrderCode,
A.ScenicId,
A.TicketsId,
A.Price,
A.Num,
A.Status,
A.Source,
A.FuKuanStatus,
A.OperatorId,
A.IssueTime,
A.ContactName,
A.ContactTel,
A.Remark,
B.ScenicName, 
C.TypeName
FROM 
tbl_ScenicAreaOrder as A 
inner join tbl_ScenicArea as B on A.ScenicId=B.ScenicId
inner join tbl_ScenicTickets as C on A.TicketsId=C.TicketsId 



go





GO

-- =============================================
-- Author:		王磊
-- Create date: 2013-04-16
-- Description:	修改景区产品订单状态信息，返回1成功，其它失败
-- =============================================
ALTER proc [dbo].[proc_ScenicAreaOrder_Update_Status]
@OrderId char(36),
@Status tinyint,
@Result int output
as
begin
	
	UPDATE tbl_ScenicAreaOrder SET  Status = @Status WHERE OrderId = @OrderId
	
	if(1 = 1)
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








