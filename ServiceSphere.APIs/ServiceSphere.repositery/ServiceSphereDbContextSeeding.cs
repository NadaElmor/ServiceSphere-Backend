using ServiceSphere.core.Entities.Services;
using ServiceSphere.repositery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceSphere.repositery
{
    public class ServiceSphereDbContextSeeding
    {
        public static async Task DataSeed(ServiceSphereContext serviceSphereContext)
        {
            //Category
            if (!serviceSphereContext.Categories.Any())
            {
                var CategoriesData = File.ReadAllText("../ServiceSphere.Repositery/Data/DataSeeding/Category.json");
                var Categories = JsonSerializer.Deserialize<List<Category>>(CategoriesData);
                if (Categories?.Count > 0)
                {
                    foreach (var Category in Categories)
                    {
                        await serviceSphereContext.Set<Category>().AddAsync(Category);
                    }
                    await serviceSphereContext.SaveChangesAsync();
                }
            }
            //SubCategory
            if (!serviceSphereContext.SubCategories.Any())
            {
                var SubCategoriesData = File.ReadAllText("../ServiceSphere.Repositery/Data/DataSeeding/SubCategory.json");
                var SubCategories = JsonSerializer.Deserialize<List<SubCategory>>(SubCategoriesData);
                if (SubCategories?.Count > 0)
                {
                    foreach (var SubCategory in SubCategories)
                    {
                        await serviceSphereContext.Set<SubCategory>().AddAsync(SubCategory);
                    }
                    await serviceSphereContext.SaveChangesAsync();
                }
            }
        }
    }
}
