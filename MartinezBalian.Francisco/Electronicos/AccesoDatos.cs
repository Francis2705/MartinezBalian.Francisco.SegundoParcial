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
    public sealed class AccesoDatos
    {
        private SqlConnection conexion; //objeto encargado de conectarse con el motor de base de datos
        private static string cadena_conexion; //es el string que me va a permitir conectarme
        private SqlCommand comando; //objeto para poder hacer consultas
        private SqlDataReader lector; //va a contener lo q devuelve la consulta de sql

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion;
            //AccesoDatos.cadena_conexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Electronicos_BD;Integrated Security=True;Trust Server Certificate=True";
        }
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

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
                    celular.ID = (int)this.lector["id"];
                    celular.Precio = (double)this.lector["precio"];
                    celular.Nombre = (string)this.lector["nombre"];
                    celular.Marca = (string)this.lector["marca"];
                    celular.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
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
                    computadora.ID = (int)this.lector["id"];
                    computadora.Precio = (double)this.lector["precio"];
                    computadora.Nombre = (string)this.lector["nombre"];
                    computadora.Marca = (string)this.lector["marca"];
                    computadora.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
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
                    consola.ID = (int)this.lector["id"];
                    consola.Precio = (double)this.lector["precio"];
                    consola.Nombre = (string)this.lector["nombre"];
                    consola.Marca = (string)this.lector["marca"];
                    consola.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
                    consola.AceptaDiscosFisicos = (bool)this.lector["aceptaDiscosFisicos"];
                    consola.MemoriaTotal = (double)this.lector["memoriaTotal"];
                    consola.VelocidadDescargaMB = (int)this.lector["velocidadDescargaMB"];

                    lista.Add(consola);
                }
            }

            this.lector.Close();
            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }
            return lista;
        }

        public bool AgregarDato(ArtefactoElectronico artefacto) //INSERT 
        {
            string campos = "";
            bool retorno = false;
            this.comando = new SqlCommand();

            if (artefacto is Celular)
            {
                Celular celu = ((Celular)artefacto);
                this.comando.Parameters.AddWithValue("@precio", celu.Precio);
                this.comando.Parameters.AddWithValue("@nombre", celu.Nombre);
                this.comando.Parameters.AddWithValue("@marca", celu.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", celu.TipoOrigen.ToString());
                this.comando.Parameters.AddWithValue("@asistenteVirtual", celu.AsistenteVirtual);
                this.comando.Parameters.AddWithValue("@bateria", celu.Bateria);
                this.comando.Parameters.AddWithValue("@cantidadContactos", celu.CantidadContactos);
                campos = "Celular(precio,nombre,marca,tipoOrigen,asistenteVirtual,bateria,cantidadContactos) " +
                    "VALUES(@precio, @nombre, @marca, @tipoOrigen, @asistenteVirtual, @bateria, @cantidadContactos)";
            }
            else if (artefacto is Computadora)
            {
                Computadora compu = ((Computadora)artefacto);
                this.comando.Parameters.AddWithValue("@precio", compu.Precio);
                this.comando.Parameters.AddWithValue("@nombre", compu.Nombre);
                this.comando.Parameters.AddWithValue("@marca", compu.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", compu.TipoOrigen.ToString());
                this.comando.Parameters.AddWithValue("@esTactil", compu.EsTactil);
                this.comando.Parameters.AddWithValue("@cantidadNucleos", compu.CantidadNucleos);
                this.comando.Parameters.AddWithValue("@espacioDiscoSSD", compu.EspacioDiscoSSD);
                campos = "Computadora(precio,nombre,marca,tipoOrigen,esTactil,cantidadNucleos,espacioDiscoSSD) " +
                    "VALUES(@precio, @nombre, @marca, @tipoOrigen, @esTactil, @cantidadNucleos, @espacioDiscoSSD)";
            }
            else if (artefacto is Consola)
            {
                Consola conso = ((Consola)artefacto);
                this.comando.Parameters.AddWithValue("@precio", conso.Precio);
                this.comando.Parameters.AddWithValue("@nombre", conso.Nombre);
                this.comando.Parameters.AddWithValue("@marca", conso.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", conso.TipoOrigen.ToString());
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

            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }

            return retorno;
        }
        public bool ModificarDato(ArtefactoElectronico artefacto) //UPDATE 
        {
            string campos = "";
            bool retorno = false;
            this.comando = new SqlCommand();

            if (artefacto is Celular)
            {
                Celular celu = ((Celular)artefacto);
                this.comando.Parameters.AddWithValue("@id", celu.ID);
                this.comando.Parameters.AddWithValue("@precio", celu.Precio);
                this.comando.Parameters.AddWithValue("@nombre", celu.Nombre);
                this.comando.Parameters.AddWithValue("@marca", celu.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", celu.TipoOrigen.ToString());
                this.comando.Parameters.AddWithValue("@asistenteVirtual", celu.AsistenteVirtual);
                this.comando.Parameters.AddWithValue("@bateria", celu.Bateria);
                this.comando.Parameters.AddWithValue("@cantidadContactos", celu.CantidadContactos);
                campos = "Celular set precio = @precio, nombre = @nombre, marca = @marca, tipoOrigen = @tipoOrigen," +
                    "asistenteVirtual = @asistenteVirtual, bateria = @bateria, cantidadContactos = @cantidadContactos WHERE id = @id";
            }
            else if (artefacto is Computadora)
            {
                Computadora compu = ((Computadora)artefacto);
                this.comando.Parameters.AddWithValue("@id", compu.ID);
                this.comando.Parameters.AddWithValue("@precio", compu.Precio);
                this.comando.Parameters.AddWithValue("@nombre", compu.Nombre);
                this.comando.Parameters.AddWithValue("@marca", compu.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", compu.TipoOrigen.ToString());
                this.comando.Parameters.AddWithValue("@esTactil", compu.EsTactil);
                this.comando.Parameters.AddWithValue("@cantidadNucleos", compu.CantidadNucleos);
                this.comando.Parameters.AddWithValue("@espacioDiscoSSD", compu.EspacioDiscoSSD);
                campos = "Computadora set precio = @precio, nombre = @nombre, marca = @marca, tipoOrigen = @tipoOrigen, " +
                    "esTactil = @esTactil, cantidadNucleos = @cantidadNucleos, espacioDiscoSSD = @espacioDiscoSSD WHERE id = @id";
            }
            else if (artefacto is Consola)
            {
                Consola conso = ((Consola)artefacto);
                this.comando.Parameters.AddWithValue("@id", conso.ID);
                this.comando.Parameters.AddWithValue("@precio", conso.Precio);
                this.comando.Parameters.AddWithValue("@nombre", conso.Nombre);
                this.comando.Parameters.AddWithValue("@marca", conso.Marca);
                this.comando.Parameters.AddWithValue("@tipoOrigen", conso.TipoOrigen.ToString());
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

            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }

            return retorno;
        }
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

            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }

            return retorno;
        }

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

        /*public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }*/
    }
}
