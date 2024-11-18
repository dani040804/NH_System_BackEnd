﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NH_Sys_Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NH_Sys_Infrastructure.Migrations
{
    [DbContext(typeof(DbDevContext))]
    [Migration("20241116002926_InventoryTables")]
    partial class InventoryTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NH_Sys_Domain.Entities.CategoriaProducto", b =>
                {
                    b.Property<long>("IdCategoriaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IdCategoriaProducto"));

                    b.Property<string>("DescripcionCategoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreCategoriaProducto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCategoriaProducto");

                    b.ToTable("CategoriaProductos");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.ClientesTb", b =>
                {
                    b.Property<long>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_cliente");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdCliente"));

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("correo_electronico");

                    b.Property<string>("Direccion")
                        .HasColumnType("text")
                        .HasColumnName("direccion");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasColumnType("text")
                        .HasColumnName("telefono");

                    b.Property<string>("TipoIdentificacion")
                        .HasColumnType("text")
                        .HasColumnName("tipo_identificacion");

                    b.HasKey("IdCliente")
                        .HasName("clientes_pkey");

                    b.ToTable("clientes_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.DetallefacturaTb", b =>
                {
                    b.Property<long>("IdDetalleFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_detalle_factura");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdDetalleFactura"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer")
                        .HasColumnName("cantidad");

                    b.Property<long?>("FacturaId")
                        .HasColumnType("bigint")
                        .HasColumnName("factura_id");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("precio_unitario");

                    b.Property<long?>("ProductoId")
                        .HasColumnType("bigint")
                        .HasColumnName("producto_id");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("numeric")
                        .HasColumnName("subtotal");

                    b.HasKey("IdDetalleFactura")
                        .HasName("detallefactura_pkey");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("detallefactura_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.FacturasTb", b =>
                {
                    b.Property<long>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_factura");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdFactura"));

                    b.Property<string>("ClaveHacienda")
                        .HasColumnType("text")
                        .HasColumnName("clave_hacienda");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaEmision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_emision")
                        .HasDefaultValueSql("now()");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.HasKey("IdFactura")
                        .HasName("facturas_pkey");

                    b.HasIndex("ClienteId");

                    b.ToTable("facturas_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.InventarioTb", b =>
                {
                    b.Property<long>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_inventario");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdInventario"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("FechaActualización")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("ProductoId")
                        .HasColumnType("bigint")
                        .HasColumnName("producto_id");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("text")
                        .HasColumnName("ubicacion");

                    b.HasKey("IdInventario")
                        .HasName("inventario_pkey");

                    b.HasIndex("ProductoId");

                    b.ToTable("inventario_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.MovimientoInventario", b =>
                {
                    b.Property<long>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IdMovimiento"));

                    b.Property<string>("Almacen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("IdProducto")
                        .HasColumnType("bigint");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("IdProducto");

                    b.ToTable("MovimientosInventario");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.Producto", b =>
                {
                    b.Property<long>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_producto");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdProducto"));

                    b.Property<string>("CodigoProducto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo_producto");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<bool>("DescuentoAplicable")
                        .HasColumnType("boolean");

                    b.Property<string>("Escala")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("IdCategoriaProducto")
                        .HasColumnType("bigint");

                    b.Property<long>("IdProveedor")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric")
                        .HasColumnName("precio");

                    b.Property<decimal>("PrecioCosto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecioDistribuidor")
                        .HasColumnType("numeric");

                    b.HasKey("IdProducto")
                        .HasName("productos_pkey");

                    b.HasIndex("IdCategoriaProducto");

                    b.HasIndex("IdProveedor");

                    b.ToTable("productos_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.Proveedor", b =>
                {
                    b.Property<long>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("IdProveedor"));

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.RecibosTb", b =>
                {
                    b.Property<long>("IdRecibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_recibo");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdRecibo"));

                    b.Property<long?>("FacturaId")
                        .HasColumnType("bigint")
                        .HasColumnName("factura_id");

                    b.Property<DateTime?>("FechaPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_pago")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("metodo_pago");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric")
                        .HasColumnName("monto");

                    b.HasKey("IdRecibo")
                        .HasName("recibos_pkey");

                    b.HasIndex("FacturaId");

                    b.ToTable("recibos_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.UsuariosTb", b =>
                {
                    b.Property<long>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_usuario");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("IdUsuario"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contrasena");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("correo_electronico");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre_usuario");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rol");

                    b.HasKey("IdUsuario")
                        .HasName("usuarios_pkey");

                    b.ToTable("usuarios_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.DetallefacturaTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.FacturasTb", "Factura")
                        .WithMany("DetallefacturaTbs")
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("detallefactura_factura_id_fkey");

                    b.HasOne("NH_Sys_Domain.Entities.Producto", "Producto")
                        .WithMany("DetallefacturaTbs")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("detallefactura_producto_id_fkey");

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.FacturasTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.ClientesTb", "Cliente")
                        .WithMany("FacturasTbs")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("facturas_cliente_id_fkey");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.InventarioTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.Producto", "Producto")
                        .WithMany("InventarioTbs")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("inventario_producto_id_fkey");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.MovimientoInventario", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.Producto", "Producto")
                        .WithMany("MovimientosInventario")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.Producto", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.CategoriaProducto", "CategoriaProducto")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoriaProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NH_Sys_Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProducto");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.RecibosTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.FacturasTb", "Factura")
                        .WithMany("RecibosTbs")
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("recibos_factura_id_fkey");

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.ClientesTb", b =>
                {
                    b.Navigation("FacturasTbs");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.FacturasTb", b =>
                {
                    b.Navigation("DetallefacturaTbs");

                    b.Navigation("RecibosTbs");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.Producto", b =>
                {
                    b.Navigation("DetallefacturaTbs");

                    b.Navigation("InventarioTbs");

                    b.Navigation("MovimientosInventario");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
