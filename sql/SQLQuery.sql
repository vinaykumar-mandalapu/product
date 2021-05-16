CREATE TABLE t_products(
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    name VARCHAR(25),
    type CHAR(20),
    price SMALLMONEY,
    quantity INT,
    modified_date DATETIME
)   

SELECT * FROM t_products

INSERT INTO dbo.t_products
   ([name],[type],[price],[quantity],[modified_date])
VALUES
   ('Surface', 'Laptop', 150000, 1, GETDATE()),
   ('Diary Milk Silk', 'Choclate', 100, 5, GETDATE()),
   ('RE Classic 350', 'Bike', 200000, 1, GETDATE()),
   ('Parker', 'Pen', 250, 1, GETDATE())
GO
