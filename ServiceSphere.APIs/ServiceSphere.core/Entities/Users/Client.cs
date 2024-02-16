using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Posting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Users
{
    public class Client:User
    {

        public string? Bio { get; set; }
       

        //nav prop for contract
        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
        //nav prop for post
        public ICollection<ProjectPosting> ProjectPostings { get; set; }=new HashSet<ProjectPosting>();
        public ICollection<ServicePosting> ServicePostings { get; set; } = new HashSet<ServicePosting>();
        //nav prop for notification 
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        //nav prop for review
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
