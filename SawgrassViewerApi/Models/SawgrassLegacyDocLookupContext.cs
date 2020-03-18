using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SawgrassViewerApi.Models
{
    public partial class SawgrassLegacyDocLookupContext : DbContext
    {
        public SawgrassLegacyDocLookupContext()
        {
        }

        public SawgrassLegacyDocLookupContext(DbContextOptions<SawgrassLegacyDocLookupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AwsPolicyreference> AwsPolicyreference { get; set; }
        public virtual DbSet<ClaimMaster> ClaimMaster { get; set; }
        public virtual DbSet<ClaimXref> ClaimXref { get; set; }
        public virtual DbSet<PolicyMaster> PolicyMaster { get; set; }
        public virtual DbSet<PolicyXref> PolicyXref { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=HPCIServer05;Database=SawgrassLegacyDocLookup;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AwsPolicyreference>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AwsBucketkey).HasColumnType("text");

                entity.Property(e => e.AwsObjectKey).HasColumnType("text");

                entity.Property(e => e.Insuredname).HasColumnType("text");

                entity.Property(e => e.PolicyId).HasColumnType("text");
            });

            modelBuilder.Entity<ClaimMaster>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClaimId)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EffDate).HasColumnType("date");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.InsuredName).HasColumnType("text");

                entity.Property(e => e.LossDate).HasColumnType("date");

                entity.Property(e => e.PolicyId)
                    .HasColumnName("PolicyID")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClaimXref>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClaimXRef");

                entity.Property(e => e.AmazonS32ref)
                    .HasColumnName("AmazonS32Ref")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PolicyMaster>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EffDate).HasColumnType("date");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.InsuredName).HasColumnType("varchar(max)");

                entity.Property(e => e.PolicyId)
                    .HasColumnName("PolicyID")
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<PolicyXref>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PolicyXRef");

                entity.Property(e => e.AmazonS3ref)
                    .HasColumnName("AmazonS3Ref")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DocType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Policy)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
