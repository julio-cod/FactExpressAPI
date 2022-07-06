using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactExpressAPI.Models
{
    public class ClienteModel
    {
        public int Codigo { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Sector { get; set; }
        public string Provincia { get; set; }
    }
}