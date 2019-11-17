using MVC_P1.Models.DBModels;
using MVC_P1.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_P1.Models.Repository
{
    public class ProductsRepository : IRepository<Urunler>
    {
        private NorthwindEntities dbN;

        public ProductsRepository(NorthwindEntities northwindEntities)
        {
            dbN = northwindEntities;
        }
        public void Delete(Urunler model)
        {
            dbN.Urunler.Remove(model);
            dbN.SaveChanges();
        }

        public Urunler Get(int Id)
        {
            return dbN.Urunler.Find(Id);
        }

        public List<Urunler> GetAll()
        {
            return dbN.Urunler.ToList();
        }

        public void Save(Urunler model)
        {
            dbN.Urunler.Add(model);
            dbN.SaveChanges();
        }

        public void Update(Urunler model)
        {
            dbN.Entry(model).State = EntityState.Modified;
            dbN.SaveChanges();
        }

        public List<Tedarikciler> GetTedarikciler()
        {
            return dbN.Tedarikciler.ToList();
        }
    }
}