using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaGE.Models;

public partial class SistemaGeContext : DbContext
{
    public SistemaGeContext()
    {
    }

    public SistemaGeContext(DbContextOptions<SistemaGeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvAlmacen> InvAlmacens { get; set; }

    public virtual DbSet<InvArticulo> InvArticulos { get; set; }

    public virtual DbSet<InvArticuloAlmacen> InvArticuloAlmacens { get; set; }

    public virtual DbSet<InvArticuloSuplidor> InvArticuloSuplidors { get; set; }

    public virtual DbSet<InvSuplidor> InvSuplidors { get; set; }

    public virtual DbSet<InvTipoDocumento> InvTipoDocumentos { get; set; }

    public virtual DbSet<InvUbicacion> InvUbicacions { get; set; }

    public virtual DbSet<InvUnidade> InvUnidades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvAlmacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK__INV_Alma__5FC485CFE22A456A");

            entity.ToTable("INV_Almacen");

            entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.IdTipoAlmacen).HasColumnName("idTipoAlmacen");
        });

        modelBuilder.Entity<InvArticulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK__INV_Arti__AABB7422B9F5E0D3");

            entity.ToTable("INV_Articulo");

            entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdClase).HasColumnName("idClase");
            entity.Property(e => e.IdFabricante).HasColumnName("idFabricante");
            entity.Property(e => e.IdUnidadAdquisicion).HasColumnName("idUnidadAdquisicion");
            entity.Property(e => e.IdUnidadVenta).HasColumnName("idUnidadVenta");
            entity.Property(e => e.RegistroSanitario).HasMaxLength(50);
        });

        modelBuilder.Entity<InvArticuloAlmacen>(entity =>
        {
            entity.HasKey(e => e.IdArticuloAlmacen).HasName("PK__INV_Arti__2F40D14ED86D6597");

            entity.ToTable("INV_ArticuloAlmacen");

            entity.Property(e => e.IdArticuloAlmacen).HasColumnName("idArticuloAlmacen");
            entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");
            entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");
            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.InvArticuloAlmacens)
                .HasForeignKey(d => d.IdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_Artic__idAlm__5CD6CB2B");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.InvArticuloAlmacens)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_Artic__idArt__5BE2A6F2");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.InvArticuloAlmacens)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_Artic__idUbi__5DCAEF64");
        });

        modelBuilder.Entity<InvArticuloSuplidor>(entity =>
        {
            entity.HasKey(e => e.IdArticuloSuplidor).HasName("PK__INV_Arti__69386911BED42FF1");

            entity.ToTable("INV_ArticuloSuplidor");

            entity.Property(e => e.IdArticuloSuplidor).HasColumnName("idArticuloSuplidor");
            entity.Property(e => e.CodigoArticulo).HasMaxLength(50);
            entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");
            entity.Property(e => e.IdSuplidor).HasColumnName("idSuplidor");
            entity.Property(e => e.MargenBeneficio).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioVentaMaximo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioVentaMayor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioVentaMinimo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UltimoPrecio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnidadOferta).HasMaxLength(50);

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.InvArticuloSuplidors)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_Artic__idArt__5812160E");

            entity.HasOne(d => d.IdSuplidorNavigation).WithMany(p => p.InvArticuloSuplidors)
                .HasForeignKey(d => d.IdSuplidor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INV_Artic__idSup__59063A47");
        });

        modelBuilder.Entity<InvSuplidor>(entity =>
        {
            entity.HasKey(e => e.IdSuplidor).HasName("PK__INV_Supl__1E24B307B9CA23EE");

            entity.ToTable("INV_Suplidor");

            entity.Property(e => e.IdSuplidor).HasColumnName("idSuplidor");
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.IdTipoIdentificacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idTipoIdentificacion");
            entity.Property(e => e.IdTipoSuplidor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idTipoSuplidor");
            entity.Property(e => e.Identificacion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.PersonaContacto).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<InvTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__INV_Tipo__61FDF9F5ACDA8F4D");

            entity.ToTable("INV_TipoDocumento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Efecto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<InvUbicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__INV_Ubic__174D150E74A0DBFF");

            entity.ToTable("INV_Ubicacion");

            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        modelBuilder.Entity<InvUnidade>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("PK__INV_Unid__34C1E8D704E87FB7");

            entity.ToTable("INV_Unidades");

            entity.Property(e => e.IdUnidad).HasColumnName("idUnidad");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
