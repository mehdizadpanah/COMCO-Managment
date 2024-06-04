using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM.Users
{
    public class ProgramTeamVm : DefaultVM
    {
        public ProgramTeamVm()
        {
            TeamId = Guid.NewGuid();
        }

        [Required]
        public Guid TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public string TeamDescription { get; set; } = string.Empty;
        public List<ProgramUserVm>? ProgramUserVms { get; set; }
        public ProgramUserVm? Manager { get; set; }

    }

}
