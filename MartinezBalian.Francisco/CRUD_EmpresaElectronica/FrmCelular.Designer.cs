namespace CRUD_EmpresaElectronica
{
    partial class FrmCelular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCelular));
            lblBateria = new Label();
            lblCantidadDeContactos = new Label();
            lblAsistenteVirtual = new Label();
            txtCantidadContactos = new TextBox();
            txtBateria = new TextBox();
            cmBoxAsistenteVirtual = new ComboBox();
            SuspendLayout();
            // 
            // lblBateria
            // 
            lblBateria.AutoSize = true;
            lblBateria.Location = new Point(65, 215);
            lblBateria.Name = "lblBateria";
            lblBateria.Size = new Size(56, 20);
            lblBateria.TabIndex = 10;
            lblBateria.Text = "Bateria";
            // 
            // lblCantidadDeContactos
            // 
            lblCantidadDeContactos.AutoSize = true;
            lblCantidadDeContactos.Location = new Point(65, 284);
            lblCantidadDeContactos.Name = "lblCantidadDeContactos";
            lblCantidadDeContactos.Size = new Size(158, 20);
            lblCantidadDeContactos.TabIndex = 11;
            lblCantidadDeContactos.Text = "Cantidad de contactos";
            // 
            // lblAsistenteVirtual
            // 
            lblAsistenteVirtual.AutoSize = true;
            lblAsistenteVirtual.Location = new Point(65, 352);
            lblAsistenteVirtual.Name = "lblAsistenteVirtual";
            lblAsistenteVirtual.Size = new Size(114, 20);
            lblAsistenteVirtual.TabIndex = 12;
            lblAsistenteVirtual.Text = "Asistente virtual";
            // 
            // txtCantidadContactos
            // 
            txtCantidadContactos.Location = new Point(65, 307);
            txtCantidadContactos.Name = "txtCantidadContactos";
            txtCantidadContactos.PlaceholderText = "Ingrese la cantidad de contactos (maximo 200)";
            txtCantidadContactos.Size = new Size(328, 27);
            txtCantidadContactos.TabIndex = 13;
            // 
            // txtBateria
            // 
            txtBateria.Location = new Point(65, 238);
            txtBateria.Name = "txtBateria";
            txtBateria.PlaceholderText = "Ingrese la bateria (maximo 100)";
            txtBateria.Size = new Size(328, 27);
            txtBateria.TabIndex = 14;
            // 
            // cmBoxAsistenteVirtual
            // 
            cmBoxAsistenteVirtual.FormattingEnabled = true;
            cmBoxAsistenteVirtual.Location = new Point(65, 375);
            cmBoxAsistenteVirtual.Name = "cmBoxAsistenteVirtual";
            cmBoxAsistenteVirtual.Size = new Size(151, 28);
            cmBoxAsistenteVirtual.TabIndex = 15;
            // 
            // FrmCelular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            BackgroundImage = Properties.Resources.fondo_celulares;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(459, 656);
            Controls.Add(cmBoxAsistenteVirtual);
            Controls.Add(txtBateria);
            Controls.Add(txtCantidadContactos);
            Controls.Add(lblAsistenteVirtual);
            Controls.Add(lblCantidadDeContactos);
            Controls.Add(lblBateria);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCelular";
            Text = "Celular";
            Controls.SetChildIndex(cmBoxOrigen, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(lblBateria, 0);
            Controls.SetChildIndex(lblCantidadDeContactos, 0);
            Controls.SetChildIndex(lblAsistenteVirtual, 0);
            Controls.SetChildIndex(txtCantidadContactos, 0);
            Controls.SetChildIndex(txtBateria, 0);
            Controls.SetChildIndex(cmBoxAsistenteVirtual, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBateria;
        private Label lblCantidadDeContactos;
        private Label lblAsistenteVirtual;
        private TextBox txtCantidadContactos;
        private TextBox txtBateria;
        private ComboBox cmBoxAsistenteVirtual;
    }
}