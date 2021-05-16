DROP TABLE product

CREATE TABLE product(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name VARCHAR(25),
    Type CHAR(20),
    Price SMALLMONEY,
    Quantity INT,
    ModifiedDate DATETIME
)   

INSERT INTO dbo.product
   ([Name],[Type],[Price],[Quantity],[ModifiedDate])
VALUES
   ('Surface', 'Laptop', 150000, 1, GETDATE()),
   ('Diary Milk Silk', 'Choclate', 100, 5, GETDATE()),
   ('RE Classic 350', 'Bike', 200000, 1, GETDATE()),
   ('Parker', 'Pen', 250.49, 1, GETDATE())
GO

SELECT * FROM product


