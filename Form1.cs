using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class Form1 : Form
{
    private GestorProductos gestor;

    public Form1()
    {
        InitializeComponent();
        gestor = new GestorProductos();
        ActualizarVista();
    }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActualizarVista()
    {
        dgvProductos.DataSource = null;
        dgvProductos.DataSource = gestor.Productos;
    }

    private void btnAñadir_Click(object sender, EventArgs e)
    {
        Producto nuevoProducto = new Producto
        {
            Id = gestor.Productos.Count + 1,
            Nombre = "Nuevo Producto",
            Precio = 0.0m,
            Cantidad = 0
        };

        gestor.AgregarProducto(nuevoProducto);
        ActualizarVista();
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count > 0)
        {
            int id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            Producto producto = gestor.Productos.Find(p => p.Id == id);

            if (producto != null)
            {
                producto.Nombre = "Producto Editado";
                producto.Precio = 100.0m;
                producto.Cantidad = 10;
                gestor.EditarProducto(producto);
                ActualizarVista();
            }
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count > 0)
        {
            int id = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            gestor.EliminarProducto(id);
            ActualizarVista();
        }
    }

    private void btnVerTodos_Click(object sender, EventArgs e)
    {
        ActualizarVista();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

        private void btnAñadir_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
