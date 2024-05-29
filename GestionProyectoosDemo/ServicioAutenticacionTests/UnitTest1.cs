using GestionDeProyectos;
using GestionProyectoos;
using GestionProyectoos.ServicioAutenticacion;
using NUnit.Framework;
using System.Collections.Generic;

namespace GestionDeProyectos.Tests
{
    [TestFixture]
    public class ServicioAutenticacionTests
    {
        private IServicioAutenticacion servicioAutenticacion;

        [SetUp]
        public void Setup()
        {
            servicioAutenticacion = new ServicioAutenticacion();
        }


        [Test]
        public void IniciarSesion_ConCredencialesInvalidas_RetornaNull()
        {
            var usuario = servicioAutenticacion.IniciarSesion("noexiste@egmail.com", "password");
            Assert.IsNull(usuario);
        }
    }
}
