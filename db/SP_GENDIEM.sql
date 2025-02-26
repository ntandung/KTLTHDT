USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[SP_GENDIEM]    Script Date: 11/24/2019 12:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_GENDIEM]
@numrow INT,
@minsup INT,
@list VARCHAR(500)
AS
BEGIN
	IF LEN(@list)=0
		RETURN
	
	-- GEN @numrow SINH VIEN --
	DELETE FROM DIEM
	DELETE FROM SINHVIEN
	DECLARE @Id INT
	SET @Id = 1
	WHILE @Id <= @numrow
	BEGIN 
	   DECLARE @lop NVARCHAR(20)
	   SELECT @lop = (SELECT TOP 1 MALOP FROM LOP ORDER BY NEWID())
	   INSERT INTO SINHVIEN (MASV, MALOP)
	   VALUES (CAST(@Id as nvarchar(12)), CAST(@lop AS NVARCHAR(20)))
	   SET @Id = @Id + 1
	END
	
	-- TINH SO DONG DUA VAO MINSUP --
	DECLARE @soSinhVienFail INT
	SET @soSinhVienFail = @minsup * @numrow / 100
	print(@soSinhVienFail)
	
	-- AUTO GEN DIEM --
	DELETE FROM DIEM
	
	-- @soSinhVienFail so mon do
	INSERT INTO DIEM
	SELECT * FROM  (SELECT MASV,MAMH, 1 AS LAN, ABS(CHECKSUM(NewId())) % 4 AS DIEM FROM (SELECT TOP (@soSinhVienFail) MASV FROM SINHVIEN ORDER BY MASV DESC) AS SV, MONHOC WHERE MAMH IN (SELECT * FROM dbo.splitstring(@list))) AS TMP
	
	-- @soSinhVienFail Thi mon khac, co the fail or pass 
	INSERT INTO DIEM
	SELECT * FROM  (SELECT MASV,MAMH, 1 AS LAN, ABS(CHECKSUM(NewId())) % 10 AS DIEM FROM (SELECT TOP (@soSinhVienFail) MASV FROM SINHVIEN ORDER BY MASV DESC) AS SV, MONHOC WHERE MAMH NOT IN (SELECT * FROM dbo.splitstring(@list))) AS TMP
	
	-- @numrow - @soSinhVienFail thi mon khac
	INSERT INTO DIEM
	SELECT * FROM  (SELECT MASV,MAMH, 1 AS LAN, ABS(CHECKSUM(NewId())) % 4 AS DIEM FROM (SELECT TOP (@numrow - @soSinhVienFail) MASV FROM SINHVIEN ORDER BY MASV ASC) AS SV, MONHOC WHERE MAMH NOT IN (SELECT * FROM dbo.splitstring(@list))) AS TMP1

	--INSERT INTO DIEM
	--SELECT * FROM  (SELECT MASV,MAMH, 1 AS LAN, ABS(CHECKSUM(NewId())) % 4 AS DIEM FROM (SELECT TOP (@numrow - @soSinhVienFail) MASV FROM SINHVIEN ORDER BY MASV ASC) AS SV, MONHOC) AS TMP1
END

