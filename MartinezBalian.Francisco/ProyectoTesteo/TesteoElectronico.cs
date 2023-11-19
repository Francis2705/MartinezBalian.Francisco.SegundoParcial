using Electronicos;

namespace ProyectoTesteo
{
    [TestClass]
    public class TesteoElectronico
    {
        /// <summary>
        /// Metodo de testeo que verifica la igualdad de dos celulares (siendo iguales)
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadCelularElectronicoOk()
        {
            //Arrange
            Celular celular1 = new Celular(500, "Iphone 11", "Apple", ETipoOrigen.AMERICANO, 50, 50, true);
            Celular celular2 = new Celular(500, "Iphone 11", "Otra marca", ETipoOrigen.CHINO, 30, 50, false);

            //Act
            bool rta = celular1 == celular2;

            //Assert
            Assert.IsTrue(rta);
        }
        /// <summary>
        /// Metodo de testeo que verifica la igualdad de dos celulares (no siendo iguales)
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadCelularElectronicoFalla()
        {
            //Arrange
            Celular celular1 = new Celular(500, "Iphone 11", "Apple", ETipoOrigen.AMERICANO, 50, 50, true);
            Celular celular2 = new Celular(500, "Iphone 12", "Otra marca", ETipoOrigen.CHINO, 30, 50, false);

            //Act
            bool rta = celular1 == celular2;

            //Assert
            Assert.IsFalse(rta);
        }
        /// <summary>
        /// Metodo de testeo que verifica la desigualdad de dos celulares (no siendo iguales)
        /// </summary>
        [TestMethod]
        public void VerificarDesigualdadCelularElectronicoOk()
        {
            //Arrange
            Celular celular1 = new Celular(500, "Iphone 11", "Apple", ETipoOrigen.AMERICANO, 50, 50, true);
            Celular celular2 = new Celular(600, "Iphone 11", "Otra marca", ETipoOrigen.CHINO, 30, 50, false);

            //Act
            bool rta = celular1 != celular2;

            //Assert
            Assert.IsTrue(rta);
        }
        /// <summary>
        /// Metodo de testeo que verifica la desigualdad de dos celulares (siendo iguales)
        /// </summary>
        [TestMethod]
        public void VerificarDesigualdadCelularElectronicoFalla()
        {
            //Arrange
            Celular celular1 = new Celular(500, "Iphone 11", "Apple", ETipoOrigen.AMERICANO, 50, 50, true);
            Celular celular2 = new Celular(500, "Iphone 11", "Otra marca", ETipoOrigen.CHINO, 30, 50, false);

            //Act
            bool rta = celular1 != celular2;

            //Assert
            Assert.IsFalse(rta);
        }
        /// <summary>
        /// Metodo de testeo que verifica si el artefacto electronico ya se encuentra en la lista (correctamente)
        /// </summary>
        [TestMethod]
        public void VerificarArtefactoEnListaOk()
        {
            EmpresaElectronica<ArtefactoElectronico> empresa = new EmpresaElectronica<ArtefactoElectronico>("Prueba", "Fran");

            Computadora computadora1 = new Computadora(200,"VivoBook", "Asus", ETipoOrigen.CHINO, true, 128, 6);

            empresa += computadora1;
            empresa += computadora1;

            bool rta = false;

            if (empresa.ProductosElectronicos.Count == 1)
            {
                rta = true;
            }

            Assert.IsTrue(rta);
        }
        /// <summary>
        /// Metodo de testeo que verifica si el artefacto electronico ya se encuentra en la lista (incorrectamente)
        /// </summary>
        [TestMethod]
        public void VerificarArtefactoEnListaFalla()
        {
            EmpresaElectronica<ArtefactoElectronico> empresa = new EmpresaElectronica<ArtefactoElectronico>("Prueba", "Fran");

            Computadora computadora1 = new Computadora(200, "VivoBook", "Asus", ETipoOrigen.CHINO, true, 128, 6);

            empresa += computadora1;
            empresa += computadora1;

            bool rta = false;

            if (empresa.ProductosElectronicos.Count == 2)
            {
                rta = true;
            }

            Assert.IsFalse(rta);
        }
    }
}