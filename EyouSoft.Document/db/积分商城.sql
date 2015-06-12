if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_MemberTotal')
            and   type = 'U')
   drop table tbl_MemberTotal
go

/*==============================================================*/
/* Table: tbl_MemberTotal                                       */
/*==============================================================*/
create table tbl_MemberTotal (
   ID                   int                  identity,
   MemberID             char(36)             not null,
   OrderId              char(36)             not null,
   OrderType            tinyint              not null default 0,
   Total                int                  null default 0,
   IssueTime            datetime             null default getdate(),
   ValidTime            datetime             null,
   constraint PK_TBL_MEMBERTOTAL primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '会员编号',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'MemberID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单编号',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'OrderId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单类型',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'OrderType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所获积分',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'Total'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '获取时间',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '有效时间',
   'user', @CurrentUser, 'table', 'tbl_MemberTotal', 'column', 'ValidTime'
go


if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_TatolProduct')
            and   type = 'U')
   drop table tbl_TatolProduct
go

/*==============================================================*/
/* Table: tbl_TatolProduct                                      */
/*==============================================================*/
create table tbl_TatolProduct (
   ProductID            int                  identity,
   ProductName          nvarchar(250)        not null,
   ProductClass         tinyint              not null default 0,
   Num                  int                  not null default 0,
   Total                int                  not null default 0,
   Price                money                not null default 0,
   ProductInfo          nvarchar(max)        null,
   IssueTime            datetime             not null default getdate(),
   OperatorId           char(36)             not null,
   constraint PK_TBL_TATOLPRODUCT primary key (ProductID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '积分产品编号',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'ProductID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '产品名称',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'ProductName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '产品类别',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'ProductClass'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '产品数量',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'Num'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所需积分',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'Total'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '市场价',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '产品信息',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'ProductInfo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布时间',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'IssueTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布用户',
   'user', @CurrentUser, 'table', 'tbl_TatolProduct', 'column', 'OperatorId'
go



if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_TatolProductPic')
            and   type = 'U')
   drop table tbl_TatolProductPic
go

/*==============================================================*/
/* Table: tbl_TatolProductPic                                   */
/*==============================================================*/
create table tbl_TatolProductPic (
   PicID                int                  identity,
   ProductID            int                  not null,
   FilePath             varchar(255)         null,
   "Desc"               nvarchar(255)        null,
   constraint PK_TBL_TATOLPRODUCTPIC primary key (PicID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片编号',
   'user', @CurrentUser, 'table', 'tbl_TatolProductPic', 'column', 'PicID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '积分产品编号',
   'user', @CurrentUser, 'table', 'tbl_TatolProductPic', 'column', 'ProductID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片路径',
   'user', @CurrentUser, 'table', 'tbl_TatolProductPic', 'column', 'FilePath'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片描述',
   'user', @CurrentUser, 'table', 'tbl_TatolProductPic', 'column', 'Desc'
go




if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_TotalToProduct')
            and   type = 'U')
   drop table tbl_TotalToProduct
go

/*==============================================================*/
/* Table: tbl_TotalToProduct                                    */
/*==============================================================*/
create table tbl_TotalToProduct (
   ID                   int                  identity,
   MemberID             char(36)             not null,
   ProductID            int                  not null default 0,
   Num                  int                  not null default 0,
   Total                int                  not null default 0,
   ExchangeTime         datetime             not null default getdate(),
   Status               tinyint              not null default 0,
   OperatorId           char(36)             null,
   IssueTime            datetime             null,
   constraint PK_TBL_TOTALTOPRODUCT primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '会员编号',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'MemberID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '积分产品编号',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'ProductID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '兑换数量',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'Num'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所兑积分',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'Total'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '兑换时间',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'ExchangeTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'Status'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核人',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'OperatorId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核时间',
   'user', @CurrentUser, 'table', 'tbl_TotalToProduct', 'column', 'IssueTime'
go


if exists (select 1
            from  sysobjects
           where  id = object_id('tbl_MemberContact')
            and   type = 'U')
   drop table tbl_MemberContact
go

/*==============================================================*/
/* Table: tbl_MemberContact                                     */
/*==============================================================*/
create table tbl_MemberContact (
   ID                   int                  identity,
   MemberID             char(36)             not null,
   MemberName           nvarchar(50)         null,
   ContactTel           nvarchar(50)         null,
   Mobile               nvarchar(50)         null,
   Address              nvarchar(255)        null,
   Code                 nvarchar(20)         null,
   BenZhu               nvarchar(255)        null,
   constraint PK_TBL_MEMBERCONTACT primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '会员编号',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'MemberID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '会员姓名',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'MemberName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'ContactTel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '手机',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'Mobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地址',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'Address'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮编',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tbl_MemberContact', 'column', 'BenZhu'
go




-- =============================================
-- Description:	<积分产品添加>
-- =============================================
create PROCEDURE [dbo].[proc_TatolProduct_Add] 
    @ProductName nvarchar(250),
    @ProductClass TINYINT,
    @Num INT,
    @Total INT,
    @Price  MONEY,
    @ProductInfo nvarchar(max),
    @OperatorId char(36),
	@PicXML xml,
	@Result int output --操作结果 正值1：成功 负值或0：失败
AS
BEGIN
	declare @error INT,@ProductID INT ,@doc int
	set @error=0
	set @Result=0
	begin tran
	INSERT INTO tbl_TatolProduct([ProductName],[ProductClass],[Num],[Total],[Price],[ProductInfo],[OperatorId])
		VALUES(@ProductName,@ProductClass,@Num,@Total,@Price,@ProductInfo,@OperatorId)
	SET @ProductID=@@identity
	set @error = @error + @@error
	if(@PicXML is not null and @error=0)
	begin
		exec sp_xml_preparedocument @doc output,@PicXML
		insert into tbl_TatolProductPic(ProductID,FilePath,[Desc])
			select @ProductID,FilePath,[Desc]
			from openxml(@doc,N'/ROOT/Pic',1)
			WITH(FilePath varchar(255),[Desc] NVARCHAR(255))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
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


-- =============================================
-- Description:	<积分产品修改>
-- =============================================
create PROCEDURE [dbo].[proc_TatolProduct_Update]
	@ProductID INT,
	@ProductName nvarchar(250),
    @ProductClass TINYINT,
    @Num INT,
    @Total INT,
    @Price  MONEY,
    @ProductInfo nvarchar(max),
    @OperatorId char(36),
	@PicXML xml,
	@Result int output --操作结果 正值1：成功 负值或0：失败
AS
BEGIN
	declare @error int ,@doc int
	set @error=0
	set @Result=0
	begin TRAN
	delete from tbl_TatolProductPic where ProductID=@ProductID
	set @error=@error+@@error
	if(@PicXML is not null)
	begin
		exec sp_xml_preparedocument @doc output,@PicXML
		insert into tbl_TatolProductPic(ProductID,FilePath,[Desc])
			select @ProductID,FilePath,[Desc]
			from openxml(@doc,N'/ROOT/Pic',1)
			WITH(FilePath varchar(255),[Desc] NVARCHAR(255))
		set @error=@error+@@error
		exec sp_xml_removedocument @doc
	end
	IF(@error=0)
	begin
		UPDATE tbl_TatolProduct Set [ProductName]=@ProductName,[ProductClass]=@ProductClass,[Num]=@Num,[Total]=@Total
			,[Price]=@Price,[ProductInfo]=@ProductInfo,[OperatorId]=@OperatorId  WHERE ProductID=@ProductID
		set @error = @error + @@error
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



