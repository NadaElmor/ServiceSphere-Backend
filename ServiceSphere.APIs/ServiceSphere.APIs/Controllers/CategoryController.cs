using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.core.Specifications;
using System.Collections;

namespace ServiceSphere.APIs.Controllers
{
   
    public class ServicesController : BaseController
    {
        private readonly IGenericRepositery<Category> _categoryRepositery;
        private readonly IGenericRepositery<SubCategory> _subCategoryRepositery;

        public ServicesController(IGenericRepositery<Category> categoryRepositery,IGenericRepositery<SubCategory> SubCategoryRepositery)
        {
            _categoryRepositery = categoryRepositery;
            _subCategoryRepositery = SubCategoryRepositery;
        }
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategoriesAsync()
        {
            var Categories= await _categoryRepositery.GetAllAsync();
            return Ok(Categories);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Category>> GetByIdAsync(int Id)
        {
            var Category =await _categoryRepositery.GetByIdAsync(Id);
            if (Category is null) return NotFound();
            return Ok(Category);
        }
        [HttpGet("SubCategory")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategoriesAsync()
        {
            var Spec = new CategoryAndSubCategorySpec();
            var SubCategories = await _subCategoryRepositery.GetAllWithSpecAsync(Spec);
            return Ok(SubCategories);
        }
    }
}
