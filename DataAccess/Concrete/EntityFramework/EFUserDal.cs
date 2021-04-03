using Core.Entities.Concrete;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
    }
}
