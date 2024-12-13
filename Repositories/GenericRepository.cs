using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MvcWebCv.Models.Entity;

namespace MvcWebCv.Repositories
{
	public class GenericRepository<T> where T : class, new()
	{

		CvWebDBEntities db = new CvWebDBEntities();

		public List<T> List()
		{
			return db.Set<T>().ToList();
		}

		public void TAdd(T paramaters)
		{
			db.Set<T>().Add(paramaters);
			db.SaveChanges();
		}

		public void TDelete(T paramaters)
		{
			db.Set<T>().Remove(paramaters);
			db.SaveChanges();
		}

		public T TGet(int id)
		{
			return db.Set<T>().Find(id);
		}

		public void TUpdate(T paramaters)
		{
			db.SaveChanges();
		}

		public T Find(Expression<Func<T,bool>> where)
		{
			return db.Set<T>().FirstOrDefault(where); 
		}
	}
}