using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DL___Web_Api.Model.Models
{
    [Table("Users")]
    public class User : DefaultModel
    {

        public User()
        {
            ID = Guid.NewGuid();
            Groups = new HashSet<Group>();
            Teams = new HashSet<Team>();
        }

        [Key]
        public Guid ID { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;
        [MaxLength(30, ErrorMessage = "طول نام از 50 کاراکتر بیشتر است.")]
        public string DcUsername { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneP { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        [Required]
        public string Position { get; set; }
        public bool IsEnable { get; set; }
        public ICollection<Group>? Groups { get; set; }
        public virtual ICollection<Team>? Teams { get; set; }
        private string phone;
        private string mobile;
    }
}
