using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionProyectoos.ServicioProyecto
{
    public class ServicioProyecto : IServicioProyecto
    {
        private List<Proyecto> proyectos;

        public ServicioProyecto()
        {
            proyectos = new List<Proyecto>();
        }

        public void AgregarProyecto(Proyecto proyecto)
        {
            proyectos.Add(proyecto);
        }

        public void AsignarProyectoADesarrollador(Proyecto proyecto, Usuario desarrollador)
        {
            var proyectoExistente = proyectos.FirstOrDefault(p => p.Nombre == proyecto.Nombre);
            if (proyectoExistente != null)
            {
                proyectoExistente.DesarrolladorAsignado = desarrollador;
            }
        }

        public IEnumerable<Proyecto> ObtenerTodosLosProyectos()
        {
            return proyectos;
        }

        public IEnumerable<Proyecto> ObtenerProyectosPorUsuario(Usuario usuario)
        {
            return proyectos.Where(p => p.DesarrolladorAsignado == usuario || p.Cliente == usuario);
        }

        public void MarcarProyectoComoPagado(Proyecto proyecto)
        {
            var proyectoExistente = proyectos.FirstOrDefault(p => p.Nombre == proyecto.Nombre);
            if (proyectoExistente != null)
            {
                proyectoExistente.EstadoPagado = true;
            }
        }

        public void AsignarProyectoAUsuario(Proyecto proyecto, Usuario usuario)
        {
            var proyectoExistente = proyectos.FirstOrDefault(p => p.Nombre == proyecto.Nombre);
            if (proyectoExistente != null)
            {
                if (usuario.Rol == RolUsuario.Desarrollador)
                {
                    proyectoExistente.DesarrolladorAsignado = usuario;
                }
                else if (usuario.Rol == RolUsuario.Cliente)
                {
                    proyectoExistente.Cliente = usuario;
                }
            }
        }
    }
}

