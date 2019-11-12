using Business.Core;
using Business.Scores;
using Business.Users;
using System.Web.Http;

namespace Website.Controllers
{
    public class BaseApiController : ApiController
    {
        private UserService _userService;
        protected UserService UserService
        {
            get
            {
                return this._userService = this._userService ?? new UserService(new ContextService());
            }
        }

        private ScoreService _scoreService;
        protected ScoreService ScoreService
        {
            get
            {
                return this._scoreService = this._scoreService ?? new ScoreService(new ContextService());
            }
        }

    }
}
