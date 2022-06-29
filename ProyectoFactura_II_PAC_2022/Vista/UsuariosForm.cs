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
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }
        string tipoOperacion = string.Empty;
        UsuarioDatos userDatos = new UsuarioDatos();
        Usuario user = new Usuario();


        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            EmailTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Text = string.Empty;
            EmailTextBox.Text = "";
            ClaveTextBox.Clear();
        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
        }

        private async void LlenarDataGrid()
        {
            UsuariosDataGridView.DataSource = await userDatos.DevolverUsuariosAsync();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            tipoOperacion = "nuevo";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                EmailTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Email"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                HabilitarControles();
                CodigoTextBox.Enabled = false;
            }
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            LlenarDataGrid();
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "nuevo")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Email = EmailTextBox.Text;
                user.Clave = ClaveTextBox.Text;


                bool inserto = await userDatos.InsertarNuevoUsuarioAsync(user);

                if (inserto)
                {
                    MessageBox.Show("Usuario Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario No se pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if(tipoOperacion == "modificar")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }

                user.Codigo = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Email = EmailTextBox.Text;
                user.Clave = ClaveTextBox.Text;

                bool actualizo = await userDatos.ActualizarUsuarioAsync(user);

                if (actualizo)
                {
                    MessageBox.Show("Usuario Actualizado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario No se pudo Actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await userDatos.EliminarUsuarioAsync(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarDataGrid();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario No se pudo Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
