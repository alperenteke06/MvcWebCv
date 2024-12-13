using MvcWebCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebCv.Repositories;

namespace MvcWebCv.Controllers
{
	public class YetenekController : Controller
	{
		#region CreateObjectRepo
		GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
		#endregion

		#region Index
		public ActionResult Index()
		{
			var skills = repo.List();
			return View(skills);
		}
		#endregion

		#region Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TblYeteneklerim paramaters)
		{
			repo.TAdd(paramaters);
			return RedirectToAction("Index","Yetenek");
		}
		#endregion

		#region Delete
		public ActionResult Delete(int id)
		{
			var value = repo.Find(x => x.Id == id);
			repo.TDelete(value);
			return RedirectToAction("Index","Yetenek");
		}
		#endregion

		#region Edit
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var value = repo.Find(x => x.Id == id);
			return View(value);
		}

		[HttpPost]
		public ActionResult Edit(TblYeteneklerim paramater)
		{
			var skill = repo.Find(x => x.Id == paramater.Id);
			skill.Yetenek = paramater.Yetenek;
			skill.Oran = paramater.Oran;
			repo.TUpdate(skill);
			return RedirectToAction("Index");
		}
		#endregion
	}
}