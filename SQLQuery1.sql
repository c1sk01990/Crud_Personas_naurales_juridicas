CREATE DATABASE REGISTRO_CLIENTES

USE REGISTRO_CLIENTES

-- crear tabla clientes--
CREATE TABLE Clientes(
    cedula int primary key,
    nombre varchar(50),
    dirección varchar(50),
    correo varchar(50),
    id_categoría int,
    FOREIGN KEY (id_categoría) REFERENCES Categoria(id_categoría)
);

-- crear tabla categoria
CREATE TABLE Categoria(

id_categoría int primary key,
descripción varchar(50),

 );

 -- insertar datos--
 Insert into Clientes values(102036659,'elios','callebonita#69-89','elios123@gmail.com',1);
 Insert into Clientes values(102036956,'ares','callefea#69-89','ares123@gmail.com',1);
 Insert into Categoria values(1,'Persona Natural');
 Insert into Categoria values(2,'Persona Juridica');

 Select * from Clientes
 Select * from Categoria


 --consulta para ver a que categoria pertenece el cliente--
 SELECT clientes.*, cat.descripción AS categoria
FROM Clientes clientes
JOIN Categoria cat ON clientes.id_categoría = cat.id_categoría;
