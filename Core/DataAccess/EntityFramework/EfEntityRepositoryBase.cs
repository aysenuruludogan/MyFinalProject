using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //IDisposable pattern implementation of c# bellegi hızlıca temizleme
            {
                var addedEntity = context.Entry(entity);//REFERANSI YAKALA.git veri kaynagından benim bu gondedegiim nesneyi eşleştir (veri kayagı ile ilşkilendirme)
                addedEntity.State = EntityState.Added; //o aslında eklenecek bir nesne
                context.SaveChanges(); // Ekleme işlemi  yapılır

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //IDisposable pattern implementation of c# bellegi hızlıca temizleme
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); //arkaplanda bizim için select * from product donduruyor ve onu bizim için bir listeye ceviriyor
            }
        }

        public void Update(TEntity entity)
        {

            using (TContext context = new TContext()) //IDisposable pattern implementation of c# bellegi hızlıca temizleme
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
