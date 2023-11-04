using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Car : IEntitiy
    {
        public int Id;
        public int BrandId;
        public int ColorId;
        public int ModelYear;
        public decimal DailyPrice;
        public string Description;
    }
}
