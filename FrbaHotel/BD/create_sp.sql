USE [GD1C2018]
-- PUNTO 1 --

GO
CREATE PROCEDURE ROL_Crear @nombreRol VARCHAR(100)
AS BEGIN
    INSERT INTO ROL (rol_nombre) VALUES (@nombreRol)
    SELECT SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE ROL_Modificar @idRol INT, @nombreRol VARCHAR(100), @habilitado CHAR(1)
AS BEGIN
    UPDATE ROL SET rol_nombre = @nombreRol, rol_habilitado = @habilitado WHERE rol_id = @idRol
END

GO
CREATE PROCEDURE ROL_Buscar @nombreRol VARCHAR(100)
AS BEGIN
    SELECT * FROM ROL WHERE rol_nombre LIKE '%' + @nombreRol + '%'
END

GO
CREATE PROCEDURE ROL_Asignar_Funcionalidad @idRol INT, @idFuncionalidad INT
AS BEGIN
    INSERT INTO FUNCIONALIDAD_ROL (rol_id, func_id) VALUES (@idRol, @idFuncionalidad)
END

GO
CREATE PROCEDURE ROL_Eliminar_Funcionalidad @idRol INT, @idFuncionalidad INT
AS BEGIN
    DELETE FROM FUNCIONALIDAD_ROL WHERE rol_id = @idRol AND func_id = @idFuncionalidad
END


-- PUNTO 2 --


GO
CREATE PROCEDURE USUARIO_Login @usuario CHAR(50), @contrasena VARCHAR(50)
AS BEGIN
    IF (SELECT COUNT(*) FROM USUARIO WHERE usua_usuario = @usuario AND usua_password = HASHBYTES('SHA2_256', @contrasena) AND usua_habilitado = 1) = 0
	BEGIN
		UPDATE USUARIO SET usua_intentos_login += 1 WHERE usua_usuario = @usuario

		IF (SELECT usua_intentos_login FROM USUARIO WHERE usua_usuario = @usuario) > 2
		BEGIN
			UPDATE USUARIO SET usua_habilitado = 1 WHERE usua_usuario = @usuario
			RAISERROR(1, 1, 1, 'Usuario bloqueado por reiterados intentos')
		END

        RAISERROR(1, 1, 1, 'Usuario no encontrado')
	END

    SELECT usua_usuario FROM USUARIO WHERE usua_usuario = @usuario AND usua_password = HASHBYTES('SHA2_256', @contrasena)
END

GO
CREATE PROCEDURE GUEST_Login
AS BEGIN
    SELECT f.func_id, f.func_nombre
    FROM FUNCIONALIDAD f
    JOIN ROL r ON r.rol_nombre = 'INVITADO'
    JOIN FUNCIONALIDAD_ROL fr ON fr.rol_id = r.rol_id
    WHERE f.func_id = fr.func_id
END


-- PUNTO 3 --


GO
CREATE PROCEDURE USUARIO_Crear @usuario CHAR(50), @contrasena VARCHAR(50), @idRol INT, @nombre VARCHAR(100), 
                                @apellido VARCHAR(100), @tipoDocumento INT, @nroDocumento VARCHAR(10), @email VARCHAR(150),
                                @telefono VARCHAR(50), @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME, @idHotel INT
AS BEGIN
    IF (SELECT COUNT(*) FROM USUARIO WHERE usua_usuario = @usuario) > 0
	BEGIN
        RAISERROR(1, 1, 1, 'Usuario ya existe')
	END

    INSERT INTO PERSONA (pers_tipo_doc, pers_numero_doc, pers_nombre, pers_apellido, pers_domicilio, pers_telefono, pers_fecha_nac)
                    VALUES(@tipoDocumento, @nroDocumento, @nombre, @apellido, @domicilio, @telefono, @fechaNacimiento)
    INSERT INTO USUARIO (usua_usuario, usua_password, usua_email, usua_tipo_doc, usua_numero_doc, usua_rol_activo, usua_hotel_activo)
                VALUES(@usuario, HASHBYTES('SHA2_256', @contrasena), @email, @tipoDocumento, @nroDocumento, @idRol, @idHotel)

    SELECT SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE USUARIO_Modificar @usuario CHAR(50), @contrasena VARCHAR(50), @idRol INT, @nombre VARCHAR(100), 
                                @apellido VARCHAR(100), @tipoDocumento INT, @nroDocumento VARCHAR(10), @email VARCHAR(150),
                                @telefono VARCHAR(50), @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME, @idHotel INT,
                                @habilitado CHAR(1)
