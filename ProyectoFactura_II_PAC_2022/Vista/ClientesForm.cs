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
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }
        ClientesDatos clientedatos = new ClientesDatos();
        Cliente cliente;
        string operacion;

        private void HabilitarControles()
        {
            IdentidadMaskedTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            DireccionTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
        }
        private void LimpiarControles()
        {
            IdentidadMaskedTextBox.Clear();
            NombreTextBox.Clear();
            DireccionTextBox.Clear();
            EmailTextBox.Clear();
            FotoPictureBox.Image = null;
        }
        private void DesabilitarControles()
        {
            IdentidadMaskedTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            DireccionTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "nuevo";
            HabilitarControles();
        }

        async void CargarClientes()
        {
            ClientesDataGridView.DataSource = await clientedatos.DevolverClientesAsync();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (IdentidadMaskedTextBox.Text == "")
            {
                errorProvider1.SetError(IdentidadMaskedTextBox, "Ingrese una identidad");
                IdentidadMaskedTextBox.Focus();
                return;
            }
            if (NombreTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                NombreTextBox.Focus();
                return;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            FotoPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            cliente = new Cliente();
            cliente.Identidad = IdentidadMaskedTextBox.Text;
            cliente.Nombre = NombreTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Foto = ms.GetBuffer();

            if (operacion == "nuevo")
            {
                bool inserto = await clientedatos.InsertarNuevoClienteAsync(cliente);

                if (inserto == true)
                {
                    MessageBox.Show("Cliente guardado");
                    CargarClientes();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo guardar");
                }
            }
            else if(operacion == "modificar")
            {
                bool modifico = await clientedatos.ActualizarClienteAsync(cliente);
                if (modifico == true)
                {
                    MessageBox.Show("Cliente Modificado");
                    CargarClientes();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo modificar");
                }
            }

        }

        private void BuscarFotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FotoPictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }

        private async void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "modificar";
            HabilitarControles();

            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                IdentidadMaskedTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                NombreTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                DireccionTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                EmailTextBox.Text = ClientesDataGridView.CurrentRow.Cells["Email"].Value.ToString();

                var temporal = await clientedatos.SeleccionarFoto(ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString());

                if (temporal.Length > 0)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(temporal);
                    FotoPictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }
                else
                {
                    FotoPictureBox.Image = null;
                }
            }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                DialogResult dialogresult = MessageBox.Show("¿Desea Eliminar el Cliente?", "Atención", MessageBoxButtons.YesNo);

                if (dialogresult == DialogResult.Yes)
                {
                    bool elimino = await clientedatos.EliminarClienteAsync(ClientesDataGridView.CurrentRow.Cells["Identidad"].Value.ToString());
                    if (elimino)
                    {
                        MessageBox.Show("Cliente eliminado");
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo eliminar");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente");
            }
        }
    }
}
