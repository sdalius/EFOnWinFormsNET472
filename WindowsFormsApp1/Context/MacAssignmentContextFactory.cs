using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WindowsFormsApp1.Context
{
    public class MacAssignmentContextFactory : IDesignTimeDbContextFactory<MacAssignmentContext>
    {
        public MacAssignmentContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("MysqlConnection");

            return new MacAssignmentContext(new DbContextOptionsBuilder<MacAssignmentContext>().UseMySql(connstr).Options);
        }
    }
}
