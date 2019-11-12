using Model;
using Website.Controllers;
using System;
using System.Collections.Generic;

namespace Website.Scores.Controllers
{
    public class ScoreController : BaseApiController
    {
        // GET api/score
        public List<Score> Get()
        {
            return base.ScoreService.Get();
        }

        // GET api/score/{id}
        public Score Get(Guid id)
        {
            return base.ScoreService.Get(id);
        }

        // POST api/score
        public void Post(Score score)
        {
            base.ScoreService.AddOrUpdate(score);
        }

        // DELETE api/score/{id}
        public void Delete(Guid id)
        {
            base.ScoreService.Delete(id);
        }
    }
}
