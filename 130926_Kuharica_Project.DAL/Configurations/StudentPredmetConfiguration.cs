using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _130926_Kuharica_Project.DAL.Configurations
{
    public class StudentPredmetConfiguration : IEntityTypeConfiguration<StudentPredmet>
    {
        public void Configure(EntityTypeBuilder<StudentPredmet> builder)
        {
            builder.ToTable("StudentPredmeti");
            builder.HasKey(sp => new { sp.StudentID, sp.PredmetID }); 

            builder.HasOne(sp=>sp.Student)
                .WithMany(s => s.StudentPredmeti)
                .HasForeignKey(s => s.StudentID) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sp => sp.Predmet)
               .WithMany(s => s.StudentPredmeti)
               .HasForeignKey(s => s.PredmetID)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
