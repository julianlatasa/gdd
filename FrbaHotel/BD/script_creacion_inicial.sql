USE [GD1C2018]
GO

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [DON_GATO_Y_SU_PANDILLA].[' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + ']'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME =rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'DON_GATO_Y_SU_PANDILLA')
BEGIN
	EXEC ('CREATE SCHEMA [DON_GATO_Y_SU_PANDILLA] AUTHORIZATION gd')
END
GO

IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FACTURA', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].FACTURA;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FORMA_PAGO', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].FORMA_PAGO;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADIA', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].ESTADIA;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CONSUMIBLE', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO ;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADO', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].ESTADO;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].RESERVA;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD ;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].COMODIDAD', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].COMODIDAD ;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].HABITACION;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].REGIMEN', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].REGIMEN;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CLIENTE', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].CLIENTE;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTRELLAS', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].ESTRELLAS;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CIUDAD', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].CIUDAD;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].PAIS', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].PAIS;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].ROL;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_ROL', 'U') IS NOT NULL DROP TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL;

IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL_Asignar_Funcionalidad') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Asignar_Funcionalidad;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ROL_Eliminar_Funcionalidad') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Eliminar_Funcionalidad;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Login') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Login;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].GUEST_Login') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].GUEST_Login;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Cambiar_Contrasena') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Cambiar_Contrasena;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol_Activo') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol_Activo;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel_Activo') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel_Activo;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Rol') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Rol;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Hotel') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Hotel;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CLIENTE_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CLIENTE_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CLIENTE_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Regimen') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Regimen;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Eliminar_Regimen') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Eliminar_Regimen;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Baja_Temporal') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Baja_Temporal;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_Asignar_Comodidad') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Asignar_Comodidad;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].HABITACION_Eliminar_Comodidad') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Eliminar_Comodidad;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA_Modificar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Modificar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].RESERVA_Cancelar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Cancelar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADIA_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADIA_Buscar') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Buscar;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADIA_Checkout') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Checkout;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].FACTURACION_Crear') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].FACTURACION_Crear;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_1') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_1;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_2') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_2;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_3') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_3;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_4') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_4;
IF OBJECT_ID('[DON_GATO_Y_SU_PANDILLA].ESTADISTICO_5') IS NOT NULL DROP PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_5;

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (
	func_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	func_nombre varchar(100) NOT NULL
	) 

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].ROL (
	rol_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	rol_nombre varchar(100) NOT NULL,
	rol_habilitado char(1) NOT NULL DEFAULT 1
	) 

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (
	func_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD(func_id),
	rol_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].ROL(rol_id)
	) 

/* ESTA TABLA NO ESTA EN EL MODELO!! */
CREATE TABLE [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO (
	tipo_id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	tipo_nombre varchar(50) NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].PAIS (
	pais_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	pais_nombre varchar(100) NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].CIUDAD (
	ciud_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ciud_nombre varchar(100) NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].ESTRELLAS (
	estr_numero int NOT NULL PRIMARY KEY,
	estr_recargo int NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL (
	hote_id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	hote_nombre varchar(100) NOT NULL,
	hote_email varchar(150) NOT NULL,
	hote_telefono varchar(50) NOT NULL,
	hote_domicilio varchar(200) NOT NULL,
	hote_ciudad int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].CIUDAD(ciud_id),
	hote_pais int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].PAIS(pais_id),
	hote_estrellas int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].ESTRELLAS(estr_numero),
	hote_fecha_creacion smalldatetime NOT NULL DEFAULT GETDATE()
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO (
	usua_usuario char(50) NOT NULL PRIMARY KEY,
	usua_password varchar(255) NOT NULL, /* este campo despues va a tener que ser un HASH*/
	usua_email varchar(150) NOT NULL,
	usua_rol_activo int FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].ROL(rol_id),
	usua_hotel_activo int FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id), 
	usua_intentos_login char(1) NOT NULL DEFAULT 0,
	usua_habilitado char(1) NOT NULL DEFAULT 1,
	usua_tipo_doc int NOT NULL ,
	usua_numero_doc varchar(10) NOT NULL,
	usua_nombre varchar(100) NOT NULL,
	usua_apellido varchar(100) NOT NULL,
	usua_telefono varchar(50),
	usua_domicilio varchar(200),
	usua_fecha_nac smalldatetime NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (
	usua_usuario char(50) NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].USUARIO(usua_usuario),
	hote_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL (
	usua_usuario char(50) NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].USUARIO(usua_usuario),
	rol_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].ROL(rol_id)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL (
	baja_hotel int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id),
	baja_desde smalldatetime NOT NULL,
	baja_hasta smalldatetime,
	baja_descripcion varchar(2000)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].CLIENTE (
	clie_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	clie_tipo_doc int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO(tipo_id),
	clie_numero_doc varchar(10) NOT NULL,
	clie_nombre varchar(100) NOT NULL,
	clie_apellido varchar(100) NOT NULL,
	clie_email varchar(150) NOT NULL,
	clie_telefono varchar(50),
	clie_habilitado char(1) NOT NULL DEFAULT 1,
	clie_domicilio varchar(200) NOT NULL,
	clie_fecha_nac smalldatetime,
	clie_localidad varchar(50),
	clie_pais int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].PAIS(pais_id),
	clie_nacionalidad int FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].PAIS(pais_id)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].REGIMEN (
	regi_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	regi_descripcion varchar(100) NOT NULL,
	regi_precio_base numeric(8,2) NOT NULL,
	regi_habilitado char(1) NOT NULL DEFAULT 1
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN (
	regi_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].REGIMEN(regi_id),
	hote_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION (
	tipo_id int NOT NULL PRIMARY KEY,
	tipo_descripcion varchar(50) NOT NULL,
	tipo_precio numeric(8,2) NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].HABITACION (
	habi_hotel int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id),
	habi_numero int NOT NULL,
	habi_piso int NOT NULL,
	habi_vista char(1) NOT NULL DEFAULT 'N',
	habi_tipo int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION(tipo_id),
	habi_descripcion varchar(255),
	habi_habilitada char(1) NOT NULL DEFAULT 1,
	PRIMARY KEY (habi_hotel, habi_numero)
	) 

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].COMODIDAD (
	como_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	como_descripcion varchar(100)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD (
	como_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].COMODIDAD(como_id),
	habi_hotel int NOT NULL,
	habi_numero int NOT NULL,
	FOREIGN KEY (habi_hotel, habi_numero) REFERENCES [DON_GATO_Y_SU_PANDILLA].HABITACION(habi_hotel, habi_numero)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].RESERVA (
	rese_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	rese_hotel int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].HOTEL(hote_id),
    rese_creacion smalldatetime DEFAULT GETDATE(),
	rese_desde smalldatetime NOT NULL,
	rese_duracion int NOT NULL,
	rese_tipo_habitacion int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION(tipo_id),
	rese_regimen int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].REGIMEN(regi_id),
	rese_cliente int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].CLIENTE(clie_id),
	rese_precio int NOT NULL,
	rese_habitaciones int NOT NULL,
	rese_motivo_cancelacion varchar(100),
	rese_fecha_cancelacion smalldatetime,
	rese_usuario_cancelacion char(50) FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].USUARIO(usua_usuario)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].ESTADO (
	esta_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	esta_descripcion varchar(100) NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO (
	rese_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].RESERVA(rese_id),
	esta_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].ESTADO(esta_id),
	usua_id char(50) NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].USUARIO(usua_usuario),
	rese_esta_fecha smalldatetime NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE (
	cons_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	cons_descripcion varchar(100) NOT NULL,
	cons_precio numeric(8,2) NOT NULL
	)

