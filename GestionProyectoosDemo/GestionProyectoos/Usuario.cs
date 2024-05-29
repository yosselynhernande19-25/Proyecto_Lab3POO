using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionProyectoos;

namespace GestionProyectoos
{
    public class Usuario
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public RolUsuario Rol { get; set; }
    }

    public enum RolUsuario
    {
        Administrador,
        Desarrollador,
        Cliente
    }
}

