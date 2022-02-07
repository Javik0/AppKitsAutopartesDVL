using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Persistencia
{
    public class QuoteConfig
    {
        public enum DestinoTipo { SQLServer, Postgres, Memory };
        const string KeyPersistenciaDestino = "PersistenciaDestino";
        static DestinoTipo PersistenciaDestino;
        static string StringConnection ;

        static QuoteConfig()
        {
            if (String.IsNullOrEmpty(StringConnection))
            {
                // Lectura de los parámetros del sistema
                PersistenciaDestino = (DestinoTipo)Enum.Parse(typeof(DestinoTipo), ConfigurationManager.AppSettings[KeyPersistenciaDestino].ToString());
                StringConnection = ConfigurationManager.ConnectionStrings[PersistenciaDestino.ToString()].ToString();
                // Debug
                Console.WriteLine(PersistenciaDestino + " --> " + StringConnection);
            }
        }

        static public void ContextOptions(DbContextOptionsBuilder optionsBuilder)
        {
            switch (PersistenciaDestino)
            {
                case DestinoTipo.SQLServer:
                    optionsBuilder.UseSqlServer(StringConnection);
                    break;
                case DestinoTipo.Postgres:
                    optionsBuilder.UseNpgsql(StringConnection);
                    break;
             /* case DestinoTipo.Memory:
                    optionsBuilder.UseInMemoryDatabase(StringConnection);
                    break; */
                default:
                    break;
            }
        }
    }
}
