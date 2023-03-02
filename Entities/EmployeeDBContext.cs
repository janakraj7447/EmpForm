using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmpForm.Entities;

public partial class EmployeeDBContext : DbContext
{
    public EmployeeDBContext()
    {
    }

    public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
        : base(options)
    {
    }

  
    public virtual DbSet<EmployeeForm> EmployeeForms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.2.30;Database=Testing_JanakRaj;User ID=JanakRaj;Password=AqdAFS3dZBcXbYqq;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

       
        modelBuilder.Entity<EmployeeForm>(entity =>
        {
            entity.ToTable("Employee_Form");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
