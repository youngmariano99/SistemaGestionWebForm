-- 1ER PASO: CREAR BASE DE DATOS Y SELECCIÓN DE LA BASE DE DATOS PARA USARLA --
CREATE DATABASE GestionEmpleadosWeb;
USE GestionEmpleadosWeb;


-- 2DO PASO: CREAR LAS TABLAS CON SUS RELACIONES --


-- TABLA DEL ADMIN --
CREATE TABLE Administradores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(100) NOT NULL
);


-- TABLA DE EMPLEADOS --

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
	Dni NVARCHAR(50) NOT NULL,
	FechaNacimiento DATE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
	Activo BIT NOT NULL DEFAULT(1),
);

-- TABLA DE PRODUCTOS CON RELACIÓN CON EMPLEADOS --

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Categoria NVARCHAR(50),
    Stock INT,
    Precio DECIMAL(10,2),
    EmpleadoResponsableId INT,
    FOREIGN KEY (EmpleadoResponsableId) REFERENCES Empleados(Id)
);


-- TABLA DE ACCESOS DE EMPLEADOS CON RELACIÓN CON EMPLEADOS --

CREATE TABLE AccesosEmpleado (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT NOT NULL,
    FechaHoraAcceso DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id)
);


-- 3ER PASO: REALIZAR INSERTS (OPCIONAL SI QUERES CONTAR CON REGISTROS ANTES DE ARRANCAR A USAR LA APP WEB) --

INSERT INTO Administradores (Nombre, Email, Contraseña)
VALUES ('Matias ','admin@tienda.com', 'admin123');

