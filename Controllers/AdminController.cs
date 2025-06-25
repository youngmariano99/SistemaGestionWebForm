using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelos;

namespace Controllers
{
    public static class AdminController
    {

        // MÉTODOS ESTÁTICOS PARA EL LOGIN DEL ADMINISTRADOR INICIO //
        public static bool ValidarAdmin(string email, string password, out DataRow adminEncontrado)
        {
            string query = @"SELECT * 
                            FROM Administradores 
                            WHERE Email = @Email AND Contraseña = @Pass";
            List<SqlParameter> parametros = new List<SqlParameter>
        {
            new SqlParameter("@Email", email),
            new SqlParameter("@Pass", password)
        };

            DataTable resultado = ConexionBD.EjecutarConsulta(query, parametros.ToArray());

            if (resultado.Rows.Count == 1)
            {
                adminEncontrado = resultado.Rows[0];
                return true;
            }

            adminEncontrado = null;
            return false;
        }

        // MÉTODOS ESTÁTICOS PARA EL LOGIN DEL ADMINISTRADOR FIN //

        // MÉTODOS ESTÁTICOS PARA FUNCIONES PRINCIPALES DEL ADMINISTRADOR INICIO //



        // Método para obtener todos los empleados
        public static List<Empleado> ObtenerTodosLosEmpleados()
        {
            string query = @"SELECT Id, Nombre, Apellido, Dni, FechaNacimiento, Email, Contraseña 
                             FROM Empleados
                             WHERE Activo = 1";
            DataTable dt = ConexionBD.EjecutarConsulta(query);

            List<Empleado> empleados = new List<Empleado>();

            foreach (DataRow row in dt.Rows)
            {
                Empleado emp = new Empleado
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Dni = row["Dni"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    Email = row["Email"].ToString(),
                    Contraseña = row["Contraseña"].ToString()
                };

                empleados.Add(emp);
            }

            return empleados;
        }

        // Método para eliminar un empleado
        public static bool DesactivarEmpleadoPorId(int id)
        {
            if (EmpleadoTieneProductosAsignados(id))
                throw new InvalidOperationException("El empleado tiene productos asignados y no se puede eliminar.");

                string query = @" UPDATE Empleados 
                                  SET Activo = 0
                                  WHERE Id = @ID";

                var parametros = new[]
                {
                    new SqlParameter("@ID", id)
                };

            return ConexionBD.EjecutarComando(query, parametros) > 0;
        }

        //Método para validar si un empleado tiene un producto asignado
        public static bool EmpleadoTieneProductosAsignados(int empleadoId)
        {
            string query = @"
            SELECT COUNT(*) 
            FROM Productos 
            WHERE EmpleadoResponsableId = @EmpleadoId";

            var parametros = new[]
            {
                new SqlParameter("@EmpleadoId", empleadoId)
            };

            int cantidad = (int)ConexionBD.EjecutarComando(query, parametros);

            return cantidad > 0;
        }

        // Método para editar un empleado
        public static bool ActualizarEmpleado(Empleado empleado)
        {
            string query = @"UPDATE Empleados SET
                     Nombre = @Nombre,
                     Apellido = @Apellido,
                     Dni = @Dni,
                     FechaNacimiento = @FechaNacimiento,
                     Email = @Email,
                     Contraseña = @Contraseña
                     WHERE Id = @Id";

            var parametros = new[]
            {
                new SqlParameter("@Id", empleado.Id),
                new SqlParameter("@Nombre", empleado.Nombre),
                new SqlParameter("@Apellido", empleado.Apellido),
                new SqlParameter("@Dni", empleado.Dni),
                new SqlParameter("@FechaNacimiento", empleado.FechaNacimiento),
                new SqlParameter("@Email", empleado.Email),
                new SqlParameter("@Contraseña", empleado.Contraseña)
            };

            return ConexionBD.EjecutarComando(query, parametros) > 0;
        }

        // Método para agregar un nuevo empleado //
        public static bool AgregarEmpleado(Empleado nuevoEmpleado)
        {
            string query = @"INSERT INTO Empleados (Nombre, Apellido, Dni, FechaNacimiento, Email, Contraseña)
                     VALUES (@nombre, @apellido, @dni, @fechaNacimiento, @email, @contraseña)";

            var parametros = new[]
            {
                new SqlParameter("@nombre", nuevoEmpleado.Nombre),
                new SqlParameter("@apellido", nuevoEmpleado.Apellido),
                new SqlParameter("@dni", nuevoEmpleado.Dni),
                new SqlParameter("@fechaNacimiento", nuevoEmpleado.FechaNacimiento),
                new SqlParameter("@email", nuevoEmpleado.Email),
                new SqlParameter("@contraseña", nuevoEmpleado.Contraseña)
            };

            return ConexionBD.EjecutarComando(query, parametros) > 0;
        }

        // MÉTODOS ESTÁTICOS PARA FUNCIONES PRINCIPALES DEL ADMINISTRADOR FIN //

        // MÉTODOS ESTÁTICOS PARA CONTROL ACCESO DE LOS EMPLEADOS INICIO //
        public static List<RegistroAccesoEmpleado> ObtenerAccesosPorRango(DateTime desde, DateTime hasta)
        {
            string query = @"
            SELECT E.Id, E.Nombre, E.Apellido, COUNT(*) AS CantidadAccesos
            FROM AccesosEmpleado AE
            INNER JOIN Empleados E ON AE.EmpleadoId = E.Id
            WHERE AE.FechaHoraAcceso BETWEEN @Desde AND @Hasta
            GROUP BY E.Id, E.Nombre, E.Apellido
            ORDER BY CantidadAccesos DESC";

            var parametros = new[]
            {
                new SqlParameter("@Desde", desde),
                new SqlParameter("@Hasta", hasta)
            };

            DataTable dt = ConexionBD.EjecutarConsulta(query, parametros);

            List<RegistroAccesoEmpleado> lista = new List<RegistroAccesoEmpleado>();

            foreach (DataRow row in dt.Rows)
            {
                var empleado = new Empleado
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString()
                };

                int cantidad = Convert.ToInt32(row["CantidadAccesos"]);

                lista.Add(new RegistroAccesoEmpleado
                {
                    Empleado = empleado,
                    CantidadAccesos = cantidad
                });
            }

            return lista;
        }

        // MÉTODOS ESTÁTICOS PARA CONTROL ACCESO DE LOS EMPLEADOS FIN //



    }
}
