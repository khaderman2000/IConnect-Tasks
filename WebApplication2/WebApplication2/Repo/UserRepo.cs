using WebApplication2.Models;

namespace WebApplication2.Repo
{

    public class UserRepo
    {
        static List<User> users { get; set; }
        static UserRepo()
        {
            users = new List<User>()
            {
                new User() { Id=1, FirstName= "khader", LastName="Mansour" },
                new User() { Id=2, FirstName= "ala", LastName="sawadeh"},
                new User() { Id=3, FirstName= "yaser", LastName="admeh"},
                new User() { Id=4, FirstName= "bassam", LastName="kosa"},
                new User() { Id=5, FirstName= "abed", LastName="fahed"},
            };

        }
        public static List<User> GetAll()
        {
            return users;
        }
        public static User Get(int id)
        {
            return users.FirstOrDefault(users => users.Id == id);
        }
        public static void Add(User user)
        {
            users.Add(user);
        }
        public static void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
                users.Remove(user);
        }
        public static void Update(int id, User user)
        {
            var index = users.FindIndex(u => u.Id == id);
            if (index == -1)
                return;
            users[index] = user;

        }

    }
}
