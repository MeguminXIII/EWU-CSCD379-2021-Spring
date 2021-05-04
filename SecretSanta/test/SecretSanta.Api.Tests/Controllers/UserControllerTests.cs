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

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Constructor_WithNullUserRepository_ThrowsArgumentNullException(){
            ArgumentNullException argumentNullException = Assert.ThrowsException<ArgumentNullException>(() => new UsersController(null!));
            Assert.AreEqual("userRepository", argumentNullException.ParamName);
        }
    }
}
