using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDb.Models;

namespace WebApiDb.Interfaces
{
	public interface IHomes
	{

		string Action { set; }

		ActionResult<IEnumerable<WorkEmployee>> Answir { get; set; }

	}
}
