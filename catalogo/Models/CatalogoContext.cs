using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace catalogo.Models;

public partial class CatalogoContext : DbContext
{
    public CatalogoContext()
    {
    }

    public CatalogoContext(DbContextOptions<CatalogoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       if(!optionsBuilder.IsConfigured) {
           //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
           //        => optionsBuilder.UseSqlServer("Server=DESKTOP-5R3J8IR\\SQLEXPRESS;Initial Catalog=catalogo;integrated security=True; TrustServerCertificate=True");

        }
    }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__clientes__47E34D64DC099BEF");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Email, "UQ__clientes__AB6E61641447199D").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CompraId).HasName("PK__compras__7B94793C68A2B0C0");

            entity.ToTable("compras");

            entity.Property(e => e.CompraId).HasColumnName("compra_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__compras__cliente__4F7CD00D");

            entity.HasOne(d => d.Producto).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__compras__product__5070F446");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__producto__FB5CEEECB769E9B1");

            entity.ToTable("productos");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.ImagenRuta)
                .HasMaxLength(255)
                .HasColumnName("imagen_ruta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
