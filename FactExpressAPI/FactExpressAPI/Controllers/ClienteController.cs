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
    public class ClienteController : ApiController
    {
        SqlConnection conectar = new SqlConnection(ConexionDB.connectionString);

        // listados

        [HttpGet]
        public IHttpActionResult ListaClientes()
        {

            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select * from Clientes";
                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.Fill(dt);
            }

            return Ok(dt);


        }


        [HttpGet]
        public IHttpActionResult BuscarClientePorNombre(string nombreCliente)
        {
            DataTable dt = new DataTable();
            using (conectar)
            {
                conectar.Open();
                string query = "Select * from Clientes where nombreCliente = @nombreCliente";

                SqlDataAdapter sda = new SqlDataAdapter(query, conectar);
                sda.SelectCommand.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                sda.Fill(dt);
                conectar.Close();
            }

            return Ok(dt);

        }

    }
}
