using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Security.AccessControl;
using System.Collections;

namespace Electronicos
{
    /// <summary>
    /// Clase referida a todo el manejo del programa con una base de datos
    /// </summary>
    public sealed class AccesoDatos
    {
        private SqlConnection conexion; //objeto encargado de conectarse con el motor de base de datos
        private static string cadena_conexion; //es el string que me va a permitir conectarme
        private SqlCommand comando; //objeto para poder hacer consultas
        private SqlDataReader lector; //va a contener lo q devuelve la consulta de sql

        /// <summary>
        /// Construcutor estatico que se encarga de inicializar la cadena de conexion para el motor de la base de datos
        /// </summary>
        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion;
            //AccesoDatos.cadena_conexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Electronicos_BD;Integrated Security=True;Trust Server Certificate=True";
        }
        /// <summary>
        /// Constructor de instancia que se encarga de inicializar la conexion con la base de datos
        /// </summary>
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        /// <summary>
        /// Metodo que se encarga de tomar los datos de todas las tablas de la base de datos
        /// </summary>
        /// <param name="lista">La lista que se va a pasar para llenar de datos</param>
        /// <param name="celu">Si esta en true, se toman los datos de la tabla de los celulalres</param>
        /// <param name="compu">Si esta en true, se toman los datos de la tabla de las computadoras</param>
        /// <param name="conso">Si esta en true, se toman los datos de la tabla de las consolas</param>
        /// <returns>Devuelve la lista completa con los datos</returns>
        public List<ArtefactoElectronico> ObtenerTodasLasListas(List<ArtefactoElectronico> lista,
            bool celu, bool compu, bool conso) //SELECT
        {
            string campos = "";

            if (celu)
            {
                campos = "id,precio,nombre,marca,tipoOrigen,asistenteVirtual,bateria,cantidadContactos FROM Celular";
            }
            else if (compu)
            {
                campos = "id,precio,nombre,marca,tipoOrigen,esTactil,cantidadNucleos,espacioDiscoSSD FROM Computadora";
            }
            else if(conso)
            {
                campos = "id,precio,nombre,marca,tipoOrigen,aceptaDiscosFisicos,memoriaTotal,velocidadDescargaMB FROM Consola";
            }

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text; //indica que se va a ejecutar una query
                this.comando.CommandText = $"SELECT {campos}"; //consulta SELECT
                this.comando.Connection = this.conexion; //objeto que va a tener q estar activo para que se ejecute el comando
                this.conexion.Open();
                this.lector = this.comando.ExecuteReader(); //devuelve la tabla que leyo con sus distintos atributos

                if (celu)
                {
                    while (this.lector.Read())
                    {
                        Celular celular = new Celular();
                        this.SeleccionarGeneral(celular);
                        celular.AsistenteVirtual = (bool)this.lector["asistenteVirtual"];
                        celular.Bateria = (int)this.lector["bateria"];
                        celular.CantidadContactos = (int)this.lector["cantidadContactos"];

                        lista.Add(celular);
                    }
                }
                else if (compu)
                {
                    while (this.lector.Read())
                    {
                        Computadora computadora = new Computadora();
                        this.SeleccionarGeneral(computadora);
                        computadora.EsTactil = (bool)this.lector["esTactil"];
                        computadora.CantidadNucleos = (int)this.lector["cantidadNucleos"];
                        computadora.EspacioDiscoSSD = (double)this.lector["espacioDiscoSSD"];

                        lista.Add(computadora);
                    }
                }
                else if (conso)
                {
                    while (this.lector.Read())
                    {
                        Consola consola = new Consola();
                        this.SeleccionarGeneral(consola);
                        consola.AceptaDiscosFisicos = (bool)this.lector["aceptaDiscosFisicos"];
                        consola.MemoriaTotal = (double)this.lector["memoriaTotal"];
                        consola.VelocidadDescargaMB = (int)this.lector["velocidadDescargaMB"];

                        lista.Add(consola);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.lector.Close();
                this.CerrarConexion();
            }
            return lista;
        }
        /// <summary>
        /// Agrega un artefacto electronico a la base de datos
        /// </summary>
        /// <param name="artefacto">Es el artefacato que se va a agregar</param>
        /// <returns>Retorna un booleano indicando si se pudo agregar o no</returns>
        public bool AgregarDato(ArtefactoElectronico artefacto) //INSERT
        {
            string campos = "";
            bool retorno = false;
            this.comando = new SqlCommand();

            if (artefacto is Celular)
            {
                Celular celu = ((Celular)artefacto);
                this.ConsultarGeneralmente(this.comando, celu);
                this.comando.Parameters.AddWithValue("@asistenteVirtual", celu.AsistenteVirtual);
                this.comando.Parameters.AddWithValue("@bateria", celu.Bateria);
                this.comando.Parameters.AddWithValue("@cantidadContactos", celu.CantidadContactos);
                campos = "Celular(precio,nombre,marca,tipoOrigen,asistenteVirtual,bateria,cantidadContactos) " +
                    "VALUES(@precio, @nombre, @marca, @tipoOrigen, @asistenteVirtual, @bateria, @cantidadContactos)";
            }
            else if (artefacto is Computadora)
            {
                Computadora compu = ((Computadora)artefacto);
                this.ConsultarGeneralmente(this.comando, compu);
                this.comando.Parameters.AddWithValue("@esTactil", compu.EsTactil);
                this.comando.Parameters.AddWithValue("@cantidadNucleos", compu.CantidadNucleos);
                this.comando.Parameters.AddWithValue("@espacioDiscoSSD", compu.EspacioDiscoSSD);
                campos = "Computadora(precio,nombre,marca,tipoOrigen,esTactil,cantidadNucleos,espacioDiscoSSD) " +
                    "VALUES(@precio, @nombre, @marca, @tipoOrigen, @esTactil, @cantidadNucleos, @espacioDiscoSSD)";
            }
            else if (artefacto is Consola)
            {
                Consola conso = ((Consola)artefacto);
                this.ConsultarGeneralmente(this.comando, conso);
                this.comando.Parameters.AddWithValue("@aceptaDiscosFisicos", conso.AceptaDiscosFisicos);
                this.comando.Parameters.AddWithValue("@memoriaTotal", conso.MemoriaTotal);
                this.comando.Parameters.AddWithValue("@velocidadDescargaMB", conso.VelocidadDescargaMB);
                campos = "Consola(precio,nombre,marca,tipoOrigen,aceptaDiscosFisicos,memoriaTotal,velocidadDescargaMB) " +
                    "VALUES(@precio, @nombre, @marca, @tipoOrigen, @aceptaDiscosFisicos, @memoriaTotal, @velocidadDescargaMB)";
            }

            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = $"INSERT INTO {campos}";
            this.comando.Connection = this.conexion;
            this.conexion.Open();
            int filasAfectadas = this.comando.ExecuteNonQuery();

            if (filasAfectadas == 1)
            {
                retorno = true;
            }

            this.CerrarConexion();

            return retorno;
        }
        /// <summary>
        /// Modifica un artefacto electronico de la base de datos
        /// </summary>
        /// <param name="artefacto">Es el artefacato que se va a modificar</param>
        /// <returns>Retorna un booleano indicando si se pudo modificar o no</returns>
        public bool ModificarDato(ArtefactoElectronico artefacto) //UPDATE
        {
            string campos = "";
            bool retorno = false;
            this.comando = new SqlCommand();

            if (artefacto is Celular)
            {
                Celular celu = ((Celular)artefacto);
                this.ConsultarGeneralmente(this.comando, celu);
                this.comando.Parameters.AddWithValue("@asistenteVirtual", celu.AsistenteVirtual);
                this.comando.Parameters.AddWithValue("@bateria", celu.Bateria);
                this.comando.Parameters.AddWithValue("@cantidadContactos", celu.CantidadContactos);
                campos = "Celular set precio = @precio, nombre = @nombre, marca = @marca, tipoOrigen = @tipoOrigen," +
                    "asistenteVirtual = @asistenteVirtual, bateria = @bateria, cantidadContactos = @cantidadContactos WHERE id = @id";
            }
            else if (artefacto is Computadora)
            {
                Computadora compu = ((Computadora)artefacto);
                this.ConsultarGeneralmente(this.comando, compu);
                this.comando.Parameters.AddWithValue("@esTactil", compu.EsTactil);
                this.comando.Parameters.AddWithValue("@cantidadNucleos", compu.CantidadNucleos);
                this.comando.Parameters.AddWithValue("@espacioDiscoSSD", compu.EspacioDiscoSSD);
                campos = "Computadora set precio = @precio, nombre = @nombre, marca = @marca, tipoOrigen = @tipoOrigen, " +
                    "esTactil = @esTactil, cantidadNucleos = @cantidadNucleos, espacioDiscoSSD = @espacioDiscoSSD WHERE id = @id";
            }
            else if (artefacto is Consola)
            {
                Consola conso = ((Consola)artefacto);
                this.ConsultarGeneralmente(this.comando, conso);
                this.comando.Parameters.AddWithValue("@aceptaDiscosFisicos", conso.AceptaDiscosFisicos);
                this.comando.Parameters.AddWithValue("@memoriaTotal", conso.MemoriaTotal);
                this.comando.Parameters.AddWithValue("@velocidadDescargaMB", conso.VelocidadDescargaMB);
                campos = "Consola set precio = @precio, nombre = @nombre, marca = @marca, tipoOrigen = @tipoOrigen, " +
                    "aceptaDiscosFisicos = @aceptaDiscosFisicos, memoriaTotal = @memoriaTotal, velocidadDescargaMB = @velocidadDescargaMB " +
                    "WHERE id = @id";
            }

            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = $"UPDATE {campos}";
            this.comando.Connection = this.conexion;
            this.conexion.Open();
            int filasAfectadas = this.comando.ExecuteNonQuery();

            if (filasAfectadas == 1)
            {
                retorno = true;
            }

            this.CerrarConexion();

            return retorno;
        }
        /// <summary>
        /// Elimina un artefacto electronico de la base de datos
        /// </summary>
        /// <param name="artefacto">Es el artefacato que se va a eliminar</param>
        /// <returns>Retorna un booleano indicando si se pudo eliminar o no</returns>
        public bool EliminarDato(ArtefactoElectronico artefacto) //DELETE
        {
            int id = artefacto.ID;
            bool retorno = false;
            string tabla = "";
            this.comando = new SqlCommand();

            if (artefacto is Celular)
            {
                tabla = "Celular";
            }
            else if (artefacto is Computadora)
            {
                tabla = "Computadora";
            }
            else if (artefacto is Consola)
            {
                tabla = "Consola";
            }

            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = $"DELETE from {tabla} WHERE id = {id}";
            this.comando.Connection = this.conexion;
            this.conexion.Open();
            int filasAfectadas = this.comando.ExecuteNonQuery();

            if (filasAfectadas == 1)
            {
                retorno = true;
            }

            this.CerrarConexion();

            return retorno;
        }
        /// <summary>
        /// Se encarga de validar los strings del lector de base de datos, para asi transformarlos en enum
        /// </summary>
        /// <param name="lectorAuxiliar">Es el lector de la base de datos</param>
        /// <returns>Retorna el enum correcto del objeto</returns>
        private static ETipoOrigen ValidarEnum(SqlDataReader lectorAuxiliar)
        {
            if (lectorAuxiliar["tipoOrigen"].ToString() == "CHINO")
            {
                return ETipoOrigen.CHINO;
            }
            else if (lectorAuxiliar["tipoOrigen"].ToString() == "AMERICANO")
            {
                return ETipoOrigen.AMERICANO;
            }
            else if (lectorAuxiliar["tipoOrigen"].ToString() == "KOREANO")
            {
                return ETipoOrigen.KOREANO;
            }
            else if (lectorAuxiliar["tipoOrigen"].ToString() == "JAPONES")
            {
                return ETipoOrigen.JAPONES;
            }
            else
            {
                return ETipoOrigen.INTERNACIONAL;
            }
        }
        /// <summary>
        /// Toma el id de la base de datos de un objeto que se creo o modifico
        /// </summary>
        /// <param name="celu">Si esta en true, va a buscar en la tabla de celulares</param>
        /// <param name="compu">Si esta en true, va a buscar en la tabla de computadoras</param>
        /// <param name="conso">Si esta en true, va a buscar en la tabla de consolas</param>
        /// <param name="artefacto">Artefacto del cual se va a buscar el id</param>
        /// <returns></returns>
        public int TraerID(bool celu, bool compu, bool conso, ArtefactoElectronico artefacto)
        {
            int id = 0;
            string tabla = "";

            if (celu)
            {
                tabla = "Celular";
            }
            else if (compu)
            {
                tabla = "Computadora";
            }
            else if (conso)
            {
                tabla = "Consola";
            }

            this.comando = new SqlCommand();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = $"SELECT id from {tabla} WHERE nombre = '{artefacto.Nombre}'";
            this.comando.Connection = this.conexion;
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();

            
            while (this.lector.Read())
            {
                id = (int)this.lector["id"];
            }
            this.lector.Close();
            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }

            return id;
        }
        /// <summary>
        /// Metodo que hace una consulta general de todas las tablas
        /// </summary>
        /// <param name="comandoAux">Es el objeto de comando de sql</param>
        /// <param name="art">Es el artefacto del cual se van a tomar los datos</param>
        public void ConsultarGeneralmente(SqlCommand comandoAux, ArtefactoElectronico art)
        {
            comandoAux.Parameters.AddWithValue("@id", art.ID);
            comandoAux.Parameters.AddWithValue("@precio", art.Precio);
            comandoAux.Parameters.AddWithValue("@nombre", art.Nombre);
            comandoAux.Parameters.AddWithValue("@marca", art.Marca);
            comandoAux.Parameters.AddWithValue("@tipoOrigen", art.TipoOrigen.ToString());
        }
        /// <summary>
        /// Hace una seleccion general de datos del artefaco
        /// </summary>
        /// <param name="art">Artefacto del cual se van a tomar los datos</param>
        public void SeleccionarGeneral(ArtefactoElectronico art)
        {
            art.ID = (int)this.lector["id"];
            art.Precio = (double)this.lector["precio"];
            art.Nombre = (string)this.lector["nombre"];
            art.Marca = (string)this.lector["marca"];
            art.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
        }
        /// <summary>
        /// Se encarga de cerrar la conexion si esta abierta
        /// </summary>
        private void CerrarConexion()
        {
            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }
        }
    }
}
