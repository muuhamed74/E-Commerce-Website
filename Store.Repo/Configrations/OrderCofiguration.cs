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
    public class OrderCofiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(O => O.Status)
                   .HasConversion(
                    OStatus => OStatus.ToString(),
                    OStatus => (OrderStatus) Enum.Parse(typeof(OrderStatus), OStatus));
           
            
            builder.Property(O => O.Subtotal)
                   .HasColumnType("decimal(18,2)");

            builder.OwnsOne(O => O.ShipToAddress, SA => SA.WithOwner());

            builder.HasOne(O => O.DeliveryMethod)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
