-- initial script for creating the Coupon table for postgresql

CREATE TABLE Coupon(
	ID SERIAL PRIMARY KEY NOT NULL,
	ProductName VARCHAR(50) NOT NULL,
	Description TEXT,
	Amount INT
);

-- Add some data to the table
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Iphone X', 'IPhone discount coupon', 150);
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Samsung', 'Samsung discount coupon', 100);