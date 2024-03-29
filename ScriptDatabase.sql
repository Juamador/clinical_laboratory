/******************************************
Created by: Ing. Julisy Amador
Description: Tables and Stored Procedures to be used in a Clinical Laboratory with API workflow
Tecnologies: C#, DAPPER, SQLSERVER, .NET CORE, CQRS, SOLID PRINCIPLES, DEPENDENCY INJECTION, MEDIATOR
*******************************************/
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
CREATE TABLE dbo.DocumentTypes
(
	DocumentTypeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Document VARCHAR(50) NOT NULL,
	State INT NOT NULL DEFAULT(1)
)
go
INSERT INTO dbo.DocumentTypes (Document)
VALUES('DNI')
CREATE TABLE dbo.TypeAges
(
	TypeAgeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TypeAge VARCHAR(15) NOT NULL,
	State INT NOT NULL DEFAULT(1)
)
GO
INSERT INTO dbo.TypeAges (TypeAge)
VALUES('MONTHS')
GO
INSERT INTO dbo.TypeAges (TypeAge)
VALUES('YEARS')
go
CREATE TABLE dbo.Genders
(
	GenderId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Gender VARCHAR(25) NOT NULL,
	State INT NOT NULL DEFAULT(1)
)
INSERT INTO dbo.Genders(Gender)
VALUES('FEMALE')
GO
INSERT INTO dbo.Genders(Gender)
VALUES('MALE')
go

CREATE TABLE dbo.Patients
(
	PatientId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Names VARCHAR(100),
	LastName VARCHAR(50),
	MotherMaidenName VARCHAR(50),
	DocumentTypeId INT,
	DocumentNumber VARCHAR(25),
	Phone VARCHAR(15),
	TypeAgeId INT,
	Age INT,
	GenderId INT,
	State INT,
	CreatedDate Datetime DEFAULT(GETDATE()),
	CONSTRAINT FK_PATIENTS_DOCUMENT_TYPES_DOCUMENTTYPEID FOREIGN KEY (DocumentTypeId) REFERENCES dbo.DocumentTypes(DocumentTypeId),
	CONSTRAINT FK_PATIENTS_TYPE_AGES_TYPEAGEID FOREIGN KEY (TypeAgeId) REFERENCES dbo.TypeAges(TypeAgeId),
	CONSTRAINT FK_PATIENTS_GENDERS_GENDERID FOREIGN KEY (GenderId) REFERENCES dbo.Genders(GenderId)
)
go
INSERT INTO dbo.Patients
(
	Names
	,LastName
	,MotherMaidenName
	,DocumentTypeId
	,DocumentNumber
	,Phone
	,TypeAgeId
	,Age
	,GenderId
	,State
)
VALUES
(
	'Julisy'
	,'Amador'
	,'Figuereo'
	,1
	,'89554545'
	,'8092556655'
	,2
	,30
	,2
	,1
)
GO
CREATE TABLE dbo.Specialties
(
	SpecialtyId INT IDENTITY(1,1) PRIMARY KEY NOT NULL
	,Name VARCHAR(100) NOT NULL
	,State INT NOT NULL DEFAULT(1)
	,CreatedDate DATETIME NOT NULL DEFAULT(GETDATE())
)
go
INSERT INTO dbo.Specialties
(Name)
values
('Prenatal')
go

GO
CREATE TABLE dbo.Medics
(
	MedicId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Names VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	MotherMaidenName VARCHAR(100) NOT NULL,
	Address VARCHAR(255),
	Phone VARCHAR(15),
	BirthDate Date,
	DocumentTypeId INT NOT NULL,
	DocumentNumber VARCHAR(25) NOT NULL,
	SpecialtyId INT NOT NULL,
	CreatedDate DATETIME NOT NULL DEFAULT(GETDATE()),
	State INT NOT NULL DEFAULT(1),
	CONSTRAINT FK_MEDICS_DOCUMENT_TYPES_DOCUMENT_TYPE_ID FOREIGN KEY (DocumentTypeId) REFERENCES dbo.DocumentTypes(DocumentTypeId),
	CONSTRAINT FK_MEDICS_SPECIALTIES_SPECIALTY_ID FOREIGN KEY (SpecialtyId) REFERENCES dbo.Specialties(SpecialtyId)
)

