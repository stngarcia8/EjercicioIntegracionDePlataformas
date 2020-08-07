-- Modulo Facturas.
-- Script: Creacion de tablas.
-- Ramo: Integracion de plataformas.
-- Profesora: Cindy Contador.
-- Alumnos: Pedro Briceno, Elias Garcia, Daniel Garcia, Ignacio Salazar.

SET ECHO OFF;
alter session set "_ORACLE_SCRIPT"=true;
clear screen;
prompt Eliminando datos antiguos.

-- Eliminando el usuario antes de quitar  tablespace.
Drop user factura_usr cascade;

-- Eliminando el table space.
drop tablespace factura_tbs INCLUDING CONTENTS AND DATAFILES CASCADE CONSTRAINTS;


-- Creando el tablespace de facturas.
prompt Creando tablespace.
CREATE TABLESPACE factura_tbs
DATAFILE 'factura.dbf'
size 500M
autoextend on;


-- Creando el usuario.
prompt Creando el usuario.
CREATE USER factura_usr
IDENTIFIED BY factura_pwd
DEFAULT TABLESPACE factura_tbs
temporary tablespace temp;


-- Asignando los privilegios al usuario.
prompt Asignando los permisos necesarios.
GRANT CREATE SESSION TO factura_usr;
GRANT RESOURCE TO factura_usr;
GRANT EXECUTE ON SYS.DBMS_LOB TO factura_usr;
GRANT EXECUTE ON SYS.DBMS_RANDOM TO factura_usr;
GRANT CREATE ANY TABLE TO factura_usr;
GRANT CREATE SEQUENCE TO factura_usr;
GRANT CREATE PROCEDURE, EXECUTE ANY PROCEDURE TO factura_usr;
GRANT CREATE TRIGGER TO factura_usr;


-- Definiendo el tablespace que trabajara el usuario.
ALTER USER factura_usr QUOTA UNLIMITED ON factura_tbs;


-- Estableciendo cambios.
commit;
prompt Creando las tablas.


prompt Creando tabla cliente.
CREATE TABLE factura_usr.cliente (
    rutcliente      VARCHAR2(10) NOT NULL,
    nombrecliente   VARCHAR2(50) NOT NULL,
	CONSTRAINT cliente_pk PRIMARY KEY ( rutcliente )
) tablespace factura_tbs;


prompt Creando tabla ejemplar.
CREATE TABLE factura_usr.ejemplar (
    idejemplar       VARCHAR2(36) NOT NULL,
    nombreejemplar   VARCHAR2(255) NOT NULL,
    precioejemplar   NUMBER(9) NOT NULL,
	CONSTRAINT ejemplar_pk PRIMARY KEY ( idejemplar )
) tablespace factura_tbs;


prompt Creando tabla formaPago.
CREATE TABLE factura_usr.formapago (
    idformapago       NUMBER(2) NOT NULL,
    nombreformapago   VARCHAR2(15) NOT NULL,
	CONSTRAINT formapago_pk PRIMARY KEY ( idformapago )
) tablespace factura_tbs;


prompt Creando tabla tipoDocumento.
CREATE TABLE factura_usr.tipodocumento (
    idtipodocumento       NUMBER(2) NOT NULL,
    nombretipodocumento   VARCHAR2(15) NOT NULL,
	CONSTRAINT tipodocumento_pk PRIMARY KEY ( idtipodocumento )
) tablespace factura_tbs;


prompt Creando tabla usuario.
CREATE TABLE factura_usr.usuario (
    rutusuario      VARCHAR2(10) NOT NULL,
    nombreusuario   VARCHAR2(50) NOT NULL,
    sucursal        VARCHAR2(20) NOT NULL,
	CONSTRAINT usuario_pk PRIMARY KEY ( rutusuario )
) tablespace factura_tbs;


prompt Creando tabla venta.
CREATE TABLE factura_usr.venta (
    idventa                         VARCHAR2(36) NOT NULL,
    fechaventa                      DATE NOT NULL,
    rutusuario              VARCHAR2(10) NOT NULL,
    rutcliente              VARCHAR2(10) NOT NULL,
    idformapago           NUMBER(2) NOT NULL,
    idtipodocumento   NUMBER(2) NOT NULL,
	CONSTRAINT venta_pk PRIMARY KEY ( idventa ),
    CONSTRAINT venta_cliente_fk FOREIGN KEY ( rutcliente )
        REFERENCES factura_usr.cliente ( rutcliente ),
    CONSTRAINT venta_formapago_fk FOREIGN KEY ( idformapago )
        REFERENCES factura_usr.formapago ( idformapago ),
    CONSTRAINT venta_tipodocumento_fk FOREIGN KEY ( idtipodocumento )
        REFERENCES factura_usr.tipodocumento ( idtipodocumento ),
    CONSTRAINT venta_usuario_fk FOREIGN KEY ( rutusuario )
        REFERENCES factura_usr.usuario ( rutusuario )
) tablespace factura_tbs;


prompt Creando tabla datosFacturacion.
CREATE TABLE factura_usr.datosfacturacion (
    iddatos         NUMBER(9) NOT NULL,
    rut             VARCHAR2(10) NOT NULL,
    razonsocial     VARCHAR2(255) NOT NULL,
    direccion       VARCHAR2(255) NOT NULL,
    giro            VARCHAR2(75) NOT NULL,
    contacto        VARCHAR2(100),
    ciudad          VARCHAR2(100) NOT NULL,
    idventa   VARCHAR2(36) NOT NULL,
	CONSTRAINT datosfacturacion_pk PRIMARY KEY ( iddatos ),
	CONSTRAINT datosfacturacion_venta_fk FOREIGN KEY ( idventa )
        REFERENCES factura_usr.venta ( idventa )
) tablespace factura_tbs;


