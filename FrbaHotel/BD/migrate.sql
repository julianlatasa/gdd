USE [GD1C2018]

INSERT INTO TIPO_DOCUMENTO (tipo_nombre) VALUES ('PASAPORTE')

INSERT INTO PAIS (pais_nombre) VALUES ('ARGENTINA')

INSERT INTO CIUDAD (ciud_nombre) 
SELECT DISTINCT Hotel_Ciudad FROM gd_esquema.Maestra

INSERT INTO ESTRELLAS (estr_numero, estr_recargo)
SELECT DISTINCT Hotel_CantEstrella, Hotel_Recarga_Estrella FROM gd_esquema.Maestra

INSERT INTO NACIONALIDAD (naci_descripcion)
SELECT DISTINCT Cliente_Nacionalidad FROM gd_esquema.Maestra

INSERT INTO TIPO_HABITACION (tipo_id, tipo_descripcion, tipo_precio)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual FROM gd_esquema.Maestra
      
INSERT INTO REGIMEN (regi_descripcion, regi_precio_base)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio FROM gd_esquema.Maestra

INSERT INTO HOTEL (hote_nombre, hote_domicilio, hote_ciudad, hote_pais, hote_estrellas, hote_email, hote_telefono, hote_fecha_creacion)
SELECT DISTINCT CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)), CAST((Hotel_Calle + ' ' + CAST(Hotel_Nro_Calle AS VARCHAR(10))) AS VARCHAR(200)), 
	(SELECT ciud_id FROM CIUDAD WHERE ciud_nombre = Hotel_Ciudad), 1, Hotel_CantEstrella, '', '', CURRENT_TIMESTAMP FROM gd_esquema.Maestra

SET IDENTITY_INSERT CONSUMIBLE ON
INSERT INTO CONSUMIBLE (cons_id, cons_descripcion, cons_precio)
SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
  FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NOT NULL
DECLARE @max_id int
SELECT @max_id=MAX(cons_id) FROM CONSUMIBLE
DBCC CHECKIDENT ('CONSUMIBLE', RESEED, @max_id)
SET IDENTITY_INSERT CONSUMIBLE OFF

INSERT INTO HABITACION (habi_hotel, habi_numero, habi_piso, habi_vista, habi_tipo, habi_habilitada)
SELECT DISTINCT hote_id, Habitacion_Numero,Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo, 1
  FROM gd_esquema.Maestra, HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre

INSERT INTO CLIENTE (clie_tipo_doc, clie_numero_doc, clie_nombre, clie_apellido, clie_email, clie_pais, clie_nacionalidad, clie_fecha_nac)
SELECT DISTINCT 1, Cliente_Pasaporte_Nro, Cliente_Nombre, Cliente_Apellido, Cliente_Mail, 1, (SELECT naci_id FROM NACIONALIDAD WHERE naci_descripcion = Cliente_Nacionalidad), Cliente_Fecha_Nac FROM gd_esquema.Maestra

UPDATE CLIENTE SET clie_habilitado = 0
	WHERE clie_email IN (SELECT cl.clie_email FROM CLIENTE cl GROUP BY cl.clie_email HAVING COUNT(cl.clie_email) > 1) AND
		clie_id NOT IN (SELECT MIN(cl.clie_id) FROM CLIENTE cl GROUP BY cl.clie_email HAVING COUNT(cl.clie_email) > 1)

INSERT INTO ESTADO (esta_descripcion) VALUES ('RESERVADO')
INSERT INTO ESTADO (esta_descripcion) VALUES ('CANCELADO')
INSERT INTO ESTADO (esta_descripcion) VALUES ('HOSPEDADO')

INSERT INTO ROL (rol_id, rol_nombre, rol_habilitado) VALUES (1,'INVITADO', 1)
INSERT INTO PERSONA (pers_tipo_doc, pers_numero_doc, pers_nombre, pers_apellido, pers_fecha_nac) 
	VALUES (1, '00000000', 'INVITADO', 'INVITADO', CAST(0 AS smalldatetime))
INSERT INTO USUARIO (usua_usuario, usua_password, usua_email, usua_rol_activo, usua_hotel_activo, usua_intentos_login, usua_habilitado, usua_tipo_doc, usua_numero_doc)
	VALUES ('INVITADO', '', '', 1, 1, 0, 1, 1, '00000000')

INSERT INTO USUARIO_HOTEL (usua_usuario, hote_id) 
	SELECT 'INVITADO', hote_id FROM HOTEL

SET IDENTITY_INSERT RESERVA ON

