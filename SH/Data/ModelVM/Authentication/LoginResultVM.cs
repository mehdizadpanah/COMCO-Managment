using System.Text.Json.Serialization;

namespace SH.Data.ModelVM.Authentication
{
    public class LoginResultVM
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }
        [JsonPropertyName("userID")]
        public string UserID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("family")]
        public string Family { get; set; }
    }
}
