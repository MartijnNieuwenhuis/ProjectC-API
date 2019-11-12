using Business.Core;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Users
{
    
    public class UserService : BaseService<User>
    {
        public UserService(ContextService contextService) : base(new ModelService<User>(contextService))
        {
        }

        public List<User> Get()
        {
            return base.Get<User>(u => u.UserName).ToList();
        }

        public User Get(Guid id)
        {
            return base.Get<User>(id);
        }

        public void Delete(Guid id)
        {
            base.Delete(id);
        }

        public void AddOrUpdate(User user)
        {
            base.Save(ref user);
        }
    }
}