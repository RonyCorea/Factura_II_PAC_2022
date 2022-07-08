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
        ProductoForm productoForm = null;
        FacturaForm facturaForm = null;

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

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (productoForm == null)
            {
                productoForm = new ProductoForm();
                productoForm.MdiParent = this;
                productoForm.FormClosed += ProductoForm_FormClosed;
                productoForm.Show();
            }
            else
            {
                productoForm.Activate();
            }
        }

        private void ProductoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            productoForm = null;
        }

        private void NuevaFacturaToolStripButton_Click(object sender, EventArgs e)
        {
            if (facturaForm == null)
            {
                facturaForm = new FacturaForm();
                facturaForm.MdiParent = this;
                facturaForm.FormClosed += FacturaForm_FormClosed;
                facturaForm.Show();
            }
            else
            {
                facturaForm.Activate();
            }
        }

        private void FacturaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            facturaForm = null;
        }
    }
}
