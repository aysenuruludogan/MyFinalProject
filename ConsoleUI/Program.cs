using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
     class Program
    {
        static void Main(string[] args)
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach(var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
            ProductTest();
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            //var Result = productManager.GetProductDetails();
            //if(Result.Success == true)
            //foreach (var product in Result.Data)
            //{
            //    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            //}
            //else
            //{
            //    Console.WriteLine(Result.Message);
            //}
        }
    }
}
