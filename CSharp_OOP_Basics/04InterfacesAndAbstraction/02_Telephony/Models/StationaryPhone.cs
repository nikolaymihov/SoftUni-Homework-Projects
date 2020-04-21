namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return CommonValidator.IsAValidPhoneNumber(number) ? $"Dialing... {number}" : Constants.INVALID_NUMBER_MSG;
        }
    }
}
