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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                UsuarioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ClaveTextBox.Text))
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                ClaveTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UsuarioTextBox.Text))
            {
                errorProvider1.Clear();
            }
        }

        private void ClaveTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ClaveTextBox.Text != "")
            {
                errorProvider1.Clear();
            }
        }
    }
}
