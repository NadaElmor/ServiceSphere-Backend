using ServiceSphere.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Specifications
{
    public interface Ispecification<T> where T : BaseEntity
    {
        //signature for where 
        public Expression<Func<T,bool>> Critria { get; set; }
        //signature for include 
        public List<Expression<Func<T,object>>> Includes { get; set; }
    }
}
