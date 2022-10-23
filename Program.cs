// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace PackageHandlerApp 
{
  // public class Package
  // {
  //   public Package(int Id, double Weight, double Value)
  //   {
  //     id = Id;
  //     weight = Weight;
  //     value = Value;
  //   }
  //   public int id;
  //   public double weight {get; set;}
  //   private double value { get; set; }
  //   public bool insuranceIsRequired()
  //   {
  //     return value > 1000;
  //   }
  // }

  // public class Department
  // {
  //   public string name = "";
  //   public double maxHandledWeight { get; set; }
  //   public double valueRequiredForInsurnace { get; set; }
  //   public List<Package> DepartmentPackages = new List<Package>();
  //   public void addPackageToDepartment(Package package)
  //   {
  //     this.DepartmentPackages.Add(package);
  //   }
  // }
  class Program 
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! Welcome to the our package handling app!");
      bool closeApp = false;
      List<Package> HoldListForInsurance = new List<Package>();

      List<Department> AvailableDepartments = new List<Department>()
      {
        new Department()
        {
          name = "Mail",
          maxHandledWeight = 1,
          valueRequiredForInsurnace = 1000,
        },
        new Department()
        {
          name = "Regular",
          maxHandledWeight = 10,
          valueRequiredForInsurnace = 1000,
        },
        new Department()
        {
          name = "Heavy",
          maxHandledWeight = double.PositiveInfinity,
          valueRequiredForInsurnace = 1000,
        },
      };

      int totalPackageCount()
      {
        int totalPacakgeCount = 0;
        foreach (Department department in AvailableDepartments)
        {
          totalPacakgeCount += department.DepartmentPackages.Count;
        }
        return totalPacakgeCount;
      }

      do
      {
        var systemUser = "Curtis";
        Console.WriteLine("What would you like to do? You may choose, 'Add Package', 'Process Insurance Holds', 'Quit'");
        var selectedOption = Console.ReadLine();

        switch (selectedOption)
        {
          case "Add Package":
            int id = totalPackageCount();
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
              if (packageToAdd.weight <= 1)
              {
                var mailDepartment = AvailableDepartments.Find(item => item.name == "Mail");
                mailDepartment!.addPackageToDepartment(packageToAdd);
                Console.WriteLine("Your package was added to the Mail department!");
              } else if (packageToAdd.weight <= 10)
              {
                var regularDepartment = AvailableDepartments.Find(item => item.name == "Regular");
                regularDepartment!.addPackageToDepartment(packageToAdd);
                Console.WriteLine("Your package was added to the Regular department!");
              } else
              {
                var heavyDepartment = AvailableDepartments.Find(item => item.name == "Heavy");
                heavyDepartment!.addPackageToDepartment(packageToAdd);
                Console.WriteLine("Your package was added to the Heavy department!");
              }
            }
            break;
          case "Process Insurance Holds":
            List<Package> insuranceHoldsProcessed = new List<Package>();
            foreach (Package item in HoldListForInsurance)
            {
              Console.WriteLine
              (
                $"Package with id: {item.id}, and weight: {item.weight} requires insurance. Please verify your user identity to confirm adding insurance."
              );
              string userNameInput = Console.ReadLine()!;
              if (userNameInput == systemUser)
              {
                if (item.weight <= 1)
                {
                  var mailDepartment = AvailableDepartments.Find(item => item.name == "Mail");
                  mailDepartment!.addPackageToDepartment(item);
                  Console.WriteLine("Your package was added to the Mail department!");
                } else if (item.weight <= 10)
                {
                  var regularDepartment = AvailableDepartments.Find(item => item.name == "Regular");
                  regularDepartment!.addPackageToDepartment(item);
                  Console.WriteLine("Your package was added to the Regular department!");
                } else
                {
                  var heavyDepartment = AvailableDepartments.Find(item => item.name == "Heavy");
                  heavyDepartment!.addPackageToDepartment(item);
                  Console.WriteLine("Your package was added to the Heavy department!");
                }
                insuranceHoldsProcessed.Add(item);
                Console.WriteLine("Package has been processed!");
              }
              else
              {
                Console.WriteLine("Sorry, that user name did not match!");
                break;
              }
            }

            foreach (Package item in insuranceHoldsProcessed)
            {
              HoldListForInsurance.Remove(item);
            }
            break;
          case "Quit":
            if (HoldListForInsurance.Count > 0)
            {
              Console.WriteLine("Please proccess your insurance holds before quitting!");
              break;
            }

            Console.WriteLine($"You processed {totalPackageCount()} packages today!");
            Console.WriteLine("Thanks for using our App! Have a nice day.");
            closeApp = true;
            break;
        }
      }
      while (!closeApp);
    }
  }
}

