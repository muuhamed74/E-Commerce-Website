using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Specification.ProductSpecification
{
    public class ProductWithSpecForCount : BaseSpecification<Product>
    {
        public ProductWithSpecForCount(ProductSpecParams Params) :
            base(p =>
            (string.IsNullOrEmpty(Params.search) || p.Name.ToLower().Contains(Params.Search))
            &&
            (!Params.categoryId.HasValue || p.CategoryId == Params.categoryId)) 
        { 
        }

    }
}
