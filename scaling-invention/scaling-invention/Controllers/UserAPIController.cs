using scaling_invention.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace scaling_invention.Controllers
{
    public class UserAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJson(Common.Users.AsEnumerable());
        }

        public HttpResponseMessage Post([FromBody]User value)
        {
            Common.Users.Add(value);

            return ToJson(Common.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]User value)
        {
            Common.Entry(value).State = EntityState.Modified;

            return ToJson(Common.SaveChanges());
        }

        public HttpResponseMessage Delete(int id)
        {
            Common.Users.Remove(Common.Users.FirstOrDefault(x => x.Id == id));

            return ToJson(Common.SaveChanges());
        }
    }
}
