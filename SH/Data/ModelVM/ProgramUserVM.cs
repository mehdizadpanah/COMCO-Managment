using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM
{
    public class ProgramUserVm : DefaultModelVm
    {
        public ProgramUserVm()
        {
            Id = Guid.NewGuid();
            FullName = new string(FirstName + " " + LastName);
        }

        
        public Guid Id { get; set; } 
        public string DcUsername { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;   
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public List<ProgramGroupVm>? ProgramGroupVms { get; set; }
        public ProgramTeamVm? ProgramTeamVm { get; set; }


    }
}
