using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("Teams")]
    public class Team : DefaultModel
    {
        public Team()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<User>? Users { get; set; }
        public Guid ManagerId { get; set; }
        public User? Manager { get; set; }
    }
}
