using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
	public class HakkimdaController : Controller
	{
		#region CreateRepoObject
		GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
		#endregion

		#region Index
		[HttpGet]
		public ActionResult Index()
		{
			var aboutMe = repo.List();
			return View(aboutMe);
		}

		[HttpPost]
		public ActionResult Index(TblHakkimda t)
		{
			var value = repo.Find(x => x.Id == 1);
			value.Ad = t.Ad;
			value.Soyad = t.Soyad;
			value.Adres = t.Adres;
			value.Telefon = t.Telefon;
			value.Mail = t.Mail;
			value.Aciklama = t.Aciklama;
			value.Resim = t.Resim;
			repo.TUpdate(value);

			return RedirectToAction("Index");
		}

		#endregion
	}
}