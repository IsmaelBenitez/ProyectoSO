#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
//MAIN DEL SERVER
int main(int argc, char *argv[]) {
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
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
	//Inicializamos el Socket
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	serv_adr.sin_port = htons(9080);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	//Socket iniciado
	//Bucle infinito para escuchar y devolver mensajes
	while(1==1)
	{
		int i =0;
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);
		
		//Partimos el mensaje para saber que piden.
		char *p =strtok(peticion,"/");
		int codigo =atoi(p);
		if(codigo==1)
		{
			char nombre[60];
			char contra[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);

			
			p=strtok(NULL,"/");
			strcpy(contra,p);

			
			i =EstaRegistrado( nombre,contra, err,conn,resultado,row);
			
			if (i==1)
			{
				sprintf(respuesta,"%s\n","OK");

				write (sock_conn,respuesta, strlen(respuesta));
			}
			else
			{
				sprintf(respuesta,"%s\n","NO");
				
				write (sock_conn,respuesta, strlen(respuesta));
			}
			close(sock_conn); 
			
		}
		if (codigo==2)
		{
			char nombre[60];
			char contra[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			
			
			p=strtok(NULL,"/");
			strcpy(contra,p);
			
			i=Registrar(nombre, contra,err,conn,resultado,row);
			
			if(i==1)
			{
				sprintf(respuesta,"%s\n","OK");
				
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else
			{
				sprintf(respuesta,"%s\n","NO");
				
				write (sock_conn,respuesta, strlen(respuesta));
			}
			close(sock_conn); 
		}
		if (codigo==3)
		{
			char nombre[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			PorcentajeVictorias(nombre,respuesta, err,conn,resultado,row);
			printf("%s\n",respuesta);
			if (strcmp(respuesta,"-1.00")==0)
			{
				sprintf(respuesta,"%s\n","E");
				printf("%s",respuesta);
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else
				write (sock_conn,respuesta, strlen(respuesta));
			close(sock_conn); 
		}
		if (codigo==4)
		{
			char nombre[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			JugadorFavorito(nombre,respuesta, err,conn,resultado,row);
			write (sock_conn,respuesta, strlen(respuesta));
			close(sock_conn); 
		}
		if (codigo==5)
		{
			char identificador[60];
			char nombre[60];
			p=strtok(NULL,"/");
			strcpy(identificador,p);
			GanadorPartida(identificador,nombre, err,conn,resultado,row);
			write (sock_conn,nombre, strlen(nombre));
			close(sock_conn); 
		}
		
	}
}


//FUNCIONES PARA EL FUNCIONAMIENTO DEL SERVER
int EstaRegistrado(char nombre[60],char contrasena[60], int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta[500];
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
	char consulta[500];
	char consulta2[500];
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

void PorcentajeVictorias(char nombre[60],char *solucion[10], int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta [500];
	float porcentaje;
	strcpy(consulta,"SELECT Jugador.Partidas_ganadas, Jugador.Partidas_jugadas FROM Jugador WHERE Nombre = '");
	strcat (consulta, nombre);
	strcat (consulta,"'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		porcentaje=-1.0;
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de un jugador.
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	// En una fila hay tantas columnas como datos tiene un
	// jugador. En nuestro caso hay dos columnas: Partidas_ganadas(row[0]) y
	// Partidas_jugadas(row[1]) .
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		porcentaje =-1.0;
	}
	else
	{
		int Partidas_ganadas=atoi(row[0]);
		int Partidas_jugadas=atoi(row[1]);
		if (Partidas_jugadas==0)
			porcentaje=0;
		else
		{
			porcentaje=((float) Partidas_ganadas/(float)Partidas_jugadas)*100;
		}
		printf("Ganadas: %d \n",Partidas_ganadas);
		printf("Jugadas: %d \n",Partidas_jugadas);
		printf("El ratio de victorias es: %.2f \n",porcentaje);
	}
	sprintf(solucion,"%.2f",porcentaje);
}
void JugadorFavorito(char nombre[60],char *avatar[60],int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta[500];
	int ismael=0;
	int itziar=0;
	int guillem=0;
	int victor=0;
	int azahara=0;
	strcpy(consulta,"SELECT Participacion.Avatar,Jugador.Partidas_jugadas FROM (Jugador, Participacion) WHERE Jugador.Nombre = '");
	strcat (consulta, nombre);
	strcat (consulta,"' AND Participacion.Id_J = Jugador.Identificador");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		strcpy(avatar,"E");
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(avatar,"X");
	}
	
	else
	{
		while (row !=NULL) {
			if (strcmp(row[0],"Ismael")==0)
				ismael=ismael+1;
			else if (strcmp(row[0],"Itziar")==0)
				itziar=itziar+1;
			else if (strcmp(row[0],"Guillem")==0)
				guillem=guillem+1;
			else if (strcmp(row[0],"Victor")==0)
				victor=victor+1;
			else if (strcmp(row[0],"Azahara")==0)
				azahara=azahara+1;
			
			strcpy(avatar,"Ismael");
			int i=ismael;
			if (i<itziar){
				i=itziar;
				strcpy(avatar,"Itziar");
			}
			if (i<guillem){
				i=guillem;
				strcpy(avatar,"Guillem");
			}
			if (i<victor){
				i=victor;
				strcpy(avatar,"Victor");
			}
			if (i<azahara){
				i=azahara;
				strcpy(avatar,"Azahara");
			}
			
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
		}
		
		printf("El avatar más jugado es: %s \n",avatar);
		
	}
}
void GanadorPartida(char Identificador[60],char *nombre[60],int err,MYSQL *conn,MYSQL_RES *resultado,MYSQL_ROW row){
	char consulta[500];
	strcpy(consulta,"SELECT Jugador.nombre FROM (Jugador, Partida) WHERE Partida.Identificador = '");
	strcat (consulta, Identificador);
	strcat (consulta,"' AND Partida.Ganador = Jugador.Identificador");
	printf("%s\n",consulta);
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		strcpy(nombre,"E");
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(nombre,"X");
	}
	else
	{
		printf("El ganador de la partida %s, es %s \n",Identificador,row[0]);
		strcpy(nombre,row[0]);
		printf("%s\n",nombre);
	}
}
