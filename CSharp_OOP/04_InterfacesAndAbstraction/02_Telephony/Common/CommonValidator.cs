using System.Linq;

namespace Telephony
{
    public static class CommonValidator
    {
        public static bool IsAValidPhoneNumber(string number)
        {
            if (number.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAValidSite(string site)
        {
            if (!site.Any(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
