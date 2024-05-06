using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using My_cv.Models.Entity;

namespace My_cv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCVEntities db = new DbCVEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T p)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }

        public void TUpdateAll(Expression<Func<T, bool>> where, T updatedEntity)
        {
            var entity = db.Set<T>().FirstOrDefault(where);
            if (entity != null)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if(prop.Name == "ID")
                        continue;
                    var value = prop.GetValue(updatedEntity);
                    if (value != null)
                    {
                        prop.SetValue(entity, value);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}