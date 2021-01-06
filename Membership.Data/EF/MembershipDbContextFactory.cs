using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Membership.Data.EF
{
    public class MembershipDbContextFactory : IDesignTimeDbContextFactory<MembershipDbContext>
    {
        public MembershipDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MembershipDb");

            var optionsBuilder = new DbContextOptionsBuilder<MembershipDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MembershipDbContext(optionsBuilder.Options);
        }
    }
}
