using System;
using System.Collections.Generic;
using System.Linq;
using MyStore.Models;

namespace MyStore.Data
{
    public static class SeedMenuItems
    {
        public static void Initialize(MyStoreContext context)
        {
            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new MenuItem
                    {
                        Name = "Menu 1 Item 1 Name",
                        Description = "Menu 1 Item 1 Description",
                        Inventory = 10,
                        Price = 2.5m,
                        MenuId = 1
                    },
                    new MenuItem
                    {
                        Name = "Menu 1 Item 2 Name",
                        Description = "Menu 1 Item 2 Description",
                        Inventory = 20,
                        Price = 3.0m,
                        MenuId = 1
                    },
                    new MenuItem
                    {
                        Name = "Menu 2 Item 1 Name",
                        Description = "Menu 2 Item 1 Description",
                        Inventory = 5,
                        Price = 1.5m,
                        MenuId = 2
                    },
                    new MenuItem
                    {
                        Name = "Menu 3 Item 1 Name",
                        Description = "Menu 3 Item 1 Description",
                        Inventory = 10,
                        Price = 4.5m,
                        MenuId = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
