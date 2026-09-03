using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ILogger logger, ICategoryService categoryService)
        {
            _productDal = productDal;
            _logger = logger;
            _categoryService = categoryService;
        }
        //Claim
       // [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        [CacheAspect] //key,value
        public IDataResult <List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==19)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult <List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult <Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult <List<Product>> GetByUnitService(decimal min, decimal max)
        {
            return new SuccessDataResult <List<Product>>(_productDal.GetAll(p => p.UnitPrice < min && p.UnitPrice <= max));
        }

        public IDataResult <List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult <List<ProductDetailDto>> (_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p=>p.CategoryId == categoryId).Count;
            if(result>= 30)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        //aynı isimde ürün eklenemez
        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
    
}
 