using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactExpressAPI.Models
{
    public class DetallePedidoModel
    {
        public int Codigo { get; set; }
        public int CodPedido { get; set; }
        public int CodProducto { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Ganancia { get; set; }
        public DateTime Fecha { get; set; }
    }
}