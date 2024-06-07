namespace SH.Service.Public
{
    public static class StringExtensions
    {
        public static string ToPersianNumber(this string input)
        {
            if (input == null) return null;
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int j = 0; j < persian.Length; j++)
            {
                input = input.Replace(j.ToString(), persian[j]);
            }
            return input;
        }
    }

}
