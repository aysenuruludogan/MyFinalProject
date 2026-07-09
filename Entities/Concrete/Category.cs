using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //çıplak sınıf kalmasın (egerki bir class herhangi bir inheritance veya bir interface implamentasyonu almıyorsa bil ki bir eksiklik vardır)
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
