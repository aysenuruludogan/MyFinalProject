using Entities.Concrete;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract //iş katmanında kullanacagım servis operasyonları
{
    public interface IProductService
    { 
       public List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id); //e-ticaret sisteminde kategoriyi seçtiginde sol tarafta kategoriye göre getiren listeyi yazıyoruz
        List<Product> GetByUnitService(decimal min, decimal max);
    }
}
