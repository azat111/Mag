using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kurs2.sakila;

public partial class MagazContext : DbContext
{
    public MagazContext()
    {
        Database.EnsureCreated();
      
    }

    public MagazContext(DbContextOptions<MagazContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Заказ> Заказs { get; set; }

    public virtual DbSet<Корзина> Корзинаs { get; set; }

    public virtual DbSet<КорзинаHasТовар> КорзинаHasТоварs { get; set; }

    public virtual DbSet<Пользователь> Пользовательs { get; set; }

    public virtual DbSet<Товар> Товарs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;port=3306;Database=magaz;Uid=root;pwd=azat;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Заказ>(entity =>
        {
            entity.HasKey(e => e.IdЗаказ).HasName("PRIMARY");

            entity.ToTable("заказ");

            entity.HasIndex(e => e.IdПользователя, "id_пользователь_idx");

            entity.Property(e => e.IdЗаказ).HasColumnName("id_заказ");
            entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
            entity.Property(e => e.Адрес).HasMaxLength(200);
            entity.Property(e => e.ОбщаяСтоимость).HasColumnName("Общая стоимость");
            entity.Property(e => e.СпособОплаты)
                .HasMaxLength(200)
                .HasColumnName("Способ оплаты");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_пользователя");
        });

        modelBuilder.Entity<Корзина>(entity =>
        {
            entity.HasKey(e => e.IdКорзина).HasName("PRIMARY");

            entity.ToTable("корзина");

            entity.HasIndex(e => e.IdПользователь, "id_корзина_idx");

            entity.Property(e => e.IdКорзина).HasColumnName("id_корзина");
            entity.Property(e => e.IdПользователь).HasColumnName("пользователь_Id_пользователь");

            entity.HasOne(d => d.ПользовательIdПользовательNavigation).WithMany(p => p.Корзинаs)
                .HasForeignKey(d => d.IdПользователь)
                .HasConstraintName("id_корзина");
        });

        modelBuilder.Entity<КорзинаHasТовар>(entity =>
        {
            entity.HasKey(e => new { e.КорзинаIdКорзина, e.ТоварIdТовар }).HasName("PRIMARY");

            entity.ToTable("корзина_has_товар");

            entity.HasIndex(e => e.КорзинаIdКорзина, "fk_корзина_has_товар_корзина1_idx");

            entity.HasIndex(e => e.ТоварIdТовар, "fk_корзина_has_товар_товар1_idx");

            entity.HasOne(d => d.КорзинаIdКорзинаNavigation).WithMany(p => p.КорзинаHasТоварs)
                .HasForeignKey(d => d.КорзинаIdКорзина)
                .HasConstraintName("fk_корзина_has_товар_корзина1");

            entity.HasOne(d => d.ТоварIdТоварNavigation).WithMany(p => p.КорзинаHasТоварs)
                .HasForeignKey(d => d.ТоварIdТовар)
                .HasConstraintName("fk_корзина_has_товар_товар1");
        });

        modelBuilder.Entity<Пользователь>(entity =>
        {
            entity.HasKey(e => e.IdПользователь).HasName("PRIMARY");

            entity.ToTable("пользователь");

            entity.Property(e => e.IdПользователь).HasColumnName("Id_пользователь");
            entity.Property(e => e.Логин).HasMaxLength(200);
            entity.Property(e => e.Пароль).HasMaxLength(200);
            entity.Property(e => e.Роль).HasMaxLength(200);
        });

        modelBuilder.Entity<Товар>(entity =>
        {
            entity.HasKey(e => e.IdТовар).HasName("PRIMARY");

            entity.ToTable("товар");

            entity.Property(e => e.IdТовар).HasColumnName("id_товар");
            entity.Property(e => e.Категория).HasMaxLength(200);
            entity.Property(e => e.Название).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
