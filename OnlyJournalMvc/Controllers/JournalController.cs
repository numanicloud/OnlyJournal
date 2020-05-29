using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlyJournalMvc.Controllers
{
	public class JournalController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
