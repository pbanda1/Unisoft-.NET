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
    public class StudentRepository : IStudentRepository
    {
        //constructors start 
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //constructors end

        public Student Create(Student student)
        {
           _appDbContext.Studenti.Add(student);
            _appDbContext.SaveChanges();
            return student;
        }

        public Student? Delete(int id)
        {
            var existingStudent = _appDbContext.Studenti.FirstOrDefault(x => x.Id == id);
            if (existingStudent == null) { return null; }
            _appDbContext.Remove(existingStudent);
            _appDbContext.SaveChanges();
            return existingStudent;  
       }

        public List<Student> GetAll()
        {
            return _appDbContext.Studenti.ToList();
        }

        public Student? GetById(int id)
        {
            return _appDbContext.Studenti.FirstOrDefault(s => s.Id == id);
        }

        public Student? GetWithPredmeti(int id)
        {
            return _appDbContext.Studenti
                .Include(s => s.StudentPredmeti!)
                .ThenInclude(sp => sp.Predmet)
                .FirstOrDefault(s => s.Id == id);
        }

        public Student? Update(int id, Student student)
        {
            var existingStudent = _appDbContext.Studenti.FirstOrDefault(x => x.Id == id);
            if (existingStudent == null) { return null; }
            existingStudent.Name = student.Name;
            _appDbContext.SaveChanges();
            return existingStudent; 

        }
    }
}
