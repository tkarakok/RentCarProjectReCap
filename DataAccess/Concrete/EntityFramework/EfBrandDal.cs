using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentCarContext> , IBrandDal
    {
     
    }
}
