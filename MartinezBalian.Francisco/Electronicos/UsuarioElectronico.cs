using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa un usuario
    /// </summary>
    public class UsuarioElectronico : IReporte
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }

        /// <summary>
        /// Sobrescripcion del metodo ToString()
        /// </summary>
        /// <returns>Retorna un string con el nombre y apellido</returns>
        public override string ToString()
        {
            return $"Nombre: {nombre} - Apellido: {apellido}\n";
        }
        public string RetornarInfoImportante()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"Legajo: {this.legajo}");
            sb.AppendLine($"Correo: {this.correo}");
            sb.AppendLine($"Clave: {this.clave}");
            sb.AppendLine($"Perfil: {this.perfil}");

            return sb.ToString();
        }
    }
}
