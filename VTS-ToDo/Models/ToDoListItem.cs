using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoListItem
    {
        public long Id { get; set; }
        public string ToDoItem { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}
