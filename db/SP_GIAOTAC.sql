USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[SP_GIAOTAC]    Script Date: 10/12/2019 14:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GIAOTAC]
@minsup float
AS
BEGIN
	
	SELECT MAMH,COUNT(DISTINCT(MASV))AS sup INTO #DSMAMH_Sup FROM (SELECT MASV, MAMH FROM DIEM GROUP BY MAMH, MASV HAVING MAX(DIEM)<5) AS tmp GROUP BY MAMH
	DECLARE @SUP float
	SET @SUP  =(80 * (SELECT COUNT(*) FROM (SELECT DISTINCT(MASV) FROM DIEM group by MAMH, MASV HAVING MAX(DIEM)<5) AS tmp))/100.0
	
	SELECT DISTINCT(MAMH) INTO #DSMAMH FROM #DSMAMH_Sup 
	WHERE SUP >= @SUP ORDER BY (MAMH)
	
	DECLARE @PivotColumnHeader varchar(max)
	SET @PivotColumnHeader = ''
	SELECT @PivotColumnHeader += RTRIM(MAMH) + ',' FROM #DSMAMH
	PRINT LEN(@PivotColumnHeader)
	IF LEN(@PivotColumnHeader) =0
	BEGIN
		DROP TABLE #DSMAMH_Sup
		Return 1
	END
	
	SET @PivotColumnHeader = SUBSTRING(@PivotColumnHeader,1,LEN(@PivotColumnHeader)-1)
	 
	SELECT MASV,MAMH into #DIEM from DIEM group by MAMH, MASV HAVING MAX(DIEM)<5 AND MAMH IN (SELECT * FROM #DSMAMH)
	DECLARE @PivotTable varchar(MAX)
	SET @PivotTable = 'SELECT * FROM #DIEM Pivot( COUNT(MAMH) for MAMH in ('+ @PivotColumnHeader +')) as PivotTable'
	PRINT (@PivotTable)
	--IF LEN(@PivotColumnHeader)>0
	execute(@PivotTable)

	DROP TABLE #DSMAMH_Sup
	DROP TABLE #DSMAMH
	DROP TABLE #DIEM
	
END
EXEC SP_GIAOTAC 10