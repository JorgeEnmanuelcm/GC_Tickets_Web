Create database GCTicketsWebDB

use GCTicketsWebDB

Create table Usuarios(
UsuarioId int primary key identity(1,1),
Nombres varchar(18),
Apellidos varchar(18),
Telefono varchar(15),
Email varchar(32),
Direccion varchar(32),
NombreUsuario varchar(12),
Contrasenia varchar(32),
TipoUsuario int
)

create table TipoEvento(
TipoEventoId int primary key identity(1,1),
Descripcion varchar(26)
)

create table Eventos(
EventoId int primary key identity(1,1),
TipoEventoId int,
NombreEvento varchar(32),
FechaEvento varchar(12),
LugarEvento varchar(32),
Imagen varchar(280)
)

create table EventosDetalle(
Id int primary key identity(1,1),
EventoId int,
DescTicket varchar(16),
CantDisponible int,
PrecioTicket int
)

--create table Ventas()
