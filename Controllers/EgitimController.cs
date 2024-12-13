using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
	public class EgitimController : Controller
	{
		#region CreateObjectRepo
		GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
		#endregion

		#region Index
		public ActionResult Index()
		{
			var value = repo.List();
			return View(value);
		}
		#endregion

		#region Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TblEgitimlerim p)
		{
			if (!ModelState.IsValid)
			{
				return View("Create");
			}
			repo.TAdd(p);
			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public ActionResult Delete(int id)
		{
			var value = repo.Find(x => x.Id == id);
			repo.TDelete(value);
			return RedirectToAction("Index");
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
		public ActionResult Edit(TblEgitimlerim p)
		{
			var value = repo.Find(x => x.Id == p.Id);
			value.Baslik = p.Baslik;
			value.AltBaslik1 = p.AltBaslik1;
			value.AltBaslik2 = p.AltBaslik2;
			value.Tarih = p.Tarih;
			repo.TUpdate(value);
			return RedirectToAction("Index");
		}
		#endregion
	}
}