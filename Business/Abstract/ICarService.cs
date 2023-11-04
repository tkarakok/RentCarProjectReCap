using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
    }
}
