using CandidateManagement.Domain.Entities;
using CandidateManagement.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Infra.Data
{
    public class CandidateManagementDBContext : DbContext
    {

        public CandidateManagementDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CandidateManagementMap());

            modelBuilder.ApplyConfiguration(new CandidateManagementExperienceMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                          .UseSqlServer(@"Server=localhost,1433;Database=CandidateManagement;User Id = sa;Password=dba(!)12345678;MultipleActiveResultSets=true;");
        }

    }
}
