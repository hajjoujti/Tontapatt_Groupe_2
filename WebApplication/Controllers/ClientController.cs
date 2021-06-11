using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        [Route("client/choixterrain")]
        public IActionResult choixTerrain()
        {
            return View("choixTerrain");
        }

        [HttpGet]
        [Route("client/choixTerrainDescription")]
        public IActionResult choixTerrainDescription()
        {
            return View("choixTerrainDescription");
        }
    }
}