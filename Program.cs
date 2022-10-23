// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace PackageHandlerApp 
{
  class Program 
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello! Welcome to the our package handling app!");
      bool closeApp = false;
      var departmentService = new DepartmentService();
      var AvailableDepartments = departmentService.AvailableDepartments;
      List<Package> HoldListForInsurance = new List<Package>();

      do
      {
        var systemUser = "Curtis";
        Console.WriteLine("What would you like to do? You may choose, 'Add Package', 'Process Insurance Holds', 'Quit'");
        var selectedOption = Console.ReadLine();

        switch (selectedOption)
        {
          case "Add Package":
            int id = departmentService.totalPackageCount();;
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
              departmentService.addPackageToDepartment(packageToAdd);
            }
            break;
          case "Process Insurance Holds":
            List<Package> insuranceHoldsProcessed = new List<Package>();
            foreach (Package packageOnHold in HoldListForInsurance)
            {
              Console.WriteLine
              (
                $"Package with id: {packageOnHold.id}, and weight: {packageOnHold.weight} requires insurance. Please verify your user identity to confirm adding insurance."
              );
              string userNameInput = Console.ReadLine()!;
              if (userNameInput == systemUser)
              {
                departmentService.addPackageToDepartment(packageOnHold);
                insuranceHoldsProcessed.Add(packageOnHold);
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

            Console.WriteLine($"You processed {departmentService.totalPackageCount()} packages today!");
            Console.WriteLine("Thanks for using our App! Have a nice day.");
            closeApp = true;
            break;
        }
      }
      while (!closeApp);
    }
  }
}

