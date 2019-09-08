using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class TempData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoListContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ToDoListContext>>()))
            {
                context.ToDoList.AddRange(
                    new ToDoList()
                    {
                        Id = 1,
                        ToDoListName = "My First List",
                        ToDoListDescription = "This is my first list"
                    },
                    new ToDoList()
                    {
                        Id = 2,
                        ToDoListName = "My Second Lst",
                        ToDoListDescription = "This is my second list"
                    });

                context.ToDoListItem.AddRange(
                    new ToDoListItem()
                    {
                        Id = 1,
                        ToDoItem = "Wash Laundry",
                        Description = "Go to the washing machine and put laundry in",
                        IsComplete = true,
                        ToDoListId = 1
                    },
                    new ToDoListItem()
                    {
                        Id = 2,
                        ToDoItem = "Fold Laundry",
                        Description = "After washing fold laundry",
                        IsComplete = false,
                        ToDoListId = 1
                    },
                    new ToDoListItem()
                    {
                        Id = 3,
                        ToDoItem = "Put away Laundry",
                        Description = "Once done folding, put laundry away",
                        IsComplete = false,
                        ToDoListId = 1
                    },
                    new ToDoListItem()
                    {
                        Id = 4,
                        ToDoItem = "Rake the leaves",
                        Description = "Go outside and rake all of the leaves",
                        IsComplete = false,
                        ToDoListId = 2
                    },
                    new ToDoListItem()
                    {
                        Id = 5,
                        ToDoItem = "Paint the mailbox",
                        Description = "Paint the mailbox white",
                        IsComplete = true,
                        ToDoListId = 2
                    },
                    new ToDoListItem()
                    {
                        Id = 6,
                        ToDoItem = "Walk the dog",
                        Description = "Take the dog for a walk",
                        IsComplete = true,
                        ToDoListId = 2
                    },
                    new ToDoListItem()
                    {
                        Id = 7,
                        ToDoItem = "Buy more dog food",
                        Description = "Dogs need to eat too",
                        IsComplete = false,
                        ToDoListId = 2
                    });

                context.SaveChanges();
            }
        }
    }
}
