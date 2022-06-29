using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class PrincipalForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        UsuariosForm usuariosForm = null;
        ClientesForm clientesForm = null;

        private void ListaUsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (usuariosForm == null)
            {
                usuariosForm = new UsuariosForm();
                usuariosForm.MdiParent = this;
                usuariosForm.FormClosed += UsuariosForm_FormClosed;
                usuariosForm.Show();
            }
            else
            {
                usuariosForm.Activate();
            }
        }

        private void UsuariosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            usuariosForm = null;
        }

        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            if (clientesForm == null)
            {
                clientesForm = new ClientesForm();
                clientesForm.MdiParent = this;
                clientesForm.FormClosed += ClientesForm_FormClosed;
                clientesForm.Show();
            }
            else
            {
                clientesForm.Activate();
            }
        }

        private void ClientesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientesForm = null;
        }
    }
}
