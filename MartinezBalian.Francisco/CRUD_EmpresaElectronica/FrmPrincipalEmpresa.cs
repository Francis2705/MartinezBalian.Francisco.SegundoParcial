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
        private EmpresaElectronica<ArtefactoElectronico> empresaElectronica = new EmpresaElectronica<ArtefactoElectronico>
            ("Comcelcon", "Francisco");
        private UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();
        private int cantidad;

        public FrmPrincipalEmpresa() //Excepcion de sistema (en AccesoDatos, ObtenerTodasLasListas)
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
        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e) //Excepcion de sistema (en el form)
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }
        private void btnMostrarCaracteristicasEspecificas_Click(object sender, EventArgs e) //Excepcion propia y de sistema
        {
            if (this.lstBoxObjetos.SelectedIndex == -1)
            {
                try
                {
                    throw new OpcionNoSeleccionadaException();
                }
                catch (OpcionNoSeleccionadaException ex)
                {
                    MessageBox.Show(OpcionNoSeleccionadaException.InformacionOpcionNoSeleccionada(ex), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}\nLlamar urgente al tecnico!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica<ArtefactoElectronico>.OrdenarArtefactosPorNombreAscendente);
            }
            else if (this.rbNombreDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica<ArtefactoElectronico>.OrdenarArtefactosPorNombreDescendente);
            }
            else if (this.rbPrecioAscendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica<ArtefactoElectronico>.OrdenarArtefactosPorPrecioAscendente);
            }
            else if (this.rbPrecioDescendentemente.Checked == true)
            {
                empresaElectronica.ProductosElectronicos.Sort(EmpresaElectronica<ArtefactoElectronico>.OrdenarArtefactosPorPrecioDescendente);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un criterio de ordenamiento", "Ordenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarVisor();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
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

                        if (this.ValidarAgregadoProducto())
                        {
                            if (ado.AgregarDato(frmCeluar.celular))
                            {
                                frmCeluar.celular.ID = ado.TraerID(true, false, false, frmCeluar.celular);
                                MessageBox.Show("Se agrego exitosamente a la lista y a la base de datos!");
                            }
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

                        if (this.ValidarAgregadoProducto())
                        {
                            if (ado.AgregarDato(frmComputadora.computadora))
                            {
                                frmComputadora.computadora.ID = ado.TraerID(false, true, false, frmComputadora.computadora);
                                MessageBox.Show("Se agrego exitosamente a la base de datos!");
                            }
                        }
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

                        if (this.ValidarAgregadoProducto())
                        {
                            if (ado.AgregarDato(frmConsola.consola))
                            {
                                frmConsola.consola.ID = ado.TraerID(false, false, true, frmConsola.consola);
                                MessageBox.Show("Se agrego exitosamente a la base de datos!");
                            }
                        }
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

                        if (ado.ModificarDato(frmCeluar.celular))
                        {
                            MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!");
                        }

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

                        if (ado.ModificarDato(frmComputadora.computadora))
                        {
                            MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!");
                        }
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

                        if (ado.ModificarDato(frmConsola.consola))
                        {
                            MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!");
                        }
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
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto? Se va a eliminar de " +
                    "la lista y de la base de datos definitivamente!", "Confirmar eliminacion", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    this.ado.EliminarDato((ArtefactoElectronico)lstBoxObjetos.SelectedItem);
                    this.empresaElectronica -= (ArtefactoElectronico)lstBoxObjetos.SelectedItem;
                    this.ActualizarVisor();
                }
            }
        }
        private bool ValidarAgregadoProducto()
        {
            if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
            {
                MessageBox.Show("Error, producto existente, no se pudo agregar ni a la lista ni a la base de datos");
                return false;
            }
            else
            {
                this.ActualizarVisor();
                return true;
            }
        }
    }
}
