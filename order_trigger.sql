CREATE or REPLACE FUNCTION reduce_quantity() 
  RETURNS TRIGGER 
as $$
begin
   update products pr
       set "UnitsInStock" = "UnitsInStock" - od."Quantity",
           "UnitsOnOrder" = "UnitsOnOrder" - od."Quantity"
   from orderdetails od
   where od."ProductId" = pr."ProductId"
     and od."OrderId" = new."OrderId";
   return new;
end;
$$
language plpgsql;

create or replace trigger is_done
   after update on orders 
   for each row
   when (new."StatusId" = 1 and old."StatusId" = 3)
   execute procedure reduce_quantity();
----------------------------------------------------------------------------------------------------------

   CREATE or REPLACE FUNCTION order_canceled() 
  RETURNS TRIGGER 
as $$
begin
   update products pr
       set  "UnitsOnOrder" = "UnitsOnOrder" - od."Quantity"
   from orderdetails od
   where od."ProductId" = pr."ProductId"
     and od."OrderId" = new."OrderId";
   return new;
end;
$$
language plpgsql;

create or replace trigger orders_canceled_trigger
   after update on orders 
   for each row
   when (new."StatusId" = 1 and old."StatusId" = 2)
   execute procedure order_canceled();
----------------------------------------------------------------------------------------------------------
   create or replace function UnitsOnOrder_Increase() returns trigger
   as $$
   begin
   update products set "UnitsOnOrder" = "UnitsOnOrder" + new."Quantity" where "ProductId"=new."ProductId";
   return new;
   end;
   $$
language plpgsql;

create or replace trigger UnitsOnOrder_Increase_trigger
after insert on orderdetails
for each row
execute procedure UnitsOnOrder_Increase();
----------------------------------------------------------------------------------------------------------
Create Or Replace Procedure Is_Done(OrderID orders."OrderId"%type)
LANGUAGE SQL
as $$
update orders set "StatusId" = 3 where "OrderId"=OrderID;
$$;

Create Or Replace Procedure Is_Canceled(OrderID orders."OrderId"%type)
LANGUAGE SQL
as $$
update orders set "StatusId" = 2 where "OrderId"=OrderID;
$$;
