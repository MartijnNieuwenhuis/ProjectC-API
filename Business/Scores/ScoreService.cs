using Business.Core;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Scores
{
    
    public class ScoreService : BaseService<Score>
    {
        public ScoreService(ContextService contextService) : base(new ModelService<Score>(contextService))
        {
        }

        public List<Score> Get()
        {
            return base.Get<Score>(u => u.Points).ToList();
        }

        public Score Get(Guid id)
        {
            return base.Get<Score>(id);
        }

        public void Delete(Guid id)
        {
            base.Delete(id);
        }

        public void AddOrUpdate(Score score)
        {
            base.Save(ref score);
        }
    }
}