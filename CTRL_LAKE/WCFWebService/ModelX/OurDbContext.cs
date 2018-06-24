using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WCFWebService
{
    /*
     * Aggiungere System.Data.Entity (se non installato installarlo con nuget)
     * 
     */
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }

        /*
         * CHE E' STA ROBA?
         * Quando viene lanciato per la prima volta il programma, viene inizializzato il db, se poi vengono fatti dei cambiamenti al model
         * si crea inconsistenza tra le parti, pertanto è necessario disabilitare l' inizializzazione univoca ed eseguirla "fresca" tutte le volte
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OurDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}