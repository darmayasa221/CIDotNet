using System.ComponentModel.DataAnnotations;

public class Request {
  public const string Route = "/user";
  [Required]
  public string? Name { get; set; }
}
