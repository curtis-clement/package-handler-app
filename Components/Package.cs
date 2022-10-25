using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class Package
  {
    public Package(Guid Id, double Weight, double Value)
    {
      id = Id;
      weight = Weight;
      value = Value;
    }
    public Guid id;
    public double weight {get; set;}
    public double value { get; set; }
  }
}