/* necesita relacion con reserva? o cliente y habitacion? */
CREATE TABLE [DON_GATO_Y_SU_PANDILLA].ESTADIA (
	esta_hotel int NOT NULL,
	esta_habitacion int NOT NULL,
	esta_cliente int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].CLIENTE(clie_id),
	esta_reserva int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].RESERVA(rese_id),
	esta_checkin smalldatetime NOT NULL,
	esta_checkout smalldatetime,
    esta_usua_checkin CHAR(50),
    esta_usua_checkout CHAR(50),
	esta_duracion int,
	FOREIGN KEY (esta_hotel, esta_habitacion) REFERENCES [DON_GATO_Y_SU_PANDILLA].HABITACION(habi_hotel, habi_numero)
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA (
    rese_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].RESERVA(rese_id),
    cons_id int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE(cons_id),
    cons_cantidad int NOT NULL
	)

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].FORMA_PAGO (
	form_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	form_nombre nchar(100) NOT NULL
	) 

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].FACTURA (
    fact_numero int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    fact_reserva int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].RESERVA(rese_id),
    fact_forma_pago int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].FORMA_PAGO(form_id),
    fact_fecha smalldatetime NOT NULL DEFAULT GETDATE(),
    fact_total int NOT NULL
    )

CREATE TABLE [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (
    fact_numero int NOT NULL FOREIGN KEY REFERENCES [DON_GATO_Y_SU_PANDILLA].FACTURA(fact_numero),
    fact_es_consumible BIT NOT NULL,
    fact_line_descripcion varchar(100) NOT NULL,
    fact_line_monto int NOT NULL,
    fact_line_cantidad int NOT NULL
    )

-- PUNTO 1 --

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Crear @nombreRol VARCHAR(100)
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].ROL(rol_nombre) VALUES (@nombreRol);
    SELECT CONVERT(INT, SCOPE_IDENTITY());
END

GO

CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Modificar @idRol INT, @nombreRol VARCHAR(100), @habilitado CHAR(1)
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].ROL SET rol_nombre = @nombreRol, rol_habilitado = @habilitado WHERE rol_id = @idRol
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Buscar @nombreRol VARCHAR(100)
AS BEGIN
    SELECT * FROM [DON_GATO_Y_SU_PANDILLA].ROL WHERE rol_nombre LIKE CONCAT('%', @nombreRol, '%')
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Asignar_Funcionalidad @idRol INT, @idFuncionalidad INT
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (@idRol, @idFuncionalidad)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ROL_Eliminar_Funcionalidad @idRol INT, @idFuncionalidad INT
AS BEGIN
    DELETE FROM [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL WHERE rol_id = @idRol AND func_id = @idFuncionalidad
END


-- PUNTO 2 --
select * from [DON_GATO_Y_SU_PANDILLA].CLIENTE where clie_nombre = 'nicolas'

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Login @usuario CHAR(50), @contrasena VARCHAR(50)
AS BEGIN
    IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].USUARIO WHERE usua_usuario = @usuario AND usua_password = HASHBYTES('SHA2_256', @contrasena) AND usua_habilitado = 1) = 0
	BEGIN
		UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_intentos_login += 1 WHERE usua_usuario = @usuario

		IF (SELECT usua_intentos_login FROM [DON_GATO_Y_SU_PANDILLA].USUARIO WHERE usua_usuario = @usuario) > 2
		BEGIN
			UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_habilitado = 1 WHERE usua_usuario = @usuario
			RAISERROR('Usuario bloqueado por reiterados intentos.', 16, 1);
			RETURN;
		END

        RAISERROR('Usuario no encontrado.', 16, 1);
		RETURN;
	END

	UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_intentos_login = 0 WHERE usua_usuario = @usuario
    SELECT usua_usuario FROM [DON_GATO_Y_SU_PANDILLA].USUARIO WHERE usua_usuario = @usuario AND usua_password = HASHBYTES('SHA2_256', @contrasena)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].GUEST_Login
AS BEGIN
	SELECT TOP 1 r.rol_id, u.usua_usuario FROM [DON_GATO_Y_SU_PANDILLA].ROL r JOIN [DON_GATO_Y_SU_PANDILLA].USUARIO u ON u.usua_rol_activo = r.rol_id WHERE r.rol_nombre = 'INVITADO';
/*
    SELECT f.func_id, f.func_nombre
    FROM [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD f
    JOIN [DON_GATO_Y_SU_PANDILLA].ROL r ON r.rol_nombre = 'INVITADO'
    JOIN [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL fr ON fr.rol_id = r.rol_id
    WHERE f.func_id = fr.func_id
*/
END


-- PUNTO 3 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Crear @usuario CHAR(50), @contrasena VARCHAR(50), @nombre VARCHAR(100), 
                                @apellido VARCHAR(100), @tipoDocumento INT, @nroDocumento VARCHAR(10), @email VARCHAR(150),
                                @telefono VARCHAR(50), @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME
