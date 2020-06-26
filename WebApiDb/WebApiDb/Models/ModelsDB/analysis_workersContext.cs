using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiDb.Models
{
    public partial class analysis_workersContext : DbContext
    {
        public analysis_workersContext()
        {
        }

        public analysis_workersContext(DbContextOptions<analysis_workersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Work> Work { get; set; }
        public virtual DbSet<WorkEmployee> WorkEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=analysis_workers;uid=root;pwd=root", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.IdDepartment)
                    .HasName("PRIMARY");

                entity.ToTable("departments");

                entity.Property(e => e.IdDepartment)
                    .HasColumnName("Id_department")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.Deportamen)
                    .HasName("_idx");

                entity.HasIndex(e => e.Work)
                    .HasName(" _idx");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_employee");

                entity.Property(e => e.Deportamen).HasColumnType("mediumint unsigned");

                entity.Property(e => e.Experience)
                    .HasColumnType("tinyint(2) unsigned zerofill")
                    .HasDefaultValueSql("'00'");

                entity.Property(e => e.MidleName)
                    .HasColumnName("Midle_name")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(35)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Work).HasColumnType("mediumint unsigned");

                entity.HasOne(d => d.DeportamenNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Deportamen)
                    .HasConstraintName("Depart");

                entity.HasOne(d => d.WorkNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Work)
                    .HasConstraintName("Work");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(e => e.IdWork)
                    .HasName("PRIMARY");

                entity.ToTable("work");

                entity.Property(e => e.IdWork)
                    .HasColumnName("Id_work")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<WorkEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmploye)
                    .HasName("PRIMARY");

                entity.ToTable("work_employee");

                entity.Property(e => e.IdEmploye)
                    .HasColumnName("Id_employe")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PlanFact)
                    .HasColumnName("Plan_fact")
                    .HasColumnType("varchar(65)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdEmployeNavigation)
                    .WithOne(p => p.WorkEmployee)
                    .HasForeignKey<WorkEmployee>(d => d.IdEmploye)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
