using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Specification.ProductSpecification
{
    public class ProductSpecParams
    {
        public string? Sort {  get; set; }
        

        //Default return 3 products in page
        private int pagesize = 3;

        public int? categoryId { get; set; }

        public int Pagesize
        {
            // default pagesize initialization
            get { return pagesize; }
            set { pagesize = value > 3 ? 3 : value; }
        }

        // default return first page
        public int PageIndex { get; set; } = 1;

        public int? Count { get; set; }

       
        
        public string? search;

        public string? Search
        {
            get { return search; }
            set { search = value.ToLower(); }
        }



    }
}
