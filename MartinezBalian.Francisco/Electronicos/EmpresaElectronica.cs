using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Representa una emmpresa electronica que contendria artefactos electronicos y es generica, permitiendo que la lista ahora sea de celulares
    /// u otros derivados de ArtefactoElectronico
    /// </summary>
    public sealed class EmpresaElectronica<T> : IUnicoID<T> where T : ArtefactoElectronico
    {
        //Atributos
        private string nombre;
        private string creador;
        private List<T> productosElectronicos;

        //Propiedades
        public string Nombre 
        {
            get { return nombre; }
        }
        public string Creador 
        {
            get { return creador; }
        }
        public List<T> ProductosElectronicos 
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
            this.productosElectronicos = new List<T>();
            this.nombre = nombre;
            this.creador = creador;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(EmpresaElectronica<T> e, T a)
        {
            foreach (T artefacto in e.productosElectronicos)
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
        public static bool operator !=(EmpresaElectronica<T> e, T a)
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
            return this == (T)obj;
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
        public static EmpresaElectronica<T> operator +(EmpresaElectronica<T> e, T a)
        {
            if (e != a)
            {
                e.productosElectronicos.Add(a);
            }
            return e;
        }
        public static EmpresaElectronica<T> operator -(EmpresaElectronica<T> e, T a)
        {
            if (e == a)
            {
                e.productosElectronicos.Remove(a);
            }
            return e;
        }

        //Metodos ordenamientos
        public static int OrdenarArtefactosPorNombreAscendente(T art1, T art2)
        {
            return String.Compare(art1.Nombre, art2.Nombre);
        }
        public static int OrdenarArtefactosPorNombreDescendente(T art1, T art2)
        {
            return String.Compare(art2.Nombre, art1.Nombre);
        }
        public static int OrdenarArtefactosPorPrecioAscendente(T art1, T art2)
        {
            return art1.Precio.CompareTo(art2.Precio);
        }
        public static int OrdenarArtefactosPorPrecioDescendente(T art1, T art2)
        {
            return art2.Precio.CompareTo(art1.Precio);
        }

        /// <summary>
        /// Definicion del metodo de la interfaz
        /// </summary>
        /// <param name="art">El objeto del tipo T del cual se va a tomar la info</param>
        /// <returns>Retorna la informacion del id</returns>
        public string RetornarDataDeId(T art)
        {
            return $"Numero de ID unico: {art.ID}";
        }
    }
}
