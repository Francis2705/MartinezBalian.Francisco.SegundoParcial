namespace CRUD_EmpresaElectronica
{
    partial class FrmPrincipalEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipalEmpresa));
            btnVisualizadorUsuariosLogueo = new Button();
            lblUsuarioInfo = new Label();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnMostrarCaracteristicasEspecificas = new Button();
            rbNombreAscendentemente = new RadioButton();
            rbNombreDescendentemente = new RadioButton();
            btnOrdenar = new Button();
            rbPrecioAscendentemente = new RadioButton();
            rbPrecioDescendentemente = new RadioButton();
            cmBoxProductos = new ComboBox();
            lblAgregarProducto = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            lstBoxObjetos = new ListBox();
            SuspendLayout();
            // 
            // btnVisualizadorUsuariosLogueo
            // 
            btnVisualizadorUsuariosLogueo.BackColor = SystemColors.GradientActiveCaption;
            btnVisualizadorUsuariosLogueo.Location = new Point(28, 537);
            btnVisualizadorUsuariosLogueo.Name = "btnVisualizadorUsuariosLogueo";
            btnVisualizadorUsuariosLogueo.Size = new Size(104, 80);
            btnVisualizadorUsuariosLogueo.TabIndex = 0;
            btnVisualizadorUsuariosLogueo.Text = "Ver registro de usuarios";
            btnVisualizadorUsuariosLogueo.UseVisualStyleBackColor = false;
            btnVisualizadorUsuariosLogueo.Click += btnVisualizadorUsuariosLogueo_Click;
            // 
            // lblUsuarioInfo
            // 
            lblUsuarioInfo.AutoSize = true;
            lblUsuarioInfo.BackColor = Color.Transparent;
            lblUsuarioInfo.ForeColor = SystemColors.ButtonHighlight;
            lblUsuarioInfo.Location = new Point(884, 9);
            lblUsuarioInfo.Name = "lblUsuarioInfo";
            lblUsuarioInfo.Size = new Size(85, 20);
            lblUsuarioInfo.TabIndex = 1;
            lblUsuarioInfo.Text = "InfoUsuario";
            lblUsuarioInfo.TextAlign = ContentAlignment.TopRight;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.GradientActiveCaption;
            btnAgregar.Location = new Point(846, 206);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 83);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar producto";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.GradientActiveCaption;
            btnModificar.Location = new Point(847, 307);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(150, 83);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar producto";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.GradientActiveCaption;
            btnEliminar.Location = new Point(846, 407);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 85);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar producto";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnMostrarCaracteristicasEspecificas
            // 
            btnMostrarCaracteristicasEspecificas.BackColor = SystemColors.GradientActiveCaption;
            btnMostrarCaracteristicasEspecificas.Location = new Point(846, 540);
            btnMostrarCaracteristicasEspecificas.Name = "btnMostrarCaracteristicasEspecificas";
            btnMostrarCaracteristicasEspecificas.Size = new Size(150, 77);
            btnMostrarCaracteristicasEspecificas.TabIndex = 5;
            btnMostrarCaracteristicasEspecificas.Text = "Mostrar caracteristicas del producto";
            btnMostrarCaracteristicasEspecificas.UseVisualStyleBackColor = false;
            btnMostrarCaracteristicasEspecificas.Click += btnMostrarCaracteristicasEspecificas_Click;
            // 
            // rbNombreAscendentemente
            // 
            rbNombreAscendentemente.AutoSize = true;
            rbNombreAscendentemente.BackColor = Color.Transparent;
            rbNombreAscendentemente.ForeColor = SystemColors.ActiveCaptionText;
            rbNombreAscendentemente.Location = new Point(153, 519);
            rbNombreAscendentemente.Name = "rbNombreAscendentemente";
            rbNombreAscendentemente.Size = new Size(288, 24);
            rbNombreAscendentemente.TabIndex = 6;
            rbNombreAscendentemente.TabStop = true;
            rbNombreAscendentemente.Text = "Ordenar por nombre ascendentemente";
            rbNombreAscendentemente.UseVisualStyleBackColor = false;
            // 
            // rbNombreDescendentemente
            // 
            rbNombreDescendentemente.AutoSize = true;
            rbNombreDescendentemente.BackColor = Color.Transparent;
            rbNombreDescendentemente.Location = new Point(153, 549);
            rbNombreDescendentemente.Name = "rbNombreDescendentemente";
            rbNombreDescendentemente.Size = new Size(297, 24);
            rbNombreDescendentemente.TabIndex = 7;
            rbNombreDescendentemente.TabStop = true;
            rbNombreDescendentemente.Text = "Ordenar por nombre descendentemente";
            rbNombreDescendentemente.UseVisualStyleBackColor = false;
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = SystemColors.GradientActiveCaption;
            btnOrdenar.Location = new Point(507, 540);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(153, 77);
            btnOrdenar.TabIndex = 9;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // rbPrecioAscendentemente
            // 
            rbPrecioAscendentemente.AutoSize = true;
            rbPrecioAscendentemente.BackColor = Color.Transparent;
            rbPrecioAscendentemente.Location = new Point(153, 579);
            rbPrecioAscendentemente.Name = "rbPrecioAscendentemente";
            rbPrecioAscendentemente.Size = new Size(278, 24);
            rbPrecioAscendentemente.TabIndex = 10;
            rbPrecioAscendentemente.TabStop = true;
            rbPrecioAscendentemente.Text = "Ordenar por precio ascendentemente";
            rbPrecioAscendentemente.UseVisualStyleBackColor = false;
            // 
            // rbPrecioDescendentemente
            // 
            rbPrecioDescendentemente.AutoSize = true;
            rbPrecioDescendentemente.BackColor = Color.Transparent;
            rbPrecioDescendentemente.Location = new Point(153, 609);
            rbPrecioDescendentemente.Name = "rbPrecioDescendentemente";
            rbPrecioDescendentemente.Size = new Size(287, 24);
            rbPrecioDescendentemente.TabIndex = 11;
            rbPrecioDescendentemente.TabStop = true;
            rbPrecioDescendentemente.Text = "Ordenar por precio descendentemente";
            rbPrecioDescendentemente.UseVisualStyleBackColor = false;
            // 
            // cmBoxProductos
            // 
            cmBoxProductos.BackColor = SystemColors.GradientActiveCaption;
            cmBoxProductos.FormattingEnabled = true;
            cmBoxProductos.Location = new Point(847, 102);
            cmBoxProductos.Name = "cmBoxProductos";
            cmBoxProductos.Size = new Size(150, 28);
            cmBoxProductos.TabIndex = 12;
            // 
            // lblAgregarProducto
            // 
            lblAgregarProducto.AutoSize = true;
            lblAgregarProducto.BackColor = Color.Transparent;
            lblAgregarProducto.ForeColor = SystemColors.ButtonFace;
            lblAgregarProducto.Location = new Point(847, 64);
            lblAgregarProducto.Name = "lblAgregarProducto";
            lblAgregarProducto.Size = new Size(150, 20);
            lblAgregarProducto.TabIndex = 13;
            lblAgregarProducto.Text = "Seleccionar producto";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lstBoxObjetos
            // 
            lstBoxObjetos.BackColor = SystemColors.GradientActiveCaption;
            lstBoxObjetos.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lstBoxObjetos.FormattingEnabled = true;
            lstBoxObjetos.ItemHeight = 19;
            lstBoxObjetos.Location = new Point(40, 28);
            lstBoxObjetos.Name = "lstBoxObjetos";
            lstBoxObjetos.Size = new Size(762, 460);
            lstBoxObjetos.TabIndex = 14;
            // 
            // FrmPrincipalEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo_empresa;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1037, 645);
            Controls.Add(lstBoxObjetos);
            Controls.Add(lblAgregarProducto);
            Controls.Add(cmBoxProductos);
            Controls.Add(rbPrecioDescendentemente);
            Controls.Add(rbPrecioAscendentemente);
            Controls.Add(btnOrdenar);
            Controls.Add(rbNombreDescendentemente);
            Controls.Add(rbNombreAscendentemente);
            Controls.Add(btnMostrarCaracteristicasEspecificas);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lblUsuarioInfo);
            Controls.Add(btnVisualizadorUsuariosLogueo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPrincipalEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comcelcon";
            FormClosing += FrmPrincipalEmpresa_FormClosing;
            Load += FrmPrincipalEmpresa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVisualizadorUsuariosLogueo;
        private Label lblUsuarioInfo;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnMostrarCaracteristicasEspecificas;
        private RadioButton rbNombreAscendentemente;
        private RadioButton rbNombreDescendentemente;
        private Button btnOrdenar;
        private RadioButton rbPrecioAscendentemente;
        private RadioButton rbPrecioDescendentemente;
        private ComboBox cmBoxProductos;
        private Label lblAgregarProducto;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ListBox lstBoxObjetos;
    }
}