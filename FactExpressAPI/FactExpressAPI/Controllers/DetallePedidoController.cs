using FactExpressAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FactExpressAPI.Controllers
{
    public class DetallePedidoController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        [HttpGet]
        public IHttpActionResult listadoDetallePedidosParaEntregar(int codPedido)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigo,codProducto,descripcion,cantidad,precio,descuento from DetallePedido where codPedido = @codPedido";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codPedido", codPedido);
                sda.Fill(dt);
            }

            return Ok(dt);


        }


    }
}
