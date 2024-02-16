using Microsoft.EntityFrameworkCore;
using ServiceSphere.core.Entities;
using ServiceSphere.core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery
{
    internal static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery,Ispecification<T> Spec)
        {
            var Query = InputQuery;

            //where
            if(Spec.Critria is not null)
            {
                Query=Query.Where(Spec.Critria);
            }
            //include
            if(Spec.Includes is not null)
            {
                Query = Spec.Includes.Aggregate(Query, (currentQuery, includeExp) => (currentQuery.Include(includeExp)));
            }


            return Query;
        }
    }
}
