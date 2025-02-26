USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[SP_GIAOTAC]    Script Date: 10/19/2019 23:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GIAOTAC]
@minsup float
AS
BEGIN
	
	select MAMH,COUNT(DISTINCT(MASV))AS sup INTO #DSMAMH_Sup from (select MASV, MAMH from DIEM group by MAMH, MASV HAVING MAX(DIEM)<5) AS tmp group by MAMH
	DECLARE @SUP float
	SET @SUP  =(@minsup * (SELECT COUNT(*) FROM (SELECT DISTINCT(MASV) FROM DIEM group by MAMH, MASV HAVING MAX(DIEM)<5) AS tmp))/100.0
	
	SELECT DISTINCT(MAMH) INTO #DSMAMH FROM #DSMAMH_Sup 
	WHERE SUP >= @SUP ORDER BY (MAMH)
	
	DECLARE @PivotColumnHeader varchar(max)
	SET @PivotColumnHeader = ''
	SELECT @PivotColumnHeader += RTRIM(MAMH) + ',' FROM #DSMAMH
	IF LEN(@PivotColumnHeader)=0
		RETURN
	SET @PivotColumnHeader = SUBSTRING(@PivotColumnHeader,1,LEN(@PivotColumnHeader)-1)
	 
	SELECT MASV,MAMH into #DIEM from DIEM group by MAMH, MASV HAVING MAX(DIEM)<5 AND MAMH IN (SELECT * FROM #DSMAMH)
	DECLARE @PivotTable varchar(MAX)
	SET @PivotTable = 'SELECT * FROM #DIEM Pivot( COUNT(MAMH) for MAMH in ('+ @PivotColumnHeader +')) as PivotTable'
	PRINT (@PivotTable)
	execute(@PivotTable)

	DROP TABLE #DSMAMH_Sup
	DROP TABLE #DSMAMH
	DROP TABLE #DIEM
	
END