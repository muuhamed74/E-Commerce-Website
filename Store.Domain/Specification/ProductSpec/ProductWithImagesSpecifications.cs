using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Specification.ProductSpecification
{
    public class ProductWithImagesSpecifications : BaseSpecification<Product>
    {
        public ProductWithImagesSpecifications(ProductSpecParams Params) :
            base(p =>
            (string.IsNullOrEmpty(Params.search) || p.Name.ToLower().Contains(Params.Search))
            &&
            (!Params.categoryId.HasValue || p.CategoryId == Params.categoryId))

            
           
                
        {
            Includes.Add(p => p.Images);


            if(!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDsc":
                        AddOrderByDesending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }

            }

            //Products => 14
            //PageSize => 3

            //EX: 
            //pageindex 2
            //skip => 3 = 3 * 1
            //take 3 
            
            
            ApplyPagination(Params.Pagesize * (Params.PageIndex - 1) , Params.Pagesize);
        }

        public ProductWithImagesSpecifications(int id) :
           base(p => p.Id == id)
        {
            Includes.Add(p => p.Images);
        }
    }

}

