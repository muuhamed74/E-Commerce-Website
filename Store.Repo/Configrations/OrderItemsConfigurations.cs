using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Models;
using Store.Domain.Models.Order_Models;

namespace Store.Repo.Configrations
{
    public class OrderItemsConfigurations : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.Property(OrderItems => OrderItems.Price)
                .HasColumnType("decimal(18,2)");


            builder.OwnsOne(o => o.Product, product =>
            {
                product.Property(p => p.ProductId).HasColumnName("ProductId");
                product.Property(p => p.ProductName).HasColumnName("ProductName");
                product.Property(p => p.ProductImages).HasColumnName("ProductImages");
            });
        }
    }
}