go
INSERT INTO dbo.Medics
	(
		Names,
		LastName,
		MotherMaidenName,
		Address,
		Phone,
		BirthDate,
		DocumentTypeId,
		DocumentNumber,
		SpecialtyId
	)
values
	(
		'Cesar',
		'Valencia',
		'Palacios',
		'Santo Domingo, Dominican Republic',
		'8294565555',
		'1980-01-20',
		1,
		'22855555655',
		1
	)
go
CREATE TABLE dbo.TakeExam
(
	TakeExamId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PatientId INT NOT NULL,
	MedicId INT NOT NULL,
	State INT DEFAULT(1) NOT NULL,
	CreatedDate DateTime DEFAULT(GETDATE()) NOT NULL,
	CONSTRAINT FK_TAKEEXAM_PATIENTS_PATIENTID FOREIGN KEY(PatientId) REFERENCES dbo.Patients(PatientId),
	CONSTRAINT FK_TAKEEXAM_MEDICS_MEDICID FOREIGN KEY(MedicId) REFERENCES dbo.Medics(MedicId)
)
INSERT INTO dbo.TakeExam
	(
		PatientId,
		MedicId
	)
VALUES
	(
		1,
		1
	)
GO
CREATE TABLE dbo.TakeExamDetail
(
	TakeExamDetailId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TakeExamId INT  NOT NULL,
	ExamId INT NOT NULL,
	MedicId INT NOT NULL,
	AnalysisId INT NOT NULL,	
)
/*****************************************
--STORE PROCEDURES
*******************************************/

ALTER PROCEDURE dbo.SP_GET_ANALYSIS_LIST
(
	@PageNumber INT,
	@PageSize INT
)
AS
BEGIN
	SELECT
		AnalysisId
		,Name
		,CreatedDate
		,State
	FROM dbo.Analysis
	ORDER BY AnalysisId
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
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
(
	@PageNumber INT,
	@PageSize INT
)
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
	ORDER BY E.ExamId
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
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
go
CREATE PROCEDURE dbo.SP_GET_PATIENT_LIST
(
	@PageNumber INT,
	@PageSize INT
)
AS
BEGIN
	SELECT P.PatientId
		,P.Names
		,P.LastName
		,SurNames = P.LastName + ' ' + P.MotherMaidenName
		,DocumentType = DT.Document
		,P.DocumentNumber
		,P.Phone
		,Age = cast(P.Age as varchar) + ' '+ TA.TypeAge
		,G.Gender
		,StatePatient = CASE WHEN P.State = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END
		,P.CreatedDate
	FROM dbo.Patients P
	INNER JOIN dbo.DocumentTypes DT
		ON P.DocumentTypeId = DT.DocumentTypeId
	INNER JOIN dbo.TypeAges TA
		ON P.TypeAgeId = TA.TypeAgeId
	INNER JOIN dbo.Genders G
		ON P.GenderId = G.GenderId
	ORDER BY P.PatientId
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
go
CREATE PROCEDURE dbo.SP_GET_PATIENT_BY_ID
(
	@PatientId INT
)
AS
BEGIN
	SELECT P.PatientId
		,P.Names
		,P.LastName
		,P.MotherMaidenName
		,P.DocumentTypeId
		,P.DocumentNumber
		,P.Phone
		,P.TypeAgeId
		,P.Age
		,P.GenderId
	FROM dbo.Patients P
	WHERE PatientId = @PatientId
