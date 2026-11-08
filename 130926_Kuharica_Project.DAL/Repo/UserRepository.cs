using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _130926_Kuharica_Project.DAL.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User Create(User user)
        {
           _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user; 
        }

        public User? GetByUserName(string userName)
         => _appDbContext.Users.FirstOrDefault(x => x.UserName == userName);
    }
}
