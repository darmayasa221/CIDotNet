using System;
using Ardalis.Specification;

namespace Onboard.Core.Aggregate.Article.Specifications
{
  public class UserByIdWithArticles : Specification<AUser>, ISingleResultSpecification
  {
    public UserByIdWithArticles(Guid userId)
    {
      Query
          .Where(user => user.id == userId)
          .Include(user => user.Articles);
    }
  }

}