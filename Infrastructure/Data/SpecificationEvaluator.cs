﻿using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification) 
        {
            var query = inputQuery.AsQueryable();
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            /* _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).ToListAsync(); */
                                                         // current = entity; include = expression of the include statement
            query = specification.includes.Aggregate(query, (current, include) =>  current.Include(include));            

            return query;
        }
    }
}
