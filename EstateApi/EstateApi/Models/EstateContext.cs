using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstateApi.Models
{
    public partial class EstateContext : DbContext
    {
        public EstateContext()
        {
        }

        public EstateContext(DbContextOptions<EstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EsateLoging> EsateLoging { get; set; }
        public virtual DbSet<Estate> Estate { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EsateLoging>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogExeption).HasMaxLength(50);

                entity.Property(e => e.LogTable).HasMaxLength(100);
            });

            modelBuilder.Entity<Estate>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EstateName).HasMaxLength(100);

                entity.Property(e => e.EstateNumber).HasMaxLength(50);

                entity.Property(e => e.Orientedstate).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            });
        }
    }
}
