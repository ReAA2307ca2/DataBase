using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database.Models;

public partial class ReAaContext : DbContext
{
    public ReAaContext()
    {
    }

    public ReAaContext(DbContextOptions<ReAaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Автор> Авторs { get; set; }

    public virtual DbSet<АвторыКниг> АвторыКнигs { get; set; }

    public virtual DbSet<Библиотекарь> Библиотекарьs { get; set; }

    public virtual DbSet<Жанр> Жанрs { get; set; }

    public virtual DbSet<ЖанрыКниг> ЖанрыКнигs { get; set; }

    public virtual DbSet<Издатель> Издательs { get; set; }

    public virtual DbSet<Книга> Книгаs { get; set; }

    public virtual DbSet<Комната> Комнатаs { get; set; }

    public virtual DbSet<Операция> Операцияs { get; set; }

    public virtual DbSet<Полка> Полкаs { get; set; }

    public virtual DbSet<Ряд> Рядs { get; set; }

    public virtual DbSet<Сектор> Секторs { get; set; }

    public virtual DbSet<Стеллаж> Стеллажs { get; set; }

    public virtual DbSet<Формуляр> Формулярs { get; set; }

    public virtual DbSet<Читатель> Читательs { get; set; }

    public virtual DbSet<ЭкземплярКниги> ЭкземплярКнигиs { get; set; }

    public virtual DbSet<Ячейка> Ячейкаs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DBSRV\\vip2024;Database=ReAA;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Автор>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Автор__3214EC27A8EE7346");

            entity.ToTable("Автор");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Имя)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<АвторыКниг>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Авторы_к__3214EC2795E7F1F2");

