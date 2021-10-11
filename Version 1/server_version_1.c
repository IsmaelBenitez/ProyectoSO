#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int main(int argc, char *argv[]) {
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char identificador[20]="4";
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexiï¿ƒï¾³n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexiï¿ƒï¾³n: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}

int EstaRegistrado(char nombre[60],char contrasena[60], int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta[100];
	strcpy(consulta,"Select Nombre,Contraseña FROM Jugador WHERE Nombre='");
	strcat(consulta,nombre);
	strcat (consulta,"' AND Contraseña='");
	strcat(consulta,contrasena);
	strcat (consulta,"'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 0;
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		return 0;
	else
		return 1;
}
int Registrar(char nombre[60],char contrasena[60], int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta[100];
	char consulta2[100];
	int yaesta;
	yaesta=EstaRegistrado(nombre,contrasena, err,conn,resultado,row);
	if (yaesta==0){
		strcpy(consulta,"SELECT MAX(Identificador) FROM Jugador");
		err=mysql_query (conn, consulta);
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			return 0;
			exit (1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		int id=atoi(row[0])+1;
		char id1[10];
		strcpy(consulta2,"INSERT INTO Jugador VALUES(");
		sprintf(id1,"%d",id);
		strcat(consulta2,id1);
		strcat(consulta2,",'");
		strcat(consulta2,nombre);
		strcat(consulta2,"','");
		strcat(consulta2,contrasena);
		strcat(consulta2,"',0,0);");
		
		err=mysql_query (conn, consulta2);
		if (err!=0) {
			printf ("Error al añadir en la base de datos %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			return 0;
			exit (1);
		}
		else
			return 1;
		
	}
	else
		return 0;
		
	
}

