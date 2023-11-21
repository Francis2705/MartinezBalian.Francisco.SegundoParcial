using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Interfaz que representa un reporte
    /// </summary>
    public interface IReporte
    {
        /// <summary>
        /// Se encarga de devolver la informacion importante
        /// </summary>
        /// <returns>Retorna todo el string con la info</returns>
        public string RetornarInfoImportante();
    }
}