            entity.ToTable("Авторы_книг");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkАвтора).HasColumnName("FK_Автора");
            entity.Property(e => e.FkКниги).HasColumnName("FK_Книги");

            entity.HasOne(d => d.FkАвтораNavigation).WithMany(p => p.АвторыКнигs)
                .HasForeignKey(d => d.FkАвтора)
                .HasConstraintName("FK__Авторы_кн__FK_Ав__4B422AD5");

            entity.HasOne(d => d.FkКнигиNavigation).WithMany(p => p.АвторыКнигs)
                .HasForeignKey(d => d.FkКниги)
                .HasConstraintName("FK__Авторы_кн__FK_Кн__4A4E069C");
        });

        modelBuilder.Entity<Библиотекарь>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Библиоте__3214EC27E3DD5427");

            entity.ToTable("Библиотекарь");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Имя)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Жанр>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Жанр__3214EC27F89E5D7C");

            entity.ToTable("Жанр");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ЖанрыКниг>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Жанры_кн__3214EC2796D6243B");

            entity.ToTable("Жанры_книг");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkЖанра).HasColumnName("FK_Жанра");
            entity.Property(e => e.FkКниги).HasColumnName("FK_Книги");

            entity.HasOne(d => d.FkЖанраNavigation).WithMany(p => p.ЖанрыКнигs)
                .HasForeignKey(d => d.FkЖанра)
                .HasConstraintName("FK__Жанры_кни__FK_Жа__4959E263");

            entity.HasOne(d => d.FkКнигиNavigation).WithMany(p => p.ЖанрыКнигs)
                .HasForeignKey(d => d.FkКниги)
                .HasConstraintName("FK__Жанры_кни__FK_Кн__4865BE2A");
        });

        modelBuilder.Entity<Издатель>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Издатель__3214EC27F44AE5DB");

            entity.ToTable("Издатель");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Книга>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Книга__3214EC27C214E755");

            entity.ToTable("Книга");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkАвтора).HasColumnName("FK_Автора");
            entity.Property(e => e.FkЖанра).HasColumnName("FK_Жанра");
            entity.Property(e => e.FkИздателя).HasColumnName("FK_Издателя");
            entity.Property(e => e.FkЭкземпляра).HasColumnName("FK_экземпляра");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FkИздателяNavigation).WithMany(p => p.Книгаs)
                .HasForeignKey(d => d.FkИздателя)
                .HasConstraintName("FK__Книга__FK_Издате__467D75B8");
        });

        modelBuilder.Entity<Комната>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Комната__3214EC27DE6DB877");

            entity.ToTable("Комната");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Операция>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Операция__3214EC276384D9B1");

            entity.ToTable("Операция");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Полка>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Полка__3214EC277381E80B");

            entity.ToTable("Полка");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkСтеллажа).HasColumnName("FK_Стеллажа");

            entity.HasOne(d => d.FkСтеллажаNavigation).WithMany(p => p.Полкаs)
                .HasForeignKey(d => d.FkСтеллажа)
                .HasConstraintName("FK__Полка__FK_Стелла__50FB042B");
        });

        modelBuilder.Entity<Ряд>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ряд__3214EC27BB81352C");

            entity.ToTable("Ряд");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkСектора).HasColumnName("FK_Сектора");

            entity.HasOne(d => d.FkСектораNavigation).WithMany(p => p.Рядs)
                .HasForeignKey(d => d.FkСектора)
                .HasConstraintName("FK__Ряд__FK_Сектора__4E1E9780");
        });

        modelBuilder.Entity<Сектор>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Сектор__3214EC2718CA62FE");

            entity.ToTable("Сектор");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkКомнаты).HasColumnName("FK_Комнаты");

            entity.HasOne(d => d.FkКомнатыNavigation).WithMany(p => p.Секторs)
                .HasForeignKey(d => d.FkКомнаты)
                .HasConstraintName("FK__Сектор__FK_Комна__4D2A7347");
        });

        modelBuilder.Entity<Стеллаж>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Стеллаж__3214EC2798871241");

            entity.ToTable("Стеллаж");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkРяда).HasColumnName("FK_Ряда");

            entity.HasOne(d => d.FkРядаNavigation).WithMany(p => p.Стеллажs)
                .HasForeignKey(d => d.FkРяда)
                .HasConstraintName("FK__Стеллаж__FK_Ряда__4F12BBB9");
        });

        modelBuilder.Entity<Формуляр>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Формуляр__3214EC2743AFD1FB");

            entity.ToTable("Формуляр");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkБиблиотекаря).HasColumnName("FK_Библиотекаря");
            entity.Property(e => e.FkБилета).HasColumnName("FK_Билета");
            entity.Property(e => e.FkКниги).HasColumnName("FK_Книги");
            entity.Property(e => e.FkОперации).HasColumnName("FK_Операции");
            entity.Property(e => e.Дата).HasColumnType("datetime");

            entity.HasOne(d => d.FkБиблиотекаряNavigation).WithMany(p => p.Формулярs)
                .HasForeignKey(d => d.FkБиблиотекаря)
                .HasConstraintName("FK__Формуляр__FK_Биб__42ACE4D4");

            entity.HasOne(d => d.FkБилетаNavigation).WithMany(p => p.Формулярs)
                .HasForeignKey(d => d.FkБилета)
                .HasConstraintName("FK__Формуляр__FK_Бил__41B8C09B");

            entity.HasOne(d => d.FkКнигиNavigation).WithMany(p => p.Формулярs)
                .HasForeignKey(d => d.FkКниги)
                .HasConstraintName("FK__Формуляр__FK_Кни__40C49C62");

            entity.HasOne(d => d.FkОперацииNavigation).WithMany(p => p.Формулярs)
                .HasForeignKey(d => d.FkОперации)
                .HasConstraintName("FK__Формуляр__FK_Опе__43A1090D");
        });

        modelBuilder.Entity<Читатель>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Читатель__3214EC2701E7D3F0");

            entity.ToTable("Читатель");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Имя)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ЭкземплярКниги>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Экземпля__3214EC27EF10D898");

            entity.ToTable("Экземпляр_книги");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkОригинала).HasColumnName("FK_оригинала");
            entity.Property(e => e.FkЯчейки).HasColumnName("FK_Ячейки");

            entity.HasOne(d => d.FkОригиналаNavigation).WithMany(p => p.ЭкземплярКнигиs)
                .HasForeignKey(d => d.FkОригинала)
                .HasConstraintName("FK__Экземпляр__FK_ор__55BFB948");

            entity.HasOne(d => d.FkЯчейкиNavigation).WithMany(p => p.ЭкземплярКнигиs)
                .HasForeignKey(d => d.FkЯчейки)
                .HasConstraintName("FK__Экземпляр__FK_Яч__4C364F0E");
        });

        modelBuilder.Entity<Ячейка>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ячейка__3214EC27ECD5B9A6");

            entity.ToTable("Ячейка");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkПолки).HasColumnName("FK_Полки");

            entity.HasOne(d => d.FkПолкиNavigation).WithMany(p => p.Ячейкаs)
                .HasForeignKey(d => d.FkПолки)
                .HasConstraintName("FK__Ячейка__FK_Полки__51EF2864");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
