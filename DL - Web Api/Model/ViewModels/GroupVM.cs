using SH.Data.ModelVM;
using System.ComponentModel.DataAnnotations;

namespace DL___Web_Api.Model.ViewModels
{
    public class GroupVM : DefaultVM
    {
        public GroupVM()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        public Guid ID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Permission { get; set; } = string.Empty;
        public ICollection<GroupVM>? Users { get; set; }
    }
}
