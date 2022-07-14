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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Vista
{
    public partial class FacturaForm : Form
    {
        Producto producto;
        Cliente cliente;
        List<DetalleFactura> detalles = new List<DetalleFactura>();
        Factura factura;
        FacturaDatos facturaDatos;
        string identidadCliente;
        decimal subTotal = 0;
        decimal isv = 0;
        decimal descuento = 0;
        decimal total = decimal.Zero;

        public FacturaForm()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            IdentidadMaskedTextBox.Clear();
            CodigoProductoTextBox.Clear();
            CantidadProductoTextBox.Clear();
            NombreClienteLabel.Text = String.Empty;
            DescripcionProductoLabel.Text = string.Empty;
            producto = null;
            cliente = null;
            detalles.Clear();
            factura = null;
            subTotal = 0;
            isv = 0;
            total = 0;
            ISVTextBox.Clear();
            DescuentoTextBox.Text = "0";
            SubTotalTextBox.Clear();
            TotalTextBox.Clear();
            DetalleFacturaDataGridView.DataSource = null;
            DetalleFacturaDataGridView.DataSource = detalles;
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
                    CantidadProductoTextBox.Enabled = true;
                    CantidadProductoTextBox.Focus();
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

                    descuento = Convert.ToDecimal(DescuentoTextBox.Text);

                    subTotal += detalleFactura.Total;
                    //subTotal = subTotal + detalleFactura.Total;
                    isv = subTotal * 0.15M;
                    total = subTotal + isv - descuento;
                    detalles.Add(detalleFactura);
                    DetalleFacturaDataGridView.DataSource = null;

                    DetalleFacturaDataGridView.DataSource = detalles;

                    SubTotalTextBox.Text = subTotal.ToString("N");
                    ISVTextBox.Text = isv.ToString("N");
                    TotalTextBox.Text = total.ToString("N");
                    CantidadProductoTextBox.Clear();
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

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (cliente == null)
            {
                MessageBox.Show("Seleccione el cliente");
                return;
            }

            factura = new Factura();

            factura.IdentidadCliente = cliente.Identidad;
            factura.Fecha = FechaFacturaDateTimePicker.Value;
            factura.SubTotal = subTotal;
            factura.ISV = isv;
            factura.Descuento = descuento;
            factura.Total = total;

            facturaDatos = new FacturaDatos();

            bool inserto = await facturaDatos.GuardarAsync(factura, detalles);
            if (inserto)
            {
                Document documento = new Document();
                BaseFont fuenteDeTexto = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font f15Negrita = new iTextSharp.text.Font(fuenteDeTexto, 15, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font f12Normal= new iTextSharp.text.Font(fuenteDeTexto, 12, iTextSharp.text.Font.NORMAL);

                FileStream fs = new FileStream("Factura.pdf", FileMode.Create);

                using (fs)
                {
                    PdfWriter.GetInstance(documento, fs);
                    documento.Open();

                    PdfPTable tabla_encabezado = new PdfPTable(1);

                    PdfPCell celda1 = new PdfPCell(new Phrase("Cliente: " + cliente.Nombre, f15Negrita));
                    PdfPCell celda2 = new PdfPCell(new Phrase("Fecha: " + FechaFacturaDateTimePicker.Value.ToShortDateString(), f15Negrita));

                    celda1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    celda2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    
                    tabla_encabezado.WidthPercentage = 45;
                    tabla_encabezado.HorizontalAlignment = Element.ALIGN_CENTER;

                    tabla_encabezado.AddCell(celda1);
                    tabla_encabezado.AddCell(celda2);

                    tabla_encabezado.SpacingAfter = 20;
                    tabla_encabezado.SpacingBefore = 20;


                    PdfPTable tabla_datos = new PdfPTable(5);
                    PdfPCell celdaencabezado = new PdfPCell(new Phrase("Detalle de la factura", f15Negrita));
                    celdaencabezado.Colspan = 5;
                    celdaencabezado.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla_datos.AddCell(celdaencabezado);

                    for (int i = 0; i < 1; i++)
                    {
                        PdfPCell cel1 = new PdfPCell(new Phrase("Código", f15Negrita));
                        PdfPCell cel2 = new PdfPCell(new Phrase("Descripcion", f15Negrita));
                        PdfPCell cel3 = new PdfPCell(new Phrase("Cantidad", f15Negrita));
                        PdfPCell cel4 = new PdfPCell(new Phrase("Precio", f15Negrita));
                        PdfPCell cel5 = new PdfPCell(new Phrase("Total", f15Negrita));

                        tabla_datos.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.FixedHeight = 20;
                        cel2.FixedHeight = 20;
                        cel3.FixedHeight = 20;
                        cel4.FixedHeight = 20;
                        cel5.FixedHeight = 20;
           
                        tabla_datos.AddCell(cel1);
                        tabla_datos.AddCell(cel2);
                        tabla_datos.AddCell(cel3);
                        tabla_datos.AddCell(cel4);
                        tabla_datos.AddCell(cel5);
                    }

                    foreach (var item in detalles)
                    {
                        PdfPCell celd1 = new PdfPCell(new Phrase(item.CodigoProducto, f12Normal));
                        PdfPCell celd2 = new PdfPCell(new Phrase(item.Descripcion, f12Normal));
                        PdfPCell celd3 = new PdfPCell(new Phrase(item.Cantidad.ToString(), f12Normal));
                        PdfPCell celd4 = new PdfPCell(new Phrase(item.Precio.ToString("N"), f12Normal));
                        PdfPCell celd5 = new PdfPCell(new Phrase(item.Total.ToString("N"), f12Normal));

                        celd1.FixedHeight = 20;
                        celd2.FixedHeight = 20;
                        celd3.FixedHeight = 20;
                        celd4.FixedHeight = 20;
                        celd5.FixedHeight = 20;

                        tabla_datos.AddCell(celd1);
                        tabla_datos.AddCell(celd2);
                        tabla_datos.AddCell(celd3);
                        tabla_datos.AddCell(celd4);
                        tabla_datos.AddCell(celd5);
                    }


                    PdfPTable tabla_total = new PdfPTable(1);



                    documento.Add(tabla_encabezado);
                    documento.Add(tabla_datos);

                    documento.Close();
                    System.Diagnostics.Process.Start("Factura.pdf");

                }
                MessageBox.Show("Factura registrada correctamente");
                LimpiarControles();
            }

        }

        private void DescuentoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                descuento = Convert.ToDecimal(DescuentoTextBox.Text);

                total = subTotal + isv - descuento;

                TotalTextBox.Text = total.ToString("N");
            }
                
        }
    }
}
