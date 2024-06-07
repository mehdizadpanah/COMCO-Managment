using System.Text.Json.Serialization;

namespace SH.Data.ModelVM.Authentication
{
    public class Token
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
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
