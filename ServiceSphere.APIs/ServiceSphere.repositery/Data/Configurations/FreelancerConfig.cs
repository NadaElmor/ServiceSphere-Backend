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
    internal class FreelancerConfig : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {
          
            //nav prop for proposal
            builder.HasMany(f=>f.Proposals).WithOne(p=>p.Freelancer).HasForeignKey(p=>p.FreelancerId);
            ////nav prop for category
            //builder.HasMany(f => f.Categories).WithMany(c => c.Freelancers);
            //nav prop for service
            builder.HasMany(f => f.Services).WithOne(s => s.Freelancer).HasForeignKey(s=>s.FreelancerId);
            //required
           // builder.Property(u => u.FirstName).IsRequired();
           // builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            //builder.Property(u => u.Password).IsRequired();
            //builder.Property(u => u.Country).IsRequired();

        }
    }
}
