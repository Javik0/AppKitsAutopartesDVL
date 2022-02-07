using Controladores;
using Escenarios;
using Modelos.Quote;
using Persistencia;
using System;
using Xunit;

namespace PruebasQuote
{
    public class AltPartControladorTest
    {
        public AltPartControladorTest()
        {
            EscenarioControlador escenarioControlador = new EscenarioControlador();
            DatosInicales escenario01 = new DatosInicales();
            escenarioControlador.Grabar(escenario01);
            
        }
        [Theory]
        [InlineData(1,40, true)]
        [InlineData(3, 40, true)]
        [InlineData(5, 40, false)]
        [InlineData(6, 40, true)]
        [InlineData(8, 40, true)]
        [InlineData(10, 40, false)]
        [InlineData(11, 40, true)]
        [InlineData(13, 40, true)]
        [InlineData(15, 40, true)]
        public void AltPartControladorTest01(int ParteID, int Cantidad,bool resEsperado)
        {
            Parte prueba = AltParteControlador.ProcesarAltPartes(ParteID, Cantidad);

            if(!(prueba == null))
            {
                Assert.True(resEsperado);
            }
            else
            {
                Assert.False(resEsperado);
            }
        }
    }
}
