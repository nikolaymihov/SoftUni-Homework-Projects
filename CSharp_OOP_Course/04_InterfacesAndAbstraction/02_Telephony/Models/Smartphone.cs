namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            return CommonValidator.IsAValidPhoneNumber(number) ? $"Calling... {number}" : Constants.INVALID_NUMBER_MSG;
        }

        public string Browse(string site)
        {
            return CommonValidator.IsAValidSite(site) ? $"Browsing: {site}!" : Constants.INVALID_SITE_MSG;
        }
    }
}
