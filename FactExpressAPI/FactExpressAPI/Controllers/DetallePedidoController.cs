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

        // listados

        [HttpGet]
        public IHttpActionResult listadoDetallePedidos(int codPedido)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigo,codProducto,descripcion,cantidad,precio,descuento from DetallePedido where codPedido = @codPedido";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codPedido", codPedido);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);
            

        }

        //Crear detalles de pedido

        [HttpPost]
        public IHttpActionResult CrearDetallePedido(DetallePedidoModel detallePedidoModel)
        {
            using (conectar)
            {
                if (detallePedidoModel.CodPedido.ToString() == "")
                {
                    return NotFound();

                }
                else
                {
                    conectar.Open();
                    string query = "insert into DetallePedido(codPedido,codProducto,descripcion,categoria,cantidad,precio,descuento,ganancia,fecha)" +
                                   " values (@codPedido,@codProducto,@descripcion,@categoria,@cantidad,@precio,@descuento,@ganancia,@fecha)";
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@codPedido", detallePedidoModel.CodPedido);
                    cmd.Parameters.AddWithValue("@codProducto", detallePedidoModel.CodProducto);
                    cmd.Parameters.AddWithValue("@descripcion", detallePedidoModel.Descripcion);
                    cmd.Parameters.AddWithValue("@categoria", detallePedidoModel.Categoria);
                    cmd.Parameters.AddWithValue("@cantidad", detallePedidoModel.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", detallePedidoModel.Precio);
                    cmd.Parameters.AddWithValue("@descuento", detallePedidoModel.Descuento);
                    cmd.Parameters.AddWithValue("@ganancia", detallePedidoModel.Ganancia);
                    cmd.Parameters.AddWithValue("@fecha", detallePedidoModel.Fecha);
                    cmd.ExecuteNonQuery();

                    conectar.Close();
                }

            }

            return Ok("Guardado");
        }

        //Eliminar items

        [HttpDelete]
        public IHttpActionResult EliminarDetallePedido(int codigo)
        {
            using (conectar)
            {
                conectar.Open();
                string query = "Delete from DetallePedido Where codigo= @codigo";
                SqlCommand cmd = new SqlCommand(query, conectar);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                conectar.Close();
            }


            return Ok("Eliminado");
        }


    }
}
