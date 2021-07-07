using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentCardService
    {
        List<TalentCard> GetAll();
        TalentCard GetById(int id);
        void Add(TalentCard talent);
        void Update(TalentCard talent);
        void Delete(TalentCard talent);
    }
}
