using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace pro8.Models;

public partial class AlmacenContext : DbConText
{
    public AlmacenConText()
    {
    }

    public AlmacenContext(DbContextOptions<AlmacenConText> options)
        : base(options)
    {
    }

    public virtual DbSet <Producto> Productos { get; set; }

    protected override void OnConfiguring(DbConTextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("DESKTOP-U1P0BTP\\SQLEXPRESS\\;Database=Almacen;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}