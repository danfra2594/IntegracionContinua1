CREATE DATABASE INVENTARIO
GO
USE INVENTARIO
GO

CREATE TABLE Bodega
(
	IdBodega int primary key identity(1,1),
	Descripcion varchar(50) not null,
	Estado bit not null default 1,
	Fecha datetime default getdate()
)
GO
Create table Producto
(
	IdProducto int primary key identity(1,1),
	Descripcion varchar(50) not null,
	Estado bit not null default 1,
	Fecha datetime default getdate(),
	Foto varchar(max),
	CostoCompra float,
	CostoVenta float,
	CantidadDisponible int,
	IdBodega int not null,
	Foreign key (IdBodega) references Bodega(IdBodega)
)
GO
Create table Usuario
(
	IdUsuario int primary key identity(1,1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Direccion varchar(200) not null,
	Email varchar(100) not null,
	Estado bit not null default 1,
	Fecha datetime default getdate(),
	Rol varchar(50) not null
)
go
Create table VentaEncabezado
(
	IdVentaEncabezado int primary key identity(1,1),
	Fecha datetime default getdate(),
	Cliente varchar(200),
	Estado bit not null default 1,
	MedioPago varchar(100),
	CostoTotal float not null,
	IdUsuario int not null,
	Foreign key (IdUsuario) references Usuario(IdUsuario)
)
go
Create table VentaDetalle
(
	IdVentaDetalle int primary key identity(1,1),
	Fecha datetime default getdate(),
	Valor float not null,
	Estado bit not null default 1,
	IdProducto int not null,
	IdVentaEncabezado int not null,
	Foreign key (IdProducto) references Producto(IdProducto),
	Foreign key (IdVentaEncabezado) references VentaEncabezado(IdVentaEncabezado)
)

