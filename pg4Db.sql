DROP TABLE IF EXISTS OrderDetails cascade;
DROP TABLE IF EXISTS Orders cascade;
DROP TABLE IF EXISTS Customers cascade;
DROP TABLE IF EXISTS Products cascade;
DROP TABLE IF EXISTS Categories cascade;
Drop TABLE IF EXISTS Shippers cascade;

CREATE TABLE Products(
	"ProductId" serial PRIMARY KEY NOT NULL,
	"ProductName" character varying(15) NOT NULL,
	"SupplierId" text NOT NULL,
	"CategoryId" SMALLINT NOT NULL,
	"UnitPrice" money  NOT NULL,
	"UnitsInStock" SMALLINT NOT NULL,
	"UnitsOnOrder" SMALLINT,
	"Discount" NUMERIC DEFAULT 0
);
create TABLE Categories(
	"CategoryId" serial PRIMARY KEY NOT NULL,
	"CategoryName" character varying(15) NOT NULL
);
CREATE TABLE Customers(
	"CustomerId" text PRIMARY key	NOT NULL,
	"FirstName" character varying(15) NOT NULL,
	"LastName" character varying(15) NOT NULL,
	"Address" text NOT NULL,
	"City" character varying(15) NOT NULL,
	"County" character varying(15) NOT NULL,
	"Country" character varying(15) NOT NULL,
	"Phone" character varying(15) NOT NULL
);
Create TABLE Orders(
	"OrderId" serial PRIMARY key not null,
	"CustomerId" text NOT NULL,
	"ShipperId" smallint NOT NULL,
	"OrderDate" text,
	"RequiredDate" text,
	"ShipAddress" text NOT NULL,
	"ShipCity" character varying(15) NOT NULL,
	"Total" money not null,
	"IsProgress" BOOLEAN DEFAULT True,
	"IsCanceled" BOOLEAN DEFAULT False
);
CREATE TABLE OrderDetails(
	"OrderId" smallint NOT NULL ,
	"ProductId" SMALLINT NOT NULL ,
    "Quantity" SMALLINT NOT NULL,
	constraint pk_od primary key("OrderId","ProductId")
);
Create TABLE Shippers(
	"ShipperId" serial primary key NOT NULL,
	"CompanyName" character varying(25) NOT NULL
);
Alter TABLE Products
	add constraint fk_product_category FOREIGN key ("CategoryId") REFERENCES Categories("CategoryId");
Alter TABLE Products
	add constraint fk_product_suppliers FOREIGN key ("SupplierId") REFERENCES Customers("CustomerId");

alter TABLE OrderDetails
	add constraint fk_orderDetails_product FOREIGN key ("ProductId") REFERENCES Products("ProductId");
alter TABLE OrderDetails
	add constraint fk_orderDetails_order FOREIGN key ("OrderId") REFERENCES Orders("OrderId");

alter TABLE Orders
	add constraint fk_order_cutomer FOREIGN key ("CustomerId") REFERENCES Customers("CustomerId");
alter TABLE Orders
	add constraint fk_order_shippers FOREIGN key ("ShipperId") REFERENCES Shippers("ShipperId");

INSERT INTO categories VALUES (1, 'Beverages');
INSERT INTO categories VALUES (2, 'Condiments');
INSERT INTO categories VALUES (3, 'Confections');
INSERT INTO categories VALUES (4, 'Dairy Products');
INSERT INTO categories VALUES (5, 'Grains/Cereals');
INSERT INTO categories VALUES (6, 'Meat/Poultry');
INSERT INTO categories VALUES (7, 'Produce');
INSERT INTO categories VALUES (8, 'Seafood');
INSERT INTO shippers VALUES (1,'Aras Kargo');



















