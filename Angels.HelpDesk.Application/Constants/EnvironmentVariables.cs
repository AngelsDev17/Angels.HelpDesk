using System.Text;

namespace Angels.HelpDesk.Application.Constants
{
    public static class EnvironmentVariables
    {
        public static string PREFIX => Environment.GetEnvironmentVariable("HelpDeskPrefix");

        public static byte[] SECRET_KEY => Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable(PREFIX + "SECRET_KEY"));
    }
}
