using Electronicos;
using System.Text;
using System.Text.Json;

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Representa un formulario para que un usuario se loguee para acceder a la empresa
    /// </summary>
    public partial class FrmLogin : Form
    {
        private List<UsuarioElectronico> listaUsuarios = new List<UsuarioElectronico>();
        private static UsuarioElectronico usuarioLogueado = null;
        /// <summary>
        /// Inicializa los componentes del formulario
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Deserializa el archivo de los usuarios
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {

            if (File.Exists(@"../../../../MOCK_DATA.json"))
            {
                using (StreamReader lectorJson = new StreamReader(@"../../../../MOCK_DATA.json"))
                {
                    string jsonString = lectorJson.ReadToEnd();

                    this.listaUsuarios = JsonSerializer.Deserialize<List<UsuarioElectronico>>(jsonString);
                }
            }
            else
            {
                MessageBox.Show("No se encontro el path del archivo");
                Application.Exit();
            }
        }
        /// <summary>
        /// Si el usuario y la clave son correctos, accede a la empresa, sino no lo deja entrar
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void btnIngresar_Click(object sender, EventArgs e) //Excepcion propia y de sistema 
        {
            bool usuarioValido = false;

            foreach (UsuarioElectronico usuario in listaUsuarios)
            {
                if (usuario.correo == txtBoxCorreo.Text && usuario.clave == txtBoxClave.Text)
                {
                    usuarioValido = true;
                    FrmLogin.usuarioLogueado = usuario;
                    break;
                }
            }
            if (usuarioValido)
            {
                Encoding miCodificacion = Encoding.UTF8;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Apellido: {usuarioLogueado.apellido}");
                sb.AppendLine($"Nombre: {usuarioLogueado.nombre}");
                sb.AppendLine($"Legajo: {usuarioLogueado.legajo}");
                sb.AppendLine($"Correo: {usuarioLogueado.correo}");
                sb.AppendLine($"Clave: {usuarioLogueado.clave}");
                sb.AppendLine($"Perfil: {usuarioLogueado.perfil}");
                sb.AppendLine($"Fecha de logueo: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                sb.ToString();

                using (StreamWriter sw = new StreamWriter(@"../../../../usuarios.log", true, miCodificacion))
                {
                    sw.WriteLine(sb);
                }

                this.Hide();
                FrmPrincipalEmpresa frmPrincipalEmpresa = new FrmPrincipalEmpresa();
                if (frmPrincipalEmpresa.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    txtBoxCorreo.Text = string.Empty;
                    txtBoxClave.Text = string.Empty;
                }
            }
            else
            {
                try
                {
                    throw new UsuarioIncorrectoException();
                }
                catch (UsuarioIncorrectoException ex)
                {
                    MessageBox.Show(UsuarioIncorrectoException.RetornarInformacionExcepcion(ex),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}\nLlamar urgente al tecnico!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //MessageBox.Show("Nombre de usuario o clave incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Rellena automaticamente los campos de usuario y clave
        /// </summary>
        /// <param name="sender">Representa un objeto de cualquier tipo</param>
        /// <param name="e">Representa un objeto de tipo EventArgs</param>
        private void btnRellenar_Click(object sender, EventArgs e) //MODIFICAR
        {
            /*Random random = new Random();
            int i = random.Next(0, listaUsuarios.Count);
            txtBoxCorreo.Text = listaUsuarios[i].correo;
            txtBoxClave.Text = listaUsuarios[i].clave;*/
            txtBoxCorreo.Text = "admin@admin.com";
            txtBoxClave.Text = "12345678";
        }
        /// <summary>
        /// Metodo que retorna el usuario logueado
        /// </summary>
        /// <returns>Retorna el usuario logueado</returns>
        public static UsuarioElectronico GetUsuarioElectronico()
        {
            return FrmLogin.usuarioLogueado;
        }
    }
}