using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Data;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System;


namespace SecretSanta.Api.Tests
{
    [TestClass]
    public class UsersControllerTests{

        private Mock<IUserRepository> Setup(){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.List()).Returns(new List<User>()
            {
                new User(){
                    FirstName = "Inigo",
                    LastName = "Montoya",
                    Id = 0
                }
            });
            return moq;
        }

        private Mock<IUserRepository> Setup(User user){
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.GetItem(0)).Returns(user);
            return moq;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassInNull_ThrowsException(){
            UsersController uc = new(null);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsList(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            List<User> user = (List<User>)uc.Get();
            Assert.AreEqual<string>(user[0].FirstName, "Inigo");
        }

        [TestMethod]
        public void Get_GivenIndex_ReturnsUserAtIndex(){
            User newUser = new(){
                FirstName = "Inigo",
                LastName = "Montoya",
                Id = 0
            };

            Mock<IUserRepository> moq = Setup(newUser);
            UsersController uc = new(moq.Object);
            User user = uc.Get(0).Value;

            Assert.AreEqual<User>(uc.Get(0).Value, newUser);

        }

        [TestMethod]
        public void Get_GivenNeg1_ThrowsException(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            var response = uc.Get(-1);
            Assert.IsTrue(response.Result is NotFoundResult);
        }

        [TestMethod]
        public void Delete_GivenIndex_ReturnsOk(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            ActionResult result = uc.Delete(0);
            Assert.IsTrue(result is OkResult);
        }

        [TestMethod]
        public void Delete_GivenNeg1_ThrowsException(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            var response = uc.Delete(-1);
            Assert.IsTrue(response is NotFoundResult);
        }

        [TestMethod]
        public void Post_GivenNull_ThrowsException(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            var response = uc.Post(null);
            Assert.IsTrue(response.Result is BadRequestResult);
        }

        [TestMethod]
        public void Post_GivenUser_CreateGetsCalled(){
            User newUser = new(){
                FirstName = "Inigo",
                LastName = "Montoya",
                Id = 0
            };
            Mock<IUserRepository> moq = new();
            moq.Setup(item => item.Create(newUser)).Returns(newUser);
            UsersController uc = new(moq.Object);
            uc.Post(newUser);
            moq.Verify(item => item.Create(newUser), Times.Once());
        }

        [TestMethod]
        public void Put_GivenNullUser_ReturnsBadRequest(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            var response = uc.Put(1, null);
            Assert.IsTrue(response is BadRequestResult);
        }

        [TestMethod]
        public void Put_GivenNeg1Id_ReturnsNotFound(){
            Mock<IUserRepository> moq = Setup();
            UsersController uc = new(moq.Object);
            var response = uc.Put(1, null);
            Assert.IsTrue(response is BadRequestResult);
        }

        [TestMethod]
        public void Put_GivenValidIdAndUser_ReturnsOkResult(){
            User newUser = new(){
                FirstName = "Inigo",
                LastName = "Montoya",
                Id = 0
            };
            Mock<IUserRepository> moq = Setup(newUser);
            UsersController uc = new(moq.Object);
            var response = uc.Put(0, newUser);
            Assert.IsTrue(response is OkResult);            
        }
    }

}