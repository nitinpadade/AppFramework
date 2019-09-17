using Framework.Data;
using Framework.Factory;

namespace Framework.BL.Query
{
    public class CurrentUserContext
    {
        private readonly ILoggedInUser _loggedInUser;
        public FrameworkDataContext _dbcontext { get; }

        public CurrentUserContext(ILoggedInUser loggedInUser, FrameworkDataContext dbcontext)
        {
            _loggedInUser = loggedInUser;
            _dbcontext = dbcontext;
        }

        public CurrentUser UserInfo(string[] userInfo)
        {
            return _loggedInUser.Current(userInfo);
        }
        
    }
}
