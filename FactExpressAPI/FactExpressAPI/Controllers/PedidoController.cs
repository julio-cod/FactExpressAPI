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

        //Listados

        [HttpGet]
        public IHttpActionResult listadoPedidosCreadosMobile(int codUsuario)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select codigoPedido,codigoCliente,nombreCliente,fechaOrden,fechaEntrega,lugarEntrega,totalDescuentos,total,estado,comentario,codUsuarioDelSistema from Pedidos where estado = 'Pendiente' and codUsuarioDelSistema = @codUsuarioDelSistema";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@codUsuarioDelSistema", codUsuario);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);


        }



        //Crear pedido

        [HttpPost]
        public IHttpActionResult CrearPedido(PedidoModel pedidoModel)
        {
            string idPedido = "";

            using (conectar)
            {
                
                if (pedidoModel.CodigoCliente.ToString() == "")
                {
                    return NotFound();

                }
                else
                {
                    conectar.Open();
                    //string query = "insert into Pedidos(codUsuarioDelSistema,nombreUsuarioDelSistema,codigoCliente,nombreCliente,lugarEntrega,fechaOrden,fechaEntrega,totalDescuentos,total,totalGanancia,estado,comentario,codUsuarioEntrega,nombreUsuarioEntrega)" +
                    //               " values (@codUsuarioDelSistema,@nombreUsuarioDelSistema,@codigoCliente,@nombreCliente,@lugarEntrega,@fechaOrden,@fechaEntrega,@totalDescuentos,@total,@totalGanancia,@estado,@comentario,@codUsuarioEntrega,@nombreUsuarioEntrega) SELECT SCOPE_IDENTITY();";

                    string query = "insert Into Pedidos Values (@codUsuarioDelSistema,@nombreUsuarioDelSistema,@codigoCliente,@nombreCliente,@lugarEntrega,@fechaOrden,@fechaEntrega,@totalDescuentos,@total,@totalGanancia,@estado,@comentario,@codUsuarioEntrega,@nombreUsuarioEntrega) SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@codUsuarioDelSistema", pedidoModel.CodUsuarioDelSistema);
                    cmd.Parameters.AddWithValue("@nombreUsuarioDelSistema", pedidoModel.NombreUsuarioDelSistema);
                    cmd.Parameters.AddWithValue("@codigoCliente", pedidoModel.CodigoCliente);
                    cmd.Parameters.AddWithValue("@nombreCliente", pedidoModel.NombreCliente);
                    cmd.Parameters.AddWithValue("@lugarEntrega", pedidoModel.LugarEntrega);
                    cmd.Parameters.AddWithValue("@fechaOrden", pedidoModel.FechaOrden);
                    cmd.Parameters.AddWithValue("@fechaEntrega", pedidoModel.FechaEntrega);
                    cmd.Parameters.AddWithValue("@totalDescuentos", pedidoModel.TotalDescuentos);
                    cmd.Parameters.AddWithValue("@total", pedidoModel.Total);
                    cmd.Parameters.AddWithValue("@totalGanancia", pedidoModel.TotalGanancia);
                    cmd.Parameters.AddWithValue("@estado", pedidoModel.Estado);
                    cmd.Parameters.AddWithValue("@comentario", pedidoModel.Comentario);
                    cmd.Parameters.AddWithValue("@codUsuarioEntrega", pedidoModel.CodUsuarioEntrega);
                    cmd.Parameters.AddWithValue("@nombreUsuarioEntrega", pedidoModel.NombreUsuarioEntrega);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //prueba = true;
                        try
                        {
                            //RECUPERAR EL CODIGO AUTOGENERADO

                            if (reader.Read())
                            {
                                idPedido = reader[0].ToString();
                            }

                        }
                        catch (Exception)
                        {
                            //objVenta.Estado = 1;

                        }
                        finally
                        {
                            cmd = null;
                            conectar.Close();
                        }


                    }
                    else
                    {
                        //prueba = false;
                    }

                    //return idPedido;


                }

            }
            //return Ok("Guardado");
            return Ok(idPedido);
        }



    }
}
