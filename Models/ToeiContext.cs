using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthApi.Models;

public partial class ToeiContext : DbContext
{
    public ToeiContext()
    {
    }

    public ToeiContext(DbContextOptions<ToeiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=172.16.200.202,1434;Database=Toei;Trusted_Connection=false;TrustServerCertificate=true;User=sa;Password=reallyStrongPwd123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
