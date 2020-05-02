using System;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            StringBuilder output = new StringBuilder();
            CallPhoneNumbers(phoneNumbers, output);
            BrowseWebsites(websites, output);

            Console.WriteLine(output.ToString().TrimEnd());

        }
        private static void CallPhoneNumbers(string[] phoneNumbersToCall, StringBuilder output)
        {
            ICallable phone = null;

            foreach (string phoneNumber in phoneNumbersToCall)
            {
                if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }

                output.AppendLine(phone.Call(phoneNumber));
            }
        }

        private static void BrowseWebsites(string[] websitesToBrowse, StringBuilder output)
        {
            Smartphone smartphone = new Smartphone();

            foreach (string website in websitesToBrowse)
            { 
                output.AppendLine(smartphone.Browse(website));
            }
        }
    }
}
