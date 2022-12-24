DROP TABLE IF EXISTS OrderDetails cascade;
DROP TABLE IF EXISTS Orders cascade;
DROP TABLE IF EXISTS Customers cascade;
DROP TABLE IF EXISTS Products cascade;
DROP TABLE IF EXISTS Categories cascade;
Drop TABLE IF EXISTS Shippers cascade;
Drop Table If EXISTS Addresses cascade;
Drop Table If EXISTS multicategories cascade;
Drop Table If EXISTS status cascade;

CREATE TABLE Products(
	"ProductId" serial PRIMARY KEY NOT NULL,
	"ProductName" character varying(15) NOT NULL,
	"CategoryId" smallint not null,
	"SupplierId" text NOT NULL,
	"UnitPrice" numeric(18,2)  NOT NULL,
	"UnitsInStock" SMALLINT NOT NULL,
	"UnitsOnOrder" SMALLINT,
	"ImageUrl" text
);
create TABLE Categories(
	"CategoryId" serial PRIMARY KEY NOT NULL,
	"CategoryName" character varying(15) NOT NULL
);
/*create Table multicategories(
	"CategoryId" smallint not null,
	"ProductId"  smallint not null,
	constraint pk_multi primary key("CategoryId","ProductId")
);*/
CREATE TABLE Customers(
	"CustomerId" text PRIMARY key	NOT NULL,
	"FirstName" character varying(15) NOT NULL,
	"LastName" character varying(15) NOT NULL,
	"Phone" character varying(15) NOT NULL
);
Create TABLE Orders(
	"OrderId" serial PRIMARY key not null,
	"CustomerId" text NOT NULL,
	"ShipperId" smallint NOT NULL,
	"OrderDate" text,
	"RequiredDate" text,
	"AddressId" int not null,
	"Total" numeric(18,2) not null,
	"StatusId" smallint not null default 1
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
Create Table Addresses(
 "AddressId" serial primary key not null,
 "AddressTitle" text not null,
 "Address" text not null,
 "City" character varying(15) NOT NULL,
 "County" character varying(15) NOT NULL,
 "Country" character varying(15) NOT NULL,
 "CustomerId" text
);
Create Table Status(
	"StatusId" serial PRIMARY key not null,
	"StatusName" text not null
);

Alter Table Addresses
    add constraint fk_address_customer foreign key ("CustomerId") REFERENCES Customers("CustomerId");
	
Alter TABLE Products
	add constraint fk_product_suppliers FOREIGN key ("SupplierId") REFERENCES Customers("CustomerId");
Alter Table products
	add constraint fk_product_category FOREIGN key ("CategoryId") REFERENCES Categories("CategoryId");

alter TABLE OrderDetails
	add constraint fk_orderDetails_product FOREIGN key ("ProductId") REFERENCES Products("ProductId") ON DELETE CASCADE;
alter TABLE OrderDetails
	add constraint fk_orderDetails_order FOREIGN key ("OrderId") REFERENCES Orders("OrderId");

alter TABLE Orders
	add constraint fk_order_cutomer FOREIGN key ("CustomerId") REFERENCES Customers("CustomerId");
alter TABLE Orders
	add constraint fk_order_shippers FOREIGN key ("ShipperId") REFERENCES Shippers("ShipperId");
alter TABLE Orders
	add constraint fk_order_address FOREIGN key ("AddressId") REFERENCES Addresses("AddressId");
alter TABLE Orders
	add constraint fk_order_status FOREIGN key ("StatusId") REFERENCES Status("StatusId");
/*alter TABLE multicategories
	add constraint fk_MultiCategory_product FOREIGN key ("ProductId") REFERENCES Products("ProductId");
alter TABLE multicategories
	add constraint fk_MultiCategory_category FOREIGN key ("CategoryId") REFERENCES Categories("CategoryId");*/


INSERT INTO categories VALUES (1, 'Beverages');
INSERT INTO categories VALUES (2, 'Condiments');
INSERT INTO categories VALUES (3, 'Confections');
INSERT INTO categories VALUES (4, 'Dairy Products');
INSERT INTO categories VALUES (5, 'Grains/Cereals');
INSERT INTO categories VALUES (6, 'Meat/Poultry');
INSERT INTO categories VALUES (7, 'Produce');
INSERT INTO categories VALUES (8, 'Seafood');
INSERT INTO shippers VALUES (1,'Aras Kargo');
INSERT INTO Status VALUES (1,'InProgres');
INSERT INTO Status VALUES (2,'IsCanceled');
INSERT INTO Status VALUES (3,'Done');

CREATE OR REPLACE VIEW public."TopCustomerForTopProduct"
 AS
 SELECT customers."CustomerId",
    customers."FirstName",
    customers."LastName",
    products."ProductName"
   FROM customers
     JOIN orders ON orders."CustomerId" = customers."CustomerId"
     JOIN orderdetails ON orderdetails."OrderId" = orders."OrderId"
     JOIN products ON products."ProductId" = orderdetails."ProductId"
  GROUP BY customers."CustomerId", customers."FirstName", customers."LastName", products."ProductName"
  ORDER BY (sum(orderdetails."Quantity")) DESC
 LIMIT 1;

ALTER TABLE public."TopCustomerForTopProduct"
    OWNER TO postgres;



















