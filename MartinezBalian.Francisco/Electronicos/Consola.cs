using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa una consola
    /// </summary>
    public sealed class Consola : ArtefactoElectronico
    {
        //Atributos
        private bool aceptaDiscosFisicos;
        private double memoriaTotal;
        private short velocidadDescargaMB;

        //Propiedades
        public bool AceptaDiscosFisicos
        {
            get
            {
                return this.aceptaDiscosFisicos;
            }
            set
            {
                this.aceptaDiscosFisicos = value;
            }
        }
        public double MemoriaTotal
        {
            get
            {
                return this.memoriaTotal;
            }
            set
            {
                this.memoriaTotal = value;

                if (this.memoriaTotal > 2048)
                {
                    this.memoriaTotal = 2048;
                }
                else if (this.memoriaTotal < 64)
                {
                    this.memoriaTotal = 64;
                }
            }
        }
        public short VelocidadDescargaMB
        {
            get
            {
                return this.velocidadDescargaMB;
            }
            set
            {
                this.velocidadDescargaMB = value;

                if (this.velocidadDescargaMB > 500)
                {
                    this.velocidadDescargaMB = 500;
                }
                else if (this.velocidadDescargaMB < 0)
                {
                    this.velocidadDescargaMB = 10;
                }
            }
        }

        /// <summary>
        /// Constructor declarado para la serializacion
        /// </summary>
        public Consola()
        {

        }
        /// <summary>
        /// Crea una consola a partir de algunos datos y llama al constructor de la clase base
        /// </summary>
        /// <param name="precio">Recibe el precio</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="tipoOrigen">Recibe el origen</param>
        /// <param name="aceptaDiscosFisicos">Recibe si acepta discos fisicos o no</param>
        public Consola(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos)
            : base(precio, nombre, marca, tipoOrigen)
        {
            this.aceptaDiscosFisicos = aceptaDiscosFisicos;
            this.MemoriaTotal = 256;
            this.VelocidadDescargaMB = 10;
        }
        /// <summary>
        /// Crea una consola a partir de algunos datos y llama al constructor que setea si acepta o no discos fisicos
        /// </summary>
        /// <param name="precio">Recibe el precio</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="tipoOrigen">Recibe el origen</param>
        /// <param name="aceptaDiscosFisicos">Recibe si acepta discos fisicos o no</param>
        /// <param name="velocidadDescargaMB">Recibe la velocidad de descarga</param>
        public Consola(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos,
            short velocidadDescargaMB) : this(precio, nombre, marca, tipoOrigen, aceptaDiscosFisicos)
        {
            this.VelocidadDescargaMB = velocidadDescargaMB;
        }
        /// <summary>
        /// Crea una consola a partir de algunos datos y llama al constructor que setea si acepta o no discos fisicos y la velocidad de
        /// descarga
        /// </summary>
        /// <param name="precio">Recibe el precio</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="tipoOrigen">Recibe el origen</param>
        /// <param name="aceptaDiscosFisicos">Recibe si acepta discos fisicos o no</param>
        /// <param name="velocidadDescargaMB">Recibe la velocidad de descarga</param>
        /// <param name="velocidadDescargaMB">Recibe la velocidad de descarga</param>
        /// <param name="memoriaTotal">Recibe la memoria total</param>
        public Consola(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos,
            short velocidadDescargaMB, double memoriaTotal) : this(precio, nombre, marca, tipoOrigen, 
                aceptaDiscosFisicos, velocidadDescargaMB)
        {
            this.MemoriaTotal = memoriaTotal;
        }

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            return "Consola -> " + base.MostrarDatosGenerales();
        }
        public override string MostrarCaracteristicasEspecificas()
        {
            StringBuilder sb = new StringBuilder();

            if (this.aceptaDiscosFisicos)
            {
                sb.AppendLine("Acepta discos fisicos");
            }
            else
            {
                sb.AppendLine("No acepta discos fisicos");
            }

            sb.AppendLine($"Memoria total: {this.memoriaTotal}");
            sb.AppendLine($"Velocidad de descarga en MB: {this.velocidadDescargaMB}");

            return sb.ToString();
        }

        //Sobrecarga implicita y explicita
        public static implicit operator Consola(string nombreConsola)
        {
            return new Consola(10000, nombreConsola, "Consola sin marca", ETipoOrigen.INTERNACIONAL, false);
        }
        public static explicit operator string(Consola nombreConsola) 
        {
            return nombreConsola.nombre;
        }

        /// <summary>
        /// Sobrecarga del operador ==, compara por igualdad de nonmbre, precio y por velocidad de descarga
        /// </summary>
        /// <param name="art1">Representa una consola</param>
        /// <param name="art2">Representa otra consola</param>
        /// <returns>Retorna true si son iguales y false sino lo son</returns>
        public static bool operator ==(Consola con1, Consola con2) //Va al Equals() base
        {
            return ((ArtefactoElectronico)con1).Equals(con2) && con1.velocidadDescargaMB == con2.velocidadDescargaMB;
            //return ((ArtefactoElectronico)con1) == con2 && con1.velocidadDescargaMB == con2.velocidadDescargaMB;
        }
        public static bool operator !=(Consola con1, Consola con2)
        {
            return !(con1 == con2);
        }

        /// <summary>
        /// Sobrescritura del Equals()
        /// </summary>
        /// <param name="obj">Objeto de cualquier tipo</param>
        /// <returns>Retorna true si es de tipo consola</returns>
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
            //bool retorno = false;
            //if (obj is Consola)
            //{
            //    retorno = true;
            //}
            //return retorno;
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
        /// <returns>Llama al de la clase base</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //Metodos "normales" y sobrecarga
        public void AgregarMemoria()
        {
            this.MemoriaTotal += 50;
        }
        public void AgregarMemoria(int num)
        {
            this.memoriaTotal += num;
        }
    }
}
