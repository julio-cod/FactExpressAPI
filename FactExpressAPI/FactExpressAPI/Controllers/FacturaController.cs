using FactExpressAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FactExpressAPI.Controllers
{
    public class FacturaController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        //Actualizaciones

        [HttpPut]
        public IHttpActionResult EjecutarFacturaPedido(PedidoModel PedidoModel)
        {
            using (conectar)
            {
                conectar.Open();
                string query = "Update Pedidos Set estado = @estado Where codigoPedido = @codigoPedido";
                SqlCommand cmd = new SqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@codigoPedido", PedidoModel.CodigoPedido);
                cmd.Parameters.AddWithValue("@estado", PedidoModel.Estado);
                cmd.ExecuteNonQuery();
                conectar.Close();
            }

            return Ok("Actualizado");
        }

        

    }
}
