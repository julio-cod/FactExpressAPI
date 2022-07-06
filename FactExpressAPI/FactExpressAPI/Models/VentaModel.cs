using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactExpressAPI.Models
{
    public class VentaModel
    {
        public int CodigoVenta { get; set; }
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int CodigoPedido { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal Total { get; set; }
        public decimal TotalGanancia { get; set; }
        public string TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public int CodUsuarioEntrega { get; set; }
        public string NombreUsuarioEntrega { get; set; }

        

    }
}