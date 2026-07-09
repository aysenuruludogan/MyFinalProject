using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract //iş katmanında kullanacagım servis operasyonları
{
    public interface IProductService
    { 
       public List<Product> GetAll();
    }
}
