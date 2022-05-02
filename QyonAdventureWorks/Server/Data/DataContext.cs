namespace QyonAdventureWorks.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<CompetidorModel> Competidores { get; set; }
        public DbSet<HistoricoModel> Historicos { get; set; }
        public DbSet<PistaModel> Pistas { get; set; }
    }
}
