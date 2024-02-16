using ServiceSphere.core.Entities;
using ServiceSphere.core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Repositeries.contract
{
    public interface IGenericRepositery<T> where T : BaseEntity
    {
        public Task<T?> GetByIdAsync(int Id);
        public Task<T?> GetByIdWithSpecAsync(Ispecification<T> Spec);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> Spec);

    }
}
