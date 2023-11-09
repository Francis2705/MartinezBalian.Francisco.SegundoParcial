using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Representa una emmpresa electronica que contendria artefactos electronicos
    /// </summary>
    public sealed class EmpresaElectronica
    {
        //Atributos
        private string nombre;
        private string creador;
        private List<ArtefactoElectronico> productosElectronicos;

        //Propiedades
        public string Nombre
        {
            get { return nombre; }
        }
        public string Creador
        {
            get { return creador; }
        }
        public List<ArtefactoElectronico> ProductosElectronicos
        {
            get { return productosElectronicos; }
            set { productosElectronicos = value;}
        }

        /// <summary>
        /// Crea una nueva empresa
        /// </summary>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="creador">Recibe el nombre del creador</param>
        public EmpresaElectronica(string nombre, string creador)
        {
            this.productosElectronicos = new List<ArtefactoElectronico>();
            this.nombre = nombre;
            this.creador = creador;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(EmpresaElectronica e, ArtefactoElectronico a)
        {
            foreach (ArtefactoElectronico artefacto in e.productosElectronicos)
            {
                /*if (a == artefacto)
                {
                    return true;
                }*/
                if (a.Equals(artefacto)) //Va al Equals de cada producto y ese va al base
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(EmpresaElectronica e, ArtefactoElectronico a)
        {
            return !(e == a);
        }

        /// <summary>
        /// Sobrescritura del Equals()
        /// </summary>
        /// <param name="obj">Objeto de cualquier tipo</param>
        /// <returns>Retorna true si el objeto esta en la empresa (relacion con el ==)</returns>
        public override bool Equals(object? obj)
        {
            return this == (ArtefactoElectronico)obj;
        }
        /// <summary>
        /// Sobrescritura del GetHashCode()
        /// </summary>
        /// <returns>Retorna la cantidad de productos que hay en la empresa</returns>
        public override int GetHashCode()
        {
            return productosElectronicos.Count;
        }
        /// <summary>
        /// Sobrescritura del ToString()
        /// </summary>
        /// <returns>Retorna un string con el nombre y el creador de la empres</returns>
        public override string ToString()
        {
            return $"Nombre: {nombre} - Creador: {creador}";
        }

        //Sobrecarga del operador + y -
        public static EmpresaElectronica operator +(EmpresaElectronica e, ArtefactoElectronico a)
        {
            if (e != a)
            {
                e.productosElectronicos.Add(a);
            }
            return e;
        }
        public static EmpresaElectronica operator -(EmpresaElectronica e, ArtefactoElectronico a)
        {
            if (e == a)
            {
                e.productosElectronicos.Remove(a);
            }
            return e;
        }

        //Metodos ordenamientos
        public static int OrdenarArtefactosPorNombreAscendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return String.Compare(art1.Nombre, art2.Nombre);
        }
        public static int OrdenarArtefactosPorNombreDescendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return String.Compare(art2.Nombre, art1.Nombre);
        }
        public static int OrdenarArtefactosPorPrecioAscendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return art1.Precio.CompareTo(art2.Precio);
        }
        public static int OrdenarArtefactosPorPrecioDescendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return art2.Precio.CompareTo(art1.Precio);
        }
    }
}
