using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("UserTeam")]
    public class UserTeam : DefaultModel 
    {
        public UserTeam()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public ICollection<Team>? Teams { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Position>? Position { get; set; }

    }

        
    
}
