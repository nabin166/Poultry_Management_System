using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PoultryVersion.Models
{
    public partial class PoultryUpdatedContext : DbContext
    {
      //  public PoultryUpdatedContext()
        //{
        //}

        public PoultryUpdatedContext(DbContextOptions<PoultryUpdatedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TblDisease> TblDiseases { get; set; } = null!;
        public virtual DbSet<TblPoultryFarm> TblPoultryFarms { get; set; } = null!;
        public virtual DbSet<TblProduction> TblProductions { get; set; } = null!;
        public virtual DbSet<TblTreatment> TblTreatments { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblVaccine> TblVaccines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-3S3KF7F;Database=PoultryUpdated;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Roles)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDisease>(entity =>
            {
                entity.ToTable("tblDisease");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiseaseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Poultry)
                    .WithMany(p => p.TblDiseases)
                    .HasForeignKey(d => d.PoultryId)
                    .HasConstraintName("FK_tblDisease_tblPoultryFarm");
            });

            modelBuilder.Entity<TblPoultryFarm>(entity =>
            {
                entity.ToTable("tblPoultryFarm");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPoultryFarms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblPoultryFarm_tblUser");
            });

            modelBuilder.Entity<TblProduction>(entity =>
            {
                entity.ToTable("tblProduction");

                entity.Property(e => e.EggType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Poultry)
                    .WithMany(p => p.TblProductions)
                    .HasForeignKey(d => d.PoultryId)
                    .HasConstraintName("FK_tblProduction_tblPoultryFarm");
            });

            modelBuilder.Entity<TblTreatment>(entity =>
            {
                entity.ToTable("tblTreatment");

                entity.Property(e => e.CheckedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Medicine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.TblTreatments)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK_tblTreatment_tblDisease");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tblUser_Role");
            });

            modelBuilder.Entity<TblVaccine>(entity =>
            {
                entity.ToTable("tblVaccine");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Poultry)
                    .WithMany(p => p.TblVaccines)
                    .HasForeignKey(d => d.PoultryId)
                    .HasConstraintName("FK_tblVaccine_tblPoultryFarm");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
