using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controllers]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository UserManager  {get; }

        public UsersController(IUserRepository userManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserManager.List();
        }

        [HttpGet("{id}")]
        public ActionResult<User?> Get(int id)
        {
            if(id < 0) return NotFound();
            return UserManager.GetItem(id);
        }

        [HttpGet("{id}")]
        public ActionResult<User?> Delete(int id)
        {
            if(id < 0) return NotFound();
            UserManager.RemoveAt(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult<User?> Post([FromBody] User user)
        {
            if(user is null) return BadRequest();
            return UserManager.Create(user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User? newUser)
        {
            if(newUser is null) return BadRequest();
            User? curUser = UserManager.GetItem(id);
            if(curUser is null) return NotFound();
            else
            {
                if(!string.IsNullOrWhiteSpace(newUser.FirstName) && !string.IsNullOrWhiteSpace(newUser.LastName))
                {
                    curUser.FirstName = newUser.FirstName;
                    curUser.LastName = newUser.LastName;
                }

                UserManager.Save(curUser);
                return Ok();
            }
        }


    }
}