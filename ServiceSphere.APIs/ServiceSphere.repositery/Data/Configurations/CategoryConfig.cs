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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //nav prop for post
            builder.HasMany(c => c.ProjectPostings).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            //nav prop for service
            builder.HasMany(c => c.Services).WithOne(s => s.Category).HasForeignKey(c => c.CategoryId);
            //nav prop for subcategory
            builder.HasMany(c => c.SubCategories).WithOne(s => s.Category).HasForeignKey(s => s.CategoryId);
            //required
            builder.Property(c=>c.Name).IsRequired();
        }
    }
}
