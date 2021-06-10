using SecretSanta.Data;
using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Business
{
    public class SampleData
    {
        public User[] Users {get; set;}
        public Group[] Groups {get; set;}
        public SampleData()
        {
            Users = new[]
            {
                 new User
                {
                    Id = 1,
                    FirstName = "Inigo",
                    LastName = "Montoya"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Princess",
                    LastName = "Buttercup"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Prince",
                    LastName = "Humperdink"
                },
                new User
                {
                    Id = 4,
                    FirstName = "Count",
                    LastName = "Rugen"
                },
                new User
                {
                    Id = 5,
                    FirstName = "Miracle",
                    LastName = "Max"
                }
            };

            Groups = new[]
            {
                new Group
                {
                    Id = 1,
                    Name = "IntelliTect Christmas Party",
                    Users = new List<User> { Users[0], Users[1], Users[2], Users[3], Users[4] }
                },
                new Group
                {
                    Id = 2,
                    Name = "Friends",
                    Users = new List<User> { Users[0], Users[1], Users[2], Users[3], Users[4] }
                }
            };
        }
        
        public static void Seed()
        {
            using DbContext dbContext = new DbContext();
            
            SampleData sampleData = new SampleData();

            dbContext.AddRange(sampleData.Users);
            dbContext.AddRange(sampleData.Groups);
            dbContext.SaveChanges();

        }
    }
}