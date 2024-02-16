using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            //nav prop for user
            //builder.HasOne(r => r.Client).WithMany(u => u.Reviews).HasForeignKey(r => r.ClientId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(r => r.Freelncer).WithMany(u => u.Reviews).HasForeignKey(r => r.FreelancerId).OnDelete(DeleteBehavior.NoAction);

            //required
            builder.Property(r => r.Rating).IsRequired();
        }
    }
}
