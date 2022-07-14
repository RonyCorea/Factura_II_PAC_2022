namespace Vista
{
    partial class FacturaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.FechaFacturaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NombreClienteLabel = new System.Windows.Forms.Label();
            this.IdentidadMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CantidadProductoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DescripcionProductoLabel = new System.Windows.Forms.Label();
            this.CodigoProductoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DetalleFacturaDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.ISVTextBox = new System.Windows.Forms.TextBox();
            this.DescuentoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SubTotalTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.BuscarProductoButton = new System.Windows.Forms.Button();
            this.BuscarClienteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleFacturaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.FechaFacturaDateTimePicker);
            this.groupBox1.Controls.Add(this.NombreClienteLabel);
            this.groupBox1.Controls.Add(this.BuscarClienteButton);
            this.groupBox1.Controls.Add(this.IdentidadMaskedTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Cliente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Fecha:";
            // 
            // FechaFacturaDateTimePicker
            // 
            this.FechaFacturaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFacturaDateTimePicker.Location = new System.Drawing.Point(752, 21);
            this.FechaFacturaDateTimePicker.Name = "FechaFacturaDateTimePicker";
            this.FechaFacturaDateTimePicker.Size = new System.Drawing.Size(104, 22);
            this.FechaFacturaDateTimePicker.TabIndex = 4;
            // 
            // NombreClienteLabel
            // 
            this.NombreClienteLabel.AutoSize = true;
            this.NombreClienteLabel.Location = new System.Drawing.Point(302, 34);
            this.NombreClienteLabel.Name = "NombreClienteLabel";
            this.NombreClienteLabel.Size = new System.Drawing.Size(48, 16);
            this.NombreClienteLabel.TabIndex = 3;
            this.NombreClienteLabel.Text = "Cliente";
            // 
            // IdentidadMaskedTextBox
            // 
            this.IdentidadMaskedTextBox.Location = new System.Drawing.Point(91, 31);
            this.IdentidadMaskedTextBox.Mask = "####-####-#####";
            this.IdentidadMaskedTextBox.Name = "IdentidadMaskedTextBox";
            this.IdentidadMaskedTextBox.Size = new System.Drawing.Size(142, 22);
            this.IdentidadMaskedTextBox.TabIndex = 1;
            this.IdentidadMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdentidadMaskedTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identidad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CantidadProductoTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DescripcionProductoLabel);
            this.groupBox2.Controls.Add(this.BuscarProductoButton);
            this.groupBox2.Controls.Add(this.CodigoProductoTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 107);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Producto";
            // 
            // CantidadProductoTextBox
            // 
            this.CantidadProductoTextBox.Enabled = false;
            this.CantidadProductoTextBox.Location = new System.Drawing.Point(89, 71);
            this.CantidadProductoTextBox.Name = "CantidadProductoTextBox";
            this.CantidadProductoTextBox.Size = new System.Drawing.Size(143, 22);
            this.CantidadProductoTextBox.TabIndex = 6;
            this.CantidadProductoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CantidadProductoTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad:";
            // 
            // DescripcionProductoLabel
            // 
            this.DescripcionProductoLabel.AutoSize = true;
            this.DescripcionProductoLabel.Location = new System.Drawing.Point(303, 31);
            this.DescripcionProductoLabel.Name = "DescripcionProductoLabel";
            this.DescripcionProductoLabel.Size = new System.Drawing.Size(61, 16);
            this.DescripcionProductoLabel.TabIndex = 5;
            this.DescripcionProductoLabel.Text = "Producto";
            // 
            // CodigoProductoTextBox
            // 
            this.CodigoProductoTextBox.Location = new System.Drawing.Point(91, 28);
            this.CodigoProductoTextBox.Name = "CodigoProductoTextBox";
            this.CodigoProductoTextBox.Size = new System.Drawing.Size(143, 22);
            this.CodigoProductoTextBox.TabIndex = 1;
            this.CodigoProductoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoProductoTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código:";
            // 
            // DetalleFacturaDataGridView
            // 
            this.DetalleFacturaDataGridView.AllowUserToAddRows = false;
            this.DetalleFacturaDataGridView.AllowUserToDeleteRows = false;
            this.DetalleFacturaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetalleFacturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetalleFacturaDataGridView.Enabled = false;
            this.DetalleFacturaDataGridView.Location = new System.Drawing.Point(1, 213);
            this.DetalleFacturaDataGridView.Name = "DetalleFacturaDataGridView";
            this.DetalleFacturaDataGridView.ReadOnly = true;
            this.DetalleFacturaDataGridView.Size = new System.Drawing.Size(886, 233);
            this.DetalleFacturaDataGridView.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "ISV:";
            // 
            // ISVTextBox
            // 
            this.ISVTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ISVTextBox.Location = new System.Drawing.Point(38, 459);
            this.ISVTextBox.Name = "ISVTextBox";
            this.ISVTextBox.ReadOnly = true;
            this.ISVTextBox.Size = new System.Drawing.Size(100, 22);
            this.ISVTextBox.TabIndex = 4;
            // 
            // DescuentoTextBox
            // 
            this.DescuentoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DescuentoTextBox.Location = new System.Drawing.Point(241, 459);
            this.DescuentoTextBox.Name = "DescuentoTextBox";
            this.DescuentoTextBox.Size = new System.Drawing.Size(95, 22);
            this.DescuentoTextBox.TabIndex = 6;
            this.DescuentoTextBox.Text = "0";
            this.DescuentoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescuentoTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descuento:";
            // 
            // SubTotalTextBox
            // 
            this.SubTotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SubTotalTextBox.Location = new System.Drawing.Point(425, 459);
            this.SubTotalTextBox.Name = "SubTotalTextBox";
            this.SubTotalTextBox.ReadOnly = true;
            this.SubTotalTextBox.Size = new System.Drawing.Size(95, 22);
            this.SubTotalTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sub Total:";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalTextBox.Location = new System.Drawing.Point(586, 459);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.Size = new System.Drawing.Size(95, 22);
            this.TotalTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(539, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total:";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GuardarButton.Image = global::Vista.Properties.Resources.Guardar;
            this.GuardarButton.Location = new System.Drawing.Point(786, 452);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(88, 33);
            this.GuardarButton.TabIndex = 11;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // BuscarProductoButton
            // 
            this.BuscarProductoButton.Image = global::Vista.Properties.Resources.lupas;
            this.BuscarProductoButton.Location = new System.Drawing.Point(240, 25);
            this.BuscarProductoButton.Name = "BuscarProductoButton";
            this.BuscarProductoButton.Size = new System.Drawing.Size(36, 30);
            this.BuscarProductoButton.TabIndex = 4;
            this.BuscarProductoButton.UseVisualStyleBackColor = true;
            // 
            // BuscarClienteButton
            // 
            this.BuscarClienteButton.Image = global::Vista.Properties.Resources.lupas;
            this.BuscarClienteButton.Location = new System.Drawing.Point(239, 26);
            this.BuscarClienteButton.Name = "BuscarClienteButton";
            this.BuscarClienteButton.Size = new System.Drawing.Size(36, 30);
            this.BuscarClienteButton.TabIndex = 2;
            this.BuscarClienteButton.UseVisualStyleBackColor = true;
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 493);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SubTotalTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DescuentoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ISVTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DetalleFacturaDataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FacturaForm";
            this.Text = "FacturaForm";
            this.Load += new System.EventHandler(this.FacturaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleFacturaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox IdentidadMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuscarClienteButton;
        private System.Windows.Forms.Label NombreClienteLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox CodigoProductoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BuscarProductoButton;
        private System.Windows.Forms.Label DescripcionProductoLabel;
        private System.Windows.Forms.TextBox CantidadProductoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DetalleFacturaDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ISVTextBox;
        private System.Windows.Forms.TextBox DescuentoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SubTotalTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.DateTimePicker FechaFacturaDateTimePicker;
        private System.Windows.Forms.Label label8;
    }
}