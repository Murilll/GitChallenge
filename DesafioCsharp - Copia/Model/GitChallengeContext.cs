using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesafioCsharp.Model;

public partial class GitChallengeContext : DbContext
{
    public GitChallengeContext()
    {
    }

    public GitChallengeContext(DbContextOptions<GitChallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FilesGit> FilesGits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013F\\SQLEXPRESS;Initial Catalog=GitChallenge;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilesGit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FilesGit__3214EC27421F63D4");

            entity.ToTable("FilesGit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FileAddress).IsUnicode(false);
            entity.Property(e => e.FileNameS)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
