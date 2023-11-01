using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    public class DefaultModel
    {
        
        public Guid? CreatorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid? UpdatedById { get; set; }
        public bool Deleted { get; set; }
    }
}
