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
    public class CanastaController : ApiController
    {
        static string connectionString = "server=localhost; port=3306; userid=root; password=123456; database=padrones";
        MySqlConnection conn = new MySqlConnection(connectionString);



        // GET: api/Canasta
        public IEnumerable<Canasta> Get(string municipio)
        {
            MySqlDataReader dr = null;
            List<Canasta> canastas = new List<Canasta>();

            try
            {
                string command = $"call ConsultaMunicipio('{ municipio }', '')";
                MySqlCommand cmd = new MySqlCommand($"call ConsultaMunicipio('{ municipio }'); ", conn);
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM padrones.canastas LIMIT 3000;", conn);
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Canasta obj = new Canasta();
                    //obj.CALLE = "";

                    Canasta canasta = new Canasta
                    {
                        PROGRESIVO = Int32.Parse(dr["PROGRESIVO"].ToString()),
                        PROGRAMA = dr["PROGRAMA"].ToString(),
                        VERTIENTE = dr["VERTIENTE"].ToString(),
                        PRIMER_APELLIDO = dr["PRIMER_APELLIDO"].ToString(),
                        SEGUNDO_APELLIDO = dr["SEGUNDO_APELLIDO"].ToString(),
                        NOMBRE = dr["NOMBRE"].ToString(),
                        CALLE = dr["CALLE"].ToString(),
                        NUM_EXT = dr["NUM_EXT"].ToString(),
                        NUM_INT = dr["NUM_INT"].ToString(),
                        LOCALIDAD = dr["LOCALIDAD"].ToString(),
                        MUNICIPIO = dr["MUNICIPIO"].ToString(),
                        CURP = dr["CURP"].ToString(),
                        EDAD = dr["EDAD"].ToString(),
                        SEXO = dr["SEXO"].ToString(),
                        FOLIO_RELACIONADO = dr["FOLIO_RELACIONADO"].ToString(),
                        CANT_APOYOS_RECIBIDOS = dr["CANT_APOYOS_RECIBIDOS"].ToString(),
                        COSTO_UNITARIO = dr["COSTO_UNITARIO"].ToString(),
                        PRIMERA_ENTREGA = dr["PRIMERA_ENTREGA"].ToString(),
                        FT_01 = dr["FT_01"].ToString(),
                        SEGUNDA_ENTREGA = dr["SEGUNDA_ENTREGA"].ToString(),
                        FT_02 = dr["FT_02"].ToString(),
                        TERCERA_ENTREGA = dr["TERCERA_ENTREGA"].ToString(),
                        FT_03 = dr["FT_03"].ToString(),
                        CUARTA_ENTREGA = dr["CUARTA_ENTREGA"].ToString(),
                        FT_04 = dr["FT_04"].ToString(),
                        CODIGO_POSTAL = dr["CODIGO_POSTAL"].ToString(),
                        COLONIA = dr["COLONIA"].ToString(),



                    };

                    canastas.Add(canasta);
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return canastas;
        }



        // GET: api/Canasta/5
        public string Get(int id)
        {
            return "value";
        }



        // POST: api/Canasta
        public void Post([FromBody]string value)
        {
        }



        // PUT: api/Canasta/5
        //public void Put(Canasta canasta)
        //{
        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand($@"
        //        update padrones.canastas set
        //        CEDIS_OK='{ canasta.CEDIS_OK }',
        //        PRIMER_AP='{ canasta.PRIMER_AP }',
        //        SEGUNDO_AP='{ canasta.SEGUNDO_AP}',
        //        NOMBRES='{ canasta.NOMBRES }',
        //        FECHA_DE_NACIMIENTO='{ canasta.FECHA_DE_NACIMIENTO }',
        //        GENERO='{ canasta.GENERO}',
        //        CURP='{ canasta.CURP }',
        //        CLAVE_DE_ELECTOR='{ canasta.CLAVE_DE_ELECTOR }',
        //        CALLE='{ canasta.CALLE}',
        //        COLONIA='{ canasta.COLONIA }',
        //        ENTREGA_1='{ canasta.ENTREGA_1 }',
        //        ENTREGA_2='{ canasta.ENTREGA_2 }',
        //        ENTREGA_3='{ canasta.ENTREGA_3 }',
        //        ENTREGA_4='{ canasta.ENTREGA_4 }',
        //        ENTREGA_5='{ canasta.ENTREGA_5 }',
        //        ENTREGA_6='{ canasta.ENTREGA_6 }',
        //        ENTREGA_7='{ canasta.ENTREGA_7 }',
        //        ENTREGA_8='{ canasta.ENTREGA_8 }',
        //        ENTREGA_9='{ canasta.ENTREGA_9 }',
        //        ENTREGA_10='{ canasta.ENTREGA_10 }',
        //        ENTREGA_11='{ canasta.ENTREGA_11 }',
        //        ENTREGA_12='{ canasta.ENTREGA_12 }',
        //        COMENTARIOS='{ canasta.COMENTARIOS }'
        //        where ID_CODIGO={ canasta.ID_CODIGO }", conn);
        //        cmd.ExecuteNonQuery();
   
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}



        // DELETE: api/Canasta/5
        public void Delete(int id)
        {
        }
    }
}
