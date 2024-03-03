using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


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
        //public virtual ICollection<User>? Users { get; set; }
        //public int? ManagerId { get; set; }

        //[ForeignKey("ManagerId")]
        //public virtual User Manager { get; set; }
    }
}
