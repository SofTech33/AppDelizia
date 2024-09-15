using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloUsuario
{
    public class Usuario
    {
        private string usuario;
        private string contrasena;
        private int tipo;

        // Constructor
        public Usuario(string usuario, string contrasena, int tipo)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.tipo = tipo;
        }

        // Getters y Setters
        public string UsuarioNombre
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        // Método para verificar usuario
        public bool VerificarUsuario(string usuarioIngresado, string contrasenaIngresada)
        {
            return usuarioIngresado == "Admin" && contrasenaIngresada == "1234";
        }
    }
}
