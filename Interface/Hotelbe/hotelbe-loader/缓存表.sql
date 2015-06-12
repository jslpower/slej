

use hzjalydb
go
create table Temp_Hotel_City
(
CITY_CODE  varchar(max), --城市代码
CITY_NAME  varchar(max), --城市名称
CITY_PINYIN  varchar(max), --城市拼音
CITY_PYFW  varchar(max), --拼音首字母
COUNTRY_CODE  varchar(max),--国家代码
Country_Name varchar(max), --国家名称
PROVINCE  varchar(max) --省份
)

GO

create table Temp_Hotel_BrandInfo
(
ID  varchar(max), --唯一标识
BRAND_CODE  varchar(max), ---品牌代码
BRAND_NAME  varchar(max), --品牌名称
CHAIN_CODE  varchar(max), --酒店所属集团代码
DESCP  varchar(max) --品牌描述
)

GO

create table Temp_Hotel_HotelAmenity
(
HOTEL_CODE  varchar(max), --酒店代码
AMENITY_NAME  varchar(max), --设施名称
AMENITY_STATUS  varchar(max), --设施状态
AMENITY_TYPE  varchar(max) --设施类别
)

GO

create table Temp_Hotel_HotelAccepted
(
HOTEL_CODE  varchar(max) , --酒店代码
CARD_CODE  varchar(max), --信用卡代码
CARD_NAME  varchar(max), --信用卡名称
CARD_TYPE  varchar(max) --信用卡类型
)

create table Temp_Hotel_HotelTraffic
(
HOTEL_CODE  varchar(max) , --酒店代码
TRAFFIC_NAME  varchar(max), --交通信息名称
DISTANCE  varchar(max), --距离
CAR_INTERVAL  varchar(max), --车程
FOOT_INTERVAL  varchar(max), --步程
CATEGORY  varchar(max) --类别
)

GO

create table Temp_Hotel_Landmark
(
CITY_CODE  varchar(max) not null, --城市代码
LANDMARK_NAME  varchar(max)  not null, --地标名称
CITY_NAME  varchar(max), --城市名称
CATEGORY  varchar(max), --类别
COUNTRY_CODE  varchar(max), --国家代码
HOTELS  varchar(max) --该区域酒店 code 队列
)
GO
--alter table Hotel_Landmark  
--add primary key nonclustered (CITY_CODE,LANDMARK_NAME,CATEGORY) 

GO

create table Temp_Hotel_HotelInfo
(
HOTEL_CODE  varchar(max), --酒店代码
HOTEL_NAMECN  varchar(max), --酒店中文名称
HOTEL_NAMEEN  varchar(max), --酒店英文名称
RANK_CODE  varchar(max), --星级
CITY_CODE  varchar(max), --城市代码
COUNTRY_CODE  varchar(max), --国家代码
PROVINCE  varchar(max), --省份
HOTEL_ADDRESS  varchar(max), --酒店地址
POSTAL_CODE  varchar(max), --邮编
TEL  varchar(max), --电话
OPEN_DATE  varchar(max), --开业时间
FIX_MENT  varchar(max), --装修时间
ROOM_QUANTITY  varchar(max), --房间数
FLOOR  varchar(max), --楼层数
FAX  varchar(max), --传真
DISTRICT  varchar(max), --行政区
LONG_DESC  varchar(max), --简介
LATITUDE  varchar(max), ---纬度
LONGITUDE  varchar(max), --经度
IMG_DT  varchar(max), -- 大厅图片
STATUS  varchar(max), --酒店状态
IMG_KF  varchar(max), --客房图片
IMG_WJ  varchar(max), --外景图片
BRAND_CODE  varchar(max) --品牌代码
)

GO


create table Temp_Hotel_RoomType
(
HOTEL_CODE  varchar(max) not null, --酒店代码
ROOM_TYPE_CODE  varchar(max) not null, --房型代码
INV_STATUS varchar(max),--保留值
NO_SMOKING varchar(max),--是否无烟
BED_TYPE varchar(max),--床型
TOTAL_NUMBER varchar(max),--房间总量
FLOOR varchar(max),--楼层
ROOM_AREA varchar(max),--房间面积
MAX_ADD_BED varchar(max),--最大加床数量
DESCP varchar(max),--描述
INV_TYPE varchar(max),--房型名称
CATEGORY varchar(max),--房型种类
ROOM_VIEW varchar(max),--房型景观
MAX_GUEST_NUM varchar(max),--最大入住客人数目
INTERNET varchar(max),--宽带
EN_INV_TYPE varchar(max),--房型英文名称
BED_AREA varchar(max),--床面积
STATUS  varchar(max) --房型状态
)
GO
--alter table Hotel_RoomType  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE) 
GO

create table Temp_Hotel_RatePlan_Temp
(
HOTEL_CODE  varchar(max) not null, --酒店代码
ROOM_TYPE_CODE  varchar(max) not null, --房型代码
RATE_PLAN_CODE  varchar(max)  not null, --价格计划代码
START_DATE  varchar(max) not null, --开始时间
END_DATE varchar(max),--结束时间
MAX_LOS varchar(max),--最大入住人数
STATUS varchar(max),--房间状态
LEADING_TIME varchar(max),--提前预订天数
VENDOR_CODE varchar(max),--供应商代码
IS_SIGN varchar(max),--是否是自签酒店
MIN_LOS varchar(max),--最小入住天数
TIME_STAMP  varchar(max) --时间戳
)
GO
--alter table Hotel_RatePlan_Temp  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 
GO

