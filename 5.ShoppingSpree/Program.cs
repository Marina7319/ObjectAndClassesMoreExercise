using System;
using System.Linq;
using System.Collections.Generic;
namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int i = 0;
            double sum = 0;
            double maxNum = double.MinValue;
            string department = "";
            List<Employee> employeesList = new List<Employee>();
            while (i < N)
            {
                i++;
                string[] employees = Console.ReadLine().Split(" ");
                var employee = new Employee(employees[0], double.Parse(employees[1]), employees[2]);
                employeesList.Add(employee);
                double sumSalary = 0;
                int employeeCount = 0;
                foreach (Employee emp in employeesList)
                {
                    if (employee.Department == emp.Department)
                    {
                        sumSalary += emp.Salary;
                        employeeCount++;
                    }
                }
                double empoyeeSalary = sumSalary / employeeCount;
                sum += empoyeeSalary;
                if (empoyeeSalary > maxNum)
                {
                    maxNum = empoyeeSalary;
                    department = employees[2];
                }
            }
            Console.WriteLine($"Highest Average Salary: {department}");
            employeesList = employeesList.OrderByDescending(currEmployee => currEmployee.Salary).ToList();
            foreach (Employee emp in employeesList)
            {
                if (emp.Department == department)
                {
                    Console.WriteLine(emp);
                }
            }
        }
    }
    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public override string ToString() => $"{Name} {Salary:f2} ";
    }
}
