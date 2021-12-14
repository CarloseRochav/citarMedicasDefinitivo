Create DataBase CitasMedicas2

use CitasMedicas2

DROP DATABASE CitasMedicas2

--BIEN
Create table Administrador(
IDAdministrador int identity(1,1) primary key not null,
CorreoElectronico varchar(30) unique,
Contraseña varchar(30)
)

--BIEN
Create Table Especialidad(
IDEspecialidad_Nombre varchar(40) primary key not null,
Descripcion varchar(100)  not null
)

--BIEN
Create Table Medico(
IdMedico int identity(1,1) primary key not null,
ApellidoPaterno varchar(30)not null,
ApellidoMaterno varchar(30)not null,
Nombre varchar(30)not null,
Genero char (15)not null,
FechaNacimiento date not null,
CorreoElectronico varchar(30) unique not null,
Contraseña varchar(30) not null,
IDEspecialidad_Nombre VARCHAR(40) not null FOREIGN KEY REFERENCES Especialidad(IDEspecialidad_Nombre)
)


--BIEN
Create Table Paciente(
IdPaciente int identity(1,1) primary key not null,
ApellidoPaterno varchar(30)not null,
ApellidoMaterno varchar(30)not null,
Nombre varchar(30)not null,
Genero char not null,
FechaNacimiento date not null,
CorreoElectronico varchar(30) unique not null,
Contraseña varchar(30) not null,
)

--DROP TABLE PACIENTE;
--DROP DATABASE CitasMedicas2
-- Donde esta tu consulta?



select IdPaciente, Nombre from Paciente
select * from cita



INSERT INTO Cita Values (1,1,'2021-12-20',);

--SELECT * FROM PACIENTE;
SELECT * FROM ESPECIALIDAD;
--SELECT * FROM ADMINISTRADOR;
--SELECT * FROM MEDICO;
--select * from cita

--DELETE FROM MEDICO WHERE IdMedico=3;

--Administradores
INSERT INTO ADMINISTRADOR VALUES ('admin@sysadmin.com','12345');
INSERT INTO ADMINISTRADOR VALUES ('admin@sysit.com','123456');

INSERT INTO MEDICO VALUES ('Perez','Gonzales','Pedro','M','1980-12-01','medico@muypreparado.com','medico123','Pediatria');
INSERT INTO CITA;

--CAMBIOS
Create Table Horarios(
IDHorario int identity(1,1) primary key not null,
Hora_Entrada varchar (20) not null,
Hora_Salida varchar(20) not null,
IdMedico Int not null FOREIGN KEY REFERENCES Medico(IdMedico)
)

Create Table Cita(
idCita int identity(1,1) primary key not null,
IdPaciente int not null FOREIGN KEY REFERENCES Paciente(Idpaciente),
IdMedico Int not null FOREIGN KEY REFERENCES Medico(IdMedico),
Fecha date not null,
Hora varchar (20) not null,
Folio int UNIQUE not null,
StatusS varchar(20)
)

SELECT * FROM PACIENTE ;
SELECT * FROM MEDICO;
SELECT * FROM FOLIO;
INSERT INTO Cita Values (1,3,'2021-12-20','16:00 PM',2,'Pendiente');

--Creacion de Proc
create proc InsertarCita
@idpaciente int,
@medico int,
@fecha date,
@hora varchar(20),
@folio int,
@status varchar(20)
as
insert into Cita
values(
@idpaciente ,
@medico ,
@fecha ,
@hora ,
@folio ,
@status 
)