AS BEGIN
    IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].USUARIO WHERE usua_usuario = @usuario) > 0
	BEGIN
        RAISERROR('Usuario ya existe.', 16, 1);
		RETURN;
	END

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO (usua_usuario, usua_password, usua_email, usua_tipo_doc, usua_numero_doc, usua_nombre, usua_apellido, usua_domicilio, usua_telefono, usua_fecha_nac)
                VALUES(@usuario, HASHBYTES('SHA2_256', @contrasena), @email, @tipoDocumento, @nroDocumento, @nombre, @apellido, @domicilio, @telefono, @fechaNacimiento)

    SELECT CONVERT(INT, SCOPE_IDENTITY())
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Modificar @usuario CHAR(50), @contrasena VARCHAR(50), @nombre VARCHAR(100), 
                                @apellido VARCHAR(100), @tipoDocumento INT, @nroDocumento VARCHAR(10), @email VARCHAR(150),
                                @telefono VARCHAR(50), @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME, @habilitado CHAR(1)
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_password = HASHBYTES('SHA2_256', @contrasena), usua_tipo_doc = @tipoDocumento, usua_numero_doc = @nroDocumento, 
                        usua_habilitado = @habilitado, usua_email = @email, usua_intentos_login = 0, usua_nombre = @nombre, 
						usua_apellido = @apellido, usua_domicilio = @domicilio, usua_telefono = @telefono, usua_fecha_nac = @fechaNacimiento
                    WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Cambiar_Contrasena @usuario CHAR(50), @contrasena VARCHAR(50)
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_password = HASHBYTES('SHA2_256', @contrasena) WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Buscar @usuario VARCHAR(50), @idRol INT = NULL, @idHotel INT = NULL
AS BEGIN
    SELECT DISTINCT u.* FROM [DON_GATO_Y_SU_PANDILLA].USUARIO u 
	JOIN [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL ur ON ur.usua_usuario = u.usua_usuario AND (@idRol IS NULL OR (@idRol IS NOT NULL AND ur.rol_id = @idRol))
	JOIN [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL uh ON uh.usua_usuario = u.usua_usuario AND (@idHotel IS NULL OR (@idHotel IS NOT NULL AND uh.hote_id = @idHotel))
	WHERE u.usua_usuario LIKE CONCAT('%', @usuario, '%')
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol_Activo @usuario CHAR(50), @idRol INT
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_rol_activo = @idRol WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel_Activo @usuario CHAR(50), @idHotel INT
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].USUARIO SET usua_hotel_activo = @idHotel WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Rol @usuario CHAR(50), @idRol INT
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL(usua_usuario, rol_id) VALUES (@usuario, @idRol)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Rol @usuario CHAR(50), @idRol INT
AS BEGIN
    DELETE FROM [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL WHERE usua_usuario = @usuario AND rol_id = @idRol
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Asignar_Hotel @usuario CHAR(50), @idHotel INT
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL(usua_usuario, hote_id) VALUES (@usuario, @idHotel)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].USUARIO_Eliminar_Hotel @usuario CHAR(50), @idHotel INT
AS BEGIN
    DELETE FROM [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL WHERE usua_usuario = @usuario AND hote_id = @idHotel
END


-- PUNTO 4 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Crear @tipoDocumento INT, @nroDocumento VARCHAR(10), @nombre VARCHAR(100),
                                @apellido VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME, @pais INT, @nacionalidad INT, @localidad VARCHAR(50)
AS BEGIN
	IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE WHERE clie_email = @email) > 0
	BEGIN
		RAISERROR('Email duplicado.', 16, 1);
		RETURN;
	END

	INSERT INTO [DON_GATO_Y_SU_PANDILLA].CLIENTE (clie_tipo_doc, clie_numero_doc, clie_nombre, clie_apellido, clie_email, clie_telefono, clie_domicilio, clie_fecha_nac, clie_pais, clie_nacionalidad, clie_localidad)
	VALUES (@tipoDocumento, @nroDocumento, @nombre, @apellido, @email, @telefono, @domicilio, @fechaNacimiento, @pais, @nacionalidad, @localidad)

	SELECT CONVERT(INT, SCOPE_IDENTITY());
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Modificar @idCliente INT, @tipoDocumento INT, @nroDocumento VARCHAR(10), @nombre VARCHAR(100),
                                    @apellido VARCHAR(100), @email varchar(150),@telefono VARCHAR(50), @domicilio VARCHAR(200), 
                                    @fechaNacimiento SMALLDATETIME, @localidad VARCHAR(50), @pais INT, @nacionalidad INT, @habilitado CHAR(1)
AS BEGIN
	UPDATE [DON_GATO_Y_SU_PANDILLA].CLIENTE SET clie_tipo_doc = @tipoDocumento, 
						clie_numero_doc = @nroDocumento, 
						clie_nombre = @nombre, 
						clie_apellido = @apellido, 
						clie_email = @email, 
						clie_telefono = @telefono,
						clie_domicilio = @domicilio, 
						clie_fecha_nac = @fechaNacimiento,
						clie_localidad = @localidad, 
						clie_pais = @pais, 
						clie_nacionalidad = @nacionalidad,
						clie_habilitado = @habilitado
					WHERE clie_id = @idCliente
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].CLIENTE_Buscar @nombre VARCHAR(100), @apellido VARCHAR(100), @tipoDocumento INT = NULL, @nroDocumento VARCHAR(10), @email VARCHAR(150)
AS BEGIN
    SELECT DISTINCT TOP 50 * FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE WHERE 
								clie_tipo_doc = @tipoDocumento AND 
								clie_numero_doc LIKE CONCAT('%', @nroDocumento, '%') AND
                                clie_email LIKE CONCAT('%', @email, '%') AND
                                clie_nombre LIKE CONCAT('%', @nombre, '%') AND 
                                clie_apellido LIKE CONCAT('%', @apellido, '%')
END

