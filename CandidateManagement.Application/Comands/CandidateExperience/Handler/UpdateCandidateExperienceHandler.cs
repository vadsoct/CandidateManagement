using CandidateManagement.Application.Comands.Requests;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Comands.Candidate.Handler
{
    public class UpdateCandidateExperienceHandler : IRequestHandler<UpdateCandidateExperienceRequest, bool>
    {
        private readonly ICandidateManagementExperienceRepository _candidateManagementExperienceRepository;

        public UpdateCandidateExperienceHandler(ICandidateManagementExperienceRepository candidateExperienceRepository)
        {
            this._candidateManagementExperienceRepository = candidateExperienceRepository;
        }

        public Task<bool> Handle(UpdateCandidateExperienceRequest request, CancellationToken cancellationToken)
        {
            var candidateExperience = _candidateManagementExperienceRepository.Get(request.Id);

            if (candidateExperience == null)
                return Task.FromResult(false);

            var candidateExperienceUpdated =
                new CandidateExperience(request.Id,
                                                                request.Company,
                                                                request.Job,
                                                                request.Description,
                                                                request.Salary,
                                                                request.BeginDate,
                                                                request.EndDate,
                                                                candidateExperience.InsertDate,
                                                                candidateExperience.CandidateId);

            _candidateManagementExperienceRepository.Update(candidateExperienceUpdated);

            return Task.FromResult(true);
        }

    }
}
