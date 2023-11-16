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
    public partial class FrmRecuperarClave : Form
    {
        private List<UsuarioElectronico> listaUsuarios;
        public FrmRecuperarClave(FrmLogin frmLogin)
        {
            InitializeComponent();
            this.listaUsuarios = frmLogin.ListaDeUsuarios;
        }
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
        private void btnRellenoAutomatico_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int i = random.Next(0, listaUsuarios.Count);
            txtCorreo.Text = listaUsuarios[i].correo;
            txtLegajo.Text = listaUsuarios[i].legajo.ToString();
        }
    }
}
