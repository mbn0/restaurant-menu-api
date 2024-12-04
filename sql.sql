CREATE TABLE Catagories (
  Cat_ID int identity(1,1) PRIMARY KEY,
  Cat_Name nvarchar(255),
  Cat_Image varbinary(max)
);

CREATE TABLE Products (
  Id int identity(1,1) PRIMARY KEY
  Name nvarchar(255)
  price decimal(10,2) not null
  Image varbinary(max)
  Available boolean bit not null default 1
);

ALTER TABLE Products
ADD Cat_ID int;

Alter table Products
add constraint FK_Product_Categories
foreign key (Cat_ID) references Categories(Cat_ID)
ON update cascade ;
