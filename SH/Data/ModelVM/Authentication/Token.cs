namespace SH.Data.ModelVM.Authentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
