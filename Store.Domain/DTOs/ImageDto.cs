using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
    }
}
