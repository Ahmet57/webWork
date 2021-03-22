using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAzure.Controllers
{
    public class UsersController : ApiController
    {
        public Users GetAdmin(string UserName, string Password)
        {
            using (ahmetDatabaseEntities studentSystemEntities = new ahmetDatabaseEntities())
            {
                return studentSystemEntities.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            }
        }
    }
}
