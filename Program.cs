// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace PackageHandlerApp 
{
  public class Package
  {
    public Package(int Id, double Weight, double Value)
    {
      id = Id;
      weight = Weight;
      value = Value;
    }
    private int id;
    public double weight {get; set;}
    private double value { get; set; }
    public bool insuranceIsRequired()
    {
      return value > 1000;
    }
  }

  public class Department
  {
    public string name = "";
    public double maxHandledWeight { get; set; }
    public double valueRequiredForInsurnace { get; set; }
  }
  class Program 
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! Welcome to the our package handling app!");
      bool closeApp = false;
      List<Package> Packages = new List<Package>();
      List<Package> HoldListForInsurance = new List<Package>();

      do
      {
        Console.WriteLine("What would you like to do? You may choose, 'Add Package', 'Proccess Insurance Holds', 'Quit'");
        var selectedOption = Console.ReadLine();

        switch (selectedOption)
        {
          case "Add Package":
            int id = Packages.Count;
            Console.WriteLine("Please enter a weight...");
            var weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter a value...");
            var value = Convert.ToDouble(Console.ReadLine());
            var packageToAdd = new Package(id, weight, value);
            if (packageToAdd.insuranceIsRequired())
            {
              HoldListForInsurance.Add(packageToAdd);
              Console.WriteLine("Your package requires insurance and processing is momentarily suspended.");
            }
            else {
              Packages.Add(packageToAdd);
              Console.WriteLine("Your package was added!");
            }
            break;
          case "Proccess Insurance Holds":
            // Add logic to process from insurance and add to department
            break;
          case "Quit":
            if (HoldListForInsurance.Count > 0)
            {
              Console.WriteLine("Please proccess your insurance holds before quitting!");
              break;
            }
            Console.WriteLine("Thanks for using our App! Have a nice day.");
            closeApp = true;
            break;
        }
      }
      while (!closeApp);

      // Check each package for weight and then insurance, if value is under then pass to department, if over pass to insurance

      // Loop through insurance to validate the insurance of each pending package (some sort of validation logic here?)

      // Once all insurance cases are complete, verify the amount of packages going to each department

      // Once verified, write the info for each package to a file and close the app
    }
  }
}

