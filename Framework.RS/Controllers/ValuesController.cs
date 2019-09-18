using Framework.BL.Query.UserList;
using Framework.DomainModels.Models.UserList;
using Framework.DomainModels.Parameters.UserList;
using Framework.Factory;
using Framework.Factory.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Framework.RS.Controllers
{
    [Route("api/[controller]")]

    public class ValuesController : BaseController
    {

        public ValuesController(ICommandHandler command, IQueryExecutor query)
            : base(command, query)
        {

        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var result = Query<UserListQuery, QueryResultList<UserListModel>, UserListParameter>(new UserListParameter());
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
