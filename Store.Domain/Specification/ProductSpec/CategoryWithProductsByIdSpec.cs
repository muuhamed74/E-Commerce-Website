using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Store.Domain.Specification.ProductSpecification
{
    public class CategoryWithProductsByIdSpec : BaseSpecification<Category>
    {
        public CategoryWithProductsByIdSpec(int id) :
            base(p => p.Id == id) 
        {
            AddInclude(q => q.Include(p => p.Products)
                         .ThenInclude(p => p.Images));




        }
    }
}
