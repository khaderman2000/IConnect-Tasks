using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserUsingFrameWork.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; }
        [ForeignKey("UserId")]

        public int UserId { get; set; }
        public User? user { get; set; }

    }
}
