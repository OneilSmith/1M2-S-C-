using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto() { } // Constructor vacío para la serialización XML

        public override string ToString()
        {
            return $"{Id}: {Nombre} - Precio: {Precio:C}, Cantidad: {Cantidad}";
        }
    }
}
