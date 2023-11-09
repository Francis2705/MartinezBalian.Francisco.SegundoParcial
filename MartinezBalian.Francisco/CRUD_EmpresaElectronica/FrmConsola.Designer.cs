namespace CRUD_EmpresaElectronica
{
    partial class FrmConsola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsola));
            lblMemoriaTotal = new Label();
            lblVelocidadDescarga = new Label();
            lblAceptaDiscosFisicos = new Label();
            txtBoxMemoriaTotal = new TextBox();
            txtBoxVelocidadDescarga = new TextBox();
            cmBoxAceptaDiscosFisicos = new ComboBox();
            SuspendLayout();
            // 
            // lblMemoriaTotal
            // 
            lblMemoriaTotal.AutoSize = true;
            lblMemoriaTotal.Location = new Point(64, 217);
            lblMemoriaTotal.Name = "lblMemoriaTotal";
            lblMemoriaTotal.Size = new Size(104, 20);
            lblMemoriaTotal.TabIndex = 10;
            lblMemoriaTotal.Text = "Memoria total";
            // 
            // lblVelocidadDescarga
            // 
            lblVelocidadDescarga.AutoSize = true;
            lblVelocidadDescarga.Location = new Point(64, 283);
            lblVelocidadDescarga.Name = "lblVelocidadDescarga";
            lblVelocidadDescarga.Size = new Size(186, 20);
            lblVelocidadDescarga.TabIndex = 11;
            lblVelocidadDescarga.Text = "Velocidad de descarga MB";
            // 
            // lblAceptaDiscosFisicos
            // 
            lblAceptaDiscosFisicos.AutoSize = true;
            lblAceptaDiscosFisicos.Location = new Point(65, 356);
            lblAceptaDiscosFisicos.Name = "lblAceptaDiscosFisicos";
            lblAceptaDiscosFisicos.Size = new Size(180, 20);
            lblAceptaDiscosFisicos.TabIndex = 12;
            lblAceptaDiscosFisicos.Text = "Acepta o no discos fisicos";
            // 
            // txtBoxMemoriaTotal
            // 
            txtBoxMemoriaTotal.Location = new Point(65, 240);
            txtBoxMemoriaTotal.Name = "txtBoxMemoriaTotal";
            txtBoxMemoriaTotal.PlaceholderText = "Ingrese la memoria total (maximo 2048)";
            txtBoxMemoriaTotal.Size = new Size(328, 27);
            txtBoxMemoriaTotal.TabIndex = 13;
            // 
            // txtBoxVelocidadDescarga
            // 
            txtBoxVelocidadDescarga.Location = new Point(65, 306);
            txtBoxVelocidadDescarga.Name = "txtBoxVelocidadDescarga";
            txtBoxVelocidadDescarga.PlaceholderText = "Ingrese velocidad de descarga (maximo 500)";
            txtBoxVelocidadDescarga.Size = new Size(328, 27);
            txtBoxVelocidadDescarga.TabIndex = 14;
            // 
            // cmBoxAceptaDiscosFisicos
            // 
            cmBoxAceptaDiscosFisicos.FormattingEnabled = true;
            cmBoxAceptaDiscosFisicos.Location = new Point(65, 379);
            cmBoxAceptaDiscosFisicos.Name = "cmBoxAceptaDiscosFisicos";
            cmBoxAceptaDiscosFisicos.Size = new Size(328, 28);
            cmBoxAceptaDiscosFisicos.TabIndex = 15;
            // 
            // FrmConsola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            BackgroundImage = Properties.Resources.fondo_consola;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(452, 656);
            Controls.Add(cmBoxAceptaDiscosFisicos);
            Controls.Add(txtBoxVelocidadDescarga);
            Controls.Add(txtBoxMemoriaTotal);
            Controls.Add(lblAceptaDiscosFisicos);
            Controls.Add(lblVelocidadDescarga);
            Controls.Add(lblMemoriaTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmConsola";
            Text = "Consola";
            Controls.SetChildIndex(cmBoxOrigen, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtNombre, 0);
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(lblMemoriaTotal, 0);
            Controls.SetChildIndex(lblVelocidadDescarga, 0);
            Controls.SetChildIndex(lblAceptaDiscosFisicos, 0);
            Controls.SetChildIndex(txtBoxMemoriaTotal, 0);
            Controls.SetChildIndex(txtBoxVelocidadDescarga, 0);
            Controls.SetChildIndex(cmBoxAceptaDiscosFisicos, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMemoriaTotal;
        private Label lblVelocidadDescarga;
        private Label lblAceptaDiscosFisicos;
        private TextBox txtBoxMemoriaTotal;
        private TextBox txtBoxVelocidadDescarga;
        private ComboBox cmBoxAceptaDiscosFisicos;
    }
}