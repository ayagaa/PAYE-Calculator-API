using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.DataAccess
{
    public class UserRespository : IFirestore<User>
    {
        private string collectionName = "Users";
        private BaseRepository baseRepository;

        public UserRespository()
        {
            baseRepository = new BaseRepository(collectionName);
        }

        public User Add(User record)
        {
            return baseRepository.Add(record);
        }

        public bool Delete(User record)
        {
            return baseRepository.Delete(record);
        }

        public User Get(User record)
        {
            return baseRepository.Get(record);
        }

        public List<User> GetAll()
        {
            return baseRepository.GetAll<User>();
        }

        public User GetById(string Id)
        {
            return baseRepository.Get<User>(Id);
        }

        public bool Update(User record)
        {
            return baseRepository.Update(record);
        }
    }
}
