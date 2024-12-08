using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas
{
    internal class Usuario
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string email, string contraseña)
        {
            Email = email;
            Contraseña = contraseña;
        }

        public bool Autenticar(string email, string contraseña)
        {
            return this.Email == email && this.Contraseña == contraseña;
        }
    }
}
