using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace modelos
{
    public static class ConexionBD
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["CadenaSQL"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public static DataTable EjecutarConsulta(string query, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open(); // 🔥 Abre la conexión antes de usarla

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int EjecutarComando(string query, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);

                    return comando.ExecuteNonQuery();
                }
            }
        }

        public static object EjecutarEscalar(string query, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddRange(parametros);
                    conexion.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }

}
