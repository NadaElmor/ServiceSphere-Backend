using ServiceSphere.core.Entities.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Users.Freelancer
{
    public enum TeamStatus
    {
        Open,       // Team is open for new members
        Full,       // Team is full and not accepting new members
        InProgress, // Team is in progress with the project
        Completed   // Team has completed the project
    }
    public class Team:BaseEntity
    {
        public TeamStatus Status { get; set; }

        //fk for project
        public int ProjectPostingId { get; set; }
        public ProjectPosting ProjectPosting { get; set; }
    }
}
