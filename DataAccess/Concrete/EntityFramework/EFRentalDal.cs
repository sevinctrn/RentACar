using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join cs in context.Customers on r.CustomerId equals cs.Id
                             join u in context.Users on cs.UserId equals u.Id
                             select new RentalDetailDto { Id = r.Id, BrandName = b.BrandName, 
                                 ColorName = co.ColorName, ModelYear = c.ModelYear, 
                                 DailyPrice = c.DailyPrice, Description = c.Descriptions,
                                 FirstName = u.FirstName, LastName = u.LastName, RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate, CompanyName = cs.CompanyName };
                return result.ToList();
            }
        }
    }
}
