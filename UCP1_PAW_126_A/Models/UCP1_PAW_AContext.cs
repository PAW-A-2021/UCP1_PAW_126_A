using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_126_A.Models
{
    public partial class UCP1_PAW_AContext : DbContext
    {
        public UCP1_PAW_AContext()
        {
        }

        public UCP1_PAW_AContext(DbContextOptions<UCP1_PAW_AContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admiin> Admiins { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Admiin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admiin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Admiins)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Admiin_User");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Menu");

                entity.Property(e => e.About)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.Product)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Menu_Admiin");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Order");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_Order_Menu");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_User");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
