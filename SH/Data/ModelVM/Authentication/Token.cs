namespace SH.Data.ModelVM.Authentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string UserID { get; set; }
    }
}
