using System;

namespace Helpers.Checkers
{
    public static class ArgumentChecker
    {
        public static void ThrowIfNull<T>(T value, string argumentName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
        public static void ThrowIfNullOrEmpty(string value, string argumentName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
