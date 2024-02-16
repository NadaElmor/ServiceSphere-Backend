using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Agreements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ProposalConfig : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            //nav prop for contract 
            builder.HasOne(p => p.Contract).WithOne(c => c.Proposal).HasForeignKey<Contract>(c => c.ProposalId);
            //nav prop for post
            builder.HasOne(p => p.ProjectPosting).WithMany(po => po.Proposals).HasForeignKey(p => p.ProjectPostingId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            //nav prop for post
            builder.HasOne(p => p.ServicePosting).WithMany(po => po.Proposals).HasForeignKey(p => p.ServicePostingId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            //nav prop for freelancer
            builder.HasOne(p => p.Freelancer).WithMany(f => f.Proposals).HasForeignKey(p => p.FreelancerId).OnDelete(DeleteBehavior.NoAction);

            //required
            //builder.Property(p=>p.Status).IsRequired();
            builder.Property(p => p.ProposedBudget).IsRequired();
            builder.Property(p => p.ProposedTimeframe).IsRequired();
            
        }
    }
}