AS BEGIN
    DECLARE @oldTipoDocumento INT, @oldNroDocumento VARCHAR(10)
    SELECT @oldNroDocumento = usua_tipo_doc, @oldNroDocumento = usua_numero_doc FROM USUARIO WHERE usua_usuario = @usuario

    DELETE FROM PERSONA WHERE pers_tipo_doc = @oldTipoDocumento AND pers_numero_doc = @oldNroDocumento

    INSERT INTO PERSONA (pers_tipo_doc, pers_numero_doc, pers_nombre, pers_apellido, pers_telefono, pers_domicilio, pers_fecha_nac) 
    VALUES (@tipoDocumento, @nroDocumento, @nombre, @apellido, @telefono, @domicilio, @fechaNacimiento)
    UPDATE USUARIO SET usua_password = HASHBYTES('SHA2_256', @contrasena), usua_tipo_doc = @tipoDocumento, usua_numero_doc = @nroDocumento, 
                        usua_habilitado = @habilitado, usua_rol_activo = @idRol, usua_hotel_activo = @idHotel, usua_email = @email, usua_intentos_login = 0
                    WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE USUARIO_Buscar @usuario CHAR(50), @idRol INT, @idHotel INT
AS BEGIN
    SELECT * FROM USUARIO WHERE usua_usuario LIKE '%' + @usuario + '%' OR
                                usua_rol_activo = @idRol OR
                                usua_hotel_activo = @idHotel
END

GO
CREATE PROCEDURE USUARIO_Asignar_Rol_Activo @usuario CHAR(50), @idRol INT
AS BEGIN
    UPDATE USUARIO SET usua_rol_activo = @idRol WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE USUARIO_Asignar_Hotel_Activo @usuario CHAR(50), @idHotel INT
AS BEGIN
    UPDATE USUARIO SET usua_hotel_activo = @idHotel WHERE usua_usuario = @usuario
END

GO
CREATE PROCEDURE USUARIO_Asignar_Rol @usuario CHAR(50), @idRol INT
AS BEGIN
    INSERT INTO USUARIO_ROL(usua_usuario, rol_id) VALUES (@usuario, @idRol)
END

GO
CREATE PROCEDURE USUARIO_Eliminar_Rol @usuario CHAR(50), @idRol INT
AS BEGIN
    DELETE FROM USUARIO_ROL WHERE usua_usuario = @usuario AND rol_id = @idRol
END

GO
CREATE PROCEDURE USUARIO_Asignar_Hotel @usuario CHAR(50), @idHotel INT
AS BEGIN
    INSERT INTO USUARIO_HOTEL(usua_usuario, hote_id) VALUES (@usuario, @idHotel)
END

GO
CREATE PROCEDURE USUARIO_Eliminar_Hotel @usuario CHAR(50), @idHotel INT
AS BEGIN
    DELETE FROM USUARIO_HOTEL WHERE usua_usuario = @usuario AND hote_id = @idHotel
END


-- PUNTO 4 --


GO
CREATE PROCEDURE CLIENTE_Crear @tipoDocumento INT, @nroDocumento VARCHAR(10), @nombre VARCHAR(100),
                                @apellido VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @fechaNacimiento SMALLDATETIME, @pais INT, @nacionalidad INT
AS BEGIN
	IF (SELECT COUNT(*) FROM CLIENTE WHERE clie_email = @email) > 0
	BEGIN
		RAISERROR(1, 1, 1, 'Email duplicado')
	END

	INSERT INTO PERSONA (pers_tipo_doc, pers_numero_doc, pers_nombre, pers_apellido, pers_telefono, pers_domicilio, pers_fecha_nac) 
	VALUES (@tipoDocumento, @nroDocumento, @nombre, @apellido, @telefono, @domicilio, @fechaNacimiento)
	INSERT INTO CLIENTE (clie_tipo_doc, clie_numero_doc, clie_nombre, clie_apellido, clie_email, clie_domicilio, clie_fecha_nac, clie_pais, clie_nacionalidad)
	VALUES (@tipoDocumento, @nroDocumento, @nombre, @apellido, @email, @domicilio, @fechaNacimiento, @pais, @nacionalidad)
