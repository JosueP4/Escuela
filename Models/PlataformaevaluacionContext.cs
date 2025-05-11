using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlataformaEvaluacion.Models;

public partial class PlataformaevaluacionContext : DbContext
{
    public PlataformaevaluacionContext()
    {
    }

    public PlataformaevaluacionContext(DbContextOptions<PlataformaevaluacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Examene> Examenes { get; set; }

    public virtual DbSet<Incripcione> Incripciones { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Initial Catalog= PLATAFORMAEVALUACION; Integrated Security = true;TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CURSOS__3214EC0735830693");

            entity.ToTable("CURSOS");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTUDIAN__3214EC076EC90C8F");

            entity.ToTable("ESTUDIANTES");

            entity.Property(e => e.Correo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Examene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EXAMENES__3214EC0787E7E9A6");

            entity.ToTable("EXAMENES");

            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.Curso).WithMany(p => p.Examenes)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__EXAMENES__CursoI__5AEE82B9");
        });

        modelBuilder.Entity<Incripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INCRIPCI__3214EC074A23BDE7");

            entity.ToTable("INCRIPCIONES");

            entity.Property(e => e.FechaIncripcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Curso).WithMany(p => p.Incripciones)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__INCRIPCIO__Curso__4E88ABD4");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Incripciones)
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__INCRIPCIO__Estud__4D94879B");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PREGUNTA__3214EC07B902F9A5");

            entity.ToTable("PREGUNTAS");

            entity.Property(e => e.Opciones)
                .HasMaxLength(10)
                .HasColumnName("opciones");
            entity.Property(e => e.Pregunta1)
                .HasMaxLength(100)
                .HasColumnName("Pregunta");
            entity.Property(e => e.RepuestaCorrecta).HasMaxLength(20);

            entity.HasOne(d => d.Examen).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.ExamenId)
                .HasConstraintName("FK__PREGUNTAS__Exame__5DCAEF64");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESULTAD__3214EC0708828EE6");

            entity.ToTable("RESULTADOS");

            entity.Property(e => e.FechaPresentacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__RESULTADO__Estud__628FA481");

            entity.HasOne(d => d.Examen).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.ExamenId)
                .HasConstraintName("FK__RESULTADO__Exame__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
