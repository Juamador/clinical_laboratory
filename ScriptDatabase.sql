CREATE DATABASE CLINICAL
GO
USE CLINICAL
GO
--TABLES
CREATE TABLE dbo.Analysis
(
	AnalysisId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	State INT NOT NULL,
	CreatedDate DATETIME2(7) DEFAULT(GETDATE())
)
go
/*****************************************
--INSERT A TEST RECCORD IN THE TABLE
*******************************************/
GO
INSERT INTO dbo.Analysis
(
	Name
	,State
)
VALUES
(
	'ANALYSIS TEST 1'
	,1
)
go
INSERT INTO dbo.Analysis
(
	Name
	,State
)
VALUES
(
	'ANALYSIS TEST 2'
	,0
)

/*****************************************
--STORE PROCEDURES
*******************************************/
CREATE PROCEDURE dbo.SP_GET_ANALYSIS_LIST
AS
BEGIN
	SELECT
		AnalysisId
		,Name
		,CreatedDate
		,State
	FROM dbo.Analysis
END
CREATE PROCEDURE dbo.SP_GET_ANALYSIS_LIST_BY_ID
	@AnalysisId INT
AS
BEGIN
	SELECT
		AnalysisId
		,Name
	FROM dbo.Analysis
	WHERE AnalysisId = @AnalysisId
END
go
CREATE PROCEDURE dbo.SP_ANALYSIS_REGISTER
(
	@Name VARCHAR(100)
)
AS
BEGIN
	IF EXISTS(SELECT 1 FROM dbo.Analysis WHERE NAME=@Name)
		BEGIN
			DECLARE @Message VARCHAR(200) = 'Already exists a record with the name ' + @Name
			RAISERROR(@Message, 16, -1)
			RETURN;
		END

	INSERT INTO dbo.Analysis
		(
			Name
			,State
			,CreatedDate
		)
	VALUES
		(
			@Name
			,1
			,GETDATE()
		)
END
go
CREATE PROCEDURE dbo.SP_ANALYSIS_EDIT
(
	@AnalysisId INT,
	@Name VARCHAR(100)
)
AS
BEGIN
	UPDATE dbo.Analysis
		SET Name = @Name
	WHERE AnalysisId = @AnalysisId
END
go

CREATE PROCEDURE dbo.SP_ANALYSIS_REMOVE
(
	@AnalysisId INT
)
AS
BEGIN
	DELETE 
	FROM dbo.Analysis
	WHERE AnalysisId = @AnalysisId
END
/*****************************************
--TEST STORE PROCEDURES
*******************************************/
EXEC dbo.SP_GET_ANALYSIS_LIST
EXEC dbo.SP_GET_ANALYSIS_LIST_BY_ID 1