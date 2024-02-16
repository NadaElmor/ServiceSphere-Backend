using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Users
{
    public enum EgyptCity
    {
        Cairo,
        Alexandria,
        Giza,
        SharmElSheikh,
        Luxor,
        Aswan,
        Hurghada,
        Tanta,
        Mansoura,
        PortSaid,
        Suez,
        Ismailia,
        Assiut,
        Zagazig,
        Sohag,
        Asyut,
        Damietta,
        Minya,
        BeniSuef
    }
    public enum UserType
    {
        Client,
        Freelancer
    }
    public class User:AppUser
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string Country { get; set; }
        //public EgyptCity City { get; set; }
        public UserType UserType { get; set; }
        public string? GoogleAccount { get; set; }

        
        //public string? ZipCode { get; set; }

     //   public ICollection<Notification> Notifications { get; set; }=new HashSet<Notification>();
    //    public  ICollection<Review> Reviews { get; set; } =new HashSet<Review>();

        
       
        // Image


    }
}
