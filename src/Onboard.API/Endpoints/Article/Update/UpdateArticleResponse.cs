﻿using System;
namespace Onboard.API.Endpoints.Article.Update
{
  public class UpdateArticleResponse
  {
    public Guid Id { get; set; }
    public string Message { get; set; }

    public UpdateArticleResponse(Guid id, string message)
    {
      Id = id;
      Message = message;
    }
  }
}

