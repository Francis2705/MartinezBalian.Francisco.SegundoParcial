using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa una excepcion cuando no se selecciona una opcion
    /// </summary>
    public class OpcionNoSeleccionadaException : Exception
    {
        /// <summary>
        /// Informa que no se selecciono ningun producto
        /// </summary>
        /// <param name="ex">Objeto que representa la excepcion que se captura</param>
        /// <returns>Retorna un mennsae informando que no se selecciono nada</returns>
        public static string InformacionOpcionNoSeleccionada(OpcionNoSeleccionadaException ex)
        {
            return $"Error, no se selecciono un producto.\n\nSi lo ha seleccionado e igualmente aparece este cartel, " +
                $"por favor avise al tecnico en programacion sobre el siguiente error: {ex.Message}";
        }
    }
}
