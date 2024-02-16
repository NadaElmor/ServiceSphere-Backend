using ServiceSphere.core.Entities;
using ServiceSphere.core.Entities.Posting;
using System.ComponentModel.DataAnnotations;

namespace ServiceSphere.APIs.DTOs
{
    public class ProjectPostingDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public decimal? Budget { get; set; }

        public string? Duration { get; set; }

        public DateTime? Deadline { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UserId { get; set; }
        // Add other properties as needed

        // Add a list of selected subcategory IDs
        public List<int> SelectedSubCategoryIds { get; set; }
        
     //  public string? Category { get; set; }

        public ICollection<SubCategoryDto> SubCategories { get; set; } = new List<SubCategoryDto>();
        public List<SubCategoryTeamMemebers> SubCategoryTeamMemebers { get; set; } = new List<SubCategoryTeamMemebers>();

        // public ICollection<ProjectSubCategoryDto> ProjectSubCategories { get; set; } = new HashSet<ProjectSubCategoryDto>();

    }
}
