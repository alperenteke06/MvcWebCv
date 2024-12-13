using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
    public class HobilerimController : Controller
    {
        #region CreateRepoObject
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
		#endregion

		#region Index
		[HttpGet]
        public ActionResult Index()
        {
            var hobies = repo.List();
            return View(hobies);
        }

		[HttpPost]
		public ActionResult Index(TblHobilerim t)
		{
			var value = repo.Find(x => x.Id == 1);
			value.Aciklama1 = t.Aciklama1;
			value.Aciklama2 = t.Aciklama2;
			repo.TUpdate(value);

			return RedirectToAction("Index");
		}
		#endregion
	}
}