
CREATE DATABASE PlatReparacion
GO
USE PlatReparacion
/*------------------------------------------Tablas LOGIN------------------------------------*/
CREATE TABLE login
(
	id int identity(1,1) PRIMARY KEY,
	usuarioID int,
	clave varchar (50)
	CONSTRAINT fk_usuarioIDLogin FOREIGN KEY (usuarioID) REFERENCES usuario(usuarioID),
)
GO

INSERT INTO login VALUES ('102','0974')
INSERT INTO login VALUES ('109','1234')
INSERT INTO login VALUES ('110','1234')
GO

SELECT * FROM login
GO

ALTER PROCEDURE validarLogin
@USUARIOID int,
@CLAVE VARCHAR (50)
AS
	BEGIN
		SELECT usuarioID, clave FROM login WHERE usuarioID=@USUARIOID AND clave=@CLAVE
	END
GO

EXEC validarLogin 102, '0974'
GO

ALTER PROCEDURE obtenerusuarioID
@Nombre VARCHAR(20)
AS
	BEGIN
		select usuarioID FROM usuario WHERE nombre = @Nombre
	END
GO
EXEC obtenerusuarioID 'minor'
GO

CREATE PROCEDURE obtenerRol
@USUARIOID INT
AS
	BEGIN
		SELECT rolID FROM usuarioRol WHERE usuarioID = @USUARIOID
	END
GO

EXEC obtenerRol '102'
GO
SELECT * FROM usuarioRol
GO
/*-------------------------Fin de tabla Login-----------------------------*/
/*------------------------------------------Tablas Roles------------------------------------*/
CREATE TABLE rol
(
	id int identity(1,1) PRIMARY KEY,
	descripcion varchar(50),
)
GO

INSERT INTO rol VALUES ('Usuario')
INSERT INTO rol VALUES ('Tecnico')
INSERT INTO rol VALUES ('Administrador')
GO

/*-------------------------Fin de tabla Roles-----------------------------*/
/*------------------------------------------Tablas Roles------------------------------------*/
CREATE TABLE usuarioRol
(
	usuarioID int PRIMARY KEY,
	rolID int,
	CONSTRAINT fk_usuarioIDRol FOREIGN KEY (usuarioID) REFERENCES usuario(usuarioID),
	CONSTRAINT fk_RolID FOREIGN KEY (rolID) REFERENCES rol(id),
)
GO
INSERT INTO usuarioRol VALUES ('102', '3')
INSERT INTO usuarioRol VALUES ('109', '3')
INSERT INTO usuarioRol VALUES ('110', '3')
GO
/*-------------------------Fin de tabla usuarioRol-----------------------------*/
/*------------------------------------------Tablas usuario------------------------------------*/
CREATE TABLE usuario
(
		usuarioID int identity(100,1) PRIMARY KEY,
		nombre varchar(20) NOT NULL,
		correo varchar(50),
		telefono varchar(11),
)
GO

INSERT INTO usuario VALUES ('Ashley', 'Ashley@correo', '01473692')
INSERT INTO usuario VALUES ('Carlos', 'Carlos@correo', '01473693')
GO

select * FROM usuario
GO

/*-------Procedimientos almacenados--------*/
CREATE PROCEDURE consultaUsuarioFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM usuario WHERE usuarioID = @CODIGO;
	END
	GO

CREATE PROCEDURE agregarusuarios
@NOMBRE VARCHAR (20),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(11)
AS
	BEGIN
		INSERT INTO usuario VALUES (@NOMBRE, @CORREO, @TELEFONO)
	END
	GO

CREATE PROCEDURE borrarUsuario
@CODIGO INT
AS
	BEGIN
		DELETE usuario WHERE usuarioID = @CODIGO
	END
	GO

CREATE PROCEDURE modificarUsuario
@ID INT,
@NOMBRE VARCHAR(20),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(11)
AS
	BEGIN
		UPDATE usuario SET nombre = @NOMBRE, correo = @CORREO, telefono = @TELEFONO WHERE usuarioID = @ID
	END
	GO
/*-------------------------Fin de tabla usuario-----------------------------*/
/*------------------------------------------Tablas tecnico------------------------------------*/
CREATE TABLE tecnicos
(
	tecnicosID int identity (1,1) PRIMARY KEY,
	nombre varchar (20) NOT NULL,
	especialidad varchar (20) NOT NULL,
)
GO
/*-------Procedimientos almacenados--------*/
CREATE PROCEDURE consultatecnicoFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM tecnicos WHERE tecnicosID = @CODIGO;
	END
	GO

CREATE PROCEDURE agregartecnico
@NOMBRE VARCHAR (20),
@ESPECIALIDAD VARCHAR(20)
AS
	BEGIN
		INSERT INTO tecnicos VALUES (@NOMBRE, @ESPECIALIDAD)
	END
	GO

