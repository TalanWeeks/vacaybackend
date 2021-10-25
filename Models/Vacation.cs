using System;

namespace vacaybackend.Models
{
public class Vacation : IVacation<int>
  {

      public float Price { get; set; }
      public string Destination { get; set; }
      public new DateTime CreatedAt { get; set; }
      public new DateTime UpdatedAt { get; set; }
  }
}