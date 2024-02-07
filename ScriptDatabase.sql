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
go
CREATE TABLE dbo.Exams
(
	ExamId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(300) NOT NULL,
	AnalysisId INT NOT NULL,
	State INT NOT NULL,
	CreatedDate DATETIME2(7) DEFAULT(GETDATE()),
	CONSTRAINT FK_EXAMPS_ANALYSIS_ANALYSIS_ID FOREIGN KEY (AnalysisId) REFERENCES dbo.Analysis(AnalysisId)
)
go
INSERT INTO dbo.Exams
(
	Name
	,AnalysisId
	,State
)
VALUES
(
	'Exam Test 1'
	,1
	,1
)

go
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
go
	CREATE PROCEDURE dbo.SP_CHANGE_ANALYSIS_STATE
		@AnalysisId INT,
		@State INT
	AS
	BEGIN
		UPDATE dbo.Analysis
			SET [State] = @State
		WHERE AnalysisId = @AnalysisId
	END
go
CREATE PROCEDURE dbo.GET_EXAMS_LIST
AS
BEGIN
	SELECT
		E.ExamId
		,E.[Name]
		,Analysis = A.[Name]
		,StateExam = CASE WHEN E.[State] = 1 then 'ACTIVO' ELSE 'INACTIVO' END
		,E.CreatedDate
	FROM dbo.Exams E
	INNER JOIN dbo.Analysis A
		ON E.AnalysisId = A.AnalysisId
END
GO
CREATE PROCEDURE dbo.SP_GET_EXAM_BY_ID
(
	@ExamId INT
)
AS
BEGIN
	SELECT ExamId
		,Name
		,AnalysisId
	FROM dbo.Exams
	WHERE ExamId = @ExamId
END
go

CREATE PROCEDURE dbo.SP_EXAM_REGISTER
(
	@Name VARCHAR(200)
	,@AnalysisId int
)
AS
BEGIN
	INSERT INTO dbo.Exams
		(
			Name
			,AnalysisId
			,State
		)
	VALUES
		(
			@Name
			,@AnalysisId
			,1
		)

END
go
CREATE PROCEDURE dbo.SP_EXAM_EDIT
(
	@ExamId INT
	,@Name VARCHAR(200)
	,@AnalysisId INT
)
AS
BEGIN
	UPDATE dbo.Exams
		SET Name = @Name
			,AnalysisId = @AnalysisId
	WHERE ExamId = @ExamId
END
go
CREATE PROCEDURE dbo.SP_REMOVE_EXAM
(
	@ExamId INT
)
AS
BEGIN
	Delete from dbo.Exams
	WHERE ExamId = @ExamId
END
go

CREATE PROCEDURE dbo.SP_CHANGE_STATE_EXAM
(
	@ExamId INT
	,@State INT
)
AS
BEGIN
	UPDATE dbo.Exams
		SET State = @State
	WHERE ExamId = @ExamId
END
/*****************************************
--TEST STORE PROCEDURES
*******************************************/
EXEC dbo.SP_GET_ANALYSIS_LIST
EXEC dbo.SP_GET_ANALYSIS_LIST_BY_ID 1
EXEC dbo.GET_EXAMS_LIST
EXEC dbo.SP_GET_EXAM_BY_ID 1