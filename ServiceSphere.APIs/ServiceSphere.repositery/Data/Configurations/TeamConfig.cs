using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //nav prop for projectposting
            builder.HasOne(t => t.ProjectPosting).WithOne(p => p.Team).HasForeignKey<Team>(t => t.ProjectPostingId).IsRequired();

            //required
            builder.Property(t=>t.Status).IsRequired();
        }
    }
}
