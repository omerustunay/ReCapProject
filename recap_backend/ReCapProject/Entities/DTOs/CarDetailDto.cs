using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {

        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string CarName { get; set; }
    }
}
