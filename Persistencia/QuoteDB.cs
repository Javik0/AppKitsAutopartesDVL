using Microsoft.EntityFrameworkCore;
using Modelos.Quote;

namespace Persistencia
{
    public class QuoteDB : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<AltParte> altPartes { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Kit> kits { get; set; }
        public DbSet<KitPart> kitParts { get; set; }
        public DbSet<Parte> partes { get; set; }
        public DbSet<Quote> quotes { get; set; }
        public DbSet<QuotePart> quoteParts { get; set; }

        public QuoteDB() : base()
        {

        }

        public QuoteDB(DbContextOptions<QuoteDB> opciones) : base(opciones)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                QuoteConfig.ContextOptions(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<AltParte>()
                .HasKey(alt => new 
                { 
                    alt.ParteId, 
                    alt.ParteAlternaId
                }); 

            model.Entity<AltParte>()
                .HasOne(part => part.Parte)
                .WithMany(part => part.altPartes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(parte => parte.ParteId);


            model.Entity<KitPart>()
                .HasKey(kitp => new 
                { 
                    kitp.KitId, 
                    kitp.ParteId 
                });
              
            model.Entity<KitPart>()
                .HasOne(kpart => kpart.Kit)
                .WithMany(kit => kit.KitParts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(kpart => kpart.KitId);

            model.Entity<QuotePart>()
                .HasOne(quoteP => quoteP.Quote)
                .WithMany(quote => quote.QuoteParts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(quoteP => quoteP.QuoteId);

            model.Entity<QuotePart>()
                .HasOne(quote => quote.Parte);
            model.Entity<QuotePart>()
                .HasOne(quote => quote.AltParte);
        }
    }
}
