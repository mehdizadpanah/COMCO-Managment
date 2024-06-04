using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM.Users
{
    public class ProgramGroupVm : DefaultModelVm
    {
        public ProgramGroupVm()
        {
            GroupId = Guid.NewGuid();
        }

        [Required]
        public Guid GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Permission { get; set; } = string.Empty;
        public List<ProgramGroupVm>? Users { get; set; }
    }
}
