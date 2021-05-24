using System.ComponentModel.DataAnnotations;

namespace frog.Models
{
  public class blogs
  {
    public string Id { get; set; }

    public string CreatorId { get; set; }
    public string name { get; set; }
    [Required]

    public string description { get; set; }
  }
}