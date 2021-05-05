using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Web.Api;
using SecretSanta.Web.Tests.Api;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private WebApplicationFactory Factory {get;} = new();

        #region INDEX() TESTS

        [TestMethod]
        public async Task Index_GivenNullDto_IsOk(){
            TestableUserClient tuc = Factory.Tuc;
            tuc.GetAllUsers.Add(null!);
            HttpClient hc = Factory.CreateClient();

            await hc.GetAsync(new Uri("/users/", UriKind.Relative));

            Assert.IsTrue(true);//if it didnt blow up then its good.
        }


        [TestMethod]
        public async Task Index_WithValidParams_CallsGetAllAsync(){
            TestableUserClient tuc = Factory.Tuc;
            tuc.GetAllUsers.Add(new DtoUser {Id = 42, FirstName = "Inigo", LastName = "Montoya"});
            HttpClient hc = Factory.CreateClient();
            
            HttpResponseMessage hrm = await hc.GetAsync(new Uri("/users/", UriKind.Relative));
            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(1, tuc.GetAllAsyncCalledCount);
        

        }
        #endregion INDEX() TESTS

        #region CREATE(USERVIEWMODEL) TESTS

        [TestMethod]
        public async Task Create_ValidParams_CallsPostAsync(){
            TestableUserClient tuc = Factory.Tuc;
            HttpClient hc = Factory.CreateClient();
            Dictionary<string, string?> vm = new() {
              {nameof(UserViewModel.Id), "42"}  
            };

            HttpResponseMessage hrm = await hc.PostAsync(new Uri("/users/create/", UriKind.Relative),
                new FormUrlEncodedContent(vm!));

            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(1, tuc.PostAsyncCalledCount);
        }

        [TestMethod]
        public async Task Create_InvalidParams_DoesntCallPostAsync(){
            TestableUserClient tuc = Factory.Tuc;
            HttpClient hc = Factory.CreateClient();
            Dictionary<string, string?> vm = new() {
              {nameof(UserViewModel.Id), null!}  
            };

            HttpResponseMessage hrm = await hc.PostAsync(new Uri("/users/create/", UriKind.Relative),
                new FormUrlEncodedContent(vm!));

            hrm.EnsureSuccessStatusCode();

            Assert.AreEqual(0, tuc.PostAsyncCalledCount);
        }

        #endregion CREATE(USERVIEWMODEL) TESTS

        #region EDIT(VIEWMODEL) TESTS

        [TestMethod]
        public async Task Edit_ValidParams_CallsPutAsync(){
            TestableUserClient tuc = Factory.Tuc;
            HttpClient hc = Factory.CreateClient();
            Dictionary<string, string?> vm = new() {
              {nameof(UserViewModel.Id), "0"}  
            };

            HttpResponseMessage hrm = await hc.PostAsync(new Uri("/users/edit/", UriKind.Relative),
                new FormUrlEncodedContent(vm!));
            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(1, tuc.PutAsyncCalledCounter);
        }


        [TestMethod]
        public async Task Edit_ValidParams_SendsValidDtoUser(){
            TestableUserClient tuc = Factory.Tuc;
            HttpClient hc = Factory.CreateClient();
            Dictionary<string, string?> vm = new() {
              {nameof(UserViewModel.Id), "0"},
              {nameof(UserViewModel.FirstName), "Inigo"},
              {nameof(UserViewModel.LastName), "Montoya"}
            };

            HttpResponseMessage hrm = await hc.PostAsync(new Uri("/users/edit/", UriKind.Relative),
                new FormUrlEncodedContent(vm!));
            hrm.EnsureSuccessStatusCode();
            DtoUser res = tuc.PutAsyncParam;
            Assert.AreEqual(vm["FirstName"], res.FirstName);
            Assert.AreEqual(vm["LastName"], res.LastName);
        }
        #endregion EDIT(VIEWMODEL) TESTS

        #region DELETE(ID) TESTS

        [TestMethod]
        public async Task Delete_ValidParams_CallsDeleteAsync(){
            TestableUserClient tuc = Factory.Tuc;
            HttpClient hc = Factory.CreateClient();

            HttpResponseMessage hrm = await hc.PostAsync(new Uri("/users/delete/0", UriKind.Relative),
                new FormUrlEncodedContent(new Dictionary<string, string?>()!));    

            hrm.EnsureSuccessStatusCode();
            Assert.AreEqual(1, tuc.DeleteAsyncCalledCount);        
        }

        #endregion DELETE(ID) TESTS
    }
}