END
GO
CREATE PROCEDURE dbo.SP_PATIENT_REGISTER
(
	@Names VARCHAR(100),
	@LastName VARCHAR(50),
	@MotherMaidenName VARCHAR(50),
	@DocumentTypeId INT,
	@DocumentNumber VARCHAR(25),
	@Phone VARCHAR(15),
	@TypeAgeId INT,
	@Age INT,
	@GenderId INT
)
AS
BEGIN
	INSERT INTO dbo.Patients
		(
			Names
			,LastName
			,MotherMaidenName
			,DocumentTypeId
			,DocumentNumber
			,Phone
			,TypeAgeId
			,Age
			,GenderId
		)
	VALUES
		(
			@Names
			,@LastName
			,@MotherMaidenName
			,@DocumentTypeId
			,@DocumentNumber
			,@Phone
			,@TypeAgeId
			,@Age
			,@GenderId
		)
END
go
CREATE PROCEDURE dbo.SP_PATIENT_EDIT
(
	@PatientId INT
	,@Names VARCHAR(100)
	,@LastName VARCHAR(50)
	,@MotherMaidenName VARCHAR(50)
	,@DocumentTypeId INT
	,@DocumentNumber VARCHAR(25)
	,@Phone VARCHAR(15)
	,@TypeAgeId INT
	,@Age INT
	,@GenderId INT
)
AS
BEGIN
	UPDATE dbo.Patients
	SET Names = @Names
		,LastName = @LastName
		,MotherMaidenName = @MotherMaidenName
		,DocumentTypeId = @DocumentTypeId
		,DocumentNumber = @DocumentNumber
		,Phone = @Phone
		,TypeAgeId = @TypeAgeId
		,Age = @Age
		,GenderId = @GenderId
	WHERE PatientId = @PatientId
END
GO
CREATE PROCEDURE dbo.SP_PATIENT_REMOVE
(
	@PatientId INT
)
AS
BEGIN
	DELETE FROM dbo.Patients
	WHERE PatientId = @PatientId
END
go
CREATE PROCEDURE dbo.SP_CHANGE_PATIENT_STATE
(
	@PatientId INT,
	@State INT
)
AS
BEGIN
	UPDATE dbo.Patients
	SET State = @State
	WHERE PatientId = @PatientId
END
GO
CREATE PROCEDURE dbo.SP_GET_MEDIC_LIST
(
	@PageNumber INT,
	@PageSize INT
)
AS
BEGIN
	SELECT M.MedicId
		,M.Names
		,Surnames = M.LastName + ' ' + M.MotherMaidenName
		,Specialty = S.Name
		,DocumentType =  DT.Document
		,M.DocumentNumber
		,M.Address
		,M.Phone
		,M.BirthDate
		,StateMedic = CASE WHEN M.State = 1 then 'ACTIVO' ELSE 'INACTIVO' END
		,M.CreatedDate
	FROM dbo.Medics M
	INNER JOIN dbo.DocumentTypes DT
		ON M.DocumentTypeId = DT.DocumentTypeId
	INNER JOIN dbo.Specialties S
		ON M.SpecialtyId = S.SpecialtyId
	ORDER BY M.MedicId
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO
CREATE PROCEDURE dbo.SP_GET_MEDIT_BY_ID
(
	@MedicId INT
)
AS
BEGIN
	SELECT MedicId
		,Names
		,LastName
		,MotherMaidenName
		,Address
		,Phone
		,BirthDate
		,DocumentTypeId
		,DocumentNumber
		,SpecialtyId
	FROM dbo.Medics
	WHERE MedicId = @MedicId
END
go
CREATE PROCEDURE dbo.SP_MEDIC_REGISTER
(
	@Names VARCHAR(100)
	,@LastName VARCHAR(100)
	,@MotherMaidenName VARCHAR(100)
	,@Address VARCHAR(255)
	,@Phone VARCHAR(15)
	,@BirthDate DATE
	,@DocumentTypeId INT
	,@DocumentNumber VARCHAR(25)
	,@SpecialtyId INT
)
AS
BEGIN
	INSERT INTO dbo.Medics
		(
			Names
			,LastName
			,MotherMaidenName
			,Address
			,Phone
			,BirthDate
			,DocumentTypeId
			,DocumentNumber
			,SpecialtyId
		)
	VALUES
		(
			@Names
			,@LastName
			,@MotherMaidenName
			,@Address
			,@Phone
			,@BirthDate
			,@DocumentTypeId
			,@DocumentNumber
			,@SpecialtyId
		)
