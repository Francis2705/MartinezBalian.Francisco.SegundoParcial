namespace CRUD_EmpresaElectronica
{
    partial class FrmRecuperarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecuperarClave));
            lblCorreo = new Label();
            lblLegajo = new Label();
            txtCorreo = new TextBox();
            txtLegajo = new TextBox();
            SuspendLayout();
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(141, 46);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(54, 20);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Correo";
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Location = new Point(139, 96);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(54, 20);
            lblLegajo.TabIndex = 1;
            lblLegajo.Text = "Legajo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(287, 65);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese su correo";
            txtCorreo.Size = new Size(125, 27);
            txtCorreo.TabIndex = 2;
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(285, 142);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.PlaceholderText = "Ingrese su legajo";
            txtLegajo.Size = new Size(125, 27);
            txtLegajo.TabIndex = 3;
            // 
            // FrmRecuperarClave
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(494, 309);
            Controls.Add(txtLegajo);
            Controls.Add(txtCorreo);
            Controls.Add(lblLegajo);
            Controls.Add(lblCorreo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRecuperarClave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar clave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCorreo;
        private Label lblLegajo;
        private TextBox txtCorreo;
        private TextBox txtLegajo;
    }
}