using System.ComponentModel.DataAnnotations.Schema;

namespace DL___Web_Api.Model.Models
{
    public class DefaultModel
    {
        public User Creator { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public User UpdatedBy { get; set; }
        public Guid UpdatedById { get; set; }
        public bool Deleted { get; set; }
    }
}
