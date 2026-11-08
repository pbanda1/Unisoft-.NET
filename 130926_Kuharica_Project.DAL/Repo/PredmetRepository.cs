using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace _130926_Kuharica_Project.DAL.Repo
{
    public class PredmetRepository : IPredmetRepository
    {
        private readonly AppDbContext _appDbContext;

        public PredmetRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public Predmet Create(Predmet predmet)
        {
            _appDbContext.Add(predmet);
            _appDbContext.SaveChanges();
            return predmet;
        }

        public Predmet? Delete(int id)
        {
            var predmet = _appDbContext.Predmeti.FirstOrDefault(p => p.Id == id);
            if (predmet == null) { return null; }
            _appDbContext.Remove(predmet);
            _appDbContext.SaveChanges();
            return predmet;
        }

        public List<Predmet> GetAll()
        {
            return
                _appDbContext.Predmeti.ToList();
        }

        public Predmet? GetById(int id)
        {
            return _appDbContext.Predmeti.FirstOrDefault(p => p.Id == id);
        }

        public Predmet? GetWithStudenti(int id)
        {
           return _appDbContext.Predmeti
                .Include( p => p.StudentPredmeti!)
                .ThenInclude( sp => sp.Student)
                .FirstOrDefault( p => p.Id == id);
        }

        public Predmet? Update(int id, Predmet entity)
        {
            var existingSubject = _appDbContext.Predmeti.FirstOrDefault(p => p.Id == id);
            if (existingSubject == null) { return null; }
            existingSubject.Naziv = entity.Naziv;
            _appDbContext.SaveChanges();
            return existingSubject;
        }
    }
}
