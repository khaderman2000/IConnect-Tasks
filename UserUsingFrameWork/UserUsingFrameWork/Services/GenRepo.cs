using UserUsingFrameWork.Models;

namespace UserUsingFrameWork.Services
{
    public interface IGenRepo<T> where T : class
    {
        public List<T> Get();
        public T GetId(int id);
        public T Add(T model);
        public T Update(T model);
        public void Delete(int id);

    }

        


    public class GenRepo<T> : IGenRepo<T> where T : class
    {
        private UserContext _context;

        public GenRepo(UserContext context)
        {
            _context = context;
        }
        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }
        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Add(T model)
        {
            _context.Add<T>(model);
            _context.SaveChanges();
            return model;
        }
        public T Update(T model)
        {
            _context.Update<T>(model);
            _context.SaveChanges();
            return model;

        }
        public void Delete(int id)
        {
            var _temp = GetId(id);

            _context.Set<T>().Remove(_temp);
            _context.SaveChanges();

        }

    }
}
