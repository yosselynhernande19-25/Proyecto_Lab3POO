using GestionProyectoos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestionProyectoos.ServicioProyecto
{
    public interface IServicioProyecto
    {
        void AgregarProyecto(Proyecto proyecto);
        void AsignarProyectoADesarrollador(Proyecto proyecto, Usuario desarrollador);
        IEnumerable<Proyecto> ObtenerTodosLosProyectos();
        IEnumerable<Proyecto> ObtenerProyectosPorUsuario(Usuario usuario);
    }
}

