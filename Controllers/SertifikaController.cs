using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
	public class SertifikaController : Controller
	{
		#region CreateObjectRepo
		GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();
		#endregion

		#region Index
		public ActionResult Index()
		{
			var values = repo.List();
			return View(values);
		}
		#endregion

		#region Edit
		[HttpGet]
		public ActionResult Edit(int id)
		{
			//Id For Delete Process
			ViewBag.id = id;
			var value = repo.Find(x => x.Id == id);
			return View(value);
		}
		[HttpPost]
		public ActionResult Edit(TblSertifikalarım p)
		{
			var value = repo.Find(x => x.Id == p.Id);
			value.Aciklama = p.Aciklama;
			value.Tarih = p.Tarih;
			repo.TUpdate(value);
			return RedirectToAction("Index");
		}
		#endregion

		#region Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(TblSertifikalarım p)
		{
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
	}
}