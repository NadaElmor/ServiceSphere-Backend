using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSphere.core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data.Configurations
{
    internal class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // nav prop for contract
            builder.HasMany(cl => cl.Contracts).WithOne(c => c.Client).HasForeignKey(c => c.ClientId);
            //nav prop for post 
            //builder.HasMany(c=>c.ProjectPostings).WithOne(p=>p.Client).HasForeignKey(p=>p.ClientId);

            //required
            //builder.Property(u => u.FirstName).IsRequired();
            //builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            //builder.Property(u => u.Password).IsRequired();
            //builder.Property(u => u.Country).IsRequired();

        }
    }
}
