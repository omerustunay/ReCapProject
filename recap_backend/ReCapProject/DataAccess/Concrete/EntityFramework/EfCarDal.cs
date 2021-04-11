using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RecapDbContext context = new RecapDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             join im in context.CarImages
                             on car.Id equals im.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 CarName = car.Description,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Date = im.Date,
                                 ModelYear = car.ModelYear,
                                 ImagePath = im.ImagePath

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
