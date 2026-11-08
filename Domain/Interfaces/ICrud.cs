using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICrud<T>
    {
        List<T> GetAll();
        T? GetById(int id);

        T Create(T entity);
        
        T? Update(int id, T entity);

        T? Delete(int id);
    }
}
