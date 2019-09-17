using Framework.Data;
using Framework.DomainModels.Models.UserLogin;
using Framework.DomainModels.Parameters.UserLogin;
using Framework.Factory;
using System;
using System.Linq;

namespace Framework.BL.Query.UserLogin
{
    public class UserLoginQuery : IQuery<QueryResult<UserLoginModel>, UserLoginParameter>
    {
        private readonly FrameworkDataContext _dbcontext;
        private readonly ILoggedInUser _loggedInUser;

        public UserLoginQuery(FrameworkDataContext dbcontext, ILoggedInUser loggedInUser)
        {
            _dbcontext = dbcontext;
            _loggedInUser = loggedInUser;
        }

        public QueryResult<UserLoginModel> Execute(UserLoginParameter parameters)
        {
            try
            {
               
                var result = _dbcontext.User.Where(n => n.UserName == parameters.UserName && n.Password == parameters.Password)
                    .Select(n => new UserLoginModel
                    {
                        Id = n.Id,
                        Name = n.FirstName + " " + n.LastName,
                        RoleId = n.RoleId.GetValueOrDefault(),
                        Role = _dbcontext.Role.Where(r => r.Id == n.RoleId.GetValueOrDefault()).FirstOrDefault().Name,
                        IsAuthenticated = true
                    }).FirstOrDefault();

                return new QueryResult<UserLoginModel>()
                {
                    Data = result,
                    IsExecuted = true,
                    Status = CommandQueryStatus.Executed,
                    Message = result != null ? "Query Executed Successfully" : "Invalid Username Or Password"
                };
            }
            catch (Exception ex)
            {

                return new QueryResult<UserLoginModel>()
                {
                    Data = new UserLoginModel { IsAuthenticated = false },
                    IsExecuted = true,
                    Status = CommandQueryStatus.Failed,
                    ErrorMessage = ex.ToString(),
                    Message = "Error Occured While Processing Your Request"
                };
            }
        }
    }
}
