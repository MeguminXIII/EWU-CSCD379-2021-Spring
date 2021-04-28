using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SecretSanta.Data;
using System.Linq;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private Mock<IUserRepository> Setup(User user){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.Create(user)).Returns(user);
            return moq;
        }

        [TestMethod]
        public void Create_ValidUser_ReturnUserAndUserInList()
        {
            User newUser = new User(){
                    FirstName = "Princess_ButterCup",
                    LastName = "Montoya",
                    Id = 0
                };
            Mock<IUserRepository> moq = Setup(newUser);
            
            Assert.AreEqual<User>(newUser, moq.Object.Create(newUser));
            moq.Verify(item => item.Create(newUser), Times.Once());
        }

        [TestMethod]
        public void GetItem_ValidId_ReturnsCorrectUser(){
            User expUser = new User(){
                    FirstName = "Princess_ButterCup",
                    LastName = "Montoya",
                    Id = 0
                };
                Mock<IUserRepository> moq = new();
                moq.Setup(item => item.GetItem(0)).Returns(expUser);
                Assert.AreEqual(expUser, moq.Object.GetItem(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetItem_InvalidId_ReturnsArgumentOutOfRangeException(){
            UserRepository ur = new();
            ur.GetItem(-1);
        }

        [TestMethod]
        public void List_WhenCalled_ReturnsUsersList(){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.List()).Returns(new List<User>(){
               new User(){
                   FirstName = "Inigo",
                   LastName = "Montoya",
                   Id = 0
               } 
            });
            Assert.AreEqual<int>(1, moq.Object.List().Count);
            Assert.AreEqual("Inigo", moq.Object.List().First().FirstName);
        }

        [TestMethod]
        public void RemoveAt_ValidId_ReturnsTrue(){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.RemoveAt(0)).Returns(true);
            Assert.IsTrue(moq.Object.RemoveAt(0));
        }

        [TestMethod]
        public void RemoveAt_InvalidId_ReturnsFalse(){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.RemoveAt(0)).Returns(true);
            Assert.IsFalse(moq.Object.RemoveAt(20));
        }

        [TestMethod]
        public void Save_WhenCalled_UpdatesUser(){
            User newUser = new(){
                FirstName = "Inigo",
                LastName = "Montoya",
                Id = 1
            };
            
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.Save(newUser));
            moq.Object.Save(newUser);
            moq.Verify(item => item.Save(newUser), Times.Once());
        }
    }
}
