using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //projeyi başlatınca bellekte bir tane liste oluştur
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            { 
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 10 },
                new Product { ProductId = 2, CategoryId = 2, ProductName = "Çatal", UnitPrice = 15, UnitsInStock = 10 },
                new Product { ProductId = 3, CategoryId = 3, ProductName = "Kaşık", UnitPrice = 15, UnitsInStock = 10 },
                new Product { ProductId = 4, CategoryId = 4, ProductName = "Tabak", UnitPrice = 15, UnitsInStock = 10 },
                new Product { ProductId = 5, CategoryId = 5, ProductName = "Kutu", UnitPrice = 15, UnitsInStock = 10 }

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //where koşulu içindeki şartlara uyan elemanları yeni bir liste hali
        }

        public void Update(Product product)
        {

            //gonderdigim urun ıd sine sahip oLAN LİSTEDEKİ URUNU BUL
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            
        }
    }
}