CREATE PROCEDURE borrarTecnico
@CODIGO INT
AS
	BEGIN
		DELETE tecnicos WHERE tecnicosID = @CODIGO
	END
	GO

CREATE PROCEDURE modificarTecnico
@ID INT,
@NOMBRE VARCHAR(20),
@ESPECIALIDAD VARCHAR(20)
AS
	BEGIN
		UPDATE tecnicos SET nombre = @NOMBRE, especialidad = @ESPECIALIDAD WHERE tecnicosID = @ID
	END
	GO
/*-------------------------Fin de tabla tecnico-----------------------------*/
/*------------------------------------------Tablas equipos------------------------------------*/
CREATE TABLE equipos
(
	equiposID int identity (1000,1) PRIMARY KEY,
	tipodeEquipo varchar (20),
	modelo varchar (20),
	usuarioID int,
	CONSTRAINT fk_usuarioID FOREIGN KEY (usuarioID) REFERENCES usuario(usuarioID),
)
GO
/*-------Procedimientos almacenados--------*/
CREATE PROCEDURE consultaequiposFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM equipos WHERE equiposID = @CODIGO;
	END
	GO

CREATE PROCEDURE agregarequipos
@TIPODEEQUIPO VARCHAR (20),
@MODELO VARCHAR(50),
@USUARIOID VARCHAR(11)
AS
	BEGIN
		INSERT INTO equipos VALUES (@TIPODEEQUIPO, @MODELO, @USUARIOID)
	END
	GO

CREATE PROCEDURE borrarEquipos
@CODIGO INT
AS
	BEGIN
		DELETE equipos WHERE equiposID = @CODIGO
	END
	GO

CREATE PROCEDURE modificarequipo
@ID INT,
@TIPODEEQUIPO VARCHAR(20),
@MODELO VARCHAR(20),
@USUARIOID INT
AS
	BEGIN
		UPDATE equipos SET tipodeEquipo = @TIPODEEQUIPO, modelo = @MODELO, usuarioID = @USUARIOID WHERE equiposID = @ID
	END
	GO
/*-------------------------Fin de tabla equipos-----------------------------*/
/*------------------------------------------Tablas reparaciones------------------------------------*/
CREATE TABLE reparaciones
(
	reparacionesID int identity (1,1) PRIMARY KEY,
	equipoID int NOT NULL,
	fechaSolicitud date NOT NULL DEFAULT GETDATE(),
	estado varchar (20),
	CONSTRAINT fk_equipoID FOREIGN KEY (equipoID) REFERENCES equipos(equiposID),
)
GO
/*-------Procedimientos almacenados--------*/
CREATE PROCEDURE consultaReparacionesFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM reparaciones WHERE reparacionesID = @CODIGO;
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

CREATE PROCEDURE borrarReparacion
@CODIGO INT
AS
	BEGIN
		DELETE asignaciones WHERE reparacionID = @CODIGO
		DELETE reparaciones WHERE reparacionesID = @CODIGO
	END
	EXEC borrarReparacion 8
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

/*-------------------------Fin de tabla reparaciones-----------------------------*/
/*------------------------------------------Tablas detalleReparacion------------------------------------*/
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
/*Procedimientos almacenados*/
CREATE PROCEDURE consultaDetalleFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM detalleReparacion WHERE detalleReparacionID = @CODIGO;
	END
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

CREATE PROCEDURE borrarDetalleRep
@CODIGO int
AS
	BEGIN
		DELETE detalleReparacion WHERE detalleReparacionID = @CODIGO
	END
	EXEC borrarDetalleRep 101
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

/*-------------------------Fin de tabla detalleReparacion-----------------------------*/
/*------------------------------------------Tablas asignaciones------------------------------------*/
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
/*Procedimientos almacenados*/
CREATE PROCEDURE consultaAsignacionesFiltro
@CODIGO INT
AS
	BEGIN
		SELECT * FROM asignaciones WHERE asignacionesID = @CODIGO;
	END
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

CREATE PROCEDURE borrarAsignacion
@CODIGO INT
AS
	BEGIN
		DELETE asignaciones WHERE asignacionesID = @CODIGO
	END
	EXEC borrarAsignacion 1
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
/*-------------------------Fin de tabla asignaciones-----------------------------*/



/*Proceso almacenado para la generación del reporte de usuarios*/
CREATE PROCEDURE reporteUsuario
AS
	BEGIN
	SELECT U.UsuarioID, U.Nombre, E.TipodeEquipo, D.Descripcion, D.FechaFinal
	FROM Usuario U
	INNER JOIN Equipos E ON U.UsuarioID = E.UsuarioID
	INNER JOIN Reparaciones R ON E.EquiposID = R.EquipoID
	INNER JOIN DetalleReparacion D ON R.ReparacionesID = D.ReparacionID
	END
GO



USE PlatReparacion
GO

















