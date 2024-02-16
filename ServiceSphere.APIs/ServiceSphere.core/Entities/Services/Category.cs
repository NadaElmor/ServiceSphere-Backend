using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Services
{
    public enum CategoryNames
    {
        ConstructionAndRenovation, EventPlanning, Education
    }
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProjectPosting> ProjectPostings { get; set; } = new HashSet<ProjectPosting>();
        public ICollection<ServicePosting> ServicePostings { get; set; } = new HashSet<ServicePosting>();
        //nav prop for freelancer
        public ICollection<Freelancer> Freelancers { get; set; } = new HashSet<Freelancer>();
        public ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
    }
}
