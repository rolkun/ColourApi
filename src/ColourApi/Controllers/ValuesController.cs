using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ColourApi.Models;
using Microsoft.Extensions.Logging;

namespace ColourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> logger;
        private readonly ColourContext context;

        public ValuesController(ColourContext context, ILogger<ValuesController> logger)
        {
            this.context = context;
            this.logger = logger; 
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetColorItems()
        {
            this.logger.LogInformation("Return colour items");
            return this.context.ColourItems;
        }
        public ActionResult<Colour> GetColorItem(int id)
        {
            this.logger.LogInformation($"Return colour for id {id}");
            return new Colour { ColourName = "red" }; 
        }
    }
}
