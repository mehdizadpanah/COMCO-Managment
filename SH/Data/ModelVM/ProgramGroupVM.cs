using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM
{
    public class ProgramGroupVm : DefaultModelVm
    {
        [Required]
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Permission { get; set; } = string.Empty;
        public List<ProgramUserVm> Users { get; set; } = new();
    }
}
