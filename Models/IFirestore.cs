using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Models
{
    public interface IFirestore<T>
    {
        T Get(T record);
        T GetById(string Id);
        List<T> GetAll();
        T Add(T record);
        bool Update(T record);
        bool Delete(T record);
    }
}
