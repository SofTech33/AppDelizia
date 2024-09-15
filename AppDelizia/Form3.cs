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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener una referencia al formulario principal (Form1)
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            // Mostrar Form1 si está disponible
            if (form1 != null)
            {
                form1.Show();
            }

            // Cerrar Form3
            this.Close();
        }
    }
}
