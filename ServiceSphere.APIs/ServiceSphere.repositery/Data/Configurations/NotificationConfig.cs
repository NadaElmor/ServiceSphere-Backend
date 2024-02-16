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
    internal class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            //builder.HasOne(n => n.User).WithMany(u => u.Notifications).HasForeignKey(n => n.UserId).IsRequired();
           // builder.HasOne(n=>n.Client).WithMany(c=>c.Notifications).HasForeignKey(n=>n.ClientId).OnDelete(DeleteBehavior.NoAction); ;
            //builder.HasOne(n => n.Freelncer).WithMany(c => c.Notifications).HasForeignKey(n => n.FreelancerId).OnDelete(DeleteBehavior.NoAction); ;

            //required
            //builder.Property(n=>n.Status).IsRequired();
            builder.Property(n => n.date).IsRequired();
            builder.Property(n => n.Message).IsRequired();
      
        }
    }
}
