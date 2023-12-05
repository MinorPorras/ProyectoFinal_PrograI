
CREATE DATABASE PlatReparacion
GO

CREATE TABLE users
(
	id int identity (1,1) PRIMARY KEY NOT NULL,
	nombre varchar (20) NOT NULL,
	correo varchar (50) NOT NULL,
	clave varchar (50) NOT NULL,
)
GO
INSERT INTO users VALUES ('minor', 'minor@correo.com', '0974')
INSERT INTO users VALUES ('Carlos', 'Carlos@correo.com', '1234')
INSERT INTO users VALUES ('Ashley', 'Ashley@correo.com', '1234')
GO

CREATE PROCEDURE validarUsers
@NOMBRE VARCHAR(20),
@CLAVE VARCHAR (50)
AS
	BEGIN
		SELECT nombre, clave FROM users WHERE nombre=@NOMBRE AND clave=@CLAVE
	END
GO

SELECT * FROM users
GO

CREATE TABLE usuario
(
		usuarioID int identity(100,1) PRIMARY KEY,
		nombre varchar(20) NOT NULL,
		correo varchar(50),
		telefono varchar(11),
)
GO


CREATE TABLE tecnicos
(
	tecnicosID int identity (1,1) PRIMARY KEY,
	nombre varchar (20) NOT NULL,
	especialidad varchar (20) NOT NULL,
)
GO

CREATE TABLE equipos
(
	equiposID int identity (1000,1) PRIMARY KEY,
	tipodeEquipo varchar (20),
	modelo varchar (20),
	usuarioID int,
	CONSTRAINT fk_usuarioID FOREIGN KEY (usuarioID) REFERENCES usuario(usuarioID),
)
GO

CREATE TABLE reparaciones
(
	reparacionesID int identity (1,1) PRIMARY KEY,
	equipoID int NOT NULL,
	fechaSolicitud date NOT NULL DEFAULT GETDATE(),
	estado varchar (20),
	CONSTRAINT fk_equipoID FOREIGN KEY (equipoID) REFERENCES equipos(equiposID),
)
GO

CREATE TABLE detalleReparacion
(
	detalleReparacionID int identity (100,1) PRIMARY KEY,
	reparacionID int NOT NULL,
	descripcion varchar (25) NOT NULL,
	fechaInicio date DEFAULT GETDATE() NOT NULL,
	fechaFinal date DEFAULT DATEADD(DAY, 1, GETDATE()) NOT NULL,
	CONSTRAINT fk_reparacionID FOREIGN KEY (reparacionID) REFERENCES reparaciones(reparacionesID),

)
GO

CREATE TABLE asignaciones
(
	asignacionesID int identity (1,1),
	reparacionID int,
	tecnicoID int,
	fechaAsignacion date DEFAULT GETDATE()NOT NULL,
	CONSTRAINT fk_reparacionIDAs FOREIGN KEY (reparacionID) REFERENCES reparaciones(reparacionesID),
	CONSTRAINT fk_tecnicoID FOREIGN KEY (tecnicoID) REFERENCES tecnicos(tecnicosID),
)
GO

USE PlatReparacion
GO

CREATE PROCEDURE consultaReparacionesFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM reparaciones WHERE reparacionesID = @CODIGO;
	END
	GO

CREATE PROCEDURE consultaDetalleFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM detalleReparacion WHERE detalleReparacionID = @CODIGO;
	END
	GO

CREATE PROCEDURE consultaAsignacionesFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM asignaciones WHERE asignacionesID = @CODIGO;
	END
	GO

CREATE PROCEDURE agregarReparacion
@EQUIPOID INT,
@ESTADO VARCHAR(20),
@FECHA DATE
AS
	BEGIN
		INSERT INTO reparaciones VALUES (@EQUIPOID, @FECHA, @ESTADO)
	END
	GO
	EXEC agregarReparacion 1002, 'TRABAJO'
	GO

CREATE PROCEDURE agregarDetalle
@REPARACIONID INT,
@DESC VARCHAR (25),
@fECHAINICIO DATE,
@FECHAFINAL DATE
AS
	BEGIN
		INSERT INTO detalleReparacion VALUES (@REPARACIONID, @DESC, @fECHAINICIO, @FECHAFINAL)
	END
	GO
	EXEC agregarDetalle 4, 'PC', '2023/03/22', '2023/03/30'
	GO

CREATE PROCEDURE agregarAsignacion
@REPARACIONID INT,
@TECNICOID INT,
@FECHAINICIO DATE
AS
	BEGIN
		INSERT INTO asignaciones VALUES (@REPARACIONID, @TECNICOID, @FECHAINICIO)
	END
	GO
	EXEC agregarAsignacion 8, 2, null
	GO

CREATE PROCEDURE borrarReparacion
@CODIGO INT
AS
	BEGIN
		DELETE asignaciones WHERE reparacionID = @CODIGO
		DELETE reparaciones WHERE reparacionesID = @CODIGO
	END
	EXEC borrarReparacion 8
	GO

CREATE PROCEDURE borrarDetalleRep
@CODIGO int
AS
	BEGIN
		DELETE detalleReparacion WHERE detalleReparacionID = @CODIGO
	END
	EXEC borrarDetalleRep 101
	GO

CREATE PROCEDURE borrarAsignacion
@CODIGO INT
AS
	BEGIN
		DELETE asignaciones WHERE asignacionesID = @CODIGO
	END
	EXEC borrarAsignacion 1
	GO

CREATE PROCEDURE modificarReparacion
@ID INT,
@EQUIPOSID INT,
@FECHA DATE,
@ESTADO VARCHAR(20)
AS
	BEGIN
		UPDATE reparaciones SET equipoID = @EQUIPOSID, fechaSolicitud = @FECHA, estado = @ESTADO WHERE reparacionesID = @ID
	END
	GO

CREATE PROCEDURE modificarDetalleRep
@ID int,
@REPARACIONID INT,
@DESC VARCHAR (25),
@FECHAINICIO DATE,
@FECHAFIN DATE
AS
	BEGIN
		UPDATE detalleReparacion SET reparacionID = @REPARACIONID, descripcion = @DESC, fechaInicio = @FECHAINICIO, fechaFinal = @FECHAFIN WHERE detalleReparacionID = @ID
	END
GO

CREATE PROCEDURE modificarAsignacion
@ID INT,
@REPARACIONID INT,
@TECNICOID INT,
@FECHA DATE
AS
	BEGIN
		UPDATE asignaciones SET reparacionID = @REPARACIONID, tecnicoID = @TECNICOID, fechaAsignacion = @FECHA WHERE asignacionesID = @ID
	END
	GO