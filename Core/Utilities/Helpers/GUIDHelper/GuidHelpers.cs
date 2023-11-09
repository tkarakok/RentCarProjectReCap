namespace Core.Utilities.Helpers.GUIDHelper
{
    public class GuidHelpers
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
