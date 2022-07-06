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
    public class PedidosEntregadosController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        [HttpGet]
        public IHttpActionResult listadoPedidosEntregados(int codUsuario)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoPedido,codUsuarioEntrega,nombreUsuarioEntrega,codigoCliente,nombreCliente,lugarEntrega,fechaEntrega,totalDescuentos,total,estado,comentario from Pedidos Where estado = 'Entregado' and codUsuarioEntrega = @codUsuarioEntrega";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        

    }
}
