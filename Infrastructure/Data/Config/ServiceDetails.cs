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
    public class ServiceDetailsConfiguration : IEntityTypeConfiguration<ServiceDetails>
    {
        public void Configure(EntityTypeBuilder<ServiceDetails> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ServiceFeatures).HasMaxLength(30);

            builder.HasData(
                new ServiceDetails { Id = 1, ServiceFeatures = "تسجيل قراءه عداد", ServiceId = 1 },
                  new ServiceDetails { Id = 2, ServiceFeatures = "دفع الفواتير  ", ServiceId = 1 },
                  new ServiceDetails { Id = 3, ServiceFeatures = "تصحيح قراءه عداد", ServiceId = 2 },

                new ServiceDetails { Id = 4, ServiceFeatures = "تصحيح بيانات صاحب العداد", ServiceId = 2 },
                new ServiceDetails { Id = 5, ServiceFeatures = "سداد دفعة مقدمة للعداد", ServiceId = 3 },
                new ServiceDetails { Id = 6, ServiceFeatures = "جدوله مديونية على اقساط شهريه", ServiceId = 3 }
                );
        }
    }
}
