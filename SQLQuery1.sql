CREATE DATABASE REGISTRO_CLIENTES

USE REGISTRO_CLIENTES

-- crear tabla clientes--
CREATE TABLE Clientes(
    cedula int primary key,
    nombre varchar(50),
    direcci�n varchar(50),
    correo varchar(50),
    id_categor�a int,
    FOREIGN KEY (id_categor�a) REFERENCES Categoria(id_categor�a)
);

-- crear tabla categoria
CREATE TABLE Categoria(

id_categor�a int primary key,
descripci�n varchar(50),

 );

 -- insertar datos--
 Insert into Clientes values(102036659,'elios','callebonita#69-89','elios123@gmail.com',1);
 Insert into Clientes values(102036956,'ares','callefea#69-89','ares123@gmail.com',1);
 Insert into Categoria values(1,'Persona Natural');
 Insert into Categoria values(2,'Persona Juridica');

 Select * from Clientes
 Select * from Categoria


 --consulta para ver a que categoria pertenece el cliente--
 SELECT clientes.*, cat.descripci�n AS categoria
FROM Clientes clientes
JOIN Categoria cat ON clientes.id_categor�a = cat.id_categor�a;
