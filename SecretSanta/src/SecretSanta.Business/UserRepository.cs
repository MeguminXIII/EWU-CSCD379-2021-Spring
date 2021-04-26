using System;
using SecretSanta.Data;
using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        public User Create(User user)
        {
            DeleteMe.Users.Add(user);
            return user;
        }

        public User? GetItem(int id)
        {
            if(id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            return DeleteMe.Users.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<User> List()
        {
            return DeleteMe.Users;
        }

        public bool RemoveAt(int id)
        {
            User? curUser = DeleteMe.Users.FirstOrDefault(x => x.Id == id);
            if(curUser is null) return false;
            DeleteMe.Users.Remove(curUser);
            return true;
        }

        public void Save(User item)
        {
            RemoveAt(item.Id);
            Create(item);
        }
    }
}