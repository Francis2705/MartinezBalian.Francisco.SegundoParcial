using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public interface IUnicoID<T> where T : ArtefactoElectronico
    {
        public string RetornarDataDeId(T art);
    }
}
