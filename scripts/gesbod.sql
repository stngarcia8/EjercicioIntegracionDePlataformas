-- Script para crear tablespace y usuarios para la aplicación libros.
-- Alumnos: Hector Celis, Pedro Briceño, Elias Garcia, Daniel Garcia, Ignacio Salazar.
-- Ramo: Integración de plataformas.
-- Profesora: Cindy Contador.
SET ECHO OFF;
alter session set "_ORACLE_SCRIPT"=true;
clear screen;
prompt Eliminando datos antiguos.;

-- Eliminando el usuario antes de quitar  tablespace.
Drop user libros_usr cascade;

-- Eliminando el table space.
drop tablespace libros_tbs INCLUDING CONTENTS AND DATAFILES CASCADE CONSTRAINTS;


-- Creando el tablespace de libros.
prompt Creando tablespace.;
CREATE TABLESPACE libros_tbs
DATAFILE 'libros.dbf'
size 500M
autoextend on;


-- Creando el usuario.
prompt Creando el usuario.;
CREATE USER libros_usr
IDENTIFIED BY libros_pwd
DEFAULT TABLESPACE libros_tbs
temporary tablespace temp;


-- Asignando los privilegios al usuario.
prompt Asignando los permisos necesarios.;
GRANT CREATE SESSION TO libros_usr;
GRANT RESOURCE TO libros_usr;
GRANT EXECUTE ON SYS.DBMS_LOB TO libros_usr;
GRANT EXECUTE ON SYS.DBMS_RANDOM TO libros_usr;
GRANT CREATE ANY TABLE TO libros_usr;
GRANT CREATE SEQUENCE TO libros_usr;
GRANT CREATE PROCEDURE, EXECUTE ANY PROCEDURE TO libros_usr;
GRANT CREATE TRIGGER TO libros_usr;


-- Definiendo el tablespace que trabajara el usuario.
ALTER USER libros_usr QUOTA UNLIMITED ON libros_tbs;


-- Estableciendo cambios.
commit;


prompt Archivo de datos, tablespace y usuario listos.;