using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzWalks.API.Controllers
{

    public class StudentsController : BaseController
    {
        private readonly string[] names = new string[]
          {
                "habtish","Esubalew","Adbaru","Abreham","Sindie","Nebiyu","Abay","Hiwotie","Selam"
          };

        [HttpGet]
        public IActionResult Get() {
          

            return Ok(names);
        }
    }
}
