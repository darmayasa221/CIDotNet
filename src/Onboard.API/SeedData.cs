using Onboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Onboard.Core.Aggregate;

namespace Onboard.Web;

public static class SeedData
{
  public static readonly AUser migrateUser = new AUser("root","root_username","root@email.com", 1);

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    // foreach (var item in dbContext.User)
    // {
    //   dbContext.Remove(item);
    // }
   
    var count = dbContext.User.Count();
    if  (count == 0) {
    dbContext.User.Add(migrateUser);
    dbContext.SaveChanges();
    }
  }
}
