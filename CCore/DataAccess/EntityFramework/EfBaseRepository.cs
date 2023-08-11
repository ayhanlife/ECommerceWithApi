using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext
    {
        //IHttpContextAccessor _httpContextAccessor;
        //public EfBaseRepository()
        //{
        //    _httpContextAccessor = (IHttpContextAccessor)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IHttpContextAccessor)); ;
        //}

        private readonly TContext _context;
        public EfBaseRepository(TContext context)
        {
            this._context = context;
        }

        public EfBaseRepository()
        { }
        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
 
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {

            return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            //var createDate = entity.GetType().GetProperty("CreatedDate");
            //var dateValue = entity.GetType().GetProperty("CreatedDate").GetValue(entity);
            //entity.GetType().GetProperty("CreatedUserId").SetValue(entity, Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            //if (!Equals(createDate, null))
            //{
            //    if (Convert.ToDateTime(dateValue) == DateTime.MinValue)
            //        entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            //}

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //var createDate = entity.GetType().GetProperty("UpdatedDate");
            //var dateValue = entity.GetType().GetProperty("UpdatedDate").GetValue(entity);
            //entity.GetType().GetProperty("UpdatedUserId").SetValue(entity, Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            //if (!Equals(createDate, null))
            //{
            //    if (Convert.ToDateTime(dateValue) == DateTime.MinValue)
            //        entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);
            //}

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {

            var deleteEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(deleteEntity);
            var data = await _context.SaveChangesAsync();
            if (data > 0)
                return true;
            return false;
        }

        public async Task<List<TEntity>> Include(params Expression<Func<TEntity, object>>[] includes)
        {

            var query = _context.Set<TEntity>().ToList();
            foreach (var include in includes)
                query = _context.Set<TEntity>().Include(include).ToList();
            return query.ToList();
        }
    }
}