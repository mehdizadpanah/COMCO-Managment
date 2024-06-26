using System.ComponentModel.DataAnnotations;
using SH.Service.Public;

namespace SH.Data.ModelVM.Users
{
    public class ProgramUserVm : DefaultVM 
    {
        public ProgramUserVm()
        {
            Id = Guid.NewGuid();
            FullName = new string(FirstName + " " + LastName);
        }


        public Guid Id { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;
        //[Required (ErrorMessage = "نام کاربری اجباری می باشد!!!")]
        public string DcUsername { get; set; } = string.Empty;
        //[Required(ErrorMessage = "نام اجباری می باشد!!!")]

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get => phone; set => phone = value.ToPersianNumber(); }
        public string PhoneP { get; set; }
        public string Mobile { get => mobile; set => mobile = value.ToPersianNumber(); }
        public string Address { get; set; }
        [Required]
        public string Position { get; set; }
        public bool IsEnable { get; set; } = true;

        public List<ProgramGroupVm>? ProgramGroupVms { get; set; }
        public ProgramTeamVm? ProgramTeamVm { get; set; }

        private string phone;
        private string mobile;
    }
}