END

GO
CREATE PROCEDURE CLIENTE_Modificar @idCliente INT, @tipoDocumento INT, @nroDocumento VARCHAR(10), @nombre VARCHAR(100),
                                    @apellido VARCHAR(100), @email varchar(150),@telefono VARCHAR(50), @domicilio VARCHAR(200), 
                                    @fechaNacimiento SMALLDATETIME, @pais INT, @nacionalidad INT, @habilitado CHAR(1)
AS BEGIN
	DECLARE @oldTipoDocumento INT, @oldNroDocumento VARCHAR(10)
	SELECT @oldTipoDocumento = clie_tipo_doc, @oldNroDocumento = clie_numero_doc FROM CLIENTE WHERE clie_id = @idCliente

	DELETE FROM PERSONA WHERE pers_tipo_doc = @oldTipoDocumento AND pers_numero_doc = @oldNroDocumento

	INSERT INTO PERSONA (pers_tipo_doc, pers_numero_doc, pers_nombre, pers_apellido, pers_telefono, pers_domicilio, pers_fecha_nac) 
	VALUES (@tipoDocumento, @nroDocumento, @nombre, @apellido, @telefono, @domicilio, @fechaNacimiento)
	UPDATE CLIENTE SET clie_tipo_doc = @tipoDocumento, clie_numero_doc = @nroDocumento, clie_nombre = @nombre, clie_apellido = @apellido, 
						clie_email = @email, clie_domicilio = @domicilio, clie_fecha_nac = @fechaNacimiento, clie_pais = @pais, clie_nacionalidad = @nacionalidad,
						clie_habilitado = @habilitado
					WHERE clie_id = @idCliente
END

GO
CREATE PROCEDURE CLIENTE_Buscar @nombre VARCHAR(100), @apellido VARCHAR(100), @tipoDocumento INT, @nroDocumento VARCHAR(10), @email VARCHAR(150)
AS BEGIN
    SELECT * FROM CLIENTE WHERE (clie_tipo_doc = @tipoDocumento AND
                                clie_numero_doc = @nroDocumento) OR
                                clie_email = @email OR
                                clie_nombre LIKE '%' + @nombre + '%' OR 
                                clie_apellido LIKE '%' + @apellido + '%'
END


-- PUNTO 5 --


GO
CREATE PROCEDURE HOTEL_Crear @nombre VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @pais INT, @ciudad INT, @estrellas CHAR(1)
AS BEGIN
	INSERT INTO HOTEL (hote_nombre, hote_email, hote_telefono, hote_domicilio, hote_ciudad, hote_pais, hote_estrellas)
	VALUES (@nombre, @email, @telefono, @domicilio, @ciudad, @pais, @estrellas)
	SELECT SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE HOTEL_Modificar @idHotel INT, @nombre VARCHAR(100), @email VARCHAR(150), @telefono VARCHAR(50), 
                                @domicilio VARCHAR(200), @pais INT, @ciudad INT, @estrellas CHAR(1)
AS BEGIN
	UPDATE HOTEL SET hote_nombre = @nombre, hote_email = @email, hote_telefono = @telefono, hote_domicilio = @domicilio, 
					hote_ciudad = @ciudad, hote_pais = @pais, hote_estrellas = @estrellas
					WHERE hote_id = @idHotel
END

GO
CREATE PROCEDURE HOTEL_Buscar @nombre VARCHAR(100), @pais INT, @ciudad INT, @estrellas CHAR(1)
AS BEGIN
    SELECT * FROM HOTEL WHERE hote_estrellas = @estrellas OR
                                hote_nombre LIKE '%' + @nombre + '%' OR 
                                hote_pais = @pais OR
                                hote_ciudad = @ciudad
END

GO
CREATE PROCEDURE HOTEL_Asignar_Regimen @idHotel INT, @idRegimen INT
AS BEGIN
    INSERT INTO HOTEL_REGIMEN(hote_id, regi_id) VALUES (@idHotel, @idRegimen)
END

