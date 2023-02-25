using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DigiProPruebaTecnicaContext : DbContext
{
    public DigiProPruebaTecnicaContext()
    {
    }

    public DigiProPruebaTecnicaContext(DbContextOptions<DigiProPruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<MateriasAsignadasAlumno> MateriasAsignadasAlumnos { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= DigiProPruebaTecnica; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumno__460B4740688F133F");

            entity.ToTable("Alumno");

            entity.Property(e => e.Amaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AMaterno");
            entity.Property(e => e.Apaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APaterno");
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MateriasAsignadasAlumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoMateria).HasName("PK__Materias__E13EDA3708E278B5");

            entity.ToTable("MateriasAsignadasAlumno");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.MateriasAsignadasAlumnos)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__MateriasA__IdAlu__173876EA");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.MateriasAsignadasAlumnos)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__MateriasA__IdMat__182C9B23");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__EC1746707912A4F6");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97CE910FB0");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A1961B30465").IsUnique();

            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
