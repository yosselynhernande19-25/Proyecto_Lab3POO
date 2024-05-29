using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProyectoos.ServicioAutenticacion
{
   public interface IServicioAutenticacion
    {
        Usuario IniciarSesion(string correo, string contrasena);
        Usuario ObtenerUsuarioPorCorreo(string correo);
    }
}


