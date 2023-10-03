namespace ThingsSales.Data.ValidationExtensions
{
    public static class NullValidationExtensions
    {
        public static T ThrowIfNull<T>(this T argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }
    }
}
