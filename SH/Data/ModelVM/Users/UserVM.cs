using SH.Service.Public;
using System.ComponentModel.DataAnnotations;

namespace SH.Data.ModelVM.Users
{
    public class UserVM  : DefaultVM
    {
        public UserVM()
        {
            ID = Guid.NewGuid();
            Groups = new HashSet<GroupVM>();
            Teams = new HashSet<TeamVM>();
            FullName = new string(FirstName + " " + LastName);
        }


        public Guid ID { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;
        //[Required (ErrorMessage = "نام کاربری اجباری می باشد!!!")]
        [Required(ErrorMessage = "Username can not be empty")]
        [MaxLength(30, ErrorMessage = "Username can not be longer than 30 character")]
        [MinLength(2, ErrorMessage = "Username can not be shorter than 2 character")]
        public string DcUsername { get; set; } = string.Empty;
        //[Required(ErrorMessage = "نام اجباری می باشد!!!")]

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Fullname must be shorter than 50 character"), Required(ErrorMessage = "Fullname can not be empty")]
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get => phone; set => phone = value.ToPersianNumber(); }
        public string PhoneP { get; set; }
        public string Mobile { get => mobile; set => mobile = value.ToPersianNumber(); }
        public string Address { get; set; }
        [Required]
        public string Position { get; set; }
        public bool IsEnable { get; set; }
        public ICollection<GroupVM>? Groups { get; set; }
        public ICollection<TeamVM>? Teams { get; set; }
        private string phone;
        private string mobile;
    }
}
