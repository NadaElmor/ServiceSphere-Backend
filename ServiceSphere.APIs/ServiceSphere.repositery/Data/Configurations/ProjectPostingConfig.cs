using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ProjectPostingConfig : IEntityTypeConfiguration<ProjectPosting>
    {
        public void Configure(EntityTypeBuilder<ProjectPosting> builder)
        {
            //nav prop for team
            builder.HasOne(p => p.Team).WithOne(t => t.ProjectPosting).HasForeignKey<Team>(t => t.ProjectPostingId);

            //////nav prop for proposal
            ////builder.HasMany(po => po.Proposals).WithOne(p => p.ProjectPosting).HasForeignKey(p => p.ProjectPostingId);
            //nav prop for client
            //builder.HasOne(p => p.Client).WithMany(c => c.ProjectPostings).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction);
            //nav prop for category 
            builder.HasOne(p => p.Category).WithMany(c => c.ProjectPostings).HasForeignKey(p => p.CategoryId).IsRequired();
            //required
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            
        }
    }
}
