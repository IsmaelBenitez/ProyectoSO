DROP DATABASE IF EXISTS T5BBDD;
CREATE DATABASE T5BBDD;

USE T5BBDD;

CREATE TABLE Jugador (
	Identificador INTEGER PRIMARY KEY NOT NULL,
	Nombre VARCHAR(60) NOT NULL,
	Contraseña VARCHAR(60) NOT NULL,
	Partidas_jugadas INT NOT NULL,
	Partidas_ganadas INT NOT NULL 
)ENGINE=InnoDB;

CREATE TABLE Partida (
	Identificador INTEGER PRIMARY KEY NOT NULL,
	Duracion INT NOT NULL,
	Ganador INT NOT NULL,
	FOREIGN KEY (Ganador) REFERENCES Jugador(Identificador) 
)ENGINE=InnoDB;

CREATE TABLE Participacion (
	Id_J INTEGER NOT NULL,
	Id_P INTEGER NOT NULL,
	FOREIGN KEY (Id_J) REFERENCES Jugador(Identificador),
	FOREIGN KEY (Id_P) REFERENCES Partida(Identificador),
	Avatar VARCHAR(60) NOT NULL
)ENGINE=InnoDB; 

INSERT INTO Jugador VALUES(1,'Ismael','HOLA',2,2);
INSERT INTO Jugador VALUES(2,'Itziar','<3',2,1);
INSERT INTO Jugador VALUES(3,'Guillem','ADIOS',1,1);
INSERT INTO Jugador VALUES(4,'Victor','JESUS',3,2);
INSERT INTO Jugador VALUES(5,'Azahara','contraseña',1,1);

INSERT INTO Partida VALUES(1,30,3);
INSERT INTO Partida VALUES(2,45,2);
INSERT INTO Partida VALUES(3,40,1);
INSERT INTO Partida VALUES(4,20,1);
INSERT INTO Partida VALUES(5,50,5);
INSERT INTO Partida VALUES(6,25,4);
INSERT INTO Partida VALUES(7,35,4);


INSERT INTO Participacion VALUES(1,4,'Ismael');
INSERT INTO Participacion VALUES(2,1,'Itziar');
INSERT INTO Participacion VALUES(2,2,'Itziar');
INSERT INTO Participacion VALUES(3,1,'Guillem');
INSERT INTO Participacion VALUES(5,3,'Azahara');
INSERT INTO Participacion VALUES(1,5,'Ismael');
INSERT INTO Participacion VALUES(4,4,'Victor');
INSERT INTO Participacion VALUES(4,6,'Victor');
INSERT INTO Participacion VALUES(4,7,'Victor');
