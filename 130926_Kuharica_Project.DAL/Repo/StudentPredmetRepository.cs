using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace _130926_Kuharica_Project.DAL.Repo
{
    public class StudentPredmetRepository : IStudentPredmetInterface
    {
        //constructor

        private readonly AppDbContext _appDbContext;

        public StudentPredmetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }


        //methods 
        public StudentPredmet Create(StudentPredmet sp)
        {
            _appDbContext.StudentPredmeti.Add(sp);
            _appDbContext.SaveChanges();
            return GetByID(sp.StudentID, sp.PredmetID)!;
        }

        public StudentPredmet? Delete(int studentId, int predmetId)
        {
            var sp = GetByID(studentId, predmetId);
            if (sp == null) return null;

            _appDbContext.StudentPredmeti.Remove(sp);
            _appDbContext.SaveChanges();
            return sp;
        }

        public StudentPredmet? GetByID(int studentId, int predmetId)
        {
           return 
                _appDbContext
                .StudentPredmeti
                .Include(sp => sp.Student)
                .Include(s => s.Predmet)
                .FirstOrDefault( sp => sp.StudentID == studentId && sp.PredmetID == predmetId);
        }

        public List<StudentPredmet> GetAll()
        {
             return 
                _appDbContext.StudentPredmeti
                .Include(sp => sp.Student)
                .Include(sp => sp.Predmet)
                .ToList();
        }
    }
}