INSERT INTO RESERVA (rese_id, rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen, rese_cliente, rese_precio, rese_hotel)
SELECT DISTINCT Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Habitacion_Tipo_Codigo, 
(SELECT regi_id FROM REGIMEN WHERE regi_descripcion = Regimen_Descripcion), 
(SELECT clie_id FROM CLIENTE WHERE clie_email = Cliente_Mail AND clie_numero_doc = Cliente_Pasaporte_Nro),0,
(SELECT hote_id FROM HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre)
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NULL AND (SELECT COUNT(*) FROM gd_esquema.Maestra m WHERE m.Reserva_Codigo = Reserva_Codigo) = 1

INSERT INTO RESERVA_ESTADO (rese_id, esta_id, usua_id, rese_esta_fecha)
	SELECT rese_id, 1, 'INVITADO', CAST(0 as smalldatetime) FROM RESERVA

INSERT INTO RESERVA (rese_id, rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen, rese_cliente, rese_precio, rese_hotel, rese_habitaciones)
SELECT DISTINCT Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Habitacion_Tipo_Codigo, 
(SELECT regi_id FROM REGIMEN WHERE regi_descripcion = Regimen_Descripcion), 
(SELECT clie_id FROM CLIENTE WHERE clie_email = Cliente_Mail AND clie_numero_doc = Cliente_Pasaporte_Nro),0,
(SELECT hote_id FROM HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre),0
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL AND (SELECT COUNT(*) FROM gd_esquema.Maestra m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1

INSERT INTO RESERVA_ESTADO (rese_id, esta_id, usua_id, rese_esta_fecha)
	SELECT rese_id, 3, 'INVITADO', CAST(0 as smalldatetime) FROM RESERVA WHERE rese_id NOT IN (SELECT rese_id FROM RESERVA_ESTADO)

SELECT @max_id=MAX(rese_id) FROM RESERVA
DBCC CHECKIDENT ('RESERVA', RESEED, @max_id)
SET IDENTITY_INSERT RESERVA OFF

INSERT INTO ESTADIA (esta_hotel, esta_habitacion, esta_cliente, esta_reserva, esta_checkin, esta_duracion)
SELECT (SELECT hote_id FROM HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre),
	(SELECT habi_numero FROM HABITACION WHERE habi_numero = Habitacion_Numero AND habi_hotel = (SELECT hote_id FROM HOTEL WHERE CAST((RTRIM(Hotel_Ciudad) + ' - ' + Hotel_Calle) AS VARCHAR(100)) = hote_nombre)),
	(SELECT clie_id FROM CLIENTE WHERE clie_email = Cliente_Mail AND clie_numero_doc = Cliente_Pasaporte_Nro),
	Reserva_Codigo, Estadia_Fecha_Inicio, Estadia_Cant_Noches
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL AND (SELECT COUNT(*) FROM gd_esquema.Maestra m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1 AND Factura_Fecha IS NULL 

INSERT INTO CONSUMIBLE_ESTADIA (rese_id, cons_id, cons_cantidad)
SELECT Reserva_Codigo, Consumible_Codigo, Item_Factura_Monto
FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NOT NULL 

INSERT INTO FORMA_PAGO (form_id, form_nombre) VALUES (1, 'Efectivo')

SET IDENTITY_INSERT FACTURA ON
INSERT INTO FACTURA (fact_numero, fact_reserva, fact_forma_pago, fact_fecha, fact_total)
SELECT Factura_Nro, Reserva_Codigo, 1, Factura_Fecha, Factura_Total
FROM gd_esquema.Maestra WHERE Consumible_Codigo IS NULL AND Factura_Total IS NOT NULL
SELECT @max_id=MAX(fact_numero) FROM FACTURA
DBCC CHECKIDENT ('FACTURA', RESEED, @max_id)
SET IDENTITY_INSERT FACTURA OFF

INSERT INTO FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
SELECT Factura_Nro, 1, Consumible_Descripcion, Item_Factura_Monto, Item_Factura_Cantidad
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL 
	AND (SELECT COUNT(*) FROM [GD1C2018].[gd_esquema].[Maestra] m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1
	AND (Consumible_Codigo IS NOT NULL AND Factura_Total IS NOT NULL)

INSERT INTO FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
SELECT Factura_Nro, 0, '', Item_Factura_Monto, Item_Factura_Cantidad
FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL 
	AND (SELECT COUNT(*) FROM [GD1C2018].[gd_esquema].[Maestra] m WHERE m.Reserva_Codigo = Reserva_Codigo) > 1
	AND (Consumible_Codigo IS NULL AND Factura_Total IS NOT NULL)