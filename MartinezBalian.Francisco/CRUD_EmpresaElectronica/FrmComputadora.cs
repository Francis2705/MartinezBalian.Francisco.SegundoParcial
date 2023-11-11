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
    /// Representa un formulario para agregar una computadora
    /// </summary>
    public partial class FrmComputadora : FrmAgregar
    {
        public Computadora computadora;
        float precio;
        int cantidadNucleos;
        double espacioDiscoSDD;
        bool tactil = false;
        ETipoOrigen tipoOrigen;
        int idTomado;
        /// <summary>
        /// Inicializa los componentes del formulario y setea el comboBox de si es tactil o no
        /// </summary>
        public FrmComputadora()
        {
            InitializeComponent();
            cbBoxTactil.Items.Add("SI");
            cbBoxTactil.Items.Add("NO");
            cbBoxTactil.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Llama al constructor anterior y a parte setea los campos con los datos de la computadora recibida
        /// </summary>
        public FrmComputadora(Computadora computadora) : this()
        {
            this.idTomado = computadora.ID;
            txtNombre.Text = computadora.Nombre;
            txtPrecio.Text = computadora.Precio.ToString();
            txtMarca.Text = computadora.Marca;
            txtBoxCantidadNucleos.Text = computadora.CantidadNucleos.ToString();
            txtBoxSDD.Text = computadora.EspacioDiscoSSD.ToString();
            cmBoxOrigen.Text = computadora.TipoOrigen.ToString();
            if (computadora.EsTactil)
            {
                cbBoxTactil.Text = "SI";
            }
            else
            {
                cbBoxTactil.Text = "NO";
            }
        }
        /// <summary>
        /// Si se pasa una serie de validaciones, se agrega una computadaora, sino se muestra un MessageBox.Show informando que no se pudo
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        protected override void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && float.TryParse(txtPrecio.Text, out precio) &&
                !string.IsNullOrWhiteSpace(txtMarca.Text) && int.TryParse(txtBoxCantidadNucleos.Text, out cantidadNucleos) &&
                double.TryParse(txtBoxSDD.Text, out espacioDiscoSDD) && cbBoxTactil.Text != string.Empty &&
                cmBoxOrigen.Text != string.Empty)
            {
                if (cbBoxTactil.Text == "SI")
                {
                    tactil = true;
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

                this.computadora = new Computadora(precio, txtNombre.Text, txtMarca.Text, tipoOrigen, tactil, espacioDiscoSDD,
                    cantidadNucleos);
                this.computadora.ID = this.idTomado;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campos invalidos o incompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
