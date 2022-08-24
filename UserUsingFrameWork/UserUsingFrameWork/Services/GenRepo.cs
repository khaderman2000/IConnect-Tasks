
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
        public Task<T> Add(T model,int id);
        public T Update(T model,int id);
        /*public Task<TVM> Delete<TVM>(int id) where TVM : class, IBasicModel;*/
        public Task<bool> Delete(int id);
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
        public async Task<T> Add(T model, int id)
        {

            Type mytype = model.GetType();
            var createdate = mytype.GetProperties().FirstOrDefault(x=>x.Name== "createDate");
            var createBy = mytype.GetProperties().FirstOrDefault(x=>x.Name== "createBy");
            if (createdate != null)
            {
                createdate.SetValue(model, DateTime.Now);
                createBy.SetValue(model, id);
            }
           await _context.AddAsync<T>(model);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return model ;
        }
        public T Update(T model,int id)
        {
            Type mytype = model.GetType();
            var updateDate = mytype.GetProperties().FirstOrDefault(x => x.Name == "updateDate");
            var updateBy = mytype.GetProperties().FirstOrDefault(x => x.Name == "updateBy");
            if (updateDate != null)
            {
                updateDate.SetValue(model, DateTime.Now);
                updateBy.SetValue(model, id);
            }
            _context.Update<T>(model);
            _context.SaveChanges();
            return model;

        }
        /*public async Task<TVM> Delete<TVM>(int id) where TVM : class, IBasicModel
        {
            var _temp = await  GetId<TVM>(id);
            var user = _mapper.Map<T>(_temp);


            _context.Set<T>().Remove(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e) { 
            }
            return _temp;

        }*/
        public async Task<bool> Delete(int id)
        {
            try
            {


                var _temp = await _context.Set<T>().FindAsync(id);
                var g = _context.Set<T>().Remove(_temp);
                // _context.Entry(_temp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // var variable= _context.Users.ToList();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

    }
}
