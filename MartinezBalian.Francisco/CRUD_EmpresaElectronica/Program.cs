using Electronicos;
using System.Security.Cryptography;

namespace CRUD_EmpresaElectronica
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            /* AccesoDatos ado = new AccesoDatos();

            if (ado.PruebaConexion())
            {
                Console.WriteLine("se conecto");
            }
            else
            {
                Console.WriteLine("no se conecto");
            } */

            Application.Run(new FrmLogin());
        }
    }
}