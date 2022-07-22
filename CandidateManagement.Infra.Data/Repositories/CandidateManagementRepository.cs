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
    public class CandidateManagementRepository : Repository<Candidate>, ICandidateManagementRepository
    {
        private readonly CandidateManagementDBContext _context;

        public CandidateManagementRepository(CandidateManagementDBContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Candidate> GetAll()
        {
            return _context.Set<Candidate>().AsNoTracking().Include(x => x.CandidateExperiences).ToList();
        }

        public Candidate Get(Guid id)
        {

            return _context.Set<Candidate>().AsNoTracking().Where(c => c.Id == id).Include(x => x.CandidateExperiences).FirstOrDefault();
        }


    }
}
