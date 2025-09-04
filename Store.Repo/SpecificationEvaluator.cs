using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Specification;

namespace Store.Repo
{
    public class SpecificationEvaluator<T> where T : BaseModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            //sorting will be after filtration

            //sorting by Asc
            if (spec.OrderBy is not null) 
            {
                query = query.OrderBy(spec.OrderBy);
            }
            //sorting by Dsc
            if (spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            //Apply pagination
            if (spec.enablepagination)
            {
             query= query.Skip(spec.Skip).Take(spec.Take);
            }



            query = spec.Includes.Aggregate(query, (currentquery, IncludExpressione) => currentquery.Include(IncludExpressione));

            query = spec.Includables.Aggregate(query, (current, include) => include(current));











            return query;
            
        }


    }
}
