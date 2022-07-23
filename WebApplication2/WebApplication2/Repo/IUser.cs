using WebApplication2.Models;
namespace WebApplication2.Repo
{
    public interface IUser
    {
      abstract  public List<User> GetAll();
      abstract public User Get(int id);
      abstract public void Delete(int id);
      abstract public void Add(User user);
      abstract public void Update(int id,User user);


    }
}
