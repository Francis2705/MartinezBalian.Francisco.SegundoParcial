using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Interfaz para la representacion de identificadores únicos asociados a artefactos electrónicos.
    /// </summary>
    /// <typeparam name="T">Tipo de artefacto electrónico.</typeparam>
    public interface IUnicoID<T> where T : ArtefactoElectronico
    {
        /// <summary>
        /// Retorna la información del id asociada a un artefacto electrónico.
        /// </summary>
        /// <param name="art">Artefacto electrónico del cual se desea obtener la información de identificación única.</param>
        /// <returns>Información del id del artefacto electrónico.</returns>
        public string RetornarDataDeId(T art);
    }
}
