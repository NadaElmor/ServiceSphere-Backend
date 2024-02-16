using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            //nav prop for freelancer
            builder.HasOne(s => s.Freelancer).WithMany(f => f.Services).HasForeignKey(s=>s.FreelancerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.Category).WithMany(c => c.Services).HasForeignKey(c=>c.CategoryId);
            //required
            builder.Property(s=>s.Name).IsRequired();
            builder.Property(s=>s.Price).IsRequired();
        }
    }
}
