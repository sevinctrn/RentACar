
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Concrete;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from oc in context.OperationClaims
                             join usc in context.UserOperationClaims
                                 on oc.Id equals usc.OperationId
                             where usc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();

            }
        }
    }
}