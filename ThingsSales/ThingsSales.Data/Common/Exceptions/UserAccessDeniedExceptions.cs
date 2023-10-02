namespace ThingsSales.Data.Common.Exceptions
{
    public class UserAccessDeniedExceptions : IOException
    {
        public UserAccessDeniedExceptions(string name) : base($"User: {name} access denied!") { }
    }
}
