using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDb.Interfaces;

namespace WebApiDb.Models
{
	public class Sort : IHomes
	{
		private readonly analysis_workersContext _context = new analysis_workersContext();

		public string Action { set { _Sort(value); } }
		public ActionResult<IEnumerable<WorkEmployee>> Answir { get ; set ; }

		//private readonly analysis_workersContext Context;



		public void _Sort(string _value)
		{
			 
			switch (_value[0])
			{
				case 'Y':
					{
						if (_value[1] == 'O')
						{
							Answir = _context.WorkEmployee.OrderBy(r => r.Yeаr).ToList();
						}
						else if (_value[1] == 'N')
						{
							Answir = _context.WorkEmployee.OrderByDescending(r => r.Yeаr).ToList();
						}
							break;
					}
				case 'M':
					{
						if (_value[1] == 'O')
						{
							Answir = _context.WorkEmployee.OrderBy(r => r.Month).ToList();
						}
						else if (_value[1] == 'N')
						{
							Answir = _context.WorkEmployee.OrderByDescending(r => r.Month).ToList();
						}
						break;
					}
					case 'P':
					{
						if (_value[1] == 'O')
						{
							Answir = _context.WorkEmployee.OrderBy(r => r.PlanFact).ToList();
						}
						else if (_value[1] == 'N')
						{
							Answir = _context.WorkEmployee.OrderByDescending(r => r.PlanFact).ToList();
						}
						break;
					}
					default: {
						Answir = _context.WorkEmployee.ToList();
						break;
					}
			}


			
		}

		 

	}
}
