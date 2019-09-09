using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public class ToDoListItem
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ToDoItem { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        //Foreign Key
        [Required]
        public long ToDoListId { get; set; }
    }
}