create table Temp_Hotel_RoomRate_Temp
(
HOTEL_CODE  varchar(max) not null, --酒店代码
ROOM_TYPE_CODE  varchar(max) not null, --房型代码
RATE_PLAN_CODE  varchar(max)  not null, --价格计划代码
START_DATE  varchar(max) not null, --开始时间
END_DATE varchar(max),--结束时间
AMOUNT_PRICE varchar(max),--价格
CURRENCY varchar(max),--货币代码
RATE_PLAN_NAME  varchar(max), --价格计划名称
PAYMENT_METHOD  varchar(max), --支付方式
FEE_PERCENT varchar(max),--保留
VENDER_CODE varchar(max),--供应商代码
DISPLAY_PRICE varchar(max),--门市价
TIME_STAMP varchar(max),--时间戳
FREE_MEAL  varchar(max) --早餐
)
GO
--alter table Hotel_RoomRate_Temp  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 
GO

create table Temp_Hotel_RoomRate
(
HOTEL_CODE varchar(max) not null,--酒店代码
ROOM_TYPE_CODE varchar(max) not null,--房型代码
RATE_PLAN_CODE  varchar(max)  not null, --价格计划代码
START_DATE varchar(max) not null,--开始时间
END_DATE varchar(max),--结束时间
AMOUNT_PRICE varchar(max),--价格
CURRENCY varchar(max),--货币代码
RATE_PLAN_NAME  varchar(max), --价格计划名称
PAYMENT_METHOD  varchar(max), --支付方式
FEE_PERCENT varchar(max),--保留
VENDER_CODE varchar(max),--供应商代码
DISPLAY_PRICE varchar(max),--门市价
TIME_STAMP varchar(max),--时间戳
IS_SIGN varchar(max),--是否为自签酒店
FREE_MEAL varchar(max),--早餐
STATUS varchar(max),--状态
LOAD_TIME  varchar(max) --时间戳 2
)
GO
--alter table Hotel_RoomRate  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE,START_DATE) 

GO

create table Temp_Hotel_GuaranteePolicy
(
HOTEL_CODE  varchar(max) not null, --酒店代码
ROOM_TYPE_CODE  varchar(max)  not null , --房型代码
RATE_PLAN_CODE  varchar(max) not null, --价格计划代码
STATUS varchar(max),--状态
SHORT_DESC varchar(max),--简要描述
GUARANTEE_TYPE varchar(max),--担保类型
GUARANTEE_METHOD varchar(max),--担保方式
NUMOF_ROOM2 varchar(max),--入住房间数
FEE_VALUE2 varchar(max),--收费具体值
HOLD_TIME2 varchar(max),--担保时限
GUARANTEE_DATE2 varchar(max),--提前预订天数
DAYSOF_STAY varchar(max),--入住天数
FEE_VALUE varchar(max),--收费具体值
HOLD_TIME varchar(max),--担保时限
GUARANTEE_DATE varchar(max),--提前预订天数
UNITOF_FEE varchar(max),--收费单位
DAYSOF_STAY3 varchar(max),--入住天数
FEE_VALUE3 varchar(max),--收费具体值
NUMOF_ROOM3 varchar(max),--入住房间数
GUARANTEE_DATE3 varchar(max),--提前预订天数
HOLD_TIME3 varchar(max),--担保时限
NUMOF_ROOM varchar(max),--入住房间数
UNITOF_FEE2 varchar(max),--收费单位
UNITOF_FEE3 varchar(max),--收费单位
LONG_DESC varchar(max),--详细描述
START_DATE varchar(max),--开始时间
END_DATE  varchar(max) --结束时间
)
GO
--alter table Hotel_GuaranteePolicy  
--add primary key nonclustered (HOTEL_CODE,ROOM_TYPE_CODE,RATE_PLAN_CODE) 
GO

create table Temp_Hotel_Order
(
ORDERID  varchar(max), --订单代码
STATUS varchar(max),--订单状态
HOTEL_CODE varchar(max),--酒店代码
HOTEL_NAME varchar(max),--酒店名称
HOTEL_ADDRESS varchar(max),--酒店地址
HOTEL_RANK varchar(max),--酒店星级
CITY_CODE varchar(max),--酒店所在城市代码
ROOM_TYPE_CODE varchar(max),--房型代码
ROOM_TYPE_NAME varchar(max),--房型名称
RATE_PLAN_CODE varchar(max),--价格计划代码
RATE_PLAN_NAME varchar(max),--价格计划名称
VENDOR_CODE varchar(max),--供应商代码
CHECK_IN_DATE varchar(max),--入住时间
CHECK_OUT_DATE varchar(max),--离店时间
CREATE_TIME varchar(max),--创建时间
UPDATE_TIME varchar(max),--更新时间
FIRST_PRICE varchar(max),--首日价格
TOTAL_PRICE varchar(max),--总价格
BED_TYPE varchar(max),--床型
INTERNET varchar(max),--宽带
FREE_MEAL varchar(max),--早餐
ROOM_QUANTITY varchar(max),--房间数量
ROOM_NIGHTS varchar(max),--入住夜晚数
SPECIAL_REQUEST varchar(max),--特殊要求
ARRIVE_EARLY_TIME varchar(max),--最早到达时间
ARRIVE_LATE_TIME varchar(max),--最晚到达时间
PAYMENT varchar(max),--支付方式
PAYMET_STATUS varchar(max),--支付状态
[USER_ID]  varchar(max), --用户代码
GUEST_NAME  varchar(max), --客户名称
CONTACT_NAME  varchar(max), --联系人姓名
CONTACT_EMAIL  varchar(max), --联系人邮箱
CONTACT_MOBILE  varchar(max), --联系人电话
CHECK_IN_STATUS  varchar(max) --入住状态
)

GO
