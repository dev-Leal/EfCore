using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Tarde.Domains
{
    public class Pedido : BaseDomain
    {

        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

       
    }
}
