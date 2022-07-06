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
    public class VentaController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        [HttpPost]
        public IHttpActionResult RegistrarVentaPedido(VentaModel ventaModel)
        {
            using (conectar)
            {

                if (ventaModel.CodigoPedido.ToString() == "")
                {
                    return NotFound();

                }
                else
                {
                    conectar.Open();
                    string query = "insert Into Ventas Values (@codigoCliente,@nombreCliente,@codigoPedido,@totalDescuentos,@total,@totalGanancia,@tipoPago,@fecha,@codUsuarioEntrega,@nombreUsuarioEntrega)";
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@codigoCliente", ventaModel.CodigoCliente);
                    cmd.Parameters.AddWithValue("@nombreCliente", ventaModel.NombreCliente);
                    cmd.Parameters.AddWithValue("@codigoPedido", ventaModel.CodigoPedido);
                    cmd.Parameters.AddWithValue("@totalDescuentos", ventaModel.TotalDescuentos);
                    cmd.Parameters.AddWithValue("@total", ventaModel.Total);
                    cmd.Parameters.AddWithValue("@totalGanancia", ventaModel.TotalGanancia);
                    cmd.Parameters.AddWithValue("@tipoPago", ventaModel.TipoPago);
                    cmd.Parameters.AddWithValue("@fecha", ventaModel.Fecha);
                    cmd.Parameters.AddWithValue("@codUsuarioEntrega", ventaModel.CodUsuarioEntrega);
                    cmd.Parameters.AddWithValue("@nombreUsuarioEntrega", ventaModel.NombreUsuarioEntrega);
                    cmd.ExecuteNonQuery();

                    conectar.Close();

                }

            }
            return Ok("Guardado");

        }

        [HttpGet]
        public IHttpActionResult listadoVentasPorUsuario(int codUsuario)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoCliente,nombreCliente,codigoPedido,totalDescuentos,total,totalGanancia,tipoPago,fecha,codUsuarioEntrega,nombreUsuarioEntrega from Ventas Where codUsuarioEntrega = @codUsuarioEntrega ORDER BY codigoVenta DESC";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        [HttpGet]
        public IHttpActionResult listadoVentasPorTipoPago(int codUsuario,string tipoPago)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoCliente,nombreCliente,codigoPedido,totalDescuentos,total,totalGanancia,tipoPago,fecha,codUsuarioEntrega,nombreUsuarioEntrega from Ventas Where tipoPago = @tipoPago and codUsuarioEntrega = @codUsuarioEntrega ORDER BY codigoVenta DESC";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                sda.SelectCommand.Parameters.AddWithValue("@tipoPago", tipoPago);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        [HttpGet]
        public IHttpActionResult listadoVentasPorCliente(int codUsuario, string nombreCliente)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoCliente,nombreCliente,codigoPedido,totalDescuentos,total,totalGanancia,tipoPago,fecha,codUsuarioEntrega,nombreUsuarioEntrega from Ventas Where nombreCliente like ('%" + nombreCliente + "%') and codUsuarioEntrega = @codUsuarioEntrega ORDER BY codigoVenta DESC";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                //sda.SelectCommand.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

        [HttpGet]
        public IHttpActionResult listadoVentasPorTipoPagoYNombreCliente(int codUsuario, string tipoPago, string nombreCliente)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoCliente,nombreCliente,codigoPedido,totalDescuentos,total,totalGanancia,tipoPago,fecha,codUsuarioEntrega,nombreUsuarioEntrega from Ventas Where tipoPago = @tipoPago and nombreCliente like ('%" + nombreCliente + "%') and codUsuarioEntrega = @codUsuarioEntrega ORDER BY codigoVenta DESC";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioEntrega", codUsuario);
                sda.SelectCommand.Parameters.AddWithValue("@tipoPago", tipoPago);
                //sda.SelectCommand.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }

    }
}