END
go

CREATE PROCEDURE dbo.SP_MEDIC_EDIT
(
	@MedicId INT
	,@Names VARCHAR(100)
	,@LastName VARCHAR(100)
	,@MotherMaidenName VARCHAR(100)
	,@Address VARCHAR(255)
	,@Phone VARCHAR(15)
	,@BirthDate DATE
	,@DocumentTypeId INT
	,@DocumentNumber VARCHAR(25)
	,@SpecialtyId INT
)
AS
BEGIN
	UPDATE dbo.Medics
	SET	Names = @Names
		,LastName = @LastName
		,MotherMaidenName = @MotherMaidenName
		,Address = @Address
		,Phone = @Phone
		,BirthDate = @BirthDate
		,DocumentTypeId = @DocumentTypeId
		,DocumentNumber = @DocumentNumber
		,SpecialtyId = @SpecialtyId
	WHERE MedicId = @MedicId
END
GO

CREATE PROCEDURE dbo.SP_MEDIC_REMOVE
(
	@MedicId INT
)
AS
BEGIN
	DELETE FROM dbo.Medics
	WHERE MedicId = @MedicId
END
go
CREATE PROCEDURE dbo.SP_CHANGE_STATE_MEDIC
(
	@MedicId INT,
	@State INT
)
AS
BEGIN
	UPDATE dbo.Medics
	SET State = @State
	WHERE MedicId = @MedicId
END
go
CREATE PROCEDURE dbo.SP_GET_TAKEEXAM_LIST
(
	@PageNumber INT,
	@PageSize INT
)
AS
BEGIN
	SELECT TE.TakeExamId
		,Patient = P.LastName + ' ' + p.MotherMaidenName + ' ' + p.Names
		,Medic = M.LastName + ' ' + M.MotherMaidenName + ' ' + M.Names
		,StateTakeExam =(
							CASE TE.State
								WHEN 1 THEN 'FINALIZADO'
							ELSE 'PENDIENTE' END
						)
		,TE.CreatedDate
	FROM dbo.TakeExam TE
	INNER JOIN dbo.Patients P
		ON TE.PatientId = P.PatientId
	INNER JOIN dbo.Medics M
		ON TE.MedicId = M.MedicId
	ORDER BY TE.TakeExamId
	OFFSET (@PageNumber -1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE TABLE dbo.TakeExamDetail
(
	TakeExamDetailId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TakeExamId INT  NOT NULL,
	ExamId INT NOT NULL,
	MedicId INT NOT NULL,
	AnalysisId INT NOT NULL,	
)
INSERT INTO dbo.TakeExamDetail
	(
		TakeExamId,
		ExamId,
		MedicId,
		AnalysisId
	)
VALUES
	(
		1,
		1,
		1,
		1
	)
/*****************************************
--TEST STORE PROCEDURES
*******************************************/
EXEC dbo.SP_GET_ANALYSIS_LIST 1, 2
EXEC dbo.SP_GET_ANALYSIS_LIST 2, 2
EXEC dbo.SP_GET_ANALYSIS_LIST_BY_ID 1
EXEC dbo.GET_EXAMS_LIST 1, 2
EXEC dbo.SP_GET_MEDIC_LIST 1,2
EXEC dbo.SP_GET_MEDIC_LIST 2,2
EXEC dbo.SP_GET_EXAM_BY_ID 1
EXEC dbo.SP_GET_PATIENT_BY_ID 1
EXEC dbo.SP_GET_PATIENT_LIST 2,2
EXEC dbo.SP_GET_MIDIC_LIST
EXEC dbo.SP_GET_MEDIT_BY_ID 1
EXEC dbo.SP_GET_TAKEEXAM_LIST 1, 10