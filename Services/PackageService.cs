using System;
using System.Collections.Generic;

namespace PackageHandlerApp
{
  public class PackageService
  {
    public Package createPackage()
      {
        Console.WriteLine("Please enter a weight...");
        var weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Please enter a value...");
        var value = Convert.ToDouble(Console.ReadLine());
        var id = Guid.NewGuid();
        return new Package(id, weight, value);
      }
  }
}