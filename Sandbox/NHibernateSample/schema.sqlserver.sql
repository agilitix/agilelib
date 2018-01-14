
if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_order_customer]') AND parent_object_id = OBJECT_ID('ta_orders'))
begin
   alter table ta_orders  drop constraint FK_order_customer
end

if exists (select * from dbo.sysobjects where id = object_id(N'ta_customers') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
   drop table ta_customers
end

if exists (select * from dbo.sysobjects where id = object_id(N'ta_orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
   drop table ta_orders
end

create table ta_customers
(
   Id BIGINT IDENTITY NOT NULL,
   name NVARCHAR(255) null,
   primary key (Id)
)

create table ta_orders
(
   Id BIGINT IDENTITY NOT NULL,
   customer_id BIGINT null,
   quantity INT null,
   primary key (Id)
)

alter table ta_orders
   add constraint FK_order_customer
   foreign key (customer_id)
   references ta_customers
