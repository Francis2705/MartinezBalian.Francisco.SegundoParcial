namespace CRUD_EmpresaElectronica
{
    partial class FrmComputadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComputadora));
            lblCantidadNucleos = new Label();
            lblSDD = new Label();
            lblTactil = new Label();
            txtBoxCantidadNucleos = new TextBox();
            txtBoxSDD = new TextBox();
            cbBoxTactil = new ComboBox();
            SuspendLayout();
            // 
            // lblCantidadNucleos
            // 
            lblCantidadNucleos.AutoSize = true;
            lblCantidadNucleos.Location = new Point(65, 214);
            lblCantidadNucleos.Name = "lblCantidadNucleos";
            lblCantidadNucleos.Size = new Size(144, 20);
            lblCantidadNucleos.TabIndex = 10;
            lblCantidadNucleos.Text = "Cantidad de nucleos";
            // 
            // lblSDD
            // 
            lblSDD.AutoSize = true;
            lblSDD.Location = new Point(65, 276);
            lblSDD.Name = "lblSDD";
            lblSDD.Size = new Size(133, 20);
            lblSDD.TabIndex = 11;
            lblSDD.Text = "Espacio disco SDD";
            // 
            // lblTactil
            // 
            lblTactil.AutoSize = true;
            lblTactil.Location = new Point(65, 339);
            lblTactil.Name = "lblTactil";
            lblTactil.Size = new Size(43, 20);
            lblTactil.TabIndex = 12;
            lblTactil.Text = "Tactil";
            // 
            // txtBoxCantidadNucleos
            // 
            txtBoxCantidadNucleos.Location = new Point(65, 237);
            txtBoxCantidadNucleos.Name = "txtBoxCantidadNucleos";
            txtBoxCantidadNucleos.PlaceholderText = "Ingrese la cantidad de nucleos (maximo 12)";
            txtBoxCantidadNucleos.Size = new Size(328, 27);
            txtBoxCantidadNucleos.TabIndex = 13;
            // 
            // txtBoxSDD
            // 
            txtBoxSDD.Location = new Point(65, 299);
            txtBoxSDD.Name = "txtBoxSDD";
            txtBoxSDD.PlaceholderText = "Ingrese espacio del disco SDD (maximo 2048)";
            txtBoxSDD.Size = new Size(328, 27);
            txtBoxSDD.TabIndex = 14;
            // 
            // cbBoxTactil
            // 
            cbBoxTactil.FormattingEnabled = true;
            cbBoxTactil.Location = new Point(65, 362);
            cbBoxTactil.Name = "cbBoxTactil";
            cbBoxTactil.Size = new Size(328, 28);
            cbBoxTactil.TabIndex = 15;
            // 
            // FrmComputadora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            BackgroundImage = Properties.Resources.fondo_computadoras;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(468, 660);
            Controls.Add(cbBoxTactil);
            Controls.Add(txtBoxSDD);
            Controls.Add(txtBoxCantidadNucleos);
            Controls.Add(lblTactil);
            Controls.Add(lblSDD);
            Controls.Add(lblCantidadNucleos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmComputadora";
            Text = "Computadora";
            Controls.SetChildIndex(cmBoxOrigen, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(lblCantidadNucleos, 0);
            Controls.SetChildIndex(lblSDD, 0);
            Controls.SetChildIndex(lblTactil, 0);
            Controls.SetChildIndex(txtBoxCantidadNucleos, 0);
            Controls.SetChildIndex(txtBoxSDD, 0);
            Controls.SetChildIndex(cbBoxTactil, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCantidadNucleos;
        private Label lblSDD;
        private Label lblTactil;
        private TextBox txtBoxCantidadNucleos;
        private TextBox txtBoxSDD;
        private ComboBox cbBoxTactil;
    }
}