using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionProyectoos;

namespace GestionProyectoos
{
    public class Proyecto
    {
        public string Nombre { get; set; }
        public Usuario DesarrolladorAsignado { get; set; }
        public Usuario Cliente { get; set; }
        public bool EstaCompletado { get; set; }
        public bool EstadoPagado { get; set; }
        public bool PagoRealizado { get; set; }
        public bool? EstaPagado { get; set; }
    }

}