using CandidateManagement.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Domain.Entities
{
    public class CandidateExperience : Base
    {
        public string Company { get; set; }

        public string Job { get; set; }

        public string Description { get; set; }

        public decimal Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid CandidateId { get; set; }

        public CandidateExperience()
        { }

        public CandidateExperience(
            string company,
            string job,
            string description,
            decimal salary,
            DateTime beginDate,
            DateTime? endDate,
            Guid candidateId)
        {
            Id = Guid.NewGuid();
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            CandidateId = candidateId;
            InsertDate = DateTime.Now;
            ModifyDate = null;
        }

        public CandidateExperience(
            Guid id,
            string company,
            string job,
            string description,
            decimal salary,
            DateTime beginDate,
            DateTime? endDate,
            DateTime insertDate,
            Guid candidateId)
        {
            Id = id;
            Company = company;
            Job = job;
            Description = description;
            Salary = salary;
            BeginDate = beginDate;
            EndDate = endDate;
            InsertDate = insertDate;
            ModifyDate = DateTime.Now;
            CandidateId = candidateId;
        }
    }
}
