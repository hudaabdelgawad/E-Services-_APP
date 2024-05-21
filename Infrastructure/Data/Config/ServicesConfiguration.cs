using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Id)


                .IsRequired();
            builder.Property(x => x.ServiceName).HasMaxLength(30);

            //Seed
            builder.HasData(
                new Service { Id = 1, ServiceName = "خدمات العدادات" },
                new Service { Id = 2, ServiceName = " تغيير بيانات" },
                new Service { Id = 3, ServiceName = " سداد دفعات" }
                );
        }
    }
}
