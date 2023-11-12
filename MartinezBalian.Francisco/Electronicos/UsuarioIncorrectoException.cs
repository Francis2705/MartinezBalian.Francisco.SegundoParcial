using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public class UsuarioIncorrectoException : Exception
    {
        public static string RetornarInformacionExcepcion(UsuarioIncorrectoException ex)
        {
            return $"Error, usuario invalido. Por favor verifique su correo y clave.\n\nSi ya lo ha hecho y " +
                $"cree que esto se trata de un error, informe al tecnico en programacion sobre el siguiente error: {ex.Message}";
        }
    }
}
