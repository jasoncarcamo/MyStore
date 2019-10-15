using System;
using System.Collections.Generic;
using System.Linq;
using MyStore.Models;

namespace MyStore.Data
{
    public static class SeedTimeSheets
    {
        public static void Initialize(MyStoreContext context)
        {
            if (!context.TimeSheets.Any())
            {
                context.TimeSheets.AddRange(
                    new TimeSheet
                    {
                        Hours = 10,
                        Rate = 15.5f,
                        Date = "2/07/19",
                        EmployeeId = 1
                    },
                    new TimeSheet
                    {
                        Hours = 20,
                        Rate = 10f,
                        Date = "04/23/19",
                        EmployeeId = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
