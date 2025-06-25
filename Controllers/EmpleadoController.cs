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
    public static class EmpleadoController
    {

        // MÉTODOS ESTÁTICOS PARA EL LOGIN DEL EMPLEADO INICIO //
        public static Empleado ValidarEmpleado(string email, string password)
        {
            string query = "SELECT * FROM Empleados WHERE Email = @Email AND Contraseña = @Pass";

            var parametros = new List<SqlParameter>
        {
            new SqlParameter("@Email", email),
            new SqlParameter("@Pass", password)
        };

            DataTable resultado = ConexionBD.EjecutarConsulta(query, parametros.ToArray());

            if (resultado.Rows.Count == 1)
            {
                DataRow row = resultado.Rows[0];
                return new Empleado
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Dni = row["Dni"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    Email = row["Email"].ToString()
                };
            }

            return null; // Credenciales inválidas
        }
    

    // MÉTODOS ESTÁTICOS PARA EL LOGIN DEL EMPLEADO FIN //



    // MÉTODOS ESTÁTICOS PARA FUNCIONES PRINCIPALES DEL EMPLEADO INICIO//

    // Método para obtener todos los productos //
    public static List<Producto> ObtenerProductosPorEmpleado(int empleadoId)
        {
            string query = @"
                SELECT p.Id, p.Nombre, p.Categoria, p.Stock, p.Precio, e.Nombre AS EmpleadoResponsable
                FROM Productos p
                JOIN Empleados e ON e.Id = p.EmpleadoResponsableId;";

            var parametros = new[]
            {
                new SqlParameter("@EmpleadoId", empleadoId)
            };

            DataTable dt = ConexionBD.EjecutarConsulta(query, parametros);

            List<Producto> productos = new List<Producto>();

            foreach (DataRow row in dt.Rows)
            {
                Producto p = new Producto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Categoria = row["Categoria"].ToString(),
                    Stock = Convert.ToInt32(row["Stock"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    nombeEmpleadoResponsable = row["EmpleadoResponsable"].ToString(),
                    // EmpleadoResponsableId = Convert.ToInt32(row["EmpleadoResponsableId"])
                };

                productos.Add(p);
            }

            return productos;
        }

        //Método para eliminar un producto //

        public static bool EliminarProductoPorId(int productoId)
        {
            string query = "DELETE FROM Productos WHERE Id = @ID";

            var parametros = new[]
            {
                new SqlParameter("@ID", productoId)
             };

            int filasAfectadas = ConexionBD.EjecutarComando(query, parametros);
            return filasAfectadas > 0;
        }

        
        //Método para editar un producto //

        public static bool ActualizarProducto(Producto producto)
        {
            string query = @"UPDATE Productos 
                     SET
                     Nombre = @Nombre,
                     Categoria = @Categoria,
                     Stock = @Stock,
                     Precio = @Precio
                     WHERE Id = @Id";

            var parametros = new[]
            {
                new SqlParameter("@Id", producto.Id),
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Categoria", producto.Categoria),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@Precio", producto.Precio)
                
             };

            return ConexionBD.EjecutarComando(query, parametros) > 0;
        }

        //Método para agregar un nuevo producto a la base de datos //

        public static bool AgregarProducto(Producto nuevoProducto)
        {
            string query = @"INSERT INTO Productos (Nombre, Categoria, Stock, Precio, EmpleadoResponsableId)
                     VALUES (@nombre, @categoria, @stock, @precio, @empleadoResponsable)";

            var parametros = new[]
            {
                new SqlParameter("@nombre", nuevoProducto.Nombre),
                new SqlParameter("@categoria", nuevoProducto.Categoria),
                new SqlParameter("@stock", nuevoProducto.Stock),
                new SqlParameter("@precio", nuevoProducto.Precio),
                new SqlParameter("@empleadoResponsable", nuevoProducto.EmpleadoResponsableId)
            };

            return ConexionBD.EjecutarComando(query, parametros) > 0;
        }


        // MÉTODOS ESTÁTICOS PARA FUNCIONES PRINCIPALES DEL EMPLEADO FIN//

        // MÉTODO PARA CONTROL DE ACCESO DEL EMPLEADO INICIO //
        public static void RegistrarAcceso(int empleadoId)
        {
            string query = "INSERT INTO AccesosEmpleado (EmpleadoId) VALUES (@EmpleadoId)";
            var parametros = new[] { new SqlParameter("@EmpleadoId", empleadoId) };
            ConexionBD.EjecutarComando(query, parametros);
        }

        // MÉTODO PARA CONTROL DE ACCESO DEL EMPLEADO FIN //

    }
} // Fin del namespace
