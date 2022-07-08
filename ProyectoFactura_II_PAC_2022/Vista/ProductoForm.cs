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
    public partial class ProductoForm : Form
    {
        public ProductoForm()
        {
            InitializeComponent();
        }

        string operacion = string.Empty;
        Producto producto = new Producto();
        ProductoDatos productoDatos = new ProductoDatos();


        private void NuevoButton_Click(object sender, EventArgs e)
        {
           HabilitarControles();
            operacion = "nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            ExistenciaTextBox.Clear();
            PrecioTextBox.Clear();
            ImagenPictureBox.Image = null;
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Validaciones
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Digite un codigo del producto");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Digite una descripción del producto");
                    DescripcionTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
                {
                    errorProvider1.SetError(ExistenciaTextBox, "Digite una existencia del producto");
                    ExistenciaTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Digite un precio del producto");
                    PrecioTextBox.Focus();
                    return;
                }

                if (ImagenPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ImagenPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    producto.Imagen = ms.GetBuffer();
                }

                producto.Codigo = CodigoTextBox.Text;
                producto.Descripcion = DescripcionTextBox.Text;
                producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
                producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                

                if (operacion == "nuevo")
                {
                    bool inserto = await productoDatos.InsertarNuevoProductoAsync(producto);
                    if (inserto)
                    {
                        MessageBox.Show("Producto Registrado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles();
                        DesabilitarControles();
                        LlenarListaProductos();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "modificar")
                {
                    bool modifico = await productoDatos.ActualizarProductoAsync(producto);
                    if (modifico)
                    {
                        MessageBox.Show("Producto Modificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles();
                        DesabilitarControles();
                        LlenarListaProductos();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private async void LlenarListaProductos()
        {
            ProductosDataGridView.DataSource = await productoDatos.DevolverProductosAsync();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            LlenarListaProductos();
        }

        private void BuscarFotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ImagenPictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }

        private async void ModificarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                operacion = "modificar";
                HabilitarControles();

                CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();

                var imagenBD = await productoDatos.SeleccionarImagen(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (imagenBD.Length > 0)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBD);
                    ImagenPictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }
                else
                {
                    ImagenPictureBox.Image = null;
                }
                CodigoTextBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un  producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await productoDatos.EliminarProductoAsync(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    MessageBox.Show("Producto Eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarListaProductos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un  producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un  producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private void ExistenciaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
