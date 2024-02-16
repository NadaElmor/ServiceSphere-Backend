using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(c => c.Terms).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.HasOne(c => c.Proposal).WithOne(p => p.Contract).HasForeignKey<Contract>(c => c.ProposalId).IsRequired();
            builder.HasOne(c=>c.Client).WithMany(cl=>cl.Contracts).HasForeignKey(c => c.ClientId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
