using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _130926_Kuharica_Project.DAL.Configurations
{
    public class PredmetConfiguration : IEntityTypeConfiguration<Predmet>
    {
        public void Configure(EntityTypeBuilder<Predmet> builder)
        {
            builder.ToTable("Predmeti");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Naziv).IsRequired().HasMaxLength(30); 
        }
    }
}
