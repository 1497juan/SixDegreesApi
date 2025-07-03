-- Crear la base de datos
CREATE DATABASE PruebaSD;

-- Usar la base de datos reci�n creada
USE PruebaSD;

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    UsuID NUMERIC(18, 0) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Apellido VARCHAR(100) NULL
);

-- Inserci�n en la tabla Usuario
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (1, 'Juan', 'P�rez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (2, 'Ana', 'Mart�nez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (3, 'Carlos', 'G�mez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (4, 'Luisa', 'Torres');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (5, 'Pedro', 'Ram�rez');

SELECT * FROM Usuario
