using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWeb.Models;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext()
    {
    }

    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-POJ0MVA\\SQLEXPRESS;Database=Proyecto;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.ApellidoDelCliente).HasMaxLength(50);
            entity.Property(e => e.NombreDelCliente).HasMaxLength(50);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.DescripcionDelProducto).HasMaxLength(50);
            entity.Property(e => e.IdClientes).HasColumnName("Id_Clientes");
            entity.Property(e => e.NombreDelProducto).HasMaxLength(50);

            entity.HasOne(d => d.IdClientesNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdClientes)
                .HasConstraintName("FK_Productos_Clientes");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.Property(e => e.IdClientes).HasColumnName("Id_Clientes");
            entity.Property(e => e.IdProductos).HasColumnName("Id_Productos");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("FK_Ventas_Productos");
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.ToTable("VentaDetalle");

            entity.Property(e => e.CantidadDeLaCompra).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IdProductos).HasColumnName("Id_Productos");
            entity.Property(e => e.IdVentas).HasColumnName("Id_Ventas");
            entity.Property(e => e.PrecioDeLaCompra).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdVentasNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdVentas)
                .HasConstraintName("FK_VentaDetalle_Ventas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
