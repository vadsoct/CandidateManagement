using CandidateManagement.Application.Comands.Candidate.Requests;
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
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateRequest, bool>
    {
        private readonly ICandidateManagementRepository _candidateManagementRepository;

        public DeleteCandidateHandler(ICandidateManagementRepository candidateRepository)
        {
            this._candidateManagementRepository = candidateRepository;
        }
        public Task<bool> Handle(DeleteCandidateRequest request, CancellationToken cancellationToken)
        {

            _candidateManagementRepository.Delete(c => c.Id == request.Id);

            var result = true;

            return Task.FromResult(result);
        }

    }
}
