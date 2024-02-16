using AutoMapper;
using ServiceSphere.APIs.DTOs;
using ServiceSphere.core.Entities;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Services;

namespace ServiceSphere.APIs.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {


            CreateMap<AddressDto, Address>().ReverseMap();
            //CreateMap<ProjectPostingDto,ProjectPosting>().ReverseMap().
            //    ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories))
            //    .ForMember(dest => dest.ProjectSubCategories, opt => opt.MapFrom(src => src.ProjectSubCategories))
            //    ; // Map SubCategories directly;
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
          //  CreateMap<ProjectSubCategoryDto, ProjectSubCategory>().ReverseMap().ForMember(p => p.SubCategory, c => c.MapFrom(s => s.SubCategory.Name));
            //  .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            //.ForMember(p=>p.Category,c=>c.MapFrom(s=>s.Category.Name))


            // ProjectPostingDto to ProjectPosting
            CreateMap<ProjectPostingDto, ProjectPosting>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId)) // Map CategoryId directly
                .ForMember(dest => dest.userID, opt => opt.MapFrom(src => src.UserId)) // Map UserId to userID
                 ; // Map ProjectSubCategories directly
            CreateMap<ProjectPosting, ProjectPostingDto>();
        }

    }
}