GO
CREATE PROCEDURE HOTEL_Eliminar_Regimen @idHotel INT, @idRegimen INT
AS BEGIN
    IF(SELECT COUNT(*) FROM RESERVA r 
        JOIN ESTADO e ON e.esta_descripcion = 'RESERVADO'
        JOIN RESERVA_ESTADO re ON re.rese_id = r.rese_id AND re.esta_id = e.esta_id 
        WHERE r.rese_regimen = @idRegimen) > 
        (SELECT COUNT(*) FROM RESERVA r 
        JOIN ESTADO e ON e.esta_descripcion = 'EFECTIVIZADA' OR e.esta_descripcion = 'CANCELADO'
        JOIN RESERVA_ESTADO re ON re.rese_id = r.rese_id AND re.esta_id = e.esta_id 
        WHERE r.rese_regimen = @idRegimen)
        RAISERROR(1, 1, 1, 'Existen reservas utilizando ese régimen')

    IF(SELECT COUNT(*) FROM ESTADIA e
        JOIN HOTEL_REGIMEN hr ON hr.regi_id = @idRegimen AND hr.hote_id = @idHotel
        WHERE e.esta_hotel = @idHotel AND e.esta_checkout IS NOT NULL) > 0
        RAISERROR(1, 1, 1, 'Existe un huésped alojado bajo este régimen')

    DELETE FROM HOTEL_REGIMEN WHERE hote_id = @idHotel AND regi_id = @idRegimen
END

GO
CREATE PROCEDURE HOTEL_Asignar_Baja_Temporal @idHotel INT, @fechaDesde SMALLDATETIME, @fechaHasta SMALLDATETIME, @descripcion VARCHAR(2000)
AS BEGIN
    INSERT INTO HOTEL_BAJA_TEMPORAL VALUES (@idHotel, @fechaDesde, @fechaHasta, @descripcion)
END


-- PUNTO 6 --


GO
CREATE PROCEDURE HABITACION_Crear @idHotel INT, @nroHabitacion INT, @piso INT, @vista CHAR(1), @tipo INT, @descripcion VARCHAR(1000)
AS BEGIN
    IF(SELECT COUNT(*) FROM HABITACION WHERE habi_hotel = @idHotel AND habi_numero = @nroHabitacion) > 0
        RAISERROR(1, 1, 1, 'Habitación duplicada')

    INSERT INTO HABITACION (habi_hotel, habi_numero, habi_piso, habi_vista, habi_tipo, habi_descripcion)
    VALUES (@idHotel, @nroHabitacion, @piso, @vista, @tipo, @descripcion)
END
GO

GO
CREATE PROCEDURE HABITACION_Modificar @idHotel INT, @nroHabitacion INT, @piso INT, @vista CHAR(1), @descripcion VARCHAR(1000), @habilitado CHAR(1)
AS BEGIN
    UPDATE HABITACION SET habi_piso = @piso, habi_vista = @vista, habi_descripcion = @descripcion
    WHERE habi_hotel = @idHotel AND habi_numero = @nroHabitacion
END
GO

GO
CREATE PROCEDURE HABITACION_Buscar @idHotel INT
AS BEGIN
    SELECT * FROM HABITACION WHERE habi_hotel = @idHotel
END

GO
CREATE PROCEDURE HABITACION_Asignar_Comodidad @idHotel INT, @nroHabitacion INT, @idComodidad INT
AS BEGIN
    INSERT INTO HABITACION_COMODIDAD(como_id, habi_hotel, habi_numero) VALUES (@idComodidad, @idHotel, @nroHabitacion)
END

GO
CREATE PROCEDURE HABITACION_Eliminar_Comodidad @idHotel INT, @nroHabitacion INT, @idComodidad INT
AS BEGIN
    DELETE FROM HABITACION_COMODIDAD WHERE como_id = @idComodidad AND habi_hotel = @idHotel AND habi_numero = @nroHabitacion
END


-- PUNTO 8 --


GO
CREATE PROCEDURE RESERVA_Crear @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @idRegimen INT, @precio INT, @habitaciones INT, @idCliente INT = NULL
AS BEGIN
    DECLARE @idReserva INT, @idEstadoReservado INT

    INSERT INTO RESERVA (rese_hotel, rese_desde, rese_duracion, rese_tipo_habitacion, rese_regimen, rese_cliente, rese_habitaciones, rese_precio)
    VALUES (@idHotel, @fechaDesde, @duracion, @tipoHabitacion, @idRegimen, @idCliente, @habitaciones, @precio)

    SELECT @idReserva = SCOPE_IDENTITY()
    SELECT @idEstadoReservado = esta_id FROM ESTADO WHERE esta_descripcion = 'RESERVADO'

    INSERT INTO RESERVA_ESTADO (rese_id, esta_id) VALUES (@idReserva, @idEstadoReservado)

    SELECT @idReserva
