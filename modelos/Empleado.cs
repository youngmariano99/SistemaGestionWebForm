using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        
        public string Contraseña { get; set; }

        public List<Producto> ProductosACargo { get; set; } = new List<Producto>();
    }
}
