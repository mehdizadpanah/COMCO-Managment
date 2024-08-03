using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models.DataModels
{
    [Table("Sessions")]
    public class UserSession 
    {
        public UserSession()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public required DateTime AccessTokenExpiration { get; set; }
        public required DateTime RefreshTokenExpiration { get; set; }
        public string? UserName { get; set; }
        public string? IP { get; set; }
        public string? BrInfo { get; set; }
        
    }
}
