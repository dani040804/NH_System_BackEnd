using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NH_Sys_Infrastructure;

public partial class NhSystemDevContext : DbContext
{
    public NhSystemDevContext()
    {
    }

    public NhSystemDevContext(DbContextOptions<NhSystemDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detallefactura> Detallefacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Recibo> Recibos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DB_PSQL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Identificacion).HasColumnName("identificacion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion");
        });

        modelBuilder.Entity<Detallefactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detallefactura_pkey");

            entity.ToTable("detallefactura");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");

            entity.HasOne(d => d.Factura).WithMany(p => p.Detallefacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("detallefactura_factura_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallefacturas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallefactura_producto_id_fkey");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("facturas_pkey");

            entity.ToTable("facturas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ClaveHacienda).HasColumnName("clave_hacienda");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("facturas_cliente_id_fkey");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventario_pkey");

            entity.ToTable("inventario");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("inventario_producto_id_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Recibo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recibos_pkey");

            entity.ToTable("recibos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.Factura).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("recibos_factura_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Contrasena).HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correo_electronico");
            entity.Property(e => e.NombreUsuario).HasColumnName("nombre_usuario");
            entity.Property(e => e.Rol).HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
