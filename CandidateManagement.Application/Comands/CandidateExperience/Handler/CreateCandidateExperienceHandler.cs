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

namespace CandidateManagement.Application.Comands.Handler
{
    public class CreateCandidateExperienceHandler : IRequestHandler<CreateCandidateExperienceRequest, bool>
    {
        private readonly ICandidateManagementExperienceRepository _candidateManagementExperienceRepository;
        private readonly ICandidateManagementRepository _candidateManagementRepository;

        public CreateCandidateExperienceHandler(ICandidateManagementExperienceRepository candidateManagementExperienceRepository, ICandidateManagementRepository candidateManagementRepository)
        {
            this._candidateManagementExperienceRepository = candidateManagementExperienceRepository;
            this._candidateManagementRepository = candidateManagementRepository;
        }

        public Task<bool> Handle(CreateCandidateExperienceRequest request, CancellationToken cancellationToken)
        {
            var candidate = _candidateManagementRepository.Get(request.CandidateId);

            if (candidate == null)
                return Task.FromResult(false);

            var candidateExperience =
                new CandidateExperience(request.Company,
                                                                request.Job,
                                                                request.Description,
                                                                request.Salary,
                                                                request.BeginDate,
                                                                request.EndDate,
                                                                request.CandidateId);

            _candidateManagementExperienceRepository.Create(candidateExperience);

            return Task.FromResult(true);
        }

    }
}
