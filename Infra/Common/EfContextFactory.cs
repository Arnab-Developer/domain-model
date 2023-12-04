using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Common;

public class EfContextFactory : IDesignTimeDbContextFactory<App1Context>
{
    App1Context IDesignTimeDbContextFactory<App1Context>.CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<App1Context>();
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=App1Db;Integrated Security=True");

        return new App1Context(optionsBuilder.Options);
    }
}