CREATE PROC [SP_TIMSUPPORT]
@minsup float
AS
BEGIN
	
	select MAMH,COUNT(DISTINCT(MASV))AS sup INTO #DSMAMH_Sup from (select DISTINCT(MASV), MAMH from DIEM group by MAMH, MASV HAVING MAX(DIEM)<5) AS tmp group by MAMH
	-- select MAMH,COUNT(DISTINCT(MASV))AS sup INTO #DSMAMH_Sup from DIEM group by MAMH, MASV HAVING MAX(DIEM)<5
	DECLARE @SUP float
	DECLARE @minsup float
	SET @minsup = 50
	SET @SUP  =(@minsup * (SELECT COUNT(*) FROM (SELECT DISTINCT(MASV) FROM DIEM group by MAMH, MASV HAVING MAX(DIEM)<5) AS tmp))/100.0
	PRINT @SUP
	
	SELECT DISTINCT(MAMH) INTO #DSMAMH FROM #DSMAMH_Sup 
	WHERE sup >= @SUP ORDER BY (MAMH)
	
	DECLARE @PivotColumnHeader varchar(max)
	SET @PivotColumnHeader = ''
	SELECT @PivotColumnHeader += RTRIM(MAMH) + ',' FROM #DSMAMH
	SET @PivotColumnHeader = SUBSTRING(@PivotColumnHeader,1,LEN(@PivotColumnHeader)-1)
	 
	SELECT MASV,MAMH into #DIEM from DIEM 
	DECLARE @PivotTable varchar(MAX)
	SET @PivotTable = 'SELECT * FROM #DIEM Pivot( COUNT(MAMH) for MAMH in ('+ @PivotColumnHeader +')) as PivotTable'
	PRINT (@PivotTable)
	execute(@PivotTable)


	DROP TABLE #DSMAMH_Sup
	DROP TABLE #DSMAMH
	DROP TABLE #Diem
	
END