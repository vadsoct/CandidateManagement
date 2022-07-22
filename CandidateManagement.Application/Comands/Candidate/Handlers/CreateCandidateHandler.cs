using CandidateManagement.Application.Comands.Requests;
using CandidateManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Comands.Candidate.Handlers
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateRequest, bool>
    {
        private readonly ICandidateManagementRepository _candidateManagementRepository;

        public CreateCandidateHandler(ICandidateManagementRepository candidateRepository)
        {
            this._candidateManagementRepository = candidateRepository;
        }
        public Task<bool> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate =
                new Domain.Entities.Candidate(request.Name,
                                            request.Surname,
                                            request.Birthdate,
                                            request.Email);


            _candidateManagementRepository.Create(candidate);

            return Task.FromResult(true);
        }

    }
}
