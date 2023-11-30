namespace dotNetGregsListVue.Models;

public class Car
{
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public string ImgUrl { get; set; }
  public string Body { get; set; }
  public int? Price { get; set; }
  public string Description { get; set; }
  public string CreatorId { get; set; }
  public Profile Seller { get; set; }
}
