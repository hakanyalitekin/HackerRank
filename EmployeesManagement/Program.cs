using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = Employee.GetEmployees();

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            Console.WriteLine();

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            Console.WriteLine();

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }

            Console.ReadLine();
        }


        private static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            return employees.
               GroupBy(e => e.Company)
               .OrderBy(e => e.Key)
               .Select(grp => new
               {
                   CompanyName = grp.Key,
                   Average = (int)Math.Round(grp.Average(e => e.Age))
               }).ToDictionary(item => item.CompanyName, item => item.Average);

        }
      
        private static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            return employees.
                 GroupBy(e => e.Company)
                 .OrderBy(e => e.Key)
                 .Select(grp => new
                 {
                     CompanyName = grp.Key,
                     Count = grp.Count()
                 })
                 .ToDictionary(item => item.CompanyName, item => item.Count);
        }

        private static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            return employees.
               GroupBy(e => e.Company)
               .OrderBy(e => e.Key)
               .Select(grp => new
               {
                   CompanyName = grp.Key,
                   Employee = employees.Where(p => p.Company == grp.Key && p.Age == grp.Max(e => e.Age)).FirstOrDefault()
               })
               .ToDictionary(item => item.CompanyName, item => item.Employee);

        }

    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }


        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
               new Employee {FirstName ="Ainslee",  LastName = "Ginsie",    Age = 28, Company = "Galaxy"},
               new Employee {FirstName ="Libbey",   LastName = "Apdell",    Age = 44, Company = "Starbucks"},
               new Employee {FirstName ="Illa",     LastName = "Stebbings", Age = 49, Company = "Berkshire"},
               new Employee {FirstName ="Laina",    LastName = "Sycamore",  Age = 20, Company = "Berkshire"},
               new Employee {FirstName ="Abbe",     LastName = "Parnell",   Age = 20, Company = "Amazon"},
               new Employee {FirstName ="Ludovika", LastName = "Reveley",   Age = 30, Company = "Berkshire"},
               new Employee {FirstName ="Rene",     LastName = "Antos",     Age = 44, Company = "Galaxy"},
               new Employee {FirstName ="Vinson",   LastName = "Beckenham", Age = 45, Company = "Berkshire"},
               new Employee {FirstName ="Reed",     LastName = "Lynock",    Age = 41, Company = "Amazon"},
               new Employee {FirstName ="Wyndham",  LastName = "Bamfield",  Age = 34, Company = "Berkshire"},
               new Employee {FirstName ="Loraine",  LastName = "Sappson",   Age = 49, Company = "Amazon"},
               new Employee {FirstName ="Abbe",     LastName = "Antonutti", Age = 47, Company = "Starbucks"},

            };
            return employees;
        }
    }

}
