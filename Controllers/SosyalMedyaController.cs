using Microsoft.Ajax.Utilities;
using MvcWebCv.Models.Entity;
using MvcWebCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        #region CreateObject
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
		#endregion

		#region Index
		public ActionResult Index()
        {
            var values = repo.List();
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
		public ActionResult Create(TblSosyalMedya p)
		{
            repo.TAdd(p);
			return RedirectToAction("Index");
		}
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
			var value = repo.Find(x => x.ID == id);
			return View(value);
		}

        [HttpPost]
        public ActionResult Edit(TblSosyalMedya p)
        {
            var value = repo.Find(x => x.ID == p.ID);
            value.Ad = p.Ad;
            value.Link = p.Link;
            value.Icon = p.Icon;
            value.Durum = true;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            var passiveValue = repo.Find(x => x.ID == id);
            passiveValue.Durum = false;
            repo.TUpdate(passiveValue);
            return RedirectToAction("Index");

        }
		#endregion
	}
}