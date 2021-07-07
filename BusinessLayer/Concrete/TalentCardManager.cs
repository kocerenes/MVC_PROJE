using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalentCardManager : ITalentCardService
    {
        private ITalentCard _talentCard;

        public TalentCardManager(ITalentCard talentCard)
        {
            _talentCard = talentCard;
        }

        public void Add(TalentCard talent)
        {
            _talentCard.Insert(talent);
        }

        public void Delete(TalentCard talent)
        {
            _talentCard.Delete(talent);
        }

        public List<TalentCard> GetAll()
        {
            return _talentCard.List();
        }

        public TalentCard GetById(int id)
        {
            return _talentCard.Get(x => x.SkillId == id);
        }

        public void Update(TalentCard talent)
        {
            _talentCard.Update(talent);
        }
    }
}
