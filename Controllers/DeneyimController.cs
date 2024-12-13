using MvcWebCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
	public class DeneyimController : Controller
	{
		#region CreateObjectRepo
		DeneyimRepository rpDeneyim = new DeneyimRepository();
		#endregion

		#region Index
		public ActionResult Index()
		{
			var values = rpDeneyim.List();
			return View(values);
		}
		#endregion

		#region Create
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TblDeneyimlerim tblDeneyim)
		{
			rpDeneyim.TAdd(tblDeneyim);
			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public ActionResult Delete(int id)
		{
			TblDeneyimlerim value = rpDeneyim.Find(x=>x.Id == id);
			rpDeneyim.TDelete(value);
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		[HttpGet]
		public ActionResult Update(int id)
		{
			TblDeneyimlerim value = rpDeneyim.Find(x => x.Id == id);
			return View(value);
		}

		[HttpPost]
		public ActionResult Update(TblDeneyimlerim parameter)
		{
			TblDeneyimlerim value = rpDeneyim.Find(x => x.Id == parameter.Id);
			value.Baslik = parameter.Baslik;
			value.Aciklama = parameter.Aciklama;
			value.AltBaslik = parameter.AltBaslik;
			value.Tarih = parameter.Tarih;
			rpDeneyim.TUpdate(value);
			return RedirectToAction("Index");
		}
		#endregion
	}
}