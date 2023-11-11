﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Security.AccessControl;

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


        public List<ArtefactoElectronico> ObtenerTodasLasListas(bool celu, bool compu, bool conso)
        {
            List<ArtefactoElectronico> nuevaListaArtefactos = new List<ArtefactoElectronico>();
            string campos = "";

            if (celu)
            {
                campos = "precio,nombre,marca,tipoOrigen,asistenteVirtual,bateria,cantidadContactos FROM Celular";
            }
            else if (compu)
            {
                campos = "precio,nombre,marca,tipoOrigen,esTactil,cantidadNucleos,espacioDiscoSSD FROM Computadora";
            }
            else if(conso)
            {
                campos = "precio,nombre,marca,tipoOrigen,aceptaDiscosFisicos,memoriaTotal,velocidadDescargaMB FROM Consola";
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
                    celular.Precio = (double)this.lector["precio"];
                    celular.Nombre = (string)this.lector["nombre"];
                    celular.Marca = (string)this.lector["marca"];
                    celular.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
                    celular.AsistenteVirtual = (bool)this.lector["asistenteVirtual"];
                    celular.Bateria = (int)this.lector["bateria"];
                    celular.CantidadContactos = (int)this.lector["cantidadContactos"];

                    nuevaListaArtefactos.Add(celular);
                }
            }
            else if (compu)
            {
                while (this.lector.Read())
                {
                    Computadora computadora = new Computadora();
                    computadora.Precio = (double)this.lector["precio"];
                    computadora.Nombre = (string)this.lector["nombre"];
                    computadora.Marca = (string)this.lector["marca"];
                    computadora.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
                    computadora.EsTactil = (bool)this.lector["esTactil"];
                    computadora.CantidadNucleos = (int)this.lector["cantidadNucleos"];
                    computadora.EspacioDiscoSSD = (float)this.lector["espacioDiscoSSD"];

                    nuevaListaArtefactos.Add(computadora);
                }
            }
            else if (conso)
            {
                while (this.lector.Read())
                {
                    Consola consola = new Consola();
                    consola.Precio = (double)this.lector["precio"];
                    consola.Nombre = (string)this.lector["nombre"];
                    consola.Marca = (string)this.lector["marca"];
                    consola.TipoOrigen = AccesoDatos.ValidarEnum(this.lector);
                    consola.AceptaDiscosFisicos = (bool)this.lector["aceptaDiscosFisicos"];
                    consola.MemoriaTotal = (float)this.lector["memoriaTotal"];
                    consola.VelocidadDescargaMB = (int)this.lector["velocidadDescargaMB"];

                    nuevaListaArtefactos.Add(consola);
                }
            }

            this.lector.Close();
            if (this.conexion.State == System.Data.ConnectionState.Open)
            {
                this.conexion.Close();
            }
            return nuevaListaArtefactos;
        }

        public bool AgregarDato(ArtefactoElectronico artefacto) //terminar
        {
            string campos = "";
            bool retorno = false;

            if (artefacto is Celular)
            {
                Celular celu = ((Celular)artefacto);
                campos = "Celular(precio,nombre,marca,tipoOrigen,asistenteVirtual,bateria,cantidadContactos) " +
                    "VALUES()";
            }
            else if (artefacto is Computadora)
            {

            }
            else
            {

            }


            this.comando = new SqlCommand();
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
    }
}
