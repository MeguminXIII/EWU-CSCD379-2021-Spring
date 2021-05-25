using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using UserGroup.Data;

namespace UserGroup.Data.Tests
{
    [TestClass]
    public class DbContextTests
    {

        [TestMethod]
        public void DbContext_CanConnect_CanConnectReturnsTrue()
        {
            DbContext dbContext = new();
            dbContext.Database.OpenConnection();
            Assert.IsTrue(dbContext.Database.CanConnect());
        }

        [TestMethod]
        public void DbContext_AddEvent_EventExists()
        {
            DbContext dbContext = new();
        
            int count = dbContext.Events.Count();
            Assert.AreEqual(count, 0);

            dbContext.Events.Add(new Event(){Id=42,Title="C# Class"});
            count = dbContext.Events.Count();
            Assert.AreEqual(dbContext.Events.FirstAsync().Id, 42);

            Assert.AreEqual(count, 1);
            dbContext.Database.CloseConnection();
        }
    }
}
