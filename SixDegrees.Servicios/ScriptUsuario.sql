-- Crear la base de datos
CREATE DATABASE PruebaSD;

-- Usar la base de datos recién creada
USE PruebaSD;

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    UsuID NUMERIC(18, 0) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Apellido VARCHAR(100) NULL
);

-- Inserción en la tabla Usuario
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (1, 'Juan', 'Pérez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (2, 'Ana', 'Martínez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (3, 'Carlos', 'Gómez');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (4, 'Luisa', 'Torres');
INSERT INTO Usuario (UsuID, Nombre, Apellido) VALUES (5, 'Pedro', 'Ramírez');

SELECT * FROM Usuario
