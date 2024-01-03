using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CProd;

public partial class PostgresContext : DbContext
{
    public PostgresContext(){
    }
    
    public PostgresContext(DbContextOptions<PostgresContext> options): base(options){
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonAnimal> PersonAnimals { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("animal_pkey");

            entity.ToTable("animal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_pkey");

            entity.ToTable("car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coast)
                .ValueGeneratedOnAdd()
                .HasColumnName("coast");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .HasColumnName("model");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Timebuy)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timebuy");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");
            entity.Property(e => e.Wallet).HasColumnName("wallet");
        });

        modelBuilder.Entity<PersonAnimal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("person_animal");

            entity.Property(e => e.Idanimal).HasColumnName("idanimal");
            entity.Property(e => e.Idperson).HasColumnName("idperson");

            entity.HasOne(d => d.IdanimalNavigation).WithMany()
                .HasForeignKey(d => d.Idanimal)
                .HasConstraintName("person_animal_idanimal_fkey");

            entity.HasOne(d => d.IdpersonNavigation).WithMany()
                .HasForeignKey(d => d.Idperson)
                .HasConstraintName("person_animal_idperson_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(50)
                .HasColumnName("password_user");
            entity.Property(e => e.RoleUser)
                .HasMaxLength(50)
                .HasColumnName("role_user");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
