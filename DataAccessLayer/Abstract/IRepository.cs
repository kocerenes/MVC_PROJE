using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {

        List<T> List(); // Listeleme için
        void Insert(T p); //Ekleme için

        T Get(Expression<Func<T,bool>> filter);

        void Update(T p); //Güncelleme için
        void Delete(T p); // Silmek için

        List<T> List(Expression<Func<T, bool>> filter); //Şartlı filtreleme için lambda ifadesi

    }
}
