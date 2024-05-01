CREATE TABLE Department (
    DeptName VARCHAR(255) constraint pk_deptname PRIMARY KEY,
    Floor INT,
    PhoneNumber VARCHAR(20),
    MgrId INT NOT NULL constraint fk_MgrId references Employee(EmpNo),
);
