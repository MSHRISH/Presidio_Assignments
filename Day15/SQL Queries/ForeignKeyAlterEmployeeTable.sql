ALTER TABLE Employee
ADD CONSTRAINT fk_emp_dept FOREIGN KEY (Deptname) REFERENCES Department(deptname);