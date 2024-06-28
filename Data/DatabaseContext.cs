using Fiap.Api.Residuos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Residuos.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<LixeiraModel> Lixeiras { get; set; } 
        public virtual DbSet<MoradorModel> Moradores { get; set; } 
        public virtual DbSet<NotificacaoModel> Notificacoes { get; set; } 


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<LixeiraModel>(entity =>
            {
                entity.ToTable("TBL_LIXEIRA");
                entity.HasKey(e => e.LixeiraId);
                entity.Property(e => e.Endereco).IsRequired();
                entity.Property(e => e.capacidadeFull).IsRequired();
            });

            modelBuilder.Entity<MoradorModel>(entity =>
            {
                entity.ToTable("TBL_MORADOR");
                entity.HasKey(e => e.MoradorId);
                entity.Property(e => e.MoradorName).IsRequired();
                entity.Property(e => e.Telefone).IsRequired();

                entity.HasOne(e => e.Lixeira)
                      .WithMany()
                      .HasForeignKey(e => e.IdLixeira)
                      .IsRequired();
            });

            

            modelBuilder.Entity<NotificacaoModel>(entity =>
            {
                entity.ToTable("TBL_NOTIFICACAO");
                entity.HasKey(e => e.NotificacaoId);
                entity.Property(e => e.NotificacaoDescricao);
                entity.Property(e => e.DataNotificacao).HasColumnType("date");
            }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
