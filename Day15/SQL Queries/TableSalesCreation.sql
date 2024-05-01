CREATE TABLE Sales (
    SalesNo INT PRIMARY KEY,
    SaleQty INT,
    ItemName VARCHAR(100) NOT NULL constraint fk_ItemName foreign key references Item(ItemName),
    DeptName VARCHAR(100) NOT NULL constraint fk_Deptname foreign key references Department(Deptname)
);
