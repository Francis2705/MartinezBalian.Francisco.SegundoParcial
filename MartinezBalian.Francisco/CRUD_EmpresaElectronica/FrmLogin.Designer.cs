using Electronicos;

namespace CRUD_EmpresaElectronica
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            txtBoxCorreo = new TextBox();
            txtBoxClave = new TextBox();
            btnIngresar = new Button();
            btnRellenar = new Button();
            lblInicioSesion = new Label();
            linkLblRecuperarClave = new LinkLabel();
            SuspendLayout();
            // 
            // txtBoxCorreo
            // 
            txtBoxCorreo.BackColor = SystemColors.InactiveBorder;
            txtBoxCorreo.Location = new Point(159, 177);
            txtBoxCorreo.Name = "txtBoxCorreo";
            txtBoxCorreo.PlaceholderText = "Ingrese su usuario";
            txtBoxCorreo.Size = new Size(258, 27);
            txtBoxCorreo.TabIndex = 0;
            // 
            // txtBoxClave
            // 
            txtBoxClave.BackColor = SystemColors.InactiveBorder;
            txtBoxClave.Location = new Point(159, 257);
            txtBoxClave.Name = "txtBoxClave";
            txtBoxClave.PasswordChar = '*';
            txtBoxClave.PlaceholderText = "Ingrese su clave";
            txtBoxClave.Size = new Size(258, 27);
            txtBoxClave.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.ActiveCaption;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = SystemColors.HotTrack;
            btnIngresar.Location = new Point(200, 358);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(173, 56);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnRellenar
            // 
            btnRellenar.Location = new Point(12, 390);
            btnRellenar.Name = "btnRellenar";
            btnRellenar.Size = new Size(97, 97);
            btnRellenar.TabIndex = 3;
            btnRellenar.Text = "Relleno automatico";
            btnRellenar.UseVisualStyleBackColor = true;
            btnRellenar.Click += btnRellenar_Click;
            // 
            // lblInicioSesion
            // 
            lblInicioSesion.AutoSize = true;
            lblInicioSesion.BackColor = Color.Transparent;
            lblInicioSesion.Font = new Font("Calibri", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblInicioSesion.ForeColor = SystemColors.HotTrack;
            lblInicioSesion.Location = new Point(200, 68);
            lblInicioSesion.Name = "lblInicioSesion";
            lblInicioSesion.Size = new Size(162, 35);
            lblInicioSesion.TabIndex = 4;
            lblInicioSesion.Text = "Iniciar sesion";
            // 
            // linkLblRecuperarClave
            // 
            linkLblRecuperarClave.AutoSize = true;
            linkLblRecuperarClave.BackColor = Color.Transparent;
            linkLblRecuperarClave.Location = new Point(172, 442);
            linkLblRecuperarClave.Name = "linkLblRecuperarClave";
            linkLblRecuperarClave.Size = new Size(229, 20);
            linkLblRecuperarClave.TabIndex = 5;
            linkLblRecuperarClave.TabStop = true;
            linkLblRecuperarClave.Text = "Olvidaste tu clave? Haz click aqui";
            linkLblRecuperarClave.LinkClicked += linkLblRecuperarClave_LinkClicked;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = Properties.Resources.fondo_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(572, 499);
            Controls.Add(linkLblRecuperarClave);
            Controls.Add(lblInicioSesion);
            Controls.Add(btnRellenar);
            Controls.Add(btnIngresar);
            Controls.Add(txtBoxClave);
            Controls.Add(txtBoxCorreo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesion";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxCorreo;
        private TextBox txtBoxClave;
        private Button btnIngresar;
        private Button btnRellenar;
        private Label lblInicioSesion;
        private LinkLabel linkLblRecuperarClave;
    }
}