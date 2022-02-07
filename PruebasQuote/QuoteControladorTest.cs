using Controladores;
using Escenarios;
using Xunit;
namespace PruebasQuote
{
    public class QuoteControladorTest
    {
        public QuoteControladorTest()
        {
            EscenarioControlador escenarioControlador = new EscenarioControlador();
            DatosInicales escenario01 = new DatosInicales();
            escenarioControlador.Grabar(escenario01);
        }

        [Theory]
        [InlineData(1, "La quote fue aceptada")]
        [InlineData(2, "La quote fue aceptada")]
        [InlineData(3, "La quote fue aceptada")]
        [InlineData(4, "La quote fue aceptada")]
        [InlineData(5, "La Quote ya tiene estado de Aceptado")]
        [InlineData(6, "Esta Quote tiene estado de rechazado")]
        [InlineData(7, "La quote fue rechazada")]
        public void QuoteControladorTest01(int quoteID, string stringEsperado)
        {
            string stringObtenido = QuoteControlador.ProcesarQuote(quoteID);

            Assert.Equal(stringEsperado, stringObtenido);
        }
    }
}
