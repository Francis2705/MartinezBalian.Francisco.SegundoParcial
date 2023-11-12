using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public class OpcionNoSeleccionadaException : Exception
    {
        public static string InformacionOpcionNoSeleccionada(OpcionNoSeleccionadaException ex)
        {
            return $"Error, no se selecciono un producto.\n\nSi lo ha seleccionado e igualmente aparece este cartel, " +
                $"por favor avise al tecnico en programacion sobre el siguiente error: {ex.Message}";
        }
    }
}
