using Electronicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private EmpresaElectronica empresaElectronica = new EmpresaElectronica("Comcelcon", "Francisco");
        private bool error;
        private int cantidad;

        /// <summary>
        /// Inicializa los componentes del formulario y setea el posible error en falso
        /// </summary>
        public FrmPrincipalEmpresa()
        {
            InitializeComponent();
            this.Text = this.empresaElectronica.Nombre;
            this.error = false;
        }
        /// <summary>
        /// Limpia y actualiza el listBox de los productos
        /// </summary>
        private void ActualizarVisor()
        {
            lstBoxObjetos.Items.Clear();

            foreach (ArtefactoElectronico artefacto in empresaElectronica.ProductosElectronicos)
            {
                lstBoxObjetos.Items.Add(artefacto); //Agrego un objeto y se muestran sus datos
            }
        }
        /// <summary>
        /// Cierra el formulario de empresa y sino hubo ningun error, serializa la lista de productos para guardar sus cambios.
        /// Ademas, se hace uso de la clase SaveFileDialog para dar opcion a guardar el archivo en donde quiera la persona
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo FormClosingEventArgs</param>
        private void FrmPrincipalEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (error)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la sesion?",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "XML Files (*.xml)|*.xml";
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = saveDialog.FileName;

                            XmlSerializer serializer = new XmlSerializer(typeof(List<ArtefactoElectronico>));

                            using (FileStream stream = new FileStream(fileName, FileMode.Create)) //Ahora lo abro para escribir
                            {
                                serializer.Serialize(stream, empresaElectronica.ProductosElectronicos);
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Carga el formulario de empresa y sino hubo ningun error, deserializa el archivo xml para asi cargar su contenido en la lista
        /// de productos de la empresa. Ademas, se hace uso de la clase OpenFileDialog para dar opcion a abrir un archivo por si existiese
        /// mas de uno
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void FrmPrincipalEmpresa_Load(object sender, EventArgs e)
        {
            UsuarioElectronico usuarioElectronico = FrmLogin.GetUsuarioElectronico();

            this.lblUsuarioInfo.Text = $"Nombre: {usuarioElectronico.nombre}\nFecha: {DateTime.Now.ToString("yyyy-MM-dd")}";

            this.cmBoxProductos.Items.Add("Celular");
            this.cmBoxProductos.Items.Add("Computadora");
            this.cmBoxProductos.Items.Add("Consola");
            this.cmBoxProductos.DropDownStyle = ComboBoxStyle.DropDownList;

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "XML Files (*.xml)|*.xml";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openDialog.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ArtefactoElectronico>));

                    try
                    {
                        using (FileStream stream = new FileStream(fileName, FileMode.Open)) //FileMode.Open es de solo lectura
                        {
                            this.empresaElectronica.ProductosElectronicos = (List<ArtefactoElectronico>)serializer.Deserialize(stream);
                        }
                        this.ActualizarVisor();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex}");
                        this.error = true;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    this.error = true;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        /// <summary>
        /// Llama la formulario de visualizador de usuarios logueados
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void btnVisualizadorUsuariosLogueo_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuarios frmVisualizadorUsuarios = new FrmVisualizadorUsuarios();
            frmVisualizadorUsuarios.ShowDialog();
        }
        /// <summary>
        /// Muestra las caracteristicas especificas del producto seleccionado
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
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
        /// <summary>
        /// Ordena la lista de productos segun el criterio seleccionado
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
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
        /// <summary>
        /// Instancia el formulario del producto que se quiera agregar y agrega un producto inexistente a la lista
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
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
                        this.empresaElectronica += frmCeluar.celular; //empresaElectronica.ProductosElectronicos.Add(frmCeluar.celular);
                        this.ValidarProducto();
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
        /// <summary>
        /// Instancia el formulario del producto que se quiera modificar y modifica dicho producto
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
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
        /// <summary>
        /// Elimina un producto existente en la lista
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
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
        /// <summary>
        /// Valida si el producto se agrego o no a la lista
        /// </summary>
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
