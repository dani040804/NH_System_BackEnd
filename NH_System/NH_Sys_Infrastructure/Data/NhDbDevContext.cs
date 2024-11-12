using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NH_Sys_Domain.Entities;

namespace NH_Sys_Infrastructure.Data;

public partial class DbDevContext : DbContext
{
    public DbDevContext()
    {
    }

    public DbDevContext(DbContextOptions<DbDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientesTb> ClientesTbs { get; set; }

    public virtual DbSet<DetallefacturaTb> DetallefacturaTbs { get; set; }

    public virtual DbSet<FacturasTb> FacturasTbs { get; set; }

    public virtual DbSet<InventarioTb> InventarioTbs { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<RecibosTb> RecibosTbs { get; set; }

    public virtual DbSet<UsuariosTb> UsuariosTbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=NH_DB_Dev;Username=danieladmin;Password=JDvo0408.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientesTb>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");

            entity.ToTable("clientes_tb");

            entity.Property(e => e.IdCliente)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_cliente");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Identificacion).HasColumnName("identificacion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion");
        });

        modelBuilder.Entity<DetallefacturaTb>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura).HasName("detallefactura_pkey");

            entity.ToTable("detallefactura_tb");

            entity.Property(e => e.IdDetalleFactura)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_detalle_factura");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetallefacturaTbs)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("detallefactura_factura_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallefacturaTbs)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallefactura_producto_id_fkey");
        });

        modelBuilder.Entity<FacturasTb>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("facturas_pkey");

            entity.ToTable("facturas_tb");

            entity.Property(e => e.IdFactura)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_factura");
            entity.Property(e => e.ClaveHacienda).HasColumnName("clave_hacienda");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.FacturasTbs)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("facturas_cliente_id_fkey");
        });

        modelBuilder.Entity<InventarioTb>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("inventario_pkey");

            entity.ToTable("inventario_tb");

            entity.Property(e => e.IdInventario)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_inventario");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");

            entity.HasOne(d => d.Producto).WithMany(p => p.InventarioTbs)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("inventario_producto_id_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("productos_pkey");

            entity.ToTable("productos_tb");

            entity.Property(e => e.IdProducto)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_producto");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<RecibosTb>(entity =>
        {
            entity.HasKey(e => e.IdRecibo).HasName("recibos_pkey");

            entity.ToTable("recibos_tb");

            entity.Property(e => e.IdRecibo)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_recibo");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.Factura).WithMany(p => p.RecibosTbs)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("recibos_factura_id_fkey");
        });

        modelBuilder.Entity<UsuariosTb>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios_tb");

            entity.Property(e => e.IdUsuario)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena).HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico).HasColumnName("correo_electronico");
            entity.Property(e => e.NombreUsuario).HasColumnName("nombre_usuario");
            entity.Property(e => e.Rol).HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
