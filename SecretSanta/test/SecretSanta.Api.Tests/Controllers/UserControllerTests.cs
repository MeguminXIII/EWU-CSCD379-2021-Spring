using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Api.Dto;
using SecretSanta.Api.Tests.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        private WebApplicationFactory Factory {get;} = new();

        #region GET() TESTS
        [TestMethod]
        public async Task Get_ValidParams_ReturnsValidUserList(){
            TestableUserRepository tur = Factory.Tur;
            List<User> userList = new(){
                new User{Id = 42, FirstName = "Inigo", LastName = "Montoya"}
            };
            tur!.UsersList!.AddRange(userList);
            HttpClient hc = Factory.CreateClient();

            HttpResponseMessage hrm = await hc.GetAsync(new Uri("/api/users/", UriKind.Relative));
            List<DtoUser>? res = await hrm.Content.ReadFromJsonAsync<List<DtoUser>?>();

            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(userList.Count, res!.Count -1);
        }
        #endregion GET() TESTS

        #region GET(ID) TESTS

        [TestMethod]
        public async Task Get_ValidParams_ReturnsValidDtoUser(){
            TestableUserRepository tur = Factory.Tur;
            User user = new() 
            {
                Id = 42, FirstName = "Inigo", LastName = "Montoya"
            };

            tur.GetUser = user;
            HttpClient hc = Factory.CreateClient();

            HttpResponseMessage hrm = await hc.GetAsync(new Uri("/api/users" + user.Id, UriKind.Relative));
            DtoUser? dtoUser = await hrm.Content.ReadFromJsonAsync<DtoUser?>();

            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(user.FirstName, dtoUser?.FirstName);
            Assert.AreEqual(user.LastName, dtoUser!.LastName);
            Assert.AreEqual(user.Id, dtoUser!.Id);
        }
        #endregion GET(ID) TESTS

        #region POST(DTO) TESTS

        [TestMethod]
        public async Task Post_ValidParams_ReturnsValidDtoUser(){
            TestableUserRepository tur = Factory.Tur;
            DtoUser user = new() 
            {
                Id = 42, FirstName = "Inigo", LastName = "Montoya"
            };

            User expected = new() 
            {
                Id = (int)user.Id, FirstName = user.FirstName, LastName = user.LastName
            };
            
            
            HttpClient hc = Factory.CreateClient();
            HttpResponseMessage hrm = await hc.PostAsJsonAsync(new Uri("/api/users", UriKind.Relative), user);
            DtoUser? dtoUser = await hrm.Content.ReadFromJsonAsync<DtoUser?>();
            hrm.EnsureSuccessStatusCode();

            Assert.AreEqual(expected.FirstName, dtoUser?.FirstName);
            Assert.AreEqual(expected.LastName, dtoUser!.LastName);
            Assert.AreEqual(expected.Id, dtoUser!.Id);
        }
        #endregion POST(DTO) TESTS

        #region PUT(ID, DTO) TESTS
        
        [TestMethod]
        public async Task Put_ValidParams_UserGetsUpdated(){
            TestableUserRepository tur = Factory.Tur;
            int updateId = 42;
            DtoUser user = new() 
            {
                FirstName = "Inigo", LastName = "Montoya"
            };

            tur.GetUser = new() 
            {
                Id = updateId, FirstName = "Princess", LastName = "Buttercup"
            };
        
            HttpClient hc = Factory.CreateClient();
            HttpResponseMessage hrm = await hc.PostAsJsonAsync(new Uri("/api/users/" + updateId, UriKind.Relative), user);
            hrm.EnsureSuccessStatusCode();

            Assert.AreEqual(updateId, tur.GetItemId);
            Assert.AreEqual(user.FirstName, tur.SavedUser!.FirstName);
            Assert.AreEqual(user.LastName, tur.SavedUser!.LastName);
        }

        #endregion PUT(ID, DTO) TESTS

        #region DELETE(ID) TESTS

        [TestMethod]
        public async Task Delete_ValidParam_RemovesCorrectUser(){
            TestableUserRepository tur = Factory.Tur;
            tur.RemoveReturn = true;
            int id = 42;

             HttpClient hc = Factory.CreateClient();
             HttpResponseMessage hrm = await hc.DeleteAsync(new Uri("api/users/" + id, UriKind.Relative));
             hrm.EnsureSuccessStatusCode();

             Assert.AreEqual(id, tur.RemoveId);
        }

        #endregion DELETE(ID) TESTS
    }
}
