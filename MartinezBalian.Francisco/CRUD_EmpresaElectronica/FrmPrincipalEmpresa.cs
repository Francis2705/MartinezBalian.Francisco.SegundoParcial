using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
    //Delegados
    public delegate void Action(string nombre); //Delegado Action para permisos denegados y objeto repetido
    public delegate Color CambioColorBotones(bool permiso); //Delegado propio para cambiar colores

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

        //Eventos
        public event Action PermisoDenegado;
        public event Action ObjetoRepetido;
        public event CambioColorBotones CambioDeColor;

        public FrmPrincipalEmpresa()
        {
            InitializeComponent();

            //Inicializo eventos
            this.PermisoDenegado += InvalidacionesAcciones.UsuarioNoValido;
            this.ObjetoRepetido += InvalidacionesAcciones.ObjetoNoValido;
            this.CambioDeColor += InvalidacionesAcciones.CambiarDeColorFondoObjetos;

            //Cargo listas
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
                MessageBox.Show($"{((ArtefactoElectronico)lstBoxObjetos.SelectedItem).MostrarCaracteristicasEspecificas()}" +
                    $"{empresaElectronica.RetornarDataDeId(((ArtefactoElectronico)lstBoxObjetos.SelectedItem))}",
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
            if (usuarioElectronico.perfil != "vendedor")
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

                            if (this.ValidarAgregadoProducto(frmCeluar.celular))
                            {
                                if (ado.AgregarDato(frmCeluar.celular))
                                {
                                    frmCeluar.celular.ID = ado.TraerID(true, false, false, frmCeluar.celular);
                                    MessageBox.Show("Se agrego exitosamente a la lista y a la base de datos!",
                                        "Agregado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                            if (this.ValidarAgregadoProducto(frmComputadora.computadora))
                            {
                                if (ado.AgregarDato(frmComputadora.computadora))
                                {
                                    frmComputadora.computadora.ID = ado.TraerID(false, true, false, frmComputadora.computadora);
                                    MessageBox.Show("Se agrego exitosamente a la lista y a la base de datos!",
                                        "Agregado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                            if (this.ValidarAgregadoProducto(frmConsola.consola))
                            {
                                if (ado.AgregarDato(frmConsola.consola))
                                {
                                    frmConsola.consola.ID = ado.TraerID(false, false, true, frmConsola.consola);
                                    MessageBox.Show("Se agrego exitosamente a la lista y a la base de datos!",
                                        "Agregado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                this.PermisoDenegado.Invoke(usuarioElectronico.nombre);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioElectronico.perfil == "administrador" || usuarioElectronico.perfil == "supervisor")
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
                                MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!",
                                    "Modificacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!",
                                    "Modificacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("Se modifico exitosamente de la lista y de la base de datos!",
                                    "Modificacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                this.PermisoDenegado.Invoke(usuarioElectronico.nombre);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.usuarioElectronico.perfil == "administrador")
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
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        this.ado.EliminarDato((ArtefactoElectronico)lstBoxObjetos.SelectedItem);
                        this.empresaElectronica -= (ArtefactoElectronico)lstBoxObjetos.SelectedItem;
                        this.ActualizarVisor();
                    }
                }
            }
            else
            {
                this.PermisoDenegado.Invoke(usuarioElectronico.nombre);
            }
        }
        private void btnMostrarInfoUsuarioLogueado_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.usuarioElectronico.RetornarInfoImportante(), "Informacion de usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool ValidarAgregadoProducto(ArtefactoElectronico producto)
        {
            if (this.cantidad == this.empresaElectronica.ProductosElectronicos.Count)
            {
                this.ObjetoRepetido.Invoke(producto.Nombre);
                return false;
            }
            else
            {
                this.ActualizarVisor();
                return true;
            }
        }

        //Interacciones con el mouse encima de los botones
        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            bool valido = false;

            if (usuarioElectronico.perfil != "vendedor")
            {
                valido = true;
            }

            this.btnAgregar.BackColor = this.CambioDeColor.Invoke(valido);
        }
        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            this.btnAgregar.BackColor = SystemColors.GradientActiveCaption;
        }
        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            bool valido = false;

            if (usuarioElectronico.perfil == "administrador" || usuarioElectronico.perfil == "supervisor")
            {
                valido = true;
            }

            this.btnModificar.BackColor = this.CambioDeColor.Invoke(valido);
        }
        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            this.btnModificar.BackColor = SystemColors.GradientActiveCaption;
        }
        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            bool valido = false;

            if (this.usuarioElectronico.perfil == "administrador")
            {
                valido = true;
            }

            this.btnEliminar.BackColor = this.CambioDeColor.Invoke(valido);
        }
        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminar.BackColor = SystemColors.GradientActiveCaption;
        }
    }
}
