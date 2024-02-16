using ServiceSphere.core.Entities.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Services
{
    public  enum SubCategoryNames
    {
        CivilEngineers,
        MechanicalEngineers,
        ElectricalEngineers,
        Architects,
        InteriorDesigners,
        GeneralContractors,
        Carpenters,
        Plumbers,
        Electricians,
        Painters,
        EventPlanners,
        Caterers,
        Decorators,
        Musicians,
        Photographers,
        Videographers
    }
    public class SubCategory:BaseEntity
    {
        public string Name { get; set; }
        //foreign key for category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProjectPosting> ProjectPostings { get; set; } = new HashSet<ProjectPosting>();
    }
}
