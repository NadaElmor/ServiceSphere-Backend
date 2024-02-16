using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ServicePostingConfig : IEntityTypeConfiguration<ServicePosting>
    {
        public void Configure(EntityTypeBuilder<ServicePosting> builder)
        {
            ////nav prop for proposal
            //builder.HasMany(po => po.Proposals).WithOne(p => p.ServicePosting).HasForeignKey(p => p.ServicePostingId);
            //nav prop for client
            //builder.HasOne(p => p.Client).WithMany(c => c.ServicePostings).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction);
            //nav prop for category 
            builder.HasOne(p => p.Category).WithMany(c => c.ServicePostings).HasForeignKey(p => p.CategoryId).IsRequired();
            //required
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
