using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("Groups")]
    public class Group : DefaultModel
    {
        public Group()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Permission { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