INSERT INTO Empleados (Nombre, Apellido, Dni, FechaNacimiento, Email, Contraseña) VALUES 
('Lucas', 'Gómez', '30251987', '1990-03-15', 'lucas1@tienda.com', 'pass1'),
('Valentina', 'Ríos', '28401988', '1992-05-10', 'valen2@tienda.com', 'pass2'),
('Franco', 'Sosa', '32111589', '1989-12-22', 'franco3@tienda.com', 'pass3'),
('Camila', 'Paz', '29111870', '1993-07-09', 'camila4@tienda.com', 'pass4'),
('Diego', 'Ortega', '29561745', '1991-09-02', 'diego5@tienda.com', 'pass5'),
('Martina', 'Méndez', '31001584', '1994-08-14', 'martina6@tienda.com', 'pass6'),
('Bruno', 'Castro', '31631020', '1990-06-23', 'bruno7@tienda.com', 'pass7'),
('Sofía', 'Silva', '30311977', '1995-04-01', 'sofia8@tienda.com', 'pass8'),
('Nicolás', 'Luna', '28881973', '1993-11-11', 'nico9@tienda.com', 'pass9'),
('Paula', 'Ibarra', '31222114', '1992-01-05', 'paula10@tienda.com', 'pass10'),
('Julieta', 'Acosta', '31440111', '1990-02-07', 'julieta11@tienda.com', 'pass11'),
('Leandro', 'Ríos', '29731010', '1991-10-03', 'lean12@tienda.com', 'pass12'),
('Rocío', 'Moreno', '29996111', '1994-12-30', 'rocio13@tienda.com', 'pass13'),
('Agustín', 'Vega', '30111974', '1995-06-06', 'agus14@tienda.com', 'pass14'),
('Antonella', 'Fernández', '31333121', '1992-09-21', 'anto15@tienda.com', 'pass15'),
('Iván', 'Duarte', '28001119', '1993-03-17', 'ivan16@tienda.com', 'pass16'),
('Mariana', 'Toledo', '28999900', '1994-08-30', 'mariana17@tienda.com', 'pass17'),
('Matías', 'Córdoba', '31022233', '1989-11-18', 'matias18@tienda.com', 'pass18'),
('Carla', 'García', '29881177', '1990-07-22', 'carla19@tienda.com', 'pass19'),
('Esteban', 'Mansilla', '30201770', '1992-10-10', 'esteban20@tienda.com', 'pass20'),
('Nahuel', 'Torres', '30022088', '1991-02-28', 'nahuel21@tienda.com', 'pass21'),
('Ailén', 'Salas', '29311412', '1995-01-16', 'ailen22@tienda.com', 'pass22'),
('Federico', 'Varela', '30555555', '1988-04-04', 'fede23@tienda.com', 'pass23'),
('Milagros', 'Domínguez', '30223345', '1993-03-09', 'milagros24@tienda.com', 'pass24'),
('Santiago', 'Juárez', '30114455', '1991-12-06', 'santi25@tienda.com', 'pass25'),
('Belén', 'Olivares', '30998877', '1994-05-19', 'belen26@tienda.com', 'pass26'),
('Rodrigo', 'Gutiérrez', '31122334', '1992-06-12', 'rodrigo27@tienda.com', 'pass27'),
('Dana', 'Ponce', '29991112', '1993-10-25', 'dana28@tienda.com', 'pass28'),
('Tomás', 'Aguilar', '29887766', '1990-01-01', 'tomi29@tienda.com', 'pass29'),
('Luciana', 'Zárate', '30886655', '1995-07-17', 'luciana30@tienda.com', 'pass30'),
('Gustavo', 'Quiroga', '30775544', '1991-09-29', 'gustavo31@tienda.com', 'pass31'),
('Melina', 'Aranda', '29669900', '1989-08-08', 'melina32@tienda.com', 'pass32'),
('Alan', 'Morales', '30551133', '1992-11-03', 'alan33@tienda.com', 'pass33'),
('Florencia', 'Escobar', '29776611', '1994-02-13', 'flor34@tienda.com', 'pass34'),
('Facundo', 'Acuña', '30115566', '1990-03-03', 'facu35@tienda.com', 'pass35'),
('Cintia', 'Barrios', '30009988', '1993-06-21', 'cintia36@tienda.com', 'pass36'),
('Maximiliano', 'Ramírez', '30227890', '1991-12-15', 'maxi37@tienda.com', 'pass37'),
('Noelia', 'Peralta', '30812345', '1992-04-27', 'noe38@tienda.com', 'pass38'),
('Cristian', 'Giménez', '30911111', '1995-07-31', 'cristian39@tienda.com', 'pass39'),
('Celeste', 'Molina', '29448899', '1994-08-20', 'celeste40@tienda.com', 'pass40'),
('Emiliano', 'Bravo', '29800112', '1990-10-09', 'emi41@tienda.com', 'pass41'),
('Selena', 'Palacios', '29631313', '1993-01-24', 'selena42@tienda.com', 'pass42'),
('Darío', 'Villarreal', '30277655', '1991-05-15', 'dario43@tienda.com', 'pass43'),
('Lorena', 'Alonso', '29333333', '1989-09-04', 'lorena44@tienda.com', 'pass44'),
('Javier', 'Roldán', '29777770', '1992-07-30', 'javi45@tienda.com', 'pass45'),
('Daniela', 'Ramos', '29994444', '1993-11-22', 'dani46@tienda.com', 'pass46'),
('Kevin', 'Mendoza', '30118889', '1994-12-11', 'kevin47@tienda.com', 'pass47'),
('Tamara', 'Villalba', '30330001', '1990-06-18', 'tamara48@tienda.com', 'pass48'),
('Ulises', 'Ayala', '31009977', '1991-01-13', 'ulises49@tienda.com', 'pass49'),
('Valeria', 'Navarro', '29553322', '1995-03-26', 'valeria50@tienda.com', 'pass50');

-- Empleado 1
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Básica Blanca', 'Remeras', 40, 4990.00, 1),
('Zapatillas Urbanas Negro', 'Zapatillas', 15, 22990.00, 1);

-- Empleado 2
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Jogger Unisex Gris', 'Pantalones', 20, 17990.00, 2),
('Remera Estampada Retro', 'Remeras', 25, 7890.00, 2);

-- Empleado 3
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Trail', 'Zapatillas', 10, 24990.00, 3),
('Campera Softshell Azul', 'Deportivos', 12, 25990.00, 3);

-- Empleado 4
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Oversize Verde', 'Remeras', 28, 6890.00, 4),
('Pantalón Chupín Negro', 'Pantalones', 14, 18990.00, 4);

-- Empleado 5
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Running Edge', 'Zapatillas', 9, 22490.00, 5),
('Short DryFit Azul', 'Deportivos', 18, 7490.00, 5);

-- Empleado 6
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Cuello V Negra', 'Remeras', 22, 5990.00, 6),
('Pantalón Oxford Gris', 'Pantalones', 13, 19990.00, 6);

-- Empleado 7
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Buzo Hoodie Beige', 'Deportivos', 19, 14490.00, 7),
('Zapatillas Skate Mid', 'Zapatillas', 7, 21990.00, 7);