END

GO
CREATE PROCEDURE RESERVA_Modificar @idReserva INT, @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @idRegimen INT, @precio INT, @habitaciones INT, @idCliente INT = NULL
AS BEGIN
    DECLARE @idEstadoModificado INT,
            @idEstadoEfectivizado INT = (SELECT esta_id FROM ESTADO WHERE esta_descripcion = 'EFECTIVIZADO')

    IF (SELECT COUNT(*) FROM RESERVA_ESTADO WHERE esta_id = @idEstadoEfectivizado AND rese_id = @idReserva) > 0
	BEGIN
        RAISERROR(1, 1, 1, 'Esta reserva ya fue efectivizada')
	END

    UPDATE RESERVA SET rese_desde = @fechaDesde, rese_duracion = @duracion, rese_precio = @precio, rese_regimen = @idRegimen, 
                        rese_tipo_habitacion = @tipoHabitacion, rese_hotel = @idHotel, rese_habitaciones = @habitaciones
                    WHERE rese_id = @idReserva

    SELECT @idEstadoModificado = esta_id FROM ESTADO WHERE esta_descripcion = 'MODIFICADO'

    INSERT INTO RESERVA_ESTADO (rese_id, esta_id) VALUES (@idReserva, @idEstadoModificado)
END

GO
CREATE PROCEDURE RESERVA_Actualizar_Cliente @idReserva INT, @idCliente INT
AS BEGIN
    UPDATE RESERVA SET rese_cliente = @idCliente WHERE rese_id = @idReserva
END

GO
CREATE PROCEDURE RESERVA_Buscar @idHotel INT, @fechaDesde SMALLDATETIME, @duracion INT, @tipoHabitacion INT, @nroPersonas INT, @idUsuario INT, @idReserva INT = NULL, @idRegimen VARCHAR(100) = NULL
AS BEGIN
    DECLARE @cIdReserva INT
    DECLARE cReservas CURSOR FOR SELECT rese_id FROM RESERVA WHERE DATEDIFF(dayofyear, rese_desde, GETDATE()) > 0

    OPEN cReservas
    FETCH NEXT FROM cReservas INTO @cIdReserva
    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC RESERVA_Cancelar @cIdReserva, 'NO-SHOW', @idUsuario
        FETCH NEXT FROM cReservas INTO @cIdReserva
    END

    CLOSE cReservas
    DEALLOCATE cReservas

    SELECT r.regi_id, r.regi_descripcion, r.regi_precio_base * @nroPersonas + e.estr_recargo AS precio, COUNT(*) AS habitaciones
    FROM HOTEL_REGIMEN hr
    JOIN REGIMEN r ON r.regi_habilitado = 1 AND r.regi_id = hr.regi_id
    JOIN HABITACION h ON h.habi_habilitada = 1 AND h.habi_hotel = @idHotel
    JOIN RESERVA re ON DATEADD(dayofyear, re.rese_duracion, re.rese_desde) < @fechaDesde AND re.rese_id <> @idReserva
    JOIN HOTEL ho ON ho.hote_id = @idHotel
    JOIN ESTRELLAS e ON e.estr_numero = ho.hote_estrellas
    WHERE hr.hote_id = @idHotel AND ((@idRegimen IS NULL AND hr.regi_id IN (SELECT regi_id FROM HOTEL_REGIMEN WHERE hote_id = @idHotel)) OR (@idRegimen IS NOT NULL AND hr.regi_id = @idRegimen))
    GROUP BY r.regi_id, r.regi_descripcion, r.regi_precio_base * @nroPersonas + e.estr_recargo
END


-- PUNTO 9 --


