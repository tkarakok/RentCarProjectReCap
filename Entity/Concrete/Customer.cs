using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concrete
{
    public class Customer : IEntitiy
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
