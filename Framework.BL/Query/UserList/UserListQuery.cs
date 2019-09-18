using Framework.BL.Common;
using Framework.Data;
using Framework.DomainModels.Models.UserList;
using Framework.DomainModels.Parameters.UserList;
using Framework.Factory;
using System;
using System.Linq;

namespace Framework.BL.Query.UserList
{
    public class UserListQuery : IQuery<QueryResultList<UserListModel>, UserListParameter>
    {
        FrameworkDataContext _dbcontext { get; }

        public UserListQuery(FrameworkDataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public QueryResultList<UserListModel> Execute(UserListParameter parameters)
        {
            try
            {
                var userName = LoginUserContext.UserName;
                var userId = LoginUserContext.UserId;

                var result = _dbcontext.User.Select(n => new UserListModel
                {
                    Id = n.Id,
                    FirstName = n.FirstName,
                    MiddleName = n.MiddleName,
                    LastName = n.LastName,
                    Email = n.Email,
                    Mobile = n.Mobile,
                    DateOfBirth = n.DateOfBirth,
                    RoleId = n.RoleId,
                }).ToList();
               
                return new QueryResultList<UserListModel>()
                {
                    Data = result,
                    IsExecuted = true,
                    Status = CommandQueryStatus.Executed,
                    Message = result.Count != 0 ? "Query Executed Successfully" : "Records Not Found"
                };
            }
            catch (Exception ex)
            {

                return new QueryResultList<UserListModel>()
                {
                    Data = null,
                    IsExecuted = true,
                    Status = CommandQueryStatus.Failed,
                    ErrorMessage = ex.ToString(),
                    Message = "Error Occured While Processing Your Request"
                };
            }
        }
    }
}
