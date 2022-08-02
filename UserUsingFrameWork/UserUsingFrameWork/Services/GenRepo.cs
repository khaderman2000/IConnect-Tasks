
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{
    public interface IGenRepo<T> where T : class
    {
        public Task<List<TVM>?> Get<TVM>() where TVM :class, IBasicModel;
        public ValueTask<TVM?> GetId<TVM>(int id) where TVM : class, IBasicModel;
        public Task<T> Add(T model);
        public T Update(T model);
        public Task<TVM> Delete<TVM>(int id) where TVM : class, IBasicModel;

    }

        


    public class GenRepo<T> : IGenRepo<T> where T : class,IBasicModel
    {
        private UserContext _context;
        private readonly IMapper _mapper;


        public GenRepo(UserContext context,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        

        public   Task<List<TVM>?> Get <TVM>()where TVM :class,IBasicModel
        {
            return _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async ValueTask<TVM?> GetId<TVM>(int id) where TVM : class, IBasicModel
        {
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c=>c.Id==id);
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
        public async Task<TVM> Delete<TVM>(int id) where TVM : class, IBasicModel
        {
            var _temp = await  GetId<TVM>(id);
             
            _context.Set<T>().Remove(_mapper.Map<T>(_temp));
             await _context.SaveChangesAsync();
            return _temp;

        }

    }
}
