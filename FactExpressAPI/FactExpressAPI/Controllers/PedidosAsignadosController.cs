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
    public class PedidosAsignadosController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);


        //Listados

        [HttpGet]
        public IHttpActionResult listadoPedidosParaEntregar(int codUsuario)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoPedido,codUsuarioEntrega,nombreUsuarioEntrega,codigoCliente,nombreCliente,lugarEntrega,fechaEntrega,totalDescuentos,total,estado,comentario from Pedidos Where estado = 'Asignado' and codUsuarioEntrega = @codUsuarioEntrega";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        [HttpGet]
        public IHttpActionResult listadoPedidosParaEntregarPorCliente(int codUsuario, string nombreCliente)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoPedido,codUsuarioEntrega,nombreUsuarioEntrega,codigoCliente,nombreCliente,lugarEntrega,fechaEntrega,totalDescuentos,total,estado,comentario from Pedidos Where estado = 'Asignado' and nombreCliente like ('%" + nombreCliente + "%') and codUsuarioEntrega = @codUsuarioEntrega";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                //sda.SelectCommand.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        //Actualizacion

        [HttpPut]
        public IHttpActionResult EditarPedidoCambioDetalle(PedidoModel PedidoModel)
        {
            using (conectar)
            {
                conectar.Open();
                string query = "Update Pedidos Set totalDescuentos = @totalDescuentos,total = @total,totalGanancia = @totalGanancia,estado = @estado Where codigoPedido = @codigoPedido";
                SqlCommand cmd = new SqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@codigoPedido", PedidoModel.CodigoPedido);
                cmd.Parameters.AddWithValue("@totalDescuentos", PedidoModel.TotalDescuentos);
                cmd.Parameters.AddWithValue("@total", PedidoModel.Total);
                cmd.Parameters.AddWithValue("@totalGanancia", PedidoModel.TotalGanancia);
                cmd.Parameters.AddWithValue("@estado", PedidoModel.Estado);
                cmd.ExecuteNonQuery();
                conectar.Close();
            }

            return Ok("Actualizado");
        }

    }
}
