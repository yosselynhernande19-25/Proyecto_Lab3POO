using GestionProyectoos.ServicioAutenticacion.GestionProyectoos.ServicioAutenticacion;
using GestionProyectoos;
using GestionProyectoos.ServicioAutenticacion;
using GestionProyectoos.ServicioProyecto;
using System;
using System.Collections.Generic;
using System.Linq;

IServicioAutenticacion servicioAutenticacion = new ServicioAutenticacion();
IServicioProyecto servicioProyecto = new ServicioProyecto();

List<Proyecto> proyectosAgregadosEnEjecucion = new List<Proyecto>();

Usuario desarrolladorPredeterminado = servicioAutenticacion.ObtenerUsuarioPorCorreo("dev@example.com");
if (desarrolladorPredeterminado != null)
{
    Proyecto proyecto1 = new Proyecto { Nombre = "Proyecto de Desarrollo de Tienda Electrónica" };
    Proyecto proyecto2 = new Proyecto { Nombre = "Desarrollo de Sistema Contable" };

    servicioProyecto.AgregarProyecto(proyecto1);
    servicioProyecto.AgregarProyecto(proyecto2);

    proyectosAgregadosEnEjecucion.Add(proyecto1);
    proyectosAgregadosEnEjecucion.Add(proyecto2);

    servicioProyecto.AsignarProyectoADesarrollador(proyecto1, desarrolladorPredeterminado);
    servicioProyecto.AsignarProyectoADesarrollador(proyecto2, desarrolladorPredeterminado);
}

Console.WriteLine("!!!!!! Bienvenido al sistema de gestión de proyectos !!!!!!");
Console.WriteLine("Ingrese su correo:");
string correo = Console.ReadLine();
Console.WriteLine("Ingrese su contraseña:");
string contrasena = Console.ReadLine();

Usuario usuario = servicioAutenticacion.IniciarSesion(correo, contrasena);
if (usuario == null)
{
    Console.WriteLine("Credenciales inválidas");
    return;
}

bool exit = false;

while (!exit)
{
    switch (usuario.Rol)
    {
        case RolUsuario.Administrador:
            exit = MostrarMenuAdministrador(servicioProyecto, proyectosAgregadosEnEjecucion);
            break;
        case RolUsuario.Desarrollador:
            exit = MostrarMenuDesarrollador(servicioProyecto, usuario);
            break;
        case RolUsuario.Cliente:
            exit = MostrarMenuCliente(servicioProyecto, usuario);
            break;
    }
}

bool MostrarMenuAdministrador(IServicioProyecto servicioProyecto, List<Proyecto> proyectosAgregadosEnEjecucion)
{
    while (true)
    {
        Console.WriteLine("\n ****************************** Menú de Administrador ***************************************");
        Console.WriteLine("1. Ver todos los proyectos");
        Console.WriteLine("2. Agregar un nuevo proyecto");
        Console.WriteLine("3. Salir");
        Console.WriteLine("************************************************************************************************");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                VerTodosLosProyectos(proyectosAgregadosEnEjecucion);
                break;
            case "2":
                AgregarNuevoProyecto(servicioProyecto, proyectosAgregadosEnEjecucion);
                break;
            case "3":
                return true;
            default:
                Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                break;
        }
    }
}

bool MostrarMenuDesarrollador(IServicioProyecto servicioProyecto, Usuario desarrollador)
{
    while (true)
    {
        Console.WriteLine("\n********************************************* Menú de Desarrollador **************************");
        Console.WriteLine("1. Ver mis proyectos asignados");
        Console.WriteLine("2. Salir");
        Console.WriteLine("************************************************************************************************");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                VerProyectosAsignados(servicioProyecto, desarrollador);
                break;
            case "2":
                return true;
            default:
                Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                break;
        }
    }
}

bool MostrarMenuCliente(IServicioProyecto servicioProyecto, Usuario cliente)
{
    while (true)
    {
        Console.WriteLine("\n************************************+****** Menú de Cliente **********************************");
        Console.WriteLine("1. Ver mis proyectos");
        Console.WriteLine("2. Salir");
        Console.WriteLine("************************************************************************************************");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                VerMisProyectos(servicioProyecto, cliente);
                break;
            case "2":
                return true;
            default:
                Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                break;
        }
    }
}

void VerTodosLosProyectos(List<Proyecto> proyectosAgregadosEnEjecucion)
{
    if (proyectosAgregadosEnEjecucion.Count == 0)
    {
        Console.WriteLine("No hay proyectos para mostrar.");
    }
    else
    {
        foreach (var proyecto in proyectosAgregadosEnEjecucion)
        {
            Console.WriteLine($"Nombre: {proyecto.Nombre}");
        }
    }
}

void AgregarNuevoProyecto(IServicioProyecto servicioProyecto, List<Proyecto> proyectosAgregadosEnEjecucion)
{
    Console.WriteLine("Ingrese el nombre del proyecto:");
    string nombreProyecto = Console.ReadLine();
    Proyecto nuevoProyecto = new Proyecto { Nombre = nombreProyecto };
    servicioProyecto.AgregarProyecto(nuevoProyecto);
    proyectosAgregadosEnEjecucion.Add(nuevoProyecto);
    Console.WriteLine("Proyecto agregado");
}

void VerProyectosAsignados(IServicioProyecto servicioProyecto, Usuario desarrollador)
{
    var proyectosAsignados = servicioProyecto.ObtenerProyectosPorUsuario(desarrollador).Where(p => !p.EstaCompletado).ToList();
    foreach (var proyecto in proyectosAsignados)
    {
        Console.WriteLine($"Nombre: {proyecto.Nombre}");
    }
}

void VerMisProyectos(IServicioProyecto servicioProyecto, Usuario cliente)
{
    var proyectosCliente = servicioProyecto.ObtenerProyectosPorUsuario(cliente);
    foreach (var proyecto in proyectosCliente)
    {
        Console.WriteLine($"Nombre: {proyecto.Nombre}");
        if (proyecto.EstaCompletado)
        {
            Console.WriteLine("¡Su proyecto está completado!");
        }
    }
}
