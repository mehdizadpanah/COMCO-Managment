using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM.Users
{
    public class TeamVM : DefaultVM
    {
        public TeamVM()
        {
            ID = Guid.NewGuid();
        }

        [Required]
        public Guid ID { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string TeamDescription { get; set; } = string.Empty;
        public ICollection<UserVM>? UserVm { get; set; }
        public UserVM? Manager { get; set; }
    }
}
