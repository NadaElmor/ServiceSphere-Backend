using Microsoft.EntityFrameworkCore;
using ServiceSphere.core.Entities;
using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.core.Specifications;
using ServiceSphere.repositery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery
{
    public class GenericRepositery<T> : IGenericRepositery<T> where T : BaseEntity
    {
        private readonly ServiceSphereContext _serviceSphereContext;

        public GenericRepositery(ServiceSphereContext serviceSphereContext)
        {
            _serviceSphereContext = serviceSphereContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _serviceSphereContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> Spec)
        {
            return await ApplySpec(Spec).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int Id)
        {
            return await _serviceSphereContext.Set<T>().FindAsync(Id);
        }

        public async Task<T?> GetByIdWithSpecAsync(Ispecification<T> Spec)
        {
            return await ApplySpec(Spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpec(Ispecification<T> Spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_serviceSphereContext.Set<T>(), Spec);
        }
    }
}
