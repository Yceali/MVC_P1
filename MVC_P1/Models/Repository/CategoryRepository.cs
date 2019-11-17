using MVC_P1.Models.DBModels;
using MVC_P1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_P1.Models.Repository
{
    public class CategoryRepository : IRepository<Kategoriler>
    {
        private NorthwindEntities dbN;
        public CategoryRepository(NorthwindEntities MydbN)
        {
            dbN = MydbN;
        }
        public void Delete(Kategoriler model)
        {
            dbN.Kategoriler.Remove(model);
            dbN.SaveChanges();
        }

        public Kategoriler Get(int Id)
        {
            return dbN.Kategoriler.Find(Id);
        }

        public List<Kategoriler> GetAll()
        {
            return dbN.Kategoriler.ToList();
        }

        public void Save(Kategoriler model)
        {
            dbN.Kategoriler.Add(model);
            dbN.SaveChanges();
        }

        public void Update(Kategoriler model)
        {
            dbN.Entry(model).State = EntityState.Modified;
            dbN.SaveChanges();
        }
    }
}