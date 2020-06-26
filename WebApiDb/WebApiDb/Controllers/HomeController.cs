using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDb.Interfaces;
using WebApiDb.Models;

namespace WebApiDb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
        private readonly IHomes homes;

        public HomeController(IHomes homes)
        {
            this.homes = homes;
		}

		//GET: api/WorkEmployees
		[HttpGet("{values}")]
		public  ActionResult<IEnumerable<WorkEmployee>> GetWorkEmployee(string values)
		{   
			//Y/M/D
			//O = Order
			//N = Not order
			//semple : ../home/YO

			homes.Action = values;

			return  homes.Answir;
		}



	}
}
