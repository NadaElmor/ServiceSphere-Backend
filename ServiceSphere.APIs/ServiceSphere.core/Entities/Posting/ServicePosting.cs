using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Posting
{
    public class ServicePosting:Post
    {
        //foreign key for the client 
        //public string? ClientId { get; set; }
        //
        //foreign key for the category
        public decimal? Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string userID { get; set; }

        // nav prop for proposals
        public ICollection<Proposal> Proposals { get; set; } = new HashSet<Proposal>();
    }
}
