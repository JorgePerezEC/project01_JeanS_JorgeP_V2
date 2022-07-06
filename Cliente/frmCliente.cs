using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmCliente : Form
    {
        //Variables para conexión Cliente-Servidor
        TcpClient Cliente = new TcpClient("127.0.0.1", 9090); //Conexión del cliente por TCP
        byte[] bufferRx = new byte[64]; //Arreglo de Bytes de rececpcion
        int indicador; //Variable para indicar si el mensaje enviado posee una longitud mayor a 0

        //Variables para el uso de cartas
        int carta, puntajeBJ = 0, valor = 0; //Variable para la carta obtenida, su puntaje y valor de la carta
        public string usuario; //Nombre del usuario
        Random random = new Random(); //Objeto que realiza números aleatorios

        //Variable para direccionar las imágenes de las cartas 
        //(Click derecho en "img", presionar "Copia de ruta de acceso completa" y pegar en la variable "ruta")

        //string ruta = "C:\\Users\\user\\source\\repos\\proyecto01_JeanS_JorgeP\\Cliente\\img\\"; //Ubicación: JEAN
        string ruta = "D:\\DOCUMENTOS\\UNIVERSIDAD\\7MO SEMESTRE B\\APPS DISTRIBUIDAS\\PROYECTO AD\\1ER BIM - BLACK JACK\\prjcts\\proyecto01_JeanS_JorgeP_BlackJack\\blackJack\\cartas\\"; //Ubicación: Jorge

        //Inicio del formulario
        public frmCliente()
        {
            InitializeComponent();
            imgCarta.Image = Image.FromFile(ruta + "0.png");
        }

        //Método al momento de cargar el formulario
        private void frmCliente_Load(object sender, EventArgs e)
        {
            lblCliente.Text = "Player: " + usuario; //Impresión del usuario
            rchtCliente.Text = " [DAY]          [HORA]     [C]  [3-6]  [10-K]"; //Impresión en el RitchTextBox
        }

        //Método para enviar mensajes
        public void SendMsg()
        {
            string datos; //Variable para el envío y recepción de datos

            //Si el valor obtenido de la carta es 1 o 10
            if (ValorObtenido(carta) == 1 || ValorObtenido(carta) == 10)
                datos = "Carta: " + LetraObtenida(carta) + " de " + TipoPalo(carta); //Resultado de la letra de la carta y su familia
            else
                datos = "Carta: " + ValorObtenido(carta).ToString() + " de " + TipoPalo(carta); //Resultado del #carta y su familia

            NetworkStream flujo = Cliente.GetStream();  //Secuencia de datos para el acceso a la red obtenida del cliente y almanacenada en "flujo"
            byte[] bufferTx = Encoding.ASCII.GetBytes(usuario+" >> "+datos); //Envío de los datos
            flujo.Write(bufferTx, 0, bufferTx.Length); //Tamaño del envío de datos
            indicador = flujo.Read(bufferRx, 0, bufferRx.Length); //Longitud del bufferRx

            //Si la longitud es mayor a 0
            if (indicador > 0)
            {
                datos = Encoding.ASCII.GetString(bufferRx); //Recepción del mensaje 
                rchtCliente.AppendText("\n [" + DateTime.Now.ToShortDateString() + "]", Color.Red); //Fecha en color rojo
                rchtCliente.AppendText("[" + DateTime.Now.ToShortTimeString() + "] >>", Color.Green); //Hora en color verde
                rchtCliente.AppendText(" ");
                rchtCliente.AppendText(datos, Color.YellowGreen); //Mensaje recibido
            }
        }

        //Método en caso de presionar el botón Repartir
        private void btnRepartir_Click(object sender, EventArgs e)
        {
            carta = random.Next(1, 52); //Número aleatorio entre 1 al 52
            imgCarta.Image = Image.FromFile(ruta + carta.ToString() + ".png"); //Visualización de la imagen respecto al valor aleatorio salido
            puntajeBJ = puntajeBJ + ValorObtenido(carta); //Cálculo del puntaje
            lblValor.Text = "" + puntajeBJ; //Visualización del puntaje

            MostrarPalo(); //Llamada al método para mostrar el valor y la familia
            SendMsg(); //Llamada al método para enviar y recibir el mensaje

            //Si el puntaje obtenido en el juego es mayor o igual a 22
            if (puntajeBJ >= 22)
            {
                MessageBox.Show("YOU LOSE!!!", "FIN DEL JUEGO", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Mensaje resultante
                puntajeBJ = 0; //Se reinicia el puntaje
                lblValor.Text = " 0"; //Visualización del puntaje
                imgCarta.Image = Image.FromFile(ruta + "0.png"); //Se oculta la carta
                lbPalo.Text = " "; //Limpia el nombre de la carta
            }
            //Si el puntaje obtenido en el juego es 21
            else if (puntajeBJ == 21)
            {
                MessageBox.Show("YOU WIN!!", "FELICIDADES", MessageBoxButtons.OK, MessageBoxIcon.Information); //Mensaje reusltante
                puntajeBJ = 0; //Se reinicia el puntaje
                lblValor.Text = " 0"; //Visualización del puntaje
                imgCarta.Image = Image.FromFile(ruta + "0.png"); //Se oculta la carta
                lbPalo.Text = " "; //Limpia el nombre de la carta
            }

        }
        //Método para mostrar el nombre/número de la carta y su familia
        private void MostrarPalo()
        {
            //Si el valor de la carta es 1 o 10
            if (ValorObtenido(carta) == 1 || ValorObtenido(carta) == 10)
                lbPalo.Text = "Carta: " + LetraObtenida(carta) + " de " + TipoPalo(carta); //Se agrega el texto la letra y el tipo
            else
                lbPalo.Text = "Carta: " + ValorObtenido(carta).ToString() + " de " + TipoPalo(carta); //Se agrega el texto el valor y el tipo
        }

        //Método para obtener el valor obtenido de la carta
        private int ValorObtenido(int carta)
        {
            //A
            if (carta == 1 || carta == 14 || carta == 27 || carta == 40)
                valor = 1;
            //2
            else if (carta == 2 || carta == 15 || carta == 28 || carta == 41)
                valor = 2;
            //3
            else if (carta == 3 || carta == 16 || carta == 29 || carta == 42)
                valor = 3;
            //4
            else if (carta == 4 || carta == 17 || carta == 30 || carta == 43)
                valor = 4;
            //5
            else if (carta == 5 || carta == 18 || carta == 31 || carta == 44)
                valor = 5;
            //6
            else if (carta == 6 || carta == 19 || carta == 32 || carta == 45)
                valor = 6;
            //7
            else if (carta == 7 || carta == 20 || carta == 33 || carta == 46)
                valor = 7;
            //8
            else if (carta == 8 || carta == 21 || carta == 34 || carta == 47)
                valor = 8;
            //9
            else if (carta == 9 || carta == 22 || carta == 35 || carta == 48)
                valor = 9;
            //10, J, Q, K
            else if ((carta >= 10 && carta <= 13) || (carta >= 23 && carta <= 26) || (carta >= 36 && carta <= 39) || (carta >= 49 && carta <= 52))
                valor = 10;
            return valor;
        }

        //Método para obtener la letra de algunas cartas
        private string LetraObtenida(int carta)
        {
            string letra = null;
            //A
            if (carta == 1 || carta == 14 || carta == 27 || carta == 40)
                letra = "As";
            //10
            else if (carta == 10 || carta == 23 || carta == 36 || carta == 49)
                letra = "10";
            //J
            else if (carta == 11 || carta == 24 || carta == 37 || carta == 50)
                letra = "J";
            //Q
            else if (carta == 12 || carta == 25 || carta == 38 || carta == 51)
                letra = "Q";
            //K
            else if (carta == 13 || carta == 26 || carta == 39 || carta == 52)
                letra = "K";
            return letra;
        }

        //Método en caso de presionar el botón STOP
        private void btnStop_Click(object sender, EventArgs e)
        {
            int puntajeMaquina = random.Next(12, 21); //Valor aleatorio de la máquina
            string mensaje = "El juez obtuvo => " + puntajeMaquina; //Resultado obtenido de la máquina

            //Si el puntaje del jugador es mayor al de la máquina
            if (puntajeBJ > puntajeMaquina)
            {
                //Mensaje resultante
                MessageBox.Show(mensaje, "JUEZ PIERDE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("YOU WIN!!", "FELICIDADES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntajeBJ = 0; //Reinicio del puntaje
                lblValor.Text = " 0"; //Visualización del puntaje
                imgCarta.Image = Image.FromFile(ruta + "0.png"); //Se oculta la carta
                lbPalo.Text = " "; //Limpia el nombre de la carta
            }
            //Caso contrario
            else
            {
                //Mensaje resultante
                MessageBox.Show(mensaje, "JUEZ GANA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("YOU LOSE!!!", "FIN DEL JUEGO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                puntajeBJ = 0; //Reinicio del puntaje
                lblValor.Text = " 0"; //Visualización del puntaje
                imgCarta.Image = Image.FromFile(ruta + "0.png"); //Se oculta la carta
                lbPalo.Text = " "; //Limpia el nombre de la carta
            }
        }

        //Método para obtener el tipo de palo o familia
        private string TipoPalo(int carta)
        {
            string palo;

            //Corazones Negros
            if (carta < 15)
                palo = "Corazones Negros     ";
            //Corazones Rojos
            else if (carta >= 15 && carta < 27)
                palo = "Corazones Rojos      ";
            //Diamantes
            else if (carta >= 27 && carta < 40)
                palo = "Diamantes            ";
            //Trébol
            else
                palo = "Trebol               ";
            return palo;
        }

        //Método en caso de presionar el botón Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            string datos = "Reiniciar          "; //Mensaje de reiniciar

            NetworkStream flujo = Cliente.GetStream();  //Secuencia de datos para el acceso a la red obtenida del cliente y almanacenada en "flujo"
            byte[] bufferTx = Encoding.ASCII.GetBytes(usuario+" >> "+datos); //Envío del mensaje
            flujo.Write(bufferTx, 0, bufferTx.Length);  //Escritura de los datos sobre "flujo"

            indicador = flujo.Read(bufferRx, 0, bufferRx.Length); //Longitud del bufferRx

            //Si la longitud es mayor a 0
            if (indicador > 0)
            {
                datos = Encoding.ASCII.GetString(bufferRx); //Mensaje reicibido

                //Mensaje dentro del RitchTextBox
                rchtCliente.AppendText("\n\nCUENTA REINICIADA ", Color.Orange); //Cuenta reiniciada
                rchtCliente.AppendText("\n [" + DateTime.Now.ToShortDateString() + "]", Color.Red); //Fecha en color rojo
                rchtCliente.AppendText("[" + DateTime.Now.ToShortTimeString() + "] >>", Color.Green); //Hora en color verde
                rchtCliente.AppendText(" " + datos, Color.YellowGreen); //Mensaje en color amarillo naranjado
            }

            puntajeBJ = 0; //Reinicio del puntaje
            lblValor.Text = " 0"; //Visualización del puntaje
            imgCarta.Image = Image.FromFile(ruta + "0.png"); //Se oculta la carta
            lbPalo.Text = " "; //Limpia el nombre de la carta
        }
    }

    //Clase para extender el uso de los colores al String dentro de un RichTextBox
    public static class RichTextBoxExtensions
    {
        //Función para añadir al texto
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength; //Longitud del texto
            box.SelectionLength = 0; //Longitud inicial
            box.SelectionColor = color; //Selección del color
            box.AppendText(text); //Texto
            box.SelectionColor = box.ForeColor; //Aplicación al color de la fuente
        }
    }
}