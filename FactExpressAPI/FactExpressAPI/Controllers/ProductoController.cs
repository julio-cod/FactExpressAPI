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
    public class ProductoController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        // listados

        [HttpGet]
        public IHttpActionResult ListaProductos()
        {

            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select * from Productos";
                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.Fill(dt);
            }

            return Ok(dt);


        }


        [HttpGet]
        public IHttpActionResult BuscarProductoPorNombre(string descripcion)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select * from Productos where descripcion = @descripcion";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@descripcion", descripcion);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);

        }
    }
}
