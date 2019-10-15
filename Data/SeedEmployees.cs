using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Models;

namespace MyStore.Data
{
    public static class SeedEmployees
    {
        public static void Initialize(MyStoreContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(

                    new Employee{
                        Id = 0001,
                        Name = "Admin",
                        Position = "Admin",
                        Wage = 25m,
                        IsCurrentEmployee = true,
                        Password = 0
                    },
                    new Employee
                    {
                        Id = 0002,
                        Name = "Employee 1",
                        Position = "Manager",
                        Wage = 15m,
                        IsCurrentEmployee = true,
                        Password = 1111
                    },
                    new Employee
                    {
                        Id = 0003,
                        Name = "Employee 2",
                        Position = "Team Member",
                        Wage = 10m,
                        IsCurrentEmployee = true,
                        Password = 1111
                    }
                );

                context.SaveChanges();
            }
        }
    }
}