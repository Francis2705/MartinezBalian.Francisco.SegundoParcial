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

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Representa un formulario para agregar una consola
    /// </summary>
    public partial class FrmConsola : FrmAgregar
    {
        public Consola consola;
        int precio;
        double memoriaTotal;
        int velocidadDescargaMB;
        bool aceptaDiscosFisicos = false;
        ETipoOrigen tipoOrigen;
        int idTomado;
        /// <summary>
        /// Inicializa los componentes del formulario y setea el comboBox de si acepta discos fisicos o no
        /// </summary>
        public FrmConsola()
        {
            InitializeComponent();
            cmBoxAceptaDiscosFisicos.Items.Add("SI");
            cmBoxAceptaDiscosFisicos.Items.Add("NO");
            cmBoxAceptaDiscosFisicos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Llama al constructor anterior y a parte setea los campos con los datos de la consola recibida
        /// </summary>
        public FrmConsola(Consola consola) : this()
        {
            this.idTomado = consola.ID;
            txtNombre.Text = consola.Nombre;
            txtPrecio.Text = consola.Precio.ToString();
            txtMarca.Text = consola.Marca;
            txtBoxMemoriaTotal.Text = consola.MemoriaTotal.ToString();
            txtBoxVelocidadDescarga.Text = consola.VelocidadDescargaMB.ToString();
            cmBoxOrigen.Text = consola.TipoOrigen.ToString();
            if (consola.AceptaDiscosFisicos)
            {
                cmBoxAceptaDiscosFisicos.Text = "SI";
            }
            else
            {
                cmBoxAceptaDiscosFisicos.Text = "NO";
            }
        }
        /// <summary>
        /// Si se pasa una serie de validaciones, se agrega una consola, sino se muestra un MessageBox.Show informando que no se pudo
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        protected override void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && int.TryParse(txtPrecio.Text, out precio) &&
                !string.IsNullOrWhiteSpace(txtMarca.Text) && double.TryParse(txtBoxMemoriaTotal.Text, out memoriaTotal) &&
                int.TryParse(txtBoxVelocidadDescarga.Text, out velocidadDescargaMB) && cmBoxAceptaDiscosFisicos.Text != string.Empty &&
                cmBoxOrigen.Text != string.Empty)
            {
                if (cmBoxAceptaDiscosFisicos.Text == "SI")
                {
                    aceptaDiscosFisicos = true;
                }
                switch (cmBoxOrigen.Text)
                {
                    case "CHINO":
                        tipoOrigen = ETipoOrigen.CHINO;
                        break;
                    case "AMERICANO":
                        tipoOrigen = ETipoOrigen.AMERICANO;
                        break;
                    case "KOREANO":
                        tipoOrigen = ETipoOrigen.KOREANO;
                        break;
                    case "JAPONES":
                        tipoOrigen = ETipoOrigen.JAPONES;
                        break;
                    case "INTERNACIONAL":
                        tipoOrigen = ETipoOrigen.INTERNACIONAL;
                        break;
                }

                this.consola = new Consola(precio, txtNombre.Text, txtMarca.Text, tipoOrigen, aceptaDiscosFisicos, velocidadDescargaMB,
                    memoriaTotal);
                this.consola.ID = this.idTomado;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campos invalidos o incompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
