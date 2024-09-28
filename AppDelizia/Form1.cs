using ModeloUsuario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDelizia
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetPlaceholders(); // Establece placeholder al cargar el formulario
            CambiarIdioma(); // Inicializa el idioma por defecto (español en este caso)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la clase Usuario
            Usuario usuario = new Usuario(textUsuario.Text, textContraseña.Text, 0);

            // Verificar credenciales
            if (usuario.VerificarUsuario(textUsuario.Text, textContraseña.Text))
            {
                MessageBox.Show("Login correcto");

                // Crear una nueva instancia del formulario
                Form2 adminForm = new Form2();

                //Ocultar Form1
                this.Hide();

                // Mostrar el formulario
                adminForm.Show();

                // Manejar el evento de cierre de Form2 para volver a mostrar Form1 si es necesario
                adminForm.FormClosed += (s, args) => this.Show();

                // Limpiar los campos de texto después del login correcto
                textUsuario.Text = "";
                textContraseña.Text = "";
                // Asegúrate de reactivar el carácter de contraseña
                textContraseña.UseSystemPasswordChar = true;

            }
            else
            {
                MessageBox.Show("Login incorrecto");
            }
        }

        // Prueba de conexión con la DB
        public void TestDatabaseConnection()
        {
            string connectionString = "server=localhost;port=3306;database=delizia;user=root;password=";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexión a la base de datos exitosa");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Establece los placeholders para ambos TextBox al cargar el formulario
        private void SetPlaceholders()
        {
            if (idiomaIngles)
            {
                if (string.IsNullOrEmpty(textUsuario.Text)) // Placeholder para textBox1 en inglés
                {
                    textUsuario.Text = "Username";
                    textUsuario.ForeColor = Color.Gray;
                }
                if (string.IsNullOrEmpty(textContraseña.Text)) // Placeholder para textBox2 en inglés
                {
                    textContraseña.Text = "Password";
                    textContraseña.ForeColor = Color.Gray;
                    textContraseña.UseSystemPasswordChar = false;  // No mostrar caracteres como contraseñas
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textUsuario.Text)) // Placeholder para textBox1 en español
                {
                    textUsuario.Text = "Usuario";
                    textUsuario.ForeColor = Color.Gray;
                }
                if (string.IsNullOrEmpty(textContraseña.Text)) // Placeholder para textBox2 en español
                {
                    textContraseña.Text = "Contraseña";
                    textContraseña.ForeColor = Color.Gray;
                    textContraseña.UseSystemPasswordChar = false;  // No mostrar caracteres como contraseñas
                }
            }
        }

        // Evento cuando el TextBox1 recibe el foco
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textUsuario.Text == "Usuario")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.Black;
            }
            if (textUsuario.Text == "Username")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.Black;
            }
        }

        // Evento cuando el TextBox1 pierde el foco
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "" & idiomaIngles == true )
            {
                textUsuario.Text = "Usuario";
                textUsuario.ForeColor = Color.Gray;
            }
            if (textUsuario.Text == "" & idiomaIngles == false)
            {
                textUsuario.Text = "Username";
                textUsuario.ForeColor = Color.Gray;
            }
        }

        // Evento cuando el TextBox2 recibe el foco
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textContraseña.Text == "Contraseña")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.Black;
                textContraseña.UseSystemPasswordChar = true;
            }
            if (textContraseña.Text == "Password")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.Black;
                textContraseña.UseSystemPasswordChar = true;
            }

        }

        // Evento cuando el TextBox2 pierde el foco
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textContraseña.Text == "" & idiomaIngles == true)
            {
                textContraseña.Text = "Contraseña";
                textContraseña.ForeColor = Color.Gray;
                textContraseña.UseSystemPasswordChar = false;
            }
            if (textContraseña.Text == "" & idiomaIngles == false)
            {
                textContraseña.Text = "Password";
                textContraseña.ForeColor = Color.Gray;
                textContraseña.UseSystemPasswordChar = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Evento para el idioma

        private bool idiomaIngles = true; // true para español, false para inglés;

        private void CambiarIdioma()
        {
            if (idiomaIngles)
            {
                // Cambiar a español
                btnIniciar.Text = "Iniciar";
                btnSalir.Text = "Salir";
                label1.Text = "Iniciar sesión";
                textUsuario.Text = "Usuario";
                textContraseña.Text = "Contraseña";
            }
            else
            {
                // Cambiar a inglés
                btnIniciar.Text = "Sign in";
                btnSalir.Text = "Exit";
                label1.Text = "Sign in";
                textUsuario.Text = "Username";
                textContraseña.Text = "Password";
            }
        }

        //Fin evento Idioma

        private void btnIdioma_Click(object sender, EventArgs e)
        {
            // Cambia el valor de la variable para alternar el idioma
            idiomaIngles = !idiomaIngles;

            // Cambiar los textos según el idioma seleccionado
            CambiarIdioma();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            TestDatabaseConnection();
        }
    }
}