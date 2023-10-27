using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("Teams")]
    public class Teams : DefaultModel
    {
        public Teams()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        public Guid ID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<Users>? ProgramUserVms { get; set; }
        public Users? Manager { get; set; }
    }
}