-- Empleado 8
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Jogger Cargo Verde', 'Pantalones', 11, 17490.00, 8),
('Remera Estampada Tie-Dye', 'Remeras', 17, 7290.00, 8);

-- Empleado 9
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas High Street', 'Zapatillas', 8, 23990.00, 9),
('Pantalón Deportivo Azul', 'Deportivos', 16, 16990.00, 9);

-- Empleado 10
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Deportiva Airflow', 'Remeras', 23, 8490.00, 10),
('Calza Running Pro', 'Deportivos', 28, 9890.00, 10);

-- Empleado 11
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Pantalón Recto Azul', 'Pantalones', 13, 15490.00, 11),
('Zapatillas Training Flow', 'Zapatillas', 9, 21490.00, 11);

-- Empleado 12
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Crop Top Rosa', 'Remeras', 24, 6990.00, 12),
('Pantalón Chino Beige', 'Pantalones', 10, 17990.00, 12);

-- Empleado 13
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Campera Urban Wind', 'Deportivos', 12, 26490.00, 13),
('Remera Estilo Minimalista', 'Remeras', 20, 6390.00, 13);

-- Empleado 14
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Classic Trail', 'Zapatillas', 6, 22990.00, 14),
('Pantalón Wide Fit Negro', 'Pantalones', 8, 19990.00, 14);

-- Empleado 15
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Manga Larga Bordó', 'Remeras', 26, 7890.00, 15),
('Calza Termoactiva Gris', 'Deportivos', 22, 10990.00, 15);

-- Empleado 16
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Short Playa Basic', 'Deportivos', 18, 6490.00, 16),
('Zapatillas Urban Wave', 'Zapatillas', 10, 20490.00, 16);

-- Empleado 17
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Estampada City', 'Remeras', 21, 7190.00, 17),
('Pantalón Regular Fit Gris', 'Pantalones', 11, 18990.00, 17);

-- Empleado 18
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Performance X', 'Zapatillas', 5, 25990.00, 18),
('Campera Acolchada Negra', 'Deportivos', 15, 27990.00, 18);

-- Empleado 19
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Algodón Blanca', 'Remeras', 30, 5590.00, 19),
('Pantalón Deportivo DryFit', 'Pantalones', 13, 17990.00, 19);

-- Empleado 20
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Runner', 'Zapatillas', 7, 21990.00, 20),
('Short Ultraliviano Gris', 'Deportivos', 20, 6890.00, 20);

-- Empleado 21
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Técnica DryFit', 'Remeras', 19, 8990.00, 21),
('Zapatillas Outdoor Trek', 'Zapatillas', 7, 22990.00, 21);

-- Empleado 22
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Pantalón Cargo Camo', 'Pantalones', 10, 19490.00, 22),
('Campera Impermeable', 'Deportivos', 12, 27990.00, 22),
('Remera Estilo Vintage', 'Remeras', 18, 7590.00, 22);

-- Empleado 23
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Style', 'Zapatillas', 6, 21990.00, 23),
('Buzo Básico Negro', 'Deportivos', 20, 13990.00, 23);

-- Empleado 24
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Jogger Azul Noche', 'Pantalones', 14, 17490.00, 24),
('Remera Cuello Redondo', 'Remeras', 25, 5990.00, 24);

-- Empleado 25
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Training Pro', 'Zapatillas', 8, 24990.00, 25),
('Short Running AirFlow', 'Deportivos', 17, 6890.00, 25);

-- Empleado 26
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Camisa Leñadora', 'Remeras', 12, 8490.00, 26),
('Jean Recto Azul', 'Pantalones', 10, 15990.00, 26);

-- Empleado 27
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Edge', 'Zapatillas', 9, 23990.00, 27),
('Pantalón Chino Beige', 'Pantalones', 8, 18490.00, 27);

-- Empleado 28
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Estampada Jungle', 'Remeras', 20, 7190.00, 28),
('Calza Compresión Negra', 'Deportivos', 30, 10490.00, 28);

-- Empleado 29
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Classic Runner', 'Zapatillas', 10, 20990.00, 29),
('Buzo Crop Verde', 'Deportivos', 14, 11990.00, 29);

-- Empleado 30
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Oversize Lila', 'Remeras', 28, 6790.00, 30),
('Pantalón Oxford Negro', 'Pantalones', 9, 19990.00, 30);

