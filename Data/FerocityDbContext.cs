using System;
using System.Collections.Generic;
using Ferocity.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferocity.Data;

public partial class FerocityDbContext : DbContext
{
    public FerocityDbContext(DbContextOptions<FerocityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Talumno> Talumnos { get; set; }

    public virtual DbSet<Tbiometrium> Tbiometria { get; set; }

    public virtual DbSet<Tgasto> Tgastos { get; set; }

    public virtual DbSet<Tkardex> Tkardices { get; set; }

    public virtual DbSet<Tpago> Tpagos { get; set; }

    public virtual DbSet<Tproducto> Tproductos { get; set; }

    public virtual DbSet<Ttipogasto> Ttipogastos { get; set; }

    public virtual DbSet<Tusuario> Tusuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Talumno>(entity =>
        {
            entity.HasKey(e => e.Idalumno).HasName("PRIMARY");

            entity.ToTable("talumnos");

            entity.Property(e => e.Idalumno).HasColumnName("idalumno");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .HasColumnName("codigo");
            entity.Property(e => e.Fechanac)
                .HasColumnType("datetime")
                .HasColumnName("fechanac");
            entity.Property(e => e.Fechaultimopago)
                .HasColumnType("datetime")
                .HasColumnName("fechaultimopago");
            entity.Property(e => e.Fechinscripcion)
                .HasColumnType("datetime")
                .HasColumnName("fechinscripcion");
            entity.Property(e => e.Jiujitsu).HasColumnName("jiujitsu");
            entity.Property(e => e.Kickboxing).HasColumnName("kickboxing");
            entity.Property(e => e.Mma).HasColumnName("mma");
            entity.Property(e => e.Nombres)
                .HasMaxLength(45)
                .HasColumnName("nombres");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.Valorapagar)
                .HasPrecision(8)
                .HasColumnName("valorapagar");
            entity.Property(e => e.Proximopago)
                .HasColumnType("datetime")
                .HasColumnName("proximopago");  
        });

        modelBuilder.Entity<Tbiometrium>(entity =>
        {
            entity.HasKey(e => e.Idbiometria).HasName("PRIMARY");

            entity.ToTable("tbiometria");

            entity.HasIndex(e => e.Idalumno, "alumno_bio_idx");

            entity.Property(e => e.Idbiometria).HasColumnName("idbiometria");
            entity.Property(e => e.Cadera)
                .HasPrecision(8)
                .HasColumnName("cadera");
            entity.Property(e => e.Cintura)
                .HasPrecision(8)
                .HasColumnName("cintura");
            entity.Property(e => e.Cuello)
                .HasPrecision(8)
                .HasColumnName("cuello");
            entity.Property(e => e.Estado).HasMaxLength(45);
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idalumno).HasColumnName("idalumno");
            entity.Property(e => e.Igc)
                .HasPrecision(8)
                .HasColumnName("IGC");
            entity.Property(e => e.Imc)
                .HasPrecision(8)
                .HasColumnName("IMC");
            entity.Property(e => e.Peso)
                .HasPrecision(8)
                .HasColumnName("peso");
            entity.Property(e => e.Talla)
                .HasPrecision(8)
                .HasColumnName("talla");

            entity.HasOne(d => d.IdalumnoNavigation).WithMany(p => p.Tbiometria)
                .HasForeignKey(d => d.Idalumno)
                .HasConstraintName("alumno_bio");
        });

        modelBuilder.Entity<Tgasto>(entity =>
        {
            entity.HasKey(e => e.Igasto).HasName("PRIMARY");

            entity.ToTable("tgastos");

            entity.HasIndex(e => e.Idtipogasto, "tipo_gasto_idx");

            entity.Property(e => e.Igasto).HasColumnName("igasto");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idtipogasto).HasColumnName("idtipogasto");
            entity.Property(e => e.Valor)
                .HasPrecision(8)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdtipogastoNavigation).WithMany(p => p.Tgastos)
                .HasForeignKey(d => d.Idtipogasto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tipo_gasto");
        });

        modelBuilder.Entity<Tkardex>(entity =>
        {
            entity.HasKey(e => e.Idkardex).HasName("PRIMARY");

            entity.ToTable("tkardex");

            entity.HasIndex(e => e.Idproducto, "producto_kardex_idx");

            entity.Property(e => e.Idkardex).HasColumnName("idkardex");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Detalle)
                .HasMaxLength(145)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Precio)
                .HasPrecision(8)
                .HasColumnName("precio");
            entity.Property(e => e.TipoKardex).HasColumnName("tipo_kardex");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Tkardices)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("producto_kardex");
        });

        modelBuilder.Entity<Tpago>(entity =>
        {
            entity.HasKey(e => e.Idtpago).HasName("PRIMARY");

            entity.ToTable("tpagos");

            entity.HasIndex(e => e.Idalumno, "alumno_pago_idx");

            entity.Property(e => e.Idtpago).HasColumnName("idtpago");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idalumno).HasColumnName("idalumno");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasPrecision(8)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdalumnoNavigation).WithMany(p => p.Tpagos)
                .HasForeignKey(d => d.Idalumno)
                .HasConstraintName("alumno_pago");
        });

        modelBuilder.Entity<Tproducto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PRIMARY");

            entity.ToTable("tproductos");

            entity.HasIndex(e => e.Codigo, "codigo_UNIQUE").IsUnique();

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Codigo)
                .HasMaxLength(45)
                .HasColumnName("codigo");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(245)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.Pvp)
                .HasPrecision(8)
                .HasColumnName("pvp");
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(45)
                .HasColumnName("tipo_producto");
        });

        modelBuilder.Entity<Ttipogasto>(entity =>
        {
            entity.HasKey(e => e.Idtipogasto).HasName("PRIMARY");

            entity.ToTable("ttipogastos");

            entity.Property(e => e.Idtipogasto).HasColumnName("idtipogasto");
            entity.Property(e => e.Gasto)
                .HasMaxLength(150)
                .HasColumnName("gasto");
        });

        modelBuilder.Entity<Tusuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");

            entity.ToTable("tusuarios");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(14)
                .HasColumnName("password");
            entity.Property(e => e.Usuario)
                .HasMaxLength(45)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