GO
CREATE PROCEDURE RESERVA_Cancelar @idReserva INT, @motivo VARCHAR(100), @idUsuario INT
AS BEGIN
    DECLARE @idEstadoCancelado INT = (SELECT esta_id FROM ESTADO WHERE esta_descripcion = 'CANCELADO')

    IF DATEDIFF(dayofyear, (SELECT rese_desde FROM RESERVA WHERE rese_id = @idReserva), GETDATE()) > 1
	BEGIN
        RAISERROR(1, 1, 1, 'Ya no puede cancelarse la reserva')
	END

    UPDATE RESERVA SET rese_fecha_cancelacion = GETDATE(), rese_motivo_cancelacion = @motivo, rese_usuario_cancelacion = @idUsuario

    INSERT INTO RESERVA_ESTADO (rese_id, esta_id) VALUES (@idReserva, @idEstadoCancelado)
END


-- PUNTO 10 --


GO
CREATE PROCEDURE ESTADIA_Crear @idHotel INT, @nroHabitacion INT, @idCliente INT, @idReserva INT, @idUsuario INT
AS BEGIN
    DECLARE @idEstadoEfectivizado INT = (SELECT esta_id FROM ESTADO WHERE esta_descripcion = 'EFECTIVIZADO')

    IF DATEDIFF(dayofyear, (SELECT rese_desde FROM RESERVA WHERE rese_id = @idReserva), GETDATE()) > 0
	BEGIN
        RAISERROR(1, 1, 1, 'Ya no puede efectivizar la reserva')
	END

    IF (SELECT rese_habitaciones FROM RESERVA WHERE rese_id = @idReserva) > (SELECT COUNT(DISTINCT esta_habitacion) FROM ESTADIA WHERE esta_reserva = @idReserva)
    BEGIN
	    RAISERROR(1, 1, 1, 'Alcanzó el nro máximo de habitaciones para la reserva')
	END

    INSERT INTO ESTADIA (esta_hotel, esta_habitacion, esta_cliente, esta_reserva, esta_checkin, esta_usua_checkin)
    VALUES (@idHotel, @nroHabitacion, @idCliente, @idReserva, GETDATE(), @idUsuario)

    IF (SELECT COUNT(*) FROM RESERVA_ESTADO WHERE esta_id = @idEstadoEfectivizado) = 0
	BEGIN
        INSERT INTO RESERVA_ESTADO (rese_id, esta_id) VALUES (@idReserva, @idEstadoEfectivizado)
	END
END

GO
CREATE PROCEDURE ESTADIA_Checkout @idHotel INT, @nroHabitacion INT, @idCliente INT, @idReserva INT, @idUsuario INT
AS BEGIN
    UPDATE ESTADIA SET esta_checkout = GETDATE(), esta_usua_checkout = @idUsuario 
    WHERE esta_hotel = @idHotel AND esta_habitacion = @nroHabitacion AND esta_cliente = @idCliente AND esta_reserva = @idReserva
END


-- PUNTO 11 --


GO
CREATE PROCEDURE CONSUMIBLE_Crear @idReserva INT, @idConsumible INT, @cantidad INT
AS BEGIN
    INSERT INTO CONSUMIBLE_ESTADIA (rese_id, cons_id, cons_cantidad) VALUES (@idReserva, @idConsumible, @cantidad)
END


-- PUNTO 12 --


GO
CREATE PROCEDURE FACTURACION_Crear @idReserva INT, @formaPago INT, @idCliente INT
AS BEGIN
    DECLARE @idFactura INT, @consId INT, @consCantidad INT, @consTotal INT, @consDescripcion VARCHAR(100), @consPrecio INT,
            @diasUsados INT, @duracion INT, @precio INT
    DECLARE cConsumibles CURSOR FOR SELECT cons_id, cons_cantidad FROM CONSUMIBLE_ESTADIA WHERE rese_id = @idReserva

    IF (SELECT rese_cliente FROM RESERVA WHERE rese_id = @idReserva) <> @idCliente
	BEGIN
        RAISERROR(1, 1, 1, 'El cliente no es quien reservó')
	END

    INSERT INTO FACTURA (fact_reserva, fact_forma_pago, fact_total) VALUES (@idReserva, @formaPago, 0)
    SELECT @idFactura = SCOPE_IDENTITY()

    OPEN cConsumibles
    FETCH NEXT FROM cConsumibles INTO @consId, @consCantidad
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @consDescripcion = cons_descripcion, @consPrecio = cons_precio FROM CONSUMIBLE WHERE cons_id = @consId
        SET @consTotal += (SELECT SUM(cons_precio) * @consCantidad FROM CONSUMIBLE WHERE cons_id = @consId)
        INSERT INTO FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
        VALUES (@idFactura, 1, @consDescripcion, @consPrecio, @consCantidad)
        FETCH NEXT FROM cConsumibles INTO @consId, @consCantidad
    END

    SELECT @diasUsados = DATEDIFF(dayofyear, esta_checkin, esta_checkout), @duracion = esta_duracion FROM ESTADIA WHERE esta_cliente = @idCliente AND esta_reserva = @idReserva
    SELECT @precio = rese_precio FROM RESERVA WHERE rese_id = @idReserva
    INSERT INTO FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
    VALUES (@idFactura, 0, CONCAT(@diasUsados, ' de hospedaje'), @precio * @diasUsados / @duracion, @diasUsados)

    IF (SELECT DATEDIFF(dayofyear, esta_checkin, esta_checkout) FROM ESTADIA WHERE esta_cliente = @idCliente AND esta_reserva = @idReserva) < @duracion
	BEGIN
        INSERT INTO FACTURA_LINEA (fact_numero, fact_es_consumible, fact_line_descripcion, fact_line_monto, fact_line_cantidad)
        VALUES (@idFactura, 0, CONCAT(@duracion - @diasUsados, ' de reserva'), @precio * (@duracion - @diasUsados) / @duracion, @duracion - @diasUsados)
	END
