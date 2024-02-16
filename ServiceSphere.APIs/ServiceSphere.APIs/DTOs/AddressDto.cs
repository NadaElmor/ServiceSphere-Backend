using ServiceSphere.core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace ServiceSphere.APIs.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
        public string? ZipCode { get; set; }
        public string? Location { get; set; }
       
    }
}
