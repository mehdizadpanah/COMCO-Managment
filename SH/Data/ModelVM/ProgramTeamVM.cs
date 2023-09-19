using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM
{
    public class ProgramTeamVm : DefaultModelVm
    {
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string TeamDescription { get; set; } = string.Empty;
        public List<ProgramUserVm> ProgramUserVms { get; set; } = new List<ProgramUserVm>();
        public ProgramUserVm Manager { get; set; } = new();

    }

}
