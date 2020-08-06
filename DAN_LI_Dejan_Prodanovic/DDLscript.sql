--we create database  
CREATE DATABASE MedicalData
;
GO

use MedicalData

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblPatient;
DROP TABLE IF EXISTS tblDoctor;
DROP TABLE IF EXISTS tblRequest;

 
CREATE TABLE tblDoctor (
    DoctorID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50),
	LastName varchar(50),
	JMBG varchar(50),
    CurrentAccountNumber varchar(50),
    UserName varchar(50),
	Passwd varchar(50)

	
);

CREATE TABLE tblPatient (
    PatientID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FullName varchar(50),
	JMBG varchar(50),
	InsuranceCardNumber varchar(50),
    UserName varchar(50),
	Passwd varchar(50),
	DoctorID int FOREIGN KEY REFERENCES tblDoctor(DoctorID) 

	
); 


CREATE TABLE tblRequest (
    RequestID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    DateOfRequest date,
	ReasonOfRequest varchar(300),
	CompanyName varchar(50),
	EmergencyReq bit,
	PatientID int FOREIGN KEY REFERENCES tblPatient(PatientID),
	DoctorID int FOREIGN KEY REFERENCES tblDoctor(DoctorID) 

); 

GO
CREATE VIEW vwPatientRequest
AS
SELECT  dbo.tblPatient.FullName, dbo.tblPatient.JMBG, dbo.tblPatient.InsuranceCardNumber,
        dbo.tblRequest.DateOfRequest, 
        dbo.tblRequest.ReasonOfRequest, 
        dbo.tblRequest.CompanyName, dbo.tblRequest.EmergencyReq,dbo.tblPatient.PatientID,
		dbo.tblRequest.RequestID
FROM    dbo.tblPatient INNER JOIN
            dbo.tblRequest ON dbo.tblPatient.PatientID = dbo.tblRequest.PatientID
GO

 