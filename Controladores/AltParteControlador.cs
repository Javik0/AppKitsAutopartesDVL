using Microsoft.EntityFrameworkCore;
using Modelos.Quote;
using Persistencia;
using System;
using System.Linq;

namespace Controladores
{
    public class AltParteControlador
    {
        public static Parte ProcesarAltPartes(int ParteID, int cantidad)
        {
            Parte parte = null;

            using(var db = new QuoteDB())
            {
                var altPartes = db.altPartes
                    .Include(pAlt => pAlt.ParteAlterna)
                    .Where(pAlt => pAlt.ParteId == ParteID)
                    .ToList();
                    
                foreach(var parteAlterna in altPartes)
                {
                    if(parteAlterna.ParteAlterna.Stock >= cantidad)
                    {
                        parte = parteAlterna.ParteAlterna;
                        break;
                    }
                }
            }
            
            return parte;
        }

    }
}