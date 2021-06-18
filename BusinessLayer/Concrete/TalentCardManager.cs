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

        public List<TalentCard> GetAll()
        {
            return _talentCard.List();
        }
    }
}
