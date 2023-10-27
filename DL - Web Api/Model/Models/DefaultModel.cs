namespace DL___Web_Api.Model.Models
{
    public class DefaultModel
    {
        public Users Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Users UpdatedBy { get; set; }
        public bool Deleted { get; set; }
    }
}
