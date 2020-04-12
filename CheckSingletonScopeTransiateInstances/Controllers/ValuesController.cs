using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSingletonScopeTransiateInstances.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace CheckSingletonScopeTransiateInstances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ISingleTonClass singleTonClass;
        private ITransiateClass transiateClass;
        private IScopedClass scopedClass;
        private IService service;
        public ValuesController(ISingleTonClass singleTonClass, IScopedClass scopedClass, ITransiateClass transiateClass, IService service)
        {
            this.singleTonClass = singleTonClass;
            this.scopedClass = scopedClass;
            this.transiateClass = transiateClass;
            this.service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] User user)
        {
            return "Welcome to Http Post Method";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
