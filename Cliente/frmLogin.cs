using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmLogin : Form
    {
        //Inicio del formulario
        public frmLogin()
        {
            InitializeComponent();
        }

        //Método en caso de presionar el botón Conectar
        private void btnConectar_Click(object sender, EventArgs e)
        {
            //Si el texto no es nulo
            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                this.Hide();  //Oculta el formulario
                frmCliente formCliente = new frmCliente(); //Crea el formulario Cliente 
                formCliente.usuario = txtUsuario.Text; //Asigna el nombre del usuario al formulario
                formCliente.Show(); //Aparece el formulario
            }
        }

        //Método en caso de presionar la tecla Enter
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Si el texto está vacío
                if (txtUsuario.Text == String.Empty)
                {
                    MessageBox.Show("Falta ingresar usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Mensaje resultante
                }
                else
                {
                    this.Hide();  //Oculta el formulario
                    frmCliente formCliente = new frmCliente(); //Crea el formulario Cliente 
                    formCliente.usuario = txtUsuario.Text; //Asigna el nombre del usuario al formulario
                    formCliente.Show(); //Aparece el formulario
                }
            }
        }
    }
}