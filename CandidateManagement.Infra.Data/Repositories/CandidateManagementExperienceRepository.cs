using CandidateManagement.Domain.Entities;
using CandidateManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Infra.Data.Repositories
{
    public class CandidateManagementExperienceRepository : Repository<CandidateExperience>, ICandidateManagementExperienceRepository
    {
        private readonly CandidateManagementDBContext _context;

        public CandidateManagementExperienceRepository(CandidateManagementDBContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<CandidateExperience> GetAll()
        {
            return _context.Set<CandidateExperience>().AsNoTracking().Distinct();
        }

        public CandidateExperience Get(Guid id)
        {
            return _context.Set<CandidateExperience>().AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

    }
}
