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
    [Migration("20241104222414_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NH_Sys_Domain.Entities.ClientesTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.HasKey("Id")
                        .HasName("clientes_pkey");

                    b.ToTable("clientes_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.DetallefacturaTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.HasKey("Id")
                        .HasName("detallefactura_pkey");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("detallefactura_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.FacturasTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.HasKey("Id")
                        .HasName("facturas_pkey");

                    b.HasIndex("ClienteId");

                    b.ToTable("facturas_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.InventarioTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer")
                        .HasColumnName("cantidad");

                    b.Property<long?>("ProductoId")
                        .HasColumnType("bigint")
                        .HasColumnName("producto_id");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("text")
                        .HasColumnName("ubicacion");

                    b.HasKey("Id")
                        .HasName("inventario_pkey");

                    b.HasIndex("ProductoId");

                    b.ToTable("inventario_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.ProductosTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("CodigoProducto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("codigo_producto");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric")
                        .HasColumnName("precio");

                    b.HasKey("Id")
                        .HasName("productos_pkey");

                    b.ToTable("productos_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.RecibosTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.HasKey("Id")
                        .HasName("recibos_pkey");

                    b.HasIndex("FacturaId");

                    b.ToTable("recibos_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.UsuariosTb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

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

                    b.HasKey("Id")
                        .HasName("usuarios_pkey");

                    b.ToTable("usuarios_tb", (string)null);
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.DetallefacturaTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.FacturasTb", "Factura")
                        .WithMany("DetallefacturaTbs")
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("detallefactura_factura_id_fkey");

                    b.HasOne("NH_Sys_Domain.Entities.ProductosTb", "Producto")
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
                    b.HasOne("NH_Sys_Domain.Entities.ProductosTb", "Producto")
                        .WithMany("InventarioTbs")
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("inventario_producto_id_fkey");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("NH_Sys_Domain.Entities.RecibosTb", b =>
                {
                    b.HasOne("NH_Sys_Domain.Entities.FacturasTb", "Factura")
                        .WithMany("RecibosTbs")
                        .HasForeignKey("FacturaId")
                        .HasConstraintName("recibos_factura_id_fkey");

                    b.Navigation("Factura");
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

            modelBuilder.Entity("NH_Sys_Domain.Entities.ProductosTb", b =>
                {
                    b.Navigation("DetallefacturaTbs");

                    b.Navigation("InventarioTbs");
                });
#pragma warning restore 612, 618
        }
    }
}
