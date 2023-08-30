using Onboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Onboard.Core.Aggregate;

namespace Onboard.Web;

public static class SeedData
{
  public static readonly AUser TestProject1 = new AUser("root","root_username","root@email.com",1);
  // public static readonly ToDoItem ToDoItem1 = new ToDoItem
  // {
  //   Title = "Get Sample Working",
  //   Description = "Try to get the sample to build."
  // };
  // public static readonly ToDoItem ToDoItem2 = new ToDoItem
  // {
  //   Title = "Review Solution",
  //   Description = "Review the different projects in the solution and how they relate to one another."
  // };
  // public static readonly ToDoItem ToDoItem3 = new ToDoItem
  // {
  //   Title = "Run and Review Tests",
  //   Description = "Make sure all the tests run and review what they are doing."
  // };

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
    foreach (var item in dbContext.Users)
    {
      dbContext.Remove(item);
    }
    dbContext.Users.Add(TestProject1);

    dbContext.SaveChanges();
  }
}
