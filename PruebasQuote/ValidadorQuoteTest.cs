using Controladores;
using Escenarios;
using Modelos.Quote;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasQuote
{
    public class ValidadorQuoteTest
    {
        public ValidadorQuoteTest()
        {
            EscenarioControlador escenarioControlador = new EscenarioControlador();
            DatosInicales escenario01 = new DatosInicales();
            escenarioControlador.Grabar(escenario01);
            string _ = QuoteControlador.ProcesarQuote(3);

            _ = QuoteControlador.ProcesarQuote(1);

            _ = QuoteControlador.ProcesarQuote(2);

            _ = QuoteControlador.ProcesarQuote(7);

            QuoteControlador.procesarQuoteconKit(4);

            
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(7, false)]
        public void validadorQuoteTest01(int quoteID, bool resultadoEsperado)
        {
            using (var db = new QuoteDB())
            {
                List<QuotePart> partes = db.quoteParts.Where(parte => parte.QuoteId == quoteID).ToList();

                bool valido = QuoteControlador.validarQuote(partes);

                if (valido)
                {
                    Assert.True(resultadoEsperado);
                }
                else
                {
                    Assert.False(resultadoEsperado);
                }
            }
        }
    }
}
