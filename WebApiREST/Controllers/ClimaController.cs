using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApiREST.Controllers
{

    public class respuesta
    {
        public string Planeta { get; set; }
        public string Dia { get; set; }
        public string Clima { get; set; }
    }

    public class ClimaController : ApiController
    {

        //  [HttpGet]
        public JsonResult<respuesta> Get(int id)
        {

            var consulta = ConsultaClimaDia(id);
            respuesta response = new respuesta();
            response.Dia = consulta[0];
            response.Clima = consulta[2];



            return this.Json<respuesta>(response);
            // Request.CreateResponse(consulta);
        }// Fin del método.




        public string[] Get()
        {
            return new string[]
            {
                "Hello",
                "World"
            };
        }

        public static string[] ConsultaClimaDia(int dia)
        {

            string connectionString = "data source=servermario.database.windows.net;initial catalog=Clima;user id=mamorales;password=Bauti2020;MultipleActiveResultSets=True;App=EntityFramework";


            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from [Table] "
                    + "WHERE Dia = @Dia";

            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                // Create the Command and Parameter objects.

                command.Parameters.AddWithValue("Dia", dia);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); ;
                try
                {

                    while (reader.Read())
                    {
                        // string climaDia =  " " + " " +
                        // Console.WriteLine("\t{0}\t{1}\t{2}",
                        return new string[] { reader[2].ToString(), reader[1].ToString(), reader[5].ToString() };
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }

            return new string[] { "", "" };
        }


    }
}
