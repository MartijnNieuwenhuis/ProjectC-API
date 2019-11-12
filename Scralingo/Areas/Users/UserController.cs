using Model;
using Website.Controllers;
using System;
using System.Collections.Generic;

namespace Website.Users.Controllers
{
    public class UserController : BaseApiController
    {
        // GET api/user
        public List<User> Get()
        {
            return base.UserService.Get();
        }

        // GET api/user/{id}
        public User Get(Guid id)
        {
            return base.UserService.Get(id);
        }

        // POST api/user
        public void Post(User user)
        {
            base.UserService.AddOrUpdate(user);
        }

        // DELETE api/user/{id}
        public void Delete(Guid id)
        {
            base.UserService.Delete(id);
        }
    }
}
