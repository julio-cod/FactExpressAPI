using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactExpressAPI.Models
{
    public class ProductoModel
    {
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        

    }
}