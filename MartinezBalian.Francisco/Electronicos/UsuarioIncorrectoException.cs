using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa una excepcion cuando el usuario es incorrecto
    /// </summary>
    public class UsuarioIncorrectoException : Exception
    {
        /// <summary>
        /// Informa que el usuario no es valido
        /// </summary>
        /// <param name="ex">Excepcio que se captura</param>
        /// <returns>Retorna un mennsae informando que el usuario es invalido</returns>
        public static string RetornarInformacionExcepcion(UsuarioIncorrectoException ex)
        {
            return $"Error, usuario invalido. Por favor verifique su correo y clave.\n\nSi ya lo ha hecho y " +
                $"cree que esto se trata de un error, informe al tecnico en programacion sobre el siguiente error: {ex.Message}";
        }
    }
}
