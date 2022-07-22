using CandidateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Domain.Interfaces
{
    public interface ICandidateManagementExperienceRepository : IRepository<CandidateExperience>
    {
        CandidateExperience Get(Guid id);

        IEnumerable<CandidateExperience> GetAll();
    }
}
