#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

//Estructuras para la lista de conectados
typedef struct{
	char nombre[60];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[100];
	int num;
}ListaConectados;
// Variable globales:
MYSQL *conn; // Connector con el serivdor de MYSQL
ListaConectados Lista; // Lista de conectados
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;//Estructura para la implementaci?n de exclusin mutua


int i;
int sockets[100];

//Funciones para actuar sobre la lista de conectados
int AnadirConectado (ListaConectados *lista, char nombre[60], int socket){

	if (lista->num == 100)
	{
		
		return -1;
		
	}
	else{
		
		strcpy(lista->conectados[lista->num].nombre,nombre);

		lista->conectados[lista->num].socket = socket;

		lista->num++;


		return 0;
	}

}
int DameSocket (ListaConectados *lista, char nombre[20]){
	// Devuelve el socket o -1 si no está en la lista
	int i=0;
	int encontrado =0;
	while ((i< lista->num) && !encontrado ){
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
	
}
int DamePos (ListaConectados *lista, char nombre[20]){
	// Devuelve la posicion en la lista o -1 si no está en la lista
	int i=0;
	int encontrado =0;
	while ((i< lista->num) && !encontrado ){
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}
int Elimina(ListaConectados *lista, char nombre[20]){
	//Devuelve el socket o -1 si no está en la lista

	int pos = DamePos (lista,nombre);
	if (pos==-1)
		return -1;
	else
	{
		int i;
		for (i=pos; i< lista->num-1;i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
		}
		lista->num--;
		return 0;
		
	}
	
}
void DameConectados ( ListaConectados *lista, char *conectados[300]){
	//Pone en conectados los nombres de todos los conectados separados por /. Primero pone el num de conectados
	sprintf(conectados,"%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
		sprintf(conectados, "%s/%s", conectados, lista->conectados[i].nombre);
}
void DameTodosSockets ( ListaConectados *lista, char nombres[80], char *sockets){
	//Escribe una funciÃ³n que recibe un vector de caracteres con los nombres de jugadores
	//separados por comas y revuelve una cadena de caracteres con los sockets de cada uno
	//de estos jugadores, tambiÃ©n separados por comas.
	printf("vector nombres %s\n", nombres);
	char *p=strtok(nombres,",");
	int i=0;
	int n=lista->num;
	printf("%d\n",n);
	while (p!=NULL){
		while (i<n){
			if (strcmp(lista->conectados[i].nombre,p)==0)
			{
				printf("He entrado %s\n",lista->conectados[i].nombre);
				int valor=lista->conectados[i].socket;
				sprintf(sockets,"%s, %d", sockets, valor);
			}
			i=i+1;
		}
		i=0;
		p=strtok(NULL,",");
		
	}
}
void EnviarLista (){
	char notificacion[300];
	char conectados[300];
	DameConectados (&Lista,conectados);
	printf("Este es el print de la lista de conectados %s\n",conectados);
	int j;
	sprintf(notificacion,"6/%s",conectados);
	printf("%s",notificacion);
	for (j=0; j<Lista.num; j++)
		write (Lista.conectados[j].socket,notificacion, strlen(notificacion));
}

//Thread para atender peticiones de los clientes
void *AtenderCliente(void *socket) {


	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	int sock_conn, ret;
	int *s;
	s=(int *) socket;
	sock_conn=*s;
	struct sockaddr_in serv_adr;
	//Inicializamos el Socket
	char peticion[512];
	char respuesta[512];

	int i =0;
	int terminar=0;
	char nombre[60];
	
	while(terminar==0){
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		peticion[ret]='\0';
		
		printf ("Peticion: %s\n",peticion);
		
		
		
		//Partimos el mensaje para saber que piden.
		char *p =strtok(peticion,"/");
		int codigo =atoi(p);
		printf("COdigo: %d\n",codigo);
		
		
		if (codigo==0)
			terminar=1;
		if(codigo==1)
		{
			
			char contra[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			
			
			p=strtok(NULL,"/");
			strcpy(contra,p);
			
			
			i =EstaRegistrado( nombre,contra);
			
			
			
			if (i==1)
			{
				
				//Bloqueamos la parte en la que la lista debe ser modificada
				pthread_mutex_lock(&mutex);
				i = AnadirConectado(&Lista,nombre,sock_conn);
				pthread_mutex_unlock(&mutex);
				
				
				
				if(i==0){
					sprintf(respuesta,"1/%s","OK");
					write (sock_conn,respuesta, strlen(respuesta));
					EnviarLista ();
				}
				else{
					sprintf(respuesta,"1/%s","NO");
					
					write (sock_conn,respuesta, strlen(respuesta));
				}
			}
			else
			{
				sprintf(respuesta,"1/%s","NO");
				
				write (sock_conn,respuesta, strlen(respuesta));
			}
			
			
		}
		if (codigo==2)
		{
			
			char contra[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			
			
			p=strtok(NULL,"/");
			strcpy(contra,p);
			
			i=Registrar(nombre, contra);
			
			if(i==1)
			{
				
				//Bloquemaos la parte deonde la lista est? siendo modificada
				pthread_mutex_lock(&mutex);
				i = AnadirConectado(&Lista,nombre,sock_conn);
				pthread_mutex_unlock(&mutex);
				
				
				if(i==0)
				{
					sprintf(respuesta,"2/%s","OK");
					write (sock_conn,respuesta, strlen(respuesta));
					EnviarLista();
				}
				else
				{
					sprintf(respuesta,"2/%s","NO");
					
					write (sock_conn,respuesta, strlen(respuesta));
				}
			}
			else
			{
				sprintf(respuesta,"2/%s","NO");
				
				write (sock_conn,respuesta, strlen(respuesta));
			}
			
		}
		if (codigo==3)
		{
			char nombre[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			PorcentajeVictorias(nombre,respuesta);
			printf("%s\n",respuesta);
			if (strcmp(respuesta,"-1.00")==0)
			{
				sprintf(respuesta,"%s","E");
				printf("%s\n",respuesta);
				write (sock_conn,respuesta, strlen(respuesta));
			}
			else
				write (sock_conn,respuesta, strlen(respuesta));
			
		}
		if (codigo==4)
		{
			char nombre[60];
			
			p=strtok(NULL,"/");
			strcpy(nombre,p);
			JugadorFavorito(nombre,respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
			
		}
		if (codigo==5)
		{
			char identificador[60];
			char nombre[60];
			p=strtok(NULL,"/");
			strcpy(identificador,p);
			GanadorPartida(identificador,nombre);
			write (sock_conn,nombre, strlen(nombre));
			
		}
		
	
	}
	//Bloqueamos la parte donde la lista est? siendo modificada
	pthread_mutex_lock(&mutex);
	i =Elimina(&Lista,nombre);
	pthread_mutex_unlock(&mutex);
	EnviarLista();
	
	if(i==0)
		close(sock_conn);
	else
		printf("No se puede desconectar a este usuario");
}
//Funciones para atender las peticiones del server
int EstaRegistrado(char nombre[60],char contrasena[60]){
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta[500];
	strcpy(consulta,"Select Nombre,Contrase?a FROM Jugador WHERE Nombre='");
	strcat(consulta,nombre);
	strcat (consulta,"' AND Contrase?a='");
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
int Registrar(char nombre[60],char contrasena[60]){
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta[500];
	char consulta2[500];
	int yaesta;
	yaesta=EstaRegistrado(nombre,contrasena);
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
			printf ("Error al a?adir en la base de datos %u %s\n",
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

void PorcentajeVictorias(char nombre[60],char *solucion[10]){
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
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
	sprintf(solucion,"3/%.2f",porcentaje);
}
void JugadorFavorito(char nombre[60],char *avatar[60]){
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
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
		strcpy(avatar,"4/E");
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(avatar,"4/X");
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
			
			strcpy(avatar,"4/Ismael");
			int i=ismael;
			if (i<itziar){
				i=itziar;
				strcpy(avatar,"4/Itziar");
			}
			if (i<guillem){
				i=guillem;
				strcpy(avatar,"4/Guillem");
			}
			if (i<victor){
				i=victor;
				strcpy(avatar,"4/Victor");
			}
			if (i<azahara){
				i=azahara;
				strcpy(avatar,"4/Azahara");
			}
			
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
		}
		
		printf("El avatar m?s jugado es: %s \n",avatar);
		
	}
}
void GanadorPartida(char Identificador[60],char *nombre[60]){
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	char consulta[500];
	strcpy(consulta,"SELECT Jugador.nombre FROM (Jugador, Partida) WHERE Partida.Identificador = '");
	strcat (consulta, Identificador);
	strcat (consulta,"' AND Partida.Ganador = Jugador.Identificador");
	printf("%s\n",consulta);
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		strcpy(nombre,"5/E");
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(nombre,"5/X");
	}
	else
	{
		printf("El ganador de la partida %s, es %s \n",Identificador,row[0]);
		sprintf(nombre,"5/%s",row[0]);
		printf("5/%s\n",nombre);
	}
}

//MAIN DEL SERVER
int main(int argc, char *argv[]){
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexiￃﾳn: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion con la base de datos
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexiￃﾳn: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Estructiras para los sockets
	int sock_conn,sock_listen;
	struct sockaddr_in serv_adr;

	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	//Estructuras para el uso de threads
	
	pthread_t thread[100];
 
	int i=0;
	// Bucle infinito de atender las peticiones abriendo threads
	for (;;)
	{
		printf("Escuchando\n");
		
		sock_conn=accept(sock_listen,NULL,NULL);
		printf("He recibido conexion\n");
		sockets[i]=sock_conn;
		pthread_create(&thread[i],NULL,AtenderCliente,&sockets[i]);
		i++;
	}
}

