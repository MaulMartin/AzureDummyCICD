using Microsoft.AspNetCore.Mvc;
using System;

namespace DummyCDCI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        public TestController() { }

        [HttpGet]
        public int GetTest()
        {
            var rnd = new Random();
            if (rnd.Next(1, 20) == 1)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return 1;
        }
    }
}
