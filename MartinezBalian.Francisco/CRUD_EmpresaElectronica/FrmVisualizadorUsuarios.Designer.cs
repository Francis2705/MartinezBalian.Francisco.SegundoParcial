namespace CRUD_EmpresaElectronica
{
    partial class FrmVisualizadorUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizadorUsuarios));
            richTxtBoxInfoLogueos = new RichTextBox();
            SuspendLayout();
            // 
            // richTxtBoxInfoLogueos
            // 
            richTxtBoxInfoLogueos.BackColor = Color.FromArgb(179, 227, 240);
            richTxtBoxInfoLogueos.BorderStyle = BorderStyle.None;
            richTxtBoxInfoLogueos.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            richTxtBoxInfoLogueos.Location = new Point(154, 68);
            richTxtBoxInfoLogueos.Name = "richTxtBoxInfoLogueos";
            richTxtBoxInfoLogueos.Size = new Size(616, 438);
            richTxtBoxInfoLogueos.TabIndex = 0;
            richTxtBoxInfoLogueos.Text = "";
            // 
            // FrmVisualizadorUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(961, 584);
            Controls.Add(richTxtBoxInfoLogueos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmVisualizadorUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizador usuarios";
            Load += FrmVisualizadorUsuarios_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTxtBoxInfoLogueos;
    }
}