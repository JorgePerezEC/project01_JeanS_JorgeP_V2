// *****************************************************************************
// Proyecto 01
// Integrantes: Jorge Pérez y Jean Suárez
// Fecha de realización: 24/06/2022
// Fecha de entrega: 29/06/2022
//
// Resultados:
// 
// El presente proyecto se solicitó implementar un sistema distribuido basado en sockets aplicado en base al juego “21” o 
// “Blackjack” en la cual, mediante Visual Studio se utilizaron 2 proyectos: uno para el Cliente (Windows Form) y otro para el 
// Servidor (Aplicación de Consola). Dentro del cliente, se utilizaron 2 formularios: frmLogin (para acceder al juego) y 
// frmCliente (utilizado para el desarrollo del proceso). Por otro lado, en el lado del servidor se utilizó de archivo 
// Servidor.cs en donde, realiza las funciones respectivas. 
//
// Entre las funciones que realiza el programa son las siguientes: 
// 
// Cliente:
// @  Indica la carta que ha sacado (número y familia) 
// @  Recibe la respuesta de parte del Servidor dentro del RicthTextBox 
//
// Servidor:  
// @  Recibe la información de la carta 
// @  Realiza un conteo de cartas 
//    @  Incrementa en uno si las cartas están entre 3 al 6 
//    @  Decrementa en uno si las cartas están entre 10 a K 
// @  Registra la cantidad de cartas llegadas 
// @  Responde de la siguiente manera: [contador, #cartas 3-6 vista/16, #cartas 10-K vista/16] 
//
// Conclusiones:
//
// @  En la programación, los sockets tienen mucha importancia debido a su gran uso ya que, a través de ellos y en conjunto con un
//    patrón de diseño, se puede implementar un servicio de juegos que sea robusto y extensible, para que el cliente logre tener 
//    una mejor experiencia.
// @  El uso de sockets nos proporciona una gran ventaja, ya que al usarlos permiten crear comunicación entre el cliente con el 
//    servidor donde la respuesta de este último es inmediata, y no como las que se alojan en bases de datos, los cuales, 
//    comparados con los sockets, tienen mucha lentitud
// @  Al momento de recuperar los datos enviados del cliente al servidor haciendo uso del buffer de transmisión, si el tamaño de 
//    dicho buffer era demasiado grande existía demasiado espacio entre mensajes además que los mensajes recibidos llegan a 
//    presentarse mezclados con mensajes recibidos previamente debido a que el buffer no se llenaba completamente al transmitir un
//    mensaje.
//
// Recomendaciones:
//
// @  Se recomienda delimitar la cantidad de bytes que se utilizarán tanto para la transmisión y recepción de información, ya 
//    que al usar una cantidad excesiva hace que los datos se sobrepongan y la información resultante no será la adecuada. 
// @  Se recomienda dentro de Visual Studio al momento de iniciar Proyectos de inicio múltiples inicializar primero el servidor 
//    y luego el cliente, esto es debido a que salta una excepción ya que el cliente no encuentra el servidor donde conectarse.
// @  Utilizar paletas de colores amigables en los elementos de la interfaz gráfica con el usuario para un mejor entendimiento 
//    de la aplicación por parte del usuario.
// @  Colocar nombres de números al repositorio de imágenes utilizadas en el mazo de cartas con el objetivo de presentar la fot 
//    de la carta al momento de usar una simple variable aleatoria para cotejar dicho número con el nombre del archivo y lograr 
//    presentar la foto en la interfaz de usuario.
//
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor2
{
    internal class Servidor
    {
        private static TcpClient manejoCliente; //Conexion de TCP para el manejo del cliente

        //Función principal
        static void Main(string[] args)
        {
            //Creación e inicio del hilo para el Servidor
            Thread hilo_Servidor = new Thread(IniciarServicio);
            hilo_Servidor.Start();
        }

        //Método para dar inicio al Servidor
        public static void IniciarServicio()
        {
            //Variables para conexión Cliente-Servidor
            TcpListener servidor; //Escucha de conexiones del cliente por TCP
            IPEndPoint puntoLocal = new IPEndPoint(IPAddress.Any, 9090); //Socket de servidor
            servidor = new TcpListener(puntoLocal); //Servidor escucha por el socket "puntolocal"
            
            //Mensaje de Bienvenida
            Console.WriteLine("");
            Console.WriteLine("                            '####;       .ooooo.       ;####'");
            Console.WriteLine("                               '##,   .o8P'''''Y8o.   ,##'");
            Console.WriteLine("                                '##, 88'         '88 ,##'");
            Console.WriteLine("                                 '##8'             '8##'");
            Console.WriteLine("                                  '#8   ,o.   .o,   8#'");
            Console.WriteLine("                                    8 8 888; :888 8 8");
            Console.WriteLine("                                    8P '88'   '88' Y8");
            Console.WriteLine("                                    P       8      'Y");
            Console.WriteLine("                                    b      888      d");
            Console.WriteLine("                                         `8b d8`");
            Console.WriteLine("                                      88' 88888 '88");
            Console.WriteLine("                                      8 `'''''''` 8");
            Console.WriteLine("                                       `8ooooooo8`");
            Console.WriteLine("                                       ,##'   '##,");
            Console.WriteLine("                                      ,##'     '##,");
            Console.WriteLine("                                     ,##'       '##,");
            Console.WriteLine("                                  .#####,       ,#####.");
            Console.WriteLine("                                     `##'       '##`");
            Console.WriteLine("            \n\n----------------------$$$$   TrampaForEver.co   $$$$-------------------\n\n\n");

            Console.WriteLine("El servidor está escuchado...\n");

            //Mientras la conexión este activa
            while (true)
            {
                servidor.Start(); //Escucha de solicitudes con numero maximo de conexion pendiente igual a 5
                if (servidor.Pending())
                {
                    manejoCliente = servidor.AcceptTcpClient(); //Aceptacion la conexión del cliente 

                    //Creación del hilo para la admisión de varios clientes
                    Thread hilo_Cliente = new Thread(AdmitirClientes);
                    hilo_Cliente.Start();
                }
            }
        }

        //Método para la admisión de varios clientes
        public static void AdmitirClientes()
        {
            //Variables para la obtención de las cartas recibidas
            int datosLeidos, valorCarta; //Número de datos leidos y el valor que corresponde a la carta
            int contador = 0, cartasInf = 0, cartasSup = 0; //Contador, Cartas vistas 3-6, Cartas vistas 10-K 
            List<string> mazo = new List<string>(); //Lista de cartas recibidas de parte del cliente

            //Variables para el manejo de mensajes
            string datos; //Variable para datos
            byte[] bufferRx = new byte[64]; //Arreglo de bytes de recepcion
            NetworkStream flujo = manejoCliente.GetStream(); //Obtencion de los datos que llegan al servidor

            Console.WriteLine("El servidor admitió a un Jugador...\n");

            //Mientras el servidor escucha
            while (true)
            {
                do
                {
                    datosLeidos = flujo.Read(bufferRx, 0, bufferRx.Length); //Número de datos leidos por el servidor
                    datos = Encoding.ASCII.GetString(bufferRx); //Asignación de datos recibida

                    //Uso del delimitador para dividir los mensajes recibidos
                    char[] delimitador = { ',', ' ' };
                    string[] trozos = datos.Split(delimitador); //Obtención de la matriz de cadena recibida

                    Console.WriteLine("Jugador: " + trozos[0]);
                    Console.WriteLine();

                    //Si la longitud de los datos leidos son mayores a 0
                    if (datosLeidos > 0)
                    {
                        //Si el valor contiene la palabra Reiniciar
                        if(datos.Contains("Reiniciar"))
                        {
                            Console.WriteLine("Se recibió como mensaje: \nReiniciar");
                            Console.WriteLine("Valores reseteados \n");

                            //Se reinician los valores
                            contador = 0; cartasInf = 0; cartasSup = 0;
                            mazo.Clear();

                            //Envío de respuesta al cliente
                            byte[] sendBuffer = Encoding.UTF8.GetBytes("  " + contador + "   " + cartasInf + "/16      " + cartasSup + "/16        ");
                            flujo.Write(sendBuffer, 0, sendBuffer.Length);
                        }
                        //En caso de no contener la palabra Reiniciar
                        else
                        {
                            Console.WriteLine("Se recibió como mensaje: \n{0}\n", datos);  //Mensaje recibido con datos

                            //Si el listado contiene la carta actual
                            if (mazo.Contains(trozos[3] + " " + trozos[4] + " " + trozos[5] + " " + trozos[6]) == true)
                            {
                                Console.WriteLine("Error carta ya vista");

                                //Envío de respuesta al cliente
                                byte[] sendBuffer = Encoding.UTF8.GetBytes("!Error: Carta ya vista");
                                flujo.Write(sendBuffer, 0, sendBuffer.Length);
                            }
                            //En caso de que no contenga la carta actual
                            else
                            {
                                mazo.Add(trozos[3] + " " + trozos[4] + " " + trozos[5] + " " + trozos[6]); //Se añade al listado

                                //-------------ASIGNACIÓN DE UN VALOR A LA CARTA---------------
                                //Si contiene las letras J, Q o K
                                if (trozos[3] == "J" || trozos[3] == "Q" || trozos[3] == "K")
                                    valorCarta = 10; //Se asigna con el valor de 10
                                //Si la primera palabra contiene un As
                                else if (trozos[3] == "As")
                                    valorCarta = 1; //Se asigna el valor de 1
                                //Si no aplica lo anterior
                                else
                                    valorCarta = Int32.Parse(trozos[3]); //Transforma el valor en un entero (2-9)

                                //---------------CONTADOR Y CONTABILIZACIÓN DE CARTAS---------------
                                //Si el valor de la carta está entre 3 y 6
                                if (valorCarta >= 3 && valorCarta <= 6)
                                {
                                    contador++; //Aumenta en 1 el contador
                                    cartasInf++;
                                }
                                //Si el valor de la carta es 10
                                else if (valorCarta == 10)
                                {
                                    contador--; //Disminuye en 1 el contador
                                    cartasSup++;
                                }

                                //Mensaje impreso en el servidor
                                Console.WriteLine("#Contador: " + contador);
                                Console.WriteLine("#Cartas entre 3 y 6: " + cartasInf);
                                Console.WriteLine("#Cartas entre 10 y K: " + cartasSup + "\n");

                                //Envío de respuesta al Cliente
                                byte[] sendBuffer = Encoding.UTF8.GetBytes("  " + contador + "   " + cartasInf + "/16      " + cartasSup + "/16        ");
                                flujo.Write(sendBuffer, 0, sendBuffer.Length);
                            }
                        }
                    }
                } while (datosLeidos > 0);
            }
        }
    }
}
