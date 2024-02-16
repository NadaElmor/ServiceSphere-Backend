using ServiceSphere.core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Agreements
{
    public enum ContractStatus
    {
        Active,
        Completed,
        Terminated,
        // Add more status values as needed
    }
    public class Contract:BaseEntity
    {
        public string Terms { get; set; }
        public ContractStatus Status { get; set; }
        public decimal Price { get; set; }
        //fk for clientid, proposalid
        
        public string? ClientId { get; set; }
        public Client Client { get; set; }
        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }
    }
}
