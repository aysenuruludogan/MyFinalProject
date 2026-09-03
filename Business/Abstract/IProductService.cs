using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract //iş katmanında kullanacagım servis operasyonları
{
    public interface IProductService
    { 
        IDataResult <List<Product>> GetAll();
        IDataResult <List<Product>> GetAllByCategoryId(int id); //e-ticaret sisteminde kategoriyi seçtiginde sol tarafta kategoriye göre getiren listeyi yazıyoruz
        IDataResult <List<Product>> GetByUnitPrice(decimal min, decimal max); //Belli bir fiyat aralıgında ürün getirmek için
        IDataResult <List<ProductDetailDto>> GetProductDetails(); //Ürünlerin detaylı listesini getirmek için
        IDataResult <Product> GetById(int productId); // Bir ürünün detayını getirmek için
        IResult Add(Product product);
        IResult Update(Product product);
    }
}
