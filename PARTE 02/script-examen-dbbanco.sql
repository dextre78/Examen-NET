/* 
Creamos una base y sus objetos respectivos
*/

CREATE DATABASE ExamenNet;
go
use  ExamenNet;
go

CREATE SEQUENCE Seq_banco  
AS bigint
START WITH 1   
INCREMENT BY 1    
GO

CREATE SEQUENCE Seq_sucursal
AS bigint
START WITH 1   
INCREMENT BY 1    
GO

CREATE SEQUENCE Seq_ordenPago 
AS bigint
START WITH 1   
INCREMENT BY 1    
GO

CREATE TABLE [dbo].[Banco](
	[id_banco] bigint default (NEXT VALUE FOR Seq_banco),
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[FechaRegistro] [datetime] NULL
)
GO

CREATE TABLE [dbo].[OrdenPago](
	[id_OrdenPago] bigint default (NEXT VALUE FOR Seq_ordenPago),
	[id_sucursal] [bigint] NULL,
	[Monto] [decimal](18, 0) NULL,
	[Moneda] [char](10) NULL,
	[Estado] [char](10) NULL,
	[FechaPago] [datetime] NULL
) 

GO

CREATE TABLE [dbo].[Sucursal](
	[id_sucursal] bigint default (NEXT VALUE FOR Seq_sucursal),
	[id_banco] [bigint] NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[FechaRegistro] [datetime] NULL
)
go	

create proc [dbo].[sp_delete_banco]
@id_banco bigint 
as
begin
	delete from Banco where id_banco  = @id_banco
end
GO

create proc [dbo].[sp_delete_sucursal]
@id_sucursal bigint 
as
begin
	delete from Sucursal where id_sucursal = @id_sucursal
end
GO

CREATE proc [dbo].[sp_edit_banco]
@id_banco bigint, 
@Nombre varchar(50), 
@Direccion varchar(50) 
as
begin
	update Banco set Nombre = @Nombre, Direccion = @Direccion
	where id_banco = @id_banco
end
GO

CREATE proc [dbo].[sp_edit_ordenPago]
@id_OrdenPago bigint, 
@id_sucursal bigint, 
@Monto money, 
@Moneda char(10), 
@Estado varchar(11)
as
begin
	update OrdenPago set
	Monto = @Monto, Moneda = @Moneda, Estado = @Estado
	where id_OrdenPago = @id_OrdenPago and id_sucursal = @id_sucursal
end

GO
create proc [dbo].[sp_edit_sucursal]
@id_sucursal bigint, 
@id_banco bigint, 
@Nombre varchar(50), 
@Direccion varchar(50), 
@FechaRegistro datetime
as
begin
	update Sucursal set 
			id_banco = @id_banco,
			Nombre = @Nombre, 
			Direccion = @Direccion, 
			FechaRegistro = @FechaRegistro
	where id_sucursal = @id_sucursal
end

GO
create proc [dbo].[sp_find_banco]
@id_banco bigint
as
begin
	select id_banco, Nombre, Direccion, FechaRegistro from Banco
	where id_banco = @id_banco
end
GO

create proc [dbo].[sp_find_ordenPago]
@id_OrdenPago bigint
as
begin
	select 
	o.id_OrdenPago, o.id_sucursal, o.Monto, o.Moneda, o.Estado, o.FechaPago
	from OrdenPago o inner join Sucursal s on o.id_sucursal = s.id_sucursal
	where o.id_OrdenPago = @id_OrdenPago
end
GO

CREATE proc [dbo].[sp_find_ordenPago_byMoneda]
@Moneda char(10)
as
begin
	select 
	o.id_OrdenPago, o.id_sucursal, o.Monto, o.Moneda, o.Estado, o.FechaPago, b.Nombre as Banco
	from OrdenPago o inner join Sucursal s on o.id_sucursal = s.id_sucursal
					inner join Banco b on s.id_banco = b.id_banco
	where o.Moneda = @Moneda
end
GO

CREATE proc [dbo].[sp_find_sucursal]
@id_sucursal bigint
as
begin
	select id_sucursal, id_banco, Nombre, Direccion, FechaRegistro from Sucursal
	where id_sucursal = @id_sucursal
end
GO

CREATE proc [dbo].[sp_find_sucursal_byBanco]
@Nombre varchar(50)
as
begin
	select 
		s.id_sucursal, s.id_banco, b.Nombre as banco, s.Nombre, s.Direccion, s.FechaRegistro
	from Sucursal s inner join Banco b on s.id_banco = b.id_banco
	where (@Nombre = '-1' or b.Nombre = @Nombre)
end
GO
create proc [dbo].[sp_findAll_banco]
as
select id_banco, Nombre, Direccion, FechaRegistro from Banco
GO

CREATE proc [dbo].[sp_findAll_ordenPago]
@NombreBanco varchar(50),
@NombreSucursal varchar(50)
as
begin
	select 
		op.id_OrdenPago, op.id_sucursal, op.Monto, op.Moneda, op.Estado, op.FechaPago,
		b.Nombre as banco, s.Nombre	as Sucursal
	from OrdenPago op 
		inner join Sucursal s on op.id_sucursal = s.id_sucursal
		inner join Banco b on s.id_banco = b.id_banco
	where (@NombreBanco = '-1' or  b.Nombre like @NombreBanco + '%') and (@NombreSucursal = '-1' or s.Nombre like @NombreSucursal + '%')
end    
GO

create proc [dbo].[sp_findAllById_sucursal]
@id_sucursal bigint
as
begin
	select 
		s.id_sucursal, s.id_banco, s.Nombre, s.Direccion, s.FechaRegistro
	from Sucursal s 
	where s.id_sucursal = @id_sucursal
end
GO

CREATE proc [dbo].[sp_insert_banco]
@Nombre varchar(50), 
@Direccion varchar(50) 
as
begin
	insert into Banco (Nombre, Direccion, FechaRegistro) values (@Nombre, @Direccion, GETDATE())
end

GO

CREATE proc [dbo].[sp_insert_ordenPago]
@id_sucursal bigint, 
@Monto money, 
@Moneda char(10), 
@Estado varchar(11)
as
	insert into OrdenPago(id_sucursal, Monto, Moneda, Estado, FechaPago) values (@id_sucursal, @Monto, @Moneda, @Estado, GETDATE())
GO

CREATE proc [dbo].[sp_insert_sucursal]
@id_banco bigint,
@Nombre varchar(50), 
@Direccion varchar(50)
as
begin
	insert into Sucursal(id_banco, Nombre, Direccion, FechaRegistro) values (@id_banco, @Nombre, @Direccion, getdate())
end

GO
