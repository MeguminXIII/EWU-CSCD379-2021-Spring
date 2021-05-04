using SecretSanta.Business;
using SecretSanta.Data;
using System.Collections.Generic;

namespace SecretSanta.Api.Tests.Business
{
    public class TestableUserRepository : IUserRepository
    {
        public List<User>? UsersList {get; set;}
        
        public User Create(User item)
        {
            if(UsersList is null) UsersList = new List<User>();
            UsersList.Add(item);
            return item;
        }

        public User? GetUser {get; set;}
        public int GetItemId {get; set;}
        public User? GetItem(int id)
        {
            GetItemId = id;
            return GetUser;
        }

        public ICollection<User> List()
        {
            if(UsersList is null) UsersList = new List<User>();
            return UsersList;        }

        public bool Remove(int id)
        {
            if(!(GetUser is null) && GetUser.Id == id) return true;
            return false;
        }

        public User? SavedUser {get; set;}
        public void Save(User item)
        {
            SavedUser = item;
        }
    }
}