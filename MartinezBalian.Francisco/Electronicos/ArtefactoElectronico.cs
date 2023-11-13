using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa un artefacto electronico (un celular, una computadora o una consola)
    /// </summary>
    public abstract class ArtefactoElectronico
    {
        //Atributos
        protected double precio;
        protected string nombre;
        protected string marca;
        protected ETipoOrigen tipoOrigen;
        protected int id;

        //Propiedades
        public double Precio 
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;

                if (this.precio < 0)
                {
                    this.precio = 1;
                }
            }
        }
        public string Nombre 
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Marca 
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        public ETipoOrigen TipoOrigen 
        {
            get
            {
                return this.tipoOrigen;
            }
            set
            {
                this.tipoOrigen = value;
            }
        }
        public int ID 
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Constructor declarado para la serializacion
        /// </summary>
        public ArtefactoElectronico()
        {

        }
        /// <summary>
        /// Constructor que crea un nuevo artefacto electronico
        /// </summary>
        /// <param name="precio">Recibe el precio</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="tipoOrigen">Recibe el origen</param>
        public ArtefactoElectronico(double precio, string nombre, string marca, ETipoOrigen tipoOrigen)
        {
            this.Precio = precio;
            this.nombre = nombre;
            this.marca = marca;
            this.tipoOrigen = tipoOrigen;
        }

        //Metodos con virtual y abstract
        public virtual string MostrarDatosGenerales()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Precio: U$S {this.precio} - ");
            sb.AppendLine($"Nombre: {this.nombre} - ");
            sb.AppendLine($"Marca: {this.marca} - ");
            sb.AppendLine($"Origen: {this.tipoOrigen}");
            
            return sb.ToString();
        }
        public abstract string MostrarCaracteristicasEspecificas();

        /// <summary>
        /// Sobrecarga del operador ==, compara por igualdad de nombre y precio
        /// </summary>
        /// <param name="art1">Representa un artefacto electronico</param>
        /// <param name="art2">Representa otro artefacto electronico</param>
        /// <returns>Retorna true si son iguales y false sino lo son</returns>
        public static bool operator ==(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return (art1.precio == art2.precio) && (art1.nombre == art2.nombre);
        }
        public static bool operator !=(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return !(art1 == art2);
        }

        /// <summary>
        /// Sobrescritura del Equals()
        /// </summary>
        /// <param name="obj">Objeto de cualquier tipo</param>
        /// <returns>Retorna true si es de tipo Artefacto electronico y si son iguales (relacion con el ==)</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is ArtefactoElectronico)
            {
                retorno = this == (ArtefactoElectronico)obj;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrescritura del ToString()
        /// </summary>
        /// <returns>Retorna un string con lo que devuelve el metodo MostrarDatosGenerales</returns>
        public override string ToString()
        {
            return this.MostrarDatosGenerales();
        }
        /// <summary>
        /// Sobrescritura del GetHashCode()
        /// </summary>
        /// <returns>Retorna el precio del artefacto</returns>
        public override int GetHashCode()
        {
            return (int)this.Precio;
        }
    }
}