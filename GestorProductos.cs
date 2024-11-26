using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace $safeprojectname$
{
    public class GestorProductos
    {
        private string archivoXml = "productos.xml";

        public List<Producto> Productos { get; private set; }

        public GestorProductos()
        {
            // Inicializa la lista de productos
            Productos = new List<Producto>();

            // Intenta cargar datos desde el archivo al iniciar
            if (File.Exists(archivoXml))
            {
                CargarDesdeXml();
            }
        }

        public void GuardarEnXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
            using (FileStream fs = new FileStream(archivoXml, FileMode.Create))
            {
                serializer.Serialize(fs, Productos);
            }
        }

        public void CargarDesdeXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
            using (FileStream fs = new FileStream(archivoXml, FileMode.Open))
            {
                Productos = (List<Producto>)serializer.Deserialize(fs);
            }
        }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            GuardarEnXml();
        }

        public void EliminarProducto(int id)
        {
            Producto producto = Productos.Find(p => p.Id == id);
            if (producto != null)
            {
                Productos.Remove(producto);
                GuardarEnXml();
            }
        }

        public void EditarProducto(Producto productoActualizado)
        {
            Producto producto = Productos.Find(p => p.Id == productoActualizado.Id);
            if (producto != null)
            {
                producto.Nombre = productoActualizado.Nombre;
                producto.Precio = productoActualizado.Precio;
                producto.Cantidad = productoActualizado.Cantidad;
                GuardarEnXml();
            }
        }
    }
}
