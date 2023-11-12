using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Clase que representa un formulario en el cual se va a poder ver un registro de los usuario que se loguearon
    /// </summary>
    public partial class FrmVisualizadorUsuarios : Form
    {
        private string info;
        /// <summary>
        /// Inicializa los componentes del formulario
        /// </summary>
        public FrmVisualizadorUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deserializa el archivo usuarios.log y muestra en un richTextBox la informacion de los usuarios logueados
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void FrmVisualizadorUsuarios_Load(object sender, EventArgs e)
        {
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamReader sr = new StreamReader(@"../../../../usuarios.log", miCodificacion))
                {
                    info = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            this.richTxtBoxInfoLogueos.ReadOnly = true;
            this.richTxtBoxInfoLogueos.Text = info;
        }
    }
}
