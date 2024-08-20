using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PeopleEssence.Entities.TableEntities;

namespace PeopleEssence.Data
{
    public partial class ImageDbContext : DbContext
    {
        public ImageDbContext()
        {
        }

        public ImageDbContext(DbContextOptions<ImageDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<CandidatesDetail> CandidatesDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.77;Initial Catalog=PeopleEssence;Persist Security Info=False;User ID=sa;Password=sa@123;MultipleActiveResultSets=False;Connection Timeout=30;Encrypt=false;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatesDetail>(entity =>
            {
                entity.HasKey(e => e.CandidateDetailsId)
                    .HasName("PK__Candidat__3664EFF43A7AD83D");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesDetails)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Candidate__Candi__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
