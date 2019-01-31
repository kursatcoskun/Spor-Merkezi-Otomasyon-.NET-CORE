using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthentication.Data;
using TokenBasedAuthentication.Dtos;

namespace TokenBasedAuthentication.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
   
    public class ValuesController : ControllerBase
    {
        IAppRepo _Apprepo;
        private IMapper _mapper;

        public ValuesController(IAppRepo appRepo,IMapper mapper)
        {
            _Apprepo = appRepo;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var uyeler = _Apprepo.GetUyeler();
            var uyelerReturn = _mapper.Map<List<UyeListDto>>(uyeler);
            return Ok(uyeler);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
