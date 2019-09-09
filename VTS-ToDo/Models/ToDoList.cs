using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public class ToDoList
    {
        public ToDoList()
        {
            ToDoListItems = new HashSet<ToDoListItem>();
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ToDoListName { get; set; }
        public string ToDoListDescription { get; set; }

        public ICollection<ToDoListItem> ToDoListItems { get; set; }
    }
}
