using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EmpresaElectronica
{
    public class InvalidacionesAcciones
    {
        //Relacion con delegados sobre invalidaciones
        public static void UsuarioNoValido(string nombre)
        {
            MessageBox.Show($"{nombre} no tiene permiso para realizar esta accion", "Permiso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ObjetoNoValido(string nombre)
        {
            MessageBox.Show($"Este producto de nombre: '{nombre}' ya existe! No se pueden agregar productos repetidos", "Producto repetido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Relacion con delegados sobre cambio de color de botones
    }
}
