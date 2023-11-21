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
    /// Representa el formulario para que el usuario recupere la clave
    /// </summary>
    public partial class FrmRecuperarClave : Form
    {
        private List<UsuarioElectronico> listaUsuarios;
        /// <summary>
        /// Constructor de instancia que inicializa los componentes y aparte inicializa la lista de usuarios
        /// </summary>
        /// <param name="frmLogin">Login principal</param>
        public FrmRecuperarClave(FrmLogin frmLogin)
        {
            InitializeComponent();
            this.listaUsuarios = frmLogin.ListaDeUsuarios;
        }
        /// <summary>
        /// Boton que, si esta todo correcto, mostrara la clave del usuario
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool usuarioValido = false;
            string clave = "";

            foreach (UsuarioElectronico usuario in listaUsuarios)
            {
                if (usuario.correo == txtCorreo.Text && usuario.legajo.ToString() == txtLegajo.Text)
                {
                    usuarioValido = true;
                    clave = usuario.clave;
                    break;
                }
            }
            if (usuarioValido)
            {
                MessageBox.Show($"Su clave es: {clave}", "Clave recuperada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, datos incorrectos!", "Error en recuperar clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Rellena automaticamente los campos de usuario y legajo
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void btnRellenoAutomatico_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int i = random.Next(0, listaUsuarios.Count);
            txtCorreo.Text = listaUsuarios[i].correo;
            txtLegajo.Text = listaUsuarios[i].legajo.ToString();
        }
    }
}
