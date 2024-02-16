using ServiceSphere.core.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Specifications
{
    public class CategoryAndSubCategorySpec:BaseSpecification<SubCategory>
    {
        public CategoryAndSubCategorySpec():base()
        {
            Includes.Add(c => c.Category);
        
        }
        public CategoryAndSubCategorySpec(int Id):base(c=>c.Id==Id)
        {
            Includes.Add(c => c.Category);
        }
    }
}
