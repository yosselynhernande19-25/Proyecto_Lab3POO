using GestionProyectoos.ServicioAutenticacion.GestionProyectoos.ServicioAutenticacion;
using GestionProyectoos;

public class ServicioAutenticacion : IServicioAutenticacion
{
    private List<Usuario> usuarios;

    public ServicioAutenticacion()
    {

        usuarios = new List<Usuario>
        {
            new Usuario { Correo = "adminLuk@gmail.com", Contrasena = "admin123", Rol = RolUsuario.Administrador },
            new Usuario { Correo = "devJuarez@gmail.com", Contrasena = "dev123", Rol = RolUsuario.Desarrollador },
            new Usuario { Correo = "clienteSandoval@gmail.com", Contrasena = "client123", Rol = RolUsuario.Cliente }
        };
    }

    public Usuario IniciarSesion(string correo, string contrasena)
    {

        return usuarios.FirstOrDefault(u => u.Correo == correo && u.Contrasena == contrasena);
    }

    public Usuario ObtenerUsuarioPorCorreo(string correo)
    {

        return usuarios.FirstOrDefault(u => u.Correo == correo);
    }
}
