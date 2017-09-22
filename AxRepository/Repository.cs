//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using AxRepository.Interfaces;

//namespace AxRepository
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        protected readonly DbContext _context;
//        protected readonly DbSet _entities;

//        public Repository(DbContext context)
//        {
//            _context = context;
//            _entities = _context.Set<TEntity>();
//        }

//        public TEntity Get(int id)
//        {
//            return _context.Set<TEntity>().Find(id);
//        }

//        public IEnumerable<TEntity> GetAll()
//        {
//            // Note that here I've repeated _context.Set<TEntity>() in every method and this is causing
//            // too much noise. I could get a reference to the DbSet returned from this method in the 
//            // constructor and store it in a private field like _entities. This way, the implementation
//            // of our methods would be cleaner:
//            // 
//            // _entities.ToList();
//            // _entities.Where();
//            // _entities.SingleOrDefault();
//            // 
//            // I didn't change it because I wanted the code to look like the videos. But feel free to change
//            // this on your own.
//            return _context.Set<TEntity>().ToList();
//        }

//        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
//        {
//            return _context.Set<TEntity>().Where(predicate);
//        }

//        public TEntity SingleOrDefault(Func<TEntity, bool> predicate)
//        {
//            return _context.Set<TEntity>().SingleOrDefault(predicate);
//        }

//        public void Add(TEntity entity)
//        {
//            _context.Set<TEntity>().Add(entity);
//        }

//        public void AddRange(IEnumerable<TEntity> entities)
//        {
//            _context.Set<TEntity>().AddRange(entities);
//        }

//        public void Remove(TEntity entity)
//        {
//            _context.Set<TEntity>().Remove(entity);
//        }

//        public void RemoveRange(IEnumerable<TEntity> entities)
//        {
//            _context.Set<TEntity>().RemoveRange(entities);
//        }
//    }
//}
