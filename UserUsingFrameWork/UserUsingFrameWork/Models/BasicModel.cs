using System.ComponentModel.DataAnnotations;

namespace UserUsingFrameWork.Models
{
    public interface IBasicModel
    {
        public int Id { get; set; }
    }
    public class BasicModel :IBasicModel
    {
       [Key] public int Id { get; set; }
    }
}
