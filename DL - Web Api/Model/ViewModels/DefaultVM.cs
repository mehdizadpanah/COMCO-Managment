using DL___Web_Api.Model.Models;

namespace DL___Web_Api.Model.ViewModels
{
    public class DefaultVM
    {
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
    }
}
