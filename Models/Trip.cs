using System;

namespace vacaybackend.Models
{
  public class Trip : IVacation<int>
  {
    public int Price { get; set; }
    public string Destination { get; set; }

    public string CreatorId { get; set; }

    public Profile Creator { get; set; }
    public new DateTime CreatedAt { get; set; }
    public new DateTime UpdatedAt { get; set; }
  }
}