-- PUNTO 5 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Crear @nombre VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @pais INT, @ciudad INT, @estrellas INT
AS BEGIN
	INSERT INTO [DON_GATO_Y_SU_PANDILLA].HOTEL (hote_nombre, hote_email, hote_telefono, hote_domicilio, hote_ciudad, hote_pais, hote_estrellas)
	VALUES (@nombre, @email, @telefono, @domicilio, @ciudad, @pais, @estrellas)
	SELECT CONVERT(INT, SCOPE_IDENTITY())
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Modificar @idHotel INT, @nombre VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @pais INT, @ciudad INT, @estrellas INT
AS BEGIN
	UPDATE [DON_GATO_Y_SU_PANDILLA].HOTEL SET hote_nombre = @nombre, hote_email = @email, hote_telefono = @telefono, hote_domicilio = @domicilio, 
					hote_ciudad = @ciudad, hote_pais = @pais, hote_estrellas = @estrellas
					WHERE hote_id = @idHotel
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Buscar @nombre VARCHAR(100), @pais INT = NULL, @ciudad INT = NULL, @estrellas INT = NULL
AS BEGIN
    SELECT DISTINCT * FROM [DON_GATO_Y_SU_PANDILLA].HOTEL 
	WHERE hote_nombre LIKE CONCAT('%', @nombre, '%') AND 
			(@pais IS NULL OR (@pais IS NOT NULL AND hote_pais = @pais)) AND
			(@ciudad IS NULL OR (@ciudad IS NOT NULL AND hote_ciudad = @ciudad)) AND
			(@estrellas IS NULL OR (@estrellas IS NOT NULL AND hote_estrellas = @estrellas))
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Regimen @idHotel INT, @idRegimen INT
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN(hote_id, regi_id) VALUES (@idHotel, @idRegimen)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Eliminar_Regimen @idHotel INT, @idRegimen INT
AS BEGIN
    IF(SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA r 
        JOIN [DON_GATO_Y_SU_PANDILLA].ESTADO e ON e.esta_descripcion = 'RESERVADO'
        JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO re ON re.rese_id = r.rese_id AND re.esta_id = e.esta_id 
        WHERE r.rese_regimen = @idRegimen) > 
        (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA r 
        JOIN [DON_GATO_Y_SU_PANDILLA].ESTADO e ON e.esta_descripcion = 'HOSPEDADO' OR e.esta_descripcion = 'CANCELADO'
        JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO re ON re.rese_id = r.rese_id AND re.esta_id = e.esta_id 
        WHERE r.rese_regimen = @idRegimen)
	BEGIN
        RAISERROR('Existen reservas utilizando ese régimen.', 16, 1);
		RETURN;
	END;

    IF(SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA e
        JOIN [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN hr ON hr.regi_id = @idRegimen AND hr.hote_id = @idHotel
        WHERE e.esta_hotel = @idHotel AND e.esta_checkout IS NOT NULL) > 0
	BEGIN
        RAISERROR('Existe un huésped alojado bajo este régimen.', 16, 1);
		RETURN;
	END

    DELETE FROM [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN WHERE hote_id = @idHotel AND regi_id = @idRegimen
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HOTEL_Asignar_Baja_Temporal @idHotel INT, @fechaDesde SMALLDATETIME, @fechaHasta SMALLDATETIME, @descripcion VARCHAR(2000)
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL VALUES (@idHotel, @fechaDesde, @fechaHasta, @descripcion)
END


-- PUNTO 6 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Crear @idHotel INT, @nroHabitacion INT, @piso INT, @vista CHAR(1), @tipo INT, @descripcion VARCHAR(255)
AS BEGIN
    IF(SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].HABITACION WHERE habi_hotel = @idHotel AND habi_numero = @nroHabitacion) > 0
	BEGIN
        RAISERROR('Habitación duplicada.', 16, 1);
		RETURN;
	END

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].HABITACION (habi_hotel, habi_numero, habi_piso, habi_vista, habi_tipo, habi_descripcion)
    VALUES (@idHotel, @nroHabitacion, @piso, @vista, @tipo, @descripcion)
END
GO

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Modificar @idHotel INT, @nroHabitacion INT, @piso INT, @vista CHAR(1), @descripcion VARCHAR(255), @habilitado CHAR(1)
AS BEGIN
    UPDATE [DON_GATO_Y_SU_PANDILLA].HABITACION SET habi_piso = @piso, habi_vista = @vista, habi_descripcion = @descripcion, habi_habilitada = @habilitado
    WHERE habi_hotel = @idHotel AND habi_numero = @nroHabitacion
END
GO

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Buscar @idHotel INT
AS BEGIN
    SELECT * FROM [DON_GATO_Y_SU_PANDILLA].HABITACION WHERE habi_hotel = @idHotel
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Asignar_Comodidad @idHotel INT, @nroHabitacion INT, @idComodidad INT
AS BEGIN
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD(como_id, habi_hotel, habi_numero) VALUES (@idComodidad, @idHotel, @nroHabitacion)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].HABITACION_Eliminar_Comodidad @idHotel INT, @nroHabitacion INT, @idComodidad INT
AS BEGIN
    DELETE FROM [DON_GATO_Y_SU_PANDILLA].HABITACION_COMODIDAD WHERE como_id = @idComodidad AND habi_hotel = @idHotel AND habi_numero = @nroHabitacion
END


-- PUNTO 9 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Cancelar @idReserva INT, @motivo VARCHAR(100), @idUsuario VARCHAR(50)
AS BEGIN
    IF DATEDIFF(dayofyear, (SELECT rese_desde FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva), GETDATE()) > 1
	BEGIN
        RAISERROR('Ya no puede cancelarse la reserva.', 16, 1);
		RETURN;
	END

    UPDATE [DON_GATO_Y_SU_PANDILLA].RESERVA SET rese_fecha_cancelacion = GETDATE(), rese_motivo_cancelacion = @motivo, rese_usuario_cancelacion = @idUsuario WHERE rese_id = @idReserva

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO VALUES (@idReserva, 3, @idUsuario, GETDATE())
END


-- PUNTO 8 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Crear @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @idRegimen INT, @precio INT, @habitaciones INT, @idCliente INT = NULL, @idUsuario CHAR(50)
AS BEGIN
    DECLARE @idReserva INT

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA (rese_hotel, rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen, rese_cliente, rese_habitaciones, rese_precio)
    VALUES (@idHotel, @fechaDesde, @duracion, @tipoHabitacion, @idRegimen, @idCliente, @habitaciones, @precio)

    SELECT @idReserva = CONVERT(INT, SCOPE_IDENTITY())

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO VALUES (@idReserva, 1, @idUsuario, GETDATE())
	
    SELECT @idReserva
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Modificar @idReserva INT, @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @idRegimen INT, @precio INT, @habitaciones INT, @idUsuario CHAR(50)
AS BEGIN
    IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO WHERE esta_id = 4 AND rese_id = @idReserva) > 0
	BEGIN
        RAISERROR('Esta reserva ya fue efectivizada.', 16, 1);
		RETURN;
	END
	
    IF DATEDIFF(dayofyear, (SELECT rese_desde FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva), GETDATE()) > 1
	BEGIN
        RAISERROR('Ya no puede modificarse esta reserva.', 16, 1);
		RETURN;
	END

    UPDATE [DON_GATO_Y_SU_PANDILLA].RESERVA SET rese_desde = @fechaDesde, rese_duracion = @duracion, rese_precio = @precio, rese_regimen = @idRegimen, 
                        rese_tipo_habitacion = @tipoHabitacion, rese_hotel = @idHotel, rese_habitaciones = @habitaciones
                    WHERE rese_id = @idReserva

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO VALUES (@idReserva, 2, @idUsuario, GETDATE())
END