prompt Creando tabla detalleVenta.
CREATE TABLE factura_usr.detalleventa (
    iddetalle             NUMBER(9) NOT NULL,
    cantidad              NUMBER(4) DEFAULT 0 NOT NULL,
    preciototal           NUMBER(9) DEFAULT 0 NOT NULL,
    idventa         VARCHAR2(36) NOT NULL,
    idejemplar   VARCHAR2(36) NOT NULL,
	CONSTRAINT detalleventa_pk PRIMARY KEY ( idventa, iddetalle ),
	CONSTRAINT detalleventa_ejemplar_fk FOREIGN KEY ( idejemplar )
        REFERENCES factura_usr.ejemplar ( idejemplar ),
    CONSTRAINT detalleventa_venta_fk FOREIGN KEY ( idventa )
        REFERENCES factura_usr.venta ( idventa )
) tablespace factura_tbs;


prompt Creando procesos almacenados.


prompt Creado proceso almacenado spRegistrarVenta
create or replace procedure factura_usr.spRegistrarVenta(
	pIdVenta varchar2,
	pFechaVenta date,
	pRutUsuario varchar2,
	pRutCliente varchar2,
	pIdFormaPago number,
	pIdTipoDocumento number
) is
begin
	insert into factura_usr.venta
	values (
		pIdVenta,
		pFechaVenta,
		pRutUsuario,
		pRutCliente,
		pIdFormaPago,
		pIdTipoDocumento
	);

	commit;
end spRegistrarVenta;

/

prompt Creado proceso almacenado spRegistrarDetalleVenta
create or replace procedure factura_usr.spRegistrarDetalleVenta(
	pCantidad number,
	pPrecioTotal number,
	pIdVenta varchar2,
	pIdEjemplar varchar2
) is
	vIdDetalle number default 0;
begin
	select count(idventa) + 1
	into vIdDetalle
	from factura_usr.detalleventa
	where idventa = pIdVenta;

	insert into factura_usr.detalleventa
	values (
		vIdDetalle,
		pCantidad,
		pPrecioTotal,
		pIdVenta,
		pIdEjemplar
	);

	commit;
end spRegistrarDetalleVenta;

/

prompt Creado proceso almacenado spRegistrarCliente
create or replace procedure factura_usr.spRegistrarCliente(
	pRutCliente varchar2,
	pNombreCliente varchar2
) is
	vCount number default 0;
begin
	select count(rutcliente)
	into vCount
	from factura_usr.cliente
	where rutcliente = pRutCliente;

	if (vCount = 0) then
		insert into factura_usr.cliente
		values (
			pRutCliente,
			pNombreCliente
		);

        commit;
	end if;
end;

/

prompt Creado proceso almacenado spRegistrarUsuario
create or replace procedure factura_usr.spRegistrarUsuario(
	pRutUsuario varchar2,
	pNombreUsuario varchar2,
	pSucursal varchar2
) is
	vCount number default 0;
begin
	select count(rutusuario)
	into vCount
	from factura_usr.usuario
	where rutusuario = pRutUsuario;

	if (vCount = 0) then
		insert into factura_usr.usuario
		values (
			pRutUsuario,
			pNombreUsuario,
			pSucursal
		);

        commit;
	end if;
end;

/

prompt Creado proceso almacenado spRegistrarEjemplar
create or replace procedure factura_usr.spRegistrarEjemplar(
	pIdEjemplar varchar2,
	pNombreEjemplar varchar2,
	pPrecioEjemplar number
) is
	vCount number default 0;
begin
	select count(idejemplar)
	into vCount
	from factura_usr.ejemplar
	where idejemplar = pIdEjemplar;

	if (vCount = 0) then
		insert into factura_usr.ejemplar
		values (
			pIdEjemplar,
			pNombreEjemplar,
			pPrecioEjemplar
		);

        commit;
	end if;
end;

/

prompt Creado proceso almacenado spRegistrarDatosFactura
create or replace procedure factura_usr.spRegistrarDatosFactura(
	pRut varchar2,
	pRazonSocial varchar2,
	pDireccion varchar2,
	pGiro varchar2,
	pContacto varchar2,
	pCiudad varchar2,
	pIdVenta varchar2
) is
	vCount number default 0;
begin
	select count(iddatos) + 1
	into vCount
	from factura_usr.datosfacturacion;

	insert into factura_usr.datosfacturacion
	values (
		vCount,
		pRut,
		pRazonSocial,
		pDireccion,
		pGiro,
		pContacto,
		pCiudad,
		pIdVenta
	);

    commit;
end spRegistrarDatosFactura;

/

prompt Creando los tipos de pago.
INSERT INTO factura_usr.formapago VALUES (1, 'Efectivo');
INSERT INTO factura_usr.formapago VALUES (2, 'Cheque');
INSERT INTO factura_usr.formapago VALUES (3, 'Credito');
INSERT INTO factura_usr.formapago VALUES (4, 'Debito');

prompt Creando los tipos de documento.
INSERT INTO factura_usr.tipodocumento VALUES (1, 'Boleta');
INSERT INTO factura_usr.tipodocumento VALUES (2, 'Factura');

prompt Archivo de datos, tablespace, usuario, tablas y registros iniciales listos!!!;
commit;