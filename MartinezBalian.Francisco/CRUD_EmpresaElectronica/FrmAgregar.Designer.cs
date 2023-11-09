namespace CRUD_EmpresaElectronica
{
    partial class FrmAgregar
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
            btnConfirmar = new Button();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblMarca = new Label();
            lblOrigen = new Label();
            cmBoxOrigen = new ComboBox();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            txtMarca = new TextBox();
            SuspendLayout();
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(150, 608);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(131, 38);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = SystemColors.Control;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(65, 19);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(65, 84);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(65, 149);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(50, 20);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(65, 446);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(54, 20);
            lblOrigen.TabIndex = 5;
            lblOrigen.Text = "Origen";
            // 
            // cmBoxOrigen
            // 
            cmBoxOrigen.FormattingEnabled = true;
            cmBoxOrigen.Location = new Point(65, 469);
            cmBoxOrigen.Name = "cmBoxOrigen";
            cmBoxOrigen.Size = new Size(328, 28);
            cmBoxOrigen.TabIndex = 6;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(65, 107);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ingrese el precio en dolares";
            txtPrecio.Size = new Size(328, 27);
            txtPrecio.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.ForeColor = SystemColors.ControlText;
            txtNombre.Location = new Point(65, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ingrese el nombre";
            txtNombre.Size = new Size(328, 27);
            txtNombre.TabIndex = 8;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(65, 172);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "Ingrese la marca";
            txtMarca.Size = new Size(328, 27);
            txtMarca.TabIndex = 9;
            // 
            // FrmAgregar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 658);
            Controls.Add(txtMarca);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(cmBoxOrigen);
            Controls.Add(lblOrigen);
            Controls.Add(lblMarca);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(btnConfirmar);
            Name = "FrmAgregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAgregar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirmar;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblMarca;
        private Label lblOrigen;
        protected TextBox txtPrecio;
        protected TextBox txtNombre;
        protected TextBox txtMarca;
        protected ComboBox cmBoxOrigen;
    }
}