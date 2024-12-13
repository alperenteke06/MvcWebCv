using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
    public class IletisimController : Controller
    {
		#region CreateObjectRepo
		GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();
		#endregion

		#region Index
		public ActionResult Index()
        {
			var values = repo.List();
            return View(values);
        }
		#endregion
	}
}