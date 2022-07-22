using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Application.Comands.Requests
{
    public class CreateCandidateExperienceRequest : IRequest<bool>
    {
        [Required(ErrorMessage = "Company é obrigatório")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Job é obrigatório")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Description é obrigatório")]
        [StringLength(4000, MinimumLength = 1, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Salary é obrigatório")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "BeginDate é obrigatório")]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "CandidateId é obrigatório")]
        public Guid CandidateId { get; set; }

        public CreateCandidateExperienceRequest()
        {

        }
        public CreateCandidateExperienceRequest(Guid CandidateId)
        {
            this.CandidateId = CandidateId;
            this.BeginDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

    }
}
