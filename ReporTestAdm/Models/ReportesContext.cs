using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReporTestAdm.Models;

public partial class ReportesContext : DbContext
{
    public ReportesContext()
    {
    }

    public ReportesContext(DbContextOptions<ReportesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.Folio).HasName("PK__REPORTE__E8F12C9E515708C3");

            entity.ToTable("REPORTE");

            entity.Property(e => e.Folio).HasColumnName("folio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estatus");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Fecha_autorizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_autorizacion");
            entity.Property(e => e.Usuario_gestiona)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario_gestiona");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_IDUSUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF976E59CAEE");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E616466373B0C").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Puesto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("puesto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
