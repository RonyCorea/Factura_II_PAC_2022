using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FacturaForm : Form
    {
        Producto producto;
        Cliente cliente;
        List<DetalleFactura> detalles = new List<DetalleFactura>();
        string identidadCliente;
        decimal subTotal = 0;
        decimal isv = 0;
        decimal descuento = 0;
        decimal total = decimal.Zero;

        public FacturaForm()
        {
            InitializeComponent();
        }

        private async void IdentidadMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ClientesDatos clienteDatos = new ClientesDatos();

                cliente = new Cliente();
                cliente = await clienteDatos.GetPorIdentidadAsync(IdentidadMaskedTextBox.Text);

                if (cliente.Identidad != null)
                {
                    NombreClienteLabel.Text = cliente.Nombre;
                }
                else
                {
                    NombreClienteLabel.Text = "No existe el cliente";
                }

            }
        }

        private async void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ProductoDatos productoDatos = new ProductoDatos();
                producto = new Producto();

                producto = await productoDatos.GetPorCodigoAsync(CodigoProductoTextBox.Text);

                if (producto.Codigo != null)
                {
                    DescripcionProductoLabel.Text = producto.Descripcion;
                    CantidadProductoTextBox.Focus();
                    CantidadProductoTextBox.Enabled = true;
                }
                else
                {
                    DescripcionProductoLabel.Text = "No existe el producto";
                    CantidadProductoTextBox.Enabled = false;
                }
            }
                
        }

        private void CantidadProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (producto.Existencia >= Convert.ToInt32(CantidadProductoTextBox.Text))
                {
                    DetalleFactura detalleFactura = new DetalleFactura();
                    detalleFactura.CodigoProducto = producto.Codigo;
                    detalleFactura.Descripcion = producto.Descripcion;
                    detalleFactura.Cantidad = Convert.ToInt32(CantidadProductoTextBox.Text);
                    detalleFactura.Precio = Convert.ToDecimal(producto.Precio);
                    detalleFactura.Total = Convert.ToInt32(CantidadProductoTextBox.Text) * producto.Precio;

                    detalles.Add(detalleFactura);
                    DetalleFacturaDataGridView.DataSource = null;

                    DetalleFacturaDataGridView.DataSource = detalles;
                }
                else
                {
                    MessageBox.Show("La cantidad a vender supera la existencia actua del producto que es: " + producto.Existencia, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
        }

        private void FacturaForm_Load(object sender, EventArgs e)
        {
            DetalleFacturaDataGridView.DataSource = detalles;
        }
    }
}
