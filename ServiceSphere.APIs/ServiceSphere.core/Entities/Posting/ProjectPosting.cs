using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Posting
{
    public class ProjectPosting:Post
    {
        //foreign key for the client 
        //public string? ClientId { get; set; }
        //public Client Client { get; set; }
        public string userID { get; set; }

        //foreign key for the category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

       
        public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
        // nav prop for proposals
        public ICollection<Proposal> Proposals { get; set; } = new HashSet<Proposal>();
        public Team Team { get; set; }
        [NotMapped]
        public List<SubCategoryTeamMemebers> SubCategoryTeamMemebers { get; set; } = new List<SubCategoryTeamMemebers>();

        //  public ICollection<ProjectSubCategory> ProjectSubCategories { get; set; } = new HashSet<ProjectSubCategory>();
    }
    public class SubCategoryTeamMemebers
    {
       
        public int SubCategoryId { get; set;}
        public int NumberOfFreelancers { get; set;}
    }
}
