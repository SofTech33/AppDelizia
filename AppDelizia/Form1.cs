using ModeloUsuario;
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
            Usuario usuario = new Usuario(textBox1.Text, textBox2.Text, 0);

            // Verificar credenciales
            if (usuario.VerificarUsuario(textBox1.Text, textBox2.Text))
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
                textBox1.Text = "";
                textBox2.Text = "";
                // Asegúrate de reactivar el carácter de contraseña
                textBox2.UseSystemPasswordChar = true;

            }
            else
            {
                MessageBox.Show("Login incorrecto");
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
                if (string.IsNullOrEmpty(textBox1.Text)) // Placeholder para textBox1 en inglés
                {
                    textBox1.Text = "Username";
                    textBox1.ForeColor = Color.Gray;
                }
                if (string.IsNullOrEmpty(textBox2.Text)) // Placeholder para textBox2 en inglés
                {
                    textBox2.Text = "Password";
                    textBox2.ForeColor = Color.Gray;
                    textBox2.UseSystemPasswordChar = false;  // No mostrar caracteres como contraseñas
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text)) // Placeholder para textBox1 en español
                {
                    textBox1.Text = "Usuario";
                    textBox1.ForeColor = Color.Gray;
                }
                if (string.IsNullOrEmpty(textBox2.Text)) // Placeholder para textBox2 en español
                {
                    textBox2.Text = "Contraseña";
                    textBox2.ForeColor = Color.Gray;
                    textBox2.UseSystemPasswordChar = false;  // No mostrar caracteres como contraseñas
                }
            }
        }

        // Evento cuando el TextBox1 recibe el foco
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usuario")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Evento cuando el TextBox1 pierde el foco
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "" & idiomaIngles == true )
            {
                textBox1.Text = "Usuario";
                textBox1.ForeColor = Color.Gray;
            }
            if (textBox1.Text == "" & idiomaIngles == false)
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        // Evento cuando el TextBox2 recibe el foco
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contraseña")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }

        }

        // Evento cuando el TextBox2 pierde el foco
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "" & idiomaIngles == true)
            {
                textBox2.Text = "Contraseña";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
            }
            if (textBox2.Text == "" & idiomaIngles == false)
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
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
                button1.Text = "Iniciar";
                button2.Text = "Salir";
                label1.Text = "Iniciar sesión";
                textBox1.Text = "Usuario";
                textBox2.Text = "Contraseña";
            }
            else
            {
                // Cambiar a inglés
                button1.Text = "Sign in";
                button2.Text = "Exit";
                label1.Text = "Sign in";
                textBox1.Text = "Username";
                textBox2.Text = "Password";
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
    }
}