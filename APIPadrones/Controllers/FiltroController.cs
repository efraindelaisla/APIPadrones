using APIPadrones.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPadrones.Controllers
{
    public class FiltroController : ApiController
    {
        static string connectionString = "server=localhost; port=3306; userid=root; password=123456; database=padrones";
        MySqlConnection conn = new MySqlConnection(connectionString);

        [HttpGet]
        public IEnumerable<string> GetMunicipio()
        {
            MySqlDataReader dr = null;
            List<string> municipio = new List<string>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("select distinct municipio from padrones.canastas", conn);
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    municipio.Add(dr["municipio"].ToString());

                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return municipio;
        }
    }
}