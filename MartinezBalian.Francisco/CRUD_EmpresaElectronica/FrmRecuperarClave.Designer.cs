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
            txtCorreo = new TextBox();
            txtLegajo = new TextBox();
            btnAceptar = new Button();
            btnRellenoAutomatico = new Button();
            lblRecuperarClave = new Label();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(99, 115);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese su correo";
            txtCorreo.Size = new Size(256, 27);
            txtCorreo.TabIndex = 2;
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(99, 187);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.PlaceholderText = "Ingrese su legajo";
            txtLegajo.Size = new Size(256, 27);
            txtLegajo.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ActiveCaption;
            btnAceptar.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.ForeColor = SystemColors.HotTrack;
            btnAceptar.Location = new Point(153, 272);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(131, 75);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnRellenoAutomatico
            // 
            btnRellenoAutomatico.Location = new Point(12, 272);
            btnRellenoAutomatico.Name = "btnRellenoAutomatico";
            btnRellenoAutomatico.Size = new Size(101, 75);
            btnRellenoAutomatico.TabIndex = 5;
            btnRellenoAutomatico.Text = "Relleno Automatico";
            btnRellenoAutomatico.UseVisualStyleBackColor = true;
            btnRellenoAutomatico.Click += btnRellenoAutomatico_Click;
            // 
            // lblRecuperarClave
            // 
            lblRecuperarClave.AutoSize = true;
            lblRecuperarClave.BackColor = Color.Transparent;
            lblRecuperarClave.Font = new Font("Calibri", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblRecuperarClave.ForeColor = SystemColors.HotTrack;
            lblRecuperarClave.Location = new Point(123, 46);
            lblRecuperarClave.Name = "lblRecuperarClave";
            lblRecuperarClave.Size = new Size(196, 35);
            lblRecuperarClave.TabIndex = 6;
            lblRecuperarClave.Text = "Recuperar clave";
            // 
            // FrmRecuperarClave
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(455, 381);
            Controls.Add(lblRecuperarClave);
            Controls.Add(btnRellenoAutomatico);
            Controls.Add(btnAceptar);
            Controls.Add(txtLegajo);
            Controls.Add(txtCorreo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRecuperarClave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar clave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtCorreo;
        private TextBox txtLegajo;
        private Button btnAceptar;
        private Button btnRellenoAutomatico;
        private Label lblRecuperarClave;
    }
}