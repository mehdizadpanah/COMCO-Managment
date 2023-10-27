using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("Groups")]
    public class Groups : DefaultModel
    {
        public Groups()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        public Guid ID { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Permission { get; set; }
        public ICollection<Users>? Users { get; set; }
    }
}