GO
 

CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].RESERVA_Buscar @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @nroPersonas INT, @nroHabitaciones INT, @idUsuario VARCHAR(50), @idReserva INT = NULL, @idRegimen INT = NULL
AS BEGIN
	/* DEJO COMENTADO LA PARTE DEL CURSOR DE CANCELAR POR CASO DE ERROR*/
    DECLARE @cIdReserva INT
    /* EL SELECT DEL CURSOR SERIA DENTRO DE LOS DIAS QUE [DON_GATO_Y_SU_PANDILLA].RESERVA. si el DATEDIFF es mayor a la duracion de la reserva, quiere decir que ya paso la reserva*/
	DECLARE cReservas CURSOR FOR SELECT R.rese_id FROM [DON_GATO_Y_SU_PANDILLA].RESERVA R
	JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO RE ON RE.rese_id = R.rese_id WHERE DATEDIFF(dayofyear, rese_desde, GETDATE()) > rese_duracion AND R.rese_id not in (select distinct rese_id from [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO where esta_id <> 1) 

	OPEN cReservas
    FETCH NEXT FROM cReservas INTO @cIdReserva
    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC [DON_GATO_Y_SU_PANDILLA].RESERVA_Cancelar @cIdReserva, 'NO-SHOW', @idUsuario
        FETCH NEXT FROM cReservas INTO @cIdReserva
    END

    CLOSE cReservas
    DEALLOCATE cReservas

    SELECT r.regi_id, r.regi_descripcion, ((r.regi_precio_base + th.tipo_precio * @nroPersonas * @nroHabitaciones) + e.estr_recargo) * @duracion AS precio
    FROM [DON_GATO_Y_SU_PANDILLA].HOTEL_REGIMEN hr
    JOIN [DON_GATO_Y_SU_PANDILLA].REGIMEN r ON r.regi_habilitado = 1 AND r.regi_id = hr.regi_id
    JOIN [DON_GATO_Y_SU_PANDILLA].HABITACION h ON h.habi_habilitada = 1 AND h.habi_hotel = @idHotel AND h.habi_tipo = @tipoHabitacion AND h.habi_numero NOT IN 
		(SELECT e2.esta_habitacion FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA e2 JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r2 ON DATEADD(dayofyear, r2.rese_duracion, r2.rese_desde) < @fechaDesde AND r2.rese_id <> ISNULL(@idReserva, r2.rese_id) AND e2.esta_reserva = r2.rese_id)
	LEFT JOIN [DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL hbt ON hbt.baja_hotel = @idHotel AND (@fechaDesde < hbt.baja_desde OR @fechaDesde > hbt.baja_hasta) AND DATEADD(dayofyear, @duracion, @fechaDesde) NOT BETWEEN hbt.baja_desde AND hbt.baja_hasta
    JOIN [DON_GATO_Y_SU_PANDILLA].HOTEL ho ON ho.hote_id = @idHotel
    JOIN [DON_GATO_Y_SU_PANDILLA].ESTRELLAS e ON e.estr_numero = ho.hote_estrellas
	JOIN [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION th ON th.tipo_id = @tipoHabitacion
    WHERE hr.hote_id = @idHotel AND hr.regi_id = ISNULL(@idRegimen, hr.regi_id)
	GROUP BY r.regi_id, r.regi_descripcion, ((r.regi_precio_base + th.tipo_precio * @nroPersonas * @nroHabitaciones) + e.estr_recargo) * @duracion
	HAVING COUNT(*) >= @nroHabitaciones
END
GO

-- PUNTO 10 --

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Buscar @idReserva INT
AS BEGIN
    SELECT DISTINCT h.* FROM [DON_GATO_Y_SU_PANDILLA].HABITACION h
	JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r ON r.rese_id = @idReserva AND r.rese_hotel = h.habi_hotel AND r.rese_tipo_habitacion = h.habi_tipo
	LEFT JOIN [DON_GATO_Y_SU_PANDILLA].ESTADIA e ON e.esta_hotel = r.rese_hotel AND e.esta_habitacion = h.habi_numero
	WHERE h.habi_habilitada = 1 AND GETDATE() NOT BETWEEN e.esta_checkin AND e.esta_checkout
END

GO

/*FIX: SI ROMPE EN ESTADIA_CREAR ACTUALIZAR EL CREATE.SQL O
ALTER TABLE [DON_GATO_Y_SU_PANDILLA].ESTADIA ALTER COLUMN ESTA_USUA_CHECKIN CHAR(50);
ALTER TABLE [DON_GATO_Y_SU_PANDILLA].ESTADIA ALTER COLUMN ESTA_USUA_CHECKOUT CHAR(50);
*/

CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Crear @idHotel INT, @nroHabitacion INT, @idCliente INT, @idReserva INT, @idUsuario CHAR(50)
AS BEGIN
    IF DATEDIFF(dayofyear, (SELECT rese_desde FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva), GETDATE()) <> 0
	BEGIN
        RAISERROR('La reserva está fuera de fecha.', 16, 1);
		RETURN;
	END

    IF (SELECT COUNT(DISTINCT esta_habitacion) FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA WHERE esta_reserva = @idReserva) > (SELECT rese_habitaciones FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva)
    BEGIN
	    RAISERROR('Alcanzó el nro máximo de habitaciones para la reserva.', 16, 1)
		RETURN;
	END

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADIA (esta_hotel, esta_habitacion, esta_cliente, esta_reserva, esta_checkin, esta_usua_checkin, esta_duracion)
    VALUES (@idHotel, @nroHabitacion, @idCliente, @idReserva, GETDATE(), @idUsuario, (SELECT rese_duracion FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva))

    IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO WHERE esta_id = 4) = 0
	BEGIN
        INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO VALUES (@idReserva, 4, @idUsuario, GETDATE())
	END
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADIA_Checkout @idHotel INT, @nroHabitacion INT, @idReserva INT, @idUsuario VARCHAR(50)
AS BEGIN
	IF(SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA WHERE esta_checkout IS NOT NULL AND esta_hotel = @idHotel AND esta_habitacion = @nroHabitacion AND esta_reserva = @idReserva) > 0
	BEGIN
		RAISERROR('Estadía ya cerrada.', 16, 1);
		RETURN;
	END

    UPDATE [DON_GATO_Y_SU_PANDILLA].ESTADIA SET esta_checkout = GETDATE(), esta_usua_checkout = @idUsuario 
    WHERE esta_hotel = @idHotel AND esta_habitacion = @nroHabitacion AND esta_reserva = @idReserva

	SELECT TOP 1 rese_cliente, esta_cliente FROM [DON_GATO_Y_SU_PANDILLA].RESERVA, [DON_GATO_Y_SU_PANDILLA].ESTADIA WHERE rese_id = @idReserva AND esta_reserva = @idReserva
END


-- PUNTO 11 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_Crear @idReserva INT, @idConsumible INT, @cantidad INT
AS BEGIN
	IF(SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva) = 0
	BEGIN
		RAISERROR('No existe dicha reserva.', 16, 1);
		RETURN;
	END

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA (rese_id, cons_id, cons_cantidad) VALUES (@idReserva, @idConsumible, @cantidad)
END


-- PUNTO 12 --


GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].FACTURACION_Crear @idReserva INT, @formaPago INT, @idCliente INT
AS BEGIN
    DECLARE @idFactura INT, @consId INT, @consCantidad INT, @consTotal INT, @consDescripcion VARCHAR(100), @consPrecio INT,
            @diasUsados INT, @duracion INT, @precio INT
    DECLARE cConsumibles CURSOR FOR SELECT cons_id, cons_cantidad FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA WHERE rese_id = @idReserva

    IF (SELECT rese_cliente FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva) <> @idCliente
	BEGIN
        RAISERROR('El cliente no es quien reservó.', 16, 1);
		RETURN;
	END

    INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA (fact_reserva, fact_forma_pago, fact_total) VALUES (@idReserva, @formaPago, 0)
    SELECT @idFactura = CONVERT(INT, SCOPE_IDENTITY())

    OPEN cConsumibles
    FETCH NEXT FROM cConsumibles INTO @consId, @consCantidad
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @consDescripcion = cons_descripcion, @consPrecio = cons_precio FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE WHERE cons_id = @consId
        SET @consTotal += (SELECT SUM(cons_precio) * @consCantidad FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE WHERE cons_id = @consId)
        INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
        VALUES (@idFactura, 1, @consDescripcion, @consPrecio, @consCantidad)
        FETCH NEXT FROM cConsumibles INTO @consId, @consCantidad
    END

    SELECT @diasUsados = DATEDIFF(dayofyear, esta_checkin, esta_checkout), @duracion = esta_duracion FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA WHERE esta_cliente = @idCliente AND esta_reserva = @idReserva
    SELECT @precio = rese_precio FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id = @idReserva
    INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
    VALUES (@idFactura, 0, CONCAT(@diasUsados, ' de hospedaje'), @precio * @diasUsados / @duracion, @diasUsados)

    IF (SELECT DATEDIFF(dayofyear, esta_checkin, esta_checkout) FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA WHERE esta_cliente = @idCliente AND esta_reserva = @idReserva) < @duracion
	BEGIN
        INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
        VALUES (@idFactura, 0, CONCAT(@duracion - @diasUsados, ' de reserva'), @precio * (@duracion - @diasUsados) / @duracion, @duracion - @diasUsados)
	END

	IF (SELECT COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA ce 
		JOIN [DON_GATO_Y_SU_PANDILLA].REGIMEN re ON re.regi_descripcion = 'All Inclusive'
		JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r ON r.rese_id = @idReserva AND r.rese_regimen = re.regi_id 
		WHERE ce.rese_id = @idReserva) > 0
	BEGIN
		INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
        VALUES (@idFactura, 1, 'Descuento por régimen de estadía', -@consTotal, 1)
	END

	UPDATE [DON_GATO_Y_SU_PANDILLA].FACTURA SET fact_total = (SELECT SUM(fl.fact_line_monto * fl.fact_line_cantidad) FROM [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA fl WHERE fl.fact_numero = @idFactura) WHERE fact_numero = @idFactura

	SELECT f.fact_fecha, f.fact_numero, f.fact_total, fl.fact_line_descripcion, fl.fact_line_monto, fl.fact_line_cantidad FROM [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA fl JOIN [DON_GATO_Y_SU_PANDILLA].FACTURA f ON f.fact_numero = fl.fact_numero WHERE fl.fact_numero = @idFactura
END


-- PUNTO 13 --

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_1 @desde SMALLDATETIME, @hasta SMALLDATETIME
AS BEGIN
    SELECT TOP 5 h.hote_nombre, COUNT(r.rese_id) FROM [DON_GATO_Y_SU_PANDILLA].HOTEL h
    JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r ON r.rese_fecha_cancelacion IS NOT NULL AND r.rese_creacion BETWEEN @desde AND @hasta
    GROUP BY h.hote_nombre
    ORDER BY COUNT(r.rese_id)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_2 @desde SMALLDATETIME, @hasta SMALLDATETIME
AS BEGIN
    SELECT TOP 5 h.hote_nombre, SUM(c.cons_cantidad) FROM [DON_GATO_Y_SU_PANDILLA].HOTEL h
    JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r ON r.rese_hotel = h.hote_id AND r.rese_creacion BETWEEN @desde AND @hasta
    JOIN [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA c ON c.rese_id = r.rese_id
    GROUP BY h.hote_nombre
    ORDER BY SUM(c.cons_cantidad)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_3 @desde SMALLDATETIME, @hasta SMALLDATETIME
AS BEGIN
    SELECT TOP 5 h.hote_nombre, SUM(DATEDIFF(dayofyear, hb.baja_desde, hb.baja_hasta)) FROM [DON_GATO_Y_SU_PANDILLA].HOTEL h
    JOIN [DON_GATO_Y_SU_PANDILLA].HOTEL_BAJA_TEMPORAL hb ON hb.baja_hotel = h.hote_id AND hb.baja_desde BETWEEN @desde AND @hasta
    GROUP BY h.hote_nombre
    ORDER BY SUM(DATEDIFF(dayofyear, hb.baja_desde, hb.baja_hasta))
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_4 @desde SMALLDATETIME, @hasta SMALLDATETIME
AS BEGIN
    SELECT TOP 5 ha.habi_numero, ho.hote_nombre, SUM(e.esta_duracion), COUNT(*) FROM [DON_GATO_Y_SU_PANDILLA].ESTADIA e
    JOIN [DON_GATO_Y_SU_PANDILLA].HOTEL ho ON ho.hote_id = e.esta_hotel
    JOIN [DON_GATO_Y_SU_PANDILLA].HABITACION ha ON ha.habi_numero = e.esta_habitacion AND ha.habi_hotel = e.esta_hotel
	WHERE e.esta_checkin BETWEEN @desde AND @hasta
    GROUP BY ha.habi_numero, ho.hote_nombre
    ORDER BY SUM(e.esta_duracion), COUNT(*)
END

GO
CREATE PROCEDURE [DON_GATO_Y_SU_PANDILLA].ESTADISTICO_5 @desde SMALLDATETIME, @hasta SMALLDATETIME
AS BEGIN
    SELECT TOP 5 c.clie_apellido, c.clie_nombre, SUM(fl.fact_line_monto * fl.fact_line_cantidad) / 20 + SUM(fl2.fact_line_monto * fl2.fact_line_cantidad) / 10
    FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE c
    JOIN [DON_GATO_Y_SU_PANDILLA].RESERVA r ON r.rese_cliente = c.clie_id
    JOIN [DON_GATO_Y_SU_PANDILLA].FACTURA f ON f.fact_reserva = r.rese_id AND f.fact_fecha BETWEEN @desde AND @hasta
    JOIN [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA fl ON fl.fact_numero = f.fact_numero AND fl.fact_es_consumible = 0
    JOIN [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA fl2 ON fl.fact_numero = f.fact_numero AND fl.fact_es_consumible = 1
    GROUP BY c.clie_apellido, c.clie_nombre
    ORDER BY SUM(fl.fact_line_monto * fl.fact_line_cantidad) / 20 + SUM(fl2.fact_line_monto * fl2.fact_line_cantidad) / 10
END
GO

USE [GD1C2018]

INSERT INTO [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO (tipo_nombre) VALUES ('DNI')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO (tipo_nombre) VALUES ('LE')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO (tipo_nombre) VALUES ('LC')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].TIPO_DOCUMENTO (tipo_nombre) VALUES ('PASAPORTE')

INSERT INTO [DON_GATO_Y_SU_PANDILLA].CIUDAD (ciud_nombre) 
SELECT DISTINCT Hotel_Ciudad FROM gd_esquema.Maestra

INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTRELLAS (estr_numero, estr_recargo)
SELECT DISTINCT Hotel_CantEstrella, Hotel_Recarga_Estrella FROM gd_esquema.Maestra

INSERT INTO [DON_GATO_Y_SU_PANDILLA].PAIS (pais_nombre)
SELECT DISTINCT Cliente_Nacionalidad FROM gd_esquema.Maestra

INSERT INTO [DON_GATO_Y_SU_PANDILLA].TIPO_HABITACION (tipo_id, tipo_descripcion, tipo_precio)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual FROM gd_esquema.Maestra
      
INSERT INTO [DON_GATO_Y_SU_PANDILLA].REGIMEN (regi_descripcion, regi_precio_base)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio FROM gd_esquema.Maestra

INSERT INTO [DON_GATO_Y_SU_PANDILLA].HOTEL (hote_nombre, hote_domicilio, hote_ciudad, hote_pais, hote_estrellas, hote_email, hote_telefono, hote_fecha_creacion)
SELECT DISTINCT CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)), CAST((Hotel_Calle + ' ' + CAST(Hotel_Nro_Calle AS VARCHAR(10))) AS VARCHAR(200)), 
	(SELECT ciud_id FROM [DON_GATO_Y_SU_PANDILLA].CIUDAD WHERE ciud_nombre = Hotel_Ciudad), 1, Hotel_CantEstrella, '', '', CURRENT_TIMESTAMP FROM gd_esquema.Maestra

SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE ON
INSERT INTO [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE (cons_id, cons_descripcion, cons_precio)
SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
  FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NOT NULL
DECLARE @max_id int
SELECT @max_id=MAX(cons_id) FROM [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE
DBCC CHECKIDENT ('[DON_GATO_Y_SU_PANDILLA].CONSUMIBLE', RESEED, @max_id)
SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE OFF

INSERT INTO [DON_GATO_Y_SU_PANDILLA].HABITACION (habi_hotel, habi_numero, habi_piso, habi_vista, habi_tipo, habi_habilitada)
SELECT DISTINCT hote_id, Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo, 1
  FROM gd_esquema.Maestra, [DON_GATO_Y_SU_PANDILLA].HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre

INSERT INTO [DON_GATO_Y_SU_PANDILLA].CLIENTE (clie_tipo_doc, clie_numero_doc, clie_nombre, clie_apellido, clie_email, clie_pais, clie_nacionalidad, clie_fecha_nac, clie_domicilio)
SELECT DISTINCT 1, Cliente_Pasaporte_Nro, Cliente_Nombre, Cliente_Apellido, Cliente_Mail, 1, (SELECT pais_id FROM [DON_GATO_Y_SU_PANDILLA].PAIS WHERE pais_nombre = Cliente_Nacionalidad), Cliente_Fecha_Nac,  
	CAST((RTRIM(LTRIM(Cliente_Dom_Calle)) + '|' + CAST(Cliente_Nro_Calle AS VARCHAR(10)) + '|' + CAST(Cliente_Piso AS VARCHAR(10)) + RTRIM(LTRIM(Cliente_Depto))) AS VARCHAR(200))
	FROM gd_esquema.Maestra

UPDATE [DON_GATO_Y_SU_PANDILLA].CLIENTE SET clie_habilitado = 0
	WHERE clie_email IN (SELECT cl.clie_email FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE cl GROUP BY cl.clie_email HAVING COUNT(cl.clie_email) > 1) AND
		clie_id NOT IN (SELECT MIN(cl.clie_id) FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE cl GROUP BY cl.clie_email HAVING COUNT(cl.clie_email) > 1)

INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADO (esta_descripcion) VALUES ('RESERVADO')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADO (esta_descripcion) VALUES ('MODIFICADO')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADO (esta_descripcion) VALUES ('CANCELADO')
INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADO (esta_descripcion) VALUES ('HOSPEDADO')

INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('ABM de Rol');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('ABM de Usuario');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('ABM de Cliente');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('ABM de Hotel');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('ABM de Habitación');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Generar una Reserva');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Modificar una Reserva');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Registrar Estadía(check-in)');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Registrar Estadía(check-out)');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Registrar Consumibles');
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD (func_nombre) VALUES ('Listado Estadístico');

INSERT INTO [DON_GATO_Y_SU_PANDILLA].ROL (rol_nombre, rol_habilitado) VALUES ('ADMINISTRADOR', 1);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].ROL (rol_nombre, rol_habilitado) VALUES ('RECEPCIONISTA', 1);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].ROL (rol_nombre, rol_habilitado) VALUES ('INVITADO', 1);

INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (1, 1);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (1, 2);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 3);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (1, 4);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (1, 5);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 6);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (3, 6);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 7);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (3, 7);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 8);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 9);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (2, 10);
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (1, 11);

INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO (usua_usuario, usua_password, usua_email, usua_rol_activo, usua_tipo_doc, usua_numero_doc, usua_nombre, usua_apellido, usua_fecha_nac)
	VALUES 
			('invitado', '', '', 3, 1, '00000000', 'INVITADO', 'INVITADO', CAST(0 AS smalldatetime)),
			('recepcionista', HASHBYTES('SHA2_256', '123456'), '', 2, 1, '00000000', 'RECEPCIONISTA', 'RECEPCIONISTA', CAST(0 AS smalldatetime)),
			('administrador', HASHBYTES('SHA2_256', '123456'), '', 1, 1, '00000000', 'ADMINISTRADOR', 'ADMINISTRADOR', CAST(0 AS smalldatetime)),
			('test', HASHBYTES('SHA2_256', '123456'), '', 1, 1, '00000000', 'TEST', 'TEST', CAST(0 AS smalldatetime)),
			('admin', HASHBYTES('SHA2_256', 'w23e'), '', 1, 1, '00000000', 'ADMINISTRADOR', 'ADMINISTRADOR', CAST(0 AS smalldatetime))

INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'invitado', hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL
	
INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'recepcionista', hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL
	
INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'administrador', hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL
	
INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'test', hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL
	
INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'admin', hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL
	
INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL (usua_usuario, rol_id) 
	SELECT 'admin', rol_id FROM [DON_GATO_Y_SU_PANDILLA].ROL

INSERT INTO [DON_GATO_Y_SU_PANDILLA].USUARIO_ROL (usua_usuario, rol_id) VALUES ('invitado', 3), ('recepcionista', 2), ('administrador', 1), ('test', 2), ('test', 3)

SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].RESERVA ON

/* Inserto las reservas, por lo que se desprende de los datos 
	TODAS las reservas se convirtieron en estadia
	Hay mas de una reserva con el mismo numero, esto se da porque 
	     hay un consumible por fila
	*/
INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA (rese_id, rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen, rese_cliente, rese_precio, rese_hotel, rese_habitaciones)
SELECT DISTINCT Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Habitacion_Tipo_Codigo, 
(SELECT regi_id FROM [DON_GATO_Y_SU_PANDILLA].REGIMEN WHERE regi_descripcion = Regimen_Descripcion), 
(SELECT clie_id FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE WHERE clie_email = Cliente_Mail AND clie_numero_doc = Cliente_Pasaporte_Nro),0,
(SELECT hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre),0
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL AND (SELECT COUNT(*) FROM gd_esquema.Maestra m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1

INSERT INTO [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO (rese_id, esta_id, usua_id, rese_esta_fecha)
	SELECT rese_id, 3, 'INVITADO', CAST(0 as smalldatetime) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA WHERE rese_id NOT IN (SELECT rese_id FROM [DON_GATO_Y_SU_PANDILLA].RESERVA_ESTADO)

SELECT @max_id=MAX(rese_id) FROM [DON_GATO_Y_SU_PANDILLA].RESERVA
DBCC CHECKIDENT ('[DON_GATO_Y_SU_PANDILLA].RESERVA', RESEED, @max_id)
SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].RESERVA OFF

INSERT INTO [DON_GATO_Y_SU_PANDILLA].ESTADIA (esta_hotel, esta_habitacion, esta_cliente, esta_reserva, esta_checkin, esta_duracion)
SELECT (SELECT hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre),
	(SELECT habi_numero FROM [DON_GATO_Y_SU_PANDILLA].HABITACION WHERE habi_numero = Habitacion_Numero AND habi_hotel = (SELECT hote_id FROM [DON_GATO_Y_SU_PANDILLA].HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre)),
	(SELECT clie_id FROM [DON_GATO_Y_SU_PANDILLA].CLIENTE WHERE clie_email = Cliente_Mail AND clie_numero_doc = Cliente_Pasaporte_Nro),
	Reserva_Codigo, Estadia_Fecha_Inicio, Estadia_Cant_Noches
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL AND (SELECT COUNT(*) FROM gd_esquema.Maestra m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1 AND Factura_Fecha IS NULL 

INSERT INTO [DON_GATO_Y_SU_PANDILLA].CONSUMIBLE_ESTADIA (rese_id, cons_id, cons_cantidad)
SELECT Reserva_Codigo, Consumible_Codigo, Item_Factura_Monto
FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NOT NULL 

INSERT INTO [DON_GATO_Y_SU_PANDILLA].FORMA_PAGO (form_nombre) VALUES ('Efectivo'), ('Cheque'), ('Tarjeta de Crédito');

INSERT INTO [DON_GATO_Y_SU_PANDILLA].COMODIDAD (como_descripcion) VALUES ('Toallas limpias'), ('WIFI'), ('Cama inflable');

/* El total de la factura no coincide con la suma de los items, pero es un problema que se arrastra de la tabla original */
SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].FACTURA ON
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA (fact_numero, fact_reserva, fact_forma_pago, fact_fecha, fact_total)
SELECT DISTINCT Factura_Nro, Reserva_Codigo, 1, Factura_Fecha, Factura_Total
FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NULL AND Factura_Total IS NOT NULL
SELECT @max_id=MAX(fact_numero) FROM [DON_GATO_Y_SU_PANDILLA].FACTURA
DBCC CHECKIDENT ('[DON_GATO_Y_SU_PANDILLA].FACTURA', RESEED, @max_id)
SET IDENTITY_INSERT [DON_GATO_Y_SU_PANDILLA].FACTURA OFF

/* Agrega los items de la factura que son Consumibles */
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
SELECT Factura_Nro, 1, Consumible_Descripcion, Item_Factura_Monto, Item_Factura_Cantidad
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL 
	AND (SELECT COUNT(*) FROM [GD1C2018].[gd_esquema].[Maestra] m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1
	AND (Consumible_Codigo IS NOT NULL AND Factura_Total IS NOT NULL)

/* Agrega los items de la factura que son cualquier cosa, menos consumibles */
INSERT INTO [DON_GATO_Y_SU_PANDILLA].FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
SELECT Factura_Nro, 0, '', Item_Factura_Monto, Item_Factura_Cantidad
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL 
	AND (SELECT COUNT(*) FROM [GD1C2018].[gd_esquema].[Maestra] m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1
	AND (Consumible_Codigo IS NULL AND Factura_Total IS NOT NULL)