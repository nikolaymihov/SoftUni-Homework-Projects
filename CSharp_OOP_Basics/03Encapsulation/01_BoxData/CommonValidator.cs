using System;

namespace BoxData
{
    public static class CommonValidator
    {
        public static void ValidateRange(double value, string type)
        {
            if (value <= 0)
            {
                throw new NullReferenceException($"{type} cannot be zero or negative.");
            }
        }
    }
}