END


-- PUNTO 13 --


GO
CREATE PROCEDURE ESTADISTICO_1
AS BEGIN
    SELECT TOP 5 h.hote_nombre, COUNT(r.rese_id) FROM HOTEL h
    JOIN RESERVA r ON r.rese_fecha_cancelacion IS NOT NULL
    GROUP BY h.hote_nombre
    ORDER BY COUNT(r.rese_id)
END

GO
CREATE PROCEDURE ESTADISTICO_2
AS BEGIN
    SELECT TOP 5 h.hote_nombre, SUM(c.cons_cantidad) FROM HOTEL h
    JOIN RESERVA r ON r.rese_hotel = h.hote_id
    JOIN CONSUMIBLE_ESTADIA c ON c.rese_id = r.rese_id
    GROUP BY h.hote_nombre
    ORDER BY SUM(c.cons_cantidad)
END

GO
CREATE PROCEDURE ESTADISTICO_3
AS BEGIN
    SELECT TOP 5 h.hote_nombre, SUM(DATEDIFF(dayofyear, hb.baja_desde, hb.baja_hasta)) FROM HOTEL h
    JOIN HOTEL_BAJA_TEMPORAL hb ON hb.baja_hotel = h.hote_id
    GROUP BY h.hote_nombre
    ORDER BY SUM(DATEDIFF(dayofyear, hb.baja_desde, hb.baja_hasta))
END

GO
CREATE PROCEDURE ESTADISTICO_4
AS BEGIN
    SELECT TOP 5 ha.habi_numero, ho.hote_nombre, SUM(e.esta_duracion), COUNT(*) FROM ESTADIA e
    JOIN HOTEL ho ON ho.hote_id = e.esta_hotel
    JOIN HABITACION ha ON ha.habi_numero = e.esta_habitacion AND ha.habi_hotel = e.esta_hotel
    GROUP BY ha.habi_numero, ho.hote_nombre
    ORDER BY SUM(e.esta_duracion), COUNT(*)
END

GO
CREATE PROCEDURE ESTADISTICO_5
AS BEGIN
    SELECT TOP 5 c.clie_apellido, c.clie_nombre, SUM(fl.fact_line_monto * fl.fact_line_cantidad) / 20 + SUM(fl2.fact_line_monto * fl2.fact_line_cantidad) / 10
    FROM CLIENTE c
    JOIN RESERVA r ON r.rese_cliente = c.clie_id
    JOIN FACTURA f ON f.fact_reserva = r.rese_id
    JOIN FACTURA_LINEA fl ON fl.fact_numero = f.fact_numero AND fl.fact_es_consumible = 0
    JOIN FACTURA_LINEA fl2 ON fl.fact_numero = f.fact_numero AND fl.fact_es_consumible = 1
    GROUP BY c.clie_apellido, c.clie_nombre
    ORDER BY SUM(fl.fact_line_monto * fl.fact_line_cantidad) / 20 + SUM(fl2.fact_line_monto * fl2.fact_line_cantidad) / 10
END
GO