using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("Sessions")]
    public class Session 
    {
        public Session()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public string TokenID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string UserName { get; set; }
        
    }
}
