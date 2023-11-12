using Electronicos;

namespace ProyectoTesteo
{
    [TestClass]
    public class TesteoElectronico
    {
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