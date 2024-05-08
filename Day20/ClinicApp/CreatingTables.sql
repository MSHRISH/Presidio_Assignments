CREATE DATABASE Clinic;
use clinic
CREATE TABLE doctors (
    DoctorId INT PRIMARY KEY,
    DoctorName VARCHAR(100),
    Age INT,
    DateOfBirth DATE,
    ServiceYears INT
);

CREATE TABLE patients (
    PatientId INT PRIMARY KEY,
    PatientName VARCHAR(100),
    Gender VARCHAR(10),
    Age INT,
    DateOfBirth DATE
);

CREATE TABLE appointments (
    AppointmentID INT PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    FOREIGN KEY (PatientId) REFERENCES patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES doctors(DoctorId)
);



INSERT INTO doctors (DoctorId, DoctorName, Age, DateOfBirth, ServiceYears) VALUES
(101, 'Dr. Smith', 35, '1989-05-15', 10),
(102, 'Dr. Johnson', 40, '1984-10-20', 15),
(103, 'Dr. Lee', 45, '1979-03-25', 20);

INSERT INTO patients (PatientId, PatientName, Gender, Age, DateOfBirth) VALUES
(101, 'John Doe', 'Male', 30, '1994-05-10'),
(102, 'Jane Smith', 'Female', 25, '1999-02-15'),
(103, 'Michael Johnson', 'Male', 45, '1979-11-20');


INSERT INTO appointments (AppointmentID, PatientId, DoctorId, AppointmentDate, AppointmentTime) VALUES
(1, 101, 101, '2024-05-10', '10:00'),
(2, 102, 102, '2024-05-15', '11:00'),
(3, 103, 103, '2024-05-20', '14:00');

select * from doctors;
select * from patients;
select * from appointments;
