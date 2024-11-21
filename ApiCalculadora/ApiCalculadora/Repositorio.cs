using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ApiCalculadora.Models
{
    

    public class Repositorio
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CalculadoraDB"].ConnectionString;

        public List<Operaciones> ObtenerOperaciones(string tipo = null)
        {
            List<Operaciones> operaciones = new List<Operaciones>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM operaciones";
                if (!string.IsNullOrEmpty(tipo))
                {
                    query += " WHERE tipo = @tipo";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(tipo))
                    {
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            operaciones.Add(new Operaciones
                            {
                                Id = (int)reader["id"],
                                Operacion = reader["operacion"].ToString(),
                                Resultado = reader["resultado"].ToString(),
                                fecha_operacion = (DateTime)reader["fecha_operacion"],
                                Tipo = reader["tipo"].ToString()
                            });
                        }
                    }
                }
            }

            return operaciones;
        }

        public void CrearOperacion(Operaciones operacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO operaciones (operacion, resultado, fecha_operacion, tipo) VALUES (@operacion, @resultado, @fecha_operacion, @tipo)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@operacion", operacion.Operacion);
                    cmd.Parameters.AddWithValue("@resultado", operacion.Resultado);
                    cmd.Parameters.AddWithValue("@fecha_operacion", operacion.fecha_operacion);
                    cmd.Parameters.AddWithValue("@tipo", operacion.Tipo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}