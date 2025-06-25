using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public int EmpleadoResponsableId { get; set; } // FK lógica

        public string nombeEmpleadoResponsable { get; set; }
    }
}
