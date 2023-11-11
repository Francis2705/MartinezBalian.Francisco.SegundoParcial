using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Representa el formulario de la empresa
    /// </summary>
    public partial class FrmPrincipalEmpresa : Form
    {
        private AccesoDatos ado = new AccesoDatos();
        private EmpresaElectronica empresaElectronica = new EmpresaElectronica("Comcelcon", "Francisco");
        private UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();
        private int cantidad;

        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
            this.empresaElectronica.ProductosElectronicos = this.ado.ObtenerTodasLasListas(this.empresaElectronica.ProductosElectronicos,
                true, false, false);
            this.empresaElectronica.ProductosElectronicos = this.ado.ObtenerTodasLasListas(this.empresaElectronica.ProductosElectronicos, 
                false, true, false);
            this.empresaElectronica.ProductosElectronicos = this.ado.ObtenerTodasLasListas(this.empresaElectronica.ProductosElectronicos, 
                false, false, true);
            this.Text = this.empresaElectronica.Nombre;
        }
        private void ActualizarVisor()
        {
            lstBoxObjetos.Items.Clear();

            foreach (ArtefactoElectronico artefacto in empresaElectronica.ProductosElectronicos)
            {
                lstBoxObjetos.Items.Add(artefacto); //Agrego un objeto y se muestran sus datos
            }
        }
        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesion?",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e)
        {
            this.lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";

            this.cmBoxProductos.Items.Add("Celular");
            this.cmBoxProductos.Items.Add("Computadora");
            this.cmBoxProductos.Items.Add("Consola");
            this.cmBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ActualizarVisor();

        }
        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }
        private void btnMostrarCaracteristicasEspecificas_Click(object sender, EventArgs e)
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para ver sus caracteristicas especificas", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"{((ArtefactoElectronico)lstBoxObjetos.SelectedItem).MostrarCaracteristicasEspecificas()}",
                    "Caracteristicas especificas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.rbNombreAscendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorNombreAscendente);
            }
            else if (this.rbNombreDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorNombreDescendente);
            }
            else if (this.rbPrecioAscendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorPrecioAscendente);
            }
            else if (this.rbPrecioDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica.OrdenarArtefactosPorPrecioDescendente);
            }
            this.ActualizarVisor();
        }
        private void btnAgregar_Click(object sender, EventArgs e) //aca los agrego a la lista de cada uno (falta hacer)
        {
            if (cmBoxProductos.SelectedItem != null)
            {
                string opcionSeleccionada = cmBoxProductos.SelectedItem.ToString();

                if (opcionSeleccionada == "Celular")
                {
                    FrmCelular frmCeluar = new FrmCelular();
                    frmCeluar.ShowDialog();

                    if (frmCeluar.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmCeluar.celular;
                        this.ValidarProducto();

                        if (ado.AgregarDato(frmCeluar.celular))
                        {
                            MessageBox.Show("se agrego");
                        }
                    }
                }
                else if (opcionSeleccionada == "Computadora")
                {
                    FrmComputadora frmComputadora = new FrmComputadora();
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmComputadora.computadora;
                        this.ValidarProducto();
                    }
                }
                else if (opcionSeleccionada == "Consola")
                {
                    FrmConsola frmConsola = new FrmConsola();
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        this.cantidad = empresaElectronica.ProductosElectronicos.Count;
                        this.empresaElectronica += frmConsola.consola;
                        this.ValidarProducto();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para agregar", "Agregar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("No se selecciono ningun producto para modificiar", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (this.lstBoxObjetos.SelectedItem is Celular)
                {
                    Celular celu = (Celular)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmCelular frmCeluar = new FrmCelular(celu);
                    frmCeluar.ShowDialog();

                    if (frmCeluar.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmCeluar.celular;
                        this.ActualizarVisor();
                    }
                }
                else if (this.lstBoxObjetos.SelectedItem is Computadora)
                {
                    Computadora computadora = (Computadora)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmComputadora frmComputadora = new FrmComputadora(computadora);
                    frmComputadora.ShowDialog();

                    if (frmComputadora.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmComputadora.computadora;
                        this.ActualizarVisor();
                    }
                }
                else if (this.lstBoxObjetos.SelectedItem is Consola)
                {
                    Consola consola = (Consola)this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex];

                    FrmConsola frmConsola = new FrmConsola(consola);
                    frmConsola.ShowDialog();

                    if (frmConsola.DialogResult == DialogResult.OK)
                    {
                        this.empresaElectronica.ProductosElectronicos[lstBoxObjetos.SelectedIndex] = frmConsola.consola;
                        this.ActualizarVisor();
                    }
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto? Esta accion es irreversible",
                "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    this.empresaElectronica -= (ArtefactoElectronico)lstBoxObjetos.SelectedItem;
                    this.ActualizarVisor();
                }
            }
        }
        private void ValidarProducto()
        {
            if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
            {
                MessageBox.Show("Error, producto existente");
            }
            else
            {
                this.ActualizarVisor();
            }
        }
    }
}
