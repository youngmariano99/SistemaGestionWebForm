using modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ProductoController
    {
        public static void TransferirProductos(int empleadoOrigenId, int empleadoDestinoId)
        {
            string query = "UPDATE Productos SET EmpleadoResponsableId = @nuevo WHERE EmpleadoResponsableId = @origen";
            var parametros = new[]
            {
                new SqlParameter("@nuevo", empleadoDestinoId),
                new SqlParameter("@origen", empleadoOrigenId)
            };

            ConexionBD.EjecutarComando(query, parametros);
        }

        public static bool EmpleadoTieneProductosAsignados(int empleadoId)
        {
            string query = "SELECT COUNT(*) FROM Productos WHERE EmpleadoResponsableId = @EmpleadoId";
            var parametros = new[] { new SqlParameter("@EmpleadoId", empleadoId) };

            object resultado = ConexionBD.EjecutarEscalar(query, parametros);

            if (resultado != null && int.TryParse(resultado.ToString(), out int cantidad))
            {
                return cantidad > 0;
            }

            return false;
        }
    }
}
