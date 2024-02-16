using ServiceSphere.core.Entities.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Specifications
{
    public class ProjectPostingWithCategorySpec:BaseSpecification<ProjectPosting>
    {
        public ProjectPostingWithCategorySpec(PostsSpecParams @params) : base(p =>
            (!@params.CategoryId.HasValue || p.CategoryId == @params.CategoryId))
        {
            Includes.Add(c => c.Category);
            Includes.Add(c => c.Team);
            Includes.Add(c => c.SubCategories);
            Includes.Add(c => c.Proposals);

        }
    }
}
