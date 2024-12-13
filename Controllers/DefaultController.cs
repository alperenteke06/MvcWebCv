using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebCv.Models.Entity;
namespace MvcWebCv.Controllers
{
	public class DefaultController : Controller
	{
		#region CreateObjectDb
		CvWebDBEntities db = new CvWebDBEntities();
		#endregion

		#region Index
		public ActionResult Index()
		{
			var values = db.TblHakkimdas.ToList();
			return View(values);
		}
		#endregion

		#region Deneyim
		public PartialViewResult Deneyim()
		{
			var values = db.TblDeneyimlerims.ToList();
			return PartialView(values);
		}
		#endregion

		#region Deneyimlerim
		public PartialViewResult Egitimlerim()
		{
			var values = db.TblEgitimlerims.ToList();
			return PartialView(values);
		}
		#endregion

		#region Yeteneklerim
		public PartialViewResult Yeteneklerim()
		{
			var values = db.TblYeteneklerims.ToList();
			return PartialView(values);
		}
		#endregion

		#region Hobilerim
		public PartialViewResult Hobilerim()
		{
			var values = db.TblHobilerims.ToList();
			return PartialView(values);
		}
		#endregion

		#region Sertifikalarım
		public PartialViewResult Sertifikalarim()
		{
			var values = db.TblSertifikalarım.ToList();
			return PartialView(values);
		}
		#endregion

		#region Iletisim
		[HttpGet]
		public PartialViewResult Iletisim()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Iletisim(TblIletisim tblIletisim)
		{
			tblIletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.TblIletisims.Add(tblIletisim);
			db.SaveChanges();
			return PartialView();
		}
		#endregion
	}
}