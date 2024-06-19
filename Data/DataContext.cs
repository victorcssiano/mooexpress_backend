using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using mooexpress.Models;

namespace mooexpress.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacoes> Avaliacoes { get; set; }
        public DbSet<Endereco_entrega> Endereco_Entregas { get; set; }
        public DbSet<Gado> Gados { get; set; }
        /*
        public DbSet<Historico_mensagem> Historico_Mensagens { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        */
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Venda - Endereco_entrega
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Endereco_Entrega)
                .WithOne(e => e.Venda)
                .HasForeignKey<Venda>(v => v.Endereco_EntregaId);

            // Anuncio - Venda
            modelBuilder.Entity<Anuncio>()
                .HasOne(a => a.Venda)
                .WithOne(v => v.Anuncio)
                .HasForeignKey<Venda>(v => v.AnuncioId);

            // Anuncio - Gado
            modelBuilder.Entity<Anuncio>()
                .HasOne(a => a.Gado)
                .WithOne(g => g.Anuncio)
                .HasForeignKey<Anuncio>(a => a.GadoId);

            // Usuario - Anuncio
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Anuncios)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            /* Usuario - Mensagem
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Mensagem)
                .WithOne(m => m.Usuario)
                .HasForeignKey<Mensagem>(m => m.UsuarioId);
            */
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), options =>
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null));
        }

    }
}
