


GO
/****** 对象:  UserDefinedFunction [dbo].[fn_PadLeft]    脚本日期: 03/23/2013 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2010-05-25
-- Description:	右对齐字符，在左边用指定的字符填充以达到指定的总长度。
-- =============================================
CREATE FUNCTION [dbo].[fn_PadLeft]
(
	--输入的字符串
	@Input NVARCHAR(50),
	--填充字符
	@PaddingChar CHAR(1),
	--结果字符串中的字符数，等于原始字符数加上任何其他填充字符。
	@TotalWidth INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @tmp varchar(50)
	SELECT @tmp = ISNULL(REPLICATE(@PaddingChar,@TotalWidth - LEN(ISNULL(@Input ,0))), '') + @Input
	RETURN @tmp
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_Pading]    脚本日期: 03/23/2013 15:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2012-05-16
-- Description:	存储过程分页,TABLE,VIEW
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pading]
     @PageSize int = 10-- 页尺寸
    ,@PageIndex int = 1 -- 页码
    ,@TableName NVARCHAR(MAX)-- 表名    
    ,@Fields NVARCHAR(MAX) --列名
    ,@Query NVARCHAR(MAX) = ''-- 查询条件 (注意: 不要加 where)
    ,@OrderBy NVARCHAR(MAX)=''--必选,排序(不要加ORDER BY),排序是针对查询结果集生成的各列
    ,@GroupBy NVARCHAR(MAX)=''--分组(不要加GROUP BY),分组是针对查询结果集生成的各列
	,@SumString NVARCHAR(max)=''--合计,(SUM(FIELD) AS FIELD,SUM(FIELD1) AS FIELD1),合计是针对查询结果集的各列
AS
BEGIN
	DECLARE @RecordCount int--记录总数[返回]
	DECLARE @PageCount int
	DECLARE @tmpsql NVARCHAR(MAX)--临时变更
	DECLARE @sumsql NVARCHAR(MAX)
	DECLARE @MinIndex INT--返回结果集第一条记录索引
	DECLARE @MaxIndex INT--返回结果集最后一条记录索引
	SET @PageCount = 0

	IF(@OrderBy IS NOT NULL AND LEN(@OrderBy)>0)
	BEGIN
		SET @OrderBy = 'ORDER BY '+@OrderBy
	END
	ELSE
	BEGIN
		SET @OrderBy = ''
	END

	IF(@Query IS NOT NULL AND LEN(@Query) >0)
	BEGIN
		SET @Query=' WHERE '+@Query
	END
	ELSE
	BEGIN
		SET @Query=''
	END

	SET @tmpsql='SELECT @RecordCount=COUNT(*) FROM [' + @TableName + ']'+@Query

	EXECUTE sp_executesql  @tmpsql,N'@RecordCount INT OUTPUT',@RecordCount OUTPUT

	SET @PageCount=CEILING(@RecordCount*1.0/@PageSize)
	IF(@PageIndex >@PageCount) SET @PageIndex = @PageCount

	SET @MinIndex=(@PageIndex-1)* @PageSize +1
	SET @MaxIndex = @MinIndex + @PageSize -1

	SET @tmpsql = 'SELECT t120.* FROM ( SELECT  ' + @Fields + ',ROW_NUMBER() OVER(' + @OrderBy + ') AS RowNumber FROM [' + @TableName + '] ' + @Query + ' ) AS t120 WHERE RowNumber BETWEEN ' + CAST(@MinIndex AS NVARCHAR(10)) + ' AND ' + CAST(@MaxIndex AS NVARCHAR(10))+' ORDER BY RowNumber ASC'
		
	print @tmpsql
		
	--合计结果集SQL
	IF(LEN(@SumString)>0)
	BEGIN
		SET @sumsql='SELECT '+@SumString+' FROM ( SELECT  ' + @Fields + ' FROM ['+@TableName+'] ' + @Query + ' ) AS t120'
	END
	ELSE
	BEGIN
		SET @sumsql='SELECT NULL AS ''NULL'''
	END	

	SELECT @RecordCount AS RecordCount
	print @tmpsql	

	EXECUTE sp_executesql @tmpsql
	EXECUTE sp_executesql @sumsql

END
GO
/****** 对象:  StoredProcedure [dbo].[proc_Pading_BySqlTable]    脚本日期: 03/23/2013 15:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 2012-05-16
-- Description:	存储过程分页,SQLTABLE
-- =============================================
CREATE PROCEDURE [dbo].[proc_Pading_BySqlTable]
     @PageSize INT = 10-- 页尺寸
    ,@PageIndex INT = 1-- 页码
    ,@Table NVARCHAR(MAX)-- 必选,查询结果集
    ,@Fields NVARCHAR(MAX)='*' --必选,列名
    ,@Query NVARCHAR(MAX) ='' -- 查询条件(不要加WHERE),查询条件是针对查询结果集生成的各列
    ,@OrderBy NVARCHAR(MAX)=''-- 必选,排序(不要加ORDER BY),排序是针对查询结果集生成的各列
    ,@GroupBy NVARCHAR(MAX)=''-- 分组(不要加GROUP BY),分组是针对查询结果集生成的各列
	,@SumString NVARCHAR(MAX)=''--合计,(SUM(FIELD) AS FIELD,SUM(FIELD1) AS FIELD1),合计是针对查询结果集的各列
AS
BEGIN
	DECLARE @RecordCount INT--记录总数[返回]
	DECLARE @MinIndex INT--返回结果集第一条记录索引
	DECLARE @MaxIndex INT--返回结果集最后一条记录索引
	DECLARE @tmpsql NVARCHAR(MAX)--临时变量
	DECLARE @sumsql NVARCHAR(MAX)
	DECLARE @PageCount INT

	IF(@PageSize<1) SET @PageSize=1
	IF(@PageIndex<1) SET @PageIndex=1

	--排序条件
	IF(LEN(@OrderBy)>0)--是否存在查询条件
	BEGIN
		SET @OrderBy = ' ORDER BY ' + @OrderBy
	END
	ELSE
	BEGIN
		SET @OrderBy = ''
	END

	--分组条件
	IF(LEN(@GroupBy)>0)
	BEGIN
		SET @GroupBy = ' GROUP BY ' + @GroupBy
	END
	ELSE
	BEGIN
		SET @GroupBy = ''
	END

	--查询条件
	IF(LEN(@Query)>0)
	BEGIN
		SET @Query=' WHERE '+@Query
	END
	ELSE
	BEGIN
		SET @Query=''
	END

	--总记录数
	SET @tmpsql='SELECT @RecordCount=COUNT(*) FROM (SELECT '+@Fields+' FROM ('+@Table+') AS t129 ' + @Query + @GroupBy +' ) AS t120 '
	PRINT @tmpsql
	EXECUTE sp_executesql  @tmpsql,N'@RecordCount INT OUTPUT',@RecordCount OUTPUT

	SET @PageCount=CEILING(@RecordCount*1.0/@PageSize)
	IF(@PageIndex >@PageCount) SET @PageIndex = @PageCount

	SET @MinIndex=(@PageIndex-1)* @PageSize +1
	SET @MaxIndex = @MinIndex + @PageSize -1

	--分页结果集SQL
	SET @tmpsql = 'SELECT t120.* FROM ( SELECT * ,ROW_NUMBER() OVER(' + @OrderBy + ') AS RowNumber FROM (SELECT ' + @Fields + ' FROM (' + @Table + ') AS t129 ' + @Query + @GroupBy + ' ) t121 ) AS t120 WHERE RowNumber BETWEEN ' + CAST(@MinIndex AS NVARCHAR) + ' AND ' + CAST(@MaxIndex AS NVARCHAR) + ' ORDER BY RowNumber ASC '

	--PRINT @tmpsql

	--合计结果集SQL
	IF(LEN(@SumString)>0)
	BEGIN
		SET @sumsql='SELECT '+@SumString+' FROM ( SELECT  ' + @Fields + ' FROM (' + @Table + ') AS t129 ' + @Query + @GroupBy + ' ) AS t120'
	END
	ELSE
	BEGIN
		SET @sumsql='SELECT NULL AS ''NULL'''
	END	
	
	--PRINT 	@sumsql
	SELECT @RecordCount AS RecordCount
	EXECUTE sp_executesql @tmpsql
	EXECUTE sp_executesql @sumsql
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLuTuanGou_Delete]    脚本日期: 03/23/2013 15:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-19
-- Description:	写入团购信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLuTuanGou_Delete]
	 @TuanGouId CHAR(36)--团购编号
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [TuanGouId]=@TuanGouId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF EXISTS(SELECT 1 FROM [tbl_XianLuTourOrder] WHERE [TuanGouId]=@TuanGouId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN
	DELETE FROM [tbl_XianLuTuanGouFile] WHERE [TuanGouId]=@TuanGouId
	SET @errorcount=@errorcount+@@ERROR
	DELETE FROM [tbl_XianLuTuanGou] WHERE [TuanGouId]=@TuanGouId
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode	
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLuTuanGou_Insert]    脚本日期: 03/23/2013 15:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-19
-- Description:	写入团购信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLuTuanGou_Insert]
	 @TuanGouId CHAR(36)--团购编号
	,@XianLuId CHAR(36)--线路编号
	,@STime DATETIME--开始时间
	,@ETime DATETIME--截止时间
	,@RenShu INT--成团人数
	,@SCJCR MONEY--市场价-成人
	,@SCJET MONEY--市场价-儿童
	,@ZheKou DECIMAL(3,2)--折扣
	,@JSJCR MONEY--结算价-成人
	,@JSJET MONEY--结算价-儿童
	,@XiangQing NVARCHAR(MAX)--团购详情
	,@OperatorId INT--操作人编号
	,@IssueTime DATETIME--操作时间
	,@LatestId INT--修改人编号
	,@LatestTime DATETIME--修改时间
	,@TuanName NVARCHAR(255)--团购名称
	,@JianYaoMiaoShu NVARCHAR(255)--简要描述
	,@FilePath NVARCHAR(255)--图片路径
	,@FileXml NVARCHAR(MAX)--图片XML:<root><info FilePath="" MiaoShu="" /></root>
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	
	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [XianLuId]=@XianLuId AND (@STime BETWEEN [STime] AND [ETime] OR @ETime BETWEEN [STime] AND [ETime]))
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN
	INSERT INTO [tbl_XianLuTuanGou]([TuanGouId],[XianLuId],[STime]
		,[ETime],[RenShu],[SCJCR]
		,[SCJET],[ZheKou],[JSJCR]
		,[JSJET],[XiangQing],[OperatorId]
		,[IssueTime],[LatestId],[LatestTime]
		,[TuanName],[JianYaoMiaoShu],[FilePath])
	VALUES(@TuanGouId,@XianLuId,@STime
		,@ETime,@RenShu,@SCJCR
		,@SCJET,@ZheKou,@JSJCR
		,@JSJET,@XiangQing,@OperatorId
		,@IssueTime,@LatestId,@LatestTime
		,@TuanName,@JianYaoMiaoShu,@FilePath)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @FileXml IS NOT NULL AND LEN(@FileXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@FileXml
		INSERT INTO [tbl_XianLuTuanGouFile]([TuanGouId],[FilePath],[MiaoShu])
		SELECT @TuanGouId,A.FilePath,A.MiaoShu
		FROM OPENXML(@hdoc,'/root/info')
		WITH([FilePath] NVARCHAR(255),[MiaoShu] NVARCHAR(255)) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLuTuanGou_Update]    脚本日期: 03/23/2013 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-19
-- Description:	写入团购信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLuTuanGou_Update]
	 @TuanGouId CHAR(36)--团购编号
	,@XianLuId CHAR(36)--线路编号
	,@STime DATETIME--开始时间
	,@ETime DATETIME--截止时间
	,@RenShu INT--成团人数
	,@SCJCR MONEY--市场价-成人
	,@SCJET MONEY--市场价-儿童
	,@ZheKou DECIMAL(3,2)--折扣
	,@JSJCR MONEY--结算价-成人
	,@JSJET MONEY--结算价-儿童
	,@XiangQing NVARCHAR(MAX)--团购详情
	,@OperatorId INT--操作人编号
	,@IssueTime DATETIME--操作时间
	,@LatestId INT--修改人编号
	,@LatestTime DATETIME--修改时间
	,@TuanName NVARCHAR(255)--团购名称
	,@JianYaoMiaoShu NVARCHAR(255)--简要描述
	,@FilePath NVARCHAR(255)--图片路径
	,@FileXml NVARCHAR(MAX)--图片XML:<root><info FilePath="" MiaoShu="" /></root>
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	
	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [TuanGouId]=@TuanGouId)
	BEGIN
		SET @RetCode=-97
		RETURN @RetCode		
	END	

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [XianLuId]=@XianLuId AND (@STime BETWEEN [STime] AND [ETime] OR @ETime BETWEEN [STime] AND [ETime]) AND [TuanGouId]<>@TuanGouId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN
	UPDATE [tbl_XianLuTuanGou] SET [XianLuId]=[XianLuId],[STime]=@STime,[ETime]=@ETime
		,[RenShu]=@RenShu,[SCJCR]=@SCJCR,[SCJET]=@SCJET
		,[ZheKou]=@ZheKou,[JSJCR]=@JSJCR,[JSJET]=@JSJET
		,[XiangQing]=@XiangQing,[OperatorId]=[OperatorId],[IssueTime]=[IssueTime]
		,[LatestId]=@LatestId,[LatestTime]=@LatestTime,[TuanName]=@TuanName
		,[JianYaoMiaoShu]=@JianYaoMiaoShu,[FilePath]=@FilePath
	WHERE [TuanGouId]=@TuanGouId

	IF(@errorcount=0 AND @FileXml IS NOT NULL AND LEN(@FileXml)>0)
	BEGIN
		DELETE FROM [tbl_XianLuTuanGouFile] WHERE [TuanGouId]=@TuanGouId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @FileXml IS NOT NULL AND LEN(@FileXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@FileXml
			INSERT INTO [tbl_XianLuTuanGouFile]([TuanGouId],[FilePath],[MiaoShu])
			SELECT @TuanGouId,A.FilePath,A.MiaoShu
			FROM OPENXML(@hdoc,'/root/info')
			WITH([FilePath] NVARCHAR(255),[MiaoShu] NVARCHAR(255)) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END
	
	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLu_Delete]    脚本日期: 03/23/2013 15:19:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-14
-- Description:	修改线路产品信息，返回1成功，其它失败
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLu_Delete]
	 @XianLuId CHAR(36)--线路编号
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	SET @errorcount=0

	IF EXISTS(SELECT 1 FROM [tbl_XianLuTourOrder] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	BEGIN TRAN

	DELETE FROM [tbl_XianLuFuWu] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuTour] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuXingCheng] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuZhuangTai] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuZhuTi] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuTeSeFile] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuTuanGouFile] WHERE [TuanGouId] IN(SELECT A.[TuanGouId] FROM [tbl_XianLuTuanGou] AS A WHERE A.[XianLuId]=@XianLuId)
	SET @errorcount=@errorcount+@@ERROR
	DELETE FROM [tbl_XianLuTuanGou] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLuTourOrderYouKe] WHERE [OrderId] IN (SELECT A.[OrderId] FROM [tbl_XianLuTourOrder] AS A WHERE A.[XianLuId]=@XianLuId)
	SET @errorcount=@errorcount+@@ERROR
	DELETE FROM [tbl_XianLuTourOrderHistory] WHERE [OrderId] IN (SELECT A.[OrderId] FROM [tbl_XianLuTourOrder] AS A WHERE A.[XianLuId]=@XianLuId)
	SET @errorcount=@errorcount+@@ERROR
	DELETE FROM [tbl_XianLuTourOrder] WHERE XianLuId=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	DELETE FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLu_Insert]    脚本日期: 03/23/2013 15:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-14
-- Description:	写入线路产品信息，返回1成功，其它失败
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLu_Insert]
	 @XianLuId CHAR(36)--线路编号
	,@AreaId INT--线路区域
	,@RouteName NVARCHAR(255)--线路名称
	,@TianShu INT--行程天数
	,@DepProvinceId INT--出发地省份编号
	,@DepCityId INT--出发地城市编号
	,@ArrProvinceId INT--目的地省份编号
	,@ArrCityId INT--目的地城市编号
	,@JiHuaRenShu INT--计划人数
	,@SCJCR MONEY--市场价-成人
	,@SCJET MONEY--市场价-儿童
	,@JSJCR MONEY--结算价-成人
	,@JSJET MONEY--结算价-儿童
	,@TingTianShu INT--提前X天报名
	,@ChuFaJiaoTong NVARCHAR(255)--出发交通
	,@FanChengJiaoTong NVARCHAR(255)--返程交通
	,@JiHeFangShi NVARCHAR(255)--集合方式
	,@TeSe NVARCHAR(MAX)--特色描述文字
	,@TeSeFilePath NVARCHAR(255)--特色描述图片
	,@TuJing NVARCHAR(255)--途径
	,@QianZheng NVARCHAR(MAX)--签证资料
	,@QianZhengFilePath NVARCHAR(255)--签证说明
	,@GuanZhuShu INT--关注数
	,@LxrName NVARCHAR(255)--联系人姓名
	,@LxrTelephone NVARCHAR(255)--联系人电话
	,@LxrQQ NVARCHAR(255)--联系人QQ
	,@LxrMobile NVARCHAR(255)--联系人手机
	,@Description NVARCHAR(255)--description
	,@Keywords NVARCHAR(255)--keywords
	,@OperatorId INT--发布人编号
	,@IssueTime DATETIME--发布时间
	,@LatestId INT--修改人编号
	,@LatestTime DATETIME--修改时间
	,@XingChengXML NVARCHAR(MAX)--行程XML:<root><info QuJian="" JiaoTong="" ZhuSu="" YongCan="" XingCheng="" FilePath="" /></root>
	,@FuWuXml NVARCHAR(MAX)--服务标准XML:<root><info FuWuBiaoZhun="" BuHanXiangMu="" GouWuAnPai="" ErTongAnPai="" ZiFeiXiangMu="" ZhuYiShiXiang="" WenXinTiXing="" BaoMingXuZhi=""/></root>
	,@ZhuTiXml NVARCHAR(MAX)--主题XML:<root><info ZhuTiId="" /></root>
	,@ZhuangTaiXml NVARCHAR(MAX)--状态XML:<root><info Status="" /></root>
	,@TourXml NVARCHAR(MAX)--发班XML:<root><info TourId="" LDate="" RDate="" Status="" /></root>
	,@TeSeFileXml NVARCHAR(MAX)--特色图片XML:<root><info FilePath="" MiaoShu="" /></root>
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	SET @errorcount=0

	BEGIN TRAN

	INSERT INTO [tbl_XianLu]([XianLuId],[AreaId],[RouteName]
		,[TianShu],[DepProvinceId],[DepCityId]
		,[ArrProvinceId],[ArrCityId],[JiHuaRenShu]
		,[SCJCR],[SCJET],[JSJCR]
		,[JSJET],[TingTianShu],[ChuFaJiaoTong]
		,[FanChengJiaoTong],[JiHeFangShi],[TeSe]
		,[TeSeFilePath],[TuJing],[QianZheng]
		,[QianZhengFilePath],[GuanZhuShu],[LxrName]
		,[LxrTelephone],[LxrQQ],[LxrMobile]
		,[Description],[Keywords],[OperatorId]
		,[IssueTime],[LatestId],[LatestTime])
	VALUES (@XianLuId,@AreaId,@RouteName
		,@TianShu,@DepProvinceId,@DepCityId
		,@ArrProvinceId,@ArrCityId,@JiHuaRenShu
		,@SCJCR,@SCJET,@JSJCR
		,@JSJET,@TingTianShu,@ChuFaJiaoTong
		,@FanChengJiaoTong,@JiHeFangShi,@TeSe
		,@TeSeFilePath,@TuJing,@QianZheng
		,@QianZhengFilePath,@GuanZhuShu,@LxrName
		,@LxrTelephone,@LxrQQ,@LxrMobile
		,@Description,@Keywords,@OperatorId
		,@IssueTime,@LatestId,@LatestTime)
	SET @errorcount=@errorcount+@@ERROR

	IF(@errorcount=0 AND @XingChengXML IS NOT NULL AND LEN(@XingChengXML)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@XingChengXML
		INSERT INTO [tbl_XianLuXingCheng]([XianLuId],[QuJian],[JiaoTong]
			,[ZhuSu],[YongCan],[XingCheng]
			,[FilePath])
		SELECT @XianLuId,A.[QuJian],A.[JiaoTong]
			,A.[ZhuSu],A.[YongCan],A.[XingCheng]
			,A.[FilePath]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([QuJian] NVARCHAR(255),[JiaoTong] NVARCHAR(255),[ZhuSu] NVARCHAR(255),[YongCan] NVARCHAR(255),[XingCheng] NVARCHAR(MAX),[FilePath] NVARCHAR(255)) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND @FuWuXml IS NOT NULL AND LEN(@FuWuXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@FuWuXMl
		INSERT INTO [tbl_XianLuFuWu]([XianLuId],[FuWuBiaoZhun],[BuHanXiangMu]
			,[GouWuAnPai],[ErTongAnPai],[ZiFeiXiangMu]
			,[ZhuYiShiXiang],[WenXinTiXing],[BaoMingXuZhi])
		SELECT @XianLuId,A.[FuWuBiaoZhun],A.[BuHanXiangMu]
			,A.[GouWuAnPai],A.[ErTongAnPai],A.[ZiFeiXiangMu]
			,A.[ZhuYiShiXiang],A.[WenXinTiXing],A.[BaoMingXuZhi]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([FuWuBiaoZhun] NVARCHAR(MAX),[BuHanXiangMu] NVARCHAR(MAX),[GouWuAnPai] NVARCHAR(MAX),[ErTongAnPai] NVARCHAR(MAX),[ZiFeiXiangMu] NVARCHAR(MAX),[ZhuYiShiXiang] NVARCHAR(MAX),[WenXinTiXing] NVARCHAR(MAX),[BaoMingXuZhi] NVARCHAR(MAX)) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND @ZhuTiXml IS NOT NULL AND LEN(@ZhuTiXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhuTiXml
		INSERT INTO [tbl_XianLuZhuTi]([XianLuId],[ZhuTiId])
		SELECT @XianLuId,A.[ZhuTiId]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([ZhuTiId] INT) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND @ZhuangTaiXml IS NOT NULL AND LEN(@ZhuangTaiXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhuangTaiXml
		INSERT INTO [tbl_XianLuZhuangTai]([XianLuId],[Status])
		SELECT @XianLuId,A.[Status]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([Status] TINYINT) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND @TourXml IS NOT NULL AND LEN(@TourXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@TourXml
		INSERT INTO [tbl_XianLuTour]([TourId],[XianLuId],[LDate]
			,[RDate],[Status])
		SELECT A.[TourId],@XianLuId,A.[LDate]
			,A.[RDate],A.[Status]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([TourId] CHAR(36),[LDate] DATETIME,[RDate] DATETIME,[Status] TINYINT) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0 AND @TeSeFileXml IS NOT NULL AND LEN(@TeSeFileXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@TeSeFileXml
		INSERT INTO [tbl_XianLuTeSeFile]([XianLuId],[FilePath],[MiaoShu])
		SELECT @XianLuId,A.FilePath,A.MiaoShu
		FROM OPENXML(@hdoc,'/root/info')
		WITH([FilePath] NVARCHAR(255),[MiaoShu] NVARCHAR(255)) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLu_Update]    脚本日期: 03/23/2013 15:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-14
-- Description:	修改线路产品信息，返回1成功，其它失败
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLu_Update]
	 @XianLuId CHAR(36)--线路编号
	,@AreaId INT--线路区域
	,@RouteName NVARCHAR(255)--线路名称
	,@TianShu INT--行程天数
	,@DepProvinceId INT--出发地省份编号
	,@DepCityId INT--出发地城市编号
	,@ArrProvinceId INT--目的地省份编号
	,@ArrCityId INT--目的地城市编号
	,@JiHuaRenShu INT--计划人数
	,@SCJCR MONEY--市场价-成人
	,@SCJET MONEY--市场价-儿童
	,@JSJCR MONEY--结算价-成人
	,@JSJET MONEY--结算价-儿童
	,@TingTianShu INT--提前X天报名
	,@ChuFaJiaoTong NVARCHAR(255)--出发交通
	,@FanChengJiaoTong NVARCHAR(255)--返程交通
	,@JiHeFangShi NVARCHAR(255)--集合方式
	,@TeSe NVARCHAR(MAX)--特色描述文字
	,@TeSeFilePath NVARCHAR(255)--特色描述图片
	,@TuJing NVARCHAR(255)--途径
	,@QianZheng NVARCHAR(MAX)--签证资料
	,@QianZhengFilePath NVARCHAR(255)--签证说明
	,@GuanZhuShu INT--关注数
	,@LxrName NVARCHAR(255)--联系人姓名
	,@LxrTelephone NVARCHAR(255)--联系人电话
	,@LxrQQ NVARCHAR(255)--联系人QQ
	,@LxrMobile NVARCHAR(255)--联系人手机
	,@Description NVARCHAR(255)--description
	,@Keywords NVARCHAR(255)--keywords
	,@OperatorId INT--发布人编号
	,@IssueTime DATETIME--发布时间
	,@LatestId INT--修改人编号
	,@LatestTime DATETIME--修改时间
	,@XingChengXML NVARCHAR(MAX)--行程XML:<root><info QuJian="" JiaoTong="" ZhuSu="" YongCan="" XingCheng="" FilePath="" /></root>
	,@FuWuXml NVARCHAR(MAX)--服务标准XML:<root><info FuWuBiaoZhun="" BuHanXiangMu="" GouWuAnPai="" ErTongAnPai="" ZiFeiXiangMu="" ZhuYiShiXiang="" WenXinTiXing="" BaoMingXuZhi=""/></root>
	,@ZhuTiXml NVARCHAR(MAX)--主题XML:<root><info ZhuTiId="" /></root>
	,@ZhuangTaiXml NVARCHAR(MAX)--状态XML:<root><info Status="" /></root>
	,@TourXml NVARCHAR(MAX)--发班XML:<root><info TourId="" LDate="" RDate="" Status="" /></root>
	,@TeSeFileXml NVARCHAR(MAX)--特色图片XML:<root><info FilePath="" MiaoShu="" /></root>
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	SET @errorcount=0

	BEGIN TRAN

	UPDATE [tbl_XianLu] SET [AreaId]=@AreaId,[RouteName]=@RouteName,[TianShu]=@TianShu
		,[DepProvinceId]=@DepProvinceId,[DepCityId]=@DepCityId,[ArrProvinceId]=@ArrProvinceId
		,[ArrCityId]=@ArrCityId,[JiHuaRenShu]=@JiHuaRenShu,[SCJCR]=@SCJCR
		,[SCJET]=@SCJET,[JSJCR]=@JSJCR,[JSJET]=@JSJET
		,[TingTianShu]=@TingTianShu,[ChuFaJiaoTong]=@ChuFaJiaoTong,[FanChengJiaoTong]=@FanChengJiaoTong
		,[JiHeFangShi]=@JiHeFangShi,[TeSe]=@TeSe,[TeSeFilePath]=@TeSeFilePath
		,[TuJing]=@TuJing,[QianZheng]=@QianZheng,[QianZhengFilePath]=@QianZhengFilePath
		,[GuanZhuShu]=[GuanZhuShu],[LxrName]=@LxrName,[LxrTelephone]=@LxrTelephone
		,[LxrQQ]=@LxrQQ,[LxrMobile]=@LxrMobile,[Description]=@Description
		,[Keywords]=@Keywords,[LatestId]=@LatestId,[LatestTime]=@LatestTime
	WHERE [XianLuId]=@XianLuId

	IF(@errorcount=0)
	BEGIN
		DELETE FROM [tbl_XianLuXingCheng] WHERE [XianLuId]=@XianLuId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @XingChengXML IS NOT NULL AND LEN(@XingChengXML)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@XingChengXML
			INSERT INTO [tbl_XianLuXingCheng]([XianLuId],[QuJian],[JiaoTong]
				,[ZhuSu],[YongCan],[XingCheng]
				,[FilePath])
			SELECT @XianLuId,A.[QuJian],A.[JiaoTong]
				,A.[ZhuSu],A.[YongCan],A.[XingCheng]
				,A.[FilePath]
			FROM OPENXML(@hdoc,'/root/info')
			WITH([QuJian] NVARCHAR(255),[JiaoTong] NVARCHAR(255),[ZhuSu] NVARCHAR(255),[YongCan] NVARCHAR(255),[XingCheng] NVARCHAR(MAX),[FilePath] NVARCHAR(255)) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END		
	END

	IF(@errorcount=0)
	BEGIN
		DELETE FROM [tbl_XianLuFuWu] WHERE [XianLuId]=@XianLuId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @FuWuXml IS NOT NULL AND LEN(@FuWuXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@FuWuXMl
			INSERT INTO [tbl_XianLuFuWu]([XianLuId],[FuWuBiaoZhun],[BuHanXiangMu]
				,[GouWuAnPai],[ErTongAnPai],[ZiFeiXiangMu]
				,[ZhuYiShiXiang],[WenXinTiXing],[BaoMingXuZhi])
			SELECT @XianLuId,A.[FuWuBiaoZhun],A.[BuHanXiangMu]
				,A.[GouWuAnPai],A.[ErTongAnPai],A.[ZiFeiXiangMu]
				,A.[ZhuYiShiXiang],A.[WenXinTiXing],A.[BaoMingXuZhi]
			FROM OPENXML(@hdoc,'/root/info')
			WITH([FuWuBiaoZhun] NVARCHAR(MAX),[BuHanXiangMu] NVARCHAR(MAX),[GouWuAnPai] NVARCHAR(MAX),[ErTongAnPai] NVARCHAR(MAX),[ZiFeiXiangMu] NVARCHAR(MAX),[ZhuYiShiXiang] NVARCHAR(MAX),[WenXinTiXing] NVARCHAR(MAX),[BaoMingXuZhi] NVARCHAR(MAX)) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END

	IF(@errorcount=0)
	BEGIN
		DELETE FROM [tbl_XianLuZhuTi] WHERE [XianLuId]=@XianLuId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @ZhuTiXml IS NOT NULL AND LEN(@ZhuTiXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhuTiXml
			INSERT INTO [tbl_XianLuZhuTi]([XianLuId],[ZhuTiId])
			SELECT @XianLuId,A.[ZhuTiId]
			FROM OPENXML(@hdoc,'/root/info')
			WITH([ZhuTiId] INT) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END

	IF(@errorcount=0 AND @ZhuangTaiXml IS NOT NULL AND LEN(@ZhuangTaiXml)>0)
	BEGIN
		DELETE FROM [tbl_XianLuZhuangTai] WHERE [XianLuId]=@XianLuId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @ZhuangTaiXml IS NOT NULL AND LEN(@ZhuangTaiXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@ZhuangTaiXml
			INSERT INTO [tbl_XianLuZhuangTai]([XianLuId],[Status])
			SELECT @XianLuId,A.[Status]
			FROM OPENXML(@hdoc,'/root/info')
			WITH([Status] TINYINT) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END

	IF(@errorcount=0 AND @TourXml IS NOT NULL AND LEN(@TourXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@TourXml

		UPDATE [tbl_XianLuTour] SET [LDate]=B.LDate,[RDate]=B.RDate
		FROM [tbl_XianLuTour] AS A INNER JOIN (SELECT [TourId],[LDate],[RDate],[Status] FROM OPENXML(@hdoc,'/root/info') WITH([TourId] CHAR(36),[LDate] DATETIME,[RDate] DATETIME,[Status] TINYINT)) AS B
		ON A.TourId=B.TourId
		WHERE A.XianLuId=@XianLuId
		SET @errorcount=@errorcount+@@ERROR

		INSERT INTO [tbl_XianLuTour]([TourId],[XianLuId],[LDate]
			,[RDate],[Status])
		SELECT A.[TourId],@XianLuId,A.[LDate]
			,A.[RDate],A.[Status]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([TourId] CHAR(36),[LDate] DATETIME,[RDate] DATETIME,[Status] TINYINT) AS A
		WHERE A.TourId NOT IN(SELECT TourId FROM [tbl_XianLuTour] AS B WHERE B.XianLuId=@XianLuId)
		SET @errorcount=@errorcount+@@ERROR

		DELETE FROM [tbl_XianLuTour] WHERE [XianLuId]=@XianLuId 
		AND [TourId] NOT IN(SELECT A.[TourId] FROM OPENXML(@hdoc,'/root/info') WITH([TourId] CHAR(36)) AS A) 
		AND [TourId] NOT IN(SELECT A.[TourId] FROM [tbl_XianLuTourOrder] AS A WHERE A.XianLuId=@XianLuId)
		SET @errorcount=@errorcount+@@ERROR

		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount=0)
	BEGIN
		DELETE FROM [tbl_XianLuTeSeFile] WHERE [XianLuId]=@XianLuId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @TeSeFileXml IS NOT NULL AND LEN(@TeSeFileXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@TeSeFileXml
			INSERT INTO [tbl_XianLuTeSeFile]([XianLuId],[FilePath],[MiaoShu])
			SELECT @XianLuId,A.FilePath,A.MiaoShu
			FROM OPENXML(@hdoc,'/root/info')
			WITH([FilePath] NVARCHAR(255),[MiaoShu] NVARCHAR(255)) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode
END
GO
/****** 对象:  View [dbo].[view_XianLuTourOrder]    脚本日期: 03/23/2013 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-23
-- Description:线路订单信息业务实体
-- =============================================
CREATE VIEW [dbo].[view_XianLuTourOrder]
AS
SELECT A.*,B.RouteName
FROM [tbl_XianLuTourOrder] AS A INNER JOIN [tbl_XianLu] AS B
ON A.XianLuId=B.XianLuId
GO
/****** 对象:  View [dbo].[view_XianLuTuanGou]    脚本日期: 03/23/2013 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-19
-- Description:线路团购信息视图,含订单数、收客数等信息
-- =============================================
CREATE VIEW [dbo].[view_XianLuTuanGou]
AS
SELECT A.*
	,B.RouteName
	,(SELECT COUNT(*) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TuanGouId=A.TuanGouId) AS DingDanShu 
	,(SELECT ISNULL(SUM(ChengRenShu+ErTongShu),0) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TuanGouid=A.TuanGouid AND A1.Status=4) AS ShiShouRenShu
	,(SELECT ISNULL(SUM(ChengRenShu+ErTongShu),0) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TuanGouid=A.TuanGouid AND A1.Status IN(0,3,4)) AS YiShouRenShu
FROM [tbl_XianLuTuanGou] AS A  INNER JOIN [tbl_XianLu] AS B
ON A.XianLuId=B.XianLuId
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLuOrder_Insert]    脚本日期: 03/23/2013 15:19:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-15
-- Description:	写入订单信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLuOrder_Insert]
	 @OrderId CHAR(36)--订单编号
	,@XianLuId CHAR(36)--线路编号
	,@TourId CHAR(36)--团队编号
	,@OrderCode NVARCHAR(50) OUTPUT--OUTPUT 订单号
	,@Status TINYINT--订单状态
	,@ChengRenShu INT--成人数
	,@ErTongShu INT--儿童数
	,@JSJCR MONEY--成人价
	,@JSJER MONEY--儿童价
	,@JinE MONEY--合同金额
	,@FuKuanStatus TINYINT--付款状态
	,@LDate DATETIME--出发日期
	,@QiTaBeiZhu NVARCHAR(MAX)--其它要求
	,@XiaDanBeiZhu NVARCHAR(MAX)--下单备注
	,@LxrXml NVARCHAR(MAX)--联系人MXL:<root><info LxrName="" LxrTelephone="" LxrGender="" LxrZhengJianType="" LxrZhengJianCode="" /></root>
	,@OperatorId CHAR(36)--下单人
	,@IssueTime DATETIME--下单时间
	,@YouKeXml NVARCHAR(MAX)--游客XML:<root><info YouKeId="" Name="" Telephone="" Mobile="" Gender="" LeiXing="" IdCode="" ZhengJianType="" ZhengJianCode="" BeiZhu="" /></root>
	,@TuanGouId CHAR(36)--团购编号
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	DECLARE @YiShouRenShu INT--已收人数
	DECLARE @JiHuaRenShu INT--计划人数
	DECLARE @ShouKeZhuangTai TINYINT--收客状态
	DECLARE @LiuShuiHiao INT--流水号

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTour] WHERE [XianLuId]=@XianLuId AND [TourId]=@TourId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	SELECT @LDate=[LDate],@ShouKeZhuangTai=[Status] FROM [tbl_XianLuTour] WHERE [TourId]=@TourId
	SELECT @YiShouRenShu=SUM([ChengRenShu]+[ErTongShu]) FROM [tbl_XianLuTourOrder] WHERE [TourId]=@TourId AND [Status] IN(0,3,4)
	SET @YiShouRenShu=ISNULL(@YiShouRenShu,0)

	SELECT @JiHuaRenShu=[JiHuaRenShu] FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId

	IF((@TuanGouId IS NULL OR LEN(@TuanGouId)<1) AND @JiHuaRenShu<@YiShouRenShu+@ChengRenShu+@ErTongShu)
	BEGIN
		SET @RetCode=-97
		RETURn @RetCode
	END

	IF(@ShouKeZhuangTai<>0)
	BEGIN
		SET @RetCode=-96
		RETURn @RetCode
	END

	IF(@TuanGouId IS NOT NULL AND LEN(@TuanGouId)>0)
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTuanGou] WHERE [TuanGouId]=@TuanGouId AND [XianLuId]=@XianLuId)
		BEGIN
			SET @RetCode=-94
			RETURN @RetCode
		END
	END

	SELECT @LiuShuiHiao=COUNT(*)+1 FROM [tbl_XianLuTourOrder]
	SET @OrderCode=CONVERT(VARCHAR(8),GETDATE(),112)+'8'+dbo.fn_PadLeft(@LiuShuiHiao,'0',4)

	BEGIN TRAN

	EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@LxrXml
	INSERT INTO [tbl_XianLuTourOrder]([OrderId],[XianLuId],[TourId]
		,[OrderCode],[Status],[ChengRenShu]
		,[ErTongShu],[JSJCR],[JSJER]
		,[JinE],[FuKuanStatus],[LDate]
		,[QiTaBeiZhu],[XiaDanBeiZhu],[LxrName]
		,[LxrTelephone],[LxrGender],[LxrZhengJianType]
		,[LxrZhengJianCode],[OperatorId],[IssueTime]
		,[TuanGouId])
	SELECT @OrderId,@XianLuId,@TourId
		,@OrderCode,@Status,@ChengRenShu
		,@ErTongShu,@JSJCR,@JSJER
		,@JinE,@FuKuanStatus,@LDate
		,@QiTaBeiZhu,@XiaDanBeiZhu,A.LxrName
		,A.LxrTelephone,A.LxrGender,A.LxrZhengJianType
		,A.LxrZhengJianCode,@OperatorId,@IssueTime
		,@TuanGouId
	FROM OPENXML(@hdoc,'/root/info')
	WITH(LxrName NVARCHAR(255),LxrTelephone NVARCHAR(255),LxrGender TINYINT,LxrZhengJianType TINYINT,LxrZhengJianCode NVARCHAR(255)) AS A
	SET @errorcount=@errorcount+@@ERROR
	EXECUTE sp_xml_removedocument @hdoc

	IF(@errorcount=0 AND @YouKeXml IS NOT NULL AND LEN(@YouKeXml)>0)
	BEGIN
		EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@YouKeXml
		INSERT INTO [tbl_XianLuTourOrderYouKe]([OrderId],[YouKeId],[Name]
			,[Telephone],[Mobile],[Gender]
			,[LeiXing],[IdCode],[ZhengJianType]
			,[ZhengJianCode],[BeiZhu])
		SELECT @OrderId,A.[YouKeId],A.[Name]
			,A.[Telephone],A.[Mobile],A.[Gender]
			,A.[LeiXing],A.[IdCode],A.[ZhengJianType]
			,A.[ZhengJianCode],A.[BeiZhu]
		FROM OPENXML(@hdoc,'/root/info')
		WITH([YouKeId] CHAR(36),[Name] NVARCHAR(255),[Telephone] NVARCHAR(255),[Mobile] NVARCHAR(255),[Gender] TINYINT,[LeiXing] TINYINT,[IdCode] NVARCHAR(255),[ZhengJianType] TINYINT,[ZhengJianCode] NVARCHAR(255),[BeiZhu] NVARCHAR(255)) AS A
		SET @errorcount=@errorcount+@@ERROR
		EXECUTE sp_xml_removedocument @hdoc
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode	
END
GO
/****** 对象:  StoredProcedure [dbo].[proc_XianLuOrder_Update]    脚本日期: 03/23/2013 15:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-15
-- Description:	写入订单信息
-- =============================================
CREATE PROCEDURE [dbo].[proc_XianLuOrder_Update]
	 @OrderId CHAR(36)--订单编号
	,@XianLuId CHAR(36)--线路编号
	,@TourId CHAR(36)--团队编号
	,@OrderCode NVARCHAR(50) OUTPUT--OUTPUT 订单号
	,@Status TINYINT--订单状态
	,@ChengRenShu INT--成人数
	,@ErTongShu INT--儿童数
	,@JSJCR MONEY--成人价
	,@JSJER MONEY--儿童价
	,@JinE MONEY--合同金额
	,@FuKuanStatus TINYINT--付款状态
	,@LDate DATETIME--出发日期
	,@QiTaBeiZhu NVARCHAR(MAX)--其它要求
	,@XiaDanBeiZhu NVARCHAR(MAX)--下单备注
	,@LxrXml NVARCHAR(MAX)--联系人MXL:<root><info LxrName="" LxrTelephone="" LxrGender="" LxrZhengJianType="" LxrZhengJianCode="" /></root>
	,@OperatorId CHAR(36)--下单人
	,@IssueTime DATETIME--下单时间
	,@YouKeXml NVARCHAR(MAX)--游客XML:<root><info YouKeId="" Name="" Telephone="" Mobile="" Gender="" LeiXing="" IdCode="" ZhengJianType="" ZhengJianCode="" BeiZhu="" /></root>
	,@RetCode INT OUTPUT--OUTPUT CODE
AS
BEGIN
	DECLARE @errorcount INT
	DECLARE @hdoc INT
	DECLARE @YiShouRenShu INT--已收人数
	DECLARE @JiHuaRenShu INT--计划人数
	DECLARE @ShouKeZhuangTai TINYINT--收客状态
	DECLARE @TuanGouId CHAR(36)--团购编号

	SET @errorcount=0

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTourOrder] WHERE [OrderId]=@OrderId)
	BEGIN
		SET @RetCode=-95
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId)
	BEGIN
		SET @RetCode=-99
		RETURN @RetCode
	END

	IF NOT EXISTS(SELECT 1 FROM [tbl_XianLuTour] WHERE [XianLuId]=@XianLuId AND [TourId]=@TourId)
	BEGIN
		SET @RetCode=-98
		RETURN @RetCode
	END

	SELECT @LDate=[LDate],@ShouKeZhuangTai=[Status] FROM [tbl_XianLuTour] WHERE [TourId]=@TourId
	SELECT @YiShouRenShu=SUM([ChengRenShu]+[ErTongShu]) FROM [tbl_XianLuTourOrder] WHERE [TourId]=@TourId AND [Status] IN(0,3,4) AND [OrderId]<>@OrderId
	SET @YiShouRenShu=ISNULL(@YiShouRenShu,0)

	SELECT @TuanGouId=[TuanGouid] FROM [tbl_XianLuTourOrder] WHERE [OrderId]=@OrderId

	SELECT @JiHuaRenShu=[JiHuaRenShu] FROM [tbl_XianLu] WHERE [XianLuId]=@XianLuId

	IF((@TuanGouId IS NULL OR LEN(@TuanGouId)<1) AND @JiHuaRenShu<@YiShouRenShu+@ChengRenShu+@ErTongShu)
	BEGIN
		SET @RetCode=-97
		RETURn @RetCode
	END

	BEGIN TRAN

	EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@LxrXml
	UPDATE [tbl_XianLuTourOrder] SET [ChengRenShu]=@ChengRenShu,[ErTongShu]=@ErTongShu,[JSJCR]=@JSJCR
		,[JSJER]=@JSJER,[JinE]=@JinE,[LDate]=@LDate
		,[QiTaBeiZhu]=@QiTaBeiZhu,[XiaDanBeiZhu]=@XiaDanBeiZhu,[LxrName]=B.LxrName
		,[LxrTelephone]=B.LxrTelephone,[LxrGender]=B.LxrGender,[LxrZhengJianType]=B.LxrZhengJianType
		,[LxrZhengJianCode]=B.LxrZhengJianCode,[TourId]=@TourId
	FROM [tbl_XianLuTourOrder] AS A,(SELECT * FROM OPENXML(@hdoc,'/root/info') WITH(LxrName NVARCHAR(255),LxrTelephone NVARCHAR(255),LxrGender TINYINT,LxrZhengJianType TINYINT,LxrZhengJianCode NVARCHAR(255)))B
	WHERE A.OrderId=@orderId
	SET @errorcount=@errorcount+@@ERROR
	EXECUTE sp_xml_removedocument @hdoc

	IF(@errorcount=0)
	BEGIN
		DELETE FROM [tbl_XianLuTourOrderYouKe] WHERE [OrderId]=@OrderId
		SET @errorcount=@errorcount+@@ERROR
		IF(@errorcount=0 AND @YouKeXml IS NOT NULL AND LEN(@YouKeXml)>0)
		BEGIN
			EXECUTE sp_xml_preparedocument @hdoc OUTPUT,@YouKeXml
			INSERT INTO [tbl_XianLuTourOrderYouKe]([OrderId],[YouKeId],[Name]
				,[Telephone],[Mobile],[Gender]
				,[LeiXing],[IdCode],[ZhengJianType]
				,[ZhengJianCode],[BeiZhu])
			SELECT @OrderId,A.[YouKeId],A.[Name]
				,A.[Telephone],A.[Mobile],A.[Gender]
				,A.[LeiXing],A.[IdCode],A.[ZhengJianType]
				,A.[ZhengJianCode],A.[BeiZhu]
			FROM OPENXML(@hdoc,'/root/info')
			WITH([YouKeId] CHAR(36),[Name] NVARCHAR(255),[Telephone] NVARCHAR(255),[Mobile] NVARCHAR(255),[Gender] TINYINT,[LeiXing] TINYINT,[IdCode] NVARCHAR(255),[ZhengJianType] TINYINT,[ZhengJianCode] NVARCHAR(255),[BeiZhu] NVARCHAR(255)) AS A
			SET @errorcount=@errorcount+@@ERROR
			EXECUTE sp_xml_removedocument @hdoc
		END
	END

	IF(@errorcount<>0)
	BEGIN
		ROLLBACK TRAN
		SET @RetCode=-100
		RETURN @RetCode
	END

	COMMIT TRAN
	SET @RetCode=1
	RETURN @RetCode	
END
GO
/****** 对象:  View [dbo].[view_XianLuTour_OrderHistory]    脚本日期: 03/23/2013 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-16
-- Description:线路订单历史记录信息
-- =============================================
CREATE VIEW [dbo].[view_XianLuTour_OrderHistory]
AS
SELECT A.*,B.Realname AS OperatorName,1 AS T
FROM [tbl_XianLuTourOrderHistory] AS A INNER JOIN tbl_Webmaster AS B 
ON A.OperatorId=B.Id
WHERE ISNUMERIC(A.OperatorId)=1
UNION ALL
SELECT A.*,B.MemberName AS OperatorName,0 AS T
FROM [tbl_XianLuTourOrderHistory] AS A INNER JOIN [tbl_Member] AS B 
ON A.OperatorId=B.MemberID
WHERE ISNUMERIC(A.OperatorId)=0
GO
/****** 对象:  View [dbo].[view_XianLuTour]    脚本日期: 03/23/2013 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-16
-- Description:线路发班信息视图,含订单数、收客数等信息
-- =============================================
CREATE VIEW [dbo].[view_XianLuTour]
AS
SELECT A.*
	,(SELECT COUNT(*) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TourId=A.TourId) AS DingDanShu 
	,(SELECT ISNULL(SUM(ChengRenShu+ErTongShu),0) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TourId=A.TourId AND A1.Status=4) AS ShiShouRenShu
	,(SELECT ISNULL(SUM(ChengRenShu+ErTongShu),0) FROM [tbl_XianLuTourOrder] AS A1 WHERE A1.TourId=A.TourId AND A1.Status IN(0,3,4)) AS YiShouRenShu
FROM [tbl_XianLuTour] AS A
GO
/****** 对象:  View [dbo].[view_XianLuTour_ZuiJinFaBan]    脚本日期: 03/23/2013 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		汪奇志
-- Create date: 2013-03-16
-- Description:线路发班周期最近发班
-- =============================================
CREATE VIEW [dbo].[view_XianLuTour_ZuiJinFaBan]
AS
SELECT A.* FROM [tbl_XianLuTour] AS A INNER JOIN (SELECT XianLuId,MIN([LDate]) AS ZuiJinQuTuanRiQi FROM tbl_XianLuTour WHERE LDate>=GETDATE() GROUP BY XianLuId)B
ON A.XianLuId=B.XianLuId AND A.Ldate=b.ZuiJinQuTuanRiQi
GO
/****** 对象:  View [dbo].[view_XianLu]    脚本日期: 03/23/2013 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_XianLu]
AS
SELECT A.*
	,B.TourId
	,B.LDate
	,B.RDate
	,B.Status
	,(select avg(ManYiDu) as ManYiDu from tbl_XianLuDianPing  where XianLuId=A.XianLuId)as ManYiDu
	,(select count(1) from tbl_XianLuDianPing  where XianLuId=A.XianLuId) as DianPingShu
FROM [tbl_XianLu] AS A LEFT OUTER JOIN [view_XianLuTour_ZuiJinFaBan] AS B
ON A.XianLuId=B.XianLuId
GO
