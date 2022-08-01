using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{
    public interface IGenRepo<T> where T : class
    {
        public Task<List<T>?> Get();
        public ValueTask<T?> GetId(int id);
        public Task<T> Add(T model);
        public T Update(T model);
        public Task<T> Delete(int id);

    }

        


    public class GenRepo<T> : IGenRepo<T> where T : class,IBasicModel
    {
        private UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }
        public   Task<List<T>?> Get()
        {
            return  _context.Set<T>().ToListAsync();
        }
        public ValueTask<T?> GetId(int id)
        {
            return _context.Set<T>().FindAsync(id);

        }
        public async Task<T> Add(T model)
        {
           await _context.AddAsync<T>(model);
            await _context.SaveChangesAsync();
            return model ;
        }
        public T Update(T model)
        {
            _context.Update<T>(model);
            _context.SaveChanges();
            return model;

        }
        public async Task<T> Delete(int id)
        {
            var _temp = await  GetId(id);
             
            _context.Set<T>().Remove(_temp);
             await _context.SaveChangesAsync();
            return _temp;

        }

    }
}
