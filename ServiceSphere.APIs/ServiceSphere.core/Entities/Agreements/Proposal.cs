using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Agreements
{
    /*public enum ProposalStatus
    {
        UnderReview,
        Accepted,
        Rejected,
        Completed,
    }*/

    public class Proposal:BaseEntity
    {
        public string ProposedTimeframe { get; set; }
        //public ProposalStatus Status { get; set; }
        public decimal ProposedBudget { get; set; }

        public bool IsAccepted { get; set; }
        //fk for PostId, FreelancerId
        public int ProjectPostingId { get; set; }
        public ProjectPosting ProjectPosting { get; set; }
        public int ServicePostingId { get; set; }
        public ServicePosting ServicePosting { get; set; }
        public string? FreelancerId { get; set; }
        public Freelancer  Freelancer { get; set; }

        //navigational property for contract 
        public Contract Contract { get; set; }
    }
}
