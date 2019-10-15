using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Data
{
    public static class SeedMenus
    {
        public static void Initialize(MyStoreContext context)
        {
            if (!context.Menus.Any())
            {
                context.Menus.AddRange(
                    new Menu
                    {
                        Title = "Breakfast"
                    },
                    new Menu
                    {
                        Title = "Lunch"
                    },
                    new Menu
                    {
                        Title = "Dinner"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
