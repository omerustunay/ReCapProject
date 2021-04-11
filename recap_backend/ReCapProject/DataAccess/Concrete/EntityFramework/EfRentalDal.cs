using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                var result = (from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join c in context.Customers on r.CustomerId equals c.Id
                             join u in context.Users on c.UserId equals u.Id
                             join com in context.Customers on u.Id equals com.UserId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = car.Id,
                                 CarName = car.Description,
                                 CustomerName = (u.FirstName + u.LastName),
                                 CompanyName = com.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             });
                return result.ToList();
            }
        }
    }
}
