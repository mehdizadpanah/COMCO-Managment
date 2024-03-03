using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DL___Web_Api.Model.Models
{
    [Table("Position")]
    public class Position : DefaultModel
    {
            public Position()
            {
                ID = Guid.NewGuid();
            }

            [Key]
            public Guid ID { get; set; }
            public string PosName { get; set; }
            
        }
    }
