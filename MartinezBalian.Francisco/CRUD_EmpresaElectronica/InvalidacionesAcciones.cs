using Electronicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EmpresaElectronica
{
    /// <summary>
    /// Clase que representa metodos sobre acciones invalidas en la app
    /// </summary>
    public class InvalidacionesAcciones
    {
        //Relacion con delegados sobre invalidaciones
        /// <summary>
        /// Muestra que el usuario logueado no tiene el perfil requerido para realizar cierta accion
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        public static void UsuarioNoValido(string nombre)
        {
            MessageBox.Show($"{nombre} no tiene permiso para realizar esta accion", "Permiso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Muestra que el objeto ya existe
        /// </summary>
        /// <param name="nombre">Nombre del objeto que ya existe</param>
        public static void ObjetoNoValido(string nombre)
        {
            MessageBox.Show($"Este producto de nombre: '{nombre}' ya existe! No se pueden agregar productos repetidos", "Producto repetido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Relacion con delegados sobre cambio de color de botones
        /// <summary>
        /// Segun el permiso, se cambia el color del fondo de los botones
        /// </summary>
        /// <param name="permiso">Si esta en true, se pintara de color verde agua, sino, de rojo</param>
        /// <returns>Retorna el color del cual se va a pintar el fondo del boton</returns>
        public static Color CambiarDeColorFondoObjetos(bool permiso)
        {
            if (permiso)
            {
                return Color.Aquamarine;
            }
            else
            {
                return Color.Red;
            }
        }
    }
}
