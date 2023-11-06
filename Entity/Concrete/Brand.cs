using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concrete
{
    public class Brand : IEntitiy
    {
        public int  Id { get; set; }
        public string Name{ get; set; }
    }
}
