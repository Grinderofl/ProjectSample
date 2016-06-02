namespace ProjectSample.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            var array = s.ToCharArray();
            array[0] = char.ToUpper(array[0]);
            return new string(array);
        }
    }
}