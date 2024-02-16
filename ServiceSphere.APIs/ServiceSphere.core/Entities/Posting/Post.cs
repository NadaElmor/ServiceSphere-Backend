using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Posting
{
    public enum PostStatus
    {
        Draft,
        Published,
        Archived,
        Deleted,
        PendingReview,
        Flagged
    }
    public class Post:BaseEntity
    {
        
        public string? Title { get; set; }
        public string Description { get; set; }
        public PostStatus Status { get; set; }
        public decimal? Budget { get; set; }

        public string? Duration { get; set; }

        public DateTime? Deadline { get; set; }

        ////foreign key for the client 
        //public int ClientId { get; set; }
        //public Client Client { get; set; }

        ////foreign key for the category
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }

        //// nav prop for proposals
        //public ICollection<Proposal> Proposals { get; set; }=new HashSet<Proposal>();
    }
}
