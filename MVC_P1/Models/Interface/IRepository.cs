using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_P1.Models.Interface
{
    interface IRepository<T>
    {
        void Save(T model);

        void Update(T model);

        void Delete(T model);

        T Get(int Id);

        List<T> GetAll();
    }
}
