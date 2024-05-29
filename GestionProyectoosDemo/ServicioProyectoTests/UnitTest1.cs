using NUnit.Framework;
using System.Collections.Generic;
using GestionProyectoos;
using GestionProyectoos.ServicioProyecto;

namespace GestionDeProyectos.Tests
{
    [TestFixture]
    public class ServicioProyectoTests
    {
        private IServicioProyecto servicioProyecto;
        private Usuario desarrollador;
        private Usuario cliente;

        [SetUp]
        public void Setup()
        {
            servicioProyecto = new ServicioProyecto();
            desarrollador = new Usuario { Correo = "devJuarez@gmail.com", Contrasena = "dev123", Rol = RolUsuario.Desarrollador };
            cliente = new Usuario { Correo = "clienteSandoval@gmail.com", Contrasena = "cliente123", Rol = RolUsuario.Cliente };
        }

        [Test]
        public void AgregarProyecto_ProyectoNuevo_ProyectoAgregado()
        {
            Proyecto proyecto = new Proyecto { Nombre = "Proyecto 1", DesarrolladorAsignado = desarrollador, Cliente = cliente };
            servicioProyecto.AgregarProyecto(proyecto);

            var proyectos = servicioProyecto.ObtenerTodosLosProyectos();
            Assert.Contains(proyecto, (System.Collections.ICollection?)proyectos);
        }


    }
}
