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
    public class PedidoController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        [HttpGet]
        public IHttpActionResult listadoPedidosParaEntregar(int codUsuario)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codPedido,codUsuarioEnttrega,nombreUsuario,codigoCliente,nombreCliente,lugarEntrega,fechaEntrega,totalDescuentos,total,estado,comentario from PedidosAsignados Where estado = 'Asignado' and codUsuarioEnttrega = @codUsuarioEnttrega";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEnttrega", codUsuario);
                sda.Fill(dt);
            }

            return Ok(dt);


        }




    }
}
