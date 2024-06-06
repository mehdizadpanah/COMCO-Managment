using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    [Table("ValidTokens")]
    public class ValidToken : DefaultModel
    {
        public ValidToken()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public Guid TokenID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid UserID { get; set; }
        
    }
}
