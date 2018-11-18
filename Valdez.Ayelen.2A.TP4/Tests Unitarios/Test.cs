using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Tests_Unitarios
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Testea que la lista de paquetes de Correo este instanciada
        /// </summary>
        [TestMethod]
        
        public void ListaPaquetesEstaInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);


        }

        /// <summary>
        /// Testea que no se carguen dos paquetes con el mismo tracking id
        /// </summary>
        [TestMethod]
        
        public void NoCargarDosPaquetes()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Calle falsa 123", "123456");
            Paquete p2 = new Paquete("Direccion", "123456");

            try
            {
                correo += p1;
                correo += p2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
               
            }


        }
    }
}