-- Empleado 31
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera DryLine Celeste', 'Remeras', 19, 7090.00, 31),
('Pantalón Slim Fit Beige', 'Pantalones', 14, 17490.00, 31);

-- Empleado 32
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Flow Urban', 'Zapatillas', 7, 22490.00, 32),
('Calza Running Neon', 'Deportivos', 20, 11490.00, 32);

-- Empleado 33
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Urbana Bordada', 'Remeras', 22, 7690.00, 33),
('Short Stretch Negro', 'Deportivos', 16, 6590.00, 33);

-- Empleado 34
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Trail Speed', 'Zapatillas', 9, 23490.00, 34),
('Jean Skinny Gris', 'Pantalones', 12, 18490.00, 34);

-- Empleado 35
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Cuello Henley', 'Remeras', 18, 8090.00, 35),
('Campera Deportiva Viento', 'Deportivos', 13, 24990.00, 35);

-- Empleado 36
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urbana Flex', 'Zapatillas', 6, 21490.00, 36),
('Pantalón Cargo Arena', 'Pantalones', 9, 16990.00, 36);

-- Empleado 37
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Básica Naranja', 'Remeras', 26, 5790.00, 37),
('Short Deportivo DryZone', 'Deportivos', 21, 7390.00, 37);

-- Empleado 38
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Training Motion', 'Zapatillas', 8, 24490.00, 38),
('Pantalón Straight Fit Azul', 'Pantalones', 10, 17490.00, 38);

-- Empleado 39
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Estampada Lunar', 'Remeras', 17, 6890.00, 39),
('Calza Técnica Compresión', 'Deportivos', 14, 10990.00, 39);

-- Empleado 40
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Street Light', 'Zapatillas', 10, 19990.00, 40),
('Pantalón Gabardina Negro', 'Pantalones', 11, 15990.00, 40);

-- Empleado 41
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Estilo Wave', 'Remeras', 23, 7190.00, 41),
('Short Entrenamiento Elite', 'Deportivos', 18, 7990.00, 41);

-- Empleado 42
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Pulse', 'Zapatillas', 9, 20990.00, 42),
('Pantalón Slim Tech', 'Pantalones', 7, 18990.00, 42);

-- Empleado 43
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera DryCool Print', 'Remeras', 20, 7490.00, 43),
('Campera Soft Sport', 'Deportivos', 11, 25490.00, 43);

-- Empleado 44
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Negras Urban Boost', 'Zapatillas', 8, 21990.00, 44),
('Pantalón Recto Beige', 'Pantalones', 10, 16490.00, 44);

-- Empleado 45
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Vintage Cactus', 'Remeras', 15, 6290.00, 45),
('Calza Deportiva PowerFit', 'Deportivos', 19, 9490.00, 45);

-- Empleado 46
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Mid Runner', 'Zapatillas', 7, 20990.00, 46),
('Pantalón Jogger Sand', 'Pantalones', 13, 17990.00, 46);

-- Empleado 47
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Oversize Raw', 'Remeras', 29, 6790.00, 47),
('Buzo Deportivo FastDry', 'Deportivos', 12, 13990.00, 47);

-- Empleado 48
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas SportX Gris', 'Zapatillas', 5, 24990.00, 48),
('Pantalón Relax Cargo', 'Pantalones', 9, 16990.00, 48);

-- Empleado 49
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Remera Graffiti Print', 'Remeras', 20, 6890.00, 49),
('Short Deportivo Urban Core', 'Deportivos', 14, 7990.00, 49);

-- Empleado 50
INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId) VALUES
('Zapatillas Urban Storm', 'Zapatillas', 6, 23490.00, 50),
('Pantalón Slim UrbanFit', 'Pantalones', 10, 18990.00, 50);



-- QUERIES PARA RESETEAR LAS TABLAS --

-- Paso 1: Eliminar registros respetando FK
DELETE FROM AccesosEmpleado;
DELETE FROM Productos;
DELETE FROM Empleados;
DELETE FROM Administradores;

-- Paso 2: Reiniciar IDENTITY
DBCC CHECKIDENT ('AccesosEmpleado', RESEED, 0);
DBCC CHECKIDENT ('Productos', RESEED, 0);
DBCC CHECKIDENT ('Empleados', RESEED, 0);
DBCC CHECKIDENT ('Administradores', RESEED, 0);
