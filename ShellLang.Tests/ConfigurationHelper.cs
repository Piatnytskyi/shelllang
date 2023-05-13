using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ProductsTests
{
    internal class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();
        }
    }
}
