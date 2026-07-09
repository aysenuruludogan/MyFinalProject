using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class:referans tip
    //IEntity: IEntity olabilir veya IEntity implement eden bir nesne olabilir
    //new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter); //tekbir şeyin detayı için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
